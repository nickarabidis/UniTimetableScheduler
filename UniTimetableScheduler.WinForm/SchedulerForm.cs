using Scheduler.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scheduler.Algorithm;
using System.Net.WebSockets;

namespace Scheduler.WinForm
{
    public partial class SchedulerForm : Form
    {
        //[DllImport("kernel32.dll", SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //static extern bool AlocConsole();
        public SchedulerForm()
        {
            InitializeComponent();
        }

        private void SchedulerForm_Load(object sender, EventArgs e)
        {
            generatedSchedulerButton.Enabled = false;
            setComboBoxes();
            ClearRecords();

            LoadData();
        }

        private bool Validation()
        {
            bool result = false;

            //if (string.IsNullOrEmpty(seasonComboBox.Text))
            //{
            //    schedulerErrorProvider.Clear();
            //    schedulerErrorProvider.SetError(seasonComboBox, "Season Required");
            //}
            if (string.IsNullOrEmpty(schedulerIdTextBox.Text))
            {
                schedulerErrorProvider.Clear();
                schedulerErrorProvider.SetError(schedulerIdTextBox, "Scheduler Id Required");
            }
            else if (string.IsNullOrEmpty(schedulerCourseComboBox.Text))
            {
                schedulerErrorProvider.Clear();
                schedulerErrorProvider.SetError(schedulerCourseComboBox, "Course Required");
            }
            else if (string.IsNullOrEmpty(schedulerProfessorComboBox.Text))
            {
                schedulerErrorProvider.Clear();
                schedulerErrorProvider.SetError(schedulerProfessorComboBox, "Professor Required");
            }
            else if (string.IsNullOrEmpty(schedulerDurationTextBox.Text))
            {
                schedulerErrorProvider.Clear();
                schedulerErrorProvider.SetError(schedulerDurationTextBox, "Duration Required");
            }
            else if (string.IsNullOrEmpty(schedulerSemesterComboBox.Text))
            {
                schedulerErrorProvider.Clear();
                schedulerErrorProvider.SetError(schedulerSemesterComboBox, "Semester Required");
            }


            //else if (string.IsNullOrEmpty(timeStartComboBox.Text))
            //{
            //    schedulerErrorProvider.Clear();
            //    schedulerErrorProvider.SetError(timeStartComboBox, "Time Start Required");
            //}
            else
            {
                schedulerErrorProvider.Clear();
                result = true;
            }
            return result;
        }

