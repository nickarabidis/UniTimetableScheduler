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
    public partial class RoomForm : Form
    {
        public RoomForm()
        {
            InitializeComponent();
        }

        private void RoomForm_Load(object sender, EventArgs e)
        {
            setComboBoxes();
            ClearRecords();

            LoadData();
        }

        private bool Validation()
        {
            bool result = false;

            if (string.IsNullOrEmpty(roomIdTextBox.Text))
            {
                roomErrorProvider.Clear();
                roomErrorProvider.SetError(roomIdTextBox, "RoomID Required");
            }
            else if (string.IsNullOrEmpty(roomNameTextBox.Text))
            {
                roomErrorProvider.Clear();
                roomErrorProvider.SetError(roomNameTextBox, "Name Required");
            }
            else if (string.IsNullOrEmpty(roomLabComboBox.Text))
            {
                roomErrorProvider.Clear();
                roomErrorProvider.SetError(roomLabComboBox, "Lab Required");
            }
            else
            {
                roomErrorProvider.Clear();
                result = true;
            }
            return result;
        }

        private bool ifRoomExists(SQLiteConnection con, string roomId)
        {
            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select 1 From [Room] WHERE [RoomID] = '" + roomId + "' ", con);
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

        private void roomAddButton_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                SQLiteConnection con = Database.GetConnection();

                var sqlQuery = "";
                if (ifRoomExists(con, roomIdTextBox.Text))
                {
                    sqlQuery = @"UPDATE [Room] SET [RoomID] = '" + roomIdTextBox.Text + "', [Name] = '" + roomNameTextBox.Text + "', [Lab] = '" + roomLabComboBox.Text + "' WHERE [RoomID] = '" + roomIdTextBox.Text + "'";
                }
                else
                {
                    sqlQuery = @"INSERT INTO [Room] ([RoomID],[Name],[Lab]) VALUES 
                            ('" + roomIdTextBox.Text + "','" + roomNameTextBox.Text + "','" + roomLabComboBox.Text + "')";
                }

                SQLiteCommand cmd = new SQLiteCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();


                MessageBox.Show("Record Saved Successfully");
                LoadData();
                ClearRecords();
            }
        }

        private void roomClearButton_Click(object sender, EventArgs e)
        {
            ClearRecords();
        }

        private void ClearRecords()
        {
            roomIdTextBox.Clear();
            roomNameTextBox.Clear();
            roomLabComboBox.ResetText();

            roomIdTextBox.Enabled = true;
            roomAddButton.Text = "Add";

        }

        private void roomDeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (Validation())
                {
                    SQLiteConnection con = Database.GetConnection();

                    var sqlQuery = "";
                    if (ifRoomExists(con, roomIdTextBox.Text))
                    {

                        sqlQuery = @"DELETE FROM [Room] WHERE [RoomID] = '" + roomIdTextBox.Text + "'";
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

            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select * From [Room]", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            roomDataGridView.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                int n = roomDataGridView.Rows.Add();
                roomDataGridView.Rows[n].Cells["dgRoomId"].Value = int.Parse(row["RoomID"].ToString());
                roomDataGridView.Rows[n].Cells["dgRoomName"].Value = row["Name"].ToString();
                roomDataGridView.Rows[n].Cells["dgRoomLab"].Value = bool.Parse(row["Lab"].ToString());
            }

            if (roomDataGridView.Rows.Count > 0)
            {
                totalRoomValueLabel.Text = roomDataGridView.Rows.Count.ToString();

            }
            else
            {
                totalRoomValueLabel.Text = "0";

            }

        }

        private void setComboBoxes()
        {
            bool[] labs = new bool[] { true, false };

            roomLabComboBox.DataSource = labs;

        }


        private void roomDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            roomAddButton.Text = "Update";
            roomIdTextBox.Enabled = false;

            roomIdTextBox.Text = roomDataGridView.SelectedRows[0].Cells["dgRoomId"].Value.ToString();
            roomNameTextBox.Text = roomDataGridView.SelectedRows[0].Cells["dgRoomName"].Value.ToString();
            roomLabComboBox.Text = roomDataGridView.SelectedRows[0].Cells["dgRoomLab"].Value.ToString();
        }

        private void roomIdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}

