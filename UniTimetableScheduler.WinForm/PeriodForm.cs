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
    public partial class PeriodForm : Form
    {
        public PeriodForm()
        {
            InitializeComponent();
        }

        private void PeriodForm_Load(object sender, EventArgs e)
        {
            ClearRecords();

            LoadDataSemester();
            LoadDataDay();
            LoadDataStartTime();
        }

        private bool ValidationSemester()
        {
            bool result = false;

            if (string.IsNullOrEmpty(semesterIdTextBox.Text))
            {
                periodErrorProvider.Clear();
                periodErrorProvider.SetError(semesterIdTextBox, "SemesterID Required");
            }
            else if (string.IsNullOrEmpty(semesterNameTextBox.Text))
            {
                periodErrorProvider.Clear();
                periodErrorProvider.SetError(semesterNameTextBox, "Semester Name Required");
            }
            else
            {
                periodErrorProvider.Clear();
                result = true;
            }
            return result;
        }
        private bool ValidationDay()
        {
            bool result = false;

            if (string.IsNullOrEmpty(dayIdTextBox.Text))
            {
                periodErrorProvider.Clear();
                periodErrorProvider.SetError(dayIdTextBox, "DayID Required");
            }
            else if (string.IsNullOrEmpty(dayNameTextBox.Text))
            {
                periodErrorProvider.Clear();
                periodErrorProvider.SetError(dayNameTextBox, "Day Name Required");
            }
            else
            {
                periodErrorProvider.Clear();
                result = true;
            }
            return result;
        }
        private bool ValidationStartTime()
        {
            bool result = false;

            if (string.IsNullOrEmpty(startTimeIdTextBox.Text))
            {
                periodErrorProvider.Clear();
                periodErrorProvider.SetError(startTimeIdTextBox, "StartTimeID Required");
            }
            else if (string.IsNullOrEmpty(startTimeNameTextBox.Text))
            {
                periodErrorProvider.Clear();
                periodErrorProvider.SetError(startTimeNameTextBox, "StartTime Name Required");
            }
            else
            {
                periodErrorProvider.Clear();
                result = true;
            }
            return result;
        }

        private void ClearRecords()
        {
            semesterIdTextBox.Clear();
            semesterNameTextBox.Clear();
            dayIdTextBox.Clear();
            dayNameTextBox.Clear();
            startTimeIdTextBox.Clear();
            startTimeNameTextBox.Clear();

            semesterIdTextBox.Enabled = true;
            dayIdTextBox.Enabled = true;
            startTimeIdTextBox.Enabled = true;
            semesterAddButton.Text = "Add";
            dayAddButton.Text = "Add";
            startTimeAddButton.Text = "Add";

        }

        private bool ifSemesterExists(SQLiteConnection con, string semesterId)
        {
            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select 1 From [Semester] WHERE [SemesterID] = '" + semesterId + "' ", con);
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
        private bool ifDayExists(SQLiteConnection con, string dayId)
        {
            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select 1 From [Day] WHERE [DayID] = '" + dayId + "' ", con);
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
        private bool ifStartTimeExists(SQLiteConnection con, string startTimeId)
        {
            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select 1 From [StartTime] WHERE [StartTimeID] = '" + startTimeId + "' ", con);
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

        private void semesterAddButton_Click(object sender, EventArgs e)
        {
            if (ValidationSemester())
            {
                SQLiteConnection con = Database.GetConnection();

                var sqlQuery = "";
                if (ifSemesterExists(con, semesterIdTextBox.Text))
                {
                    sqlQuery = @"UPDATE [Semester] SET [SemesterID] = '" + semesterIdTextBox.Text + "', [Name] = '" + semesterNameTextBox.Text + "' WHERE [SemesterID] = '" + semesterIdTextBox.Text + "'";
                }
                else
                {
                    sqlQuery = @"INSERT INTO [Semester] ([SemesterID],[Name]) VALUES 
                            ('" + semesterIdTextBox.Text + "','" + semesterNameTextBox.Text + "')";
                }

                SQLiteCommand cmd = new SQLiteCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();


                MessageBox.Show("Record Saved Successfully");
                LoadDataSemester();
                ClearRecordsSemester();
            }
        }

        private void semesterClearButton_Click(object sender, EventArgs e)
        {
            ClearRecordsSemester();
        }

        private void ClearRecordsSemester()
        {
            semesterIdTextBox.Clear();
            semesterNameTextBox.Clear();

            semesterIdTextBox.Enabled = true;
            semesterAddButton.Text = "Add";
        }

        private void semesterDeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (ValidationSemester())
                {
                    SQLiteConnection con = Database.GetConnection();

                    var sqlQuery = "";
                    if (ifSemesterExists(con, semesterIdTextBox.Text))
                    {

                        sqlQuery = @"DELETE FROM [Semester] WHERE [SemesterID] = '" + semesterIdTextBox.Text + "'";
                        SQLiteCommand cmd = new SQLiteCommand(sqlQuery, con);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Record Deleted Successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Record Doesn't Exist!");
                    }
                    LoadDataSemester();
                    ClearRecordsSemester();
                }
            }
        }

        public void LoadDataSemester()
        {
            SQLiteConnection con = Database.GetConnection();

            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select * From [Semester]", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            semesterDataGridView.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                int n = semesterDataGridView.Rows.Add();
                semesterDataGridView.Rows[n].Cells["dgSemesterId"].Value = int.Parse(row["SemesterID"].ToString());
                semesterDataGridView.Rows[n].Cells["dgSemesterName"].Value = row["Name"].ToString();
            }

            if (semesterDataGridView.Rows.Count > 0)
            {
                totalSemesterValueLabel.Text = semesterDataGridView.Rows.Count.ToString();

            }
            else
            {
                totalSemesterValueLabel.Text = "0";

            }
        }

        private void semesterDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            semesterAddButton.Text = "Update";
            semesterIdTextBox.Enabled = false;

            semesterIdTextBox.Text = semesterDataGridView.SelectedRows[0].Cells["dgSemesterId"].Value.ToString();
            semesterNameTextBox.Text = semesterDataGridView.SelectedRows[0].Cells["dgSemesterName"].Value.ToString();
        }

        private void dayAddButton_Click(object sender, EventArgs e)
        {
            if (ValidationDay())
            {
                SQLiteConnection con = Database.GetConnection();

                var sqlQuery = "";
                if (ifDayExists(con, dayIdTextBox.Text))
                {
                    sqlQuery = @"UPDATE [Day] SET [DayID] = '" + dayIdTextBox.Text + "', [Name] = '" + dayNameTextBox.Text + "' WHERE [DayID] = '" + dayIdTextBox.Text + "'";
                }
                else
                {
                    sqlQuery = @"INSERT INTO [Day] ([DayID],[Name]) VALUES 
                            ('" + dayIdTextBox.Text + "','" + dayNameTextBox.Text + "')";
                }

                SQLiteCommand cmd = new SQLiteCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();


                MessageBox.Show("Record Saved Successfully");
                LoadDataDay();
                ClearRecordsDay();
            }
        }

        private void dayClearButton_Click(object sender, EventArgs e)
        {
            ClearRecordsDay();
        }

        private void ClearRecordsDay()
        {
            dayIdTextBox.Clear();
            dayNameTextBox.Clear();

            dayIdTextBox.Enabled = true;
            dayAddButton.Text = "Add";
        }

        private void dayDeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (ValidationDay())
                {
                    SQLiteConnection con = Database.GetConnection();

                    var sqlQuery = "";
                    if (ifDayExists(con, dayIdTextBox.Text))
                    {

                        sqlQuery = @"DELETE FROM [Day] WHERE [DayID] = '" + dayIdTextBox.Text + "'";
                        SQLiteCommand cmd = new SQLiteCommand(sqlQuery, con);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Record Deleted Successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Record Doesn't Exist!");
                    }
                    LoadDataDay();
                    ClearRecordsDay();
                }
            }
        }

        public void LoadDataDay()
        {
            SQLiteConnection con = Database.GetConnection();

            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select * From [Day]", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            dayDataGridView.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                int n = dayDataGridView.Rows.Add();
                dayDataGridView.Rows[n].Cells["dgDayId"].Value = int.Parse(row["DayID"].ToString());
                dayDataGridView.Rows[n].Cells["dgDayName"].Value = row["Name"].ToString();
            }

            if (dayDataGridView.Rows.Count > 0)
            {
                totalDayValueLabel.Text = dayDataGridView.Rows.Count.ToString();

            }
            else
            {
                totalDayValueLabel.Text = "0";

            }
        }

        private void dayDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            dayAddButton.Text = "Update";
            dayIdTextBox.Enabled = false;

            dayIdTextBox.Text = dayDataGridView.SelectedRows[0].Cells["dgDayId"].Value.ToString();
            dayNameTextBox.Text = dayDataGridView.SelectedRows[0].Cells["dgDayName"].Value.ToString();
        }

        private void startTimeAddButton_Click(object sender, EventArgs e)
        {
            if (ValidationStartTime())
            {
                SQLiteConnection con = Database.GetConnection();

                var sqlQuery = "";
                if (ifStartTimeExists(con, startTimeIdTextBox.Text))
                {
                    sqlQuery = @"UPDATE [StartTime] SET [StartTimeID] = '" + startTimeIdTextBox.Text + "', [Name] = '" + startTimeNameTextBox.Text + "' WHERE [StartTimeID] = '" + startTimeIdTextBox.Text + "'";
                }
                else
                {
                    sqlQuery = @"INSERT INTO [StartTime] ([StartTimeID],[Name]) VALUES 
                            ('" + startTimeIdTextBox.Text + "','" + startTimeNameTextBox.Text + "')";
                }

                SQLiteCommand cmd = new SQLiteCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();


                MessageBox.Show("Record Saved Successfully");
                LoadDataStartTime();
                ClearRecordsStartTime();
            }
        }

        private void startTimeClearButton_Click(object sender, EventArgs e)
        {
            ClearRecordsStartTime();
        }

        private void ClearRecordsStartTime()
        {
            startTimeIdTextBox.Clear();
            startTimeNameTextBox.Clear();

            startTimeIdTextBox.Enabled = true;

            startTimeAddButton.Text = "Add";
        }

        private void startTimeDeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (ValidationStartTime())
                {
                    SQLiteConnection con = Database.GetConnection();

                    var sqlQuery = "";
                    if (ifStartTimeExists(con, startTimeIdTextBox.Text))
                    {

                        sqlQuery = @"DELETE FROM [StartTime] WHERE [StartTimeID] = '" + startTimeIdTextBox.Text + "'";
                        SQLiteCommand cmd = new SQLiteCommand(sqlQuery, con);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Record Deleted Successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Record Doesn't Exist!");
                    }
                    LoadDataStartTime();
                    ClearRecordsStartTime();
                }
            }
        }

        public void LoadDataStartTime()
        {
            SQLiteConnection con = Database.GetConnection();

            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select * From [StartTime]", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            startTimeDataGridView.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                int n = startTimeDataGridView.Rows.Add();
                startTimeDataGridView.Rows[n].Cells["dgStartTimeId"].Value = int.Parse(row["StartTimeID"].ToString());
                startTimeDataGridView.Rows[n].Cells["dgStartTimeName"].Value = row["Name"].ToString();
            }

            if (startTimeDataGridView.Rows.Count > 0)
            {
                totalStartTimeValueLabel.Text = startTimeDataGridView.Rows.Count.ToString();

            }
            else
            {
                totalStartTimeValueLabel.Text = "0";

            }
        }


        private void startTimeDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            startTimeAddButton.Text = "Update";
            startTimeIdTextBox.Enabled = false;

            startTimeIdTextBox.Text = startTimeDataGridView.SelectedRows[0].Cells["dgStartTimeId"].Value.ToString();
            startTimeNameTextBox.Text = startTimeDataGridView.SelectedRows[0].Cells["dgStartTimeName"].Value.ToString();
        }
    }
}