        private bool ifClassExists(SQLiteConnection con, string id)
        {
            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select 1 From [Scheduler] WHERE [SchedulerID] = '" + id + "' ", con);
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

        private void addButton_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                SQLiteConnection con = Database.GetConnection();

                var sqlQuery = "";
                if (ifClassExists(con, schedulerIdTextBox.Text))
                {

                    sqlQuery = @"UPDATE [Scheduler] SET [Course] = '" + schedulerCourseComboBox.Text + "',[Professor] = '" + schedulerProfessorComboBox.Text + "', [Duration] = '" + schedulerDurationTextBox.Text + "', [Semester] = '" + schedulerSemesterComboBox.Text + "' WHERE [SchedulerID] = '" + schedulerIdTextBox.Text + "'";
                    //OverlappingHours();

                }
                else
                {

                    sqlQuery = @"INSERT INTO [Scheduler] ([SchedulerID],[Course],[Professor],[Duration],[Semester]) VALUES 
                            ('" + schedulerIdTextBox.Text + "','" + schedulerCourseComboBox.Text + "','" + schedulerProfessorComboBox.Text + "','" + schedulerDurationTextBox.Text + "','" + schedulerSemesterComboBox.Text + "')";
                    //OverlappingHours();
                }
                SQLiteCommand cmd = new SQLiteCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();


                MessageBox.Show("Record Saved Successfully");
                LoadData();
                ClearRecords();
            }
        }
        //private string GetSelectedDays()
        //{
        //    // Get the selected days from the CheckedListBox and convert them to a comma-separated string
        //    StringBuilder selectedDays = new StringBuilder();
        //    foreach (var item in chedulerDaysCheckedListBox.CheckedItems)
        //    {
        //        selectedDays.Append(item.ToString());
        //        selectedDays.Append(", ");
        //    }
        //    if (selectedDays.Length > 0)
        //    {
        //        selectedDays.Remove(selectedDays.Length - 2, 2); // Remove the trailing comma and space
        //    }
        //    return selectedDays.ToString();
        //}

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearRecords();
        }

        private void ClearRecords()
        {
            //string[] semesters = new string[] { "1", "2", "3", "4", "5", "6", "7", "8" };
            //schedulerSemesterComboBox.DataSource = semesters;

            //seasonComboBox.ResetText();

            schedulerIdTextBox.Clear();
            schedulerCourseComboBox.ResetText();
            schedulerProfessorComboBox.ResetText();
            schedulerDurationTextBox.Clear();
            schedulerSemesterComboBox.ResetText();


            schedulerIdTextBox.Enabled = true;

            addButton.Text = "Add";

        }
        //private void UncheckAllItems()
        //{
        //    while (chedulerDaysCheckedListBox.CheckedIndices.Count > 0)
        //        chedulerDaysCheckedListBox.SetItemChecked(chedulerDaysCheckedListBox.CheckedIndices[0], false);
        //}
        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (Validation())
                {
                    SQLiteConnection con = Database.GetConnection();

                    var sqlQuery = "";
                    if (ifClassExists(con, schedulerIdTextBox.Text))
                    {

                        sqlQuery = @"DELETE FROM [Scheduler] WHERE [SchedulerID] = '" + schedulerIdTextBox.Text + "'";
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

        //TO-DO: datagrid
        public void LoadData()
        {
            SQLiteConnection con = Database.GetConnection();

            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select * From [Scheduler]", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            schedulerDataGridView.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                int n = schedulerDataGridView.Rows.Add();
                schedulerDataGridView.Rows[n].Cells["dgSchedulerId"].Value = int.Parse(row["SchedulerID"].ToString());
                schedulerDataGridView.Rows[n].Cells["dgCourse"].Value = int.Parse(row["Course"].ToString());
                schedulerDataGridView.Rows[n].Cells["dgProfessor"].Value = int.Parse(row["Professor"].ToString());
                schedulerDataGridView.Rows[n].Cells["dgDuration"].Value = int.Parse(row["Duration"].ToString());
                schedulerDataGridView.Rows[n].Cells["dgSemester"].Value = int.Parse(row["Semester"].ToString());
            }

            // Use LINQ to get unique courses
            var uniqueCourses = dt.AsEnumerable()
                .Select(row =>
                {
                    if (int.TryParse(row["Course"].ToString(), out int courseValue))
                    {
                        return courseValue;
                    }
                    return -1; // Or any default value you prefer for failure
                })
                .Distinct()
                .ToList();

            // Use LINQ to get unique professors
            var uniqueProfessors = dt.AsEnumerable()
                .Select(row =>
                {
                    if (int.TryParse(row["Professor"].ToString(), out int professorValue))
                    {
                        return professorValue;
                    }
                    return -1; // Or any default value you prefer for failure
                })
                .Distinct()
                .ToList();

            if (schedulerDataGridView.Rows.Count > 0)
            {
                totalCourseValueLabel.Text = uniqueCourses.Count.ToString();
                totalProfessorValueLabel.Text = uniqueProfessors.Count.ToString();
                totalClassValueLabel.Text = schedulerDataGridView.Rows.Count.ToString();
            }
            else
            {
                totalCourseValueLabel.Text = "0";
                totalProfessorValueLabel.Text = "0";
                totalClassValueLabel.Text = "0";
            }

        }


        private void setComboBoxes()
        {
            SQLiteConnection con = Database.GetConnection();

            try
            {
                // Course data in ComboBox
                string courseQuery = "SELECT CourseID FROM Course";
                using (SQLiteCommand cmd = new SQLiteCommand(courseQuery, con))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                schedulerCourseComboBox.Items.Add(reader["CourseID"].ToString());
                            }
                        }
                    }
                }
                // Professor data in ComboBox
                string professorQuery = "SELECT ProfessorID FROM Professor";
                using (SQLiteCommand cmd = new SQLiteCommand(professorQuery, con))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                schedulerProfessorComboBox.Items.Add(reader["ProfessorID"].ToString());
                            }
                        }
                    }
                }
                // Semester data in ComboBox
                string semesterQuery = "SELECT SemesterID FROM Semester";
                using (SQLiteCommand cmd = new SQLiteCommand(semesterQuery, con))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                schedulerSemesterComboBox.Items.Add(reader["SemesterID"].ToString());
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


            //string[] subjects = new string[] {"∆ιακριτά Μαθηματικά", "Εισαγωγή στον προγραμματισμό με C, C++ Θ", "Εισαγωγή στον προγραμματισμό με C, C++ ΕΡΓ",
            //"Θεωρίες Μάθησης και Μεικτή Μάθηση", "Μαθηματικά Ι", "Ψηφιακή Σχεδίαση", "Αγγλική Τεχνική Ορολογία", "Αντικειμενοστραφής Προγραμματισμός",
            //"Επιστημονικός Υπολογισμός Θ", "Επιστημονικός Υπολογισμός ΕΡΓ", "Λειτουργικά Συστήματα", "Μεταγλωττιστές", "Προηγμένες Εφαρμογές Ψηφιακής Σχεδίασης Θ",
            //"Προηγμένες Εφαρμογές Ψηφιακής Σχεδίασης ΕΡΓ", "Εφαρμοσμένα Μαθηματικά", "Μεθοδολογία Εκπαιδευτικής Έρευνας", "∆ίκτυα Υπολογιστών", "Εισαγωγή στην Υπολογιστική Νοημοσύνη Θ",
            //"Εισαγωγή στην Υπολογιστική Νοημοσύνη ΕΡΓ", "∆ιδακτική και εφαρμογές στην Πληροφορική", "Τεχνολογία Λογισμικού I", "Αναγνώριση Προτύπων", "Νευρωνικά ∆ίκτυα",
            //"Ασύρματα ∆ίκτυα και Κινητές Επικοινωνίες", "Ασφάλεια Πληροφοριών και Ιδιωτικότητα", "Αυτόνομα Κινούμενα Ρομπότ και Εφαρμογές", "Ειδικά Θέματα Βάσεων ∆εδομένων", "Εισαγωγή στην Τεχνητή Όραση",
            //"Νοήμονα Ρομπότ", "Νοήμονα Ρομπότ ΕΡΓ", "Προγραμματισμός του Παγκόσμιου Ιστού Θ", "Προγραμματισμός του Παγκόσμιου Ιστού ΕΡΓ", "Παράλληλος και Κατανεμημένος Υπολογισμός", "Προηγμένα Θέματα Λειτουργικών Συστημάτων"};
            //string[] teachers = new string[] { "Καθηγητής 1", "Καθηγητής 2", "Καθηγητής 3", "Καθηγητής 4", "Καθηγητής 5", "Καθηγητής 6", "Καθηγητής 7", "Καθηγητής 8", "Καθηγητής 9", "Καθηγητής 10", "Καθηγητής 11", "Καθηγητής 12", "Καθηγητής 13",
            //"Έκτακτος 1", "Έκτακτος 2", "Έκτακτος 3", "Έκτακτος 4", "Έκτακτος 5", "Έκτακτος 6", "Έκτακτος 7", "Έκτακτος 8", "Έκτακτος 9" };
            //string[] subjectCategories = new string[] { "Δ", "ΦΡ", "ΕΡΓ" };
            //string[] teacherCategories = new string[] { "ΜΟΝΙΜΟΣ", "ΕΚΤΑΚΤΟΣ" };
            //string[] seasons = new string[] { "Winter", "Spring" };
            //string[] semesters = new string[] { "1", "2", "3", "4", "5", "6", "7", "8" };
            //string[] days = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            //string[] classes = new string[] { "ΑΜΦ", "Α1", "Α2", "WI", "WII", "EΨΣ", "ΕΗΚ", "ΕΠΥΣ", "ΤΗΛ", "ΡΟΜΠ" };

            //int[] StartTimes = new int[] { 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22 };
            //int[] timesEnd = new int[] { 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22 };

            ////string[] timesEnd = new string[] { "8:00", "9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00" };

            //seasonComboBox.DataSource = seasons;
            //schedulerSemesterComboBox.DataSource = semesters;
            //dayComboBox.DataSource = days;
            //timeStartComboBox.DataSource = timesStart;
            //timeEndComboBox.DataSource = timesEnd;
            //schedulerRoomComboBox.DataSource = classes;
            //schedulerCourseComboBox.DataSource = subjects;
            //schedulerProfessorComboBox.DataSource = teachers;
            //schedulerLabComboBox.DataSource = subjectCategories;
            //teacherCategoryComboBox.DataSource = teacherCategories;
        }

        private void schedulerDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            addButton.Text = "Update";
            schedulerIdTextBox.Enabled = false;

            schedulerIdTextBox.Text = schedulerDataGridView.SelectedRows[0].Cells["dgSchedulerId"].Value.ToString();
            schedulerCourseComboBox.Text = schedulerDataGridView.SelectedRows[0].Cells["dgCourse"].Value.ToString();
            schedulerProfessorComboBox.Text = schedulerDataGridView.SelectedRows[0].Cells["dgProfessor"].Value.ToString();
            schedulerDurationTextBox.Text = schedulerDataGridView.SelectedRows[0].Cells["dgDuration"].Value.ToString();
            schedulerSemesterComboBox.Text = schedulerDataGridView.SelectedRows[0].Cells["dgSemester"].Value.ToString();

            //string selectedDays = schedulerDataGridView.SelectedRows[0].Cells["dgDay"].Value.ToString();
            //string[] dayArray = selectedDays.Split(','); // Split the string into an array of individual day values

            //foreach (string day in dayArray)
            //{
            //    int index = chedulerDaysCheckedListBox.Items.IndexOf(day.Trim()); // Find the index of the day in the CheckedListBox items
            //    if (index >= 0)
            //    {
            //        chedulerDaysCheckedListBox.SetItemChecked(index, true); // Check the item at the found index
            //    }
            //}
        }

        //private void generateButton_Click(object sender, EventArgs e)
        //{
        //    SQLiteConnection con = Database.GetConnection();
        //    Stopwatch stopwatch = Stopwatch.StartNew();

        //    //var FILE_NAME = "GaSchedule.json";
        //    var configuration = new Configuration();
        //    configuration.ParseDatabase(con);

        //    var alg = new GeneticAlgorithm<Schedule>(new Schedule(configuration));
        //    alg.Run();

        //    var result = alg.Result;
        //    setFinalsInDatabase(result);

        //    var htmlResult = HtmlOutput.GetResult(result);

        //    // Save HTML result to a temporary file
        //    //var tempFilePath = Path.GetTempPath() + FILE_NAME.Replace(".json", ".htm");
        //    var tempFilePath = Path.GetTempFileName().Replace(".tmp", ".htm");
        //    using (StreamWriter outputFile = new StreamWriter(tempFilePath))
        //    {
        //        outputFile.WriteLine(htmlResult);
        //    }

        //    // Open the HTML file in the default web browser
        //    using (var proc = new Process())
        //    {
        //        proc.StartInfo.FileName = tempFilePath;
        //        proc.StartInfo.UseShellExecute = true;
        //        proc.StartInfo.Verb = "open";
        //        proc.Start();

        //        // Display a message box with the completion information
        //        MessageBox.Show($"Completed in {stopwatch.Elapsed.TotalSeconds:0.###} secs with peak memory usage of {Process.GetCurrentProcess().PeakWorkingSet64:#,#} bytes", "Generation Completed");
        //    }

        //    generatedSchedulerButton.Enabled = true;

        //    GeneratedScheduleForm generatedTimetable = new GeneratedScheduleForm();
        //    generatedTimetable.Show();

        //    //AlgorithmWithDatabase(con);
        //    //AlgorithmWithDatabaseConsole(con);

        //}

        private void generateButton_Click(object sender, EventArgs e)
        {
            SQLiteConnection con = Database.GetConnection();
            Stopwatch stopwatch = Stopwatch.StartNew();

            // Parse configuration from the database
            var configuration = new Configuration();
            configuration.ParseDatabase(con);

            // Run the genetic algorithm
            var alg = new GeneticAlgorithm<Schedule>(new Schedule(configuration));
            alg.Run();

            // Get the result from the algorithm
            var result = alg.Result;
            string status = alg.status;
            //fitAndGenValueLabel.Text = status;

            // Save the result in the database
            setFinalsInDatabase(result);

            // Generate HTML result directly from the data in the database
            var htmlResult = HtmlOutput.GetResult(result);

            // Save HTML result to a temporary file
            var tempFilePath = Path.GetTempFileName().Replace(".tmp", ".htm");
            using (StreamWriter outputFile = new StreamWriter(tempFilePath))
            {
                outputFile.WriteLine(htmlResult);
            }

            // Open the HTML file in the default web browser
            using (var proc = new Process())
            {
                proc.StartInfo.FileName = tempFilePath;
                proc.StartInfo.UseShellExecute = true;
                proc.StartInfo.Verb = "open";
                proc.Start();

                // Display a message box with the completion information
                MessageBox.Show($"Completed in {stopwatch.Elapsed.TotalSeconds:0.##} secs & {status}", "Generation Completed");
                //MessageBox.Show($"Completed in {stopwatch.Elapsed.TotalSeconds:0.###} secs with peak memory usage of {Process.GetCurrentProcess().PeakWorkingSet64:#,#} bytes", "Generation Completed");
            }

            generatedSchedulerButton.Enabled = true;

            GeneratedScheduleForm generatedTimetable = new GeneratedScheduleForm();
            generatedTimetable.Show();
        }


        public void setFinalsInDatabase(Schedule result)
        {
            SQLiteConnection con = Database.GetConnection();

            var classes = result.Classes;

            // Create an instance of Configuration
            Configuration configuration = new Configuration();

            foreach (var cc in classes.Keys)
            {
                // coordinate of time-space slot
                var reservation = Reservation.GetReservation(classes[cc]);
                int dayId = reservation.Day;
                int timeId = reservation.Time;

                cc.FinalDays = configuration.GetDayById(dayId);
                cc.FinalStartTimes = configuration.GetStartTimeById(timeId);

                var sqlQuery = @"UPDATE [Scheduler] SET [FinalDay] = '" + dayId + "',[FinalStartTime] = '" + timeId + "',[FinalRoom] = '" + cc.FinalRooms.Id + "' WHERE [SchedulerID] = '" + cc.SchedulerId + "'";
                SQLiteCommand cmd = new SQLiteCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();
            }
        }

        private void generatedSchedulerButton_Click(object sender, EventArgs e)
        {
            GeneratedScheduleForm generatedTimetable = new GeneratedScheduleForm();
            generatedTimetable.Show();
        }

    }
}

