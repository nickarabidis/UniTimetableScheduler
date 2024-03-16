namespace Scheduler.WinForm
{
    partial class SchedulerForm
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchedulerForm));
            schedulerCourseLabel = new Label();
            schedulerProfessorLabel = new Label();
            headerTextLabel = new Label();
            schedulerSemesterLabel = new Label();
            schedulerDataGridView = new DataGridView();
            dgSchedulerId = new DataGridViewTextBoxColumn();
            dgCourse = new DataGridViewTextBoxColumn();
            dgProfessor = new DataGridViewTextBoxColumn();
            dgDuration = new DataGridViewTextBoxColumn();
            dgSemester = new DataGridViewTextBoxColumn();
            deleteButton = new Button();
            clearButton = new Button();
            schedulerErrorProvider = new ErrorProvider(components);
            schedulerSemesterComboBox = new ComboBox();
            totalCoursesLabel = new Label();
            totalCourseValueLabel = new Label();
            schedulerDurationLabel = new Label();
            totalProfessorValueLabel = new Label();
            totalProfessorsLabel = new Label();
            schedulerCourseComboBox = new ComboBox();
            schedulerProfessorComboBox = new ComboBox();
            schedulerDurationTextBox = new TextBox();
            generateButton = new Button();
            splitter1 = new Splitter();
            schedulerIdLabel = new Label();
            schedulerIdTextBox = new TextBox();
            totalClassValueLabel = new Label();
            totalClassesLabel = new Label();
            addButton = new Button();
            generatedSchedulerButton = new Button();
            fitAndGenValueLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)schedulerDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)schedulerErrorProvider).BeginInit();
            SuspendLayout();
            // 
            // schedulerCourseLabel
            // 
            schedulerCourseLabel.AutoSize = true;
            schedulerCourseLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            schedulerCourseLabel.Location = new Point(146, 66);
            schedulerCourseLabel.Margin = new Padding(4, 0, 4, 0);
            schedulerCourseLabel.Name = "schedulerCourseLabel";
            schedulerCourseLabel.Size = new Size(67, 17);
            schedulerCourseLabel.TabIndex = 3;
            schedulerCourseLabel.Text = "Course Id:";
            // 
            // schedulerProfessorLabel
            // 
            schedulerProfessorLabel.AutoSize = true;
            schedulerProfessorLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            schedulerProfessorLabel.Location = new Point(269, 66);
            schedulerProfessorLabel.Margin = new Padding(4, 0, 4, 0);
            schedulerProfessorLabel.Name = "schedulerProfessorLabel";
            schedulerProfessorLabel.Size = new Size(82, 17);
            schedulerProfessorLabel.TabIndex = 4;
            schedulerProfessorLabel.Text = "Professor Id:";
            // 
            // headerTextLabel
            // 
            headerTextLabel.AutoSize = true;
            headerTextLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            headerTextLabel.Location = new Point(184, 22);
            headerTextLabel.Margin = new Padding(4, 0, 4, 0);
            headerTextLabel.Name = "headerTextLabel";
            headerTextLabel.Size = new Size(288, 25);
            headerTextLabel.TabIndex = 8;
            headerTextLabel.Text = "Put the inputs for the scheduler:";
            // 
            // schedulerSemesterLabel
            // 
            schedulerSemesterLabel.AutoSize = true;
            schedulerSemesterLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            schedulerSemesterLabel.Location = new Point(518, 66);
            schedulerSemesterLabel.Margin = new Padding(4, 0, 4, 0);
            schedulerSemesterLabel.Name = "schedulerSemesterLabel";
            schedulerSemesterLabel.Size = new Size(80, 17);
            schedulerSemesterLabel.TabIndex = 9;
            schedulerSemesterLabel.Text = "Semester Id:";
            // 
            // schedulerDataGridView
            // 
            schedulerDataGridView.AllowUserToAddRows = false;
            schedulerDataGridView.BackgroundColor = SystemColors.GradientActiveCaption;
            schedulerDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            schedulerDataGridView.Columns.AddRange(new DataGridViewColumn[] { dgSchedulerId, dgCourse, dgProfessor, dgDuration, dgSemester });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.DarkBlue;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkBlue;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            schedulerDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            schedulerDataGridView.Location = new Point(25, 179);
            schedulerDataGridView.Margin = new Padding(4);
            schedulerDataGridView.Name = "schedulerDataGridView";
            schedulerDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            schedulerDataGridView.Size = new Size(612, 372);
            schedulerDataGridView.TabIndex = 15;
            schedulerDataGridView.MouseDoubleClick += schedulerDataGridView_MouseDoubleClick;
            // 
            // dgSchedulerId
            // 
            dgSchedulerId.HeaderText = "Scheduler Id";
            dgSchedulerId.Name = "dgSchedulerId";
            dgSchedulerId.Width = 110;
            // 
            // dgCourse
            // 
            dgCourse.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgCourse.HeaderText = "Course";
            dgCourse.Name = "dgCourse";
            // 
            // dgProfessor
            // 
            dgProfessor.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgProfessor.HeaderText = "Professor";
            dgProfessor.Name = "dgProfessor";
            // 
            // dgDuration
            // 
            dgDuration.HeaderText = "Duration";
            dgDuration.Name = "dgDuration";
            dgDuration.Width = 70;
            // 
            // dgSemester
            // 
            dgSemester.HeaderText = "Semester";
            dgSemester.Name = "dgSemester";
            dgSemester.Width = 70;
            // 
            // deleteButton
            // 
            deleteButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            deleteButton.Location = new Point(271, 131);
            deleteButton.Margin = new Padding(4);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(104, 34);
            deleteButton.TabIndex = 17;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // clearButton
            // 
            clearButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            clearButton.Location = new Point(383, 131);
            clearButton.Margin = new Padding(4);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(104, 34);
            clearButton.TabIndex = 18;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // schedulerErrorProvider
            // 
            schedulerErrorProvider.ContainerControl = this;
            // 
            // schedulerSemesterComboBox
            // 
            schedulerSemesterComboBox.FormattingEnabled = true;
            schedulerSemesterComboBox.Location = new Point(521, 92);
            schedulerSemesterComboBox.Margin = new Padding(4);
            schedulerSemesterComboBox.Name = "schedulerSemesterComboBox";
            schedulerSemesterComboBox.Size = new Size(116, 25);
            schedulerSemesterComboBox.TabIndex = 22;
            schedulerSemesterComboBox.KeyPress += schedulerSemesterComboBox_KeyPress;
            // 
            // totalCoursesLabel
            // 
            totalCoursesLabel.AutoSize = true;
            totalCoursesLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            totalCoursesLabel.Location = new Point(22, 555);
            totalCoursesLabel.Margin = new Padding(4, 0, 4, 0);
            totalCoursesLabel.Name = "totalCoursesLabel";
            totalCoursesLabel.Size = new Size(80, 15);
            totalCoursesLabel.TabIndex = 23;
            totalCoursesLabel.Text = "Total Courses:";
            // 
            // totalCourseValueLabel
            // 
            totalCourseValueLabel.AutoSize = true;
            totalCourseValueLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            totalCourseValueLabel.Location = new Point(110, 555);
            totalCourseValueLabel.Margin = new Padding(4, 0, 4, 0);
            totalCourseValueLabel.Name = "totalCourseValueLabel";
            totalCourseValueLabel.Size = new Size(13, 15);
            totalCourseValueLabel.TabIndex = 24;
            totalCourseValueLabel.Text = "0";
            // 
            // schedulerDurationLabel
            // 
            schedulerDurationLabel.AutoSize = true;
            schedulerDurationLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            schedulerDurationLabel.Location = new Point(394, 65);
            schedulerDurationLabel.Margin = new Padding(4, 0, 4, 0);
            schedulerDurationLabel.Name = "schedulerDurationLabel";
            schedulerDurationLabel.Size = new Size(61, 17);
            schedulerDurationLabel.TabIndex = 30;
            schedulerDurationLabel.Text = "Duration:";
            // 
            // totalProfessorValueLabel
            // 
            totalProfessorValueLabel.AutoSize = true;
            totalProfessorValueLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            totalProfessorValueLabel.Location = new Point(621, 555);
            totalProfessorValueLabel.Margin = new Padding(4, 0, 4, 0);
            totalProfessorValueLabel.Name = "totalProfessorValueLabel";
            totalProfessorValueLabel.Size = new Size(13, 15);
            totalProfessorValueLabel.TabIndex = 37;
            totalProfessorValueLabel.Text = "0";
            // 
            // totalProfessorsLabel
            // 
            totalProfessorsLabel.AutoSize = true;
            totalProfessorsLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            totalProfessorsLabel.Location = new Point(521, 555);
            totalProfessorsLabel.Margin = new Padding(4, 0, 4, 0);
            totalProfessorsLabel.Name = "totalProfessorsLabel";
            totalProfessorsLabel.Size = new Size(92, 15);
            totalProfessorsLabel.TabIndex = 36;
            totalProfessorsLabel.Text = "Total Professors:";
            // 
            // schedulerCourseComboBox
            // 
            schedulerCourseComboBox.FormattingEnabled = true;
            schedulerCourseComboBox.Location = new Point(149, 92);
            schedulerCourseComboBox.Margin = new Padding(4);
            schedulerCourseComboBox.Name = "schedulerCourseComboBox";
            schedulerCourseComboBox.Size = new Size(116, 25);
            schedulerCourseComboBox.TabIndex = 38;
            schedulerCourseComboBox.KeyPress += schedulerCourseComboBox_KeyPress;
            // 
            // schedulerProfessorComboBox
            // 
            schedulerProfessorComboBox.FormattingEnabled = true;
            schedulerProfessorComboBox.Location = new Point(273, 92);
            schedulerProfessorComboBox.Margin = new Padding(4);
            schedulerProfessorComboBox.Name = "schedulerProfessorComboBox";
            schedulerProfessorComboBox.Size = new Size(116, 25);
            schedulerProfessorComboBox.TabIndex = 39;
            schedulerProfessorComboBox.KeyPress += schedulerProfessorComboBox_KeyPress;
            // 
            // schedulerDurationTextBox
            // 
            schedulerDurationTextBox.Location = new Point(397, 92);
            schedulerDurationTextBox.Margin = new Padding(4);
            schedulerDurationTextBox.Name = "schedulerDurationTextBox";
            schedulerDurationTextBox.Size = new Size(116, 25);
            schedulerDurationTextBox.TabIndex = 41;
            schedulerDurationTextBox.KeyPress += schedulerDurationTextBox_KeyPress;
            // 
            // generateButton
            // 
            generateButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            generateButton.Location = new Point(271, 583);
            generateButton.Margin = new Padding(4);
            generateButton.Name = "generateButton";
            generateButton.Size = new Size(104, 34);
            generateButton.TabIndex = 48;
            generateButton.Text = "Generate";
            generateButton.UseVisualStyleBackColor = true;
            generateButton.Click += generateButton_Click;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(0, 0);
            splitter1.Margin = new Padding(4);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(4, 630);
            splitter1.TabIndex = 56;
            splitter1.TabStop = false;
            // 
            // schedulerIdLabel
            // 
            schedulerIdLabel.AutoSize = true;
            schedulerIdLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            schedulerIdLabel.Location = new Point(22, 66);
            schedulerIdLabel.Margin = new Padding(4, 0, 4, 0);
            schedulerIdLabel.Name = "schedulerIdLabel";
            schedulerIdLabel.Size = new Size(83, 17);
            schedulerIdLabel.TabIndex = 60;
            schedulerIdLabel.Text = "Scheduler Id:";
            // 
            // schedulerIdTextBox
            // 
            schedulerIdTextBox.Location = new Point(25, 92);
            schedulerIdTextBox.Margin = new Padding(4);
            schedulerIdTextBox.Name = "schedulerIdTextBox";
            schedulerIdTextBox.Size = new Size(116, 25);
            schedulerIdTextBox.TabIndex = 62;
            schedulerIdTextBox.KeyPress += schedulerIdTextBox_KeyPress;
            // 
            // totalClassValueLabel
            // 
            totalClassValueLabel.AutoSize = true;
            totalClassValueLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            totalClassValueLabel.Location = new Point(357, 555);
            totalClassValueLabel.Margin = new Padding(4, 0, 4, 0);
            totalClassValueLabel.Name = "totalClassValueLabel";
            totalClassValueLabel.Size = new Size(13, 15);
            totalClassValueLabel.TabIndex = 64;
            totalClassValueLabel.Text = "0";
            // 
            // totalClassesLabel
            // 
            totalClassesLabel.AutoSize = true;
            totalClassesLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            totalClassesLabel.Location = new Point(273, 555);
            totalClassesLabel.Margin = new Padding(4, 0, 4, 0);
            totalClassesLabel.Name = "totalClassesLabel";
            totalClassesLabel.Size = new Size(76, 15);
            totalClassesLabel.TabIndex = 63;
            totalClassesLabel.Text = "Total Classes:";
            // 
            // addButton
            // 
            addButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            addButton.Location = new Point(159, 131);
            addButton.Margin = new Padding(4);
            addButton.Name = "addButton";
            addButton.Size = new Size(104, 34);
            addButton.TabIndex = 67;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // generatedSchedulerButton
            // 
            generatedSchedulerButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            generatedSchedulerButton.Location = new Point(495, 583);
            generatedSchedulerButton.Margin = new Padding(4);
            generatedSchedulerButton.Name = "generatedSchedulerButton";
            generatedSchedulerButton.Size = new Size(142, 34);
            generatedSchedulerButton.TabIndex = 68;
            generatedSchedulerButton.Text = "Generated Schedule";
            generatedSchedulerButton.UseVisualStyleBackColor = true;
            generatedSchedulerButton.Click += generatedSchedulerButton_Click;
            // 
            // fitAndGenValueLabel
            // 
            fitAndGenValueLabel.AutoSize = true;
            fitAndGenValueLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            fitAndGenValueLabel.Location = new Point(25, 583);
            fitAndGenValueLabel.Margin = new Padding(4, 0, 4, 0);
            fitAndGenValueLabel.Name = "fitAndGenValueLabel";
            fitAndGenValueLabel.Size = new Size(0, 15);
            fitAndGenValueLabel.TabIndex = 70;
            // 
            // SchedulerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(682, 630);
            Controls.Add(fitAndGenValueLabel);
            Controls.Add(generatedSchedulerButton);
            Controls.Add(addButton);
            Controls.Add(totalClassValueLabel);
            Controls.Add(totalClassesLabel);
            Controls.Add(schedulerIdTextBox);
            Controls.Add(schedulerIdLabel);
            Controls.Add(splitter1);
            Controls.Add(generateButton);
            Controls.Add(schedulerDurationTextBox);
            Controls.Add(schedulerProfessorComboBox);
            Controls.Add(schedulerCourseComboBox);
            Controls.Add(totalProfessorValueLabel);
            Controls.Add(totalProfessorsLabel);
            Controls.Add(schedulerDurationLabel);
            Controls.Add(totalCourseValueLabel);
            Controls.Add(totalCoursesLabel);
            Controls.Add(schedulerSemesterComboBox);
            Controls.Add(clearButton);
            Controls.Add(deleteButton);
            Controls.Add(schedulerDataGridView);
            Controls.Add(schedulerSemesterLabel);
            Controls.Add(headerTextLabel);
            Controls.Add(schedulerProfessorLabel);
            Controls.Add(schedulerCourseLabel);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.DarkBlue;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "SchedulerForm";
            Text = "Scheduler";
            Load += SchedulerForm_Load;
            ((System.ComponentModel.ISupportInitialize)schedulerDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)schedulerErrorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label schedulerCourseLabel;
        private System.Windows.Forms.Label schedulerProfessorLabel;
        private System.Windows.Forms.Label headerTextLabel;
        private System.Windows.Forms.Label schedulerSemesterLabel;
        private System.Windows.Forms.DataGridView schedulerDataGridView;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.ErrorProvider schedulerErrorProvider;
        private System.Windows.Forms.ComboBox schedulerSemesterComboBox;
        private System.Windows.Forms.Label totalCourseValueLabel;
        private System.Windows.Forms.Label totalCoursesLabel;
        private System.Windows.Forms.Label schedulerDurationLabel;
        private System.Windows.Forms.Label totalProfessorValueLabel;
        private System.Windows.Forms.Label totalProfessorsLabel;
        private System.Windows.Forms.ComboBox schedulerProfessorComboBox;
        private System.Windows.Forms.ComboBox schedulerCourseComboBox;
        private System.Windows.Forms.TextBox schedulerDurationTextBox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TextBox schedulerIdTextBox;
        private System.Windows.Forms.Label schedulerIdLabel;
        private System.Windows.Forms.Label totalClassValueLabel;
        private System.Windows.Forms.Label totalClassesLabel;
        private DataGridViewTextBoxColumn dgSchedulerId;
        private DataGridViewTextBoxColumn dgCourse;
        private DataGridViewTextBoxColumn dgProfessor;
        private DataGridViewTextBoxColumn dgDuration;
        private DataGridViewTextBoxColumn dgSemester;
        private Button addButton;
        private Button generatedSchedulerButton;
        private Label fitAndGenValueLabel;
    }
}