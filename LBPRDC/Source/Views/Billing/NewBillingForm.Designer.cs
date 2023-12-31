﻿namespace LBPRDC.Source.Views.Billing
{
    partial class NewBillingForm
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
            btnPreviewDateRange = new Button();
            pnlBody = new Panel();
            pnlLine2 = new Panel();
            label5 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            pnlGroup1 = new Panel();
            label3 = new Label();
            txtBillingName = new TextBox();
            label4 = new Label();
            pnlGroup2 = new Panel();
            cmbYear = new ComboBox();
            label1 = new Label();
            cmbMonth = new ComboBox();
            label2 = new Label();
            groupBox2 = new GroupBox();
            radSecond = new RadioButton();
            radFirst = new RadioButton();
            groupBox1 = new GroupBox();
            txtToDatePreview = new TextBox();
            txtFromDatePreview = new TextBox();
            label7 = new Label();
            label8 = new Label();
            pnlGroup5 = new Panel();
            txtDescription = new TextBox();
            label9 = new Label();
            pnlFooter.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            pnlBody.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            pnlGroup1.SuspendLayout();
            pnlGroup2.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            pnlGroup5.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLine1
            // 
            pnlLine1.BorderStyle = BorderStyle.FixedSingle;
            pnlLine1.Dock = DockStyle.Top;
            pnlLine1.Location = new Point(0, 0);
            pnlLine1.Name = "pnlLine1";
            pnlLine1.Size = new Size(434, 1);
            pnlLine1.TabIndex = 0;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = SystemColors.Control;
            pnlFooter.Controls.Add(flowLayoutPanel2);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 445);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(434, 46);
            pnlFooter.TabIndex = 2;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(btnConfirm);
            flowLayoutPanel2.Controls.Add(btnCancel);
            flowLayoutPanel2.Dock = DockStyle.Right;
            flowLayoutPanel2.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel2.Location = new Point(243, 0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Padding = new Padding(16, 9, 0, 0);
            flowLayoutPanel2.Size = new Size(191, 46);
            flowLayoutPanel2.TabIndex = 5;
            // 
            // btnConfirm
            // 
            btnConfirm.AutoSize = true;
            btnConfirm.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnConfirm.Location = new Point(100, 9);
            btnConfirm.Margin = new Padding(8, 0, 0, 0);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(75, 28);
            btnConfirm.TabIndex = 8;
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
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnPreviewDateRange
            // 
            btnPreviewDateRange.AutoSize = true;
            btnPreviewDateRange.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnPreviewDateRange.Location = new Point(16, 350);
            btnPreviewDateRange.Margin = new Padding(0);
            btnPreviewDateRange.Name = "btnPreviewDateRange";
            btnPreviewDateRange.Size = new Size(71, 28);
            btnPreviewDateRange.TabIndex = 23;
            btnPreviewDateRange.Text = "Preview";
            btnPreviewDateRange.UseVisualStyleBackColor = true;
            btnPreviewDateRange.Click += btnPreviewDateRange_Click;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(pnlLine2);
            pnlBody.Controls.Add(label5);
            pnlBody.Controls.Add(flowLayoutPanel1);
            pnlBody.Controls.Add(btnPreviewDateRange);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 1);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(16);
            pnlBody.Size = new Size(434, 444);
            pnlBody.TabIndex = 3;
            // 
            // pnlLine2
            // 
            pnlLine2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLine2.BorderStyle = BorderStyle.FixedSingle;
            pnlLine2.Location = new Point(16, 43);
            pnlLine2.Margin = new Padding(0, 0, 0, 16);
            pnlLine2.Name = "pnlLine2";
            pnlLine2.Size = new Size(402, 1);
            pnlLine2.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(16, 16);
            label5.Margin = new Padding(0, 0, 0, 8);
            label5.Name = "label5";
            label5.Size = new Size(95, 19);
            label5.TabIndex = 1;
            label5.Text = "New Billing";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(pnlGroup1);
            flowLayoutPanel1.Controls.Add(pnlGroup2);
            flowLayoutPanel1.Controls.Add(groupBox2);
            flowLayoutPanel1.Controls.Add(groupBox1);
            flowLayoutPanel1.Controls.Add(pnlGroup5);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(16, 60);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(403, 360);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // pnlGroup1
            // 
            pnlGroup1.AutoSize = true;
            pnlGroup1.Controls.Add(label3);
            pnlGroup1.Controls.Add(txtBillingName);
            pnlGroup1.Controls.Add(label4);
            pnlGroup1.Location = new Point(0, 0);
            pnlGroup1.Margin = new Padding(0, 0, 0, 16);
            pnlGroup1.Name = "pnlGroup1";
            pnlGroup1.Size = new Size(402, 46);
            pnlGroup1.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(0, 0);
            label3.Margin = new Padding(0, 0, 0, 4);
            label3.Name = "label3";
            label3.Size = new Size(84, 16);
            label3.TabIndex = 20;
            label3.Text = "Billing Name";
            // 
            // txtBillingName
            // 
            txtBillingName.AccessibleName = "Billing Name";
            txtBillingName.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtBillingName.Location = new Point(0, 20);
            txtBillingName.Margin = new Padding(0);
            txtBillingName.MaxLength = 100;
            txtBillingName.Name = "txtBillingName";
            txtBillingName.Size = new Size(402, 26);
            txtBillingName.TabIndex = 1;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(80, 0);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Size = new Size(12, 16);
            label4.TabIndex = 21;
            label4.Text = "*";
            // 
            // pnlGroup2
            // 
            pnlGroup2.AutoSize = true;
            pnlGroup2.Controls.Add(cmbYear);
            pnlGroup2.Controls.Add(label1);
            pnlGroup2.Controls.Add(cmbMonth);
            pnlGroup2.Controls.Add(label2);
            pnlGroup2.Location = new Point(0, 62);
            pnlGroup2.Margin = new Padding(0, 0, 0, 16);
            pnlGroup2.Name = "pnlGroup2";
            pnlGroup2.Size = new Size(402, 46);
            pnlGroup2.TabIndex = 15;
            // 
            // cmbYear
            // 
            cmbYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbYear.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbYear.FormattingEnabled = true;
            cmbYear.Location = new Point(303, 20);
            cmbYear.Margin = new Padding(0);
            cmbYear.Name = "cmbYear";
            cmbYear.Size = new Size(99, 26);
            cmbYear.TabIndex = 3;
            cmbYear.SelectedIndexChanged += UpdateDateRange_ControlChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(303, 0);
            label1.Margin = new Padding(0, 0, 0, 4);
            label1.Name = "label1";
            label1.Size = new Size(36, 16);
            label1.TabIndex = 16;
            label1.Text = "Year";
            // 
            // cmbMonth
            // 
            cmbMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMonth.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbMonth.FormattingEnabled = true;
            cmbMonth.Location = new Point(0, 20);
            cmbMonth.Margin = new Padding(0, 0, 8, 0);
            cmbMonth.Name = "cmbMonth";
            cmbMonth.Size = new Size(295, 26);
            cmbMonth.TabIndex = 2;
            cmbMonth.SelectedIndexChanged += UpdateDateRange_ControlChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(0, 0);
            label2.Margin = new Padding(0, 0, 0, 4);
            label2.Name = "label2";
            label2.Size = new Size(46, 16);
            label2.TabIndex = 14;
            label2.Text = "Month";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(radSecond);
            groupBox2.Controls.Add(radFirst);
            groupBox2.Location = new Point(0, 124);
            groupBox2.Margin = new Padding(0, 0, 0, 16);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(16, 8, 8, 8);
            groupBox2.Size = new Size(402, 53);
            groupBox2.TabIndex = 21;
            groupBox2.TabStop = false;
            groupBox2.Text = "Quarter Period";
            // 
            // radSecond
            // 
            radSecond.AutoSize = true;
            radSecond.Location = new Point(138, 24);
            radSecond.Margin = new Padding(0, 0, 16, 0);
            radSecond.Name = "radSecond";
            radSecond.Size = new Size(126, 20);
            radSecond.TabIndex = 5;
            radSecond.TabStop = true;
            radSecond.Text = "Second Quarter";
            radSecond.UseVisualStyleBackColor = true;
            radSecond.CheckedChanged += UpdateDateRange_ControlChanged;
            // 
            // radFirst
            // 
            radFirst.AutoSize = true;
            radFirst.Checked = true;
            radFirst.Location = new Point(16, 24);
            radFirst.Margin = new Padding(0, 0, 16, 0);
            radFirst.Name = "radFirst";
            radFirst.Size = new Size(106, 20);
            radFirst.TabIndex = 4;
            radFirst.TabStop = true;
            radFirst.Text = "First Quarter";
            radFirst.UseVisualStyleBackColor = true;
            radFirst.CheckedChanged += UpdateDateRange_ControlChanged;
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.Controls.Add(txtToDatePreview);
            groupBox1.Controls.Add(txtFromDatePreview);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label8);
            groupBox1.Location = new Point(0, 193);
            groupBox1.Margin = new Padding(0, 0, 0, 16);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(16, 8, 8, 0);
            groupBox1.Size = new Size(402, 97);
            groupBox1.TabIndex = 20;
            groupBox1.TabStop = false;
            groupBox1.Text = "Selected Date Preview";
            // 
            // txtToDatePreview
            // 
            txtToDatePreview.AccessibleName = "Code";
            txtToDatePreview.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtToDatePreview.Location = new Point(68, 55);
            txtToDatePreview.Margin = new Padding(0);
            txtToDatePreview.MaxLength = 100;
            txtToDatePreview.Name = "txtToDatePreview";
            txtToDatePreview.ReadOnly = true;
            txtToDatePreview.Size = new Size(326, 26);
            txtToDatePreview.TabIndex = 24;
            txtToDatePreview.TabStop = false;
            // 
            // txtFromDatePreview
            // 
            txtFromDatePreview.AccessibleName = "Code";
            txtFromDatePreview.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtFromDatePreview.Location = new Point(68, 24);
            txtFromDatePreview.Margin = new Padding(0, 0, 0, 8);
            txtFromDatePreview.MaxLength = 100;
            txtFromDatePreview.Name = "txtFromDatePreview";
            txtFromDatePreview.ReadOnly = true;
            txtFromDatePreview.Size = new Size(326, 26);
            txtFromDatePreview.TabIndex = 23;
            txtFromDatePreview.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(16, 29);
            label7.Margin = new Padding(0, 0, 8, 0);
            label7.Name = "label7";
            label7.Size = new Size(44, 16);
            label7.TabIndex = 21;
            label7.Text = "From:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(34, 60);
            label8.Margin = new Padding(0, 0, 8, 0);
            label8.Name = "label8";
            label8.Size = new Size(26, 16);
            label8.TabIndex = 22;
            label8.Text = "To:";
            // 
            // pnlGroup5
            // 
            pnlGroup5.AutoSize = true;
            pnlGroup5.Controls.Add(txtDescription);
            pnlGroup5.Controls.Add(label9);
            pnlGroup5.Location = new Point(0, 306);
            pnlGroup5.Margin = new Padding(0, 0, 0, 8);
            pnlGroup5.Name = "pnlGroup5";
            pnlGroup5.Size = new Size(402, 46);
            pnlGroup5.TabIndex = 19;
            // 
            // txtDescription
            // 
            txtDescription.AccessibleName = "Code";
            txtDescription.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtDescription.Location = new Point(0, 20);
            txtDescription.Margin = new Padding(0);
            txtDescription.MaxLength = 100;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(402, 26);
            txtDescription.TabIndex = 6;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(0, 0);
            label9.Margin = new Padding(0, 0, 0, 4);
            label9.Name = "label9";
            label9.Size = new Size(78, 16);
            label9.TabIndex = 20;
            label9.Text = "Description";
            // 
            // NewBillingForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(434, 491);
            Controls.Add(pnlBody);
            Controls.Add(pnlFooter);
            Controls.Add(pnlLine1);
            Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NewBillingForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Load += NewBillingForm_Load;
            pnlFooter.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            pnlGroup1.ResumeLayout(false);
            pnlGroup1.PerformLayout();
            pnlGroup2.ResumeLayout(false);
            pnlGroup2.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            pnlGroup5.ResumeLayout(false);
            pnlGroup5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLine1;
        private Panel pnlFooter;
        private Panel pnlBody;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lblCode;
        private TextBox txtBillingName;
        private Panel pnlGroup1;
        private Label label3;
        private Label label4;
        private Panel pnlGroup2;
        private ComboBox cmbMonth;
        private Label label2;
        private Label label1;
        private ComboBox cmbYear;
        private RadioButton radFirst;
        private RadioButton radSecond;
        private Label label8;
        private Label label7;
        private TextBox txtToDatePreview;
        private TextBox txtFromDatePreview;
        private Panel pnlGroup5;
        private TextBox txtDescription;
        private Label label9;
        private Button btnPreviewDateRange;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button btnConfirm;
        private Button btnCancel;
        private Label label5;
        private Panel pnlLine2;
    }
}