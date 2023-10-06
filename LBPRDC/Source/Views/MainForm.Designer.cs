namespace LBPRDC.Source.Views
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            pnlHeader = new Panel();
            flowHeaderActions = new FlowLayoutPanel();
            lblDateToday = new Label();
            label2 = new Label();
            lblGreetUser = new Label();
            flowHeader = new FlowLayoutPanel();
            picLogo = new PictureBox();
            label1 = new Label();
            btnHome = new Button();
            btnEmployees = new Button();
            btnAccounts = new Button();
            menuStrip1 = new MenuStrip();
            menuAccount = new ToolStripMenuItem();
            menuItemLogs = new ToolStripMenuItem();
            menuItemSignOut = new ToolStripMenuItem();
            pnlHeader.SuspendLayout();
            flowHeaderActions.SuspendLayout();
            flowHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(187, 247, 208);
            pnlHeader.Controls.Add(flowHeaderActions);
            pnlHeader.Controls.Add(flowHeader);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 24);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1264, 50);
            pnlHeader.TabIndex = 0;
            // 
            // flowHeaderActions
            // 
            flowHeaderActions.BackColor = Color.FromArgb(209, 235, 224);
            flowHeaderActions.Controls.Add(lblDateToday);
            flowHeaderActions.Controls.Add(label2);
            flowHeaderActions.Controls.Add(lblGreetUser);
            flowHeaderActions.Dock = DockStyle.Right;
            flowHeaderActions.FlowDirection = FlowDirection.RightToLeft;
            flowHeaderActions.Location = new Point(964, 0);
            flowHeaderActions.Name = "flowHeaderActions";
            flowHeaderActions.Padding = new Padding(8, 0, 8, 0);
            flowHeaderActions.Size = new Size(300, 50);
            flowHeaderActions.TabIndex = 4;
            // 
            // lblDateToday
            // 
            lblDateToday.AutoEllipsis = true;
            lblDateToday.AutoSize = true;
            lblDateToday.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblDateToday.Location = new Point(215, 17);
            lblDateToday.Margin = new Padding(0, 17, 0, 0);
            lblDateToday.Name = "lblDateToday";
            lblDateToday.Size = new Size(69, 15);
            lblDateToday.TabIndex = 5;
            lblDateToday.Text = "Date Today";
            lblDateToday.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(198, 10);
            label2.Margin = new Padding(3, 10, 0, 0);
            label2.Name = "label2";
            label2.Size = new Size(17, 25);
            label2.TabIndex = 4;
            label2.Text = "|";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblGreetUser
            // 
            lblGreetUser.AutoEllipsis = true;
            lblGreetUser.AutoSize = true;
            lblGreetUser.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblGreetUser.Location = new Point(126, 17);
            lblGreetUser.Margin = new Padding(0, 17, 0, 0);
            lblGreetUser.Name = "lblGreetUser";
            lblGreetUser.Size = new Size(69, 15);
            lblGreetUser.TabIndex = 3;
            lblGreetUser.Text = "Greet User";
            lblGreetUser.TextAlign = ContentAlignment.MiddleRight;
            // 
            // flowHeader
            // 
            flowHeader.BackColor = Color.FromArgb(209, 235, 224);
            flowHeader.Controls.Add(picLogo);
            flowHeader.Controls.Add(label1);
            flowHeader.Controls.Add(btnHome);
            flowHeader.Controls.Add(btnEmployees);
            flowHeader.Controls.Add(btnAccounts);
            flowHeader.Dock = DockStyle.Fill;
            flowHeader.Location = new Point(0, 0);
            flowHeader.Name = "flowHeader";
            flowHeader.Padding = new Padding(12, 0, 12, 0);
            flowHeader.Size = new Size(1264, 50);
            flowHeader.TabIndex = 2;
            // 
            // picLogo
            // 
            picLogo.BackgroundImage = (Image)resources.GetObject("picLogo.BackgroundImage");
            picLogo.BackgroundImageLayout = ImageLayout.Zoom;
            picLogo.Location = new Point(12, 9);
            picLogo.Margin = new Padding(0, 9, 0, 0);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(30, 30);
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(50, 10);
            label1.Margin = new Padding(8, 10, 0, 0);
            label1.Name = "label1";
            label1.Size = new Size(17, 25);
            label1.TabIndex = 5;
            label1.Text = "|";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnHome
            // 
            btnHome.Cursor = Cursors.Hand;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnHome.Location = new Point(67, 13);
            btnHome.Margin = new Padding(0, 13, 4, 0);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(49, 23);
            btnHome.TabIndex = 6;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = true;
            // 
            // btnEmployees
            // 
            btnEmployees.Cursor = Cursors.Hand;
            btnEmployees.FlatAppearance.BorderSize = 0;
            btnEmployees.FlatStyle = FlatStyle.Flat;
            btnEmployees.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnEmployees.Location = new Point(120, 13);
            btnEmployees.Margin = new Padding(0, 13, 4, 0);
            btnEmployees.Name = "btnEmployees";
            btnEmployees.Size = new Size(76, 23);
            btnEmployees.TabIndex = 2;
            btnEmployees.Text = "Employees";
            btnEmployees.UseVisualStyleBackColor = true;
            // 
            // btnAccounts
            // 
            btnAccounts.Cursor = Cursors.Hand;
            btnAccounts.FlatAppearance.BorderSize = 0;
            btnAccounts.FlatStyle = FlatStyle.Flat;
            btnAccounts.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnAccounts.Location = new Point(200, 13);
            btnAccounts.Margin = new Padding(0, 13, 4, 0);
            btnAccounts.Name = "btnAccounts";
            btnAccounts.Size = new Size(65, 23);
            btnAccounts.TabIndex = 7;
            btnAccounts.Text = "Accounts";
            btnAccounts.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(173, 220, 202);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuAccount });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1264, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuAccount
            // 
            menuAccount.DropDownItems.AddRange(new ToolStripItem[] { menuItemLogs, menuItemSignOut });
            menuAccount.Name = "menuAccount";
            menuAccount.Size = new Size(64, 20);
            menuAccount.Text = "Account";
            // 
            // menuItemLogs
            // 
            menuItemLogs.Name = "menuItemLogs";
            menuItemLogs.Size = new Size(120, 22);
            menuItemLogs.Text = "Logs";
            // 
            // menuItemSignOut
            // 
            menuItemSignOut.Name = "menuItemSignOut";
            menuItemSignOut.Size = new Size(120, 22);
            menuItemSignOut.Text = "Sign Out";
            menuItemSignOut.Click += menuItemSignOut_Click;
            // 
            // frmMain
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1264, 681);
            Controls.Add(pnlHeader);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(800, 600);
            Name = "frmMain";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += frmMain_FormClosing;
            Load += frmMain_Load;
            pnlHeader.ResumeLayout(false);
            flowHeaderActions.ResumeLayout(false);
            flowHeaderActions.PerformLayout();
            flowHeader.ResumeLayout(false);
            flowHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private PictureBox picLogo;
        private FlowLayoutPanel flowHeaderActions;
        private FlowLayoutPanel flowHeaderPages;
        private FlowLayoutPanel flowHeader;
        private Button btnEmployees;
        private Label lblGreetUser;
        private Label lblDateToday;
        private Label label2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuAccount;
        private ToolStripMenuItem menuItemSignOut;
        private Label label1;
        private Button btnHome;
        private Button btnAccounts;
        private ToolStripMenuItem menuItemLogs;
    }
}