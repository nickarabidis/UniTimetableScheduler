namespace Scheduler.WinForm
{
    partial class DependencyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DependencyForm));
            dependencyClearButton = new Button();
            dependencyDeleteButton = new Button();
            dependencyAddButton = new Button();
            dependencyDataGridView = new DataGridView();
            dependenciesLabel = new Label();
            dependencyDependentCourseIdLabel = new Label();
            dependencyCourseIdLabel = new Label();
            dependencyCourseIdComboBox = new ComboBox();
            dependencyInHowManyDaysComboBox = new ComboBox();
            label1 = new Label();
            totalDependencyValueLabel = new Label();
            totalDependenciesLabel = new Label();
            dependencyErrorProvider = new ErrorProvider(components);
            dependencyDependentCourseIdComboBox = new ComboBox();
            dgDependencyCourseId = new DataGridViewTextBoxColumn();
            dgDependencyDependentCourseId = new DataGridViewTextBoxColumn();
            dgDependencyInHowManyDays = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dependencyDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dependencyErrorProvider).BeginInit();
            SuspendLayout();
            // 
            // dependencyClearButton
            // 
            dependencyClearButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dependencyClearButton.Location = new Point(305, 163);
            dependencyClearButton.Name = "dependencyClearButton";
            dependencyClearButton.Size = new Size(100, 35);
            dependencyClearButton.TabIndex = 38;
            dependencyClearButton.Text = "Clear";
            dependencyClearButton.UseVisualStyleBackColor = true;
            dependencyClearButton.Click += dependencyClearButton_Click;
            // 
            // dependencyDeleteButton
            // 
            dependencyDeleteButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dependencyDeleteButton.Location = new Point(199, 163);
            dependencyDeleteButton.Name = "dependencyDeleteButton";
            dependencyDeleteButton.Size = new Size(100, 35);
            dependencyDeleteButton.TabIndex = 37;
            dependencyDeleteButton.Text = "Delete";
            dependencyDeleteButton.UseVisualStyleBackColor = true;
            dependencyDeleteButton.Click += dependencyDeleteButton_Click;
            // 
            // dependencyAddButton
            // 
            dependencyAddButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dependencyAddButton.Location = new Point(93, 163);
            dependencyAddButton.Name = "dependencyAddButton";
            dependencyAddButton.Size = new Size(100, 35);
            dependencyAddButton.TabIndex = 36;
            dependencyAddButton.Text = "Add";
            dependencyAddButton.UseVisualStyleBackColor = true;
            dependencyAddButton.Click += dependencyAddButton_Click;
            // 
            // dependencyDataGridView
            // 
            dependencyDataGridView.AllowUserToAddRows = false;
            dependencyDataGridView.BackgroundColor = SystemColors.GradientActiveCaption;
            dependencyDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dependencyDataGridView.Columns.AddRange(new DataGridViewColumn[] { dgDependencyCourseId, dgDependencyDependentCourseId, dgDependencyInHowManyDays });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.DarkBlue;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkBlue;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dependencyDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            dependencyDataGridView.Location = new Point(53, 204);
            dependencyDataGridView.Name = "dependencyDataGridView";
            dependencyDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dependencyDataGridView.Size = new Size(384, 271);
            dependencyDataGridView.TabIndex = 35;
            dependencyDataGridView.MouseDoubleClick += dependencyDataGridView_MouseDoubleClick;
            // 
            // dependenciesLabel
            // 
            dependenciesLabel.AutoSize = true;
            dependenciesLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            dependenciesLabel.Location = new Point(187, 20);
            dependenciesLabel.Name = "dependenciesLabel";
            dependenciesLabel.Size = new Size(135, 25);
            dependenciesLabel.TabIndex = 34;
            dependenciesLabel.Text = "Dependencies:";
            // 
            // dependencyDependentCourseIdLabel
            // 
            dependencyDependentCourseIdLabel.AutoSize = true;
            dependencyDependentCourseIdLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dependencyDependentCourseIdLabel.Location = new Point(34, 95);
            dependencyDependentCourseIdLabel.Name = "dependencyDependentCourseIdLabel";
            dependencyDependentCourseIdLabel.Size = new Size(135, 17);
            dependencyDependentCourseIdLabel.TabIndex = 33;
            dependencyDependentCourseIdLabel.Text = "Dependent Course Id:";
            // 
            // dependencyCourseIdLabel
            // 
            dependencyCourseIdLabel.AutoSize = true;
            dependencyCourseIdLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dependencyCourseIdLabel.Location = new Point(102, 63);
            dependencyCourseIdLabel.Name = "dependencyCourseIdLabel";
            dependencyCourseIdLabel.Size = new Size(67, 17);
            dependencyCourseIdLabel.TabIndex = 32;
            dependencyCourseIdLabel.Text = "Course Id:";
            // 
            // dependencyCourseIdComboBox
            // 
            dependencyCourseIdComboBox.FormattingEnabled = true;
            dependencyCourseIdComboBox.Location = new Point(175, 60);
            dependencyCourseIdComboBox.Name = "dependencyCourseIdComboBox";
            dependencyCourseIdComboBox.Size = new Size(262, 25);
            dependencyCourseIdComboBox.TabIndex = 39;
            // 
            // dependencyInHowManyDaysComboBox
            // 
            dependencyInHowManyDaysComboBox.FormattingEnabled = true;
            dependencyInHowManyDaysComboBox.Location = new Point(175, 124);
            dependencyInHowManyDaysComboBox.Name = "dependencyInHowManyDaysComboBox";
            dependencyInHowManyDaysComboBox.Size = new Size(262, 25);
            dependencyInHowManyDaysComboBox.TabIndex = 45;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(50, 127);
            label1.Name = "label1";
            label1.Size = new Size(119, 17);
            label1.TabIndex = 44;
            label1.Text = "In How Many Days:";
            // 
            // totalDependencyValueLabel
            // 
            totalDependencyValueLabel.AutoSize = true;
            totalDependencyValueLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            totalDependencyValueLabel.Location = new Point(171, 478);
            totalDependencyValueLabel.Name = "totalDependencyValueLabel";
            totalDependencyValueLabel.Size = new Size(13, 15);
            totalDependencyValueLabel.TabIndex = 47;
            totalDependencyValueLabel.Text = "0";
            // 
            // totalDependenciesLabel
            // 
            totalDependenciesLabel.AutoSize = true;
            totalDependenciesLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            totalDependenciesLabel.Location = new Point(53, 478);
            totalDependenciesLabel.Name = "totalDependenciesLabel";
            totalDependenciesLabel.Size = new Size(112, 15);
            totalDependenciesLabel.TabIndex = 46;
            totalDependenciesLabel.Text = "Total Dependencies:";
            // 
            // dependencyErrorProvider
            // 
            dependencyErrorProvider.ContainerControl = this;
            // 
            // dependencyDependentCourseIdComboBox
            // 
            dependencyDependentCourseIdComboBox.FormattingEnabled = true;
            dependencyDependentCourseIdComboBox.Location = new Point(175, 93);
            dependencyDependentCourseIdComboBox.Name = "dependencyDependentCourseIdComboBox";
            dependencyDependentCourseIdComboBox.Size = new Size(262, 25);
            dependencyDependentCourseIdComboBox.TabIndex = 48;
            // 
            // dgDependencyCourseId
            // 
            dgDependencyCourseId.HeaderText = "Scheduler Id";
            dgDependencyCourseId.Name = "dgDependencyCourseId";
            dgDependencyCourseId.Width = 90;
            // 
            // dgDependencyDependentCourseId
            // 
            dgDependencyDependentCourseId.HeaderText = "Dependent Scheduler Id";
            dgDependencyDependentCourseId.Name = "dgDependencyDependentCourseId";
            dgDependencyDependentCourseId.Width = 110;
            // 
            // dgDependencyInHowManyDays
            // 
            dgDependencyInHowManyDays.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgDependencyInHowManyDays.HeaderText = "In How Many Days";
            dgDependencyInHowManyDays.Name = "dgDependencyInHowManyDays";
            // 
            // DependencyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(509, 523);
            Controls.Add(dependencyDependentCourseIdComboBox);
            Controls.Add(totalDependencyValueLabel);
            Controls.Add(totalDependenciesLabel);
            Controls.Add(dependencyInHowManyDaysComboBox);
            Controls.Add(label1);
            Controls.Add(dependencyCourseIdComboBox);
            Controls.Add(dependencyClearButton);
            Controls.Add(dependencyDeleteButton);
            Controls.Add(dependencyAddButton);
            Controls.Add(dependencyDataGridView);
            Controls.Add(dependenciesLabel);
            Controls.Add(dependencyDependentCourseIdLabel);
            Controls.Add(dependencyCourseIdLabel);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.DarkBlue;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "DependencyForm";
            Text = "Dependency";
            Load += DependencyForm_Load;
            ((System.ComponentModel.ISupportInitialize)dependencyDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)dependencyErrorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button dependencyClearButton;
        private System.Windows.Forms.Button dependencyDeleteButton;
        private System.Windows.Forms.Button dependencyAddButton;
        private System.Windows.Forms.DataGridView dependencyDataGridView;
        private System.Windows.Forms.Label dependenciesLabel;
        private System.Windows.Forms.Label dependencyDependentCourseIdLabel;
        private System.Windows.Forms.Label dependencyCourseIdLabel;
        private System.Windows.Forms.ComboBox dependencyCourseIdComboBox;
        private System.Windows.Forms.ComboBox dependencyInHowManyDaysComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label totalDependencyValueLabel;
        private System.Windows.Forms.Label totalDependenciesLabel;
        private System.Windows.Forms.ErrorProvider dependencyErrorProvider;
        private System.Windows.Forms.ComboBox dependencyDependentCourseIdComboBox;
        private DataGridViewTextBoxColumn dgDependencyCourseId;
        private DataGridViewTextBoxColumn dgDependencyDependentCourseId;
        private DataGridViewTextBoxColumn dgDependencyInHowManyDays;
    }
}