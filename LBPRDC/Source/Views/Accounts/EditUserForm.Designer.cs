using LBPRDC.Source.Config;

namespace LBPRDC.Source.Views.Accounts
{
    partial class EditUserForm
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
            panel1 = new Panel();
            pnlFooter = new Panel();
            panel2 = new Panel();
            label32 = new Label();
            flowControls = new FlowLayoutPanel();
            btnUpdate = new Button();
            btnCancel = new Button();
            panel3 = new Panel();
            label1 = new Label();
            chkChangePassword = new CheckBox();
            grpPasswordData = new GroupBox();
            label12 = new Label();
            txtConfirmPassword = new TextBox();
            label13 = new Label();
            label14 = new Label();
            txtNewPassword = new TextBox();
            label15 = new Label();
            label16 = new Label();
            txtOldPassword = new TextBox();
            label17 = new Label();
            grpAccountData = new GroupBox();
            label19 = new Label();
            label18 = new Label();
            label2 = new Label();
            cmbStatus = new ComboBox();
            label5 = new Label();
            cmbRole = new ComboBox();
            txtUsername = new TextBox();
            label11 = new Label();
            grpPersonalData = new GroupBox();
            label9 = new Label();
            txtEmailAddress = new TextBox();
            label3 = new Label();
            label24 = new Label();
            label23 = new Label();
            label22 = new Label();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            label4 = new Label();
            flowContent = new FlowLayoutPanel();
            panel4 = new Panel();
            pnlFooter.SuspendLayout();
            panel2.SuspendLayout();
            flowControls.SuspendLayout();
            panel3.SuspendLayout();
            grpPasswordData.SuspendLayout();
            grpAccountData.SuspendLayout();
            grpPersonalData.SuspendLayout();
            flowContent.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(468, 1);
            panel1.TabIndex = 0;
            // 
            // pnlFooter
            // 
            pnlFooter.Controls.Add(panel2);
            pnlFooter.Controls.Add(flowControls);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 510);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(468, 60);
            pnlFooter.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Menu;
            panel2.Controls.Add(label32);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(241, 60);
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
            label32.TabIndex = 17;
            label32.Text = "All text fields marked with a red asterisk (*) are required.";
            label32.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // flowControls
            // 
            flowControls.BackColor = SystemColors.Menu;
            flowControls.Controls.Add(btnUpdate);
            flowControls.Controls.Add(btnCancel);
            flowControls.Dock = DockStyle.Right;
            flowControls.FlowDirection = FlowDirection.RightToLeft;
            flowControls.Location = new Point(241, 0);
            flowControls.Name = "flowControls";
            flowControls.Padding = new Padding(16, 16, 0, 16);
            flowControls.Size = new Size(227, 60);
            flowControls.TabIndex = 1;
            // 
            // btnUpdate
            // 
            btnUpdate.AutoSize = true;
            btnUpdate.Location = new Point(136, 16);
            btnUpdate.Margin = new Padding(8, 0, 0, 0);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 28);
            btnUpdate.TabIndex = 27;
            btnUpdate.Text = MessagesConstants.Update.TITLE;
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.Location = new Point(53, 16);
            btnCancel.Margin = new Padding(0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 28);
            btnCancel.TabIndex = 26;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Control;
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 1);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(16);
            panel3.Size = new Size(468, 40);
            panel3.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(146, 11);
            label1.Margin = new Padding(0, 0, 0, 16);
            label1.Name = "label1";
            label1.Size = new Size(161, 19);
            label1.TabIndex = 23;
            label1.Text = "EDIT INFORMATION";
            // 
            // chkChangePassword
            // 
            chkChangePassword.AutoSize = true;
            chkChangePassword.Location = new Point(16, 372);
            chkChangePassword.Margin = new Padding(0, 0, 0, 8);
            chkChangePassword.Name = "chkChangePassword";
            chkChangePassword.Size = new Size(236, 22);
            chkChangePassword.TabIndex = 27;
            chkChangePassword.Text = "Change this user's password?";
            chkChangePassword.UseVisualStyleBackColor = true;
            chkChangePassword.CheckedChanged += chkChangePassword_CheckedChanged;
            // 
            // grpPasswordData
            // 
            grpPasswordData.Controls.Add(label12);
            grpPasswordData.Controls.Add(txtConfirmPassword);
            grpPasswordData.Controls.Add(label13);
            grpPasswordData.Controls.Add(label14);
            grpPasswordData.Controls.Add(txtNewPassword);
            grpPasswordData.Controls.Add(label15);
            grpPasswordData.Controls.Add(label16);
            grpPasswordData.Controls.Add(txtOldPassword);
            grpPasswordData.Controls.Add(label17);
            grpPasswordData.Enabled = false;
            grpPasswordData.Location = new Point(16, 402);
            grpPasswordData.Margin = new Padding(0, 0, 0, 16);
            grpPasswordData.Name = "grpPasswordData";
            grpPasswordData.Padding = new Padding(3, 8, 3, 3);
            grpPasswordData.Size = new Size(420, 231);
            grpPasswordData.TabIndex = 26;
            grpPasswordData.TabStop = false;
            grpPasswordData.Text = "Password Information";
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label12.ForeColor = Color.Red;
            label12.Location = new Point(123, 155);
            label12.Margin = new Padding(0, 0, 0, 4);
            label12.Name = "label12";
            label12.Size = new Size(14, 18);
            label12.TabIndex = 22;
            label12.Text = "*";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.AccessibleName = "Confirm Password";
            txtConfirmPassword.Location = new Point(10, 180);
            txtConfirmPassword.Margin = new Padding(7, 3, 3, 16);
            txtConfirmPassword.MaxLength = 50;
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(400, 26);
            txtConfirmPassword.TabIndex = 20;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label13.AutoSize = true;
            label13.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(6, 157);
            label13.Margin = new Padding(3, 0, 0, 4);
            label13.Name = "label13";
            label13.Size = new Size(121, 16);
            label13.TabIndex = 21;
            label13.Text = "Confirm Password";
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label14.AutoSize = true;
            label14.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label14.ForeColor = Color.Red;
            label14.Location = new Point(100, 90);
            label14.Margin = new Padding(0, 0, 0, 4);
            label14.Name = "label14";
            label14.Size = new Size(14, 18);
            label14.TabIndex = 19;
            label14.Text = "*";
            // 
            // txtNewPassword
            // 
            txtNewPassword.AccessibleName = "New Password";
            txtNewPassword.Location = new Point(10, 115);
            txtNewPassword.Margin = new Padding(7, 3, 3, 16);
            txtNewPassword.MaxLength = 50;
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(400, 26);
            txtNewPassword.TabIndex = 17;
            txtNewPassword.UseSystemPasswordChar = true;
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label15.AutoSize = true;
            label15.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(6, 92);
            label15.Margin = new Padding(3, 0, 0, 4);
            label15.Name = "label15";
            label15.Size = new Size(98, 16);
            label15.TabIndex = 18;
            label15.Text = "New Password";
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label16.AutoSize = true;
            label16.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label16.ForeColor = Color.Red;
            label16.Location = new Point(96, 25);
            label16.Margin = new Padding(0, 0, 0, 4);
            label16.Name = "label16";
            label16.Size = new Size(14, 18);
            label16.TabIndex = 16;
            label16.Text = "*";
            // 
            // txtOldPassword
            // 
            txtOldPassword.AccessibleName = "Old Password";
            txtOldPassword.Location = new Point(10, 50);
            txtOldPassword.Margin = new Padding(7, 3, 3, 16);
            txtOldPassword.MaxLength = 50;
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.Size = new Size(400, 26);
            txtOldPassword.TabIndex = 0;
            // 
            // label17
            // 
            label17.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label17.AutoSize = true;
            label17.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label17.Location = new Point(6, 27);
            label17.Margin = new Padding(3, 0, 0, 4);
            label17.Name = "label17";
            label17.Size = new Size(94, 16);
            label17.TabIndex = 0;
            label17.Text = "Old Password";
            // 
            // grpAccountData
            // 
            grpAccountData.Controls.Add(label19);
            grpAccountData.Controls.Add(label18);
            grpAccountData.Controls.Add(label2);
            grpAccountData.Controls.Add(cmbStatus);
            grpAccountData.Controls.Add(label5);
            grpAccountData.Controls.Add(cmbRole);
            grpAccountData.Controls.Add(txtUsername);
            grpAccountData.Controls.Add(label11);
            grpAccountData.Location = new Point(16, 198);
            grpAccountData.Margin = new Padding(0, 0, 0, 8);
            grpAccountData.Name = "grpAccountData";
            grpAccountData.Padding = new Padding(3, 8, 3, 3);
            grpAccountData.Size = new Size(420, 166);
            grpAccountData.TabIndex = 25;
            grpAccountData.TabStop = false;
            grpAccountData.Text = "Account Information";
            // 
            // label19
            // 
            label19.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label19.AutoSize = true;
            label19.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label19.ForeColor = Color.Red;
            label19.Location = new Point(252, 90);
            label19.Margin = new Padding(0, 0, 0, 4);
            label19.Name = "label19";
            label19.Size = new Size(14, 18);
            label19.TabIndex = 22;
            label19.Text = "*";
            // 
            // label18
            // 
            label18.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label18.AutoSize = true;
            label18.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label18.ForeColor = Color.Red;
            label18.Location = new Point(38, 90);
            label18.Margin = new Padding(0, 0, 0, 4);
            label18.Name = "label18";
            label18.Size = new Size(14, 18);
            label18.TabIndex = 21;
            label18.Text = "*";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(209, 92);
            label2.Margin = new Padding(3, 0, 0, 4);
            label2.Name = "label2";
            label2.Size = new Size(47, 16);
            label2.TabIndex = 20;
            label2.Text = "Status";
            // 
            // cmbStatus
            // 
            cmbStatus.AccessibleName = "Status";
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "(Choose Status)", StringConstants.Status.ACTIVE, StringConstants.Status.INACTIVE });
            cmbStatus.Location = new Point(213, 115);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(197, 26);
            cmbStatus.TabIndex = 19;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(6, 92);
            label5.Margin = new Padding(3, 0, 0, 4);
            label5.Name = "label5";
            label5.Size = new Size(36, 16);
            label5.TabIndex = 18;
            label5.Text = "Role";
            // 
            // cmbRole
            // 
            cmbRole.AccessibleName = "Role";
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "(Choose Role)", "Standard", "Admin" });
            cmbRole.Location = new Point(10, 115);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(197, 26);
            cmbRole.TabIndex = 17;
            // 
            // txtUsername
            // 
            txtUsername.AccessibleName = "Username";
            txtUsername.Location = new Point(10, 50);
            txtUsername.Margin = new Padding(7, 3, 3, 16);
            txtUsername.MaxLength = 50;
            txtUsername.Name = "txtUsername";
            txtUsername.ReadOnly = true;
            txtUsername.Size = new Size(400, 26);
            txtUsername.TabIndex = 0;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(6, 27);
            label11.Margin = new Padding(3, 0, 0, 4);
            label11.Name = "label11";
            label11.Size = new Size(71, 16);
            label11.TabIndex = 0;
            label11.Text = "Username";
            // 
            // grpPersonalData
            // 
            grpPersonalData.Controls.Add(label9);
            grpPersonalData.Controls.Add(txtEmailAddress);
            grpPersonalData.Controls.Add(label3);
            grpPersonalData.Controls.Add(label24);
            grpPersonalData.Controls.Add(label23);
            grpPersonalData.Controls.Add(label22);
            grpPersonalData.Controls.Add(txtLastName);
            grpPersonalData.Controls.Add(txtFirstName);
            grpPersonalData.Controls.Add(label4);
            grpPersonalData.Location = new Point(16, 16);
            grpPersonalData.Margin = new Padding(0, 0, 0, 16);
            grpPersonalData.Name = "grpPersonalData";
            grpPersonalData.Padding = new Padding(3, 8, 3, 3);
            grpPersonalData.Size = new Size(420, 166);
            grpPersonalData.TabIndex = 24;
            grpPersonalData.TabStop = false;
            grpPersonalData.Text = "Personal Information";
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
            txtEmailAddress.Size = new Size(400, 26);
            txtEmailAddress.TabIndex = 20;
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
            label24.Location = new Point(279, 25);
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
            label22.Location = new Point(209, 27);
            label22.Margin = new Padding(3, 0, 0, 4);
            label22.Name = "label22";
            label22.Size = new Size(74, 16);
            label22.TabIndex = 15;
            label22.Text = "Last Name";
            // 
            // txtLastName
            // 
            txtLastName.AccessibleName = "Last Name";
            txtLastName.Location = new Point(213, 50);
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
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(6, 27);
            label4.Margin = new Padding(3, 0, 0, 4);
            label4.Name = "label4";
            label4.Size = new Size(75, 16);
            label4.TabIndex = 0;
            label4.Text = "First Name";
            // 
            // flowContent
            // 
            flowContent.AutoSize = true;
            flowContent.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowContent.Controls.Add(grpPersonalData);
            flowContent.Controls.Add(grpAccountData);
            flowContent.Controls.Add(chkChangePassword);
            flowContent.Controls.Add(grpPasswordData);
            flowContent.FlowDirection = FlowDirection.TopDown;
            flowContent.Location = new Point(0, 0);
            flowContent.Name = "flowContent";
            flowContent.Padding = new Padding(16, 16, 0, 0);
            flowContent.Size = new Size(436, 649);
            flowContent.TabIndex = 28;
            // 
            // panel4
            // 
            panel4.AutoScroll = true;
            panel4.Controls.Add(flowContent);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 41);
            panel4.Margin = new Padding(0);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(0, 0, 16, 0);
            panel4.Size = new Size(468, 469);
            panel4.TabIndex = 29;
            // 
            // EditUserForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(468, 570);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(pnlFooter);
            Controls.Add(panel1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditUserForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Load += EditUserForm_Load;
            pnlFooter.ResumeLayout(false);
            panel2.ResumeLayout(false);
            flowControls.ResumeLayout(false);
            flowControls.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            grpPasswordData.ResumeLayout(false);
            grpPasswordData.PerformLayout();
            grpAccountData.ResumeLayout(false);
            grpAccountData.PerformLayout();
            grpPersonalData.ResumeLayout(false);
            grpPersonalData.PerformLayout();
            flowContent.ResumeLayout(false);
            flowContent.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel pnlFooter;
        private Panel panel2;
        private FlowLayoutPanel flowControls;
        private Button btnUpdate;
        private Button btnCancel;
        private Panel panel3;
        private Label label1;
        private GroupBox grpPersonalData;
        private Label label9;
        private TextBox txtEmailAddress;
        private Label label3;
        private Label label24;
        private Label label23;
        private Label label22;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private Label label4;
        private GroupBox grpAccountData;
        private Label label6;
        private TextBox txtConfirmPassword;
        private Label label8;
        private Label label5;
        private TextBox txtPassword;
        private Label label7;
        private TextBox txtUsername;
        private Label label11;
        private CheckBox chkChangePassword;
        private GroupBox grpPasswordData;
        private Label label12;
        private TextBox textBox1;
        private Label label13;
        private Label label14;
        private TextBox textBox2;
        private Label label15;
        private Label label16;
        private TextBox textBox3;
        private Label label17;
        private FlowLayoutPanel flowContent;
        private Panel panel4;
        private Label label32;
        private TextBox txtNewPassword;
        private TextBox txtOldPassword;
        private Label label2;
        private ComboBox comboBox1;
        private ComboBox cmbGender;
        private ComboBox cmbStatus;
        private ComboBox cmbRole;
        private Label label19;
        private Label label18;
    }
}