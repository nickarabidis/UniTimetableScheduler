namespace Scheduler.WinForm
{
    partial class ProfessorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfessorForm));
            professorDataGridView = new DataGridView();
            dgProfessorId = new DataGridViewTextBoxColumn();
            dgProfessorName = new DataGridViewTextBoxColumn();
            dgProfessorMeeting = new DataGridViewTextBoxColumn();
            professorLabel = new Label();
            professorIdLabel = new Label();
            professorNameLabel = new Label();
            professorIdTextBox = new TextBox();
            professorNameTextBox = new TextBox();
            professorMeetingLabel = new Label();
            professorMeetingComboBox = new ComboBox();
            totalProfessorValueLabel = new Label();
            totalProfessorsLabel = new Label();
            professorClearButton = new Button();
            professorDeleteButton = new Button();
            professorAddButton = new Button();
            professorErrorProvider = new ErrorProvider(components);
            deleteAllButton = new Button();
            printButton = new Button();
            ((System.ComponentModel.ISupportInitialize)professorDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)professorErrorProvider).BeginInit();
            SuspendLayout();
            // 
            // professorDataGridView
            // 
            professorDataGridView.AllowUserToAddRows = false;
            professorDataGridView.BackgroundColor = SystemColors.GradientActiveCaption;
            professorDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            professorDataGridView.Columns.AddRange(new DataGridViewColumn[] { dgProfessorId, dgProfessorName, dgProfessorMeeting });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.DarkBlue;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkBlue;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            professorDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            professorDataGridView.Location = new Point(73, 201);
            professorDataGridView.Name = "professorDataGridView";
            professorDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            professorDataGridView.Size = new Size(464, 239);
            professorDataGridView.TabIndex = 22;
            professorDataGridView.MouseDoubleClick += professorDataGridView_MouseDoubleClick;
            // 
            // dgProfessorId
            // 
            dgProfessorId.HeaderText = "Id";
            dgProfessorId.Name = "dgProfessorId";
            dgProfessorId.Width = 70;
            // 
            // dgProfessorName
            // 
            dgProfessorName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgProfessorName.HeaderText = "Name";
            dgProfessorName.Name = "dgProfessorName";
            // 
            // dgProfessorMeeting
            // 
            dgProfessorMeeting.HeaderText = "Meeting";
            dgProfessorMeeting.Name = "dgProfessorMeeting";
            // 
            // professorLabel
            // 
            professorLabel.AutoSize = true;
            professorLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            professorLabel.Location = new Point(244, 35);
            professorLabel.Name = "professorLabel";
            professorLabel.Size = new Size(103, 25);
            professorLabel.TabIndex = 21;
            professorLabel.Text = "Professors:";
            // 
            // professorIdLabel
            // 
            professorIdLabel.AutoSize = true;
            professorIdLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            professorIdLabel.Location = new Point(45, 98);
            professorIdLabel.Name = "professorIdLabel";
            professorIdLabel.Size = new Size(22, 17);
            professorIdLabel.TabIndex = 20;
            professorIdLabel.Text = "Id:";
            // 
            // professorNameLabel
            // 
            professorNameLabel.AutoSize = true;
            professorNameLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            professorNameLabel.Location = new Point(21, 131);
            professorNameLabel.Name = "professorNameLabel";
            professorNameLabel.Size = new Size(46, 17);
            professorNameLabel.TabIndex = 19;
            professorNameLabel.Text = "Name:";
            // 
            // professorIdTextBox
            // 
            professorIdTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            professorIdTextBox.Location = new Point(73, 95);
            professorIdTextBox.Margin = new Padding(3, 4, 3, 4);
            professorIdTextBox.Name = "professorIdTextBox";
            professorIdTextBox.Size = new Size(185, 25);
            professorIdTextBox.TabIndex = 18;
            professorIdTextBox.KeyPress += professorIdTextBox_KeyPress;
            // 
            // professorNameTextBox
            // 
            professorNameTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            professorNameTextBox.Location = new Point(73, 128);
            professorNameTextBox.Margin = new Padding(3, 4, 3, 4);
            professorNameTextBox.Name = "professorNameTextBox";
            professorNameTextBox.Size = new Size(464, 25);
            professorNameTextBox.TabIndex = 17;
            // 
            // professorMeetingLabel
            // 
            professorMeetingLabel.AutoSize = true;
            professorMeetingLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            professorMeetingLabel.Location = new Point(284, 98);
            professorMeetingLabel.Name = "professorMeetingLabel";
            professorMeetingLabel.Size = new Size(59, 17);
            professorMeetingLabel.TabIndex = 23;
            professorMeetingLabel.Text = "Meeting:";
            // 
            // professorMeetingComboBox
            // 
            professorMeetingComboBox.FormattingEnabled = true;
            professorMeetingComboBox.Location = new Point(349, 95);
            professorMeetingComboBox.Name = "professorMeetingComboBox";
            professorMeetingComboBox.Size = new Size(188, 25);
            professorMeetingComboBox.TabIndex = 24;
            // 
            // totalProfessorValueLabel
            // 
            totalProfessorValueLabel.AutoSize = true;
            totalProfessorValueLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            totalProfessorValueLabel.Location = new Point(159, 443);
            totalProfessorValueLabel.Name = "totalProfessorValueLabel";
            totalProfessorValueLabel.Size = new Size(13, 15);
            totalProfessorValueLabel.TabIndex = 39;
            totalProfessorValueLabel.Text = "0";
            // 
            // totalProfessorsLabel
            // 
            totalProfessorsLabel.AutoSize = true;
            totalProfessorsLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            totalProfessorsLabel.Location = new Point(70, 443);
            totalProfessorsLabel.Name = "totalProfessorsLabel";
            totalProfessorsLabel.Size = new Size(92, 15);
            totalProfessorsLabel.TabIndex = 38;
            totalProfessorsLabel.Text = "Total Professors:";
            // 
            // professorClearButton
            // 
            professorClearButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            professorClearButton.Location = new Point(349, 160);
            professorClearButton.Name = "professorClearButton";
            professorClearButton.Size = new Size(77, 35);
            professorClearButton.TabIndex = 42;
            professorClearButton.Text = "Clear";
            professorClearButton.UseVisualStyleBackColor = true;
            professorClearButton.Click += professorClearButton_Click;
            // 
            // professorDeleteButton
            // 
            professorDeleteButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            professorDeleteButton.Location = new Point(266, 160);
            professorDeleteButton.Name = "professorDeleteButton";
            professorDeleteButton.Size = new Size(77, 35);
            professorDeleteButton.TabIndex = 41;
            professorDeleteButton.Text = "Delete";
            professorDeleteButton.UseVisualStyleBackColor = true;
            professorDeleteButton.Click += professorDeleteButton_Click;
            // 
            // professorAddButton
            // 
            professorAddButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            professorAddButton.Location = new Point(182, 160);
            professorAddButton.Name = "professorAddButton";
            professorAddButton.Size = new Size(78, 35);
            professorAddButton.TabIndex = 40;
            professorAddButton.Text = "Add";
            professorAddButton.UseVisualStyleBackColor = true;
            professorAddButton.Click += professorAddButton_Click;
            // 
            // professorErrorProvider
            // 
            professorErrorProvider.ContainerControl = this;
            // 
            // deleteAllButton
            // 
            deleteAllButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            deleteAllButton.Location = new Point(460, 160);
            deleteAllButton.Name = "deleteAllButton";
            deleteAllButton.Size = new Size(77, 35);
            deleteAllButton.TabIndex = 43;
            deleteAllButton.Text = "Delete All";
            deleteAllButton.UseVisualStyleBackColor = true;
            deleteAllButton.Click += deleteAllButton_Click;
            // 
            // printButton
            // 
            printButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            printButton.Location = new Point(460, 443);
            printButton.Margin = new Padding(4);
            printButton.Name = "printButton";
            printButton.Size = new Size(77, 34);
            printButton.TabIndex = 74;
            printButton.Text = "Print Data";
            printButton.UseVisualStyleBackColor = true;
            printButton.Click += printButton_Click;
            // 
            // ProfessorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(585, 484);
            Controls.Add(printButton);
            Controls.Add(deleteAllButton);
            Controls.Add(professorClearButton);
            Controls.Add(professorDeleteButton);
            Controls.Add(professorAddButton);
            Controls.Add(totalProfessorValueLabel);
            Controls.Add(totalProfessorsLabel);
            Controls.Add(professorMeetingComboBox);
            Controls.Add(professorMeetingLabel);
            Controls.Add(professorDataGridView);
            Controls.Add(professorLabel);
            Controls.Add(professorIdLabel);
            Controls.Add(professorNameLabel);
            Controls.Add(professorIdTextBox);
            Controls.Add(professorNameTextBox);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.DarkBlue;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "ProfessorForm";
            Text = "Professor";
            Load += ProfessorForm_Load;
            ((System.ComponentModel.ISupportInitialize)professorDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)professorErrorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView professorDataGridView;
        private System.Windows.Forms.Label professorLabel;
        private System.Windows.Forms.Label professorIdLabel;
        private System.Windows.Forms.Label professorNameLabel;
        private System.Windows.Forms.TextBox professorIdTextBox;
        private System.Windows.Forms.TextBox professorNameTextBox;
        private System.Windows.Forms.Label professorMeetingLabel;
        private System.Windows.Forms.ComboBox professorMeetingComboBox;
        private System.Windows.Forms.Label totalProfessorValueLabel;
        private System.Windows.Forms.Label totalProfessorsLabel;
        private System.Windows.Forms.Button professorClearButton;
        private System.Windows.Forms.Button professorDeleteButton;
        private System.Windows.Forms.Button professorAddButton;
        private System.Windows.Forms.ErrorProvider professorErrorProvider;
        private DataGridViewTextBoxColumn dgProfessorId;
        private DataGridViewTextBoxColumn dgProfessorName;
        private DataGridViewTextBoxColumn dgProfessorMeeting;
        private Button deleteAllButton;
        private Button printButton;
    }
}