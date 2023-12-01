namespace Scheduler.WinForm
{
    partial class GeneratedScheduleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneratedScheduleForm));
            generatedSchedulerDataGridView = new DataGridView();
            dgGeneratedSchedulerId = new DataGridViewTextBoxColumn();
            dgGeneratedCourse = new DataGridViewTextBoxColumn();
            dgGeneratedProfessor = new DataGridViewTextBoxColumn();
            dgGeneratedDuration = new DataGridViewTextBoxColumn();
            dgGeneratedSemester = new DataGridViewTextBoxColumn();
            dgGeneratedFinalDay = new DataGridViewTextBoxColumn();
            dgGeneratedFinalStartTime = new DataGridViewTextBoxColumn();
            dgGeneratedFinalRoom = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)generatedSchedulerDataGridView).BeginInit();
            SuspendLayout();
            // 
            // generatedSchedulerDataGridView
            // 
            generatedSchedulerDataGridView.AllowUserToAddRows = false;
            generatedSchedulerDataGridView.BackgroundColor = SystemColors.GradientActiveCaption;
            generatedSchedulerDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            generatedSchedulerDataGridView.Columns.AddRange(new DataGridViewColumn[] { dgGeneratedSchedulerId, dgGeneratedCourse, dgGeneratedProfessor, dgGeneratedDuration, dgGeneratedSemester, dgGeneratedFinalDay, dgGeneratedFinalStartTime, dgGeneratedFinalRoom });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.DarkBlue;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkBlue;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            generatedSchedulerDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            generatedSchedulerDataGridView.Location = new Point(33, 41);
            generatedSchedulerDataGridView.Margin = new Padding(4);
            generatedSchedulerDataGridView.Name = "generatedSchedulerDataGridView";
            generatedSchedulerDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            generatedSchedulerDataGridView.Size = new Size(898, 440);
            generatedSchedulerDataGridView.TabIndex = 16;
            // 
            // dgGeneratedSchedulerId
            // 
            dgGeneratedSchedulerId.HeaderText = "Scheduler Id";
            dgGeneratedSchedulerId.Name = "dgGeneratedSchedulerId";
            dgGeneratedSchedulerId.Width = 110;
            // 
            // dgGeneratedCourse
            // 
            dgGeneratedCourse.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgGeneratedCourse.HeaderText = "Course";
            dgGeneratedCourse.Name = "dgGeneratedCourse";
            // 
            // dgGeneratedProfessor
            // 
            dgGeneratedProfessor.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgGeneratedProfessor.HeaderText = "Professor";
            dgGeneratedProfessor.Name = "dgGeneratedProfessor";
            // 
            // dgGeneratedDuration
            // 
            dgGeneratedDuration.HeaderText = "Duration";
            dgGeneratedDuration.Name = "dgGeneratedDuration";
            dgGeneratedDuration.Width = 70;
            // 
            // dgGeneratedSemester
            // 
            dgGeneratedSemester.HeaderText = "Semester";
            dgGeneratedSemester.Name = "dgGeneratedSemester";
            dgGeneratedSemester.Width = 70;
            // 
            // dgGeneratedFinalDay
            // 
            dgGeneratedFinalDay.HeaderText = "Final Day";
            dgGeneratedFinalDay.Name = "dgGeneratedFinalDay";
            dgGeneratedFinalDay.Width = 70;
            // 
            // dgGeneratedFinalStartTime
            // 
            dgGeneratedFinalStartTime.HeaderText = "Final StartTime";
            dgGeneratedFinalStartTime.Name = "dgGeneratedFinalStartTime";
            dgGeneratedFinalStartTime.Width = 70;
            // 
            // dgGeneratedFinalRoom
            // 
            dgGeneratedFinalRoom.HeaderText = "Final Room";
            dgGeneratedFinalRoom.Name = "dgGeneratedFinalRoom";
            dgGeneratedFinalRoom.Width = 70;
            // 
            // GeneratedScheduleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(969, 510);
            Controls.Add(generatedSchedulerDataGridView);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.DarkBlue;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "GeneratedScheduleForm";
            Text = "Generated Schedule";
            Load += GeneratedScheduleForm_Load;
            ((System.ComponentModel.ISupportInitialize)generatedSchedulerDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView generatedSchedulerDataGridView;
        private DataGridViewTextBoxColumn dgGeneratedSchedulerId;
        private DataGridViewTextBoxColumn dgGeneratedCourse;
        private DataGridViewTextBoxColumn dgGeneratedProfessor;
        private DataGridViewTextBoxColumn dgGeneratedDuration;
        private DataGridViewTextBoxColumn dgGeneratedSemester;
        private DataGridViewTextBoxColumn dgGeneratedFinalDay;
        private DataGridViewTextBoxColumn dgGeneratedFinalStartTime;
        private DataGridViewTextBoxColumn dgGeneratedFinalRoom;
    }
}