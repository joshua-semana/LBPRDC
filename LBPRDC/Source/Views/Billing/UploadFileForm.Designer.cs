namespace LBPRDC.Source.Views.Billing
{
    partial class UploadFileForm
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnConfirm = new Button();
            btnCancel = new Button();
            pnlBody = new Panel();
            lblVerificationResult = new Label();
            btnVerify = new Button();
            label3 = new Label();
            cmbWorkSheet = new ComboBox();
            btnSelect = new Button();
            label2 = new Label();
            txtFilePath = new TextBox();
            pnlLine2 = new Panel();
            label1 = new Label();
            pnlFooter.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
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
            pnlFooter.Controls.Add(flowLayoutPanel1);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 210);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(484, 46);
            pnlFooter.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnConfirm);
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Dock = DockStyle.Right;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(295, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(16, 9, 0, 0);
            flowLayoutPanel1.Size = new Size(189, 46);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // btnConfirm
            // 
            btnConfirm.AutoSize = true;
            btnConfirm.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnConfirm.Location = new Point(98, 9);
            btnConfirm.Margin = new Padding(8, 0, 0, 0);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(75, 28);
            btnConfirm.TabIndex = 8;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.Location = new Point(15, 9);
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
            pnlBody.Controls.Add(lblVerificationResult);
            pnlBody.Controls.Add(btnVerify);
            pnlBody.Controls.Add(label3);
            pnlBody.Controls.Add(cmbWorkSheet);
            pnlBody.Controls.Add(btnSelect);
            pnlBody.Controls.Add(label2);
            pnlBody.Controls.Add(txtFilePath);
            pnlBody.Controls.Add(pnlLine2);
            pnlBody.Controls.Add(label1);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 1);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(16);
            pnlBody.Size = new Size(484, 209);
            pnlBody.TabIndex = 2;
            // 
            // lblVerificationResult
            // 
            lblVerificationResult.AutoSize = true;
            lblVerificationResult.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblVerificationResult.ForeColor = SystemColors.GrayText;
            lblVerificationResult.Location = new Point(16, 176);
            lblVerificationResult.Margin = new Padding(0, 0, 0, 4);
            lblVerificationResult.Name = "lblVerificationResult";
            lblVerificationResult.Size = new Size(287, 16);
            lblVerificationResult.TabIndex = 15;
            lblVerificationResult.Text = "Please select a worksheet and verify the file.";
            // 
            // btnVerify
            // 
            btnVerify.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnVerify.AutoSize = true;
            btnVerify.Enabled = false;
            btnVerify.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnVerify.Location = new Point(392, 145);
            btnVerify.Margin = new Padding(0, 0, 8, 0);
            btnVerify.Name = "btnVerify";
            btnVerify.Size = new Size(75, 28);
            btnVerify.TabIndex = 14;
            btnVerify.Text = "Verify";
            btnVerify.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(16, 126);
            label3.Margin = new Padding(0, 0, 0, 4);
            label3.Name = "label3";
            label3.Size = new Size(75, 16);
            label3.TabIndex = 13;
            label3.Text = "Worksheet";
            // 
            // cmbWorkSheet
            // 
            cmbWorkSheet.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbWorkSheet.Enabled = false;
            cmbWorkSheet.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbWorkSheet.FormattingEnabled = true;
            cmbWorkSheet.Location = new Point(16, 146);
            cmbWorkSheet.Margin = new Padding(0, 0, 8, 4);
            cmbWorkSheet.Name = "cmbWorkSheet";
            cmbWorkSheet.Size = new Size(368, 26);
            cmbWorkSheet.TabIndex = 12;
            // 
            // btnSelect
            // 
            btnSelect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSelect.AutoSize = true;
            btnSelect.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSelect.Location = new Point(392, 79);
            btnSelect.Margin = new Padding(4, 0, 8, 0);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(75, 28);
            btnSelect.TabIndex = 11;
            btnSelect.Text = "Select";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(16, 60);
            label2.Margin = new Padding(0, 0, 0, 4);
            label2.Name = "label2";
            label2.Size = new Size(30, 16);
            label2.TabIndex = 3;
            label2.Text = "File";
            // 
            // txtFilePath
            // 
            txtFilePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFilePath.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtFilePath.Location = new Point(16, 80);
            txtFilePath.Margin = new Padding(0, 0, 4, 16);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.ReadOnly = true;
            txtFilePath.Size = new Size(368, 26);
            txtFilePath.TabIndex = 2;
            // 
            // pnlLine2
            // 
            pnlLine2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLine2.BorderStyle = BorderStyle.FixedSingle;
            pnlLine2.Location = new Point(16, 43);
            pnlLine2.Margin = new Padding(0, 0, 0, 16);
            pnlLine2.Name = "pnlLine2";
            pnlLine2.Size = new Size(452, 1);
            pnlLine2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(16, 16);
            label1.Margin = new Padding(0, 0, 0, 8);
            label1.Name = "label1";
            label1.Size = new Size(95, 19);
            label1.TabIndex = 0;
            label1.Text = "Upload File";
            // 
            // UploadFileForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(484, 256);
            Controls.Add(pnlBody);
            Controls.Add(pnlFooter);
            Controls.Add(pnlLine1);
            Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UploadFileForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            pnlFooter.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLine1;
        private Panel pnlFooter;
        private Panel pnlBody;
        private Label label2;
        private TextBox txtFilePath;
        private Panel pnlLine2;
        private Label label1;
        private Button btnSelect;
        private Label label3;
        private ComboBox cmbWorkSheet;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnConfirm;
        private Button btnCancel;
        private Button btnVerify;
        private Label lblVerificationResult;
    }
}