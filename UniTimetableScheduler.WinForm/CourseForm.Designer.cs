namespace Scheduler.WinForm
{
    partial class CourseForm
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CourseForm));
            courseNameTextBox = new TextBox();
            courseIdTextBox = new TextBox();
            courseNameLabel = new Label();
            courseIdLabel = new Label();
            coursesLabel = new Label();
            courseDataGridView = new DataGridView();
            dgCourseId = new DataGridViewTextBoxColumn();
            dgCourseName = new DataGridViewTextBoxColumn();
            dgCourseLab = new DataGridViewTextBoxColumn();
            totalCourseValueLabel = new Label();
            totalCoursesLabel = new Label();
            courseClearButton = new Button();
            courseDeleteButton = new Button();
            courseAddButton = new Button();
            courseErrorProvider = new ErrorProvider(components);
            courseLabLabel = new Label();
            courseLabComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)courseDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)courseErrorProvider).BeginInit();
            SuspendLayout();
            // 
            // courseNameTextBox
            // 
            courseNameTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            courseNameTextBox.Location = new Point(84, 115);
            courseNameTextBox.Margin = new Padding(3, 4, 3, 4);
            courseNameTextBox.Name = "courseNameTextBox";
            courseNameTextBox.Size = new Size(415, 25);
            courseNameTextBox.TabIndex = 0;
            // 
            // courseIdTextBox
            // 
            courseIdTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            courseIdTextBox.Location = new Point(84, 82);
            courseIdTextBox.Margin = new Padding(3, 4, 3, 4);
            courseIdTextBox.Name = "courseIdTextBox";
            courseIdTextBox.Size = new Size(147, 25);
            courseIdTextBox.TabIndex = 2;
            courseIdTextBox.KeyPress += courseIdTextBox_KeyPress;
            // 
            // courseNameLabel
            // 
            courseNameLabel.AutoSize = true;
            courseNameLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            courseNameLabel.Location = new Point(32, 118);
            courseNameLabel.Name = "courseNameLabel";
            courseNameLabel.Size = new Size(46, 17);
            courseNameLabel.TabIndex = 3;
            courseNameLabel.Text = "Name:";
            // 
            // courseIdLabel
            // 
            courseIdLabel.AutoSize = true;
            courseIdLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            courseIdLabel.Location = new Point(56, 85);
            courseIdLabel.Name = "courseIdLabel";
            courseIdLabel.Size = new Size(22, 17);
            courseIdLabel.TabIndex = 6;
            courseIdLabel.Text = "Id:";
            // 
            // coursesLabel
            // 
            coursesLabel.AutoSize = true;
            coursesLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            coursesLabel.Location = new Point(245, 31);
            coursesLabel.Name = "coursesLabel";
            coursesLabel.Size = new Size(83, 25);
            coursesLabel.TabIndex = 7;
            coursesLabel.Text = "Courses:";
            // 
            // courseDataGridView
            // 
            courseDataGridView.AllowUserToAddRows = false;
            courseDataGridView.BackgroundColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            courseDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            courseDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            courseDataGridView.Columns.AddRange(new DataGridViewColumn[] { dgCourseId, dgCourseName, dgCourseLab });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.DarkBlue;
            dataGridViewCellStyle2.SelectionBackColor = Color.DarkBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            courseDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            courseDataGridView.Location = new Point(84, 188);
            courseDataGridView.Name = "courseDataGridView";
            courseDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            courseDataGridView.Size = new Size(415, 239);
            courseDataGridView.TabIndex = 16;
            courseDataGridView.MouseDoubleClick += courseDataGridView_MouseDoubleClick;
            // 
            // dgCourseId
            // 
            dgCourseId.HeaderText = "Id";
            dgCourseId.Name = "dgCourseId";
            dgCourseId.Width = 60;
            // 
            // dgCourseName
            // 
            dgCourseName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgCourseName.HeaderText = "Name";
            dgCourseName.Name = "dgCourseName";
            // 
            // dgCourseLab
            // 
            dgCourseLab.HeaderText = "Lab";
            dgCourseLab.Name = "dgCourseLab";
            dgCourseLab.Width = 60;
            // 
            // totalCourseValueLabel
            // 
            totalCourseValueLabel.AutoSize = true;
            totalCourseValueLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            totalCourseValueLabel.Location = new Point(160, 430);
            totalCourseValueLabel.Name = "totalCourseValueLabel";
            totalCourseValueLabel.Size = new Size(13, 15);
            totalCourseValueLabel.TabIndex = 26;
            totalCourseValueLabel.Text = "0";
            // 
            // totalCoursesLabel
            // 
            totalCoursesLabel.AutoSize = true;
            totalCoursesLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            totalCoursesLabel.Location = new Point(81, 430);
            totalCoursesLabel.Name = "totalCoursesLabel";
            totalCoursesLabel.Size = new Size(80, 15);
            totalCoursesLabel.TabIndex = 25;
            totalCoursesLabel.Text = "Total Courses:";
            // 
            // courseClearButton
            // 
            courseClearButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            courseClearButton.Location = new Point(344, 147);
            courseClearButton.Name = "courseClearButton";
            courseClearButton.Size = new Size(100, 35);
            courseClearButton.TabIndex = 29;
            courseClearButton.Text = "Clear";
            courseClearButton.UseVisualStyleBackColor = true;
            courseClearButton.Click += courseClearButton_Click;
            // 
            // courseDeleteButton
            // 
            courseDeleteButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            courseDeleteButton.Location = new Point(238, 147);
            courseDeleteButton.Name = "courseDeleteButton";
            courseDeleteButton.Size = new Size(100, 35);
            courseDeleteButton.TabIndex = 28;
            courseDeleteButton.Text = "Delete";
            courseDeleteButton.UseVisualStyleBackColor = true;
            courseDeleteButton.Click += courseDeleteButton_Click;
            // 
            // courseAddButton
            // 
            courseAddButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            courseAddButton.Location = new Point(132, 147);
            courseAddButton.Name = "courseAddButton";
            courseAddButton.Size = new Size(100, 35);
            courseAddButton.TabIndex = 27;
            courseAddButton.Text = "Add";
            courseAddButton.UseVisualStyleBackColor = true;
            courseAddButton.Click += courseAddButton_Click;
            // 
            // courseErrorProvider
            // 
            courseErrorProvider.ContainerControl = this;
            // 
            // courseLabLabel
            // 
            courseLabLabel.AutoSize = true;
            courseLabLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            courseLabLabel.Location = new Point(314, 85);
            courseLabLabel.Name = "courseLabLabel";
            courseLabLabel.Size = new Size(32, 17);
            courseLabLabel.TabIndex = 31;
            courseLabLabel.Text = "Lab:";
            // 
            // courseLabComboBox
            // 
            courseLabComboBox.FormattingEnabled = true;
            courseLabComboBox.Location = new Point(353, 82);
            courseLabComboBox.Margin = new Padding(4);
            courseLabComboBox.Name = "courseLabComboBox";
            courseLabComboBox.Size = new Size(146, 25);
            courseLabComboBox.TabIndex = 34;
            // 
            // CourseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(576, 472);
            Controls.Add(courseLabComboBox);
            Controls.Add(courseLabLabel);
            Controls.Add(courseClearButton);
            Controls.Add(courseDeleteButton);
            Controls.Add(courseAddButton);
            Controls.Add(totalCourseValueLabel);
            Controls.Add(totalCoursesLabel);
            Controls.Add(courseDataGridView);
            Controls.Add(coursesLabel);
            Controls.Add(courseIdLabel);
            Controls.Add(courseNameLabel);
            Controls.Add(courseIdTextBox);
            Controls.Add(courseNameTextBox);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.DarkBlue;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "CourseForm";
            Text = "Course";
            Load += CourseForm_Load;
            ((System.ComponentModel.ISupportInitialize)courseDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)courseErrorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox courseNameTextBox;
        private System.Windows.Forms.TextBox courseIdTextBox;
        private System.Windows.Forms.Label courseNameLabel;
        private System.Windows.Forms.Label courseIdLabel;
        private System.Windows.Forms.Label coursesLabel;
        private System.Windows.Forms.DataGridView courseDataGridView;
        private System.Windows.Forms.Label totalCourseValueLabel;
        private System.Windows.Forms.Label totalCoursesLabel;
        private System.Windows.Forms.Button courseClearButton;
        private System.Windows.Forms.Button courseDeleteButton;
        private System.Windows.Forms.Button courseAddButton;
        private System.Windows.Forms.ErrorProvider courseErrorProvider;
        private Label courseLabLabel;
        private ComboBox courseLabComboBox;
        private DataGridViewTextBoxColumn dgCourseId;
        private DataGridViewTextBoxColumn dgCourseName;
        private DataGridViewTextBoxColumn dgCourseLab;
    }
}