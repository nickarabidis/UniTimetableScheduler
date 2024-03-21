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
    public partial class ProfessorForm : Form
    {
        public ProfessorForm()
        {
            InitializeComponent();
        }
        private void ProfessorForm_Load(object sender, EventArgs e)
        {

            setComboBoxes();
            ClearRecords();

            LoadData();
        }

        private bool Validation()
        {
            bool result = false;

            if (string.IsNullOrEmpty(professorIdTextBox.Text))
            {
                professorErrorProvider.Clear();
                professorErrorProvider.SetError(professorIdTextBox, "ProfessorID Required");
            }
            else if (string.IsNullOrEmpty(professorNameTextBox.Text))
            {
                professorErrorProvider.Clear();
                professorErrorProvider.SetError(professorNameTextBox, "Name Required");
            }
            else if (string.IsNullOrEmpty(professorMeetingComboBox.Text))
            {
                professorErrorProvider.Clear();
                professorErrorProvider.SetError(professorMeetingComboBox, "Meeting Required");
            }
            else
            {
                professorErrorProvider.Clear();
                result = true;
            }
            return result;
        }

        private bool ifProfessorExists(SQLiteConnection con, string professorId)
        {
            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select 1 From [Professor] WHERE [ProfessorID] = '" + professorId + "' ", con);
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



        private void professorAddButton_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                SQLiteConnection con = Database.GetConnection();

                var sqlQuery = "";
                if (ifProfessorExists(con, professorIdTextBox.Text))
                {
                    sqlQuery = @"UPDATE [Professor] SET [ProfessorID] = '" + professorIdTextBox.Text + "', [Name] = '" + professorNameTextBox.Text + "', [Meeting] = '" + professorMeetingComboBox.Text + "' WHERE [ProfessorID] = '" + professorIdTextBox.Text + "'";
                }
                else
                {
                    sqlQuery = @"INSERT INTO [Professor] ([ProfessorID],[Name],[Meeting]) VALUES 
                            ('" + professorIdTextBox.Text + "','" + professorNameTextBox.Text + "','" + professorMeetingComboBox.Text + "')";
                }

                SQLiteCommand cmd = new SQLiteCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();


                MessageBox.Show("Record Saved Successfully");
                LoadData();
                ClearRecords();
            }
        }

        private void professorClearButton_Click(object sender, EventArgs e)
        {
            ClearRecords();
        }

        private void ClearRecords()
        {
            professorIdTextBox.Clear();
            professorNameTextBox.Clear();
            professorMeetingComboBox.ResetText();

            professorIdTextBox.Enabled = true;
            professorAddButton.Text = "Add";

        }

        private void professorDeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (Validation())
                {
                    SQLiteConnection con = Database.GetConnection();

                    var sqlQuery = "";
                    if (ifProfessorExists(con, professorIdTextBox.Text))
                    {

                        sqlQuery = @"DELETE FROM [Professor] WHERE [ProfessorID] = '" + professorIdTextBox.Text + "'";
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

            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select * From [Professor]", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            professorDataGridView.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                int n = professorDataGridView.Rows.Add();
                professorDataGridView.Rows[n].Cells["dgProfessorId"].Value = int.Parse(row["ProfessorID"].ToString());
                professorDataGridView.Rows[n].Cells["dgProfessorName"].Value = row["Name"].ToString();
                professorDataGridView.Rows[n].Cells["dgProfessorMeeting"].Value = bool.Parse(row["Meeting"].ToString());
            }

            if (professorDataGridView.Rows.Count > 0)
            {
                totalProfessorValueLabel.Text = professorDataGridView.Rows.Count.ToString();

            }
            else
            {
                totalProfessorValueLabel.Text = "0";

            }

        }

        private void setComboBoxes()
        {
            //string[] categories = new string[] { "Monimos", "Ektaktos" };

            bool[] categories = new bool[] { true, false };

            professorMeetingComboBox.DataSource = categories;

            //SQLiteConnection con = Database.GetConnection();

            //try
            //{
            //    // Category data in ComboBox
            //    string categoryQuery = "SELECT Category FROM Professor";
            //    using (SQLiteCommand cmd = new SQLiteCommand(categoryQuery, con))
            //    {
            //        using (SQLiteDataReader reader = cmd.ExecuteReader())
            //        {
            //            if (reader.HasRows)
            //            {
            //                while (reader.Read())
            //                {
            //                    professorCategoryComboBox.Items.Add(reader["Category"].ToString());
            //                }
            //            }
            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error: " + ex.Message);
            //}
        }

        private void professorDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            professorAddButton.Text = "Update";
            professorIdTextBox.Enabled = false;

            professorIdTextBox.Text = professorDataGridView.SelectedRows[0].Cells["dgProfessorId"].Value.ToString();
            professorNameTextBox.Text = professorDataGridView.SelectedRows[0].Cells["dgProfessorName"].Value.ToString();
            professorMeetingComboBox.Text = professorDataGridView.SelectedRows[0].Cells["dgProfessorMeeting"].Value.ToString();
        }

        private void professorIdTextBox_KeyPress(object sender, KeyPressEventArgs e)
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

                sqlQuery = @"DELETE FROM [Professor]";
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

                string fileName = "ProfessorData.txt";
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
                string query = "SELECT * FROM Professor";

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
                    writer.WriteLine("ProfessorID, Name, Meeting");

                    // Write rows
                    foreach (DataRow row in data.Rows)
                    {
                        writer.WriteLine($"{row["ProfessorID"]}, {row["Name"]}, {row["Meeting"]}");
                    }
                }

                MessageBox.Show($"Professor data has been exported to the file '{fileName}' on the desktop successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
