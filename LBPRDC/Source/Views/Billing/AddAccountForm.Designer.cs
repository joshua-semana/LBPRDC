namespace LBPRDC.Source.Views.Billing
{
    partial class AddAccountForm
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
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnConfirm = new Button();
            btnCancel = new Button();
            pnlBody = new Panel();
            label5 = new Label();
            label6 = new Label();
            txtBillingValue = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtClassification = new TextBox();
            label8 = new Label();
            label4 = new Label();
            txtAccountNumber = new TextBox();
            pnlLine2 = new Panel();
            panel1 = new Panel();
            label1 = new Label();
            pnlFooter.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            pnlBody.SuspendLayout();
            pnlLine2.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLine1
            // 
            pnlLine1.BorderStyle = BorderStyle.FixedSingle;
            pnlLine1.Dock = DockStyle.Top;
            pnlLine1.Location = new Point(0, 0);
            pnlLine1.Name = "pnlLine1";
            pnlLine1.Size = new Size(349, 1);
            pnlLine1.TabIndex = 0;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = SystemColors.Control;
            pnlFooter.Controls.Add(flowLayoutPanel2);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 248);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(349, 46);
            pnlFooter.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(btnConfirm);
            flowLayoutPanel2.Controls.Add(btnCancel);
            flowLayoutPanel2.Dock = DockStyle.Right;
            flowLayoutPanel2.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel2.Location = new Point(158, 0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Padding = new Padding(16, 9, 0, 0);
            flowLayoutPanel2.Size = new Size(191, 46);
            flowLayoutPanel2.TabIndex = 11;
            // 
            // btnConfirm
            // 
            btnConfirm.AutoSize = true;
            btnConfirm.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnConfirm.Location = new Point(100, 9);
            btnConfirm.Margin = new Padding(8, 0, 0, 0);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(75, 28);
            btnConfirm.TabIndex = 10;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.Location = new Point(17, 9);
            btnCancel.Margin = new Padding(8, 0, 0, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 28);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(label5);
            pnlBody.Controls.Add(label6);
            pnlBody.Controls.Add(txtBillingValue);
            pnlBody.Controls.Add(label2);
            pnlBody.Controls.Add(label3);
            pnlBody.Controls.Add(txtClassification);
            pnlBody.Controls.Add(label8);
            pnlBody.Controls.Add(label4);
            pnlBody.Controls.Add(txtAccountNumber);
            pnlBody.Controls.Add(pnlLine2);
            pnlBody.Controls.Add(label1);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 1);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(16);
            pnlBody.Size = new Size(349, 247);
            pnlBody.TabIndex = 2;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.Red;
            label5.Location = new Point(199, 184);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Size = new Size(12, 16);
            label5.TabIndex = 34;
            label5.Text = "*";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(16, 184);
            label6.Margin = new Padding(0, 0, 0, 4);
            label6.Name = "label6";
            label6.Size = new Size(186, 16);
            label6.TabIndex = 33;
            label6.Text = "Billing Value (Gross Amount)";
            // 
            // txtBillingValue
            // 
            txtBillingValue.AccessibleName = "Billing Value (Gross Amount)";
            txtBillingValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBillingValue.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtBillingValue.Location = new Point(16, 204);
            txtBillingValue.Margin = new Padding(0, 0, 0, 16);
            txtBillingValue.Name = "txtBillingValue";
            txtBillingValue.Size = new Size(317, 26);
            txtBillingValue.TabIndex = 32;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(103, 122);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(12, 16);
            label2.TabIndex = 31;
            label2.Text = "*";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(16, 122);
            label3.Margin = new Padding(0, 0, 0, 4);
            label3.Name = "label3";
            label3.Size = new Size(90, 16);
            label3.TabIndex = 30;
            label3.Text = "Classification";
            // 
            // txtClassification
            // 
            txtClassification.AccessibleName = "Classification";
            txtClassification.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtClassification.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtClassification.Location = new Point(16, 142);
            txtClassification.Margin = new Padding(0, 0, 0, 16);
            txtClassification.Name = "txtClassification";
            txtClassification.Size = new Size(317, 26);
            txtClassification.TabIndex = 29;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.Red;
            label8.Location = new Point(124, 60);
            label8.Margin = new Padding(0);
            label8.Name = "label8";
            label8.Size = new Size(12, 16);
            label8.TabIndex = 28;
            label8.Text = "*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(16, 60);
            label4.Margin = new Padding(0, 0, 0, 4);
            label4.Name = "label4";
            label4.Size = new Size(111, 16);
            label4.TabIndex = 27;
            label4.Text = "Account Number";
            // 
            // txtAccountNumber
            // 
            txtAccountNumber.AccessibleName = "Account Number";
            txtAccountNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAccountNumber.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtAccountNumber.Location = new Point(16, 80);
            txtAccountNumber.Margin = new Padding(0, 0, 0, 16);
            txtAccountNumber.Name = "txtAccountNumber";
            txtAccountNumber.Size = new Size(317, 26);
            txtAccountNumber.TabIndex = 26;
            // 
            // pnlLine2
            // 
            pnlLine2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLine2.BorderStyle = BorderStyle.FixedSingle;
            pnlLine2.Controls.Add(panel1);
            pnlLine2.Location = new Point(16, 43);
            pnlLine2.Margin = new Padding(0, 0, 0, 16);
            pnlLine2.Name = "pnlLine2";
            pnlLine2.Size = new Size(317, 1);
            pnlLine2.TabIndex = 11;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(-1, 0);
            panel1.Margin = new Padding(0, 0, 0, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(818, 1);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(13, 16);
            label1.Margin = new Padding(0, 0, 0, 8);
            label1.Name = "label1";
            label1.Size = new Size(171, 19);
            label1.TabIndex = 10;
            label1.Text = "Add Custom Account";
            // 
            // AddAccountForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(349, 294);
            ControlBox = false;
            Controls.Add(pnlBody);
            Controls.Add(pnlFooter);
            Controls.Add(pnlLine1);
            Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "AddAccountForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Billing Name";
            pnlFooter.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            pnlLine2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLine1;
        private Panel pnlFooter;
        private Panel pnlBody;
        private Panel pnlLine2;
        private Panel panel1;
        private Label label1;
        private Label label8;
        private Label label4;
        private TextBox txtAccountNumber;
        private Label label5;
        private Label label6;
        private TextBox txtBillingValue;
        private Label label2;
        private Label label3;
        private TextBox txtClassification;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button btnConfirm;
        private Button btnCancel;
    }
}