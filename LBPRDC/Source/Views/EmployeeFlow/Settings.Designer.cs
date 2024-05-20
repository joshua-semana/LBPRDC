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
            chkDepartment = new CheckBox();
            chkLocation = new CheckBox();
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
            chkWageType = new CheckBox();
            chkSalaryRate = new CheckBox();
            chkBillingRate = new CheckBox();
            chkEmploymentStatus = new CheckBox();
            label1 = new Label();
            flowControls = new FlowLayoutPanel();
            btnApply = new Button();
            btnCancel = new Button();
            chkClassification = new CheckBox();
            tabControl1.SuspendLayout();
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
            tabControl1.Controls.Add(tabTableSettings);
            tabControl1.Location = new Point(9, 9);
            tabControl1.Margin = new Padding(0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(370, 489);
            tabControl1.TabIndex = 0;
            // 
            // tabTableSettings
            // 
            tabTableSettings.AutoScroll = true;
            tabTableSettings.BackColor = Color.White;
            tabTableSettings.BorderStyle = BorderStyle.FixedSingle;
            tabTableSettings.Controls.Add(flowLayoutPanel1);
            tabTableSettings.Controls.Add(label1);
            tabTableSettings.Location = new Point(4, 27);
            tabTableSettings.Name = "tabTableSettings";
            tabTableSettings.Padding = new Padding(8);
            tabTableSettings.Size = new Size(362, 458);
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
            flowLayoutPanel1.Controls.Add(chkEmailAddress);
            flowLayoutPanel1.Controls.Add(flowRadioGroupForEmail);
            flowLayoutPanel1.Controls.Add(chkContactNumber);
            flowLayoutPanel1.Controls.Add(flowRadioGroupForContact);
            flowLayoutPanel1.Controls.Add(chkClassification);
            flowLayoutPanel1.Controls.Add(chkDepartment);
            flowLayoutPanel1.Controls.Add(chkLocation);
            flowLayoutPanel1.Controls.Add(chkPosition);
            flowLayoutPanel1.Controls.Add(flowRadioGroupForPosition);
            flowLayoutPanel1.Controls.Add(chkWageType);
            flowLayoutPanel1.Controls.Add(chkSalaryRate);
            flowLayoutPanel1.Controls.Add(chkBillingRate);
            flowLayoutPanel1.Controls.Add(chkEmploymentStatus);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(11, 29);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(0, 8, 0, 0);
            flowLayoutPanel1.Size = new Size(321, 731);
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
            chkGender.TabIndex = 4;
            chkGender.Text = "Gender";
            chkGender.UseVisualStyleBackColor = true;
            // 
            // chkDepartment
            // 
            chkDepartment.AutoSize = true;
            chkDepartment.Location = new Point(3, 431);
            chkDepartment.Name = "chkDepartment";
            chkDepartment.Size = new Size(109, 22);
            chkDepartment.TabIndex = 7;
            chkDepartment.Text = "Department";
            chkDepartment.UseVisualStyleBackColor = true;
            // 
            // chkLocation
            // 
            chkLocation.AutoSize = true;
            chkLocation.Location = new Point(3, 459);
            chkLocation.Name = "chkLocation";
            chkLocation.Size = new Size(87, 22);
            chkLocation.TabIndex = 30;
            chkLocation.Text = "Location";
            chkLocation.UseVisualStyleBackColor = true;
            // 
            // chkEmailAddress
            // 
            chkEmailAddress.AutoSize = true;
            chkEmailAddress.Location = new Point(3, 235);
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
            flowRadioGroupForEmail.Location = new Point(19, 260);
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
            chkContactNumber.Location = new Point(3, 319);
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
            flowRadioGroupForContact.Location = new Point(19, 344);
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
            chkPosition.Location = new Point(3, 487);
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
            flowRadioGroupForPosition.Location = new Point(19, 512);
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
            // chkWageType
            // 
            chkWageType.AutoSize = true;
            chkWageType.Location = new Point(3, 599);
            chkWageType.Name = "chkWageType";
            chkWageType.Size = new Size(105, 22);
            chkWageType.TabIndex = 31;
            chkWageType.Text = "Wage Type";
            chkWageType.UseVisualStyleBackColor = true;
            // 
            // chkSalaryRate
            // 
            chkSalaryRate.AutoSize = true;
            chkSalaryRate.Location = new Point(3, 627);
            chkSalaryRate.Name = "chkSalaryRate";
            chkSalaryRate.Size = new Size(108, 22);
            chkSalaryRate.TabIndex = 28;
            chkSalaryRate.Text = "Salary Rate";
            chkSalaryRate.UseVisualStyleBackColor = true;
            // 
            // chkBillingRate
            // 
            chkBillingRate.AutoSize = true;
            chkBillingRate.Location = new Point(3, 655);
            chkBillingRate.Name = "chkBillingRate";
            chkBillingRate.Size = new Size(106, 22);
            chkBillingRate.TabIndex = 29;
            chkBillingRate.Text = "Billing Rate";
            chkBillingRate.UseVisualStyleBackColor = true;
            // 
            // chkEmploymentStatus
            // 
            chkEmploymentStatus.AutoSize = true;
            chkEmploymentStatus.Location = new Point(3, 683);
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
            flowControls.Location = new Point(0, 494);
            flowControls.Name = "flowControls";
            flowControls.Padding = new Padding(11, 11, 0, 11);
            flowControls.Size = new Size(387, 50);
            flowControls.TabIndex = 1;
            // 
            // btnApply
            // 
            btnApply.AutoSize = true;
            btnApply.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
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
            btnCancel.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.Location = new Point(222, 11);
            btnCancel.Margin = new Padding(0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 28);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // chkClassification
            // 
            chkClassification.AutoSize = true;
            chkClassification.Location = new Point(3, 403);
            chkClassification.Name = "chkClassification";
            chkClassification.Size = new Size(121, 22);
            chkClassification.TabIndex = 32;
            chkClassification.Text = "Classification";
            chkClassification.UseVisualStyleBackColor = true;
            // 
            // frmSettingsEmployee
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Control;
            ClientSize = new Size(387, 544);
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
        private Label label3;
        private Label label4;
        private ComboBox comboBox2;
        private Label label5;
        private Label label6;
        private Label label7;
        private CheckBox chkLocation;
        private CheckBox chkWageType;
        private CheckBox chkClassification;
    }
}