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
    public partial class DependencyForm : Form
    {
        public DependencyForm()
        {
            InitializeComponent();
        }

        private void DependencyForm_Load(object sender, EventArgs e)
        {
            setComboBoxes();
            ClearRecords();

            LoadData();
        }

        private bool Validation()
        {
            bool result = false;

            if (string.IsNullOrEmpty(dependencyCourseIdComboBox.Text))
            {
                dependencyErrorProvider.Clear();
                dependencyErrorProvider.SetError(dependencyCourseIdComboBox, "CourseId Required");
            }
            else if (string.IsNullOrEmpty(dependencyDependentCourseIdComboBox.Text))
            {
                dependencyErrorProvider.Clear();
                dependencyErrorProvider.SetError(dependencyDependentCourseIdComboBox, "DependentCourseId Required");
            }
            else if (string.IsNullOrEmpty(dependencyInHowManyDaysComboBox.Text))
            {
                dependencyErrorProvider.Clear();
                dependencyErrorProvider.SetError(dependencyInHowManyDaysComboBox, "InHowManyDays Required");
            }
            else
            {
                dependencyErrorProvider.Clear();
                result = true;
            }
            return result;
        }

        private bool ifDependencyExists(SQLiteConnection con, string courseId, string dependentCourseId)
        {
            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select 1 From [Dependency] WHERE [CourseID] = '" + courseId + "' AND [DependentCourseID] = '" + dependentCourseId + "'", con);
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

        private void dependencyAddButton_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                SQLiteConnection con = Database.GetConnection();

                var sqlQuery = "";
                if (ifDependencyExists(con, dependencyCourseIdComboBox.Text, dependencyDependentCourseIdComboBox.Text))
                {
                    sqlQuery = @"UPDATE [Dependency] SET [CourseID] = '" + dependencyCourseIdComboBox.Text + "', [DependentCourseID] = '" + dependencyDependentCourseIdComboBox.Text + "', [InHowManyDays] = '" + dependencyInHowManyDaysComboBox.Text + "' WHERE [CourseID] = '" + dependencyCourseIdComboBox.Text + "' AND [DependentCourseID] = '" + dependencyDependentCourseIdComboBox.Text + "' ";
                }
                else
                {
                    sqlQuery = @"INSERT INTO [Dependency] ([CourseID],[DependentCourseID],[InHowManyDays]) VALUES 
                            ('" + dependencyCourseIdComboBox.Text + "','" + dependencyDependentCourseIdComboBox.Text + "','" + dependencyInHowManyDaysComboBox.Text + "')";
                }

                SQLiteCommand cmd = new SQLiteCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();


                MessageBox.Show("Record Saved Successfully");
                LoadData();
                ClearRecords();
            }
        }

        private void dependencyClearButton_Click(object sender, EventArgs e)
        {
            ClearRecords();
        }

        private void ClearRecords()
        {
            dependencyCourseIdComboBox.ResetText();
            dependencyDependentCourseIdComboBox.ResetText();
            
            dependencyInHowManyDaysComboBox.ResetText();

            dependencyCourseIdComboBox.Enabled = true;
            dependencyDependentCourseIdComboBox.Enabled = true;
            dependencyAddButton.Text = "Add";
        }

        private void dependencyDeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (Validation())
                {
                    SQLiteConnection con = Database.GetConnection();

                    var sqlQuery = "";
                    if (ifDependencyExists(con, dependencyCourseIdComboBox.Text, dependencyDependentCourseIdComboBox.Text))
                    {

                        sqlQuery = @"DELETE FROM [Dependency] WHERE [CourseID] = '" + dependencyCourseIdComboBox.Text + "' AND [DependentCourseID] = '" + dependencyDependentCourseIdComboBox.Text + "'";
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

            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select * From [Dependency]", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            dependencyDataGridView.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                int n = dependencyDataGridView.Rows.Add();
                dependencyDataGridView.Rows[n].Cells["dgDependencyCourseId"].Value = int.Parse(row["CourseID"].ToString());
                dependencyDataGridView.Rows[n].Cells["dgDependencyDependentCourseId"].Value = row["DependentCourseID"].ToString();
                dependencyDataGridView.Rows[n].Cells["dgDependencyInHowManyDays"].Value = int.Parse(row["InHowManyDays"].ToString());
            }

            if (dependencyDataGridView.Rows.Count > 0)
            {
                totalDependencyValueLabel.Text = dependencyDataGridView.Rows.Count.ToString();

            }
            else
            {
                totalDependencyValueLabel.Text = "0";

            }

        }

        private void setComboBoxes()
        {
            SQLiteConnection con = Database.GetConnection();

            try
            {
                // Course from Scheduler data in ComboBox
                string courseIdQuery = "SELECT SchedulerID FROM Scheduler";
                using (SQLiteCommand cmd = new SQLiteCommand(courseIdQuery, con))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                dependencyCourseIdComboBox.Items.Add(reader["SchedulerID"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            try
            {
                // CourseID from Course data in ComboBox
                string dependentCourseIdQuery = "SELECT SchedulerID FROM Scheduler";
                using (SQLiteCommand cmd = new SQLiteCommand(dependentCourseIdQuery, con))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                dependencyDependentCourseIdComboBox.Items.Add(reader["SchedulerID"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            
            int[] inHowManyDays = new int[] { 1, 2, 3, 4, 5 };

            dependencyInHowManyDaysComboBox.DataSource = inHowManyDays;
        }

        private void dependencyDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            dependencyAddButton.Text = "Update";
            dependencyCourseIdComboBox.Enabled = false;
            dependencyDependentCourseIdComboBox.Enabled = false;

            dependencyCourseIdComboBox.Text = dependencyDataGridView.SelectedRows[0].Cells["dgDependencyCourseId"].Value.ToString();
            dependencyDependentCourseIdComboBox.Text = dependencyDataGridView.SelectedRows[0].Cells["dgDependencyDependentCourseId"].Value.ToString();
            dependencyInHowManyDaysComboBox.Text = dependencyDataGridView.SelectedRows[0].Cells["dgDependencyInHowManyDays"].Value.ToString();

        }
    }
}
