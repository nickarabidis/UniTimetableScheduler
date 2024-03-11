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
    public partial class PreferenceForm : Form
    {
        public PreferenceForm()
        {
            InitializeComponent();
        }

        private void PreferenceForm_Load(object sender, EventArgs e)
        {
            setComboBoxes();
            ClearRecords();

            LoadDataDay();
            LoadDataStartTime();
            LoadDataRoom();
        }


        private bool ValidationPreferredDay()
        {
            bool result = false;

            if (string.IsNullOrEmpty(daySchedulerIdComboBox.Text))
            {
                preferenceErrorProvider.Clear();
                preferenceErrorProvider.SetError(daySchedulerIdComboBox, "Scheduler Id Required");
            }
            else if (string.IsNullOrEmpty(dayIdComboBox.Text))
            {
                preferenceErrorProvider.Clear();
                preferenceErrorProvider.SetError(dayIdComboBox, "Day Id Required");
            }
            else
            {
                preferenceErrorProvider.Clear();
                result = true;
            }
            return result;
        }
        private bool ValidationPreferredStartTime()
        {
            bool result = false;

            if (string.IsNullOrEmpty(startTimeSchedulerIdComboBox.Text))
            {
                preferenceErrorProvider.Clear();
                preferenceErrorProvider.SetError(startTimeSchedulerIdComboBox, "Scheduler Id Required");
            }
            else if (string.IsNullOrEmpty(startTimeIdComboBox.Text))
            {
                preferenceErrorProvider.Clear();
                preferenceErrorProvider.SetError(startTimeIdComboBox, "StartTime Id Required");
            }
            else
            {
                preferenceErrorProvider.Clear();
                result = true;
            }
            return result;
        }
        private bool ValidationPreferredRoom()
        {
            bool result = false;

            if (string.IsNullOrEmpty(roomSchedulerIdComboBox.Text))
            {
                preferenceErrorProvider.Clear();
                preferenceErrorProvider.SetError(roomSchedulerIdComboBox, "Scheduler Id Required");
            }
            else if (string.IsNullOrEmpty(roomIdComboBox.Text))
            {
                preferenceErrorProvider.Clear();
                preferenceErrorProvider.SetError(roomIdComboBox, "Room Id Required");
            }
            else
            {
                preferenceErrorProvider.Clear();
                result = true;
            }
            return result;
        }

        private void ClearRecords()
        {
            daySchedulerIdComboBox.ResetText();
            dayIdComboBox.ResetText();
            startTimeSchedulerIdComboBox.ResetText();
            startTimeIdComboBox.ResetText();
            roomSchedulerIdComboBox.ResetText();
            roomIdComboBox.ResetText();

            daySchedulerIdComboBox.Enabled = true;
            startTimeSchedulerIdComboBox.Enabled = true;
            roomSchedulerIdComboBox.Enabled = true;


            dayAddButton.Text = "Add";
            startTimeAddButton.Text = "Add";
            roomAddButton.Text = "Add";

        }


        private bool ifDayExists(SQLiteConnection con, string schedulerId, string dayId)
        {
            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select 1 From [DayList] WHERE [SchedulerID] = '" + schedulerId + "' AND [DayID] = '" + dayId + "' ", con);
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
        private bool ifStartTimeExists(SQLiteConnection con, string schedulerId, string startTimeId)
        {
            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select 1 From [StartTimeList] WHERE [SchedulerID] = '" + schedulerId + "' AND [StartTimeID] = '" + startTimeId + "' ", con);
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
        private bool ifRoomExists(SQLiteConnection con, string schedulerId, string roomId)
        {
            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select 1 From [RoomList] WHERE [SchedulerID] = '" + schedulerId + "' AND [RoomID] = '" + roomId + "' ", con);
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

        private void dayAddButton_Click(object sender, EventArgs e)
        {
            if (ValidationPreferredDay())
            {
                SQLiteConnection con = Database.GetConnection();

                var sqlQuery = "";
                if (ifDayExists(con, daySchedulerIdComboBox.Text, dayIdComboBox.Text))
                {
                    sqlQuery = @"UPDATE [DayList] SET [SchedulerID] = '" + daySchedulerIdComboBox.Text + "', [DayID] = '" + dayIdComboBox.Text + "' WHERE [SchedulerID] = '" + daySchedulerIdComboBox.Text + "' AND [DayID] = '" + dayIdComboBox.Text + "' ";
                }
                else
                {
                    sqlQuery = @"INSERT INTO [DayList] ([SchedulerID],[DayID]) VALUES 
                            ('" + daySchedulerIdComboBox.Text + "','" + dayIdComboBox.Text + "')";
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
            daySchedulerIdComboBox.ResetText();
            dayIdComboBox.ResetText();

            daySchedulerIdComboBox.Enabled = true;

            dayAddButton.Text = "Add";
        }

        private void dayDeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (ValidationPreferredDay())
                {
                    SQLiteConnection con = Database.GetConnection();

                    var sqlQuery = "";
                    if (ifDayExists(con, daySchedulerIdComboBox.Text, dayIdComboBox.Text))
                    {

                        sqlQuery = @"DELETE FROM [DayList] WHERE [SchedulerID] = '" + daySchedulerIdComboBox.Text + "' AND [DayID] = '" + dayIdComboBox.Text + "'";
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

            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select * From [DayList]", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            preferredDayDataGridView.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                int n = preferredDayDataGridView.Rows.Add();
                preferredDayDataGridView.Rows[n].Cells["dgDaySchedulerID"].Value = int.Parse(row["SchedulerID"].ToString());
                preferredDayDataGridView.Rows[n].Cells["dgDayID"].Value = int.Parse(row["DayID"].ToString());
            }

            if (preferredDayDataGridView.Rows.Count > 0)
            {
                totalPreferredDayValueLabel.Text = preferredDayDataGridView.Rows.Count.ToString();

            }
            else
            {
                totalPreferredDayValueLabel.Text = "0";

            }
        }

        private void preferredDayDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            dayAddButton.Text = "Update";

            daySchedulerIdComboBox.Enabled = false;

            daySchedulerIdComboBox.Text = preferredDayDataGridView.SelectedRows[0].Cells["dgDaySchedulerID"].Value.ToString();
            dayIdComboBox.Text = preferredDayDataGridView.SelectedRows[0].Cells["dgDayID"].Value.ToString();
        }


        private void startTimeAddButton_Click(object sender, EventArgs e)
        {
            if (ValidationPreferredStartTime())
            {
                SQLiteConnection con = Database.GetConnection();

                var sqlQuery = "";
                if (ifStartTimeExists(con, startTimeSchedulerIdComboBox.Text, startTimeIdComboBox.Text))
                {
                    sqlQuery = @"UPDATE [StartTimeList] SET [SchedulerID] = '" + startTimeSchedulerIdComboBox.Text + "', [StartTimeID] = '" + startTimeIdComboBox.Text + "' WHERE [SchedulerID] = '" + startTimeSchedulerIdComboBox.Text + "' AND [StartTimeID] = '" + startTimeIdComboBox.Text + "' ";
                }
                else
                {
                    sqlQuery = @"INSERT INTO [StartTimeList] ([SchedulerID],[StartTimeID]) VALUES 
                            ('" + startTimeSchedulerIdComboBox.Text + "','" + startTimeIdComboBox.Text + "')";
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
            startTimeSchedulerIdComboBox.ResetText();
            startTimeIdComboBox.ResetText();

            startTimeSchedulerIdComboBox.Enabled = true;

            startTimeAddButton.Text = "Add";
        }


        private void startTimeDeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (ValidationPreferredStartTime())
                {
                    SQLiteConnection con = Database.GetConnection();

                    var sqlQuery = "";
                    if (ifStartTimeExists(con, startTimeSchedulerIdComboBox.Text, startTimeIdComboBox.Text))
                    {

                        sqlQuery = @"DELETE FROM [StartTimeList] WHERE [SchedulerID] = '" + startTimeSchedulerIdComboBox.Text + "' AND [StartTimeID] = '" + startTimeIdComboBox.Text + "'";
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

            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select * From [StartTimeList]", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            preferredStartTimeDataGridView.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                int n = preferredStartTimeDataGridView.Rows.Add();
                preferredStartTimeDataGridView.Rows[n].Cells["dgStartTimeSchedulerID"].Value = int.Parse(row["SchedulerID"].ToString());
                preferredStartTimeDataGridView.Rows[n].Cells["dgStartTimeID"].Value = int.Parse(row["StartTimeID"].ToString());
            }

            if (preferredStartTimeDataGridView.Rows.Count > 0)
            {
                totalPreferredStartTimeValueLabel.Text = preferredStartTimeDataGridView.Rows.Count.ToString();

            }
            else
            {
                totalPreferredStartTimeValueLabel.Text = "0";

            }
        }

        private void preferredStartTimeDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            startTimeAddButton.Text = "Update";

            startTimeSchedulerIdComboBox.Enabled = false;

            startTimeSchedulerIdComboBox.Text = preferredStartTimeDataGridView.SelectedRows[0].Cells["dgStartTimeSchedulerID"].Value.ToString();
            startTimeIdComboBox.Text = preferredStartTimeDataGridView.SelectedRows[0].Cells["dgStartTimeID"].Value.ToString();
        }

        private void roomAddButton_Click(object sender, EventArgs e)
        {
            if (ValidationPreferredRoom())
            {
                SQLiteConnection con = Database.GetConnection();

                var sqlQuery = "";
                if (ifRoomExists(con, roomSchedulerIdComboBox.Text, roomIdComboBox.Text))
                {
                    sqlQuery = @"UPDATE [RoomList] SET [SchedulerID] = '" + roomSchedulerIdComboBox.Text + "', [RoomID] = '" + roomIdComboBox.Text + "' WHERE [SchedulerID] = '" + roomSchedulerIdComboBox.Text + "' AND [RoomID] = '" + roomIdComboBox.Text + "' ";
                }
                else
                {
                    sqlQuery = @"INSERT INTO [RoomList] ([SchedulerID],[RoomID]) VALUES 
                            ('" + roomSchedulerIdComboBox.Text + "','" + roomIdComboBox.Text + "')";
                }

                SQLiteCommand cmd = new SQLiteCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();


                MessageBox.Show("Record Saved Successfully");
                LoadDataRoom();
                ClearRecordsRoom();
            }
        }

        private void roomClearButton_Click(object sender, EventArgs e)
        {
            ClearRecordsRoom();
        }

        private void ClearRecordsRoom()
        {
            roomSchedulerIdComboBox.ResetText();
            roomIdComboBox.ResetText();

            roomSchedulerIdComboBox.Enabled = true;

            roomAddButton.Text = "Add";
        }

        private void roomDeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (ValidationPreferredRoom())
                {
                    SQLiteConnection con = Database.GetConnection();

                    var sqlQuery = "";
                    if (ifRoomExists(con, roomSchedulerIdComboBox.Text, roomIdComboBox.Text))
                    {

                        sqlQuery = @"DELETE FROM [RoomList] WHERE [SchedulerID] = '" + roomSchedulerIdComboBox.Text + "' AND [RoomID] = '" + roomIdComboBox.Text + "'";
                        SQLiteCommand cmd = new SQLiteCommand(sqlQuery, con);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Record Deleted Successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Record Doesn't Exist!");
                    }
                    LoadDataRoom();
                    ClearRecordsRoom();
                }
            }
        }

        public void LoadDataRoom()
        {
            SQLiteConnection con = Database.GetConnection();

            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select * From [RoomList]", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            preferredRoomDataGridView.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                int n = preferredRoomDataGridView.Rows.Add();
                preferredRoomDataGridView.Rows[n].Cells["dgRoomSchedulerID"].Value = int.Parse(row["SchedulerID"].ToString());
                preferredRoomDataGridView.Rows[n].Cells["dgRoomID"].Value = int.Parse(row["RoomID"].ToString());
            }

            if (preferredRoomDataGridView.Rows.Count > 0)
            {
                totalPreferredRoomValueLabel.Text = preferredRoomDataGridView.Rows.Count.ToString();

            }
            else
            {
                totalPreferredRoomValueLabel.Text = "0";

            }
        }

        private void preferredRoomDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            roomAddButton.Text = "Update";

            roomSchedulerIdComboBox.Enabled = false;

            roomSchedulerIdComboBox.Text = preferredRoomDataGridView.SelectedRows[0].Cells["dgRoomSchedulerID"].Value.ToString();
            roomIdComboBox.Text = preferredRoomDataGridView.SelectedRows[0].Cells["dgRoomID"].Value.ToString();
        }

        private void setComboBoxes()
        {
            SQLiteConnection con = Database.GetConnection();

            try
            {
                // SchedulerID from Scheduler data in ComboBox
                string schedulerIdQuery = "SELECT SchedulerID FROM Scheduler";
                using (SQLiteCommand cmd = new SQLiteCommand(schedulerIdQuery, con))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                daySchedulerIdComboBox.Items.Add(reader["SchedulerID"].ToString());
                                startTimeSchedulerIdComboBox.Items.Add(reader["SchedulerID"].ToString());
                                roomSchedulerIdComboBox.Items.Add(reader["SchedulerID"].ToString());
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
                // DayID from Day data in ComboBox
                string dayIdQuery = "SELECT DayID FROM Day";
                using (SQLiteCommand cmd = new SQLiteCommand(dayIdQuery, con))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                dayIdComboBox.Items.Add(reader["DayID"].ToString());
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
                // StartTimeID from StartTime data in ComboBox
                string startTimeIdQuery = "SELECT StartTimeID FROM StartTime";
                using (SQLiteCommand cmd = new SQLiteCommand(startTimeIdQuery, con))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                startTimeIdComboBox.Items.Add(reader["StartTimeID"].ToString());
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
                // RoomID from Room data in ComboBox
                string roomIdQuery = "SELECT RoomID FROM Room";
                using (SQLiteCommand cmd = new SQLiteCommand(roomIdQuery, con))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                roomIdComboBox.Items.Add(reader["RoomID"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
