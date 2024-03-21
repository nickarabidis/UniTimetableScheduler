using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler.WinForm
{
    public partial class CourseForm : Form
    {
        public CourseForm()
        {
            InitializeComponent();
        }

        private void CourseForm_Load(object sender, EventArgs e)
        {
            setComboBoxes();
            ClearRecords();

            LoadData();

        }

        private bool Validation()
        {
            bool result = false;

            if (string.IsNullOrEmpty(courseIdTextBox.Text))
            {
                courseErrorProvider.Clear();
                courseErrorProvider.SetError(courseIdTextBox, "CourseID Required");
            }
            else if (string.IsNullOrEmpty(courseNameTextBox.Text))
            {
                courseErrorProvider.Clear();
                courseErrorProvider.SetError(courseNameTextBox, "Name Required");
            }
            else if (string.IsNullOrEmpty(courseLabComboBox.Text))
            {
                courseErrorProvider.Clear();
                courseErrorProvider.SetError(courseLabComboBox, "Lab Required");
            }
            else
            {
                courseErrorProvider.Clear();
                result = true;
            }
            return result;
        }

        private bool ifCourseExists(SQLiteConnection con, string courseId)
        {
            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select 1 From [Course] WHERE [CourseID] = '" + courseId + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void courseAddButton_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                SQLiteConnection con = Database.GetConnection();

                var sqlQuery = "";
                if (ifCourseExists(con, courseIdTextBox.Text))
                {
                    sqlQuery = @"UPDATE [Course] SET [CourseID] = '" + courseIdTextBox.Text + "', [Name] = '" + courseNameTextBox.Text + "', [Lab] = '" + courseLabComboBox.Text + "' WHERE [CourseID] = '" + courseIdTextBox.Text + "'";
                }
                else
                {
                    sqlQuery = @"INSERT INTO [Course] ([CourseID],[Name],[Lab]) VALUES 
                            ('" + courseIdTextBox.Text + "','" + courseNameTextBox.Text + "','" + courseLabComboBox.Text + "')";
                }

                SQLiteCommand cmd = new SQLiteCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();


                MessageBox.Show("Record Saved Successfully");
                LoadData();
                ClearRecords();
            }
        }

        private void courseClearButton_Click(object sender, EventArgs e)
        {
            ClearRecords();
        }

        private void ClearRecords()
        {
            courseIdTextBox.Clear();
            courseNameTextBox.Clear();
            courseLabComboBox.ResetText();

            courseIdTextBox.Enabled = true;
            courseAddButton.Text = "Add";

        }

        private void courseDeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (Validation())
                {
                    SQLiteConnection con = Database.GetConnection();

                    var sqlQuery = "";
                    if (ifCourseExists(con, courseIdTextBox.Text))
                    {

                        sqlQuery = @"DELETE FROM [Course] WHERE [CourseID] = '" + courseIdTextBox.Text + "'";
                        SQLiteCommand cmd = new SQLiteCommand(sqlQuery, con);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Record Deleted Successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Record Doesn't Exist!");
                    }
                    LoadData();
                    ClearRecords();
                }
            }
        }

        public void LoadData()
        {
            SQLiteConnection con = Database.GetConnection();

            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select * From [Course]", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            courseDataGridView.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                int n = courseDataGridView.Rows.Add();
                courseDataGridView.Rows[n].Cells["dgCourseId"].Value = int.Parse(row["CourseID"].ToString());
                courseDataGridView.Rows[n].Cells["dgCourseName"].Value = row["Name"].ToString();
                courseDataGridView.Rows[n].Cells["dgCourseLab"].Value = bool.Parse(row["Lab"].ToString());
            }

            if (courseDataGridView.Rows.Count > 0)
            {
                totalCourseValueLabel.Text = courseDataGridView.Rows.Count.ToString();

            }
            else
            {
                totalCourseValueLabel.Text = "0";

            }

        }



        private void courseDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            courseAddButton.Text = "Update";
            courseIdTextBox.Enabled = false;

            courseIdTextBox.Text = courseDataGridView.SelectedRows[0].Cells["dgCourseId"].Value.ToString();
            courseNameTextBox.Text = courseDataGridView.SelectedRows[0].Cells["dgCourseName"].Value.ToString();
            courseLabComboBox.Text = courseDataGridView.SelectedRows[0].Cells["dgCourseLab"].Value.ToString();
        }


        private void setComboBoxes()
        {
            bool[] labs = new bool[] { true, false };
            courseLabComboBox.DataSource = labs;
        }

        private void courseIdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void deleteAllButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to DELETE ALL the data?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                SQLiteConnection con = Database.GetConnection();

                var sqlQuery = "";

                sqlQuery = @"DELETE FROM [Course]";
                SQLiteCommand cmd = new SQLiteCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("All Records Deleted Successfully!");

                LoadData();
                ClearRecords();
            }
        }


        private void printButton_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection con = Database.GetConnection();
                DataTable data = LoadDataFromDatabase(con);

                string fileName = "CourseData.txt";
                ExportDataToTxt(data, fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

        }

        private DataTable LoadDataFromDatabase(SQLiteConnection con)
        {
            DataTable dataTable = new DataTable();

            try
            {
                //con.Open();
                string query = "SELECT * FROM Course";

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, con))
                {
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading data from the database: {ex.Message}");
            }

            return dataTable;
        }

        public void ExportDataToTxt(DataTable data, string fileName)
        {
            try
            {
                // Get the path to the desktop folder
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                // Create a directory named "UniTimetableSchedulerData" on the desktop if it doesn't exist
                string directoryPath = Path.Combine(desktopPath, "UniTimetableSchedulerData");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // Combine the directory path and file name to get the full file path
                string filePath = Path.Combine(directoryPath, fileName);

                // Create or overwrite the file
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Write header
                    writer.WriteLine("CourseID, Name, Lab");

                    // Write rows
                    foreach (DataRow row in data.Rows)
                    {
                        writer.WriteLine($"{row["CourseID"]}, {row["Name"]}, {row["Lab"]}");
                    }
                }

                MessageBox.Show($"Course data has been exported to the file '{fileName}' on the desktop successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
