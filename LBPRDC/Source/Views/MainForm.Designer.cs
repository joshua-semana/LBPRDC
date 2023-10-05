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
            btnSignOut = new Button();
            label1 = new Label();
            lblDateToday = new Label();
            label2 = new Label();
            lblGreetUser = new Label();
            flowHeaderPages = new FlowLayoutPanel();
            btnEmployees = new Button();
            flowHeaderLogo = new FlowLayoutPanel();
            picLogo = new PictureBox();
            pnlHeader.SuspendLayout();
            flowHeaderActions.SuspendLayout();
            flowHeaderPages.SuspendLayout();
            flowHeaderLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(240, 253, 244);
            pnlHeader.Controls.Add(flowHeaderActions);
            pnlHeader.Controls.Add(flowHeaderPages);
            pnlHeader.Controls.Add(flowHeaderLogo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1264, 48);
            pnlHeader.TabIndex = 0;
            // 
            // flowHeaderActions
            // 
            flowHeaderActions.Controls.Add(btnSignOut);
            flowHeaderActions.Controls.Add(label1);
            flowHeaderActions.Controls.Add(lblDateToday);
            flowHeaderActions.Controls.Add(label2);
            flowHeaderActions.Controls.Add(lblGreetUser);
            flowHeaderActions.Dock = DockStyle.Right;
            flowHeaderActions.FlowDirection = FlowDirection.RightToLeft;
            flowHeaderActions.Location = new Point(764, 0);
            flowHeaderActions.Name = "flowHeaderActions";
            flowHeaderActions.Padding = new Padding(8, 0, 8, 0);
            flowHeaderActions.Size = new Size(500, 48);
            flowHeaderActions.TabIndex = 4;
            // 
            // btnSignOut
            // 
            btnSignOut.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSignOut.Cursor = Cursors.Hand;
            btnSignOut.FlatAppearance.BorderSize = 0;
            btnSignOut.FlatStyle = FlatStyle.Flat;
            btnSignOut.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSignOut.Location = new Point(409, 12);
            btnSignOut.Margin = new Padding(4, 12, 0, 0);
            btnSignOut.Name = "btnSignOut";
            btnSignOut.Size = new Size(75, 23);
            btnSignOut.TabIndex = 1;
            btnSignOut.Text = "Sign Out";
            btnSignOut.UseVisualStyleBackColor = true;
            btnSignOut.Click += btnSignOut_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(388, 9);
            label1.Margin = new Padding(0, 9, 0, 0);
            label1.Name = "label1";
            label1.Size = new Size(17, 25);
            label1.TabIndex = 2;
            label1.Text = "|";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDateToday
            // 
            lblDateToday.AutoEllipsis = true;
            lblDateToday.AutoSize = true;
            lblDateToday.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblDateToday.Location = new Point(307, 16);
            lblDateToday.Margin = new Padding(14, 16, 16, 0);
            lblDateToday.Name = "lblDateToday";
            lblDateToday.Size = new Size(65, 15);
            lblDateToday.TabIndex = 5;
            lblDateToday.Text = "Date Today";
            lblDateToday.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(276, 9);
            label2.Margin = new Padding(0, 9, 0, 0);
            label2.Name = "label2";
            label2.Size = new Size(17, 25);
            label2.TabIndex = 4;
            label2.Text = "|";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblGreetUser
            // 
            lblGreetUser.AutoEllipsis = true;
            lblGreetUser.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblGreetUser.Location = new Point(103, 12);
            lblGreetUser.Margin = new Padding(0, 12, 16, 0);
            lblGreetUser.Name = "lblGreetUser";
            lblGreetUser.Size = new Size(157, 23);
            lblGreetUser.TabIndex = 3;
            lblGreetUser.Text = "Greet User";
            lblGreetUser.TextAlign = ContentAlignment.MiddleRight;
            // 
            // flowHeaderPages
            // 
            flowHeaderPages.Controls.Add(btnEmployees);
            flowHeaderPages.Dock = DockStyle.Fill;
            flowHeaderPages.Location = new Point(64, 0);
            flowHeaderPages.Name = "flowHeaderPages";
            flowHeaderPages.Padding = new Padding(8, 0, 8, 0);
            flowHeaderPages.Size = new Size(1200, 48);
            flowHeaderPages.TabIndex = 3;
            // 
            // btnEmployees
            // 
            btnEmployees.Cursor = Cursors.Hand;
            btnEmployees.FlatAppearance.BorderSize = 0;
            btnEmployees.FlatStyle = FlatStyle.Flat;
            btnEmployees.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnEmployees.Location = new Point(8, 12);
            btnEmployees.Margin = new Padding(0, 12, 4, 0);
            btnEmployees.Name = "btnEmployees";
            btnEmployees.Size = new Size(75, 23);
            btnEmployees.TabIndex = 2;
            btnEmployees.Text = "Employees";
            btnEmployees.UseVisualStyleBackColor = true;
            // 
            // flowHeaderLogo
            // 
            flowHeaderLogo.Controls.Add(picLogo);
            flowHeaderLogo.Dock = DockStyle.Left;
            flowHeaderLogo.Location = new Point(0, 0);
            flowHeaderLogo.Name = "flowHeaderLogo";
            flowHeaderLogo.Padding = new Padding(12, 0, 12, 0);
            flowHeaderLogo.Size = new Size(64, 48);
            flowHeaderLogo.TabIndex = 2;
            // 
            // picLogo
            // 
            picLogo.BackgroundImage = (Image)resources.GetObject("picLogo.BackgroundImage");
            picLogo.BackgroundImageLayout = ImageLayout.Zoom;
            picLogo.Location = new Point(12, 4);
            picLogo.Margin = new Padding(0, 4, 4, 0);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(40, 40);
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // frmMain
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1264, 681);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1280, 720);
            Name = "frmMain";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += frmMain_FormClosing;
            Load += frmMain_Load;
            pnlHeader.ResumeLayout(false);
            flowHeaderActions.ResumeLayout(false);
            flowHeaderActions.PerformLayout();
            flowHeaderPages.ResumeLayout(false);
            flowHeaderLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private PictureBox picLogo;
        private Button btnSignOut;
        private FlowLayoutPanel flowHeaderActions;
        private FlowLayoutPanel flowHeaderPages;
        private FlowLayoutPanel flowHeaderLogo;
        private Button btnEmployees;
        private Label label1;
        private Label lblGreetUser;
        private Label lblDateToday;
        private Label label2;
    }
}