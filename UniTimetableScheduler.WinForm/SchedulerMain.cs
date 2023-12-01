using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler.WinForm
{
    public partial class SchedulerMain : Form
    {

        public SchedulerMain()
        {
            InitializeComponent();
        }

        private void SchedulerMain_Load(object sender, EventArgs e)
        {
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.FromArgb(255, 34, 67, 102);

            /*
            if the db doesnt exists it creates the db connection
            and setup the tables

            if it exists it just creates the connection
            */

            if (!Directory.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/db"))
            {
                Directory.CreateDirectory($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/db");
            }
            if (!(File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/db/database.db")))

            {

                Database.CreateDb();

                Database.CreateTableCourse();
                Database.CreateTableProfessor();
                Database.CreateTableSemester();
                Database.CreateTableDay();
                Database.CreateTableStartTime();
                Database.CreateTableRoom();
                Database.CreateTableScheduler();
                Database.CreateTableDayList();
                Database.CreateTableStartTimeList();
                Database.CreateTableRoomList();
                Database.CreateTableDependency();

                Database.InsertInCourse();
                Database.InsertInProfessor();
                Database.InsertInSemester();
                Database.InsertInDay();
                Database.InsertInStartTime();
                Database.InsertInRoom();
                Database.InsertInScheduler();
                Database.InsertInDayList();
                Database.InsertInStartTimeList();
                Database.InsertInRoomList();
                Database.InsertInDependency();



                //Database.CreateTables();
                //Database.InsertInTable();
            }

            else
            {
                Database.CreateDb();
            }
        }

        private void coursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CourseForm courses = new CourseForm();
            courses.MdiParent = this;
            courses.Show();
        }
        private void professorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfessorForm professors = new ProfessorForm();
            professors.MdiParent = this;
            professors.Show();
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoomForm rooms = new RoomForm();
            rooms.MdiParent = this;
            rooms.Show();
        }

        private void periodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PeriodForm periods = new PeriodForm();
            periods.MdiParent = this;
            periods.Show();
        }

        private void dependenciesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DependencyForm dependencies = new DependencyForm();
            dependencies.MdiParent = this;
            dependencies.Show();
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PreferenceForm preferences = new PreferenceForm();
            preferences.MdiParent = this;
            preferences.Show();
        }

        private void schedulerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SchedulerForm scheduler = new SchedulerForm();
            scheduler.MdiParent = this;
            scheduler.Show();
        }

    }
}
