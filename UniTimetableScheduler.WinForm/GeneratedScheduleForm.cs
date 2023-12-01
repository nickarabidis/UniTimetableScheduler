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

            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select * From [Scheduler]", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            generatedSchedulerDataGridView.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                int n = generatedSchedulerDataGridView.Rows.Add();
                generatedSchedulerDataGridView.Rows[n].Cells["dgGeneratedSchedulerId"].Value = int.Parse(row["SchedulerID"].ToString());
                generatedSchedulerDataGridView.Rows[n].Cells["dgGeneratedCourse"].Value = int.Parse(row["Course"].ToString());
                generatedSchedulerDataGridView.Rows[n].Cells["dgGeneratedProfessor"].Value = int.Parse(row["Professor"].ToString());
                generatedSchedulerDataGridView.Rows[n].Cells["dgGeneratedDuration"].Value = int.Parse(row["Duration"].ToString());
                generatedSchedulerDataGridView.Rows[n].Cells["dgGeneratedSemester"].Value = int.Parse(row["Semester"].ToString());
                generatedSchedulerDataGridView.Rows[n].Cells["dgGeneratedFinalDay"].Value = int.Parse(row["FinalDay"].ToString());
                generatedSchedulerDataGridView.Rows[n].Cells["dgGeneratedFinalStartTime"].Value = int.Parse(row["FinalStartTime"].ToString());
                generatedSchedulerDataGridView.Rows[n].Cells["dgGeneratedFinalRoom"].Value = int.Parse(row["FinalRoom"].ToString());
            }

        }
    }
}
