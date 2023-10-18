namespace LBPRDC.Source.Views.Employee
{
    partial class frmSettingsEmployee
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
            tabControl1 = new TabControl();
            tabFilterSettings = new TabPage();
            label2 = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            chkFilterDepartment = new CheckBox();
            cmbFilterDepartment = new ComboBox();
            chkFilterSection = new CheckBox();
            cmbFilterSection = new ComboBox();
            chkFilterPosition = new CheckBox();
            cmbFilterPosition = new ComboBox();
            chkFilterCivilStatus = new CheckBox();
            cmbFilterCivilStatus = new ComboBox();
            chkFilterGender = new CheckBox();
            cmbFilterGender = new ComboBox();
            chkFilterEmploymentStatus = new CheckBox();
            cmbFilterEmploymentStatus = new ComboBox();
            tabTableSettings = new TabPage();
            flowLayoutPanel1 = new FlowLayoutPanel();
            chkEmployeeID = new CheckBox();
            chkName = new CheckBox();
            flowRadioGroupForName = new FlowLayoutPanel();
            rdbName1 = new RadioButton();
            rdbName2 = new RadioButton();
            rdbName3 = new RadioButton();
            rdbName4 = new RadioButton();
            rdbName5 = new RadioButton();
            chkGender = new CheckBox();
            chkBirthday = new CheckBox();
            chkEducation = new CheckBox();
            chkCivilStatus = new CheckBox();
            chkDepartment = new CheckBox();
            chkSection = new CheckBox();
            chkEmailAddress = new CheckBox();
            flowRadioGroupForEmail = new FlowLayoutPanel();
            rdbEmail1 = new RadioButton();
            rdbEmail2 = new RadioButton();
            chkContactNumber = new CheckBox();
            flowRadioGroupForContact = new FlowLayoutPanel();
            rdbContact1 = new RadioButton();
            rdbContact2 = new RadioButton();
            chkPosition = new CheckBox();
            flowRadioGroupForPosition = new FlowLayoutPanel();
            rdbPosition1 = new RadioButton();
            rdbPosition2 = new RadioButton();
            rdbPosition3 = new RadioButton();
            chkSalaryRate = new CheckBox();
            chkBillingRate = new CheckBox();
            chkEmploymentStatus = new CheckBox();
            label1 = new Label();
            flowControls = new FlowLayoutPanel();
            btnApply = new Button();
            btnCancel = new Button();
            tabControl1.SuspendLayout();
            tabFilterSettings.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            tabTableSettings.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowRadioGroupForName.SuspendLayout();
            flowRadioGroupForEmail.SuspendLayout();
            flowRadioGroupForContact.SuspendLayout();
            flowRadioGroupForPosition.SuspendLayout();
            flowControls.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabFilterSettings);
            tabControl1.Controls.Add(tabTableSettings);
            tabControl1.Location = new Point(9, 9);
            tabControl1.Margin = new Padding(0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(370, 406);
            tabControl1.TabIndex = 0;
            // 
            // tabFilterSettings
            // 
            tabFilterSettings.AutoScroll = true;
            tabFilterSettings.BackColor = Color.White;
            tabFilterSettings.BorderStyle = BorderStyle.FixedSingle;
            tabFilterSettings.Controls.Add(label2);
            tabFilterSettings.Controls.Add(flowLayoutPanel2);
            tabFilterSettings.Location = new Point(4, 27);
            tabFilterSettings.Name = "tabFilterSettings";
            tabFilterSettings.Padding = new Padding(8);
            tabFilterSettings.Size = new Size(362, 375);
            tabFilterSettings.TabIndex = 1;
            tabFilterSettings.Text = "Filters";
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Location = new Point(8, 8);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(327, 21);
            label2.TabIndex = 1;
            label2.Text = "Options:";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(chkFilterDepartment);
            flowLayoutPanel2.Controls.Add(cmbFilterDepartment);
            flowLayoutPanel2.Controls.Add(chkFilterSection);
            flowLayoutPanel2.Controls.Add(cmbFilterSection);
            flowLayoutPanel2.Controls.Add(chkFilterPosition);
            flowLayoutPanel2.Controls.Add(cmbFilterPosition);
            flowLayoutPanel2.Controls.Add(chkFilterCivilStatus);
            flowLayoutPanel2.Controls.Add(cmbFilterCivilStatus);
            flowLayoutPanel2.Controls.Add(chkFilterGender);
            flowLayoutPanel2.Controls.Add(cmbFilterGender);
            flowLayoutPanel2.Controls.Add(chkFilterEmploymentStatus);
            flowLayoutPanel2.Controls.Add(cmbFilterEmploymentStatus);
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.Location = new Point(11, 29);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Padding = new Padding(0, 8, 0, 0);
            flowLayoutPanel2.Size = new Size(321, 382);
            flowLayoutPanel2.TabIndex = 0;
            // 
            // chkFilterDepartment
            // 
            chkFilterDepartment.AutoSize = true;
            chkFilterDepartment.Location = new Point(3, 11);
            chkFilterDepartment.Name = "chkFilterDepartment";
            chkFilterDepartment.Size = new Size(109, 22);
            chkFilterDepartment.TabIndex = 24;
            chkFilterDepartment.Tag = "cmbFilterDepartment";
            chkFilterDepartment.Text = "Department";
            chkFilterDepartment.UseVisualStyleBackColor = true;
            chkFilterDepartment.CheckedChanged += chkFilterDepartment_CheckedChanged;
            // 
            // cmbFilterDepartment
            // 
            cmbFilterDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterDepartment.Enabled = false;
            cmbFilterDepartment.FormattingEnabled = true;
            cmbFilterDepartment.Location = new Point(3, 36);
            cmbFilterDepartment.Margin = new Padding(3, 0, 0, 8);
            cmbFilterDepartment.Name = "cmbFilterDepartment";
            cmbFilterDepartment.Size = new Size(315, 26);
            cmbFilterDepartment.TabIndex = 1;
            // 
            // chkFilterSection
            // 
            chkFilterSection.AutoSize = true;
            chkFilterSection.Location = new Point(3, 73);
            chkFilterSection.Name = "chkFilterSection";
            chkFilterSection.Size = new Size(80, 22);
            chkFilterSection.TabIndex = 34;
            chkFilterSection.Tag = "cmbFilterSection";
            chkFilterSection.Text = "Section";
            chkFilterSection.UseVisualStyleBackColor = true;
            chkFilterSection.CheckedChanged += chkFilterSection_CheckedChanged;
            // 
            // cmbFilterSection
            // 
            cmbFilterSection.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterSection.Enabled = false;
            cmbFilterSection.FormattingEnabled = true;
            cmbFilterSection.Location = new Point(3, 98);
            cmbFilterSection.Margin = new Padding(3, 0, 0, 8);
            cmbFilterSection.Name = "cmbFilterSection";
            cmbFilterSection.Size = new Size(315, 26);
            cmbFilterSection.TabIndex = 33;
            // 
            // chkFilterPosition
            // 
            chkFilterPosition.AutoSize = true;
            chkFilterPosition.Location = new Point(3, 135);
            chkFilterPosition.Name = "chkFilterPosition";
            chkFilterPosition.Size = new Size(84, 22);
            chkFilterPosition.TabIndex = 26;
            chkFilterPosition.Tag = "cmbFilterPosition";
            chkFilterPosition.Text = "Position";
            chkFilterPosition.UseVisualStyleBackColor = true;
            chkFilterPosition.CheckedChanged += chkFilterPosition_CheckedChanged;
            // 
            // cmbFilterPosition
            // 
            cmbFilterPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterPosition.Enabled = false;
            cmbFilterPosition.FormattingEnabled = true;
            cmbFilterPosition.Location = new Point(3, 160);
            cmbFilterPosition.Margin = new Padding(3, 0, 0, 8);
            cmbFilterPosition.Name = "cmbFilterPosition";
            cmbFilterPosition.Size = new Size(315, 26);
            cmbFilterPosition.TabIndex = 25;
            // 
            // chkFilterCivilStatus
            // 
            chkFilterCivilStatus.AutoSize = true;
            chkFilterCivilStatus.Location = new Point(3, 197);
            chkFilterCivilStatus.Name = "chkFilterCivilStatus";
            chkFilterCivilStatus.Size = new Size(105, 22);
            chkFilterCivilStatus.TabIndex = 28;
            chkFilterCivilStatus.Tag = "cmbFilterCivilStatus";
            chkFilterCivilStatus.Text = "Civil Status";
            chkFilterCivilStatus.UseVisualStyleBackColor = true;
            chkFilterCivilStatus.CheckedChanged += chkFilterCivilStatus_CheckedChanged;
            // 
            // cmbFilterCivilStatus
            // 
            cmbFilterCivilStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterCivilStatus.Enabled = false;
            cmbFilterCivilStatus.FormattingEnabled = true;
            cmbFilterCivilStatus.Location = new Point(3, 222);
            cmbFilterCivilStatus.Margin = new Padding(3, 0, 0, 8);
            cmbFilterCivilStatus.Name = "cmbFilterCivilStatus";
            cmbFilterCivilStatus.Size = new Size(315, 26);
            cmbFilterCivilStatus.TabIndex = 27;
            // 
            // chkFilterGender
            // 
            chkFilterGender.AutoSize = true;
            chkFilterGender.Location = new Point(3, 259);
            chkFilterGender.Name = "chkFilterGender";
            chkFilterGender.Size = new Size(79, 22);
            chkFilterGender.TabIndex = 30;
            chkFilterGender.Tag = "cmbFilterGender";
            chkFilterGender.Text = "Gender";
            chkFilterGender.UseVisualStyleBackColor = true;
            chkFilterGender.CheckedChanged += chkFilterGender_CheckedChanged;
            // 
            // cmbFilterGender
            // 
            cmbFilterGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterGender.Enabled = false;
            cmbFilterGender.FormattingEnabled = true;
            cmbFilterGender.Items.AddRange(new object[] { "(Choose Gender)", "MALE", "FEMALE" });
            cmbFilterGender.Location = new Point(3, 284);
            cmbFilterGender.Margin = new Padding(3, 0, 0, 8);
            cmbFilterGender.Name = "cmbFilterGender";
            cmbFilterGender.Size = new Size(315, 26);
            cmbFilterGender.TabIndex = 29;
            // 
            // chkFilterEmploymentStatus
            // 
            chkFilterEmploymentStatus.AutoSize = true;
            chkFilterEmploymentStatus.Location = new Point(3, 321);
            chkFilterEmploymentStatus.Name = "chkFilterEmploymentStatus";
            chkFilterEmploymentStatus.Size = new Size(161, 22);
            chkFilterEmploymentStatus.TabIndex = 32;
            chkFilterEmploymentStatus.Tag = "cmbFilterEmploymentStatus";
            chkFilterEmploymentStatus.Text = "Employment Status";
            chkFilterEmploymentStatus.UseVisualStyleBackColor = true;
            chkFilterEmploymentStatus.CheckedChanged += chkFilterEmploymentStatus_CheckedChanged;
            // 
            // cmbFilterEmploymentStatus
            // 
            cmbFilterEmploymentStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterEmploymentStatus.Enabled = false;
            cmbFilterEmploymentStatus.FormattingEnabled = true;
            cmbFilterEmploymentStatus.Location = new Point(3, 346);
            cmbFilterEmploymentStatus.Margin = new Padding(3, 0, 0, 8);
            cmbFilterEmploymentStatus.Name = "cmbFilterEmploymentStatus";
            cmbFilterEmploymentStatus.Size = new Size(315, 26);
            cmbFilterEmploymentStatus.TabIndex = 31;
            // 
            // tabTableSettings
            // 
            tabTableSettings.AutoScroll = true;
            tabTableSettings.BackColor = Color.White;
            tabTableSettings.BorderStyle = BorderStyle.FixedSingle;
            tabTableSettings.Controls.Add(flowLayoutPanel1);
            tabTableSettings.Controls.Add(label1);
            tabTableSettings.Location = new Point(4, 24);
            tabTableSettings.Name = "tabTableSettings";
            tabTableSettings.Padding = new Padding(8);
            tabTableSettings.Size = new Size(362, 378);
            tabTableSettings.TabIndex = 0;
            tabTableSettings.Text = "Columns";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(chkEmployeeID);
            flowLayoutPanel1.Controls.Add(chkName);
            flowLayoutPanel1.Controls.Add(flowRadioGroupForName);
            flowLayoutPanel1.Controls.Add(chkGender);
            flowLayoutPanel1.Controls.Add(chkBirthday);
            flowLayoutPanel1.Controls.Add(chkEducation);
            flowLayoutPanel1.Controls.Add(chkCivilStatus);
            flowLayoutPanel1.Controls.Add(chkDepartment);
            flowLayoutPanel1.Controls.Add(chkSection);
            flowLayoutPanel1.Controls.Add(chkEmailAddress);
            flowLayoutPanel1.Controls.Add(flowRadioGroupForEmail);
            flowLayoutPanel1.Controls.Add(chkContactNumber);
            flowLayoutPanel1.Controls.Add(flowRadioGroupForContact);
            flowLayoutPanel1.Controls.Add(chkPosition);
            flowLayoutPanel1.Controls.Add(flowRadioGroupForPosition);
            flowLayoutPanel1.Controls.Add(chkSalaryRate);
            flowLayoutPanel1.Controls.Add(chkBillingRate);
            flowLayoutPanel1.Controls.Add(chkEmploymentStatus);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(11, 29);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(0, 8, 0, 0);
            flowLayoutPanel1.Size = new Size(321, 739);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // chkEmployeeID
            // 
            chkEmployeeID.AutoSize = true;
            chkEmployeeID.Enabled = false;
            chkEmployeeID.Location = new Point(3, 11);
            chkEmployeeID.Name = "chkEmployeeID";
            chkEmployeeID.Size = new Size(116, 22);
            chkEmployeeID.TabIndex = 23;
            chkEmployeeID.Text = "Employee ID";
            chkEmployeeID.UseVisualStyleBackColor = true;
            // 
            // chkName
            // 
            chkName.AutoSize = true;
            chkName.Location = new Point(3, 39);
            chkName.Name = "chkName";
            chkName.Size = new Size(69, 22);
            chkName.TabIndex = 1;
            chkName.Tag = "flowRadioGroupForName";
            chkName.Text = "Name";
            chkName.UseVisualStyleBackColor = true;
            chkName.CheckedChanged += chkName_CheckedChanged;
            // 
            // flowRadioGroupForName
            // 
            flowRadioGroupForName.Controls.Add(rdbName1);
            flowRadioGroupForName.Controls.Add(rdbName2);
            flowRadioGroupForName.Controls.Add(rdbName3);
            flowRadioGroupForName.Controls.Add(rdbName4);
            flowRadioGroupForName.Controls.Add(rdbName5);
            flowRadioGroupForName.FlowDirection = FlowDirection.TopDown;
            flowRadioGroupForName.Location = new Point(19, 64);
            flowRadioGroupForName.Margin = new Padding(19, 0, 3, 0);
            flowRadioGroupForName.Name = "flowRadioGroupForName";
            flowRadioGroupForName.Size = new Size(251, 140);
            flowRadioGroupForName.TabIndex = 24;
            // 
            // rdbName1
            // 
            rdbName1.AccessibleName = "Full1";
            rdbName1.AutoSize = true;
            rdbName1.Location = new Point(3, 3);
            rdbName1.Name = "rdbName1";
            rdbName1.Size = new Size(214, 22);
            rdbName1.TabIndex = 14;
            rdbName1.TabStop = true;
            rdbName1.Text = "Full name (John C. Doe Jr.)";
            rdbName1.UseVisualStyleBackColor = true;
            // 
            // rdbName2
            // 
            rdbName2.AccessibleName = "Full2";
            rdbName2.AutoSize = true;
            rdbName2.Location = new Point(3, 31);
            rdbName2.Name = "rdbName2";
            rdbName2.Size = new Size(214, 22);
            rdbName2.TabIndex = 10;
            rdbName2.TabStop = true;
            rdbName2.Text = "Full name (Doe, John C Jr.)";
            rdbName2.UseVisualStyleBackColor = true;
            // 
            // rdbName3
            // 
            rdbName3.AccessibleName = "FirstAndLastOnly";
            rdbName3.AutoSize = true;
            rdbName3.Location = new Point(3, 59);
            rdbName3.Name = "rdbName3";
            rdbName3.Size = new Size(238, 22);
            rdbName3.TabIndex = 15;
            rdbName3.TabStop = true;
            rdbName3.Text = "First name and Last name only";
            rdbName3.UseVisualStyleBackColor = true;
            // 
            // rdbName4
            // 
            rdbName4.AccessibleName = "LastNameOnly";
            rdbName4.AutoSize = true;
            rdbName4.Location = new Point(3, 87);
            rdbName4.Name = "rdbName4";
            rdbName4.Size = new Size(130, 22);
            rdbName4.TabIndex = 16;
            rdbName4.TabStop = true;
            rdbName4.Text = "Last name only";
            rdbName4.UseVisualStyleBackColor = true;
            // 
            // rdbName5
            // 
            rdbName5.AccessibleName = "Separated";
            rdbName5.AutoSize = true;
            rdbName5.Location = new Point(3, 115);
            rdbName5.Name = "rdbName5";
            rdbName5.Size = new Size(210, 22);
            rdbName5.TabIndex = 11;
            rdbName5.TabStop = true;
            rdbName5.Text = "Each on their own columns";
            rdbName5.UseVisualStyleBackColor = true;
            // 
            // chkGender
            // 
            chkGender.AutoSize = true;
            chkGender.Location = new Point(3, 207);
            chkGender.Name = "chkGender";
            chkGender.Size = new Size(79, 22);
            chkGender.TabIndex = 2;
            chkGender.Text = "Gender";
            chkGender.UseVisualStyleBackColor = true;
            // 
            // chkBirthday
            // 
            chkBirthday.AutoSize = true;
            chkBirthday.Location = new Point(3, 235);
            chkBirthday.Name = "chkBirthday";
            chkBirthday.Size = new Size(84, 22);
            chkBirthday.TabIndex = 3;
            chkBirthday.Text = "Birthday";
            chkBirthday.UseVisualStyleBackColor = true;
            // 
            // chkEducation
            // 
            chkEducation.AutoSize = true;
            chkEducation.Location = new Point(3, 263);
            chkEducation.Name = "chkEducation";
            chkEducation.Size = new Size(97, 22);
            chkEducation.TabIndex = 4;
            chkEducation.Text = "Education";
            chkEducation.UseVisualStyleBackColor = true;
            // 
            // chkCivilStatus
            // 
            chkCivilStatus.AutoSize = true;
            chkCivilStatus.Location = new Point(3, 291);
            chkCivilStatus.Name = "chkCivilStatus";
            chkCivilStatus.Size = new Size(105, 22);
            chkCivilStatus.TabIndex = 21;
            chkCivilStatus.Text = "Civil Status";
            chkCivilStatus.UseVisualStyleBackColor = true;
            // 
            // chkDepartment
            // 
            chkDepartment.AutoSize = true;
            chkDepartment.Location = new Point(3, 319);
            chkDepartment.Name = "chkDepartment";
            chkDepartment.Size = new Size(109, 22);
            chkDepartment.TabIndex = 7;
            chkDepartment.Text = "Department";
            chkDepartment.UseVisualStyleBackColor = true;
            // 
            // chkSection
            // 
            chkSection.AutoSize = true;
            chkSection.Location = new Point(3, 347);
            chkSection.Name = "chkSection";
            chkSection.Size = new Size(80, 22);
            chkSection.TabIndex = 30;
            chkSection.Text = "Section";
            chkSection.UseVisualStyleBackColor = true;
            // 
            // chkEmailAddress
            // 
            chkEmailAddress.AutoSize = true;
            chkEmailAddress.Location = new Point(3, 375);
            chkEmailAddress.Name = "chkEmailAddress";
            chkEmailAddress.Size = new Size(128, 22);
            chkEmailAddress.TabIndex = 5;
            chkEmailAddress.Tag = "flowRadioGroupForEmail";
            chkEmailAddress.Text = "Email address";
            chkEmailAddress.UseVisualStyleBackColor = true;
            chkEmailAddress.CheckedChanged += chkEmailAddress_CheckedChanged;
            // 
            // flowRadioGroupForEmail
            // 
            flowRadioGroupForEmail.Controls.Add(rdbEmail1);
            flowRadioGroupForEmail.Controls.Add(rdbEmail2);
            flowRadioGroupForEmail.Location = new Point(19, 400);
            flowRadioGroupForEmail.Margin = new Padding(19, 0, 0, 0);
            flowRadioGroupForEmail.Name = "flowRadioGroupForEmail";
            flowRadioGroupForEmail.Size = new Size(200, 56);
            flowRadioGroupForEmail.TabIndex = 25;
            // 
            // rdbEmail1
            // 
            rdbEmail1.AccessibleName = "FirstOnly";
            rdbEmail1.AutoSize = true;
            rdbEmail1.Location = new Point(3, 3);
            rdbEmail1.Name = "rdbEmail1";
            rdbEmail1.Size = new Size(191, 22);
            rdbEmail1.TabIndex = 8;
            rdbEmail1.TabStop = true;
            rdbEmail1.Text = "First email address only";
            rdbEmail1.UseVisualStyleBackColor = true;
            // 
            // rdbEmail2
            // 
            rdbEmail2.AccessibleName = "Both";
            rdbEmail2.AutoSize = true;
            rdbEmail2.Location = new Point(3, 31);
            rdbEmail2.Name = "rdbEmail2";
            rdbEmail2.Size = new Size(99, 22);
            rdbEmail2.TabIndex = 9;
            rdbEmail2.TabStop = true;
            rdbEmail2.Text = "Show both";
            rdbEmail2.UseVisualStyleBackColor = true;
            // 
            // chkContactNumber
            // 
            chkContactNumber.AutoSize = true;
            chkContactNumber.Location = new Point(3, 459);
            chkContactNumber.Name = "chkContactNumber";
            chkContactNumber.Size = new Size(137, 22);
            chkContactNumber.TabIndex = 6;
            chkContactNumber.Tag = "flowRadioGroupForContact";
            chkContactNumber.Text = "Contact number";
            chkContactNumber.UseVisualStyleBackColor = true;
            chkContactNumber.CheckedChanged += chkContactNumber_CheckedChanged;
            // 
            // flowRadioGroupForContact
            // 
            flowRadioGroupForContact.Controls.Add(rdbContact1);
            flowRadioGroupForContact.Controls.Add(rdbContact2);
            flowRadioGroupForContact.FlowDirection = FlowDirection.TopDown;
            flowRadioGroupForContact.Location = new Point(19, 484);
            flowRadioGroupForContact.Margin = new Padding(19, 0, 0, 0);
            flowRadioGroupForContact.Name = "flowRadioGroupForContact";
            flowRadioGroupForContact.Size = new Size(200, 56);
            flowRadioGroupForContact.TabIndex = 26;
            // 
            // rdbContact1
            // 
            rdbContact1.AccessibleName = "FirstOnly";
            rdbContact1.AutoSize = true;
            rdbContact1.Location = new Point(3, 3);
            rdbContact1.Name = "rdbContact1";
            rdbContact1.Size = new Size(198, 22);
            rdbContact1.TabIndex = 12;
            rdbContact1.TabStop = true;
            rdbContact1.Text = "First contact number only";
            rdbContact1.UseVisualStyleBackColor = true;
            // 
            // rdbContact2
            // 
            rdbContact2.AccessibleName = "Both";
            rdbContact2.AutoSize = true;
            rdbContact2.Location = new Point(3, 31);
            rdbContact2.Name = "rdbContact2";
            rdbContact2.Size = new Size(99, 22);
            rdbContact2.TabIndex = 13;
            rdbContact2.TabStop = true;
            rdbContact2.Text = "Show both";
            rdbContact2.UseVisualStyleBackColor = true;
            // 
            // chkPosition
            // 
            chkPosition.AutoSize = true;
            chkPosition.Location = new Point(3, 543);
            chkPosition.Name = "chkPosition";
            chkPosition.Size = new Size(84, 22);
            chkPosition.TabIndex = 17;
            chkPosition.Tag = "flowRadioGroupForPosition";
            chkPosition.Text = "Position";
            chkPosition.UseVisualStyleBackColor = true;
            chkPosition.CheckedChanged += chkPosition_CheckedChanged;
            // 
            // flowRadioGroupForPosition
            // 
            flowRadioGroupForPosition.Controls.Add(rdbPosition1);
            flowRadioGroupForPosition.Controls.Add(rdbPosition2);
            flowRadioGroupForPosition.Controls.Add(rdbPosition3);
            flowRadioGroupForPosition.FlowDirection = FlowDirection.TopDown;
            flowRadioGroupForPosition.Location = new Point(19, 568);
            flowRadioGroupForPosition.Margin = new Padding(19, 0, 0, 0);
            flowRadioGroupForPosition.Name = "flowRadioGroupForPosition";
            flowRadioGroupForPosition.Size = new Size(200, 84);
            flowRadioGroupForPosition.TabIndex = 27;
            // 
            // rdbPosition1
            // 
            rdbPosition1.AccessibleName = "NameOnly";
            rdbPosition1.AutoSize = true;
            rdbPosition1.Location = new Point(3, 3);
            rdbPosition1.Name = "rdbPosition1";
            rdbPosition1.Size = new Size(99, 22);
            rdbPosition1.TabIndex = 19;
            rdbPosition1.TabStop = true;
            rdbPosition1.Text = "Name only";
            rdbPosition1.UseVisualStyleBackColor = true;
            // 
            // rdbPosition2
            // 
            rdbPosition2.AccessibleName = "CodeOnly";
            rdbPosition2.AutoSize = true;
            rdbPosition2.Location = new Point(3, 31);
            rdbPosition2.Name = "rdbPosition2";
            rdbPosition2.Size = new Size(96, 22);
            rdbPosition2.TabIndex = 18;
            rdbPosition2.TabStop = true;
            rdbPosition2.Text = "Code only";
            rdbPosition2.UseVisualStyleBackColor = true;
            // 
            // rdbPosition3
            // 
            rdbPosition3.AccessibleName = "Both";
            rdbPosition3.AutoSize = true;
            rdbPosition3.Location = new Point(3, 59);
            rdbPosition3.Name = "rdbPosition3";
            rdbPosition3.Size = new Size(99, 22);
            rdbPosition3.TabIndex = 20;
            rdbPosition3.TabStop = true;
            rdbPosition3.Text = "Show both";
            rdbPosition3.UseVisualStyleBackColor = true;
            // 
            // chkSalaryRate
            // 
            chkSalaryRate.AutoSize = true;
            chkSalaryRate.Location = new Point(3, 655);
            chkSalaryRate.Name = "chkSalaryRate";
            chkSalaryRate.Size = new Size(108, 22);
            chkSalaryRate.TabIndex = 28;
            chkSalaryRate.Text = "Salary Rate";
            chkSalaryRate.UseVisualStyleBackColor = true;
            // 
            // chkBillingRate
            // 
            chkBillingRate.AutoSize = true;
            chkBillingRate.Location = new Point(3, 683);
            chkBillingRate.Name = "chkBillingRate";
            chkBillingRate.Size = new Size(102, 22);
            chkBillingRate.TabIndex = 29;
            chkBillingRate.Text = "BillingRate";
            chkBillingRate.UseVisualStyleBackColor = true;
            // 
            // chkEmploymentStatus
            // 
            chkEmploymentStatus.AutoSize = true;
            chkEmploymentStatus.Location = new Point(3, 711);
            chkEmploymentStatus.Name = "chkEmploymentStatus";
            chkEmploymentStatus.Size = new Size(161, 22);
            chkEmploymentStatus.TabIndex = 22;
            chkEmploymentStatus.Text = "Employment Status";
            chkEmploymentStatus.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(8, 8);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(327, 21);
            label1.TabIndex = 0;
            label1.Text = "Please select the information you want to see:";
            // 
            // flowControls
            // 
            flowControls.Controls.Add(btnApply);
            flowControls.Controls.Add(btnCancel);
            flowControls.Dock = DockStyle.Bottom;
            flowControls.FlowDirection = FlowDirection.RightToLeft;
            flowControls.Location = new Point(0, 411);
            flowControls.Name = "flowControls";
            flowControls.Padding = new Padding(11, 11, 0, 11);
            flowControls.Size = new Size(387, 50);
            flowControls.TabIndex = 1;
            // 
            // btnApply
            // 
            btnApply.AutoSize = true;
            btnApply.Location = new Point(301, 11);
            btnApply.Margin = new Padding(4, 0, 0, 0);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(75, 28);
            btnApply.TabIndex = 0;
            btnApply.Text = "Apply";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.Location = new Point(222, 11);
            btnCancel.Margin = new Padding(0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 28);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmSettingsEmployee
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Control;
            ClientSize = new Size(387, 461);
            Controls.Add(flowControls);
            Controls.Add(tabControl1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "frmSettingsEmployee";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            tabControl1.ResumeLayout(false);
            tabFilterSettings.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            tabTableSettings.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowRadioGroupForName.ResumeLayout(false);
            flowRadioGroupForName.PerformLayout();
            flowRadioGroupForEmail.ResumeLayout(false);
            flowRadioGroupForEmail.PerformLayout();
            flowRadioGroupForContact.ResumeLayout(false);
            flowRadioGroupForContact.PerformLayout();
            flowRadioGroupForPosition.ResumeLayout(false);
            flowRadioGroupForPosition.PerformLayout();
            flowControls.ResumeLayout(false);
            flowControls.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabTableSettings;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private CheckBox chkName;
        private CheckBox chkGender;
        private CheckBox chkBirthday;
        private CheckBox chkEducation;
        private CheckBox chkEmailAddress;
        private CheckBox chkContactNumber;
        private CheckBox chkDepartment;
        private RadioButton rdbEmail1;
        private RadioButton rdbName2;
        private RadioButton rdbName5;
        private RadioButton rdbEmail2;
        private RadioButton rdbContact1;
        private RadioButton rdbContact2;
        private RadioButton rdbName1;
        private RadioButton rdbName3;
        private RadioButton rdbName4;
        private CheckBox chkPosition;
        private RadioButton rdbPosition1;
        private RadioButton rdbPosition2;
        private RadioButton rdbPosition3;
        private CheckBox chkCivilStatus;
        private CheckBox chkEmploymentStatus;
        private FlowLayoutPanel flowControls;
        private Button btnApply;
        private Button btnCancel;
        private CheckBox chkEmployeeID;
        private FlowLayoutPanel flowRadioGroupForName;
        private FlowLayoutPanel flowRadioGroupForEmail;
        private FlowLayoutPanel flowRadioGroupForContact;
        private FlowLayoutPanel flowRadioGroupForPosition;
        private CheckBox chkSalaryRate;
        private CheckBox chkBillingRate;
        private TabPage tabFilterSettings;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label3;
        private ComboBox cmbFilterDepartment;
        private CheckBox chkFilterDepartment;
        private CheckBox chkFilterPosition;
        private ComboBox cmbFilterPosition;
        private CheckBox chkFilterCivilStatus;
        private ComboBox cmbFilterCivilStatus;
        private CheckBox chkFilterGender;
        private ComboBox cmbFilterGender;
        private CheckBox chkFilterEmploymentStatus;
        private ComboBox cmbFilterEmploymentStatus;
        private Label label4;
        private ComboBox comboBox2;
        private Label label5;
        private Label label6;
        private Label label7;
        private CheckBox chkSection;
        private CheckBox chkFilterSection;
        private ComboBox cmbFilterSection;
    }
}