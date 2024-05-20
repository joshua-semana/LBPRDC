namespace LBPRDC.Source.Views.Billing
{
    partial class EmployeeTimekeepReviewForm
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            pnlLine1 = new Panel();
            pnlFooter = new Panel();
            lblEntryCounter = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnVerifyBilling = new Button();
            btnSave = new Button();
            btnNext = new Button();
            btnPrevious = new Button();
            btnVerify = new Button();
            pnlBody = new Panel();
            grpExport = new GroupBox();
            label16 = new Label();
            radNoExport = new RadioButton();
            radYesExport = new RadioButton();
            grpNightDifferential = new GroupBox();
            txtNight_10 = new TextBox();
            label41 = new Label();
            txtNight_20 = new TextBox();
            label42 = new Label();
            txtNight_50 = new TextBox();
            label43 = new Label();
            txtNight_125 = new TextBox();
            label44 = new Label();
            label21 = new Label();
            label45 = new Label();
            txtNight_130 = new TextBox();
            label26 = new Label();
            label46 = new Label();
            txtNight_150 = new TextBox();
            label20 = new Label();
            label22 = new Label();
            label19 = new Label();
            label18 = new Label();
            dgvAdjustmentSummary = new DataGridView();
            btnRemove = new Button();
            grpOvertime = new GroupBox();
            txtRegular_125 = new TextBox();
            label7 = new Label();
            label8 = new Label();
            txtRestDaySpecialHoliday_130 = new TextBox();
            label9 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label37 = new Label();
            txtRestDay_150 = new TextBox();
            label38 = new Label();
            label39 = new Label();
            label40 = new Label();
            label35 = new Label();
            txtRestDayExcess_169 = new TextBox();
            label36 = new Label();
            label47 = new Label();
            label34 = new Label();
            label48 = new Label();
            label33 = new Label();
            txtRenderedOvertimeHours = new TextBox();
            txtSpecialHolidayExcess_195 = new TextBox();
            txtRegularHoliday_160 = new TextBox();
            txtLegalHoliday_200 = new TextBox();
            txtLegalHoliday_260 = new TextBox();
            grpRemarks = new GroupBox();
            label49 = new Label();
            label50 = new Label();
            btnClearBookmark = new Button();
            btnApplyBookmark = new Button();
            txtBookmarkReason = new TextBox();
            label32 = new Label();
            btnClearRemarks = new Button();
            btnApplyRemarks = new Button();
            label30 = new Label();
            txtTimekeepRemarks = new TextBox();
            txtCustomRemarks = new TextBox();
            lblCustomRemarks = new Label();
            dgvAdjustments = new DataGridView();
            grpBasicInformation = new GroupBox();
            label31 = new Label();
            txtRegularInDays = new TextBox();
            txtUndertime = new TextBox();
            label28 = new Label();
            label24 = new Label();
            label17 = new Label();
            label27 = new Label();
            txtLegalHolidayDays_100 = new TextBox();
            label23 = new Label();
            txtLegalHolidayHours_100 = new TextBox();
            label3 = new Label();
            txtRenderedRegularHours = new TextBox();
            label2 = new Label();
            txtTotalRegularHours = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label1 = new Label();
            label6 = new Label();
            btnAddAdjustment = new Button();
            lblEmployeeInformation = new Label();
            pnlLine2 = new Panel();
            lblTitle = new Label();
            pnlLeft = new Panel();
            pnlLeftBody = new Panel();
            flowLeftEmployeeList = new FlowLayoutPanel();
            pnlLeftHeader = new Panel();
            btnRemoveEntry = new Button();
            btnInsertEntry = new Button();
            btnSearch = new Button();
            label10 = new Label();
            txtSearch = new TextBox();
            cmbDepartment = new ComboBox();
            pnlLine3 = new Panel();
            label29 = new Label();
            pnlVLine1 = new Panel();
            pnlFooter.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            pnlBody.SuspendLayout();
            grpExport.SuspendLayout();
            grpNightDifferential.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAdjustmentSummary).BeginInit();
            grpOvertime.SuspendLayout();
            grpRemarks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAdjustments).BeginInit();
            grpBasicInformation.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlLeftBody.SuspendLayout();
            pnlLeftHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLine1
            // 
            pnlLine1.BorderStyle = BorderStyle.FixedSingle;
            pnlLine1.Dock = DockStyle.Top;
            pnlLine1.Location = new Point(0, 0);
            pnlLine1.Name = "pnlLine1";
            pnlLine1.Size = new Size(1608, 1);
            pnlLine1.TabIndex = 0;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = SystemColors.Control;
            pnlFooter.Controls.Add(lblEntryCounter);
            pnlFooter.Controls.Add(flowLayoutPanel1);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(303, 938);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1305, 46);
            pnlFooter.TabIndex = 1;
            // 
            // lblEntryCounter
            // 
            lblEntryCounter.AutoSize = true;
            lblEntryCounter.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblEntryCounter.ForeColor = SystemColors.GrayText;
            lblEntryCounter.Location = new Point(16, 15);
            lblEntryCounter.Margin = new Padding(0, 0, 0, 4);
            lblEntryCounter.Name = "lblEntryCounter";
            lblEntryCounter.Size = new Size(45, 16);
            lblEntryCounter.TabIndex = 23;
            lblEntryCounter.Text = "Count";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnVerifyBilling);
            flowLayoutPanel1.Controls.Add(btnSave);
            flowLayoutPanel1.Controls.Add(btnNext);
            flowLayoutPanel1.Controls.Add(btnPrevious);
            flowLayoutPanel1.Controls.Add(btnVerify);
            flowLayoutPanel1.Dock = DockStyle.Right;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(660, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(16, 9, 0, 0);
            flowLayoutPanel1.Size = new Size(645, 46);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // btnVerifyBilling
            // 
            btnVerifyBilling.AutoSize = true;
            btnVerifyBilling.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnVerifyBilling.Location = new Point(554, 9);
            btnVerifyBilling.Margin = new Padding(8, 0, 0, 0);
            btnVerifyBilling.Name = "btnVerifyBilling";
            btnVerifyBilling.Size = new Size(75, 28);
            btnVerifyBilling.TabIndex = 13;
            btnVerifyBilling.Text = "Finish";
            btnVerifyBilling.UseVisualStyleBackColor = true;
            btnVerifyBilling.Click += btnVerifyBilling_Click;
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Location = new Point(471, 9);
            btnSave.Margin = new Padding(24, 0, 0, 0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 28);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnNext
            // 
            btnNext.AutoSize = true;
            btnNext.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnNext.Location = new Point(372, 9);
            btnNext.Margin = new Padding(8, 0, 0, 0);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(75, 28);
            btnNext.TabIndex = 12;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.AutoSize = true;
            btnPrevious.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnPrevious.Location = new Point(289, 9);
            btnPrevious.Margin = new Padding(24, 0, 0, 0);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(75, 28);
            btnPrevious.TabIndex = 11;
            btnPrevious.Text = "Previous";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnVerify
            // 
            btnVerify.AutoSize = true;
            btnVerify.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnVerify.Location = new Point(185, 9);
            btnVerify.Margin = new Padding(8, 0, 0, 0);
            btnVerify.Name = "btnVerify";
            btnVerify.Size = new Size(80, 28);
            btnVerify.TabIndex = 9;
            btnVerify.Text = "Verify";
            btnVerify.UseVisualStyleBackColor = true;
            btnVerify.Click += btnVerify_Click;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(grpExport);
            pnlBody.Controls.Add(grpNightDifferential);
            pnlBody.Controls.Add(dgvAdjustmentSummary);
            pnlBody.Controls.Add(btnRemove);
            pnlBody.Controls.Add(grpOvertime);
            pnlBody.Controls.Add(grpRemarks);
            pnlBody.Controls.Add(dgvAdjustments);
            pnlBody.Controls.Add(grpBasicInformation);
            pnlBody.Controls.Add(btnAddAdjustment);
            pnlBody.Controls.Add(lblEmployeeInformation);
            pnlBody.Controls.Add(pnlLine2);
            pnlBody.Controls.Add(lblTitle);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(303, 1);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(16);
            pnlBody.Size = new Size(1305, 937);
            pnlBody.TabIndex = 2;
            // 
            // grpExport
            // 
            grpExport.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpExport.Controls.Add(label16);
            grpExport.Controls.Add(radNoExport);
            grpExport.Controls.Add(radYesExport);
            grpExport.Location = new Point(481, 863);
            grpExport.Margin = new Padding(0, 0, 0, 16);
            grpExport.Name = "grpExport";
            grpExport.Padding = new Padding(16, 8, 1, 8);
            grpExport.Size = new Size(808, 58);
            grpExport.TabIndex = 65;
            grpExport.TabStop = false;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label16.Location = new Point(20, 24);
            label16.Margin = new Padding(0, 0, 16, 4);
            label16.Name = "label16";
            label16.Size = new Size(389, 16);
            label16.TabIndex = 51;
            label16.Text = "Include this employee in your final department report?";
            label16.TextAlign = ContentAlignment.MiddleRight;
            // 
            // radNoExport
            // 
            radNoExport.AutoSize = true;
            radNoExport.Location = new Point(625, 22);
            radNoExport.Margin = new Padding(0);
            radNoExport.Name = "radNoExport";
            radNoExport.Size = new Size(130, 20);
            radNoExport.TabIndex = 1;
            radNoExport.TabStop = true;
            radNoExport.Text = "No, don't include";
            radNoExport.UseVisualStyleBackColor = true;
            radNoExport.Click += radNoExport_Click;
            // 
            // radYesExport
            // 
            radYesExport.AutoSize = true;
            radYesExport.Location = new Point(425, 22);
            radYesExport.Margin = new Padding(0, 0, 8, 0);
            radYesExport.Name = "radYesExport";
            radYesExport.Size = new Size(192, 20);
            radYesExport.TabIndex = 0;
            radYesExport.TabStop = true;
            radYesExport.Text = "Yes, include this employee";
            radYesExport.UseVisualStyleBackColor = true;
            radYesExport.Click += radYesExport_Click;
            // 
            // grpNightDifferential
            // 
            grpNightDifferential.Controls.Add(txtNight_10);
            grpNightDifferential.Controls.Add(label41);
            grpNightDifferential.Controls.Add(txtNight_20);
            grpNightDifferential.Controls.Add(label42);
            grpNightDifferential.Controls.Add(txtNight_50);
            grpNightDifferential.Controls.Add(label43);
            grpNightDifferential.Controls.Add(txtNight_125);
            grpNightDifferential.Controls.Add(label44);
            grpNightDifferential.Controls.Add(label21);
            grpNightDifferential.Controls.Add(label45);
            grpNightDifferential.Controls.Add(txtNight_130);
            grpNightDifferential.Controls.Add(label26);
            grpNightDifferential.Controls.Add(label46);
            grpNightDifferential.Controls.Add(txtNight_150);
            grpNightDifferential.Controls.Add(label20);
            grpNightDifferential.Controls.Add(label22);
            grpNightDifferential.Controls.Add(label19);
            grpNightDifferential.Controls.Add(label18);
            grpNightDifferential.Location = new Point(16, 684);
            grpNightDifferential.Margin = new Padding(0, 0, 17, 0);
            grpNightDifferential.Name = "grpNightDifferential";
            grpNightDifferential.Padding = new Padding(16, 8, 16, 8);
            grpNightDifferential.Size = new Size(448, 237);
            grpNightDifferential.TabIndex = 64;
            grpNightDifferential.TabStop = false;
            grpNightDifferential.Text = "Night Differentials";
            // 
            // txtNight_10
            // 
            txtNight_10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNight_10.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNight_10.Location = new Point(278, 24);
            txtNight_10.Margin = new Padding(0, 0, 4, 8);
            txtNight_10.Name = "txtNight_10";
            txtNight_10.ReadOnly = true;
            txtNight_10.Size = new Size(100, 26);
            txtNight_10.TabIndex = 25;
            txtNight_10.TabStop = false;
            txtNight_10.TextAlign = HorizontalAlignment.Right;
            // 
            // label41
            // 
            label41.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label41.AutoSize = true;
            label41.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label41.ForeColor = SystemColors.GrayText;
            label41.Location = new Point(382, 199);
            label41.Margin = new Padding(0, 0, 0, 4);
            label41.Name = "label41";
            label41.Size = new Size(49, 16);
            label41.TabIndex = 63;
            label41.Text = "hh:mm";
            // 
            // txtNight_20
            // 
            txtNight_20.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNight_20.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNight_20.Location = new Point(278, 58);
            txtNight_20.Margin = new Padding(0, 0, 4, 8);
            txtNight_20.Name = "txtNight_20";
            txtNight_20.ReadOnly = true;
            txtNight_20.Size = new Size(100, 26);
            txtNight_20.TabIndex = 26;
            txtNight_20.TabStop = false;
            txtNight_20.TextAlign = HorizontalAlignment.Right;
            // 
            // label42
            // 
            label42.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label42.AutoSize = true;
            label42.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label42.ForeColor = SystemColors.GrayText;
            label42.Location = new Point(382, 165);
            label42.Margin = new Padding(0, 0, 0, 4);
            label42.Name = "label42";
            label42.Size = new Size(49, 16);
            label42.TabIndex = 62;
            label42.Text = "hh:mm";
            // 
            // txtNight_50
            // 
            txtNight_50.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNight_50.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNight_50.Location = new Point(278, 92);
            txtNight_50.Margin = new Padding(0, 0, 4, 8);
            txtNight_50.Name = "txtNight_50";
            txtNight_50.ReadOnly = true;
            txtNight_50.Size = new Size(100, 26);
            txtNight_50.TabIndex = 35;
            txtNight_50.TabStop = false;
            txtNight_50.TextAlign = HorizontalAlignment.Right;
            // 
            // label43
            // 
            label43.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label43.AutoSize = true;
            label43.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label43.ForeColor = SystemColors.GrayText;
            label43.Location = new Point(382, 131);
            label43.Margin = new Padding(0, 0, 0, 4);
            label43.Name = "label43";
            label43.Size = new Size(49, 16);
            label43.TabIndex = 61;
            label43.Text = "hh:mm";
            // 
            // txtNight_125
            // 
            txtNight_125.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNight_125.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNight_125.Location = new Point(278, 126);
            txtNight_125.Margin = new Padding(0, 0, 4, 8);
            txtNight_125.Name = "txtNight_125";
            txtNight_125.ReadOnly = true;
            txtNight_125.Size = new Size(100, 26);
            txtNight_125.TabIndex = 36;
            txtNight_125.TabStop = false;
            txtNight_125.TextAlign = HorizontalAlignment.Right;
            // 
            // label44
            // 
            label44.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label44.AutoSize = true;
            label44.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label44.ForeColor = SystemColors.GrayText;
            label44.Location = new Point(382, 97);
            label44.Margin = new Padding(0, 0, 0, 4);
            label44.Name = "label44";
            label44.Size = new Size(49, 16);
            label44.TabIndex = 60;
            label44.Text = "hh:mm";
            // 
            // label21
            // 
            label21.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label21.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label21.Location = new Point(11, 199);
            label21.Margin = new Padding(0, 0, 0, 4);
            label21.Name = "label21";
            label21.Size = new Size(262, 16);
            label21.TabIndex = 43;
            label21.Text = "Night Differential (150%) :";
            label21.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label45
            // 
            label45.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label45.AutoSize = true;
            label45.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label45.ForeColor = SystemColors.GrayText;
            label45.Location = new Point(382, 63);
            label45.Margin = new Padding(0, 0, 0, 4);
            label45.Name = "label45";
            label45.Size = new Size(49, 16);
            label45.TabIndex = 59;
            label45.Text = "hh:mm";
            // 
            // txtNight_130
            // 
            txtNight_130.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNight_130.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNight_130.Location = new Point(278, 160);
            txtNight_130.Margin = new Padding(0, 0, 4, 8);
            txtNight_130.Name = "txtNight_130";
            txtNight_130.ReadOnly = true;
            txtNight_130.Size = new Size(100, 26);
            txtNight_130.TabIndex = 37;
            txtNight_130.TabStop = false;
            txtNight_130.TextAlign = HorizontalAlignment.Right;
            // 
            // label26
            // 
            label26.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label26.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label26.Location = new Point(11, 29);
            label26.Margin = new Padding(0, 0, 0, 4);
            label26.Name = "label26";
            label26.Size = new Size(262, 16);
            label26.TabIndex = 25;
            label26.Text = "Night Differential (10%) :";
            label26.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label46
            // 
            label46.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label46.AutoSize = true;
            label46.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label46.ForeColor = SystemColors.GrayText;
            label46.Location = new Point(382, 29);
            label46.Margin = new Padding(0, 0, 0, 4);
            label46.Name = "label46";
            label46.Size = new Size(49, 16);
            label46.TabIndex = 58;
            label46.Text = "hh:mm";
            // 
            // txtNight_150
            // 
            txtNight_150.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNight_150.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNight_150.Location = new Point(278, 194);
            txtNight_150.Margin = new Padding(0, 0, 4, 8);
            txtNight_150.Name = "txtNight_150";
            txtNight_150.ReadOnly = true;
            txtNight_150.Size = new Size(100, 26);
            txtNight_150.TabIndex = 38;
            txtNight_150.TabStop = false;
            txtNight_150.TextAlign = HorizontalAlignment.Right;
            // 
            // label20
            // 
            label20.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label20.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label20.Location = new Point(11, 97);
            label20.Margin = new Padding(0, 0, 0, 4);
            label20.Name = "label20";
            label20.Size = new Size(262, 16);
            label20.TabIndex = 40;
            label20.Text = "Night Differential (50%) :";
            label20.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            label22.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label22.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label22.Location = new Point(11, 165);
            label22.Margin = new Padding(0, 0, 0, 4);
            label22.Name = "label22";
            label22.Size = new Size(262, 16);
            label22.TabIndex = 42;
            label22.Text = "Night Differential (130%) :";
            label22.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            label19.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label19.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label19.Location = new Point(11, 131);
            label19.Margin = new Padding(0, 0, 0, 4);
            label19.Name = "label19";
            label19.Size = new Size(262, 16);
            label19.TabIndex = 41;
            label19.Text = "Night Differential (125%) :";
            label19.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            label18.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label18.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label18.Location = new Point(11, 63);
            label18.Margin = new Padding(0, 0, 0, 4);
            label18.Name = "label18";
            label18.Size = new Size(262, 16);
            label18.TabIndex = 39;
            label18.Text = "Night Differential (20%) :";
            label18.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dgvAdjustmentSummary
            // 
            dgvAdjustmentSummary.AllowUserToAddRows = false;
            dgvAdjustmentSummary.AllowUserToDeleteRows = false;
            dgvAdjustmentSummary.AllowUserToOrderColumns = true;
            dgvAdjustmentSummary.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.SelectionBackColor = Color.SeaGreen;
            dgvAdjustmentSummary.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvAdjustmentSummary.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvAdjustmentSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvAdjustmentSummary.BackgroundColor = SystemColors.Window;
            dgvAdjustmentSummary.BorderStyle = BorderStyle.Fixed3D;
            dgvAdjustmentSummary.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAdjustmentSummary.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new Padding(0, 2, 0, 2);
            dataGridViewCellStyle2.SelectionBackColor = Color.MediumSeaGreen;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvAdjustmentSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvAdjustmentSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAdjustmentSummary.EditMode = DataGridViewEditMode.EditOnF2;
            dgvAdjustmentSummary.GridColor = SystemColors.Control;
            dgvAdjustmentSummary.Location = new Point(481, 373);
            dgvAdjustmentSummary.Margin = new Padding(0, 0, 0, 8);
            dgvAdjustmentSummary.MultiSelect = false;
            dgvAdjustmentSummary.Name = "dgvAdjustmentSummary";
            dgvAdjustmentSummary.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new Padding(4);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvAdjustmentSummary.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvAdjustmentSummary.RowHeadersVisible = false;
            dgvAdjustmentSummary.RowTemplate.DefaultCellStyle.Padding = new Padding(4, 8, 4, 8);
            dgvAdjustmentSummary.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgvAdjustmentSummary.RowTemplate.Height = 41;
            dgvAdjustmentSummary.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdjustmentSummary.Size = new Size(808, 273);
            dgvAdjustmentSummary.TabIndex = 59;
            dgvAdjustmentSummary.VirtualMode = true;
            // 
            // btnRemove
            // 
            btnRemove.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemove.AutoSize = true;
            btnRemove.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnRemove.Location = new Point(1214, 65);
            btnRemove.Margin = new Padding(0, 0, 0, 8);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(75, 28);
            btnRemove.TabIndex = 2;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemoveAdjustment_Click;
            // 
            // grpOvertime
            // 
            grpOvertime.Controls.Add(txtRegular_125);
            grpOvertime.Controls.Add(label7);
            grpOvertime.Controls.Add(label8);
            grpOvertime.Controls.Add(txtRestDaySpecialHoliday_130);
            grpOvertime.Controls.Add(label9);
            grpOvertime.Controls.Add(label11);
            grpOvertime.Controls.Add(label12);
            grpOvertime.Controls.Add(label13);
            grpOvertime.Controls.Add(label14);
            grpOvertime.Controls.Add(label15);
            grpOvertime.Controls.Add(label37);
            grpOvertime.Controls.Add(txtRestDay_150);
            grpOvertime.Controls.Add(label38);
            grpOvertime.Controls.Add(label39);
            grpOvertime.Controls.Add(label40);
            grpOvertime.Controls.Add(label35);
            grpOvertime.Controls.Add(txtRestDayExcess_169);
            grpOvertime.Controls.Add(label36);
            grpOvertime.Controls.Add(label47);
            grpOvertime.Controls.Add(label34);
            grpOvertime.Controls.Add(label48);
            grpOvertime.Controls.Add(label33);
            grpOvertime.Controls.Add(txtRenderedOvertimeHours);
            grpOvertime.Controls.Add(txtSpecialHolidayExcess_195);
            grpOvertime.Controls.Add(txtRegularHoliday_160);
            grpOvertime.Controls.Add(txtLegalHoliday_200);
            grpOvertime.Controls.Add(txtLegalHoliday_260);
            grpOvertime.Location = new Point(16, 337);
            grpOvertime.Margin = new Padding(0, 0, 17, 8);
            grpOvertime.Name = "grpOvertime";
            grpOvertime.Padding = new Padding(16, 8, 16, 8);
            grpOvertime.Size = new Size(448, 339);
            grpOvertime.TabIndex = 24;
            grpOvertime.TabStop = false;
            grpOvertime.Text = "Overtime Information";
            // 
            // txtRegular_125
            // 
            txtRegular_125.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtRegular_125.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtRegular_125.Location = new Point(278, 24);
            txtRegular_125.Margin = new Padding(0, 0, 4, 8);
            txtRegular_125.Name = "txtRegular_125";
            txtRegular_125.ReadOnly = true;
            txtRegular_125.Size = new Size(100, 26);
            txtRegular_125.TabIndex = 25;
            txtRegular_125.TabStop = false;
            txtRegular_125.TextAlign = HorizontalAlignment.Right;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(11, 29);
            label7.Margin = new Padding(0, 0, 0, 4);
            label7.Name = "label7";
            label7.Size = new Size(262, 16);
            label7.TabIndex = 25;
            label7.Text = "Regular (125%) :";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label8.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(11, 63);
            label8.Margin = new Padding(0, 0, 0, 4);
            label8.Name = "label8";
            label8.Size = new Size(262, 16);
            label8.TabIndex = 27;
            label8.Text = "Rest Day/Special Holiday (130%) :";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtRestDaySpecialHoliday_130
            // 
            txtRestDaySpecialHoliday_130.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtRestDaySpecialHoliday_130.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtRestDaySpecialHoliday_130.Location = new Point(278, 58);
            txtRestDaySpecialHoliday_130.Margin = new Padding(0, 0, 4, 8);
            txtRestDaySpecialHoliday_130.Name = "txtRestDaySpecialHoliday_130";
            txtRestDaySpecialHoliday_130.ReadOnly = true;
            txtRestDaySpecialHoliday_130.Size = new Size(100, 26);
            txtRestDaySpecialHoliday_130.TabIndex = 26;
            txtRestDaySpecialHoliday_130.TabStop = false;
            txtRestDaySpecialHoliday_130.TextAlign = HorizontalAlignment.Right;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label9.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(2, 131);
            label9.Margin = new Padding(0, 0, 0, 4);
            label9.Name = "label9";
            label9.Size = new Size(271, 16);
            label9.TabIndex = 28;
            label9.Text = "Rest Day/Special Holiday Excess (169%) :";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label11.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(11, 97);
            label11.Margin = new Padding(0, 0, 0, 4);
            label11.Name = "label11";
            label11.Size = new Size(262, 16);
            label11.TabIndex = 30;
            label11.Text = "Rest Day Special Holiday (150%) :";
            label11.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label12.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(11, 165);
            label12.Margin = new Padding(0, 0, 0, 4);
            label12.Name = "label12";
            label12.Size = new Size(262, 16);
            label12.TabIndex = 31;
            label12.Text = "Special Holiday Excess (195%) :";
            label12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label13.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(11, 199);
            label13.Margin = new Padding(0, 0, 0, 4);
            label13.Name = "label13";
            label13.Size = new Size(262, 16);
            label13.TabIndex = 32;
            label13.Text = "Legal Holiday (200%) :";
            label13.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label14.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(11, 233);
            label14.Margin = new Padding(0, 0, 0, 4);
            label14.Name = "label14";
            label14.Size = new Size(262, 16);
            label14.TabIndex = 33;
            label14.Text = "Legal Holiday (260%) :";
            label14.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label15.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(11, 267);
            label15.Margin = new Padding(0, 0, 0, 4);
            label15.Name = "label15";
            label15.Size = new Size(262, 16);
            label15.TabIndex = 34;
            label15.Text = "Regular Holiday (160%) :";
            label15.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label37
            // 
            label37.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label37.AutoSize = true;
            label37.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label37.ForeColor = SystemColors.GrayText;
            label37.Location = new Point(382, 267);
            label37.Margin = new Padding(0, 0, 0, 4);
            label37.Name = "label37";
            label37.Size = new Size(49, 16);
            label37.TabIndex = 57;
            label37.Text = "hh:mm";
            // 
            // txtRestDay_150
            // 
            txtRestDay_150.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtRestDay_150.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtRestDay_150.Location = new Point(278, 92);
            txtRestDay_150.Margin = new Padding(0, 0, 4, 8);
            txtRestDay_150.Name = "txtRestDay_150";
            txtRestDay_150.ReadOnly = true;
            txtRestDay_150.Size = new Size(100, 26);
            txtRestDay_150.TabIndex = 35;
            txtRestDay_150.TabStop = false;
            txtRestDay_150.TextAlign = HorizontalAlignment.Right;
            // 
            // label38
            // 
            label38.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label38.AutoSize = true;
            label38.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label38.ForeColor = SystemColors.GrayText;
            label38.Location = new Point(382, 233);
            label38.Margin = new Padding(0, 0, 0, 4);
            label38.Name = "label38";
            label38.Size = new Size(49, 16);
            label38.TabIndex = 56;
            label38.Text = "hh:mm";
            // 
            // label39
            // 
            label39.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label39.AutoSize = true;
            label39.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label39.ForeColor = SystemColors.GrayText;
            label39.Location = new Point(382, 199);
            label39.Margin = new Padding(0, 0, 0, 4);
            label39.Name = "label39";
            label39.Size = new Size(49, 16);
            label39.TabIndex = 55;
            label39.Text = "hh:mm";
            // 
            // label40
            // 
            label40.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label40.AutoSize = true;
            label40.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label40.ForeColor = SystemColors.GrayText;
            label40.Location = new Point(382, 165);
            label40.Margin = new Padding(0, 0, 0, 4);
            label40.Name = "label40";
            label40.Size = new Size(49, 16);
            label40.TabIndex = 54;
            label40.Text = "hh:mm";
            // 
            // label35
            // 
            label35.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label35.AutoSize = true;
            label35.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label35.ForeColor = SystemColors.GrayText;
            label35.Location = new Point(382, 131);
            label35.Margin = new Padding(0, 0, 0, 4);
            label35.Name = "label35";
            label35.Size = new Size(49, 16);
            label35.TabIndex = 53;
            label35.Text = "hh:mm";
            // 
            // txtRestDayExcess_169
            // 
            txtRestDayExcess_169.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtRestDayExcess_169.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtRestDayExcess_169.Location = new Point(278, 126);
            txtRestDayExcess_169.Margin = new Padding(0, 0, 4, 8);
            txtRestDayExcess_169.Name = "txtRestDayExcess_169";
            txtRestDayExcess_169.ReadOnly = true;
            txtRestDayExcess_169.Size = new Size(100, 26);
            txtRestDayExcess_169.TabIndex = 36;
            txtRestDayExcess_169.TabStop = false;
            txtRestDayExcess_169.TextAlign = HorizontalAlignment.Right;
            // 
            // label36
            // 
            label36.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label36.AutoSize = true;
            label36.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label36.ForeColor = SystemColors.GrayText;
            label36.Location = new Point(382, 97);
            label36.Margin = new Padding(0, 0, 0, 4);
            label36.Name = "label36";
            label36.Size = new Size(49, 16);
            label36.TabIndex = 52;
            label36.Text = "hh:mm";
            // 
            // label47
            // 
            label47.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label47.AutoSize = true;
            label47.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label47.ForeColor = SystemColors.GrayText;
            label47.Location = new Point(382, 301);
            label47.Margin = new Padding(0, 0, 0, 4);
            label47.Name = "label47";
            label47.Size = new Size(49, 16);
            label47.TabIndex = 67;
            label47.Text = "hh:mm";
            // 
            // label34
            // 
            label34.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label34.AutoSize = true;
            label34.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label34.ForeColor = SystemColors.GrayText;
            label34.Location = new Point(382, 63);
            label34.Margin = new Padding(0, 0, 0, 4);
            label34.Name = "label34";
            label34.Size = new Size(49, 16);
            label34.TabIndex = 51;
            label34.Text = "hh:mm";
            // 
            // label48
            // 
            label48.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label48.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label48.Location = new Point(11, 301);
            label48.Margin = new Padding(0, 0, 0, 4);
            label48.Name = "label48";
            label48.Size = new Size(262, 16);
            label48.TabIndex = 65;
            label48.Text = "Total Overtime Hours Rendered :";
            label48.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label33
            // 
            label33.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label33.AutoSize = true;
            label33.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label33.ForeColor = SystemColors.GrayText;
            label33.Location = new Point(382, 29);
            label33.Margin = new Padding(0, 0, 0, 4);
            label33.Name = "label33";
            label33.Size = new Size(49, 16);
            label33.TabIndex = 50;
            label33.Text = "hh:mm";
            // 
            // txtRenderedOvertimeHours
            // 
            txtRenderedOvertimeHours.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtRenderedOvertimeHours.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtRenderedOvertimeHours.Location = new Point(278, 296);
            txtRenderedOvertimeHours.Margin = new Padding(0, 0, 4, 24);
            txtRenderedOvertimeHours.Name = "txtRenderedOvertimeHours";
            txtRenderedOvertimeHours.ReadOnly = true;
            txtRenderedOvertimeHours.Size = new Size(100, 26);
            txtRenderedOvertimeHours.TabIndex = 66;
            txtRenderedOvertimeHours.TabStop = false;
            txtRenderedOvertimeHours.TextAlign = HorizontalAlignment.Right;
            // 
            // txtSpecialHolidayExcess_195
            // 
            txtSpecialHolidayExcess_195.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSpecialHolidayExcess_195.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtSpecialHolidayExcess_195.Location = new Point(278, 160);
            txtSpecialHolidayExcess_195.Margin = new Padding(0, 0, 4, 8);
            txtSpecialHolidayExcess_195.Name = "txtSpecialHolidayExcess_195";
            txtSpecialHolidayExcess_195.ReadOnly = true;
            txtSpecialHolidayExcess_195.Size = new Size(100, 26);
            txtSpecialHolidayExcess_195.TabIndex = 38;
            txtSpecialHolidayExcess_195.TabStop = false;
            txtSpecialHolidayExcess_195.TextAlign = HorizontalAlignment.Right;
            // 
            // txtRegularHoliday_160
            // 
            txtRegularHoliday_160.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtRegularHoliday_160.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtRegularHoliday_160.Location = new Point(278, 262);
            txtRegularHoliday_160.Margin = new Padding(0, 0, 4, 8);
            txtRegularHoliday_160.Name = "txtRegularHoliday_160";
            txtRegularHoliday_160.ReadOnly = true;
            txtRegularHoliday_160.Size = new Size(100, 26);
            txtRegularHoliday_160.TabIndex = 41;
            txtRegularHoliday_160.TabStop = false;
            txtRegularHoliday_160.TextAlign = HorizontalAlignment.Right;
            // 
            // txtLegalHoliday_200
            // 
            txtLegalHoliday_200.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtLegalHoliday_200.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtLegalHoliday_200.Location = new Point(278, 194);
            txtLegalHoliday_200.Margin = new Padding(0, 0, 4, 8);
            txtLegalHoliday_200.Name = "txtLegalHoliday_200";
            txtLegalHoliday_200.ReadOnly = true;
            txtLegalHoliday_200.Size = new Size(100, 26);
            txtLegalHoliday_200.TabIndex = 39;
            txtLegalHoliday_200.TabStop = false;
            txtLegalHoliday_200.TextAlign = HorizontalAlignment.Right;
            // 
            // txtLegalHoliday_260
            // 
            txtLegalHoliday_260.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtLegalHoliday_260.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtLegalHoliday_260.Location = new Point(278, 228);
            txtLegalHoliday_260.Margin = new Padding(0, 0, 4, 8);
            txtLegalHoliday_260.Name = "txtLegalHoliday_260";
            txtLegalHoliday_260.ReadOnly = true;
            txtLegalHoliday_260.Size = new Size(100, 26);
            txtLegalHoliday_260.TabIndex = 40;
            txtLegalHoliday_260.TabStop = false;
            txtLegalHoliday_260.TextAlign = HorizontalAlignment.Right;
            // 
            // grpRemarks
            // 
            grpRemarks.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpRemarks.Controls.Add(label49);
            grpRemarks.Controls.Add(label50);
            grpRemarks.Controls.Add(btnClearBookmark);
            grpRemarks.Controls.Add(btnApplyBookmark);
            grpRemarks.Controls.Add(txtBookmarkReason);
            grpRemarks.Controls.Add(label32);
            grpRemarks.Controls.Add(btnClearRemarks);
            grpRemarks.Controls.Add(btnApplyRemarks);
            grpRemarks.Controls.Add(label30);
            grpRemarks.Controls.Add(txtTimekeepRemarks);
            grpRemarks.Controls.Add(txtCustomRemarks);
            grpRemarks.Controls.Add(lblCustomRemarks);
            grpRemarks.Location = new Point(481, 654);
            grpRemarks.Margin = new Padding(0, 0, 0, 8);
            grpRemarks.Name = "grpRemarks";
            grpRemarks.Padding = new Padding(16, 8, 1, 8);
            grpRemarks.Size = new Size(808, 201);
            grpRemarks.TabIndex = 57;
            grpRemarks.TabStop = false;
            grpRemarks.Text = "Remarks";
            // 
            // label49
            // 
            label49.AutoSize = true;
            label49.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label49.ForeColor = SystemColors.GrayText;
            label49.Location = new Point(140, 132);
            label49.Margin = new Padding(0, 0, 0, 4);
            label49.Name = "label49";
            label49.Size = new Size(425, 16);
            label49.TabIndex = 64;
            label49.Text = "(Sets the employee name text color to red in the left-side page list)";
            label49.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label50
            // 
            label50.AutoSize = true;
            label50.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label50.Location = new Point(20, 132);
            label50.Margin = new Padding(0, 0, 0, 4);
            label50.Name = "label50";
            label50.Size = new Size(123, 16);
            label50.TabIndex = 63;
            label50.Text = "Bookmark Reason";
            label50.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnClearBookmark
            // 
            btnClearBookmark.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClearBookmark.AutoSize = true;
            btnClearBookmark.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnClearBookmark.Location = new Point(713, 151);
            btnClearBookmark.Margin = new Padding(0, 0, 0, 16);
            btnClearBookmark.Name = "btnClearBookmark";
            btnClearBookmark.Size = new Size(75, 28);
            btnClearBookmark.TabIndex = 8;
            btnClearBookmark.Text = "Clear";
            btnClearBookmark.UseVisualStyleBackColor = true;
            btnClearBookmark.Click += btnClearBookmark_Click;
            // 
            // btnApplyBookmark
            // 
            btnApplyBookmark.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnApplyBookmark.AutoSize = true;
            btnApplyBookmark.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnApplyBookmark.Location = new Point(630, 151);
            btnApplyBookmark.Margin = new Padding(0, 0, 8, 16);
            btnApplyBookmark.Name = "btnApplyBookmark";
            btnApplyBookmark.Size = new Size(75, 28);
            btnApplyBookmark.TabIndex = 7;
            btnApplyBookmark.Text = "Apply";
            btnApplyBookmark.UseVisualStyleBackColor = true;
            btnApplyBookmark.Click += btnApplyBookmark_Click;
            // 
            // txtBookmarkReason
            // 
            txtBookmarkReason.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBookmarkReason.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtBookmarkReason.Location = new Point(20, 152);
            txtBookmarkReason.Margin = new Padding(0, 0, 8, 8);
            txtBookmarkReason.Name = "txtBookmarkReason";
            txtBookmarkReason.Size = new Size(602, 26);
            txtBookmarkReason.TabIndex = 6;
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label32.ForeColor = SystemColors.GrayText;
            label32.Location = new Point(113, 78);
            label32.Margin = new Padding(0, 0, 0, 4);
            label32.Name = "label32";
            label32.Size = new Size(435, 16);
            label32.TabIndex = 58;
            label32.Text = "(Appears next to the employee name in the final department report.)";
            label32.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnClearRemarks
            // 
            btnClearRemarks.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClearRemarks.AutoSize = true;
            btnClearRemarks.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnClearRemarks.Location = new Point(713, 97);
            btnClearRemarks.Margin = new Padding(0, 0, 0, 16);
            btnClearRemarks.Name = "btnClearRemarks";
            btnClearRemarks.Size = new Size(75, 28);
            btnClearRemarks.TabIndex = 5;
            btnClearRemarks.Text = "Clear";
            btnClearRemarks.UseVisualStyleBackColor = true;
            btnClearRemarks.Click += btnClearRemarks_Click;
            // 
            // btnApplyRemarks
            // 
            btnApplyRemarks.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnApplyRemarks.AutoSize = true;
            btnApplyRemarks.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnApplyRemarks.Location = new Point(630, 97);
            btnApplyRemarks.Margin = new Padding(0, 0, 8, 16);
            btnApplyRemarks.Name = "btnApplyRemarks";
            btnApplyRemarks.Size = new Size(75, 28);
            btnApplyRemarks.TabIndex = 4;
            btnApplyRemarks.Text = "Apply";
            btnApplyRemarks.UseVisualStyleBackColor = true;
            btnApplyRemarks.Click += btnApplyRemarks_Click;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label30.Location = new Point(20, 24);
            label30.Margin = new Padding(0, 0, 0, 4);
            label30.Name = "label30";
            label30.Size = new Size(147, 16);
            label30.TabIndex = 50;
            label30.Text = "Timekeeping Remarks";
            label30.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtTimekeepRemarks
            // 
            txtTimekeepRemarks.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTimekeepRemarks.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtTimekeepRemarks.Location = new Point(20, 44);
            txtTimekeepRemarks.Margin = new Padding(0, 0, 0, 8);
            txtTimekeepRemarks.Name = "txtTimekeepRemarks";
            txtTimekeepRemarks.ReadOnly = true;
            txtTimekeepRemarks.Size = new Size(768, 26);
            txtTimekeepRemarks.TabIndex = 50;
            txtTimekeepRemarks.TabStop = false;
            // 
            // txtCustomRemarks
            // 
            txtCustomRemarks.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCustomRemarks.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCustomRemarks.Location = new Point(20, 98);
            txtCustomRemarks.Margin = new Padding(0, 0, 8, 8);
            txtCustomRemarks.MaxLength = 255;
            txtCustomRemarks.Name = "txtCustomRemarks";
            txtCustomRemarks.Size = new Size(602, 26);
            txtCustomRemarks.TabIndex = 3;
            // 
            // lblCustomRemarks
            // 
            lblCustomRemarks.AutoSize = true;
            lblCustomRemarks.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblCustomRemarks.Location = new Point(20, 78);
            lblCustomRemarks.Margin = new Padding(0, 0, 0, 4);
            lblCustomRemarks.Name = "lblCustomRemarks";
            lblCustomRemarks.Size = new Size(96, 16);
            lblCustomRemarks.TabIndex = 55;
            lblCustomRemarks.Text = "Your Remarks";
            lblCustomRemarks.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dgvAdjustments
            // 
            dgvAdjustments.AllowUserToAddRows = false;
            dgvAdjustments.AllowUserToDeleteRows = false;
            dgvAdjustments.AllowUserToOrderColumns = true;
            dgvAdjustments.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.SelectionBackColor = Color.SeaGreen;
            dgvAdjustments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvAdjustments.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvAdjustments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvAdjustments.BackgroundColor = SystemColors.Window;
            dgvAdjustments.BorderStyle = BorderStyle.Fixed3D;
            dgvAdjustments.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAdjustments.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.Padding = new Padding(0, 2, 0, 2);
            dataGridViewCellStyle5.SelectionBackColor = Color.MediumSeaGreen;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvAdjustments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvAdjustments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAdjustments.EditMode = DataGridViewEditMode.EditOnF2;
            dgvAdjustments.GridColor = SystemColors.Control;
            dgvAdjustments.Location = new Point(481, 104);
            dgvAdjustments.Margin = new Padding(0);
            dgvAdjustments.MultiSelect = false;
            dgvAdjustments.Name = "dgvAdjustments";
            dgvAdjustments.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.Padding = new Padding(4);
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvAdjustments.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvAdjustments.RowHeadersVisible = false;
            dgvAdjustments.RowTemplate.DefaultCellStyle.Padding = new Padding(4, 8, 4, 8);
            dgvAdjustments.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgvAdjustments.RowTemplate.Height = 41;
            dgvAdjustments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdjustments.Size = new Size(808, 273);
            dgvAdjustments.TabIndex = 52;
            dgvAdjustments.VirtualMode = true;
            dgvAdjustments.CellContentClick += dgvAdjustments_CellContentClick;
            // 
            // grpBasicInformation
            // 
            grpBasicInformation.Controls.Add(label31);
            grpBasicInformation.Controls.Add(txtRegularInDays);
            grpBasicInformation.Controls.Add(txtUndertime);
            grpBasicInformation.Controls.Add(label28);
            grpBasicInformation.Controls.Add(label24);
            grpBasicInformation.Controls.Add(label17);
            grpBasicInformation.Controls.Add(label27);
            grpBasicInformation.Controls.Add(txtLegalHolidayDays_100);
            grpBasicInformation.Controls.Add(label23);
            grpBasicInformation.Controls.Add(txtLegalHolidayHours_100);
            grpBasicInformation.Controls.Add(label3);
            grpBasicInformation.Controls.Add(txtRenderedRegularHours);
            grpBasicInformation.Controls.Add(label2);
            grpBasicInformation.Controls.Add(txtTotalRegularHours);
            grpBasicInformation.Controls.Add(label4);
            grpBasicInformation.Controls.Add(label5);
            grpBasicInformation.Controls.Add(label1);
            grpBasicInformation.Controls.Add(label6);
            grpBasicInformation.Location = new Point(16, 92);
            grpBasicInformation.Margin = new Padding(0, 0, 17, 8);
            grpBasicInformation.Name = "grpBasicInformation";
            grpBasicInformation.Padding = new Padding(16, 8, 16, 8);
            grpBasicInformation.Size = new Size(448, 237);
            grpBasicInformation.TabIndex = 51;
            grpBasicInformation.TabStop = false;
            grpBasicInformation.Text = "Regular Time Information";
            // 
            // label31
            // 
            label31.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label31.AutoSize = true;
            label31.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label31.ForeColor = SystemColors.GrayText;
            label31.Location = new Point(381, 199);
            label31.Margin = new Padding(0, 0, 0, 4);
            label31.Name = "label31";
            label31.Size = new Size(49, 16);
            label31.TabIndex = 64;
            label31.Text = "hh:mm";
            // 
            // txtRegularInDays
            // 
            txtRegularInDays.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtRegularInDays.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtRegularInDays.Location = new Point(277, 24);
            txtRegularInDays.Margin = new Padding(0, 0, 4, 8);
            txtRegularInDays.Name = "txtRegularInDays";
            txtRegularInDays.ReadOnly = true;
            txtRegularInDays.Size = new Size(100, 26);
            txtRegularInDays.TabIndex = 16;
            txtRegularInDays.TabStop = false;
            txtRegularInDays.TextAlign = HorizontalAlignment.Right;
            // 
            // txtUndertime
            // 
            txtUndertime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtUndertime.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtUndertime.Location = new Point(277, 92);
            txtUndertime.Margin = new Padding(0, 0, 4, 8);
            txtUndertime.Name = "txtUndertime";
            txtUndertime.ReadOnly = true;
            txtUndertime.Size = new Size(100, 26);
            txtUndertime.TabIndex = 18;
            txtUndertime.TabStop = false;
            txtUndertime.TextAlign = HorizontalAlignment.Right;
            // 
            // label28
            // 
            label28.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label28.AutoSize = true;
            label28.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label28.ForeColor = SystemColors.GrayText;
            label28.Location = new Point(381, 63);
            label28.Margin = new Padding(0, 0, 0, 4);
            label28.Name = "label28";
            label28.Size = new Size(53, 16);
            label28.TabIndex = 49;
            label28.Text = "hour(s)";
            // 
            // label24
            // 
            label24.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label24.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label24.Location = new Point(10, 165);
            label24.Margin = new Padding(0, 0, 0, 4);
            label24.Name = "label24";
            label24.Size = new Size(262, 16);
            label24.TabIndex = 43;
            label24.Text = "Legal Holiday (100%) :";
            label24.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            label17.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label17.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label17.Location = new Point(10, 199);
            label17.Margin = new Padding(0, 0, 0, 4);
            label17.Name = "label17";
            label17.Size = new Size(262, 16);
            label17.TabIndex = 25;
            label17.Text = "Total Regular Hours Rendered :";
            label17.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label27
            // 
            label27.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label27.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label27.Location = new Point(10, 63);
            label27.Margin = new Padding(0, 0, 0, 4);
            label27.Name = "label27";
            label27.Size = new Size(262, 16);
            label27.TabIndex = 46;
            label27.Text = "Total of Regular Hours :";
            label27.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtLegalHolidayDays_100
            // 
            txtLegalHolidayDays_100.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtLegalHolidayDays_100.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtLegalHolidayDays_100.Location = new Point(277, 126);
            txtLegalHolidayDays_100.Margin = new Padding(0, 0, 4, 8);
            txtLegalHolidayDays_100.Name = "txtLegalHolidayDays_100";
            txtLegalHolidayDays_100.ReadOnly = true;
            txtLegalHolidayDays_100.Size = new Size(100, 26);
            txtLegalHolidayDays_100.TabIndex = 20;
            txtLegalHolidayDays_100.TabStop = false;
            txtLegalHolidayDays_100.TextAlign = HorizontalAlignment.Right;
            // 
            // label23
            // 
            label23.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label23.AutoSize = true;
            label23.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label23.ForeColor = SystemColors.GrayText;
            label23.Location = new Point(381, 165);
            label23.Margin = new Padding(0, 0, 0, 4);
            label23.Name = "label23";
            label23.Size = new Size(53, 16);
            label23.TabIndex = 45;
            label23.Text = "hour(s)";
            // 
            // txtLegalHolidayHours_100
            // 
            txtLegalHolidayHours_100.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtLegalHolidayHours_100.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtLegalHolidayHours_100.Location = new Point(277, 160);
            txtLegalHolidayHours_100.Margin = new Padding(0, 0, 4, 8);
            txtLegalHolidayHours_100.Name = "txtLegalHolidayHours_100";
            txtLegalHolidayHours_100.ReadOnly = true;
            txtLegalHolidayHours_100.Size = new Size(100, 26);
            txtLegalHolidayHours_100.TabIndex = 44;
            txtLegalHolidayHours_100.TabStop = false;
            txtLegalHolidayHours_100.TextAlign = HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(10, 131);
            label3.Margin = new Padding(0, 0, 0, 4);
            label3.Name = "label3";
            label3.Size = new Size(262, 16);
            label3.TabIndex = 19;
            label3.Text = "Legal Holiday (100%) :";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtRenderedRegularHours
            // 
            txtRenderedRegularHours.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtRenderedRegularHours.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtRenderedRegularHours.Location = new Point(277, 194);
            txtRenderedRegularHours.Margin = new Padding(0, 0, 4, 24);
            txtRenderedRegularHours.Name = "txtRenderedRegularHours";
            txtRenderedRegularHours.ReadOnly = true;
            txtRenderedRegularHours.Size = new Size(100, 26);
            txtRenderedRegularHours.TabIndex = 26;
            txtRenderedRegularHours.TabStop = false;
            txtRenderedRegularHours.TextAlign = HorizontalAlignment.Right;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(10, 97);
            label2.Margin = new Padding(0, 0, 0, 4);
            label2.Name = "label2";
            label2.Size = new Size(262, 16);
            label2.TabIndex = 17;
            label2.Text = "Undertime :";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtTotalRegularHours
            // 
            txtTotalRegularHours.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTotalRegularHours.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtTotalRegularHours.Location = new Point(277, 58);
            txtTotalRegularHours.Margin = new Padding(0, 0, 4, 8);
            txtTotalRegularHours.Name = "txtTotalRegularHours";
            txtTotalRegularHours.ReadOnly = true;
            txtTotalRegularHours.Size = new Size(100, 26);
            txtTotalRegularHours.TabIndex = 47;
            txtTotalRegularHours.TabStop = false;
            txtTotalRegularHours.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.GrayText;
            label4.Location = new Point(381, 30);
            label4.Margin = new Padding(0, 0, 0, 4);
            label4.Name = "label4";
            label4.Size = new Size(47, 16);
            label4.TabIndex = 21;
            label4.Text = "day(s)";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.GrayText;
            label5.Location = new Point(381, 97);
            label5.Margin = new Padding(0, 0, 0, 4);
            label5.Name = "label5";
            label5.Size = new Size(66, 16);
            label5.TabIndex = 22;
            label5.Text = "minute(s)";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(10, 29);
            label1.Margin = new Padding(0, 0, 0, 4);
            label1.Name = "label1";
            label1.Size = new Size(262, 16);
            label1.TabIndex = 15;
            label1.Text = "Total Days Rendered :";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.GrayText;
            label6.Location = new Point(381, 131);
            label6.Margin = new Padding(0, 0, 0, 4);
            label6.Name = "label6";
            label6.Size = new Size(47, 16);
            label6.TabIndex = 23;
            label6.Text = "day(s)";
            // 
            // btnAddAdjustment
            // 
            btnAddAdjustment.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddAdjustment.AutoSize = true;
            btnAddAdjustment.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddAdjustment.Location = new Point(1091, 65);
            btnAddAdjustment.Margin = new Padding(0, 0, 8, 8);
            btnAddAdjustment.Name = "btnAddAdjustment";
            btnAddAdjustment.Size = new Size(115, 28);
            btnAddAdjustment.TabIndex = 1;
            btnAddAdjustment.Text = "Add Adjustment";
            btnAddAdjustment.UseVisualStyleBackColor = true;
            btnAddAdjustment.Click += btnAddAdjustment_Click;
            // 
            // lblEmployeeInformation
            // 
            lblEmployeeInformation.AutoSize = true;
            lblEmployeeInformation.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblEmployeeInformation.Location = new Point(16, 60);
            lblEmployeeInformation.Margin = new Padding(0, 0, 0, 16);
            lblEmployeeInformation.Name = "lblEmployeeInformation";
            lblEmployeeInformation.Size = new Size(159, 16);
            lblEmployeeInformation.TabIndex = 14;
            lblEmployeeInformation.Text = "Employee Information";
            // 
            // pnlLine2
            // 
            pnlLine2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLine2.BorderStyle = BorderStyle.FixedSingle;
            pnlLine2.Location = new Point(16, 43);
            pnlLine2.Margin = new Padding(0, 0, 0, 16);
            pnlLine2.Name = "pnlLine2";
            pnlLine2.Size = new Size(1273, 1);
            pnlLine2.TabIndex = 3;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(16, 16);
            lblTitle.Margin = new Padding(0, 0, 0, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(172, 19);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Timekeep Verification";
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.White;
            pnlLeft.Controls.Add(pnlLeftBody);
            pnlLeft.Controls.Add(pnlLeftHeader);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 1);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(302, 983);
            pnlLeft.TabIndex = 43;
            // 
            // pnlLeftBody
            // 
            pnlLeftBody.AutoScroll = true;
            pnlLeftBody.Controls.Add(flowLeftEmployeeList);
            pnlLeftBody.Dock = DockStyle.Fill;
            pnlLeftBody.Location = new Point(0, 176);
            pnlLeftBody.Name = "pnlLeftBody";
            pnlLeftBody.Size = new Size(302, 807);
            pnlLeftBody.TabIndex = 1;
            // 
            // flowLeftEmployeeList
            // 
            flowLeftEmployeeList.AutoSize = true;
            flowLeftEmployeeList.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLeftEmployeeList.FlowDirection = FlowDirection.TopDown;
            flowLeftEmployeeList.Location = new Point(0, 0);
            flowLeftEmployeeList.Margin = new Padding(0);
            flowLeftEmployeeList.Name = "flowLeftEmployeeList";
            flowLeftEmployeeList.Padding = new Padding(16, 4, 0, 0);
            flowLeftEmployeeList.Size = new Size(16, 4);
            flowLeftEmployeeList.TabIndex = 0;
            // 
            // pnlLeftHeader
            // 
            pnlLeftHeader.Controls.Add(btnRemoveEntry);
            pnlLeftHeader.Controls.Add(btnInsertEntry);
            pnlLeftHeader.Controls.Add(btnSearch);
            pnlLeftHeader.Controls.Add(label10);
            pnlLeftHeader.Controls.Add(txtSearch);
            pnlLeftHeader.Controls.Add(cmbDepartment);
            pnlLeftHeader.Controls.Add(pnlLine3);
            pnlLeftHeader.Controls.Add(label29);
            pnlLeftHeader.Dock = DockStyle.Top;
            pnlLeftHeader.Location = new Point(0, 0);
            pnlLeftHeader.Name = "pnlLeftHeader";
            pnlLeftHeader.Padding = new Padding(16);
            pnlLeftHeader.Size = new Size(302, 176);
            pnlLeftHeader.TabIndex = 0;
            // 
            // btnRemoveEntry
            // 
            btnRemoveEntry.AutoSize = true;
            btnRemoveEntry.Enabled = false;
            btnRemoveEntry.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnRemoveEntry.Location = new Point(206, 130);
            btnRemoveEntry.Margin = new Padding(8, 0, 0, 0);
            btnRemoveEntry.Name = "btnRemoveEntry";
            btnRemoveEntry.Size = new Size(80, 28);
            btnRemoveEntry.TabIndex = 21;
            btnRemoveEntry.Text = "Remove";
            btnRemoveEntry.UseVisualStyleBackColor = true;
            btnRemoveEntry.Click += btnRemoveEntry_Click;
            // 
            // btnInsertEntry
            // 
            btnInsertEntry.AutoSize = true;
            btnInsertEntry.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnInsertEntry.Location = new Point(16, 130);
            btnInsertEntry.Margin = new Padding(0);
            btnInsertEntry.Name = "btnInsertEntry";
            btnInsertEntry.Size = new Size(182, 28);
            btnInsertEntry.TabIndex = 20;
            btnInsertEntry.Text = "Insert Custom Entry";
            btnInsertEntry.UseVisualStyleBackColor = true;
            btnInsertEntry.Click += btnInsertEntry_Click;
            // 
            // btnSearch
            // 
            btnSearch.AutoSize = true;
            btnSearch.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearch.Location = new Point(206, 87);
            btnSearch.Margin = new Padding(8, 0, 0, 0);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(80, 28);
            btnSearch.TabIndex = 19;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(16, 68);
            label10.Margin = new Padding(0, 0, 0, 4);
            label10.Name = "label10";
            label10.Size = new Size(52, 16);
            label10.TabIndex = 18;
            label10.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(16, 88);
            txtSearch.Margin = new Padding(0, 0, 0, 16);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(182, 26);
            txtSearch.TabIndex = 14;
            txtSearch.KeyUp += txtSearch_KeyUp;
            // 
            // cmbDepartment
            // 
            cmbDepartment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.Location = new Point(16, 36);
            cmbDepartment.Margin = new Padding(0, 0, 0, 8);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(270, 24);
            cmbDepartment.TabIndex = 13;
            cmbDepartment.SelectedIndexChanged += cmbDepartment_SelectedIndexChanged;
            // 
            // pnlLine3
            // 
            pnlLine3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlLine3.BorderStyle = BorderStyle.FixedSingle;
            pnlLine3.Location = new Point(16, 168);
            pnlLine3.Margin = new Padding(0, 0, 0, 16);
            pnlLine3.Name = "pnlLine3";
            pnlLine3.Size = new Size(270, 1);
            pnlLine3.TabIndex = 4;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label29.Location = new Point(16, 16);
            label29.Margin = new Padding(0, 0, 0, 4);
            label29.Name = "label29";
            label29.Size = new Size(88, 16);
            label29.TabIndex = 3;
            label29.Text = "Departments";
            // 
            // pnlVLine1
            // 
            pnlVLine1.BackColor = Color.White;
            pnlVLine1.BorderStyle = BorderStyle.FixedSingle;
            pnlVLine1.Dock = DockStyle.Left;
            pnlVLine1.Location = new Point(302, 1);
            pnlVLine1.Name = "pnlVLine1";
            pnlVLine1.Size = new Size(1, 983);
            pnlVLine1.TabIndex = 44;
            // 
            // EmployeeTimekeepReviewForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(1608, 984);
            Controls.Add(pnlBody);
            Controls.Add(pnlFooter);
            Controls.Add(pnlVLine1);
            Controls.Add(pnlLeft);
            Controls.Add(pnlLine1);
            Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EmployeeTimekeepReviewForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += EmployeeTimekeepReviewForm_FormClosing;
            Load += EmployeeTimekeepReviewForm_Load;
            pnlFooter.ResumeLayout(false);
            pnlFooter.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            grpExport.ResumeLayout(false);
            grpExport.PerformLayout();
            grpNightDifferential.ResumeLayout(false);
            grpNightDifferential.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAdjustmentSummary).EndInit();
            grpOvertime.ResumeLayout(false);
            grpOvertime.PerformLayout();
            grpRemarks.ResumeLayout(false);
            grpRemarks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAdjustments).EndInit();
            grpBasicInformation.ResumeLayout(false);
            grpBasicInformation.PerformLayout();
            pnlLeft.ResumeLayout(false);
            pnlLeftBody.ResumeLayout(false);
            pnlLeftBody.PerformLayout();
            pnlLeftHeader.ResumeLayout(false);
            pnlLeftHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLine1;
        private Panel pnlFooter;
        private Panel pnlBody;
        private Panel pnlLine2;
        private Label lblTitle;
        private Label lblEmployeeInformation;
        private Label label1;
        private TextBox txtTotalDays;
        private TextBox txtUndertime;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnNext;
        private Button btnPrevious;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox txtLegalHolidayDays_100;
        private Label label3;
        private Label lblEntryCounter;
        private GroupBox grpOvertime;
        private TextBox txtRegular_125;
        private Label label7;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label9;
        private TextBox txtRestDaySpecialHoliday_130;
        private Label label8;
        private TextBox txtRegularHoliday_160;
        private TextBox txtLegalHoliday_260;
        private TextBox txtLegalHoliday_200;
        private TextBox txtSpecialHolidayExcess_195;
        private TextBox txtSpecialHoliday_130;
        private TextBox txtRestDayExcess_169;
        private TextBox txtRestDay_130;
        private TextBox txtRenderedRegularHours;
        private Label label17;
        private TextBox txtNight_150;
        private TextBox txtNight_130;
        private TextBox txtNight_125;
        private TextBox txtNight_50;
        private TextBox txtNight_20;
        private TextBox txtNight_10;
        private Label label26;
        private Label label21;
        private Label label22;
        private Label label19;
        private Label label20;
        private Label label18;
        private Panel pnlLeft;
        private TextBox txtRestDay_150;
        private Label label23;
        private TextBox txtLegalHolidayHours_100;
        private Label label24;
        private TextBox txtSearch;
        private Label label27;
        private TextBox txtTotalRegularHours;
        private TextBox txtRegularInDays;
        private Label label28;
        private Panel pnlVLine1;
        private Panel pnlLeftHeader;
        private ComboBox cmbDepartment;
        private Panel pnlLine3;
        private Label label29;
        private Label label10;
        private Panel pnlLeftBody;
        private FlowLayoutPanel flowLeftEmployeeList;
        private GroupBox grpBasicInformation;
        private Button btnAddAdjustment;
        private DataGridView dgvAdjustments;
        private Button btnSave;
        private Button btnVerify;
        private TextBox txtCustomRemarks;
        private Label label31;
        private TextBox txtTimekeepRemarks;
        private Label label30;
        private GroupBox grpRemarks;
        private Label lblCustomRemarks;
        private Button btnRemove;
        private Button btnClearRemarks;
        private Button btnApplyRemarks;
        private Label label32;
        private Label label41;
        private Label label42;
        private Label label43;
        private Label label44;
        private Label label45;
        private Label label46;
        private Label label37;
        private Label label38;
        private Label label39;
        private Label label40;
        private Label label35;
        private Label label36;
        private Label label34;
        private Label label33;
        private Label label47;
        private Label label48;
        private TextBox txtRenderedOvertimeHours;
        private DataGridView dataGridView1;
        private Button btnClearBookmark;
        private Button btnApplyBookmark;
        private TextBox txtBookmarkReason;
        private CheckBox chkBookmark;
        private Label label49;
        private Label label50;
        private DataGridView dgvAdjustmentSummary;
        private GroupBox grpNightDifferential;
        private Button btnToExport;
        private Button btnVerifyBilling;
        private GroupBox grpExport;
        private Label label16;
        private RadioButton radNoExport;
        private RadioButton radYesExport;
        private Button btnSearch;
        private Button btnInsertEntry;
        private Button btnRemoveEntry;
    }
}