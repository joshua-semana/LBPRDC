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
            panel1 = new Panel();
            lblVersionNumber = new Label();
            pictureBox1 = new PictureBox();
            chkShowPassword = new CheckBox();
            btnLogin = new Button();
            label3 = new Label();
            txtPassword = new TextBox();
            label2 = new Label();
            txtUsername = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            label5 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(lblVersionNumber);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(chkShowPassword);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(764, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(80);
            panel1.Size = new Size(500, 681);
            panel1.TabIndex = 0;
            // 
            // lblVersionNumber
            // 
            lblVersionNumber.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblVersionNumber.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblVersionNumber.Location = new Point(83, 634);
            lblVersionNumber.Margin = new Padding(3, 0, 3, 4);
            lblVersionNumber.Name = "lblVersionNumber";
            lblVersionNumber.Size = new Size(334, 15);
            lblVersionNumber.TabIndex = 5;
            lblVersionNumber.Text = "v1.0.0";
            lblVersionNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(83, 81);
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
            chkShowPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            chkShowPassword.AutoSize = true;
            chkShowPassword.Location = new Point(83, 424);
            chkShowPassword.Margin = new Padding(3, 3, 3, 24);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(138, 25);
            chkShowPassword.TabIndex = 2;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnLogin.Location = new Point(83, 476);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(334, 34);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Sign In";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(78, 360);
            label3.Margin = new Padding(3, 0, 3, 4);
            label3.Name = "label3";
            label3.Size = new Size(76, 21);
            label3.TabIndex = 4;
            label3.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Location = new Point(83, 388);
            txtPassword.Margin = new Padding(3, 3, 3, 4);
            txtPassword.MaxLength = 16;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(334, 29);
            txtPassword.TabIndex = 1;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.KeyPress += txtPassword_KeyPress;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(78, 287);
            label2.Margin = new Padding(3, 0, 3, 4);
            label2.Name = "label2";
            label2.Size = new Size(81, 21);
            label2.TabIndex = 2;
            label2.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUsername.Location = new Point(83, 315);
            txtUsername.Margin = new Padding(3, 3, 3, 16);
            txtUsername.MaxLength = 50;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(334, 29);
            txtUsername.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(75, 231);
            label1.Margin = new Padding(3, 0, 3, 24);
            label1.Name = "label1";
            label1.Size = new Size(94, 32);
            label1.TabIndex = 0;
            label1.Text = "Sign In";
            // 
            // panel2
            // 
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(764, 681);
            panel2.TabIndex = 1;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(83, 653);
            label5.Margin = new Padding(3, 0, 3, 4);
            label5.Name = "label5";
            label5.Size = new Size(334, 15);
            label5.TabIndex = 6;
            label5.Text = "© LBP Resource And Development Corporation, 2023";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1264, 681);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MinimumSize = new Size(1280, 720);
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private CheckBox chkShowPassword;
        private Button btnLogin;
        private Label label3;
        private TextBox txtPassword;
        private Label label2;
        private TextBox txtUsername;
        private Label label1;
        private Label lblVersionNumber;
        private Label label5;
    }
}