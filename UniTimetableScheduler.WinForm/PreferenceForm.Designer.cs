namespace Scheduler.WinForm
{
    partial class PreferenceForm
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreferenceForm));
            totalPreferredDayValueLabel = new Label();
            totalPreferredDaysLabel = new Label();
            dayClearButton = new Button();
            dayDeleteButton = new Button();
            dayAddButton = new Button();
            preferredDayDataGridView = new DataGridView();
            dgDaySchedulerID = new DataGridViewTextBoxColumn();
            dgDayID = new DataGridViewTextBoxColumn();
            preferredDayLabel = new Label();
            daySchedulerIdLabel = new Label();
            dayIdLabel = new Label();
            daySchedulerIdComboBox = new ComboBox();
            dayIdComboBox = new ComboBox();
            startTimeIdComboBox = new ComboBox();
            startTimeSchedulerIdComboBox = new ComboBox();
            totalPreferredStartTimeValueLabel = new Label();
            totalPreferredStartTimesLabel = new Label();
            startTimeClearButton = new Button();
            startTimeDeleteButton = new Button();
            startTimeAddButton = new Button();
            preferredStartTimeLabel = new Label();
            startTimeSchedulerIdLabel = new Label();
            startTimeIdLabel = new Label();
            preferredStartTimeDataGridView = new DataGridView();
            dgStartTimeSchedulerID = new DataGridViewTextBoxColumn();
            dgStartTimeID = new DataGridViewTextBoxColumn();
            roomIdComboBox = new ComboBox();
            roomSchedulerIdComboBox = new ComboBox();
            totalPreferredRoomValueLabel = new Label();
            totalPreferredRoomsLabel = new Label();
            roomClearButton = new Button();
            roomDeleteButton = new Button();
            roomAddButton = new Button();
            preferredRoomDataGridView = new DataGridView();
            dgRoomSchedulerID = new DataGridViewTextBoxColumn();
            dgRoomID = new DataGridViewTextBoxColumn();
            preferredRoomLabel = new Label();
            roomSchedulerIdLabel = new Label();
            roomIdLabel = new Label();
            preferenceErrorProvider = new ErrorProvider(components);
            deleteAllPreferredDayButton = new Button();
            deleteAllPreferredStartTimeButton = new Button();
            deleteAllPreferredRoomButton = new Button();
            printPreferredDayButton = new Button();
            printPreferredStartTimeButton = new Button();
            printPreferredRoomButton = new Button();
            ((System.ComponentModel.ISupportInitialize)preferredDayDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)preferredStartTimeDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)preferredRoomDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)preferenceErrorProvider).BeginInit();
            SuspendLayout();
            // 
            // totalPreferredDayValueLabel
            // 
            totalPreferredDayValueLabel.AutoSize = true;
            totalPreferredDayValueLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            totalPreferredDayValueLabel.Location = new Point(236, 444);
            totalPreferredDayValueLabel.Name = "totalPreferredDayValueLabel";
            totalPreferredDayValueLabel.Size = new Size(13, 15);
            totalPreferredDayValueLabel.TabIndex = 74;
            totalPreferredDayValueLabel.Text = "0";
            // 
            // totalPreferredDaysLabel
            // 
            totalPreferredDaysLabel.AutoSize = true;
            totalPreferredDaysLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            totalPreferredDaysLabel.Location = new Point(116, 444);
            totalPreferredDaysLabel.Name = "totalPreferredDaysLabel";
            totalPreferredDaysLabel.Size = new Size(114, 15);
            totalPreferredDaysLabel.TabIndex = 73;
            totalPreferredDaysLabel.Text = "Total Preferred Days:";
            // 
            // dayClearButton
            // 
            dayClearButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dayClearButton.Location = new Point(230, 167);
            dayClearButton.Name = "dayClearButton";
            dayClearButton.Size = new Size(70, 35);
            dayClearButton.TabIndex = 72;
            dayClearButton.Text = "Clear";
            dayClearButton.UseVisualStyleBackColor = true;
            dayClearButton.Click += dayClearButton_Click;
            // 
            // dayDeleteButton
            // 
            dayDeleteButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dayDeleteButton.Location = new Point(154, 167);
            dayDeleteButton.Name = "dayDeleteButton";
            dayDeleteButton.Size = new Size(70, 35);
            dayDeleteButton.TabIndex = 71;
            dayDeleteButton.Text = "Delete";
            dayDeleteButton.UseVisualStyleBackColor = true;
            dayDeleteButton.Click += dayDeleteButton_Click;
            // 
            // dayAddButton
            // 
            dayAddButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dayAddButton.Location = new Point(78, 167);
            dayAddButton.Name = "dayAddButton";
            dayAddButton.Size = new Size(70, 35);
            dayAddButton.TabIndex = 70;
            dayAddButton.Text = "Add";
            dayAddButton.UseVisualStyleBackColor = true;
            dayAddButton.Click += dayAddButton_Click;
            // 
            // preferredDayDataGridView
            // 
            preferredDayDataGridView.AllowUserToAddRows = false;
            preferredDayDataGridView.BackgroundColor = SystemColors.GradientActiveCaption;
            preferredDayDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            preferredDayDataGridView.Columns.AddRange(new DataGridViewColumn[] { dgDaySchedulerID, dgDayID });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.DarkBlue;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkBlue;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            preferredDayDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            preferredDayDataGridView.Location = new Point(60, 208);
            preferredDayDataGridView.Name = "preferredDayDataGridView";
            preferredDayDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            preferredDayDataGridView.Size = new Size(250, 195);
            preferredDayDataGridView.TabIndex = 69;
            preferredDayDataGridView.MouseDoubleClick += preferredDayDataGridView_MouseDoubleClick;
            // 
            // dgDaySchedulerID
            // 
            dgDaySchedulerID.HeaderText = "Scheduler Id";
            dgDaySchedulerID.Name = "dgDaySchedulerID";
            dgDaySchedulerID.Width = 105;
            // 
            // dgDayID
            // 
            dgDayID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgDayID.HeaderText = "Day Id";
            dgDayID.Name = "dgDayID";
            // 
            // preferredDayLabel
            // 
            preferredDayLabel.AutoSize = true;
            preferredDayLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            preferredDayLabel.Location = new Point(116, 62);
            preferredDayLabel.Name = "preferredDayLabel";
            preferredDayLabel.Size = new Size(140, 25);
            preferredDayLabel.TabIndex = 68;
            preferredDayLabel.Text = "Preferred Days:";
            // 
            // daySchedulerIdLabel
            // 
            daySchedulerIdLabel.AutoSize = true;
            daySchedulerIdLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            daySchedulerIdLabel.Location = new Point(57, 106);
            daySchedulerIdLabel.Name = "daySchedulerIdLabel";
            daySchedulerIdLabel.Size = new Size(83, 17);
            daySchedulerIdLabel.TabIndex = 67;
            daySchedulerIdLabel.Text = "Scheduler Id:";
            // 
            // dayIdLabel
            // 
            dayIdLabel.AutoSize = true;
            dayIdLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dayIdLabel.Location = new Point(91, 139);
            dayIdLabel.Name = "dayIdLabel";
            dayIdLabel.Size = new Size(48, 17);
            dayIdLabel.TabIndex = 66;
            dayIdLabel.Text = "Day Id:";
            // 
            // daySchedulerIdComboBox
            // 
            daySchedulerIdComboBox.FormattingEnabled = true;
            daySchedulerIdComboBox.Location = new Point(142, 103);
            daySchedulerIdComboBox.Name = "daySchedulerIdComboBox";
            daySchedulerIdComboBox.Size = new Size(168, 25);
            daySchedulerIdComboBox.TabIndex = 75;
            daySchedulerIdComboBox.KeyPress += daySchedulerIdComboBox_KeyPress;
            // 
            // dayIdComboBox
            // 
            dayIdComboBox.FormattingEnabled = true;
            dayIdComboBox.Location = new Point(142, 136);
            dayIdComboBox.Name = "dayIdComboBox";
            dayIdComboBox.Size = new Size(168, 25);
            dayIdComboBox.TabIndex = 76;
            dayIdComboBox.KeyPress += dayIdComboBox_KeyPress;
            // 
            // startTimeIdComboBox
            // 
            startTimeIdComboBox.FormattingEnabled = true;
            startTimeIdComboBox.Location = new Point(447, 136);
            startTimeIdComboBox.Name = "startTimeIdComboBox";
            startTimeIdComboBox.Size = new Size(171, 25);
            startTimeIdComboBox.TabIndex = 87;
            startTimeIdComboBox.KeyPress += startTimeIdComboBox_KeyPress;
            // 
            // startTimeSchedulerIdComboBox
            // 
            startTimeSchedulerIdComboBox.FormattingEnabled = true;
            startTimeSchedulerIdComboBox.Location = new Point(447, 103);
            startTimeSchedulerIdComboBox.Name = "startTimeSchedulerIdComboBox";
            startTimeSchedulerIdComboBox.Size = new Size(171, 25);
            startTimeSchedulerIdComboBox.TabIndex = 86;
            startTimeSchedulerIdComboBox.KeyPress += startTimeSchedulerIdComboBox_KeyPress;
            // 
            // totalPreferredStartTimeValueLabel
            // 
            totalPreferredStartTimeValueLabel.AutoSize = true;
            totalPreferredStartTimeValueLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            totalPreferredStartTimeValueLabel.Location = new Point(568, 444);
            totalPreferredStartTimeValueLabel.Name = "totalPreferredStartTimeValueLabel";
            totalPreferredStartTimeValueLabel.Size = new Size(13, 15);
            totalPreferredStartTimeValueLabel.TabIndex = 85;
            totalPreferredStartTimeValueLabel.Text = "0";
            // 
            // totalPreferredStartTimesLabel
            // 
            totalPreferredStartTimesLabel.AutoSize = true;
            totalPreferredStartTimesLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            totalPreferredStartTimesLabel.Location = new Point(418, 444);
            totalPreferredStartTimesLabel.Name = "totalPreferredStartTimesLabel";
            totalPreferredStartTimesLabel.Size = new Size(144, 15);
            totalPreferredStartTimesLabel.TabIndex = 84;
            totalPreferredStartTimesLabel.Text = "Total Preferred StartTimes:";
            // 
            // startTimeClearButton
            // 
            startTimeClearButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            startTimeClearButton.Location = new Point(535, 167);
            startTimeClearButton.Name = "startTimeClearButton";
            startTimeClearButton.Size = new Size(70, 35);
            startTimeClearButton.TabIndex = 83;
            startTimeClearButton.Text = "Clear";
            startTimeClearButton.UseVisualStyleBackColor = true;
            startTimeClearButton.Click += startTimeClearButton_Click;
            // 
            // startTimeDeleteButton
            // 
            startTimeDeleteButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            startTimeDeleteButton.Location = new Point(459, 167);
            startTimeDeleteButton.Name = "startTimeDeleteButton";
            startTimeDeleteButton.Size = new Size(70, 35);
            startTimeDeleteButton.TabIndex = 82;
            startTimeDeleteButton.Text = "Delete";
            startTimeDeleteButton.UseVisualStyleBackColor = true;
            startTimeDeleteButton.Click += startTimeDeleteButton_Click;
            // 
            // startTimeAddButton
            // 
            startTimeAddButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            startTimeAddButton.Location = new Point(383, 167);
            startTimeAddButton.Name = "startTimeAddButton";
            startTimeAddButton.Size = new Size(70, 35);
            startTimeAddButton.TabIndex = 81;
            startTimeAddButton.Text = "Add";
            startTimeAddButton.UseVisualStyleBackColor = true;
            startTimeAddButton.Click += startTimeAddButton_Click;
            // 
            // preferredStartTimeLabel
            // 
            preferredStartTimeLabel.AutoSize = true;
            preferredStartTimeLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            preferredStartTimeLabel.Location = new Point(402, 62);
            preferredStartTimeLabel.Name = "preferredStartTimeLabel";
            preferredStartTimeLabel.Size = new Size(192, 25);
            preferredStartTimeLabel.TabIndex = 79;
            preferredStartTimeLabel.Text = "Preferred Start Times:";
            // 
            // startTimeSchedulerIdLabel
            // 
            startTimeSchedulerIdLabel.AutoSize = true;
            startTimeSchedulerIdLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            startTimeSchedulerIdLabel.Location = new Point(361, 106);
            startTimeSchedulerIdLabel.Name = "startTimeSchedulerIdLabel";
            startTimeSchedulerIdLabel.Size = new Size(83, 17);
            startTimeSchedulerIdLabel.TabIndex = 78;
            startTimeSchedulerIdLabel.Text = "Scheduler Id:";
            // 
            // startTimeIdLabel
            // 
            startTimeIdLabel.AutoSize = true;
            startTimeIdLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            startTimeIdLabel.Location = new Point(363, 139);
            startTimeIdLabel.Name = "startTimeIdLabel";
            startTimeIdLabel.Size = new Size(81, 17);
            startTimeIdLabel.TabIndex = 77;
            startTimeIdLabel.Text = "StartTime Id:";
            // 
            // preferredStartTimeDataGridView
            // 
            preferredStartTimeDataGridView.AllowUserToAddRows = false;
            preferredStartTimeDataGridView.BackgroundColor = SystemColors.GradientActiveCaption;
            preferredStartTimeDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            preferredStartTimeDataGridView.Columns.AddRange(new DataGridViewColumn[] { dgStartTimeSchedulerID, dgStartTimeID });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.DarkBlue;
            dataGridViewCellStyle2.SelectionBackColor = Color.DarkBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            preferredStartTimeDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            preferredStartTimeDataGridView.Location = new Point(366, 208);
            preferredStartTimeDataGridView.Name = "preferredStartTimeDataGridView";
            preferredStartTimeDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            preferredStartTimeDataGridView.Size = new Size(250, 195);
            preferredStartTimeDataGridView.TabIndex = 88;
            preferredStartTimeDataGridView.MouseDoubleClick += preferredStartTimeDataGridView_MouseDoubleClick;
            // 
            // dgStartTimeSchedulerID
            // 
            dgStartTimeSchedulerID.HeaderText = "Scheduler Id";
            dgStartTimeSchedulerID.Name = "dgStartTimeSchedulerID";
            dgStartTimeSchedulerID.Width = 105;
            // 
            // dgStartTimeID
            // 
            dgStartTimeID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgStartTimeID.HeaderText = "StartTime Id";
            dgStartTimeID.Name = "dgStartTimeID";
            // 
            // roomIdComboBox
            // 
            roomIdComboBox.FormattingEnabled = true;
            roomIdComboBox.Location = new Point(749, 136);
            roomIdComboBox.Name = "roomIdComboBox";
            roomIdComboBox.Size = new Size(168, 25);
            roomIdComboBox.TabIndex = 99;
            roomIdComboBox.KeyPress += roomIdComboBox_KeyPress;
            // 
            // roomSchedulerIdComboBox
            // 
            roomSchedulerIdComboBox.FormattingEnabled = true;
            roomSchedulerIdComboBox.Location = new Point(749, 103);
            roomSchedulerIdComboBox.Name = "roomSchedulerIdComboBox";
            roomSchedulerIdComboBox.Size = new Size(168, 25);
            roomSchedulerIdComboBox.TabIndex = 98;
            roomSchedulerIdComboBox.KeyPress += roomSchedulerIdComboBox_KeyPress;
            // 
            // totalPreferredRoomValueLabel
            // 
            totalPreferredRoomValueLabel.AutoSize = true;
            totalPreferredRoomValueLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            totalPreferredRoomValueLabel.Location = new Point(850, 444);
            totalPreferredRoomValueLabel.Name = "totalPreferredRoomValueLabel";
            totalPreferredRoomValueLabel.Size = new Size(13, 15);
            totalPreferredRoomValueLabel.TabIndex = 97;
            totalPreferredRoomValueLabel.Text = "0";
            // 
            // totalPreferredRoomsLabel
            // 
            totalPreferredRoomsLabel.AutoSize = true;
            totalPreferredRoomsLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            totalPreferredRoomsLabel.Location = new Point(720, 444);
            totalPreferredRoomsLabel.Name = "totalPreferredRoomsLabel";
            totalPreferredRoomsLabel.Size = new Size(126, 15);
            totalPreferredRoomsLabel.TabIndex = 96;
            totalPreferredRoomsLabel.Text = "Total Preferred Rooms:";
            // 
            // roomClearButton
            // 
            roomClearButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            roomClearButton.Location = new Point(833, 167);
            roomClearButton.Name = "roomClearButton";
            roomClearButton.Size = new Size(70, 35);
            roomClearButton.TabIndex = 95;
            roomClearButton.Text = "Clear";
            roomClearButton.UseVisualStyleBackColor = true;
            roomClearButton.Click += roomClearButton_Click;
            // 
            // roomDeleteButton
            // 
            roomDeleteButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            roomDeleteButton.Location = new Point(757, 167);
            roomDeleteButton.Name = "roomDeleteButton";
            roomDeleteButton.Size = new Size(70, 35);
            roomDeleteButton.TabIndex = 94;
            roomDeleteButton.Text = "Delete";
            roomDeleteButton.UseVisualStyleBackColor = true;
            roomDeleteButton.Click += roomDeleteButton_Click;
            // 
            // roomAddButton
            // 
            roomAddButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            roomAddButton.Location = new Point(681, 167);
            roomAddButton.Name = "roomAddButton";
            roomAddButton.Size = new Size(70, 35);
            roomAddButton.TabIndex = 93;
            roomAddButton.Text = "Add";
            roomAddButton.UseVisualStyleBackColor = true;
            roomAddButton.Click += roomAddButton_Click;
            // 
            // preferredRoomDataGridView
            // 
            preferredRoomDataGridView.AllowUserToAddRows = false;
            preferredRoomDataGridView.BackgroundColor = SystemColors.GradientActiveCaption;
            preferredRoomDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            preferredRoomDataGridView.Columns.AddRange(new DataGridViewColumn[] { dgRoomSchedulerID, dgRoomID });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.DarkBlue;
            dataGridViewCellStyle3.SelectionBackColor = Color.DarkBlue;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            preferredRoomDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            preferredRoomDataGridView.Location = new Point(667, 208);
            preferredRoomDataGridView.Name = "preferredRoomDataGridView";
            preferredRoomDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            preferredRoomDataGridView.Size = new Size(250, 195);
            preferredRoomDataGridView.TabIndex = 92;
            preferredRoomDataGridView.MouseDoubleClick += preferredRoomDataGridView_MouseDoubleClick;
            // 
            // dgRoomSchedulerID
            // 
            dgRoomSchedulerID.HeaderText = "Scheduler Id";
            dgRoomSchedulerID.Name = "dgRoomSchedulerID";
            dgRoomSchedulerID.Width = 105;
            // 
            // dgRoomID
            // 
            dgRoomID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgRoomID.HeaderText = "Room Id";
            dgRoomID.Name = "dgRoomID";
            // 
            // preferredRoomLabel
            // 
            preferredRoomLabel.AutoSize = true;
            preferredRoomLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            preferredRoomLabel.Location = new Point(720, 62);
            preferredRoomLabel.Name = "preferredRoomLabel";
            preferredRoomLabel.Size = new Size(156, 25);
            preferredRoomLabel.TabIndex = 91;
            preferredRoomLabel.Text = "Preferred Rooms:";
            // 
            // roomSchedulerIdLabel
            // 
            roomSchedulerIdLabel.AutoSize = true;
            roomSchedulerIdLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            roomSchedulerIdLabel.Location = new Point(663, 106);
            roomSchedulerIdLabel.Name = "roomSchedulerIdLabel";
            roomSchedulerIdLabel.Size = new Size(83, 17);
            roomSchedulerIdLabel.TabIndex = 90;
            roomSchedulerIdLabel.Text = "Scheduler Id:";
            // 
            // roomIdLabel
            // 
            roomIdLabel.AutoSize = true;
            roomIdLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            roomIdLabel.Location = new Point(685, 139);
            roomIdLabel.Name = "roomIdLabel";
            roomIdLabel.Size = new Size(61, 17);
            roomIdLabel.TabIndex = 89;
            roomIdLabel.Text = "Room Id:";
            // 
            // preferenceErrorProvider
            // 
            preferenceErrorProvider.ContainerControl = this;
            // 
            // deleteAllPreferredDayButton
            // 
            deleteAllPreferredDayButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            deleteAllPreferredDayButton.Location = new Point(237, 406);
            deleteAllPreferredDayButton.Name = "deleteAllPreferredDayButton";
            deleteAllPreferredDayButton.Size = new Size(73, 34);
            deleteAllPreferredDayButton.TabIndex = 100;
            deleteAllPreferredDayButton.Text = "Delete All";
            deleteAllPreferredDayButton.UseVisualStyleBackColor = true;
            deleteAllPreferredDayButton.Click += deleteAllPreferredDayButton_Click;
            // 
            // deleteAllPreferredStartTimeButton
            // 
            deleteAllPreferredStartTimeButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            deleteAllPreferredStartTimeButton.Location = new Point(545, 406);
            deleteAllPreferredStartTimeButton.Name = "deleteAllPreferredStartTimeButton";
            deleteAllPreferredStartTimeButton.Size = new Size(73, 34);
            deleteAllPreferredStartTimeButton.TabIndex = 101;
            deleteAllPreferredStartTimeButton.Text = "Delete All";
            deleteAllPreferredStartTimeButton.UseVisualStyleBackColor = true;
            deleteAllPreferredStartTimeButton.Click += deleteAllPreferredStartTimeButton_Click;
            // 
            // deleteAllPreferredRoomButton
            // 
            deleteAllPreferredRoomButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            deleteAllPreferredRoomButton.Location = new Point(844, 405);
            deleteAllPreferredRoomButton.Name = "deleteAllPreferredRoomButton";
            deleteAllPreferredRoomButton.Size = new Size(73, 34);
            deleteAllPreferredRoomButton.TabIndex = 102;
            deleteAllPreferredRoomButton.Text = "Delete All";
            deleteAllPreferredRoomButton.UseVisualStyleBackColor = true;
            deleteAllPreferredRoomButton.Click += deleteAllPreferredRoomButton_Click;
            // 
            // printPreferredDayButton
            // 
            printPreferredDayButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            printPreferredDayButton.Location = new Point(60, 406);
            printPreferredDayButton.Margin = new Padding(4);
            printPreferredDayButton.Name = "printPreferredDayButton";
            printPreferredDayButton.Size = new Size(73, 34);
            printPreferredDayButton.TabIndex = 103;
            printPreferredDayButton.Text = "Print Data";
            printPreferredDayButton.UseVisualStyleBackColor = true;
            printPreferredDayButton.Click += printPreferredDayButton_Click;
            // 
            // printPreferredStartTimeButton
            // 
            printPreferredStartTimeButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            printPreferredStartTimeButton.Location = new Point(366, 406);
            printPreferredStartTimeButton.Margin = new Padding(4);
            printPreferredStartTimeButton.Name = "printPreferredStartTimeButton";
            printPreferredStartTimeButton.Size = new Size(73, 34);
            printPreferredStartTimeButton.TabIndex = 104;
            printPreferredStartTimeButton.Text = "Print Data";
            printPreferredStartTimeButton.UseVisualStyleBackColor = true;
            printPreferredStartTimeButton.Click += printPreferredStartTimeButton_Click;
            // 
            // printPreferredRoomButton
            // 
            printPreferredRoomButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            printPreferredRoomButton.Location = new Point(667, 405);
            printPreferredRoomButton.Margin = new Padding(4);
            printPreferredRoomButton.Name = "printPreferredRoomButton";
            printPreferredRoomButton.Size = new Size(73, 34);
            printPreferredRoomButton.TabIndex = 105;
            printPreferredRoomButton.Text = "Print Data";
            printPreferredRoomButton.UseVisualStyleBackColor = true;
            printPreferredRoomButton.Click += printPreferredRoomButton_Click;
            // 
            // PreferenceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(944, 477);
            Controls.Add(printPreferredRoomButton);
            Controls.Add(printPreferredStartTimeButton);
            Controls.Add(printPreferredDayButton);
            Controls.Add(deleteAllPreferredRoomButton);
            Controls.Add(deleteAllPreferredStartTimeButton);
            Controls.Add(deleteAllPreferredDayButton);
            Controls.Add(roomIdComboBox);
            Controls.Add(roomSchedulerIdComboBox);
            Controls.Add(totalPreferredRoomValueLabel);
            Controls.Add(totalPreferredRoomsLabel);
            Controls.Add(roomClearButton);
            Controls.Add(roomDeleteButton);
            Controls.Add(roomAddButton);
            Controls.Add(preferredRoomDataGridView);
            Controls.Add(preferredRoomLabel);
            Controls.Add(roomSchedulerIdLabel);
            Controls.Add(roomIdLabel);
            Controls.Add(preferredStartTimeDataGridView);
            Controls.Add(startTimeIdComboBox);
            Controls.Add(startTimeSchedulerIdComboBox);
            Controls.Add(totalPreferredStartTimeValueLabel);
            Controls.Add(totalPreferredStartTimesLabel);
            Controls.Add(startTimeClearButton);
            Controls.Add(startTimeDeleteButton);
            Controls.Add(startTimeAddButton);
            Controls.Add(preferredStartTimeLabel);
            Controls.Add(startTimeSchedulerIdLabel);
            Controls.Add(startTimeIdLabel);
            Controls.Add(dayIdComboBox);
            Controls.Add(daySchedulerIdComboBox);
            Controls.Add(totalPreferredDayValueLabel);
            Controls.Add(totalPreferredDaysLabel);
            Controls.Add(dayClearButton);
            Controls.Add(dayDeleteButton);
            Controls.Add(dayAddButton);
            Controls.Add(preferredDayDataGridView);
            Controls.Add(preferredDayLabel);
            Controls.Add(daySchedulerIdLabel);
            Controls.Add(dayIdLabel);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.DarkBlue;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "PreferenceForm";
            Text = "Preference";
            Load += PreferenceForm_Load;
            ((System.ComponentModel.ISupportInitialize)preferredDayDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)preferredStartTimeDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)preferredRoomDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)preferenceErrorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label totalPreferredDayValueLabel;
        private System.Windows.Forms.Label totalPreferredDaysLabel;
        private System.Windows.Forms.Button dayClearButton;
        private System.Windows.Forms.Button dayDeleteButton;
        private System.Windows.Forms.Button dayAddButton;
        private System.Windows.Forms.DataGridView preferredDayDataGridView;
        private System.Windows.Forms.Label preferredDayLabel;
        private System.Windows.Forms.Label daySchedulerIdLabel;
        private System.Windows.Forms.Label dayIdLabel;
        private System.Windows.Forms.ComboBox daySchedulerIdComboBox;
        private System.Windows.Forms.ComboBox dayIdComboBox;
        private System.Windows.Forms.ComboBox startTimeIdComboBox;
        private System.Windows.Forms.ComboBox startTimeSchedulerIdComboBox;
        private System.Windows.Forms.Label totalPreferredStartTimeValueLabel;
        private System.Windows.Forms.Label totalPreferredStartTimesLabel;
        private System.Windows.Forms.Button startTimeClearButton;
        private System.Windows.Forms.Button startTimeDeleteButton;
        private System.Windows.Forms.Button startTimeAddButton;
        private System.Windows.Forms.Label preferredStartTimeLabel;
        private System.Windows.Forms.Label startTimeSchedulerIdLabel;
        private System.Windows.Forms.Label startTimeIdLabel;
        private System.Windows.Forms.DataGridView preferredStartTimeDataGridView;
        private System.Windows.Forms.ComboBox roomIdComboBox;
        private System.Windows.Forms.ComboBox roomSchedulerIdComboBox;
        private System.Windows.Forms.Label totalPreferredRoomValueLabel;
        private System.Windows.Forms.Label totalPreferredRoomsLabel;
        private System.Windows.Forms.Button roomClearButton;
        private System.Windows.Forms.Button roomDeleteButton;
        private System.Windows.Forms.Button roomAddButton;
        private System.Windows.Forms.DataGridView preferredRoomDataGridView;
        private System.Windows.Forms.Label preferredRoomLabel;
        private System.Windows.Forms.Label roomSchedulerIdLabel;
        private System.Windows.Forms.Label roomIdLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDaySchedulerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDayID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgStartTimeSchedulerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgStartTimeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgRoomSchedulerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgRoomID;
        private System.Windows.Forms.ErrorProvider preferenceErrorProvider;
        private Button deleteAllPreferredRoomButton;
        private Button deleteAllPreferredStartTimeButton;
        private Button deleteAllPreferredDayButton;
        private Button printPreferredRoomButton;
        private Button printPreferredStartTimeButton;
        private Button printPreferredDayButton;
    }
}