namespace LBPRDC.Source.Views.Billing
{
    partial class InsertCustomEntryForm
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
            pnlFooter = new Panel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnInsert = new Button();
            btnCancel = new Button();
            pnlBody = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            pnlGroup1 = new Panel();
            label18 = new Label();
            label19 = new Label();
            txtEmployeeID = new TextBox();
            pnlGroup2 = new Panel();
            label4 = new Label();
            label3 = new Label();
            txtFirstName = new TextBox();
            pnlGroup3 = new Panel();
            label2 = new Label();
            txtMiddleName = new TextBox();
            pnlGroup4 = new Panel();
            label6 = new Label();
            label7 = new Label();
            txtLastName = new TextBox();
            pnlGroup5 = new Panel();
            label14 = new Label();
            label16 = new Label();
            txtSalaryRate = new TextBox();
            pnlGroup6 = new Panel();
            label8 = new Label();
            label9 = new Label();
            txtBillingRate = new TextBox();
            pnlGroup7 = new Panel();
            label13 = new Label();
            label12 = new Label();
            cmbLocation = new ComboBox();
            label10 = new Label();
            cmbDepartment = new ComboBox();
            label11 = new Label();
            pnlGroup8 = new Panel();
            label15 = new Label();
            cmbPosition = new ComboBox();
            label17 = new Label();
            pnlGroup9 = new Panel();
            lblCustomPositionAsterisk = new Label();
            chkCustomPosition = new CheckBox();
            txtCustomPosition = new TextBox();
            pnlLine2 = new Panel();
            label5 = new Label();
            pnlFooter.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            pnlBody.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            pnlGroup1.SuspendLayout();
            pnlGroup2.SuspendLayout();
            pnlGroup3.SuspendLayout();
            pnlGroup4.SuspendLayout();
            pnlGroup5.SuspendLayout();
            pnlGroup6.SuspendLayout();
            pnlGroup7.SuspendLayout();
            pnlGroup8.SuspendLayout();
            pnlGroup9.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLine1
            // 
            pnlLine1.BorderStyle = BorderStyle.FixedSingle;
            pnlLine1.Dock = DockStyle.Top;
            pnlLine1.Location = new Point(0, 0);
            pnlLine1.Name = "pnlLine1";
            pnlLine1.Size = new Size(434, 1);
            pnlLine1.TabIndex = 0;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = SystemColors.Control;
            pnlFooter.Controls.Add(flowLayoutPanel2);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 619);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(434, 46);
            pnlFooter.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(btnInsert);
            flowLayoutPanel2.Controls.Add(btnCancel);
            flowLayoutPanel2.Dock = DockStyle.Right;
            flowLayoutPanel2.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel2.Location = new Point(243, 0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Padding = new Padding(16, 9, 0, 0);
            flowLayoutPanel2.Size = new Size(191, 46);
            flowLayoutPanel2.TabIndex = 6;
            // 
            // btnInsert
            // 
            btnInsert.AutoSize = true;
            btnInsert.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnInsert.Location = new Point(100, 9);
            btnInsert.Margin = new Padding(8, 0, 0, 0);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(75, 28);
            btnInsert.TabIndex = 9;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.Location = new Point(17, 9);
            btnCancel.Margin = new Padding(8, 0, 0, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 28);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(flowLayoutPanel1);
            pnlBody.Controls.Add(pnlLine2);
            pnlBody.Controls.Add(label5);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 1);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(16);
            pnlBody.Size = new Size(434, 618);
            pnlBody.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(pnlGroup1);
            flowLayoutPanel1.Controls.Add(pnlGroup2);
            flowLayoutPanel1.Controls.Add(pnlGroup3);
            flowLayoutPanel1.Controls.Add(pnlGroup4);
            flowLayoutPanel1.Controls.Add(pnlGroup5);
            flowLayoutPanel1.Controls.Add(pnlGroup6);
            flowLayoutPanel1.Controls.Add(pnlGroup7);
            flowLayoutPanel1.Controls.Add(pnlGroup8);
            flowLayoutPanel1.Controls.Add(pnlGroup9);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(16, 60);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(403, 544);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // pnlGroup1
            // 
            pnlGroup1.AutoSize = true;
            pnlGroup1.Controls.Add(label18);
            pnlGroup1.Controls.Add(label19);
            pnlGroup1.Controls.Add(txtEmployeeID);
            pnlGroup1.Location = new Point(0, 0);
            pnlGroup1.Margin = new Padding(0, 0, 0, 16);
            pnlGroup1.Name = "pnlGroup1";
            pnlGroup1.Size = new Size(402, 46);
            pnlGroup1.TabIndex = 1;
            // 
            // label18
            // 
            label18.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label18.AutoSize = true;
            label18.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label18.ForeColor = Color.Red;
            label18.Location = new Point(83, 0);
            label18.Margin = new Padding(0);
            label18.Name = "label18";
            label18.Size = new Size(12, 16);
            label18.TabIndex = 21;
            label18.Text = "*";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label19.Location = new Point(0, 0);
            label19.Margin = new Padding(0, 0, 0, 4);
            label19.Name = "label19";
            label19.Size = new Size(86, 16);
            label19.TabIndex = 20;
            label19.Text = "Employee ID";
            // 
            // txtEmployeeID
            // 
            txtEmployeeID.AccessibleName = "Employee ID";
            txtEmployeeID.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmployeeID.Location = new Point(0, 20);
            txtEmployeeID.Margin = new Padding(0);
            txtEmployeeID.MaxLength = 100;
            txtEmployeeID.Name = "txtEmployeeID";
            txtEmployeeID.Size = new Size(402, 26);
            txtEmployeeID.TabIndex = 0;
            // 
            // pnlGroup2
            // 
            pnlGroup2.AutoSize = true;
            pnlGroup2.Controls.Add(label4);
            pnlGroup2.Controls.Add(label3);
            pnlGroup2.Controls.Add(txtFirstName);
            pnlGroup2.Location = new Point(0, 62);
            pnlGroup2.Margin = new Padding(0, 0, 0, 16);
            pnlGroup2.Name = "pnlGroup2";
            pnlGroup2.Size = new Size(402, 46);
            pnlGroup2.TabIndex = 2;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(72, 0);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Size = new Size(12, 16);
            label4.TabIndex = 21;
            label4.Text = "*";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(0, 0);
            label3.Margin = new Padding(0, 0, 0, 4);
            label3.Name = "label3";
            label3.Size = new Size(75, 16);
            label3.TabIndex = 20;
            label3.Text = "First Name";
            // 
            // txtFirstName
            // 
            txtFirstName.AccessibleName = "First Name";
            txtFirstName.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtFirstName.Location = new Point(0, 20);
            txtFirstName.Margin = new Padding(0);
            txtFirstName.MaxLength = 100;
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(402, 26);
            txtFirstName.TabIndex = 1;
            // 
            // pnlGroup3
            // 
            pnlGroup3.AutoSize = true;
            pnlGroup3.Controls.Add(label2);
            pnlGroup3.Controls.Add(txtMiddleName);
            pnlGroup3.Location = new Point(0, 124);
            pnlGroup3.Margin = new Padding(0, 0, 0, 16);
            pnlGroup3.Name = "pnlGroup3";
            pnlGroup3.Size = new Size(402, 46);
            pnlGroup3.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(0, 0);
            label2.Margin = new Padding(0, 0, 0, 4);
            label2.Name = "label2";
            label2.Size = new Size(88, 16);
            label2.TabIndex = 20;
            label2.Text = "Middle Name";
            // 
            // txtMiddleName
            // 
            txtMiddleName.AccessibleName = "Middle Name";
            txtMiddleName.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtMiddleName.Location = new Point(0, 20);
            txtMiddleName.Margin = new Padding(0);
            txtMiddleName.MaxLength = 100;
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(402, 26);
            txtMiddleName.TabIndex = 2;
            // 
            // pnlGroup4
            // 
            pnlGroup4.AutoSize = true;
            pnlGroup4.Controls.Add(label6);
            pnlGroup4.Controls.Add(label7);
            pnlGroup4.Controls.Add(txtLastName);
            pnlGroup4.Location = new Point(0, 186);
            pnlGroup4.Margin = new Padding(0, 0, 0, 16);
            pnlGroup4.Name = "pnlGroup4";
            pnlGroup4.Size = new Size(402, 46);
            pnlGroup4.TabIndex = 4;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.Red;
            label6.Location = new Point(71, 0);
            label6.Margin = new Padding(0);
            label6.Name = "label6";
            label6.Size = new Size(12, 16);
            label6.TabIndex = 21;
            label6.Text = "*";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(0, 0);
            label7.Margin = new Padding(0, 0, 0, 4);
            label7.Name = "label7";
            label7.Size = new Size(74, 16);
            label7.TabIndex = 20;
            label7.Text = "Last Name";
            // 
            // txtLastName
            // 
            txtLastName.AccessibleName = "Last Name";
            txtLastName.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtLastName.Location = new Point(0, 20);
            txtLastName.Margin = new Padding(0);
            txtLastName.MaxLength = 100;
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(402, 26);
            txtLastName.TabIndex = 3;
            // 
            // pnlGroup5
            // 
            pnlGroup5.AutoSize = true;
            pnlGroup5.Controls.Add(label14);
            pnlGroup5.Controls.Add(label16);
            pnlGroup5.Controls.Add(txtSalaryRate);
            pnlGroup5.Location = new Point(0, 248);
            pnlGroup5.Margin = new Padding(0, 0, 0, 16);
            pnlGroup5.Name = "pnlGroup5";
            pnlGroup5.Size = new Size(402, 46);
            pnlGroup5.TabIndex = 5;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label14.AutoSize = true;
            label14.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label14.ForeColor = Color.Red;
            label14.Location = new Point(78, 0);
            label14.Margin = new Padding(0);
            label14.Name = "label14";
            label14.Size = new Size(12, 16);
            label14.TabIndex = 21;
            label14.Text = "*";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(0, 0);
            label16.Margin = new Padding(0, 0, 0, 4);
            label16.Name = "label16";
            label16.Size = new Size(81, 16);
            label16.TabIndex = 20;
            label16.Text = "Salary Rate";
            // 
            // txtSalaryRate
            // 
            txtSalaryRate.AccessibleName = "Salary Rate";
            txtSalaryRate.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtSalaryRate.Location = new Point(0, 20);
            txtSalaryRate.Margin = new Padding(0);
            txtSalaryRate.MaxLength = 100;
            txtSalaryRate.Name = "txtSalaryRate";
            txtSalaryRate.Size = new Size(402, 26);
            txtSalaryRate.TabIndex = 4;
            txtSalaryRate.KeyPress += ValidateInputIfNumber_KeyPress;
            // 
            // pnlGroup6
            // 
            pnlGroup6.AutoSize = true;
            pnlGroup6.Controls.Add(label8);
            pnlGroup6.Controls.Add(label9);
            pnlGroup6.Controls.Add(txtBillingRate);
            pnlGroup6.Location = new Point(0, 310);
            pnlGroup6.Margin = new Padding(0, 0, 0, 16);
            pnlGroup6.Name = "pnlGroup6";
            pnlGroup6.Size = new Size(402, 46);
            pnlGroup6.TabIndex = 6;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.Red;
            label8.Location = new Point(75, 0);
            label8.Margin = new Padding(0);
            label8.Name = "label8";
            label8.Size = new Size(12, 16);
            label8.TabIndex = 21;
            label8.Text = "*";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(0, 0);
            label9.Margin = new Padding(0, 0, 0, 4);
            label9.Name = "label9";
            label9.Size = new Size(78, 16);
            label9.TabIndex = 20;
            label9.Text = "Billing Rate";
            // 
            // txtBillingRate
            // 
            txtBillingRate.AccessibleName = "Billing Rate";
            txtBillingRate.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtBillingRate.Location = new Point(0, 20);
            txtBillingRate.Margin = new Padding(0);
            txtBillingRate.MaxLength = 100;
            txtBillingRate.Name = "txtBillingRate";
            txtBillingRate.Size = new Size(402, 26);
            txtBillingRate.TabIndex = 5;
            txtBillingRate.KeyPress += ValidateInputIfNumber_KeyPress;
            // 
            // pnlGroup7
            // 
            pnlGroup7.AutoSize = true;
            pnlGroup7.Controls.Add(label13);
            pnlGroup7.Controls.Add(label12);
            pnlGroup7.Controls.Add(cmbLocation);
            pnlGroup7.Controls.Add(label10);
            pnlGroup7.Controls.Add(cmbDepartment);
            pnlGroup7.Controls.Add(label11);
            pnlGroup7.Location = new Point(0, 372);
            pnlGroup7.Margin = new Padding(0, 0, 0, 16);
            pnlGroup7.Name = "pnlGroup7";
            pnlGroup7.Size = new Size(402, 46);
            pnlGroup7.TabIndex = 7;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label13.AutoSize = true;
            label13.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label13.ForeColor = Color.Red;
            label13.Location = new Point(263, 0);
            label13.Margin = new Padding(0);
            label13.Name = "label13";
            label13.Size = new Size(12, 16);
            label13.TabIndex = 23;
            label13.Text = "*";
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label12.ForeColor = Color.Red;
            label12.Location = new Point(78, 0);
            label12.Margin = new Padding(0);
            label12.Name = "label12";
            label12.Size = new Size(12, 16);
            label12.TabIndex = 22;
            label12.Text = "*";
            // 
            // cmbLocation
            // 
            cmbLocation.AccessibleName = "Location";
            cmbLocation.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLocation.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbLocation.FormattingEnabled = true;
            cmbLocation.Location = new Point(205, 20);
            cmbLocation.Margin = new Padding(0);
            cmbLocation.Name = "cmbLocation";
            cmbLocation.Size = new Size(197, 26);
            cmbLocation.TabIndex = 7;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(205, 0);
            label10.Margin = new Padding(0, 0, 0, 4);
            label10.Name = "label10";
            label10.Size = new Size(61, 16);
            label10.TabIndex = 16;
            label10.Text = "Location";
            // 
            // cmbDepartment
            // 
            cmbDepartment.AccessibleName = "Department";
            cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartment.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.Location = new Point(0, 20);
            cmbDepartment.Margin = new Padding(0, 0, 8, 0);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(197, 26);
            cmbDepartment.TabIndex = 6;
            cmbDepartment.SelectedIndexChanged += cmbDepartment_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(0, 0);
            label11.Margin = new Padding(0, 0, 0, 4);
            label11.Name = "label11";
            label11.Size = new Size(81, 16);
            label11.TabIndex = 14;
            label11.Text = "Department";
            // 
            // pnlGroup8
            // 
            pnlGroup8.AutoSize = true;
            pnlGroup8.Controls.Add(label15);
            pnlGroup8.Controls.Add(cmbPosition);
            pnlGroup8.Controls.Add(label17);
            pnlGroup8.Location = new Point(0, 434);
            pnlGroup8.Margin = new Padding(0, 0, 0, 16);
            pnlGroup8.Name = "pnlGroup8";
            pnlGroup8.Size = new Size(402, 46);
            pnlGroup8.TabIndex = 8;
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label15.AutoSize = true;
            label15.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label15.ForeColor = Color.Red;
            label15.Location = new Point(54, 0);
            label15.Margin = new Padding(0);
            label15.Name = "label15";
            label15.Size = new Size(12, 16);
            label15.TabIndex = 22;
            label15.Text = "*";
            // 
            // cmbPosition
            // 
            cmbPosition.AccessibleName = "Position";
            cmbPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPosition.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbPosition.FormattingEnabled = true;
            cmbPosition.Location = new Point(0, 20);
            cmbPosition.Margin = new Padding(0);
            cmbPosition.Name = "cmbPosition";
            cmbPosition.Size = new Size(402, 26);
            cmbPosition.TabIndex = 8;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label17.Location = new Point(0, 0);
            label17.Margin = new Padding(0, 0, 0, 4);
            label17.Name = "label17";
            label17.Size = new Size(57, 16);
            label17.TabIndex = 14;
            label17.Text = "Position";
            // 
            // pnlGroup9
            // 
            pnlGroup9.AutoSize = true;
            pnlGroup9.Controls.Add(lblCustomPositionAsterisk);
            pnlGroup9.Controls.Add(chkCustomPosition);
            pnlGroup9.Controls.Add(txtCustomPosition);
            pnlGroup9.Location = new Point(0, 496);
            pnlGroup9.Margin = new Padding(0);
            pnlGroup9.Name = "pnlGroup9";
            pnlGroup9.Size = new Size(402, 46);
            pnlGroup9.TabIndex = 9;
            // 
            // lblCustomPositionAsterisk
            // 
            lblCustomPositionAsterisk.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblCustomPositionAsterisk.AutoSize = true;
            lblCustomPositionAsterisk.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblCustomPositionAsterisk.ForeColor = Color.Red;
            lblCustomPositionAsterisk.Location = new Point(126, 0);
            lblCustomPositionAsterisk.Margin = new Padding(0);
            lblCustomPositionAsterisk.Name = "lblCustomPositionAsterisk";
            lblCustomPositionAsterisk.Size = new Size(12, 16);
            lblCustomPositionAsterisk.TabIndex = 21;
            lblCustomPositionAsterisk.Text = "*";
            lblCustomPositionAsterisk.Visible = false;
            // 
            // chkCustomPosition
            // 
            chkCustomPosition.AutoSize = true;
            chkCustomPosition.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkCustomPosition.Location = new Point(3, 0);
            chkCustomPosition.Margin = new Padding(0, 0, 0, 4);
            chkCustomPosition.Name = "chkCustomPosition";
            chkCustomPosition.Size = new Size(128, 20);
            chkCustomPosition.TabIndex = 22;
            chkCustomPosition.Text = "Custom Position";
            chkCustomPosition.UseVisualStyleBackColor = true;
            chkCustomPosition.CheckedChanged += chkCustomPosition_CheckedChanged;
            // 
            // txtCustomPosition
            // 
            txtCustomPosition.AccessibleName = "Custom Position";
            txtCustomPosition.Enabled = false;
            txtCustomPosition.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCustomPosition.Location = new Point(0, 20);
            txtCustomPosition.Margin = new Padding(0);
            txtCustomPosition.MaxLength = 100;
            txtCustomPosition.Name = "txtCustomPosition";
            txtCustomPosition.Size = new Size(402, 26);
            txtCustomPosition.TabIndex = 5;
            // 
            // pnlLine2
            // 
            pnlLine2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLine2.BorderStyle = BorderStyle.FixedSingle;
            pnlLine2.Location = new Point(16, 43);
            pnlLine2.Margin = new Padding(0, 0, 0, 16);
            pnlLine2.Name = "pnlLine2";
            pnlLine2.Size = new Size(402, 1);
            pnlLine2.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(16, 16);
            label5.Margin = new Padding(0, 0, 0, 8);
            label5.Name = "label5";
            label5.Size = new Size(161, 19);
            label5.TabIndex = 3;
            label5.Text = "Insert Custom Entry";
            // 
            // InsertCustomEntryForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(434, 665);
            ControlBox = false;
            Controls.Add(pnlBody);
            Controls.Add(pnlFooter);
            Controls.Add(pnlLine1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "InsertCustomEntryForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Billing Name";
            Load += InsertCustomEntryForm_Load;
            pnlFooter.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            pnlGroup1.ResumeLayout(false);
            pnlGroup1.PerformLayout();
            pnlGroup2.ResumeLayout(false);
            pnlGroup2.PerformLayout();
            pnlGroup3.ResumeLayout(false);
            pnlGroup3.PerformLayout();
            pnlGroup4.ResumeLayout(false);
            pnlGroup4.PerformLayout();
            pnlGroup5.ResumeLayout(false);
            pnlGroup5.PerformLayout();
            pnlGroup6.ResumeLayout(false);
            pnlGroup6.PerformLayout();
            pnlGroup7.ResumeLayout(false);
            pnlGroup7.PerformLayout();
            pnlGroup8.ResumeLayout(false);
            pnlGroup8.PerformLayout();
            pnlGroup9.ResumeLayout(false);
            pnlGroup9.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLine1;
        private Panel pnlFooter;
        private Panel pnlBody;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button btnInsert;
        private Button btnCancel;
        private Panel pnlLine2;
        private Label label5;
        private Panel pnlGroup2;
        private Label label3;
        private TextBox txtFirstName;
        private Label label4;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel pnlGroup3;
        private Label label1;
        private Label label2;
        private TextBox txtMiddleName;
        private Panel pnlGroup4;
        private Label label6;
        private Label label7;
        private TextBox txtLastName;
        private Panel pnlGroup6;
        private Label label8;
        private Label label9;
        private TextBox txtBillingRate;
        private Panel pnlGroup7;
        private Label label13;
        private Label label12;
        private ComboBox cmbLocation;
        private Label label10;
        private ComboBox cmbDepartment;
        private Label label11;
        private Panel pnlGroup8;
        private Label label15;
        private ComboBox cmbPosition;
        private Label label17;
        private Panel pnlGroup5;
        private Label label14;
        private Label label16;
        private TextBox txtSalaryRate;
        private Panel pnlGroup1;
        private Label label18;
        private Label label19;
        private TextBox txtEmployeeID;
        private Panel pnlGroup9;
        private Label lblCustomPositionAsterisk;
        private TextBox txtCustomPosition;
        private CheckBox chkCustomPosition;
    }
}