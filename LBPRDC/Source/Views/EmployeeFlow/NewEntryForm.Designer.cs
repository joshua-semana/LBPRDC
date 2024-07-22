namespace LBPRDC.Source.Views
{
    partial class frmNewEntryEmployee
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
            pnlLine1 = new Panel();
            flowControls = new FlowLayoutPanel();
            btnConfirm = new Button();
            btnCancel = new Button();
            pnlMain = new Panel();
            label12 = new Label();
            pnlLine2 = new Panel();
            label33 = new Label();
            grpJobData = new GroupBox();
            label5 = new Label();
            cmbEmploymentStatus = new ComboBox();
            label4 = new Label();
            cmbClassification = new ComboBox();
            label3 = new Label();
            label34 = new Label();
            cmbWageType = new ComboBox();
            label35 = new Label();
            label31 = new Label();
            chkPreviousEmployee = new CheckBox();
            dtpStartDate = new DateTimePicker();
            label30 = new Label();
            label29 = new Label();
            label28 = new Label();
            label27 = new Label();
            label20 = new Label();
            cmbLocation = new ComboBox();
            cmbDepartment = new ComboBox();
            grpPreviousWork = new GroupBox();
            label11 = new Label();
            txtOtherInformation = new TextBox();
            label19 = new Label();
            label18 = new Label();
            dtpToDate = new DateTimePicker();
            label17 = new Label();
            dtpFromDate = new DateTimePicker();
            txtPreviousPosition = new TextBox();
            label16 = new Label();
            txtRemarks = new TextBox();
            label15 = new Label();
            txtPositionTitle = new TextBox();
            label14 = new Label();
            txtEmployeeID = new TextBox();
            label13 = new Label();
            cmbPosition = new ComboBox();
            label7 = new Label();
            label8 = new Label();
            grpContactData = new GroupBox();
            txtContactNumber2 = new TextBox();
            txtContactNumber1 = new TextBox();
            label6 = new Label();
            txtEmailAddress2 = new TextBox();
            txtEmailAddress1 = new TextBox();
            label10 = new Label();
            grpPersonalData = new GroupBox();
            label25 = new Label();
            label24 = new Label();
            label23 = new Label();
            label22 = new Label();
            label21 = new Label();
            label9 = new Label();
            cmbGender = new ComboBox();
            label2 = new Label();
            cmbSuffix = new ComboBox();
            txtMiddleName = new TextBox();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            label1 = new Label();
            pnlFooter = new Panel();
            label26 = new Label();
            flowControls.SuspendLayout();
            pnlMain.SuspendLayout();
            grpJobData.SuspendLayout();
            grpPreviousWork.SuspendLayout();
            grpContactData.SuspendLayout();
            grpPersonalData.SuspendLayout();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLine1
            // 
            pnlLine1.BorderStyle = BorderStyle.FixedSingle;
            pnlLine1.Dock = DockStyle.Top;
            pnlLine1.Location = new Point(0, 0);
            pnlLine1.Name = "pnlLine1";
            pnlLine1.Size = new Size(1061, 1);
            pnlLine1.TabIndex = 0;
            // 
            // flowControls
            // 
            flowControls.BackColor = SystemColors.Menu;
            flowControls.Controls.Add(btnConfirm);
            flowControls.Controls.Add(btnCancel);
            flowControls.Dock = DockStyle.Fill;
            flowControls.FlowDirection = FlowDirection.RightToLeft;
            flowControls.Location = new Point(0, 0);
            flowControls.Name = "flowControls";
            flowControls.Padding = new Padding(16, 16, 0, 16);
            flowControls.Size = new Size(1061, 60);
            flowControls.TabIndex = 1;
            // 
            // btnConfirm
            // 
            btnConfirm.AutoSize = true;
            btnConfirm.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnConfirm.Location = new Point(970, 16);
            btnConfirm.Margin = new Padding(8, 0, 0, 0);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(75, 28);
            btnConfirm.TabIndex = 24;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.Location = new Point(887, 16);
            btnCancel.Margin = new Padding(0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 28);
            btnCancel.TabIndex = 25;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // pnlMain
            // 
            pnlMain.AutoScroll = true;
            pnlMain.Controls.Add(label12);
            pnlMain.Controls.Add(pnlLine2);
            pnlMain.Controls.Add(label33);
            pnlMain.Controls.Add(grpJobData);
            pnlMain.Controls.Add(grpContactData);
            pnlMain.Controls.Add(grpPersonalData);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 1);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(16);
            pnlMain.Size = new Size(1061, 693);
            pnlMain.TabIndex = 2;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(16, 661);
            label12.Margin = new Padding(0, 6, 8, 0);
            label12.Name = "label12";
            label12.Size = new Size(427, 16);
            label12.TabIndex = 28;
            label12.Text = "Reminder: All text fields marked with a red asterisk (*) are required.";
            // 
            // pnlLine2
            // 
            pnlLine2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLine2.BorderStyle = BorderStyle.FixedSingle;
            pnlLine2.Location = new Point(16, 43);
            pnlLine2.Margin = new Padding(0, 0, 0, 16);
            pnlLine2.Name = "pnlLine2";
            pnlLine2.Size = new Size(1029, 1);
            pnlLine2.TabIndex = 24;
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label33.Location = new Point(16, 16);
            label33.Margin = new Padding(0, 0, 0, 8);
            label33.Name = "label33";
            label33.Size = new Size(158, 19);
            label33.TabIndex = 23;
            label33.Text = "Add New Employee";
            // 
            // grpJobData
            // 
            grpJobData.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpJobData.Controls.Add(label5);
            grpJobData.Controls.Add(cmbEmploymentStatus);
            grpJobData.Controls.Add(label4);
            grpJobData.Controls.Add(cmbClassification);
            grpJobData.Controls.Add(label3);
            grpJobData.Controls.Add(label34);
            grpJobData.Controls.Add(cmbWageType);
            grpJobData.Controls.Add(label35);
            grpJobData.Controls.Add(label31);
            grpJobData.Controls.Add(chkPreviousEmployee);
            grpJobData.Controls.Add(dtpStartDate);
            grpJobData.Controls.Add(label30);
            grpJobData.Controls.Add(label29);
            grpJobData.Controls.Add(label28);
            grpJobData.Controls.Add(label27);
            grpJobData.Controls.Add(label20);
            grpJobData.Controls.Add(cmbLocation);
            grpJobData.Controls.Add(cmbDepartment);
            grpJobData.Controls.Add(grpPreviousWork);
            grpJobData.Controls.Add(txtRemarks);
            grpJobData.Controls.Add(label15);
            grpJobData.Controls.Add(txtPositionTitle);
            grpJobData.Controls.Add(label14);
            grpJobData.Controls.Add(txtEmployeeID);
            grpJobData.Controls.Add(label13);
            grpJobData.Controls.Add(cmbPosition);
            grpJobData.Controls.Add(label7);
            grpJobData.Controls.Add(label8);
            grpJobData.Location = new Point(16, 334);
            grpJobData.Margin = new Padding(0);
            grpJobData.Name = "grpJobData";
            grpJobData.Padding = new Padding(3, 8, 3, 3);
            grpJobData.Size = new Size(1028, 314);
            grpJobData.TabIndex = 14;
            grpJobData.TabStop = false;
            grpJobData.Text = "Work Information";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.Red;
            label5.Location = new Point(138, 155);
            label5.Margin = new Padding(0, 0, 0, 4);
            label5.Name = "label5";
            label5.Size = new Size(14, 18);
            label5.TabIndex = 40;
            label5.Text = "*";
            // 
            // cmbEmploymentStatus
            // 
            cmbEmploymentStatus.AccessibleName = "Employment Status";
            cmbEmploymentStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbEmploymentStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmploymentStatus.FormattingEnabled = true;
            cmbEmploymentStatus.Location = new Point(10, 180);
            cmbEmploymentStatus.Margin = new Padding(3, 3, 3, 16);
            cmbEmploymentStatus.Name = "cmbEmploymentStatus";
            cmbEmploymentStatus.Size = new Size(197, 26);
            cmbEmploymentStatus.TabIndex = 17;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(10, 157);
            label4.Margin = new Padding(3, 0, 0, 4);
            label4.Name = "label4";
            label4.Size = new Size(128, 16);
            label4.TabIndex = 39;
            label4.Text = "Employment Status";
            // 
            // cmbClassification
            // 
            cmbClassification.AccessibleName = "Classification";
            cmbClassification.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbClassification.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClassification.FormattingEnabled = true;
            cmbClassification.Location = new Point(213, 50);
            cmbClassification.Margin = new Padding(3, 3, 3, 16);
            cmbClassification.Name = "cmbClassification";
            cmbClassification.Size = new Size(400, 26);
            cmbClassification.TabIndex = 10;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(213, 27);
            label3.Margin = new Padding(3, 0, 0, 4);
            label3.Name = "label3";
            label3.Size = new Size(90, 16);
            label3.TabIndex = 37;
            label3.Text = "Classification";
            // 
            // label34
            // 
            label34.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label34.AutoSize = true;
            label34.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label34.ForeColor = Color.Red;
            label34.Location = new Point(303, 25);
            label34.Margin = new Padding(0, 0, 0, 4);
            label34.Name = "label34";
            label34.Size = new Size(14, 18);
            label34.TabIndex = 36;
            label34.Text = "*";
            // 
            // cmbWageType
            // 
            cmbWageType.AccessibleName = "Wage Type";
            cmbWageType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbWageType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbWageType.FormattingEnabled = true;
            cmbWageType.Location = new Point(10, 115);
            cmbWageType.Margin = new Padding(3, 3, 3, 16);
            cmbWageType.Name = "cmbWageType";
            cmbWageType.Size = new Size(197, 26);
            cmbWageType.TabIndex = 13;
            // 
            // label35
            // 
            label35.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label35.AutoSize = true;
            label35.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label35.Location = new Point(10, 92);
            label35.Margin = new Padding(3, 0, 0, 4);
            label35.Name = "label35";
            label35.Size = new Size(78, 16);
            label35.TabIndex = 34;
            label35.Text = "Wage Type";
            // 
            // label31
            // 
            label31.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label31.AutoSize = true;
            label31.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label31.Location = new Point(822, 92);
            label31.Margin = new Padding(3, 0, 3, 4);
            label31.Name = "label31";
            label31.Size = new Size(71, 16);
            label31.TabIndex = 33;
            label31.Text = "Start Date";
            // 
            // chkPreviousEmployee
            // 
            chkPreviousEmployee.AutoSize = true;
            chkPreviousEmployee.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkPreviousEmployee.Location = new Point(20, 221);
            chkPreviousEmployee.Margin = new Padding(3, 3, 3, 8);
            chkPreviousEmployee.Name = "chkPreviousEmployee";
            chkPreviousEmployee.Size = new Size(317, 20);
            chkPreviousEmployee.TabIndex = 19;
            chkPreviousEmployee.Text = "This person is a previous employee of LBRDC";
            chkPreviousEmployee.UseVisualStyleBackColor = true;
            chkPreviousEmployee.CheckedChanged += chkPreviousEmployee_CheckedChanged;
            // 
            // dtpStartDate
            // 
            dtpStartDate.AccessibleName = "Start Date";
            dtpStartDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpStartDate.CustomFormat = "MM-dd-yyy";
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.Location = new Point(822, 115);
            dtpStartDate.Margin = new Padding(3, 3, 3, 16);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(197, 26);
            dtpStartDate.TabIndex = 16;
            // 
            // label30
            // 
            label30.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label30.AutoSize = true;
            label30.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label30.ForeColor = Color.Red;
            label30.Location = new Point(883, 25);
            label30.Margin = new Padding(0, 0, 0, 4);
            label30.Name = "label30";
            label30.Size = new Size(14, 18);
            label30.TabIndex = 31;
            label30.Text = "*";
            // 
            // label29
            // 
            label29.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label29.AutoSize = true;
            label29.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label29.ForeColor = Color.Red;
            label29.Location = new Point(270, 90);
            label29.Margin = new Padding(0, 0, 0, 4);
            label29.Name = "label29";
            label29.Size = new Size(14, 18);
            label29.TabIndex = 30;
            label29.Text = "*";
            // 
            // label28
            // 
            label28.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label28.AutoSize = true;
            label28.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label28.ForeColor = Color.Red;
            label28.Location = new Point(700, 25);
            label28.Margin = new Padding(0, 0, 0, 4);
            label28.Name = "label28";
            label28.Size = new Size(14, 18);
            label28.TabIndex = 29;
            label28.Text = "*";
            // 
            // label27
            // 
            label27.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label27.AutoSize = true;
            label27.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label27.ForeColor = Color.Red;
            label27.Location = new Point(96, 25);
            label27.Margin = new Padding(0, 0, 0, 4);
            label27.Name = "label27";
            label27.Size = new Size(14, 18);
            label27.TabIndex = 18;
            label27.Text = "*";
            // 
            // label20
            // 
            label20.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label20.AutoSize = true;
            label20.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label20.Location = new Point(822, 27);
            label20.Margin = new Padding(3, 0, 0, 4);
            label20.Name = "label20";
            label20.Size = new Size(61, 16);
            label20.TabIndex = 28;
            label20.Text = "Location";
            // 
            // cmbLocation
            // 
            cmbLocation.AccessibleName = "Location";
            cmbLocation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbLocation.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLocation.FormattingEnabled = true;
            cmbLocation.Location = new Point(822, 50);
            cmbLocation.Name = "cmbLocation";
            cmbLocation.Size = new Size(197, 26);
            cmbLocation.TabIndex = 12;
            // 
            // cmbDepartment
            // 
            cmbDepartment.AccessibleName = "Department";
            cmbDepartment.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.Location = new Point(619, 50);
            cmbDepartment.Margin = new Padding(3, 3, 3, 16);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(197, 26);
            cmbDepartment.TabIndex = 11;
            cmbDepartment.SelectedIndexChanged += cmbDepartment_SelectedIndexChanged;
            // 
            // grpPreviousWork
            // 
            grpPreviousWork.Controls.Add(label11);
            grpPreviousWork.Controls.Add(txtOtherInformation);
            grpPreviousWork.Controls.Add(label19);
            grpPreviousWork.Controls.Add(label18);
            grpPreviousWork.Controls.Add(dtpToDate);
            grpPreviousWork.Controls.Add(label17);
            grpPreviousWork.Controls.Add(dtpFromDate);
            grpPreviousWork.Controls.Add(txtPreviousPosition);
            grpPreviousWork.Controls.Add(label16);
            grpPreviousWork.Enabled = false;
            grpPreviousWork.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            grpPreviousWork.Location = new Point(10, 222);
            grpPreviousWork.Margin = new Padding(0);
            grpPreviousWork.Name = "grpPreviousWork";
            grpPreviousWork.Padding = new Padding(3, 8, 3, 3);
            grpPreviousWork.Size = new Size(1009, 82);
            grpPreviousWork.TabIndex = 25;
            grpPreviousWork.TabStop = false;
            grpPreviousWork.Text = "Former Work Information";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label11.ForeColor = Color.Red;
            label11.Location = new Point(67, 24);
            label11.Margin = new Padding(0, 0, 0, 4);
            label11.Name = "label11";
            label11.Size = new Size(12, 16);
            label11.TabIndex = 34;
            label11.Text = "*";
            // 
            // txtOtherInformation
            // 
            txtOtherInformation.AccessibleName = "Other Information";
            txtOtherInformation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtOtherInformation.Location = new Point(203, 47);
            txtOtherInformation.Margin = new Padding(6, 3, 3, 16);
            txtOtherInformation.MaxLength = 100;
            txtOtherInformation.Name = "txtOtherInformation";
            txtOtherInformation.Size = new Size(400, 23);
            txtOtherInformation.TabIndex = 21;
            // 
            // label19
            // 
            label19.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label19.AutoSize = true;
            label19.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label19.Location = new Point(203, 24);
            label19.Margin = new Padding(3, 0, 3, 4);
            label19.Name = "label19";
            label19.Size = new Size(117, 16);
            label19.TabIndex = 27;
            label19.Text = "Other Information";
            // 
            // label18
            // 
            label18.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label18.AutoSize = true;
            label18.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label18.Location = new Point(812, 24);
            label18.Margin = new Padding(3, 0, 3, 4);
            label18.Name = "label18";
            label18.Size = new Size(66, 16);
            label18.TabIndex = 25;
            label18.Text = "End Date";
            // 
            // dtpToDate
            // 
            dtpToDate.AccessibleName = "Previous Work To Date";
            dtpToDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpToDate.CustomFormat = "MM-dd-yyy";
            dtpToDate.Format = DateTimePickerFormat.Custom;
            dtpToDate.Location = new Point(812, 47);
            dtpToDate.Margin = new Padding(3, 3, 3, 16);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(188, 23);
            dtpToDate.TabIndex = 23;
            // 
            // label17
            // 
            label17.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label17.AutoSize = true;
            label17.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label17.Location = new Point(609, 24);
            label17.Margin = new Padding(3, 0, 3, 4);
            label17.Name = "label17";
            label17.Size = new Size(71, 16);
            label17.TabIndex = 23;
            label17.Text = "Start Date";
            // 
            // dtpFromDate
            // 
            dtpFromDate.AccessibleName = "Previous Work From Date";
            dtpFromDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpFromDate.CustomFormat = "MM-dd-yyy";
            dtpFromDate.Format = DateTimePickerFormat.Custom;
            dtpFromDate.Location = new Point(609, 47);
            dtpFromDate.Margin = new Padding(3, 3, 3, 16);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(197, 23);
            dtpFromDate.TabIndex = 22;
            // 
            // txtPreviousPosition
            // 
            txtPreviousPosition.AccessibleName = "Previous Work Position";
            txtPreviousPosition.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPreviousPosition.Location = new Point(10, 47);
            txtPreviousPosition.Margin = new Padding(6, 3, 3, 16);
            txtPreviousPosition.MaxLength = 50;
            txtPreviousPosition.Name = "txtPreviousPosition";
            txtPreviousPosition.Size = new Size(187, 23);
            txtPreviousPosition.TabIndex = 20;
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label16.AutoSize = true;
            label16.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(10, 24);
            label16.Margin = new Padding(3, 0, 0, 4);
            label16.Name = "label16";
            label16.Size = new Size(57, 16);
            label16.TabIndex = 21;
            label16.Text = "Position";
            // 
            // txtRemarks
            // 
            txtRemarks.AccessibleName = "Remarks";
            txtRemarks.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtRemarks.Location = new Point(213, 180);
            txtRemarks.Margin = new Padding(6, 3, 3, 16);
            txtRemarks.MaxLength = 100;
            txtRemarks.Name = "txtRemarks";
            txtRemarks.Size = new Size(400, 26);
            txtRemarks.TabIndex = 18;
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label15.AutoSize = true;
            label15.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(213, 157);
            label15.Margin = new Padding(3, 0, 3, 4);
            label15.Name = "label15";
            label15.Size = new Size(63, 16);
            label15.TabIndex = 23;
            label15.Text = "Remarks";
            // 
            // txtPositionTitle
            // 
            txtPositionTitle.AccessibleName = "Position Title";
            txtPositionTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPositionTitle.Location = new Point(619, 115);
            txtPositionTitle.Margin = new Padding(6, 3, 3, 16);
            txtPositionTitle.MaxLength = 50;
            txtPositionTitle.Name = "txtPositionTitle";
            txtPositionTitle.Size = new Size(197, 26);
            txtPositionTitle.TabIndex = 15;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label14.AutoSize = true;
            label14.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(619, 92);
            label14.Margin = new Padding(3, 0, 3, 4);
            label14.Name = "label14";
            label14.Size = new Size(87, 16);
            label14.TabIndex = 21;
            label14.Text = "Position Title";
            // 
            // txtEmployeeID
            // 
            txtEmployeeID.AccessibleName = "Employee ID";
            txtEmployeeID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEmployeeID.Location = new Point(10, 50);
            txtEmployeeID.Margin = new Padding(6, 3, 3, 16);
            txtEmployeeID.MaxLength = 50;
            txtEmployeeID.Name = "txtEmployeeID";
            txtEmployeeID.Size = new Size(197, 26);
            txtEmployeeID.TabIndex = 9;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label13.AutoSize = true;
            label13.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(10, 27);
            label13.Margin = new Padding(3, 0, 0, 4);
            label13.Name = "label13";
            label13.Size = new Size(86, 16);
            label13.TabIndex = 19;
            label13.Text = "Employee ID";
            // 
            // cmbPosition
            // 
            cmbPosition.AccessibleName = "Position";
            cmbPosition.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPosition.FormattingEnabled = true;
            cmbPosition.Location = new Point(213, 115);
            cmbPosition.Margin = new Padding(3, 3, 3, 16);
            cmbPosition.Name = "cmbPosition";
            cmbPosition.Size = new Size(400, 26);
            cmbPosition.TabIndex = 14;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(619, 27);
            label7.Margin = new Padding(3, 0, 0, 4);
            label7.Name = "label7";
            label7.Size = new Size(81, 16);
            label7.TabIndex = 13;
            label7.Text = "Department";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(213, 92);
            label8.Margin = new Padding(3, 0, 0, 4);
            label8.Name = "label8";
            label8.Size = new Size(57, 16);
            label8.TabIndex = 0;
            label8.Text = "Position";
            // 
            // grpContactData
            // 
            grpContactData.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpContactData.Controls.Add(txtContactNumber2);
            grpContactData.Controls.Add(txtContactNumber1);
            grpContactData.Controls.Add(label6);
            grpContactData.Controls.Add(txtEmailAddress2);
            grpContactData.Controls.Add(txtEmailAddress1);
            grpContactData.Controls.Add(label10);
            grpContactData.Location = new Point(16, 164);
            grpContactData.Margin = new Padding(0, 0, 0, 16);
            grpContactData.Name = "grpContactData";
            grpContactData.Padding = new Padding(3, 8, 3, 3);
            grpContactData.Size = new Size(1028, 154);
            grpContactData.TabIndex = 13;
            grpContactData.TabStop = false;
            grpContactData.Text = "Contact Information";
            // 
            // txtContactNumber2
            // 
            txtContactNumber2.AccessibleName = "Contact Number 2";
            txtContactNumber2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtContactNumber2.Location = new Point(514, 115);
            txtContactNumber2.MaxLength = 11;
            txtContactNumber2.Name = "txtContactNumber2";
            txtContactNumber2.Size = new Size(505, 26);
            txtContactNumber2.TabIndex = 8;
            txtContactNumber2.KeyPress += txtContactNumber_KeyPress;
            // 
            // txtContactNumber1
            // 
            txtContactNumber1.AccessibleName = "Contact Number 1";
            txtContactNumber1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtContactNumber1.Location = new Point(10, 115);
            txtContactNumber1.Margin = new Padding(6, 3, 3, 16);
            txtContactNumber1.MaxLength = 11;
            txtContactNumber1.Name = "txtContactNumber1";
            txtContactNumber1.PlaceholderText = "09xxxxxxxxx";
            txtContactNumber1.Size = new Size(498, 26);
            txtContactNumber1.TabIndex = 7;
            txtContactNumber1.KeyPress += txtContactNumber_KeyPress;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(10, 92);
            label6.Margin = new Padding(3, 0, 3, 4);
            label6.Name = "label6";
            label6.Size = new Size(116, 16);
            label6.TabIndex = 4;
            label6.Text = "Contact Numbers";
            // 
            // txtEmailAddress2
            // 
            txtEmailAddress2.AccessibleName = "Email Address 2";
            txtEmailAddress2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtEmailAddress2.Location = new Point(514, 50);
            txtEmailAddress2.MaxLength = 100;
            txtEmailAddress2.Name = "txtEmailAddress2";
            txtEmailAddress2.Size = new Size(505, 26);
            txtEmailAddress2.TabIndex = 6;
            // 
            // txtEmailAddress1
            // 
            txtEmailAddress1.AccessibleName = "Email Address 1";
            txtEmailAddress1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEmailAddress1.Location = new Point(10, 50);
            txtEmailAddress1.Margin = new Padding(6, 3, 3, 16);
            txtEmailAddress1.MaxLength = 100;
            txtEmailAddress1.Name = "txtEmailAddress1";
            txtEmailAddress1.PlaceholderText = "ex: myname@example.com";
            txtEmailAddress1.Size = new Size(498, 26);
            txtEmailAddress1.TabIndex = 5;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(10, 27);
            label10.Margin = new Padding(3, 0, 3, 4);
            label10.Name = "label10";
            label10.Size = new Size(111, 16);
            label10.TabIndex = 0;
            label10.Text = "Email Addresses";
            // 
            // grpPersonalData
            // 
            grpPersonalData.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpPersonalData.Controls.Add(label26);
            grpPersonalData.Controls.Add(label25);
            grpPersonalData.Controls.Add(label24);
            grpPersonalData.Controls.Add(label23);
            grpPersonalData.Controls.Add(label22);
            grpPersonalData.Controls.Add(label21);
            grpPersonalData.Controls.Add(label9);
            grpPersonalData.Controls.Add(cmbGender);
            grpPersonalData.Controls.Add(label2);
            grpPersonalData.Controls.Add(cmbSuffix);
            grpPersonalData.Controls.Add(txtMiddleName);
            grpPersonalData.Controls.Add(txtLastName);
            grpPersonalData.Controls.Add(txtFirstName);
            grpPersonalData.Controls.Add(label1);
            grpPersonalData.Location = new Point(16, 60);
            grpPersonalData.Margin = new Padding(0, 0, 0, 16);
            grpPersonalData.Name = "grpPersonalData";
            grpPersonalData.Padding = new Padding(3, 8, 3, 3);
            grpPersonalData.Size = new Size(1028, 88);
            grpPersonalData.TabIndex = 0;
            grpPersonalData.TabStop = false;
            grpPersonalData.Text = "Personal Information";
            // 
            // label25
            // 
            label25.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label25.AutoSize = true;
            label25.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label25.ForeColor = Color.Red;
            label25.Location = new Point(877, 25);
            label25.Margin = new Padding(0, 0, 0, 4);
            label25.Name = "label25";
            label25.Size = new Size(14, 18);
            label25.TabIndex = 18;
            label25.Text = "*";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label24.ForeColor = Color.Red;
            label24.Location = new Point(490, 25);
            label24.Margin = new Padding(0, 0, 0, 4);
            label24.Name = "label24";
            label24.Size = new Size(14, 18);
            label24.TabIndex = 17;
            label24.Text = "*";
            // 
            // label23
            // 
            label23.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label23.AutoSize = true;
            label23.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label23.ForeColor = Color.Red;
            label23.Location = new Point(85, 25);
            label23.Margin = new Padding(0, 0, 0, 4);
            label23.Name = "label23";
            label23.Size = new Size(14, 18);
            label23.TabIndex = 16;
            label23.Text = "*";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label22.Location = new Point(416, 27);
            label22.Margin = new Padding(3, 0, 0, 4);
            label22.Name = "label22";
            label22.Size = new Size(74, 16);
            label22.TabIndex = 15;
            label22.Text = "Last Name";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label21.Location = new Point(213, 27);
            label21.Margin = new Padding(3, 0, 3, 4);
            label21.Name = "label21";
            label21.Size = new Size(88, 16);
            label21.TabIndex = 14;
            label21.Text = "Middle Name";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(619, 27);
            label9.Margin = new Padding(3, 0, 3, 4);
            label9.Name = "label9";
            label9.Size = new Size(41, 16);
            label9.TabIndex = 13;
            label9.Text = "Suffix";
            // 
            // cmbGender
            // 
            cmbGender.AccessibleName = "Gender";
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { "(Choose Gender)", "Male", "Female" });
            cmbGender.Location = new Point(822, 50);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(197, 26);
            cmbGender.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(822, 27);
            label2.Margin = new Padding(3, 0, 0, 4);
            label2.Name = "label2";
            label2.Size = new Size(55, 16);
            label2.TabIndex = 5;
            label2.Text = "Gender";
            // 
            // cmbSuffix
            // 
            cmbSuffix.AccessibleName = "Suffix";
            cmbSuffix.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSuffix.FormattingEnabled = true;
            cmbSuffix.Location = new Point(619, 50);
            cmbSuffix.Name = "cmbSuffix";
            cmbSuffix.Size = new Size(197, 26);
            cmbSuffix.TabIndex = 3;
            // 
            // txtMiddleName
            // 
            txtMiddleName.AccessibleName = "Middle Name";
            txtMiddleName.Location = new Point(213, 50);
            txtMiddleName.MaxLength = 50;
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(197, 26);
            txtMiddleName.TabIndex = 1;
            // 
            // txtLastName
            // 
            txtLastName.AccessibleName = "Last Name";
            txtLastName.Location = new Point(416, 50);
            txtLastName.MaxLength = 50;
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(197, 26);
            txtLastName.TabIndex = 2;
            // 
            // txtFirstName
            // 
            txtFirstName.AccessibleName = "First Name";
            txtFirstName.Location = new Point(10, 50);
            txtFirstName.Margin = new Padding(7, 3, 3, 16);
            txtFirstName.MaxLength = 50;
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(197, 26);
            txtFirstName.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(10, 27);
            label1.Margin = new Padding(3, 0, 0, 4);
            label1.Name = "label1";
            label1.Size = new Size(75, 16);
            label1.TabIndex = 0;
            label1.Text = "First Name";
            // 
            // pnlFooter
            // 
            pnlFooter.Controls.Add(flowControls);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 694);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1061, 60);
            pnlFooter.TabIndex = 3;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label26.ForeColor = Color.Red;
            label26.Location = new Point(660, 25);
            label26.Margin = new Padding(0, 0, 0, 4);
            label26.Name = "label26";
            label26.Size = new Size(14, 18);
            label26.TabIndex = 19;
            label26.Text = "*";
            // 
            // frmNewEntryEmployee
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1061, 754);
            Controls.Add(pnlMain);
            Controls.Add(pnlFooter);
            Controls.Add(pnlLine1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "frmNewEntryEmployee";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Load += frmEmployeeDataEntry_Load;
            flowControls.ResumeLayout(false);
            flowControls.PerformLayout();
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            grpJobData.ResumeLayout(false);
            grpJobData.PerformLayout();
            grpPreviousWork.ResumeLayout(false);
            grpPreviousWork.PerformLayout();
            grpContactData.ResumeLayout(false);
            grpContactData.PerformLayout();
            grpPersonalData.ResumeLayout(false);
            grpPersonalData.PerformLayout();
            pnlFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLine1;
        private FlowLayoutPanel flowControls;
        private Button btnConfirm;
        private Button btnCancel;
        private Panel pnlMain;
        private GroupBox grpPersonalData;
        private TextBox txtFirstName;
        private Label label1;
        private ComboBox cmbSuffix;
        private TextBox txtMiddleName;
        private TextBox txtLastName;
        private ComboBox cmbGender;
        private Label label2;
        private GroupBox grpContactData;
        private TextBox txtEmailAddress2;
        private TextBox txtEmailAddress1;
        private Label label10;
        private GroupBox grpJobData;
        private Label label8;
        private TextBox txtContactNumber2;
        private TextBox txtContactNumber1;
        private Label label6;
        private ComboBox cmbPosition;
        private Label label7;
        private Label label9;
        private TextBox txtEmployeeID;
        private Label label13;
        private TextBox txtPositionTitle;
        private Label label14;
        private TextBox txtRemarks;
        private Label label15;
        private CheckBox chkPreviousEmployee;
        private GroupBox grpPreviousWork;
        private TextBox txtPreviousPosition;
        private Label label16;
        private TextBox txtOtherInformation;
        private Label label19;
        private Label label18;
        private DateTimePicker dtpToDate;
        private Label label17;
        private DateTimePicker dtpFromDate;
        private Label label20;
        private ComboBox cmbLocation;
        private ComboBox cmbDepartment;
        private Label label28;
        private Label label27;
        private Label label25;
        private Label label24;
        private Label label23;
        private Label label22;
        private Label label21;
        private Label label30;
        private Label label29;
        private Panel pnlFooter;
        private Label label31;
        private DateTimePicker dtpStartDate;
        private Label label11;
        private Label label33;
        private Panel pnlLine2;
        private Label label34;
        private ComboBox cmbWageType;
        private Label label35;
        private ComboBox cmbClassification;
        private Label label3;
        private Label label5;
        private ComboBox cmbEmploymentStatus;
        private Label label4;
        private Label label12;
        private Label label26;
    }
}