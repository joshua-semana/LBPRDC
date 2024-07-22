namespace LBPRDC.Source.Views.Accounts
{
    partial class EditUserForAdminForm
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
            label32 = new Label();
            flowFooterActions = new FlowLayoutPanel();
            btnSave = new Button();
            btnCancel = new Button();
            pnlHeader = new Panel();
            label2 = new Label();
            pnlBody = new Panel();
            grpAccountData = new GroupBox();
            txtUserID = new TextBox();
            label4 = new Label();
            label19 = new Label();
            label18 = new Label();
            label1 = new Label();
            cmbStatus = new ComboBox();
            label5 = new Label();
            cmbRole = new ComboBox();
            txtUsername = new TextBox();
            label11 = new Label();
            pnlFooter.SuspendLayout();
            flowFooterActions.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlBody.SuspendLayout();
            grpAccountData.SuspendLayout();
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
            pnlFooter.Controls.Add(label32);
            pnlFooter.Controls.Add(flowFooterActions);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 247);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(452, 60);
            pnlFooter.TabIndex = 1;
            // 
            // label32
            // 
            label32.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label32.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label32.Location = new Point(13, 10);
            label32.Margin = new Padding(3, 0, 3, 4);
            label32.Name = "label32";
            label32.Size = new Size(207, 40);
            label32.TabIndex = 18;
            label32.Text = "All text fields marked with a red asterisk (*) are required.";
            label32.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // flowFooterActions
            // 
            flowFooterActions.Controls.Add(btnSave);
            flowFooterActions.Controls.Add(btnCancel);
            flowFooterActions.Dock = DockStyle.Right;
            flowFooterActions.FlowDirection = FlowDirection.RightToLeft;
            flowFooterActions.Location = new Point(262, 0);
            flowFooterActions.Name = "flowFooterActions";
            flowFooterActions.Padding = new Padding(15, 16, 0, 16);
            flowFooterActions.Size = new Size(190, 60);
            flowFooterActions.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Location = new Point(100, 16);
            btnSave.Margin = new Padding(8, 0, 0, 0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 28);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.Location = new Point(17, 16);
            btnCancel.Margin = new Padding(0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 28);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = SystemColors.Control;
            pnlHeader.Controls.Add(label2);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 1);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(452, 40);
            pnlHeader.TabIndex = 2;
            // 
            // label2
            // 
            label2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(54, 11);
            label2.Margin = new Padding(0, 0, 0, 16);
            label2.Name = "label2";
            label2.Size = new Size(345, 19);
            label2.TabIndex = 24;
            label2.Text = "USER ACCOUNT";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(grpAccountData);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 41);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(16);
            pnlBody.Size = new Size(452, 206);
            pnlBody.TabIndex = 3;
            // 
            // grpAccountData
            // 
            grpAccountData.Controls.Add(txtUserID);
            grpAccountData.Controls.Add(label4);
            grpAccountData.Controls.Add(label19);
            grpAccountData.Controls.Add(label18);
            grpAccountData.Controls.Add(label1);
            grpAccountData.Controls.Add(cmbStatus);
            grpAccountData.Controls.Add(label5);
            grpAccountData.Controls.Add(cmbRole);
            grpAccountData.Controls.Add(txtUsername);
            grpAccountData.Controls.Add(label11);
            grpAccountData.Location = new Point(16, 16);
            grpAccountData.Margin = new Padding(0, 0, 0, 8);
            grpAccountData.Name = "grpAccountData";
            grpAccountData.Padding = new Padding(3, 8, 3, 3);
            grpAccountData.Size = new Size(420, 166);
            grpAccountData.TabIndex = 26;
            grpAccountData.TabStop = false;
            grpAccountData.Text = "Account Information";
            // 
            // txtUserID
            // 
            txtUserID.AccessibleName = "Username";
            txtUserID.Location = new Point(10, 50);
            txtUserID.Margin = new Padding(7, 3, 3, 16);
            txtUserID.MaxLength = 50;
            txtUserID.Name = "txtUserID";
            txtUserID.ReadOnly = true;
            txtUserID.Size = new Size(100, 26);
            txtUserID.TabIndex = 23;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(6, 27);
            label4.Margin = new Padding(3, 0, 0, 4);
            label4.Name = "label4";
            label4.Size = new Size(53, 16);
            label4.TabIndex = 24;
            label4.Text = "User ID";
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
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(209, 92);
            label1.Margin = new Padding(3, 0, 0, 4);
            label1.Name = "label1";
            label1.Size = new Size(47, 16);
            label1.TabIndex = 20;
            label1.Text = "Status";
            // 
            // cmbStatus
            // 
            cmbStatus.AccessibleName = "Status";
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "(Choose Status)", "Active", "Inactive" });
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
            cmbRole.Location = new Point(10, 115);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(197, 26);
            cmbRole.TabIndex = 17;
            // 
            // txtUsername
            // 
            txtUsername.AccessibleName = "Username";
            txtUsername.Location = new Point(120, 50);
            txtUsername.Margin = new Padding(7, 3, 3, 16);
            txtUsername.MaxLength = 50;
            txtUsername.Name = "txtUsername";
            txtUsername.ReadOnly = true;
            txtUsername.Size = new Size(290, 26);
            txtUsername.TabIndex = 0;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(116, 27);
            label11.Margin = new Padding(3, 0, 0, 4);
            label11.Name = "label11";
            label11.Size = new Size(71, 16);
            label11.TabIndex = 0;
            label11.Text = "Username";
            // 
            // EditUserForAdminForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(452, 307);
            Controls.Add(pnlBody);
            Controls.Add(pnlHeader);
            Controls.Add(pnlFooter);
            Controls.Add(pnlLine1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditUserForAdminForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Update";
            Load += EditUserForAdminForm_Load;
            pnlFooter.ResumeLayout(false);
            flowFooterActions.ResumeLayout(false);
            flowFooterActions.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlBody.ResumeLayout(false);
            grpAccountData.ResumeLayout(false);
            grpAccountData.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLine1;
        private Panel pnlFooter;
        private Panel pnlHeader;
        private Panel pnlBody;
        private Label label2;
        private FlowLayoutPanel flowFooterActions;
        private Button btnSave;
        private Button btnCancel;
        private GroupBox grpAccountData;
        private Label label19;
        private Label label18;
        private Label label1;
        private ComboBox cmbStatus;
        private Label label5;
        private ComboBox cmbRole;
        private TextBox txtUsername;
        private Label label11;
        private Label label32;
        private TextBox txtUserID;
        private Label label4;
    }
}