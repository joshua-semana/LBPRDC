namespace LBPRDC.Source.Views.Accounts
{
    partial class ViewGeneratedPassword
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
            lblNotifCopied = new Label();
            flowFooterActions = new FlowLayoutPanel();
            btnDone = new Button();
            btnCopyPassword = new Button();
            pnlHeader = new Panel();
            label2 = new Label();
            pnlBody = new Panel();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            txtPassword = new TextBox();
            pnlFooter.SuspendLayout();
            flowFooterActions.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlBody.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLine1
            // 
            pnlLine1.BorderStyle = BorderStyle.FixedSingle;
            pnlLine1.Dock = DockStyle.Top;
            pnlLine1.Location = new Point(0, 0);
            pnlLine1.Name = "pnlLine1";
            pnlLine1.Size = new Size(484, 1);
            pnlLine1.TabIndex = 0;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = SystemColors.Control;
            pnlFooter.Controls.Add(lblNotifCopied);
            pnlFooter.Controls.Add(flowFooterActions);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 270);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(484, 60);
            pnlFooter.TabIndex = 1;
            // 
            // lblNotifCopied
            // 
            lblNotifCopied.AutoSize = true;
            lblNotifCopied.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblNotifCopied.Location = new Point(12, 22);
            lblNotifCopied.Name = "lblNotifCopied";
            lblNotifCopied.Size = new Size(204, 16);
            lblNotifCopied.TabIndex = 4;
            lblNotifCopied.Text = "✓ Password copied to clipboard";
            lblNotifCopied.TextAlign = ContentAlignment.MiddleCenter;
            lblNotifCopied.Visible = false;
            // 
            // flowFooterActions
            // 
            flowFooterActions.Controls.Add(btnDone);
            flowFooterActions.Controls.Add(btnCopyPassword);
            flowFooterActions.Dock = DockStyle.Right;
            flowFooterActions.FlowDirection = FlowDirection.RightToLeft;
            flowFooterActions.Location = new Point(238, 0);
            flowFooterActions.Name = "flowFooterActions";
            flowFooterActions.Padding = new Padding(15, 16, 0, 16);
            flowFooterActions.Size = new Size(246, 60);
            flowFooterActions.TabIndex = 1;
            // 
            // btnDone
            // 
            btnDone.AutoSize = true;
            btnDone.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnDone.Location = new Point(156, 16);
            btnDone.Margin = new Padding(8, 0, 0, 0);
            btnDone.Name = "btnDone";
            btnDone.Size = new Size(75, 28);
            btnDone.TabIndex = 8;
            btnDone.Text = "Done";
            btnDone.UseVisualStyleBackColor = true;
            btnDone.Click += btnDone_Click;
            // 
            // btnCopyPassword
            // 
            btnCopyPassword.AutoSize = true;
            btnCopyPassword.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnCopyPassword.Location = new Point(19, 16);
            btnCopyPassword.Margin = new Padding(0);
            btnCopyPassword.Name = "btnCopyPassword";
            btnCopyPassword.Size = new Size(129, 28);
            btnCopyPassword.TabIndex = 7;
            btnCopyPassword.Text = "Copy Password";
            btnCopyPassword.UseVisualStyleBackColor = true;
            btnCopyPassword.Click += btnCopyPassword_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = SystemColors.Control;
            pnlHeader.Controls.Add(label2);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 1);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(484, 40);
            pnlHeader.TabIndex = 2;
            // 
            // label2
            // 
            label2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(70, 11);
            label2.Margin = new Padding(0, 0, 0, 16);
            label2.Name = "label2";
            label2.Size = new Size(345, 19);
            label2.TabIndex = 25;
            label2.Text = "NEW GENERATED PASSWORD";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(label4);
            pnlBody.Controls.Add(label3);
            pnlBody.Controls.Add(label1);
            pnlBody.Controls.Add(txtPassword);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 41);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(16, 24, 16, 16);
            pnlBody.Size = new Size(484, 229);
            pnlBody.TabIndex = 3;
            // 
            // label4
            // 
            label4.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 168);
            label4.Name = "label4";
            label4.Size = new Size(460, 41);
            label4.TabIndex = 3;
            label4.Text = "They are required to change their password after the initial login for security reasons.";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 112);
            label3.Name = "label3";
            label3.Size = new Size(460, 56);
            label3.TabIndex = 2;
            label3.Text = "Please make a note of this password, as it will be used for the user's account access. We recommend presenting or securely sending this password to the user.";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 72);
            label1.Name = "label1";
            label1.Size = new Size(460, 40);
            label1.TabIndex = 1;
            label1.Text = "The new password has been generated and saved to the user's account.";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Consolas", 16F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(42, 24);
            txtPassword.Margin = new Padding(0, 0, 0, 16);
            txtPassword.Name = "txtPassword";
            txtPassword.ReadOnly = true;
            txtPassword.Size = new Size(400, 32);
            txtPassword.TabIndex = 0;
            txtPassword.TextAlign = HorizontalAlignment.Center;
            // 
            // ViewGeneratedPassword
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(484, 330);
            Controls.Add(pnlBody);
            Controls.Add(pnlHeader);
            Controls.Add(pnlFooter);
            Controls.Add(pnlLine1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ViewGeneratedPassword";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reset Password Success";
            Load += ViewGeneratedPassword_Load;
            pnlFooter.ResumeLayout(false);
            pnlFooter.PerformLayout();
            flowFooterActions.ResumeLayout(false);
            flowFooterActions.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLine1;
        private Panel pnlFooter;
        private Panel pnlHeader;
        private Panel pnlBody;
        private Label label2;
        private TextBox txtPassword;
        private FlowLayoutPanel flowFooterActions;
        private Button btnDone;
        private Button btnCopyPassword;
        private Label label3;
        private Label label1;
        private Label label4;
        private Label lblNotifCopied;
    }
}