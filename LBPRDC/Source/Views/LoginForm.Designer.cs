namespace LBPRDC.Source.Views
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            pnlLogin = new Panel();
            btnConfiguration = new Button();
            lblVersionNumber = new Label();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            chkShowPassword = new CheckBox();
            btnSignIn = new Button();
            label3 = new Label();
            txtPassword = new TextBox();
            label2 = new Label();
            txtUsername = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            pnlLine1 = new Panel();
            pnlLine2 = new Panel();
            panel1 = new Panel();
            pnlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLogin
            // 
            pnlLogin.BackColor = SystemColors.Window;
            pnlLogin.Controls.Add(btnConfiguration);
            pnlLogin.Controls.Add(lblVersionNumber);
            pnlLogin.Controls.Add(label5);
            pnlLogin.Controls.Add(pictureBox1);
            pnlLogin.Controls.Add(chkShowPassword);
            pnlLogin.Controls.Add(btnSignIn);
            pnlLogin.Controls.Add(label3);
            pnlLogin.Controls.Add(txtPassword);
            pnlLogin.Controls.Add(label2);
            pnlLogin.Controls.Add(txtUsername);
            pnlLogin.Controls.Add(label1);
            pnlLogin.Dock = DockStyle.Right;
            pnlLogin.Location = new Point(764, 0);
            pnlLogin.Margin = new Padding(3, 4, 3, 4);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Padding = new Padding(80);
            pnlLogin.Size = new Size(500, 760);
            pnlLogin.TabIndex = 0;
            // 
            // btnConfiguration
            // 
            btnConfiguration.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnConfiguration.Cursor = Cursors.Hand;
            btnConfiguration.FlatAppearance.BorderSize = 0;
            btnConfiguration.FlatStyle = FlatStyle.Flat;
            btnConfiguration.Image = (Image)resources.GetObject("btnConfiguration.Image");
            btnConfiguration.Location = new Point(449, 11);
            btnConfiguration.Name = "btnConfiguration";
            btnConfiguration.Size = new Size(40, 40);
            btnConfiguration.TabIndex = 7;
            btnConfiguration.UseVisualStyleBackColor = true;
            btnConfiguration.Click += btnConfiguration_Click;
            // 
            // lblVersionNumber
            // 
            lblVersionNumber.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblVersionNumber.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblVersionNumber.Location = new Point(83, 714);
            lblVersionNumber.Margin = new Padding(4);
            lblVersionNumber.Name = "lblVersionNumber";
            lblVersionNumber.Size = new Size(334, 15);
            lblVersionNumber.TabIndex = 5;
            lblVersionNumber.Text = "v1.0.0";
            lblVersionNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(83, 733);
            label5.Margin = new Padding(3, 0, 3, 4);
            label5.Name = "label5";
            label5.Size = new Size(334, 15);
            label5.TabIndex = 6;
            label5.Text = "© LBP Resource And Development Corporation, 2023";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(83, 82);
            pictureBox1.Margin = new Padding(3, 4, 3, 48);
            pictureBox1.MinimumSize = new Size(100, 100);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(334, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // chkShowPassword
            // 
            chkShowPassword.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            chkShowPassword.AutoSize = true;
            chkShowPassword.Location = new Point(83, 420);
            chkShowPassword.Margin = new Padding(3, 3, 3, 32);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(140, 22);
            chkShowPassword.TabIndex = 2;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // btnSignIn
            // 
            btnSignIn.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnSignIn.AutoSize = true;
            btnSignIn.Location = new Point(83, 477);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(334, 34);
            btnSignIn.TabIndex = 3;
            btnSignIn.Text = "Sign In";
            btnSignIn.UseVisualStyleBackColor = true;
            btnSignIn.Click += btnSignIn_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(79, 362);
            label3.Margin = new Padding(3, 0, 3, 4);
            label3.Name = "label3";
            label3.Size = new Size(78, 18);
            label3.TabIndex = 4;
            label3.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Location = new Point(83, 387);
            txtPassword.Margin = new Padding(3, 3, 3, 4);
            txtPassword.MaxLength = 16;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(334, 26);
            txtPassword.TabIndex = 1;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.KeyPress += txtPassword_KeyPress;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(79, 291);
            label2.Margin = new Padding(3, 0, 3, 4);
            label2.Name = "label2";
            label2.Size = new Size(80, 18);
            label2.TabIndex = 2;
            label2.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtUsername.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsername.Location = new Point(83, 316);
            txtUsername.Margin = new Padding(3, 3, 3, 20);
            txtUsername.MaxLength = 50;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(334, 26);
            txtUsername.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(76, 230);
            label1.Margin = new Padding(3, 0, 3, 32);
            label1.Name = "label1";
            label1.Size = new Size(95, 29);
            label1.TabIndex = 0;
            label1.Text = "Sign In";
            // 
            // panel2
            // 
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.Controls.Add(pnlLine1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(764, 760);
            panel2.TabIndex = 1;
            // 
            // pnlLine1
            // 
            pnlLine1.BorderStyle = BorderStyle.FixedSingle;
            pnlLine1.Dock = DockStyle.Right;
            pnlLine1.Location = new Point(763, 0);
            pnlLine1.Name = "pnlLine1";
            pnlLine1.Size = new Size(1, 760);
            pnlLine1.TabIndex = 0;
            // 
            // pnlLine2
            // 
            pnlLine2.BorderStyle = BorderStyle.FixedSingle;
            pnlLine2.Dock = DockStyle.Top;
            pnlLine2.Location = new Point(0, 0);
            pnlLine2.Name = "pnlLine2";
            pnlLine2.Size = new Size(1264, 1);
            pnlLine2.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(pnlLogin);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1264, 760);
            panel1.TabIndex = 3;
            // 
            // frmLogin
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1264, 761);
            Controls.Add(panel1);
            Controls.Add(pnlLine2);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MinimumSize = new Size(800, 800);
            Name = "frmLogin";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLogin;
        private Panel panel2;
        private PictureBox pictureBox1;
        private CheckBox chkShowPassword;
        private Label label3;
        private TextBox txtPassword;
        private Label label2;
        private TextBox txtUsername;
        private Label label1;
        private Label lblVersionNumber;
        private Label label5;
        private Button btnConfiguration;
        private Button btnSignIn;
        private Panel pnlLine1;
        private Panel pnlLine2;
        private Panel panel1;
    }
}