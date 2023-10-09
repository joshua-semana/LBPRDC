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
            flowHeaderLeft = new FlowLayoutPanel();
            picLogo = new PictureBox();
            flowHeaderRight = new FlowLayoutPanel();
            lblDateToday = new Label();
            lblLine1 = new Label();
            lblGreetUser = new Label();
            pnlLine1 = new Panel();
            pnlMainContainer = new Panel();
            pnlContent = new Panel();
            pnlLine2 = new Panel();
            pnlSideNav = new Panel();
            flowSideNavBottom = new FlowLayoutPanel();
            btnSignOut = new Button();
            flowSideNavTop = new FlowLayoutPanel();
            btnNavHome = new Button();
            btnNavEmployees = new Button();
            btnAccounts = new Button();
            btnLogs = new Button();
            pnlLine3 = new Panel();
            pnlHeader.SuspendLayout();
            flowHeaderLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            flowHeaderRight.SuspendLayout();
            pnlMainContainer.SuspendLayout();
            pnlSideNav.SuspendLayout();
            flowSideNavBottom.SuspendLayout();
            flowSideNavTop.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = SystemColors.Window;
            pnlHeader.Controls.Add(flowHeaderLeft);
            pnlHeader.Controls.Add(flowHeaderRight);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1264, 50);
            pnlHeader.TabIndex = 0;
            // 
            // flowHeaderLeft
            // 
            flowHeaderLeft.BackColor = SystemColors.Window;
            flowHeaderLeft.Controls.Add(picLogo);
            flowHeaderLeft.Dock = DockStyle.Fill;
            flowHeaderLeft.Location = new Point(0, 0);
            flowHeaderLeft.Name = "flowHeaderLeft";
            flowHeaderLeft.Padding = new Padding(10, 0, 0, 0);
            flowHeaderLeft.Size = new Size(976, 50);
            flowHeaderLeft.TabIndex = 2;
            // 
            // picLogo
            // 
            picLogo.BackgroundImage = (Image)resources.GetObject("picLogo.BackgroundImage");
            picLogo.BackgroundImageLayout = ImageLayout.Zoom;
            picLogo.Location = new Point(10, 0);
            picLogo.Margin = new Padding(0);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(32, 50);
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            picLogo.Click += picLogo_Click;
            // 
            // flowHeaderRight
            // 
            flowHeaderRight.BackColor = SystemColors.Window;
            flowHeaderRight.Controls.Add(lblDateToday);
            flowHeaderRight.Controls.Add(lblLine1);
            flowHeaderRight.Controls.Add(lblGreetUser);
            flowHeaderRight.Dock = DockStyle.Right;
            flowHeaderRight.FlowDirection = FlowDirection.RightToLeft;
            flowHeaderRight.Location = new Point(976, 0);
            flowHeaderRight.Name = "flowHeaderRight";
            flowHeaderRight.Padding = new Padding(8, 0, 8, 0);
            flowHeaderRight.Size = new Size(288, 50);
            flowHeaderRight.TabIndex = 4;
            // 
            // lblDateToday
            // 
            lblDateToday.AutoEllipsis = true;
            lblDateToday.AutoSize = true;
            lblDateToday.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblDateToday.Location = new Point(193, 17);
            lblDateToday.Margin = new Padding(0, 17, 0, 0);
            lblDateToday.Name = "lblDateToday";
            lblDateToday.Size = new Size(79, 16);
            lblDateToday.TabIndex = 5;
            lblDateToday.Text = "Date Today";
            lblDateToday.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblLine1
            // 
            lblLine1.AutoSize = true;
            lblLine1.Font = new Font("Arial", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblLine1.Location = new Point(177, 12);
            lblLine1.Margin = new Padding(3, 12, 0, 0);
            lblLine1.Name = "lblLine1";
            lblLine1.Size = new Size(16, 22);
            lblLine1.TabIndex = 4;
            lblLine1.Text = "|";
            lblLine1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblGreetUser
            // 
            lblGreetUser.AutoEllipsis = true;
            lblGreetUser.AutoSize = true;
            lblGreetUser.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblGreetUser.Location = new Point(98, 17);
            lblGreetUser.Margin = new Padding(0, 17, 0, 0);
            lblGreetUser.Name = "lblGreetUser";
            lblGreetUser.Size = new Size(76, 16);
            lblGreetUser.TabIndex = 3;
            lblGreetUser.Text = "Greet User";
            lblGreetUser.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlLine1
            // 
            pnlLine1.BorderStyle = BorderStyle.FixedSingle;
            pnlLine1.Dock = DockStyle.Top;
            pnlLine1.Location = new Point(0, 0);
            pnlLine1.Name = "pnlLine1";
            pnlLine1.Size = new Size(1264, 1);
            pnlLine1.TabIndex = 1;
            // 
            // pnlMainContainer
            // 
            pnlMainContainer.Controls.Add(pnlContent);
            pnlMainContainer.Controls.Add(pnlLine2);
            pnlMainContainer.Controls.Add(pnlSideNav);
            pnlMainContainer.Controls.Add(pnlLine3);
            pnlMainContainer.Controls.Add(pnlHeader);
            pnlMainContainer.Dock = DockStyle.Fill;
            pnlMainContainer.Location = new Point(0, 1);
            pnlMainContainer.Name = "pnlMainContainer";
            pnlMainContainer.Size = new Size(1264, 680);
            pnlMainContainer.TabIndex = 2;
            // 
            // pnlContent
            // 
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(51, 51);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1213, 629);
            pnlContent.TabIndex = 5;
            // 
            // pnlLine2
            // 
            pnlLine2.BorderStyle = BorderStyle.FixedSingle;
            pnlLine2.Dock = DockStyle.Left;
            pnlLine2.Location = new Point(50, 51);
            pnlLine2.Name = "pnlLine2";
            pnlLine2.Size = new Size(1, 629);
            pnlLine2.TabIndex = 2;
            // 
            // pnlSideNav
            // 
            pnlSideNav.Controls.Add(flowSideNavBottom);
            pnlSideNav.Controls.Add(flowSideNavTop);
            pnlSideNav.Dock = DockStyle.Left;
            pnlSideNav.Location = new Point(0, 51);
            pnlSideNav.Name = "pnlSideNav";
            pnlSideNav.Size = new Size(50, 629);
            pnlSideNav.TabIndex = 4;
            // 
            // flowSideNavBottom
            // 
            flowSideNavBottom.Controls.Add(btnSignOut);
            flowSideNavBottom.Dock = DockStyle.Bottom;
            flowSideNavBottom.FlowDirection = FlowDirection.BottomUp;
            flowSideNavBottom.Location = new Point(0, 576);
            flowSideNavBottom.Name = "flowSideNavBottom";
            flowSideNavBottom.Size = new Size(50, 53);
            flowSideNavBottom.TabIndex = 5;
            // 
            // btnSignOut
            // 
            btnSignOut.Cursor = Cursors.Hand;
            btnSignOut.FlatAppearance.BorderSize = 0;
            btnSignOut.FlatStyle = FlatStyle.Flat;
            btnSignOut.Image = (Image)resources.GetObject("btnSignOut.Image");
            btnSignOut.Location = new Point(0, 3);
            btnSignOut.Margin = new Padding(0);
            btnSignOut.Name = "btnSignOut";
            btnSignOut.Size = new Size(50, 50);
            btnSignOut.TabIndex = 12;
            btnSignOut.Tag = "";
            btnSignOut.UseVisualStyleBackColor = true;
            btnSignOut.Click += btnSignOut_Click;
            // 
            // flowSideNavTop
            // 
            flowSideNavTop.Controls.Add(btnNavHome);
            flowSideNavTop.Controls.Add(btnNavEmployees);
            flowSideNavTop.Controls.Add(btnAccounts);
            flowSideNavTop.Controls.Add(btnLogs);
            flowSideNavTop.Dock = DockStyle.Fill;
            flowSideNavTop.FlowDirection = FlowDirection.TopDown;
            flowSideNavTop.Location = new Point(0, 0);
            flowSideNavTop.Name = "flowSideNavTop";
            flowSideNavTop.Size = new Size(50, 629);
            flowSideNavTop.TabIndex = 1;
            // 
            // btnNavHome
            // 
            btnNavHome.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNavHome.Cursor = Cursors.Hand;
            btnNavHome.FlatAppearance.BorderSize = 0;
            btnNavHome.FlatStyle = FlatStyle.Flat;
            btnNavHome.Image = (Image)resources.GetObject("btnNavHome.Image");
            btnNavHome.Location = new Point(0, 0);
            btnNavHome.Margin = new Padding(0);
            btnNavHome.Name = "btnNavHome";
            btnNavHome.Size = new Size(50, 50);
            btnNavHome.TabIndex = 8;
            btnNavHome.Tag = "Home";
            btnNavHome.UseVisualStyleBackColor = true;
            // 
            // btnNavEmployees
            // 
            btnNavEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNavEmployees.Cursor = Cursors.Hand;
            btnNavEmployees.FlatAppearance.BorderSize = 0;
            btnNavEmployees.FlatStyle = FlatStyle.Flat;
            btnNavEmployees.Image = (Image)resources.GetObject("btnNavEmployees.Image");
            btnNavEmployees.Location = new Point(0, 50);
            btnNavEmployees.Margin = new Padding(0);
            btnNavEmployees.Name = "btnNavEmployees";
            btnNavEmployees.Size = new Size(50, 50);
            btnNavEmployees.TabIndex = 9;
            btnNavEmployees.Tag = "Employees";
            btnNavEmployees.UseVisualStyleBackColor = true;
            // 
            // btnAccounts
            // 
            btnAccounts.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAccounts.Cursor = Cursors.Hand;
            btnAccounts.FlatAppearance.BorderSize = 0;
            btnAccounts.FlatStyle = FlatStyle.Flat;
            btnAccounts.Image = (Image)resources.GetObject("btnAccounts.Image");
            btnAccounts.Location = new Point(0, 100);
            btnAccounts.Margin = new Padding(0);
            btnAccounts.Name = "btnAccounts";
            btnAccounts.Size = new Size(50, 50);
            btnAccounts.TabIndex = 10;
            btnAccounts.Tag = "Accounts";
            btnAccounts.UseVisualStyleBackColor = true;
            // 
            // btnLogs
            // 
            btnLogs.Cursor = Cursors.Hand;
            btnLogs.FlatAppearance.BorderSize = 0;
            btnLogs.FlatStyle = FlatStyle.Flat;
            btnLogs.Image = (Image)resources.GetObject("btnLogs.Image");
            btnLogs.Location = new Point(0, 150);
            btnLogs.Margin = new Padding(0);
            btnLogs.Name = "btnLogs";
            btnLogs.Size = new Size(50, 50);
            btnLogs.TabIndex = 11;
            btnLogs.Tag = "Logs";
            btnLogs.UseVisualStyleBackColor = true;
            // 
            // pnlLine3
            // 
            pnlLine3.BorderStyle = BorderStyle.FixedSingle;
            pnlLine3.Dock = DockStyle.Top;
            pnlLine3.Location = new Point(0, 50);
            pnlLine3.Name = "pnlLine3";
            pnlLine3.Size = new Size(1264, 1);
            pnlLine3.TabIndex = 3;
            // 
            // frmMain
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1264, 681);
            Controls.Add(pnlMainContainer);
            Controls.Add(pnlLine1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(800, 600);
            Name = "frmMain";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += frmMain_FormClosing;
            Load += frmMain_Load;
            pnlHeader.ResumeLayout(false);
            flowHeaderLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            flowHeaderRight.ResumeLayout(false);
            flowHeaderRight.PerformLayout();
            pnlMainContainer.ResumeLayout(false);
            pnlSideNav.ResumeLayout(false);
            flowSideNavBottom.ResumeLayout(false);
            flowSideNavTop.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private PictureBox picLogo;
        private FlowLayoutPanel flowHeaderRight;
        private FlowLayoutPanel flowHeaderPages;
        private FlowLayoutPanel flowHeaderLeft;
        private Button btnNavEmployees;
        private Label lblGreetUser;
        private Label lblDateToday;
        private Label lblLine1;
        private Label label1;
        private Button btnHome;
        private Button btnAccounts;
        private Panel pnlLine1;
        private Panel pnlMainContainer;
        private FlowLayoutPanel flowSideNavTop;
        private Panel pnlLine2;
        private Button btnNavHome;
        private Button btnSignOut;
        private Panel pnlLine3;
        private Button btnLogs;
        private Panel pnlSideNav;
        private FlowLayoutPanel flowSideNavBottom;
        private Panel pnlContent;
    }
}