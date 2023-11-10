﻿namespace LBPRDC.Source.Views.Profile
{
    partial class ViewAndEditProfileForm
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
            flowFooterActions = new FlowLayoutPanel();
            btnClose = new Button();
            btnUndoChanges = new Button();
            pnlHeader = new Panel();
            lblHiddenUserID = new Label();
            label2 = new Label();
            pnlBody = new Panel();
            chkChangePassword = new CheckBox();
            grpPasswordData = new GroupBox();
            btnUpdatePassword = new Button();
            txtConfirmPassword = new TextBox();
            label13 = new Label();
            txtNewPassword = new TextBox();
            label15 = new Label();
            txtOldPassword = new TextBox();
            label17 = new Label();
            grpPersonalData = new GroupBox();
            btnUpdateBasicInformation = new Button();
            txtEmailAddress = new TextBox();
            label3 = new Label();
            label22 = new Label();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            label4 = new Label();
            pnlFooter.SuspendLayout();
            flowFooterActions.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlBody.SuspendLayout();
            grpPasswordData.SuspendLayout();
            grpPersonalData.SuspendLayout();
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
            pnlFooter.BackColor = SystemColors.Control;
            pnlFooter.Controls.Add(flowFooterActions);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 565);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(452, 60);
            pnlFooter.TabIndex = 1;
            // 
            // flowFooterActions
            // 
            flowFooterActions.Controls.Add(btnClose);
            flowFooterActions.Controls.Add(btnUndoChanges);
            flowFooterActions.Dock = DockStyle.Right;
            flowFooterActions.FlowDirection = FlowDirection.RightToLeft;
            flowFooterActions.Location = new Point(178, 0);
            flowFooterActions.Name = "flowFooterActions";
            flowFooterActions.Padding = new Padding(15, 16, 0, 16);
            flowFooterActions.Size = new Size(274, 60);
            flowFooterActions.TabIndex = 2;
            // 
            // btnClose
            // 
            btnClose.AutoSize = true;
            btnClose.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.Location = new Point(184, 16);
            btnClose.Margin = new Padding(8, 0, 0, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 28);
            btnClose.TabIndex = 8;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnUndoChanges
            // 
            btnUndoChanges.AutoSize = true;
            btnUndoChanges.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnUndoChanges.Location = new Point(101, 16);
            btnUndoChanges.Margin = new Padding(8, 0, 0, 0);
            btnUndoChanges.Name = "btnUndoChanges";
            btnUndoChanges.Size = new Size(75, 28);
            btnUndoChanges.TabIndex = 9;
            btnUndoChanges.Text = "Undo";
            btnUndoChanges.UseVisualStyleBackColor = true;
            btnUndoChanges.Visible = false;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = SystemColors.Control;
            pnlHeader.Controls.Add(lblHiddenUserID);
            pnlHeader.Controls.Add(label2);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 1);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(452, 40);
            pnlHeader.TabIndex = 2;
            // 
            // lblHiddenUserID
            // 
            lblHiddenUserID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblHiddenUserID.AutoSize = true;
            lblHiddenUserID.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblHiddenUserID.Location = new Point(12, 13);
            lblHiddenUserID.Margin = new Padding(3, 0, 0, 4);
            lblHiddenUserID.Name = "lblHiddenUserID";
            lblHiddenUserID.Size = new Size(49, 16);
            lblHiddenUserID.TabIndex = 24;
            lblHiddenUserID.Text = "UserID";
            lblHiddenUserID.Visible = false;
            // 
            // label2
            // 
            label2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(54, 11);
            label2.Margin = new Padding(0, 0, 0, 16);
            label2.Name = "label2";
            label2.Size = new Size(345, 19);
            label2.TabIndex = 26;
            label2.Text = "MY PROFILE";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(chkChangePassword);
            pnlBody.Controls.Add(grpPasswordData);
            pnlBody.Controls.Add(grpPersonalData);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 41);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(16);
            pnlBody.Size = new Size(452, 524);
            pnlBody.TabIndex = 3;
            // 
            // chkChangePassword
            // 
            chkChangePassword.AutoSize = true;
            chkChangePassword.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkChangePassword.Location = new Point(26, 228);
            chkChangePassword.Name = "chkChangePassword";
            chkChangePassword.Size = new Size(141, 20);
            chkChangePassword.TabIndex = 22;
            chkChangePassword.Text = "Change Password";
            chkChangePassword.UseVisualStyleBackColor = true;
            chkChangePassword.CheckedChanged += chkChangePassword_CheckedChanged;
            // 
            // grpPasswordData
            // 
            grpPasswordData.Controls.Add(btnUpdatePassword);
            grpPasswordData.Controls.Add(txtConfirmPassword);
            grpPasswordData.Controls.Add(label13);
            grpPasswordData.Controls.Add(txtNewPassword);
            grpPasswordData.Controls.Add(label15);
            grpPasswordData.Controls.Add(txtOldPassword);
            grpPasswordData.Controls.Add(label17);
            grpPasswordData.Enabled = false;
            grpPasswordData.Location = new Point(16, 228);
            grpPasswordData.Margin = new Padding(0, 0, 0, 16);
            grpPasswordData.Name = "grpPasswordData";
            grpPasswordData.Padding = new Padding(3, 8, 3, 3);
            grpPasswordData.Size = new Size(420, 270);
            grpPasswordData.TabIndex = 28;
            grpPasswordData.TabStop = false;
            // 
            // btnUpdatePassword
            // 
            btnUpdatePassword.AutoSize = true;
            btnUpdatePassword.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpdatePassword.Location = new Point(335, 222);
            btnUpdatePassword.Margin = new Padding(8, 0, 0, 0);
            btnUpdatePassword.Name = "btnUpdatePassword";
            btnUpdatePassword.Size = new Size(75, 28);
            btnUpdatePassword.TabIndex = 22;
            btnUpdatePassword.Text = "Update";
            btnUpdatePassword.UseVisualStyleBackColor = true;
            btnUpdatePassword.Click += btnUpdatePassword_Click;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.AccessibleName = "Confirm Password";
            txtConfirmPassword.Location = new Point(10, 180);
            txtConfirmPassword.Margin = new Padding(7, 3, 3, 16);
            txtConfirmPassword.MaxLength = 50;
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(400, 26);
            txtConfirmPassword.TabIndex = 5;
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
            // txtNewPassword
            // 
            txtNewPassword.AccessibleName = "New Password";
            txtNewPassword.Location = new Point(10, 115);
            txtNewPassword.Margin = new Padding(7, 3, 3, 16);
            txtNewPassword.MaxLength = 50;
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(400, 26);
            txtNewPassword.TabIndex = 4;
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
            // txtOldPassword
            // 
            txtOldPassword.AccessibleName = "Old Password";
            txtOldPassword.Location = new Point(10, 50);
            txtOldPassword.Margin = new Padding(7, 3, 3, 16);
            txtOldPassword.MaxLength = 50;
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.Size = new Size(400, 26);
            txtOldPassword.TabIndex = 3;
            txtOldPassword.UseSystemPasswordChar = true;
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
            // grpPersonalData
            // 
            grpPersonalData.Controls.Add(btnUpdateBasicInformation);
            grpPersonalData.Controls.Add(txtEmailAddress);
            grpPersonalData.Controls.Add(label3);
            grpPersonalData.Controls.Add(label22);
            grpPersonalData.Controls.Add(txtLastName);
            grpPersonalData.Controls.Add(txtFirstName);
            grpPersonalData.Controls.Add(label4);
            grpPersonalData.Location = new Point(16, 16);
            grpPersonalData.Margin = new Padding(0, 0, 0, 6);
            grpPersonalData.Name = "grpPersonalData";
            grpPersonalData.Padding = new Padding(3, 8, 3, 3);
            grpPersonalData.Size = new Size(420, 203);
            grpPersonalData.TabIndex = 25;
            grpPersonalData.TabStop = false;
            // 
            // btnUpdateBasicInformation
            // 
            btnUpdateBasicInformation.AutoSize = true;
            btnUpdateBasicInformation.Enabled = false;
            btnUpdateBasicInformation.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpdateBasicInformation.Location = new Point(335, 157);
            btnUpdateBasicInformation.Margin = new Padding(8, 0, 0, 0);
            btnUpdateBasicInformation.Name = "btnUpdateBasicInformation";
            btnUpdateBasicInformation.Size = new Size(75, 28);
            btnUpdateBasicInformation.TabIndex = 20;
            btnUpdateBasicInformation.Text = "Update";
            btnUpdateBasicInformation.UseVisualStyleBackColor = true;
            btnUpdateBasicInformation.Click += btnUpdateBasicInformation_Click;
            // 
            // txtEmailAddress
            // 
            txtEmailAddress.AccessibleName = "Email Address";
            txtEmailAddress.Location = new Point(10, 115);
            txtEmailAddress.Margin = new Padding(0, 0, 0, 16);
            txtEmailAddress.MaxLength = 100;
            txtEmailAddress.Name = "txtEmailAddress";
            txtEmailAddress.Size = new Size(400, 26);
            txtEmailAddress.TabIndex = 2;
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
            txtLastName.TabIndex = 1;
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
            // ViewAndEditProfileForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(452, 625);
            Controls.Add(pnlBody);
            Controls.Add(pnlHeader);
            Controls.Add(pnlFooter);
            Controls.Add(pnlLine1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ViewAndEditProfileForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Load += ViewAndEditProfileForm_Load;
            pnlFooter.ResumeLayout(false);
            flowFooterActions.ResumeLayout(false);
            flowFooterActions.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            grpPasswordData.ResumeLayout(false);
            grpPasswordData.PerformLayout();
            grpPersonalData.ResumeLayout(false);
            grpPersonalData.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLine1;
        private Panel pnlFooter;
        private Panel pnlHeader;
        private Panel pnlBody;
        private GroupBox grpPersonalData;
        private TextBox txtEmailAddress;
        private Label label3;
        private Label label22;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private Label label4;
        private Label label2;
        private GroupBox grpPasswordData;
        private TextBox txtConfirmPassword;
        private Label label13;
        private TextBox txtNewPassword;
        private Label label15;
        private TextBox txtOldPassword;
        private Label label17;
        private Label lblHiddenUserID;
        private FlowLayoutPanel flowFooterActions;
        private Button btnAction;
        private Button btnUndoChanges;
        private CheckBox chkChangePassword;
        private Button btnUpdateBasicInformation;
        private Button btnUpdatePassword;
        private Button btnClose;
    }
}