namespace LBPRDC.Source.Views.Accounts
{
    partial class AddNewUser
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
            panel2 = new Panel();
            label32 = new Label();
            flowControls = new FlowLayoutPanel();
            btnAdd = new Button();
            btnCancel = new Button();
            pnlMain = new Panel();
            grpAccountData = new GroupBox();
            cmbUserRole = new ComboBox();
            label16 = new Label();
            label15 = new Label();
            label6 = new Label();
            txtConfirmPassword = new TextBox();
            label8 = new Label();
            label2 = new Label();
            txtPassword = new TextBox();
            label4 = new Label();
            label5 = new Label();
            txtUsername = new TextBox();
            label7 = new Label();
            grpPersonalData = new GroupBox();
            label13 = new Label();
            txtPositionTitle = new TextBox();
            label14 = new Label();
            label12 = new Label();
            txtMiddleName = new TextBox();
            label9 = new Label();
            txtEmailAddress = new TextBox();
            label3 = new Label();
            label24 = new Label();
            label23 = new Label();
            label22 = new Label();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            label1 = new Label();
            label10 = new Label();
            pnlHeader = new Panel();
            pnlFooter.SuspendLayout();
            panel2.SuspendLayout();
            flowControls.SuspendLayout();
            pnlMain.SuspendLayout();
            grpAccountData.SuspendLayout();
            grpPersonalData.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLine1
            // 
            pnlLine1.BorderStyle = BorderStyle.FixedSingle;
            pnlLine1.Dock = DockStyle.Top;
            pnlLine1.Location = new Point(0, 0);
            pnlLine1.Name = "pnlLine1";
            pnlLine1.Size = new Size(452, 1);
            pnlLine1.TabIndex = 0;
            // 
            // pnlFooter
            // 
            pnlFooter.Controls.Add(panel2);
            pnlFooter.Controls.Add(flowControls);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 555);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(452, 60);
            pnlFooter.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Menu;
            panel2.Controls.Add(label32);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(225, 60);
            panel2.TabIndex = 2;
            // 
            // label32
            // 
            label32.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label32.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label32.Location = new Point(12, 10);
            label32.Margin = new Padding(3, 0, 3, 4);
            label32.Name = "label32";
            label32.Size = new Size(207, 40);
            label32.TabIndex = 16;
            label32.Text = "All text fields marked with a red asterisk (*) are required.";
            label32.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // flowControls
            // 
            flowControls.BackColor = SystemColors.Menu;
            flowControls.Controls.Add(btnAdd);
            flowControls.Controls.Add(btnCancel);
            flowControls.Dock = DockStyle.Right;
            flowControls.FlowDirection = FlowDirection.RightToLeft;
            flowControls.Location = new Point(225, 0);
            flowControls.Name = "flowControls";
            flowControls.Padding = new Padding(16, 16, 0, 16);
            flowControls.Size = new Size(227, 60);
            flowControls.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.AutoSize = true;
            btnAdd.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnAdd.Location = new Point(136, 16);
            btnAdd.Margin = new Padding(8, 0, 0, 0);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 28);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.Location = new Point(53, 16);
            btnCancel.Margin = new Padding(0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 28);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(grpAccountData);
            pnlMain.Controls.Add(grpPersonalData);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 41);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(16);
            pnlMain.Size = new Size(452, 514);
            pnlMain.TabIndex = 5;
            // 
            // grpAccountData
            // 
            grpAccountData.Controls.Add(cmbUserRole);
            grpAccountData.Controls.Add(label16);
            grpAccountData.Controls.Add(label15);
            grpAccountData.Controls.Add(label6);
            grpAccountData.Controls.Add(txtConfirmPassword);
            grpAccountData.Controls.Add(label8);
            grpAccountData.Controls.Add(label2);
            grpAccountData.Controls.Add(txtPassword);
            grpAccountData.Controls.Add(label4);
            grpAccountData.Controls.Add(label5);
            grpAccountData.Controls.Add(txtUsername);
            grpAccountData.Controls.Add(label7);
            grpAccountData.Location = new Point(16, 198);
            grpAccountData.Margin = new Padding(0, 0, 0, 16);
            grpAccountData.Name = "grpAccountData";
            grpAccountData.Padding = new Padding(3, 8, 3, 3);
            grpAccountData.Size = new Size(420, 297);
            grpAccountData.TabIndex = 21;
            grpAccountData.TabStop = false;
            grpAccountData.Text = "Account Information";
            // 
            // cmbUserRole
            // 
            cmbUserRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUserRole.FormattingEnabled = true;
            cmbUserRole.Location = new Point(10, 245);
            cmbUserRole.Name = "cmbUserRole";
            cmbUserRole.Size = new Size(400, 26);
            cmbUserRole.TabIndex = 25;
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label16.AutoSize = true;
            label16.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label16.ForeColor = Color.Red;
            label16.Location = new Point(42, 220);
            label16.Margin = new Padding(0, 0, 0, 4);
            label16.Name = "label16";
            label16.Size = new Size(14, 18);
            label16.TabIndex = 24;
            label16.Text = "*";
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label15.AutoSize = true;
            label15.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(10, 222);
            label15.Margin = new Padding(3, 0, 0, 4);
            label15.Name = "label15";
            label15.Size = new Size(36, 16);
            label15.TabIndex = 23;
            label15.Text = "Role";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.Red;
            label6.Location = new Point(123, 155);
            label6.Margin = new Padding(0, 0, 0, 4);
            label6.Name = "label6";
            label6.Size = new Size(14, 18);
            label6.TabIndex = 22;
            label6.Text = "*";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.AccessibleName = "Confirm Password";
            txtConfirmPassword.Location = new Point(10, 180);
            txtConfirmPassword.Margin = new Padding(7, 3, 3, 16);
            txtConfirmPassword.MaxLength = 50;
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(400, 26);
            txtConfirmPassword.TabIndex = 7;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(6, 157);
            label8.Margin = new Padding(3, 0, 0, 4);
            label8.Name = "label8";
            label8.Size = new Size(121, 16);
            label8.TabIndex = 21;
            label8.Text = "Confirm Password";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(70, 90);
            label2.Margin = new Padding(0, 0, 0, 4);
            label2.Name = "label2";
            label2.Size = new Size(14, 18);
            label2.TabIndex = 19;
            label2.Text = "*";
            // 
            // txtPassword
            // 
            txtPassword.AccessibleName = "Password";
            txtPassword.Location = new Point(10, 115);
            txtPassword.Margin = new Padding(7, 3, 3, 16);
            txtPassword.MaxLength = 50;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(400, 26);
            txtPassword.TabIndex = 6;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(6, 92);
            label4.Margin = new Padding(3, 0, 0, 4);
            label4.Name = "label4";
            label4.Size = new Size(68, 16);
            label4.TabIndex = 18;
            label4.Text = "Password";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.Red;
            label5.Location = new Point(73, 25);
            label5.Margin = new Padding(0, 0, 0, 4);
            label5.Name = "label5";
            label5.Size = new Size(14, 18);
            label5.TabIndex = 16;
            label5.Text = "*";
            // 
            // txtUsername
            // 
            txtUsername.AccessibleName = "Username";
            txtUsername.Location = new Point(10, 50);
            txtUsername.Margin = new Padding(7, 3, 3, 16);
            txtUsername.MaxLength = 50;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(400, 26);
            txtUsername.TabIndex = 5;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(6, 27);
            label7.Margin = new Padding(3, 0, 0, 4);
            label7.Name = "label7";
            label7.Size = new Size(71, 16);
            label7.TabIndex = 0;
            label7.Text = "Username";
            // 
            // grpPersonalData
            // 
            grpPersonalData.Controls.Add(label13);
            grpPersonalData.Controls.Add(txtPositionTitle);
            grpPersonalData.Controls.Add(label14);
            grpPersonalData.Controls.Add(label12);
            grpPersonalData.Controls.Add(txtMiddleName);
            grpPersonalData.Controls.Add(label9);
            grpPersonalData.Controls.Add(txtEmailAddress);
            grpPersonalData.Controls.Add(label3);
            grpPersonalData.Controls.Add(label24);
            grpPersonalData.Controls.Add(label23);
            grpPersonalData.Controls.Add(label22);
            grpPersonalData.Controls.Add(txtLastName);
            grpPersonalData.Controls.Add(txtFirstName);
            grpPersonalData.Controls.Add(label1);
            grpPersonalData.Location = new Point(16, 16);
            grpPersonalData.Margin = new Padding(0, 0, 0, 16);
            grpPersonalData.Name = "grpPersonalData";
            grpPersonalData.Padding = new Padding(3, 8, 3, 3);
            grpPersonalData.Size = new Size(420, 166);
            grpPersonalData.TabIndex = 1;
            grpPersonalData.TabStop = false;
            grpPersonalData.Text = "Personal Information";
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label13.AutoSize = true;
            label13.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label13.ForeColor = Color.Red;
            label13.Location = new Point(292, 90);
            label13.Margin = new Padding(0, 0, 0, 4);
            label13.Name = "label13";
            label13.Size = new Size(14, 18);
            label13.TabIndex = 29;
            label13.Text = "*";
            // 
            // txtPositionTitle
            // 
            txtPositionTitle.AccessibleName = "Position Title";
            txtPositionTitle.Location = new Point(213, 115);
            txtPositionTitle.MaxLength = 100;
            txtPositionTitle.Name = "txtPositionTitle";
            txtPositionTitle.Size = new Size(197, 26);
            txtPositionTitle.TabIndex = 4;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(209, 92);
            label14.Margin = new Padding(3, 0, 0, 4);
            label14.Name = "label14";
            label14.Size = new Size(87, 16);
            label14.TabIndex = 27;
            label14.Text = "Position Title";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(142, 27);
            label12.Margin = new Padding(3, 0, 0, 4);
            label12.Name = "label12";
            label12.Size = new Size(88, 16);
            label12.TabIndex = 25;
            label12.Text = "Middle Name";
            // 
            // txtMiddleName
            // 
            txtMiddleName.AccessibleName = "Middle Name";
            txtMiddleName.Location = new Point(146, 50);
            txtMiddleName.MaxLength = 50;
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(129, 26);
            txtMiddleName.TabIndex = 1;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = Color.Red;
            label9.Location = new Point(98, 90);
            label9.Margin = new Padding(0, 0, 0, 4);
            label9.Name = "label9";
            label9.Size = new Size(14, 18);
            label9.TabIndex = 23;
            label9.Text = "*";
            // 
            // txtEmailAddress
            // 
            txtEmailAddress.AccessibleName = "Email Address";
            txtEmailAddress.Location = new Point(10, 115);
            txtEmailAddress.MaxLength = 100;
            txtEmailAddress.Name = "txtEmailAddress";
            txtEmailAddress.Size = new Size(197, 26);
            txtEmailAddress.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(6, 92);
            label3.Margin = new Padding(3, 0, 0, 4);
            label3.Name = "label3";
            label3.Size = new Size(96, 16);
            label3.TabIndex = 19;
            label3.Text = "Email Address";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label24.ForeColor = Color.Red;
            label24.Location = new Point(347, 25);
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
            label23.Location = new Point(77, 25);
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
            label22.Location = new Point(277, 27);
            label22.Margin = new Padding(3, 0, 0, 4);
            label22.Name = "label22";
            label22.Size = new Size(74, 16);
            label22.TabIndex = 15;
            label22.Text = "Last Name";
            // 
            // txtLastName
            // 
            txtLastName.AccessibleName = "Last Name";
            txtLastName.Location = new Point(281, 50);
            txtLastName.MaxLength = 50;
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(129, 26);
            txtLastName.TabIndex = 2;
            // 
            // txtFirstName
            // 
            txtFirstName.AccessibleName = "First Name";
            txtFirstName.Location = new Point(10, 50);
            txtFirstName.Margin = new Padding(7, 3, 3, 16);
            txtFirstName.MaxLength = 50;
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(129, 26);
            txtFirstName.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(6, 27);
            label1.Margin = new Padding(3, 0, 0, 4);
            label1.Name = "label1";
            label1.Size = new Size(75, 16);
            label1.TabIndex = 0;
            label1.Text = "First Name";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(138, 11);
            label10.Margin = new Padding(0, 0, 0, 16);
            label10.Name = "label10";
            label10.Size = new Size(177, 19);
            label10.TabIndex = 22;
            label10.Text = "ACCOUNT CREATION";
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = SystemColors.Control;
            pnlHeader.Controls.Add(label10);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 1);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(452, 40);
            pnlHeader.TabIndex = 6;
            // 
            // AddNewUser
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(452, 615);
            Controls.Add(pnlMain);
            Controls.Add(pnlHeader);
            Controls.Add(pnlFooter);
            Controls.Add(pnlLine1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddNewUser";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Load += AddNewUser_Load;
            pnlFooter.ResumeLayout(false);
            panel2.ResumeLayout(false);
            flowControls.ResumeLayout(false);
            flowControls.PerformLayout();
            pnlMain.ResumeLayout(false);
            grpAccountData.ResumeLayout(false);
            grpAccountData.PerformLayout();
            grpPersonalData.ResumeLayout(false);
            grpPersonalData.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLine1;
        private Panel pnlFooter;
        private Panel panel2;
        private FlowLayoutPanel flowControls;
        private Button btnAdd;
        private Button btnCancel;
        private Panel pnlMain;
        private GroupBox grpPersonalData;
        private Label label24;
        private Label label23;
        private Label label22;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private Label label1;
        private Label label3;
        private TextBox txtEmailAddress;
        private GroupBox grpAccountData;
        private Label label5;
        private TextBox txtUsername;
        private Label label7;
        private Label label6;
        private TextBox txtConfirmPassword;
        private Label label8;
        private Label label2;
        private TextBox txtPassword;
        private Label label4;
        private Label label9;
        private Label label10;
        private Label label32;
        private Panel pnlHeader;
        private Label label11;
        private Label label12;
        private TextBox txtMiddleName;
        private Label label13;
        private TextBox txtPositionTitle;
        private Label label14;
        private Label label16;
        private Label label15;
        private ComboBox cmbUserRole;
    }
}