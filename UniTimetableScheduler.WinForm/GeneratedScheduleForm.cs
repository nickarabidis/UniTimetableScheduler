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
    public partial class GeneratedScheduleForm : Form
    {
        public GeneratedScheduleForm()
        {
            InitializeComponent();
        }

        private void GeneratedScheduleForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            SQLiteConnection con = Database.GetConnection();

            //SQLiteDataAdapter sda = new SQLiteDataAdapter("Select * From [Scheduler]", con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter("SELECT " +
                "Scheduler.SchedulerID AS SchedulerID, " +
                "Course.Name AS Course, " +
                "Professor.Name AS Professor, " +
                "Scheduler.Duration AS Duration, " +
                "Semester.Name AS Semester, " +
                "Day.Name AS Day, " +
                "StartTime.Name AS StartTime, " +
                "Room.Name AS Room " +
                "FROM Scheduler " +
                "JOIN Course ON Scheduler.Course = Course.CourseID " +
                "JOIN Professor ON Scheduler.Professor = Professor.ProfessorID " +
                "JOIN Semester ON Scheduler.Semester = Semester.SemesterID " +
                "JOIN Day ON Scheduler.FinalDay = Day.DayID " +
                "JOIN StartTime ON Scheduler.FinalStartTime = StartTime.StartTimeID " +
                "JOIN Room ON Scheduler.FinalRoom = Room.RoomID", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            generatedSchedulerDataGridView.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                int n = generatedSchedulerDataGridView.Rows.Add();
                generatedSchedulerDataGridView.Rows[n].Cells["dgGeneratedSchedulerId"].Value = int.Parse(row["SchedulerID"].ToString());
                generatedSchedulerDataGridView.Rows[n].Cells["dgGeneratedCourse"].Value = row["Course"].ToString();
                generatedSchedulerDataGridView.Rows[n].Cells["dgGeneratedProfessor"].Value = row["Professor"].ToString();
                generatedSchedulerDataGridView.Rows[n].Cells["dgGeneratedDuration"].Value = int.Parse(row["Duration"].ToString());
                generatedSchedulerDataGridView.Rows[n].Cells["dgGeneratedSemester"].Value = row["Semester"].ToString();
                generatedSchedulerDataGridView.Rows[n].Cells["dgGeneratedFinalDay"].Value = row["Day"].ToString();
                generatedSchedulerDataGridView.Rows[n].Cells["dgGeneratedFinalStartTime"].Value = row["StartTime"].ToString();
                generatedSchedulerDataGridView.Rows[n].Cells["dgGeneratedFinalRoom"].Value = row["Room"].ToString();
            }

        }
    }
}
