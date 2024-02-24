namespace LBPRDC.Source.Views.Billing
{
    partial class CollectAccountForm
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
            label8 = new Label();
            label5 = new Label();
            txtBillingValue = new TextBox();
            dtpCollectionDate = new DateTimePicker();
            label4 = new Label();
            txtReceiptNumber = new TextBox();
            label3 = new Label();
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
            pnlLine1.Size = new Size(373, 1);
            pnlLine1.TabIndex = 0;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = SystemColors.Control;
            pnlFooter.Controls.Add(flowLayoutPanel2);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 251);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(373, 46);
            pnlFooter.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(btnConfirm);
            flowLayoutPanel2.Controls.Add(btnCancel);
            flowLayoutPanel2.Dock = DockStyle.Right;
            flowLayoutPanel2.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel2.Location = new Point(182, 0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Padding = new Padding(16, 9, 0, 0);
            flowLayoutPanel2.Size = new Size(191, 46);
            flowLayoutPanel2.TabIndex = 10;
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
            pnlBody.Controls.Add(label8);
            pnlBody.Controls.Add(label5);
            pnlBody.Controls.Add(txtBillingValue);
            pnlBody.Controls.Add(dtpCollectionDate);
            pnlBody.Controls.Add(label4);
            pnlBody.Controls.Add(txtReceiptNumber);
            pnlBody.Controls.Add(label3);
            pnlBody.Controls.Add(pnlLine2);
            pnlBody.Controls.Add(label1);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 1);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(16);
            pnlBody.Size = new Size(373, 250);
            pnlBody.TabIndex = 2;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.Red;
            label8.Location = new Point(167, 122);
            label8.Margin = new Padding(0);
            label8.Name = "label8";
            label8.Size = new Size(12, 16);
            label8.TabIndex = 25;
            label8.Text = "*";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(16, 60);
            label5.Margin = new Padding(0, 0, 0, 4);
            label5.Name = "label5";
            label5.Size = new Size(83, 16);
            label5.TabIndex = 17;
            label5.Text = "Billing Value";
            // 
            // txtBillingValue
            // 
            txtBillingValue.AccessibleName = "Billing Value";
            txtBillingValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBillingValue.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtBillingValue.Location = new Point(16, 80);
            txtBillingValue.Margin = new Padding(0, 0, 0, 16);
            txtBillingValue.Name = "txtBillingValue";
            txtBillingValue.ReadOnly = true;
            txtBillingValue.Size = new Size(341, 26);
            txtBillingValue.TabIndex = 16;
            // 
            // dtpCollectionDate
            // 
            dtpCollectionDate.AccessibleName = "Collection Date";
            dtpCollectionDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpCollectionDate.CalendarFont = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpCollectionDate.Checked = false;
            dtpCollectionDate.CustomFormat = "MM-dd-yyyy";
            dtpCollectionDate.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpCollectionDate.Format = DateTimePickerFormat.Custom;
            dtpCollectionDate.Location = new Point(16, 204);
            dtpCollectionDate.Margin = new Padding(0, 0, 0, 16);
            dtpCollectionDate.Name = "dtpCollectionDate";
            dtpCollectionDate.Size = new Size(341, 26);
            dtpCollectionDate.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(16, 122);
            label4.Margin = new Padding(0, 0, 0, 4);
            label4.Name = "label4";
            label4.Size = new Size(155, 16);
            label4.TabIndex = 14;
            label4.Text = "Official Receipt Number";
            // 
            // txtReceiptNumber
            // 
            txtReceiptNumber.AccessibleName = "Official Receipt Number";
            txtReceiptNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtReceiptNumber.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtReceiptNumber.Location = new Point(16, 142);
            txtReceiptNumber.Margin = new Padding(0, 0, 0, 16);
            txtReceiptNumber.Name = "txtReceiptNumber";
            txtReceiptNumber.Size = new Size(341, 26);
            txtReceiptNumber.TabIndex = 13;
            txtReceiptNumber.KeyPress += ValidateInputIfNumber1_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(16, 184);
            label3.Margin = new Padding(0, 0, 0, 4);
            label3.Name = "label3";
            label3.Size = new Size(119, 16);
            label3.TabIndex = 12;
            label3.Text = "Date of Collection";
            // 
            // pnlLine2
            // 
            pnlLine2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLine2.BorderStyle = BorderStyle.FixedSingle;
            pnlLine2.Controls.Add(panel1);
            pnlLine2.Location = new Point(16, 43);
            pnlLine2.Margin = new Padding(0, 0, 0, 16);
            pnlLine2.Name = "pnlLine2";
            pnlLine2.Size = new Size(341, 1);
            pnlLine2.TabIndex = 9;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(-1, 0);
            panel1.Margin = new Padding(0, 0, 0, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(703, 1);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(16, 16);
            label1.Margin = new Padding(0, 0, 0, 8);
            label1.Name = "label1";
            label1.Size = new Size(264, 19);
            label1.TabIndex = 8;
            label1.Text = "Update Statement of Account Info";
            // 
            // CollectAccountForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(373, 297);
            ControlBox = false;
            Controls.Add(pnlBody);
            Controls.Add(pnlFooter);
            Controls.Add(pnlLine1);
            Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "CollectAccountForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Account Collection";
            Load += CollectAccountForm_Load;
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
        private FlowLayoutPanel flowLayoutPanel2;
        private Button btnConfirm;
        private Button btnCancel;
        private Panel pnlLine2;
        private Panel panel1;
        private Label label1;
        private Label label3;
        private Label label4;
        private TextBox txtReceiptNumber;
        private DateTimePicker dtpCollectionDate;
        private Label label5;
        private TextBox txtBillingValue;
        private Label label8;
    }
}