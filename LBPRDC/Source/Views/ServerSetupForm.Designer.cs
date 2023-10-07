namespace LBPRDC.Source.Views
{
    partial class frmServerSetup
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
            flowControls = new FlowLayoutPanel();
            btnApply = new Button();
            btnAction = new Button();
            btnTestConnection = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtServerName = new TextBox();
            txtDatabaseName = new TextBox();
            txtUserID = new TextBox();
            txtPassword = new TextBox();
            grpControls = new GroupBox();
            flowControls.SuspendLayout();
            grpControls.SuspendLayout();
            SuspendLayout();
            // 
            // flowControls
            // 
            flowControls.BackColor = SystemColors.Control;
            flowControls.Controls.Add(btnApply);
            flowControls.Controls.Add(btnAction);
            flowControls.Controls.Add(btnTestConnection);
            flowControls.Dock = DockStyle.Bottom;
            flowControls.FlowDirection = FlowDirection.RightToLeft;
            flowControls.Location = new Point(0, 207);
            flowControls.Name = "flowControls";
            flowControls.Padding = new Padding(0, 8, 8, 0);
            flowControls.Size = new Size(434, 50);
            flowControls.TabIndex = 0;
            // 
            // btnApply
            // 
            btnApply.AutoSize = true;
            btnApply.Enabled = false;
            btnApply.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnApply.Location = new Point(348, 11);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(75, 28);
            btnApply.TabIndex = 0;
            btnApply.Text = "Apply";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // btnAction
            // 
            btnAction.AutoSize = true;
            btnAction.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnAction.Location = new Point(267, 11);
            btnAction.Margin = new Padding(16, 3, 3, 3);
            btnAction.Name = "btnAction";
            btnAction.Size = new Size(75, 28);
            btnAction.TabIndex = 1;
            btnAction.Text = "Edit";
            btnAction.UseVisualStyleBackColor = true;
            btnAction.Click += btnAction_Click;
            // 
            // btnTestConnection
            // 
            btnTestConnection.AutoSize = true;
            btnTestConnection.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnTestConnection.Location = new Point(119, 11);
            btnTestConnection.Name = "btnTestConnection";
            btnTestConnection.Size = new Size(129, 28);
            btnTestConnection.TabIndex = 2;
            btnTestConnection.Text = "Test Connection";
            btnTestConnection.UseVisualStyleBackColor = true;
            btnTestConnection.Click += btnTestConnection_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(26, 28);
            label2.Margin = new Padding(8, 8, 0, 32);
            label2.Name = "label2";
            label2.Size = new Size(93, 16);
            label2.TabIndex = 2;
            label2.Text = "Server Name:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(7, 65);
            label3.Margin = new Padding(8, 8, 0, 32);
            label3.Name = "label3";
            label3.Size = new Size(112, 16);
            label3.TabIndex = 3;
            label3.Text = "Database Name:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(62, 102);
            label4.Margin = new Padding(8, 8, 0, 32);
            label4.Name = "label4";
            label4.Size = new Size(57, 16);
            label4.TabIndex = 4;
            label4.Text = "User ID:";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(47, 139);
            label5.Margin = new Padding(8, 8, 0, 32);
            label5.Name = "label5";
            label5.Size = new Size(72, 16);
            label5.TabIndex = 5;
            label5.Text = "Password:";
            // 
            // txtServerName
            // 
            txtServerName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtServerName.Enabled = false;
            txtServerName.Location = new Point(122, 23);
            txtServerName.Margin = new Padding(3, 3, 8, 8);
            txtServerName.MaxLength = 50;
            txtServerName.Name = "txtServerName";
            txtServerName.Size = new Size(277, 26);
            txtServerName.TabIndex = 6;
            // 
            // txtDatabaseName
            // 
            txtDatabaseName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtDatabaseName.Enabled = false;
            txtDatabaseName.Location = new Point(122, 60);
            txtDatabaseName.Margin = new Padding(3, 3, 8, 8);
            txtDatabaseName.MaxLength = 50;
            txtDatabaseName.Name = "txtDatabaseName";
            txtDatabaseName.Size = new Size(277, 26);
            txtDatabaseName.TabIndex = 7;
            // 
            // txtUserID
            // 
            txtUserID.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtUserID.Enabled = false;
            txtUserID.Location = new Point(122, 97);
            txtUserID.Margin = new Padding(3, 3, 8, 8);
            txtUserID.MaxLength = 50;
            txtUserID.Name = "txtUserID";
            txtUserID.Size = new Size(277, 26);
            txtUserID.TabIndex = 8;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPassword.Enabled = false;
            txtPassword.Location = new Point(122, 134);
            txtPassword.Margin = new Padding(3, 3, 8, 8);
            txtPassword.MaxLength = 50;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(277, 26);
            txtPassword.TabIndex = 9;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // grpControls
            // 
            grpControls.Controls.Add(txtServerName);
            grpControls.Controls.Add(label5);
            grpControls.Controls.Add(txtDatabaseName);
            grpControls.Controls.Add(label3);
            grpControls.Controls.Add(label4);
            grpControls.Controls.Add(txtPassword);
            grpControls.Controls.Add(txtUserID);
            grpControls.Controls.Add(label2);
            grpControls.Location = new Point(12, 12);
            grpControls.Name = "grpControls";
            grpControls.Size = new Size(410, 176);
            grpControls.TabIndex = 12;
            grpControls.TabStop = false;
            grpControls.Text = "Setup";
            // 
            // frmServerSetup
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Window;
            ClientSize = new Size(434, 257);
            Controls.Add(grpControls);
            Controls.Add(flowControls);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(450, 1000);
            MinimizeBox = false;
            MinimumSize = new Size(400, 255);
            Name = "frmServerSetup";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Server Setup Configuration";
            Load += frmServerSetup_Load;
            flowControls.ResumeLayout(false);
            flowControls.PerformLayout();
            grpControls.ResumeLayout(false);
            grpControls.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel flowControls;
        private Button btnAction;
        private Button btnApply;
        private Button btnTestConnection;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtServerName;
        private TextBox txtDatabaseName;
        private TextBox txtUserID;
        private TextBox txtPassword;
        private GroupBox grpControls;
    }
}