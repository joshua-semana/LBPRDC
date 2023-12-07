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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            pnlLine1 = new Panel();
            pnlFooter = new Panel();
            lblEntryCounter = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnNext = new Button();
            btnPrevious = new Button();
            btnSave = new Button();
            btnVerify = new Button();
            pnlBody = new Panel();
            btnRemove = new Button();
            grpRemarks = new GroupBox();
            label30 = new Label();
            txtTimekeepRemarks = new TextBox();
            txtCustomRemarks = new TextBox();
            lblCustomRemarks = new Label();
            label16 = new Label();
            dgvAdjustments = new DataGridView();
            grpBasicInformation = new GroupBox();
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
            txtTotalHours = new TextBox();
            label2 = new Label();
            txtTotalRegularHours = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label1 = new Label();
            label6 = new Label();
            btnAddAdjustment = new Button();
            label25 = new Label();
            grpNightDifferential = new GroupBox();
            label21 = new Label();
            label22 = new Label();
            label19 = new Label();
            label20 = new Label();
            label18 = new Label();
            txtNight_150 = new TextBox();
            txtNight_130 = new TextBox();
            txtNight_125 = new TextBox();
            txtNight_50 = new TextBox();
            txtNight_20 = new TextBox();
            txtNight_10 = new TextBox();
            label26 = new Label();
            grpOvertime = new GroupBox();
            txtRegularHoliday_160 = new TextBox();
            txtLegalHoliday_260 = new TextBox();
            txtLegalHoliday_200 = new TextBox();
            txtSpecialHolidayExcess_195 = new TextBox();
            txtRestDayExcess_169 = new TextBox();
            txtRestDay_150 = new TextBox();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label9 = new Label();
            txtRestDaySpecialHoliday_130 = new TextBox();
            label8 = new Label();
            txtRegular_125 = new TextBox();
            label7 = new Label();
            lblEmployeeInformation = new Label();
            pnlLine2 = new Panel();
            lblTitle = new Label();
            pnlLeft = new Panel();
            pnlLeftBody = new Panel();
            flowLeftEmployeeList = new FlowLayoutPanel();
            pnlLeftHeader = new Panel();
            label10 = new Label();
            txtSearch = new TextBox();
            cmbDepartment = new ComboBox();
            pnlLine3 = new Panel();
            label29 = new Label();
            pnlVLine1 = new Panel();
            btnApplyRemarks = new Button();
            btnClearRemarks = new Button();
            pnlFooter.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            pnlBody.SuspendLayout();
            grpRemarks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAdjustments).BeginInit();
            grpBasicInformation.SuspendLayout();
            grpNightDifferential.SuspendLayout();
            grpOvertime.SuspendLayout();
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
            pnlLine1.Size = new Size(1250, 1);
            pnlLine1.TabIndex = 0;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = SystemColors.Control;
            pnlFooter.Controls.Add(lblEntryCounter);
            pnlFooter.Controls.Add(flowLayoutPanel1);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(241, 815);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1009, 46);
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
            flowLayoutPanel1.Controls.Add(btnNext);
            flowLayoutPanel1.Controls.Add(btnPrevious);
            flowLayoutPanel1.Controls.Add(btnSave);
            flowLayoutPanel1.Controls.Add(btnVerify);
            flowLayoutPanel1.Dock = DockStyle.Right;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(643, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(16, 9, 0, 0);
            flowLayoutPanel1.Size = new Size(366, 46);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // btnNext
            // 
            btnNext.AutoSize = true;
            btnNext.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnNext.Location = new Point(275, 9);
            btnNext.Margin = new Padding(8, 0, 0, 0);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(75, 28);
            btnNext.TabIndex = 8;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.AutoSize = true;
            btnPrevious.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnPrevious.Location = new Point(192, 9);
            btnPrevious.Margin = new Padding(8, 0, 0, 0);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(75, 28);
            btnPrevious.TabIndex = 9;
            btnPrevious.Text = "Previous";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Location = new Point(109, 9);
            btnSave.Margin = new Padding(8, 0, 0, 0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 28);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnVerify
            // 
            btnVerify.AutoSize = true;
            btnVerify.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnVerify.Location = new Point(26, 9);
            btnVerify.Margin = new Padding(8, 0, 0, 0);
            btnVerify.Name = "btnVerify";
            btnVerify.Size = new Size(75, 28);
            btnVerify.TabIndex = 11;
            btnVerify.Text = "Verify";
            btnVerify.UseVisualStyleBackColor = true;
            btnVerify.Click += btnVerify_Click;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(btnRemove);
            pnlBody.Controls.Add(grpRemarks);
            pnlBody.Controls.Add(label16);
            pnlBody.Controls.Add(dgvAdjustments);
            pnlBody.Controls.Add(grpBasicInformation);
            pnlBody.Controls.Add(btnAddAdjustment);
            pnlBody.Controls.Add(label25);
            pnlBody.Controls.Add(grpNightDifferential);
            pnlBody.Controls.Add(grpOvertime);
            pnlBody.Controls.Add(lblEmployeeInformation);
            pnlBody.Controls.Add(pnlLine2);
            pnlBody.Controls.Add(lblTitle);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(241, 1);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(16);
            pnlBody.Size = new Size(1009, 814);
            pnlBody.TabIndex = 2;
            // 
            // btnRemove
            // 
            btnRemove.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemove.AutoSize = true;
            btnRemove.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnRemove.Location = new Point(918, 579);
            btnRemove.Margin = new Padding(0, 0, 0, 16);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(75, 28);
            btnRemove.TabIndex = 58;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // grpRemarks
            // 
            grpRemarks.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpRemarks.Controls.Add(btnClearRemarks);
            grpRemarks.Controls.Add(btnApplyRemarks);
            grpRemarks.Controls.Add(label30);
            grpRemarks.Controls.Add(txtTimekeepRemarks);
            grpRemarks.Controls.Add(txtCustomRemarks);
            grpRemarks.Controls.Add(lblCustomRemarks);
            grpRemarks.Location = new Point(16, 421);
            grpRemarks.Margin = new Padding(0, 0, 0, 16);
            grpRemarks.Name = "grpRemarks";
            grpRemarks.Padding = new Padding(16, 8, 1, 8);
            grpRemarks.Size = new Size(977, 148);
            grpRemarks.TabIndex = 57;
            grpRemarks.TabStop = false;
            grpRemarks.Text = "Remarks";
            // 
            // label30
            // 
            label30.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
            txtTimekeepRemarks.Size = new Size(937, 26);
            txtTimekeepRemarks.TabIndex = 50;
            // 
            // txtCustomRemarks
            // 
            txtCustomRemarks.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCustomRemarks.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCustomRemarks.Location = new Point(20, 98);
            txtCustomRemarks.Margin = new Padding(0, 0, 8, 16);
            txtCustomRemarks.Name = "txtCustomRemarks";
            txtCustomRemarks.Size = new Size(771, 26);
            txtCustomRemarks.TabIndex = 54;
            // 
            // lblCustomRemarks
            // 
            lblCustomRemarks.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label16.Location = new Point(16, 585);
            label16.Margin = new Padding(0, 0, 8, 16);
            label16.Name = "label16";
            label16.Size = new Size(94, 16);
            label16.TabIndex = 53;
            label16.Text = "Adjustments";
            // 
            // dgvAdjustments
            // 
            dgvAdjustments.AllowUserToAddRows = false;
            dgvAdjustments.AllowUserToDeleteRows = false;
            dgvAdjustments.AllowUserToOrderColumns = true;
            dgvAdjustments.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.SelectionBackColor = Color.SeaGreen;
            dgvAdjustments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvAdjustments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            dgvAdjustments.Location = new Point(16, 617);
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
            dgvAdjustments.Size = new Size(977, 181);
            dgvAdjustments.TabIndex = 52;
            dgvAdjustments.VirtualMode = true;
            // 
            // grpBasicInformation
            // 
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
            grpBasicInformation.Controls.Add(txtTotalHours);
            grpBasicInformation.Controls.Add(label2);
            grpBasicInformation.Controls.Add(txtTotalRegularHours);
            grpBasicInformation.Controls.Add(label4);
            grpBasicInformation.Controls.Add(label5);
            grpBasicInformation.Controls.Add(label1);
            grpBasicInformation.Controls.Add(label6);
            grpBasicInformation.Location = new Point(16, 92);
            grpBasicInformation.Margin = new Padding(0, 0, 8, 8);
            grpBasicInformation.Name = "grpBasicInformation";
            grpBasicInformation.Padding = new Padding(16);
            grpBasicInformation.Size = new Size(361, 318);
            grpBasicInformation.TabIndex = 51;
            grpBasicInformation.TabStop = false;
            grpBasicInformation.Text = "Basic Information";
            // 
            // txtRegularInDays
            // 
            txtRegularInDays.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtRegularInDays.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtRegularInDays.Location = new Point(181, 32);
            txtRegularInDays.Margin = new Padding(0, 0, 4, 8);
            txtRegularInDays.Name = "txtRegularInDays";
            txtRegularInDays.ReadOnly = true;
            txtRegularInDays.Size = new Size(100, 26);
            txtRegularInDays.TabIndex = 16;
            txtRegularInDays.TextAlign = HorizontalAlignment.Right;
            // 
            // txtUndertime
            // 
            txtUndertime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtUndertime.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtUndertime.Location = new Point(181, 100);
            txtUndertime.Margin = new Padding(0, 0, 4, 8);
            txtUndertime.Name = "txtUndertime";
            txtUndertime.ReadOnly = true;
            txtUndertime.Size = new Size(100, 26);
            txtUndertime.TabIndex = 18;
            txtUndertime.TextAlign = HorizontalAlignment.Right;
            // 
            // label28
            // 
            label28.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label28.AutoSize = true;
            label28.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label28.ForeColor = SystemColors.GrayText;
            label28.Location = new Point(285, 71);
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
            label24.Location = new Point(20, 173);
            label24.Margin = new Padding(0, 0, 0, 4);
            label24.Name = "label24";
            label24.Size = new Size(156, 16);
            label24.TabIndex = 43;
            label24.Text = "Legal Holiday (100%) :";
            label24.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            label17.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label17.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label17.Location = new Point(20, 207);
            label17.Margin = new Padding(0, 0, 0, 4);
            label17.Name = "label17";
            label17.Size = new Size(156, 16);
            label17.TabIndex = 25;
            label17.Text = "Total Hours Rendered :";
            label17.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label27
            // 
            label27.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label27.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label27.Location = new Point(20, 71);
            label27.Margin = new Padding(0, 0, 0, 4);
            label27.Name = "label27";
            label27.Size = new Size(156, 16);
            label27.TabIndex = 46;
            label27.Text = "Total of Regular Hours :";
            label27.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtLegalHolidayDays_100
            // 
            txtLegalHolidayDays_100.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtLegalHolidayDays_100.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtLegalHolidayDays_100.Location = new Point(181, 134);
            txtLegalHolidayDays_100.Margin = new Padding(0, 0, 4, 8);
            txtLegalHolidayDays_100.Name = "txtLegalHolidayDays_100";
            txtLegalHolidayDays_100.ReadOnly = true;
            txtLegalHolidayDays_100.Size = new Size(100, 26);
            txtLegalHolidayDays_100.TabIndex = 20;
            txtLegalHolidayDays_100.TextAlign = HorizontalAlignment.Right;
            // 
            // label23
            // 
            label23.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label23.AutoSize = true;
            label23.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label23.ForeColor = SystemColors.GrayText;
            label23.Location = new Point(285, 173);
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
            txtLegalHolidayHours_100.Location = new Point(181, 168);
            txtLegalHolidayHours_100.Margin = new Padding(0, 0, 4, 8);
            txtLegalHolidayHours_100.Name = "txtLegalHolidayHours_100";
            txtLegalHolidayHours_100.ReadOnly = true;
            txtLegalHolidayHours_100.Size = new Size(100, 26);
            txtLegalHolidayHours_100.TabIndex = 44;
            txtLegalHolidayHours_100.TextAlign = HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(20, 139);
            label3.Margin = new Padding(0, 0, 0, 4);
            label3.Name = "label3";
            label3.Size = new Size(156, 16);
            label3.TabIndex = 19;
            label3.Text = "Legal Holiday (100%) :";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtTotalHours
            // 
            txtTotalHours.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTotalHours.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtTotalHours.Location = new Point(181, 202);
            txtTotalHours.Margin = new Padding(0, 0, 4, 8);
            txtTotalHours.Name = "txtTotalHours";
            txtTotalHours.ReadOnly = true;
            txtTotalHours.Size = new Size(100, 26);
            txtTotalHours.TabIndex = 26;
            txtTotalHours.TextAlign = HorizontalAlignment.Right;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(20, 105);
            label2.Margin = new Padding(0, 0, 0, 4);
            label2.Name = "label2";
            label2.Size = new Size(156, 16);
            label2.TabIndex = 17;
            label2.Text = "Undertime :";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtTotalRegularHours
            // 
            txtTotalRegularHours.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTotalRegularHours.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtTotalRegularHours.Location = new Point(181, 66);
            txtTotalRegularHours.Margin = new Padding(0, 0, 4, 8);
            txtTotalRegularHours.Name = "txtTotalRegularHours";
            txtTotalRegularHours.ReadOnly = true;
            txtTotalRegularHours.Size = new Size(100, 26);
            txtTotalRegularHours.TabIndex = 47;
            txtTotalRegularHours.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.GrayText;
            label4.Location = new Point(285, 38);
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
            label5.Location = new Point(285, 105);
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
            label1.Location = new Point(20, 37);
            label1.Margin = new Padding(0, 0, 0, 4);
            label1.Name = "label1";
            label1.Size = new Size(156, 16);
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
            label6.Location = new Point(285, 139);
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
            btnAddAdjustment.Location = new Point(835, 579);
            btnAddAdjustment.Margin = new Padding(0, 0, 8, 16);
            btnAddAdjustment.Name = "btnAddAdjustment";
            btnAddAdjustment.Size = new Size(75, 28);
            btnAddAdjustment.TabIndex = 50;
            btnAddAdjustment.Text = "Add";
            btnAddAdjustment.UseVisualStyleBackColor = true;
            btnAddAdjustment.Click += btnAddAdjustment_Click;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label25.ForeColor = SystemColors.GrayText;
            label25.Location = new Point(684, 528);
            label25.Margin = new Padding(0, 0, 0, 4);
            label25.Name = "label25";
            label25.Size = new Size(0, 16);
            label25.TabIndex = 48;
            // 
            // grpNightDifferential
            // 
            grpNightDifferential.Controls.Add(label21);
            grpNightDifferential.Controls.Add(label22);
            grpNightDifferential.Controls.Add(label19);
            grpNightDifferential.Controls.Add(label20);
            grpNightDifferential.Controls.Add(label18);
            grpNightDifferential.Controls.Add(txtNight_150);
            grpNightDifferential.Controls.Add(txtNight_130);
            grpNightDifferential.Controls.Add(txtNight_125);
            grpNightDifferential.Controls.Add(txtNight_50);
            grpNightDifferential.Controls.Add(txtNight_20);
            grpNightDifferential.Controls.Add(txtNight_10);
            grpNightDifferential.Controls.Add(label26);
            grpNightDifferential.Location = new Point(791, 92);
            grpNightDifferential.Margin = new Padding(0, 0, 0, 16);
            grpNightDifferential.Name = "grpNightDifferential";
            grpNightDifferential.Padding = new Padding(16);
            grpNightDifferential.Size = new Size(202, 318);
            grpNightDifferential.TabIndex = 42;
            grpNightDifferential.TabStop = false;
            grpNightDifferential.Text = "Night Differential";
            // 
            // label21
            // 
            label21.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label21.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label21.Location = new Point(11, 208);
            label21.Margin = new Padding(0, 0, 0, 4);
            label21.Name = "label21";
            label21.Size = new Size(66, 16);
            label21.TabIndex = 43;
            label21.Text = "(150%) :";
            label21.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            label22.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label22.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label22.Location = new Point(11, 174);
            label22.Margin = new Padding(0, 0, 0, 4);
            label22.Name = "label22";
            label22.Size = new Size(66, 16);
            label22.TabIndex = 42;
            label22.Text = "(130%) :";
            label22.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            label19.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label19.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label19.Location = new Point(11, 140);
            label19.Margin = new Padding(0, 0, 0, 4);
            label19.Name = "label19";
            label19.Size = new Size(66, 16);
            label19.TabIndex = 41;
            label19.Text = "(125%) :";
            label19.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            label20.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label20.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label20.Location = new Point(11, 106);
            label20.Margin = new Padding(0, 0, 0, 4);
            label20.Name = "label20";
            label20.Size = new Size(66, 16);
            label20.TabIndex = 40;
            label20.Text = "(50%) :";
            label20.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            label18.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label18.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label18.Location = new Point(11, 72);
            label18.Margin = new Padding(0, 0, 0, 4);
            label18.Name = "label18";
            label18.Size = new Size(66, 16);
            label18.TabIndex = 39;
            label18.Text = "(20%) :";
            label18.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtNight_150
            // 
            txtNight_150.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNight_150.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNight_150.Location = new Point(82, 203);
            txtNight_150.Margin = new Padding(0, 0, 4, 8);
            txtNight_150.Name = "txtNight_150";
            txtNight_150.ReadOnly = true;
            txtNight_150.Size = new Size(100, 26);
            txtNight_150.TabIndex = 38;
            txtNight_150.TextAlign = HorizontalAlignment.Right;
            // 
            // txtNight_130
            // 
            txtNight_130.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNight_130.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNight_130.Location = new Point(82, 169);
            txtNight_130.Margin = new Padding(0, 0, 4, 8);
            txtNight_130.Name = "txtNight_130";
            txtNight_130.ReadOnly = true;
            txtNight_130.Size = new Size(100, 26);
            txtNight_130.TabIndex = 37;
            txtNight_130.TextAlign = HorizontalAlignment.Right;
            // 
            // txtNight_125
            // 
            txtNight_125.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNight_125.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNight_125.Location = new Point(82, 135);
            txtNight_125.Margin = new Padding(0, 0, 4, 8);
            txtNight_125.Name = "txtNight_125";
            txtNight_125.ReadOnly = true;
            txtNight_125.Size = new Size(100, 26);
            txtNight_125.TabIndex = 36;
            txtNight_125.TextAlign = HorizontalAlignment.Right;
            // 
            // txtNight_50
            // 
            txtNight_50.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNight_50.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNight_50.Location = new Point(82, 101);
            txtNight_50.Margin = new Padding(0, 0, 4, 8);
            txtNight_50.Name = "txtNight_50";
            txtNight_50.ReadOnly = true;
            txtNight_50.Size = new Size(100, 26);
            txtNight_50.TabIndex = 35;
            txtNight_50.TextAlign = HorizontalAlignment.Right;
            // 
            // txtNight_20
            // 
            txtNight_20.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNight_20.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNight_20.Location = new Point(82, 67);
            txtNight_20.Margin = new Padding(0, 0, 4, 8);
            txtNight_20.Name = "txtNight_20";
            txtNight_20.ReadOnly = true;
            txtNight_20.Size = new Size(100, 26);
            txtNight_20.TabIndex = 26;
            txtNight_20.TextAlign = HorizontalAlignment.Right;
            // 
            // txtNight_10
            // 
            txtNight_10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNight_10.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNight_10.Location = new Point(82, 33);
            txtNight_10.Margin = new Padding(0, 0, 4, 8);
            txtNight_10.Name = "txtNight_10";
            txtNight_10.ReadOnly = true;
            txtNight_10.Size = new Size(100, 26);
            txtNight_10.TabIndex = 25;
            txtNight_10.TextAlign = HorizontalAlignment.Right;
            // 
            // label26
            // 
            label26.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label26.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label26.Location = new Point(11, 38);
            label26.Margin = new Padding(0, 0, 0, 4);
            label26.Name = "label26";
            label26.Size = new Size(66, 16);
            label26.TabIndex = 25;
            label26.Text = "(10%) :";
            label26.TextAlign = ContentAlignment.MiddleRight;
            // 
            // grpOvertime
            // 
            grpOvertime.Controls.Add(txtRegularHoliday_160);
            grpOvertime.Controls.Add(txtLegalHoliday_260);
            grpOvertime.Controls.Add(txtLegalHoliday_200);
            grpOvertime.Controls.Add(txtSpecialHolidayExcess_195);
            grpOvertime.Controls.Add(txtRestDayExcess_169);
            grpOvertime.Controls.Add(txtRestDay_150);
            grpOvertime.Controls.Add(label15);
            grpOvertime.Controls.Add(label14);
            grpOvertime.Controls.Add(label13);
            grpOvertime.Controls.Add(label12);
            grpOvertime.Controls.Add(label11);
            grpOvertime.Controls.Add(label9);
            grpOvertime.Controls.Add(txtRestDaySpecialHoliday_130);
            grpOvertime.Controls.Add(label8);
            grpOvertime.Controls.Add(txtRegular_125);
            grpOvertime.Controls.Add(label7);
            grpOvertime.Location = new Point(385, 92);
            grpOvertime.Margin = new Padding(0, 0, 8, 16);
            grpOvertime.Name = "grpOvertime";
            grpOvertime.Padding = new Padding(16);
            grpOvertime.Size = new Size(398, 318);
            grpOvertime.TabIndex = 24;
            grpOvertime.TabStop = false;
            grpOvertime.Text = "Overtime";
            // 
            // txtRegularHoliday_160
            // 
            txtRegularHoliday_160.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtRegularHoliday_160.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtRegularHoliday_160.Location = new Point(278, 267);
            txtRegularHoliday_160.Margin = new Padding(0, 0, 4, 8);
            txtRegularHoliday_160.Name = "txtRegularHoliday_160";
            txtRegularHoliday_160.ReadOnly = true;
            txtRegularHoliday_160.Size = new Size(100, 26);
            txtRegularHoliday_160.TabIndex = 41;
            txtRegularHoliday_160.TextAlign = HorizontalAlignment.Right;
            // 
            // txtLegalHoliday_260
            // 
            txtLegalHoliday_260.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtLegalHoliday_260.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtLegalHoliday_260.Location = new Point(278, 233);
            txtLegalHoliday_260.Margin = new Padding(0, 0, 4, 8);
            txtLegalHoliday_260.Name = "txtLegalHoliday_260";
            txtLegalHoliday_260.ReadOnly = true;
            txtLegalHoliday_260.Size = new Size(100, 26);
            txtLegalHoliday_260.TabIndex = 40;
            txtLegalHoliday_260.TextAlign = HorizontalAlignment.Right;
            // 
            // txtLegalHoliday_200
            // 
            txtLegalHoliday_200.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtLegalHoliday_200.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtLegalHoliday_200.Location = new Point(278, 199);
            txtLegalHoliday_200.Margin = new Padding(0, 0, 4, 8);
            txtLegalHoliday_200.Name = "txtLegalHoliday_200";
            txtLegalHoliday_200.ReadOnly = true;
            txtLegalHoliday_200.Size = new Size(100, 26);
            txtLegalHoliday_200.TabIndex = 39;
            txtLegalHoliday_200.TextAlign = HorizontalAlignment.Right;
            // 
            // txtSpecialHolidayExcess_195
            // 
            txtSpecialHolidayExcess_195.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSpecialHolidayExcess_195.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtSpecialHolidayExcess_195.Location = new Point(278, 168);
            txtSpecialHolidayExcess_195.Margin = new Padding(0, 0, 4, 8);
            txtSpecialHolidayExcess_195.Name = "txtSpecialHolidayExcess_195";
            txtSpecialHolidayExcess_195.ReadOnly = true;
            txtSpecialHolidayExcess_195.Size = new Size(100, 26);
            txtSpecialHolidayExcess_195.TabIndex = 38;
            txtSpecialHolidayExcess_195.TextAlign = HorizontalAlignment.Right;
            // 
            // txtRestDayExcess_169
            // 
            txtRestDayExcess_169.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtRestDayExcess_169.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtRestDayExcess_169.Location = new Point(278, 134);
            txtRestDayExcess_169.Margin = new Padding(0, 0, 4, 8);
            txtRestDayExcess_169.Name = "txtRestDayExcess_169";
            txtRestDayExcess_169.ReadOnly = true;
            txtRestDayExcess_169.Size = new Size(100, 26);
            txtRestDayExcess_169.TabIndex = 36;
            txtRestDayExcess_169.TextAlign = HorizontalAlignment.Right;
            // 
            // txtRestDay_150
            // 
            txtRestDay_150.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtRestDay_150.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtRestDay_150.Location = new Point(278, 100);
            txtRestDay_150.Margin = new Padding(0, 0, 4, 8);
            txtRestDay_150.Name = "txtRestDay_150";
            txtRestDay_150.ReadOnly = true;
            txtRestDay_150.Size = new Size(100, 26);
            txtRestDay_150.TabIndex = 35;
            txtRestDay_150.TextAlign = HorizontalAlignment.Right;
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label15.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(11, 272);
            label15.Margin = new Padding(0, 0, 0, 4);
            label15.Name = "label15";
            label15.Size = new Size(262, 16);
            label15.TabIndex = 34;
            label15.Text = "Regular Holiday (160%) :";
            label15.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label14.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(11, 238);
            label14.Margin = new Padding(0, 0, 0, 4);
            label14.Name = "label14";
            label14.Size = new Size(262, 16);
            label14.TabIndex = 33;
            label14.Text = "Legal Holiday (260%) :";
            label14.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label13.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(11, 204);
            label13.Margin = new Padding(0, 0, 0, 4);
            label13.Name = "label13";
            label13.Size = new Size(262, 16);
            label13.TabIndex = 32;
            label13.Text = "Legal Holiday (200%) :";
            label13.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label12.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(11, 173);
            label12.Margin = new Padding(0, 0, 0, 4);
            label12.Name = "label12";
            label12.Size = new Size(262, 16);
            label12.TabIndex = 31;
            label12.Text = "Special Holiday Excess (195%) :";
            label12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label11.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(11, 105);
            label11.Margin = new Padding(0, 0, 0, 4);
            label11.Name = "label11";
            label11.Size = new Size(262, 16);
            label11.TabIndex = 30;
            label11.Text = "Rest Day (150%) :";
            label11.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label9.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(11, 139);
            label9.Margin = new Padding(0, 0, 0, 4);
            label9.Name = "label9";
            label9.Size = new Size(262, 16);
            label9.TabIndex = 28;
            label9.Text = "Rest Day Excess (169%) :";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtRestDaySpecialHoliday_130
            // 
            txtRestDaySpecialHoliday_130.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtRestDaySpecialHoliday_130.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtRestDaySpecialHoliday_130.Location = new Point(278, 66);
            txtRestDaySpecialHoliday_130.Margin = new Padding(0, 0, 4, 8);
            txtRestDaySpecialHoliday_130.Name = "txtRestDaySpecialHoliday_130";
            txtRestDaySpecialHoliday_130.ReadOnly = true;
            txtRestDaySpecialHoliday_130.Size = new Size(100, 26);
            txtRestDaySpecialHoliday_130.TabIndex = 26;
            txtRestDaySpecialHoliday_130.TextAlign = HorizontalAlignment.Right;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label8.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(11, 71);
            label8.Margin = new Padding(0, 0, 0, 4);
            label8.Name = "label8";
            label8.Size = new Size(262, 16);
            label8.TabIndex = 27;
            label8.Text = "Rest Day and Special Holiday (130%) :";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtRegular_125
            // 
            txtRegular_125.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtRegular_125.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtRegular_125.Location = new Point(278, 32);
            txtRegular_125.Margin = new Padding(0, 0, 4, 8);
            txtRegular_125.Name = "txtRegular_125";
            txtRegular_125.ReadOnly = true;
            txtRegular_125.Size = new Size(100, 26);
            txtRegular_125.TabIndex = 25;
            txtRegular_125.TextAlign = HorizontalAlignment.Right;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(11, 37);
            label7.Margin = new Padding(0, 0, 0, 4);
            label7.Name = "label7";
            label7.Size = new Size(262, 16);
            label7.TabIndex = 25;
            label7.Text = "Regular (125%) :";
            label7.TextAlign = ContentAlignment.MiddleRight;
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
            pnlLine2.Size = new Size(977, 1);
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
            pnlLeft.Size = new Size(240, 860);
            pnlLeft.TabIndex = 43;
            // 
            // pnlLeftBody
            // 
            pnlLeftBody.AutoScroll = true;
            pnlLeftBody.Controls.Add(flowLeftEmployeeList);
            pnlLeftBody.Dock = DockStyle.Fill;
            pnlLeftBody.Location = new Point(0, 138);
            pnlLeftBody.Name = "pnlLeftBody";
            pnlLeftBody.Size = new Size(240, 722);
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
            pnlLeftHeader.Controls.Add(label10);
            pnlLeftHeader.Controls.Add(txtSearch);
            pnlLeftHeader.Controls.Add(cmbDepartment);
            pnlLeftHeader.Controls.Add(pnlLine3);
            pnlLeftHeader.Controls.Add(label29);
            pnlLeftHeader.Dock = DockStyle.Top;
            pnlLeftHeader.Location = new Point(0, 0);
            pnlLeftHeader.Name = "pnlLeftHeader";
            pnlLeftHeader.Padding = new Padding(16);
            pnlLeftHeader.Size = new Size(240, 138);
            pnlLeftHeader.TabIndex = 0;
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
            txtSearch.Size = new Size(208, 26);
            txtSearch.TabIndex = 17;
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
            cmbDepartment.Size = new Size(208, 24);
            cmbDepartment.TabIndex = 5;
            cmbDepartment.SelectedIndexChanged += cmbDepartment_SelectedIndexChanged;
            // 
            // pnlLine3
            // 
            pnlLine3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLine3.BorderStyle = BorderStyle.FixedSingle;
            pnlLine3.Location = new Point(16, 130);
            pnlLine3.Margin = new Padding(0, 0, 0, 16);
            pnlLine3.Name = "pnlLine3";
            pnlLine3.Size = new Size(208, 1);
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
            pnlVLine1.Location = new Point(240, 1);
            pnlVLine1.Name = "pnlVLine1";
            pnlVLine1.Size = new Size(1, 860);
            pnlVLine1.TabIndex = 44;
            // 
            // btnApplyRemarks
            // 
            btnApplyRemarks.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnApplyRemarks.AutoSize = true;
            btnApplyRemarks.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnApplyRemarks.Location = new Point(799, 97);
            btnApplyRemarks.Margin = new Padding(0, 0, 8, 16);
            btnApplyRemarks.Name = "btnApplyRemarks";
            btnApplyRemarks.Size = new Size(75, 28);
            btnApplyRemarks.TabIndex = 56;
            btnApplyRemarks.Text = "Apply";
            btnApplyRemarks.UseVisualStyleBackColor = true;
            // 
            // btnClearRemarks
            // 
            btnClearRemarks.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClearRemarks.AutoSize = true;
            btnClearRemarks.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnClearRemarks.Location = new Point(882, 97);
            btnClearRemarks.Margin = new Padding(0, 0, 0, 16);
            btnClearRemarks.Name = "btnClearRemarks";
            btnClearRemarks.Size = new Size(75, 28);
            btnClearRemarks.TabIndex = 57;
            btnClearRemarks.Text = "Clear";
            btnClearRemarks.UseVisualStyleBackColor = true;
            btnClearRemarks.Click += btnClearRemarks_Click;
            // 
            // EmployeeTimekeepReviewForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(1250, 861);
            Controls.Add(pnlBody);
            Controls.Add(pnlFooter);
            Controls.Add(pnlVLine1);
            Controls.Add(pnlLeft);
            Controls.Add(pnlLine1);
            Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
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
            grpRemarks.ResumeLayout(false);
            grpRemarks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAdjustments).EndInit();
            grpBasicInformation.ResumeLayout(false);
            grpBasicInformation.PerformLayout();
            grpNightDifferential.ResumeLayout(false);
            grpNightDifferential.PerformLayout();
            grpOvertime.ResumeLayout(false);
            grpOvertime.PerformLayout();
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
        private Label label16;
        private TextBox txtTotalHours;
        private Label label17;
        private GroupBox grpNightDifferential;
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
        private Label label25;
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
    }
}