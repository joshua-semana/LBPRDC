namespace LBPRDC.Source.Views.Billing
{
    partial class CollectEmployeeBillingForm
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
            label7 = new Label();
            label5 = new Label();
            txtGrossBillingValue = new TextBox();
            label2 = new Label();
            txtCollectedAmount = new TextBox();
            pnlLine2 = new Panel();
            lblTitle = new Label();
            pnlFooter.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            pnlBody.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLine1
            // 
            pnlLine1.BorderStyle = BorderStyle.FixedSingle;
            pnlLine1.Dock = DockStyle.Top;
            pnlLine1.Location = new Point(0, 0);
            pnlLine1.Name = "pnlLine1";
            pnlLine1.Size = new Size(345, 1);
            pnlLine1.TabIndex = 0;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = SystemColors.Control;
            pnlFooter.Controls.Add(flowLayoutPanel2);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 187);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(345, 46);
            pnlFooter.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(btnConfirm);
            flowLayoutPanel2.Controls.Add(btnCancel);
            flowLayoutPanel2.Dock = DockStyle.Right;
            flowLayoutPanel2.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel2.Location = new Point(154, 0);
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
            pnlBody.Controls.Add(label7);
            pnlBody.Controls.Add(label5);
            pnlBody.Controls.Add(txtGrossBillingValue);
            pnlBody.Controls.Add(label2);
            pnlBody.Controls.Add(txtCollectedAmount);
            pnlBody.Controls.Add(pnlLine2);
            pnlBody.Controls.Add(lblTitle);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 1);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(16);
            pnlBody.Size = new Size(345, 186);
            pnlBody.TabIndex = 2;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.Red;
            label7.Location = new Point(130, 122);
            label7.Margin = new Padding(0);
            label7.Name = "label7";
            label7.Size = new Size(12, 16);
            label7.TabIndex = 31;
            label7.Text = "*";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(16, 60);
            label5.Margin = new Padding(0, 0, 0, 4);
            label5.Name = "label5";
            label5.Size = new Size(125, 16);
            label5.TabIndex = 30;
            label5.Text = "Gross Billing Value";
            // 
            // txtGrossBillingValue
            // 
            txtGrossBillingValue.AccessibleName = "Gross Billing Value";
            txtGrossBillingValue.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtGrossBillingValue.Location = new Point(16, 80);
            txtGrossBillingValue.Margin = new Padding(0, 0, 0, 16);
            txtGrossBillingValue.Name = "txtGrossBillingValue";
            txtGrossBillingValue.ReadOnly = true;
            txtGrossBillingValue.Size = new Size(317, 26);
            txtGrossBillingValue.TabIndex = 29;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(16, 122);
            label2.Margin = new Padding(0, 0, 0, 4);
            label2.Name = "label2";
            label2.Size = new Size(117, 16);
            label2.TabIndex = 26;
            label2.Text = "Collected Amount";
            // 
            // txtCollectedAmount
            // 
            txtCollectedAmount.AccessibleName = "Collected Amount";
            txtCollectedAmount.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCollectedAmount.Location = new Point(16, 142);
            txtCollectedAmount.Margin = new Padding(0, 0, 0, 16);
            txtCollectedAmount.Name = "txtCollectedAmount";
            txtCollectedAmount.Size = new Size(317, 26);
            txtCollectedAmount.TabIndex = 25;
            txtCollectedAmount.KeyPress += MoneyInput_KeyPress;
            // 
            // pnlLine2
            // 
            pnlLine2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLine2.BorderStyle = BorderStyle.FixedSingle;
            pnlLine2.Location = new Point(16, 43);
            pnlLine2.Margin = new Padding(0, 0, 0, 16);
            pnlLine2.Name = "pnlLine2";
            pnlLine2.Size = new Size(313, 1);
            pnlLine2.TabIndex = 5;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(16, 16);
            lblTitle.Margin = new Padding(0, 0, 0, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(114, 19);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "Collect Billing";
            // 
            // CollectEmployeeBillingForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(345, 233);
            ControlBox = false;
            Controls.Add(pnlBody);
            Controls.Add(pnlFooter);
            Controls.Add(pnlLine1);
            Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "CollectEmployeeBillingForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Collect Billing";
            Load += CollectEmployeeBillingForm_Load;
            pnlFooter.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLine1;
        private Panel pnlFooter;
        private Panel pnlBody;
        private Label lblTitle;
        private Panel pnlLine2;
        private Label label7;
        private Label label5;
        private TextBox txtGrossBillingValue;
        private DateTimePicker dtpCollectionDate;
        private Label label3;
        private Label label2;
        private TextBox txtCollectedAmount;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button btnConfirm;
        private Button btnCancel;
    }
}