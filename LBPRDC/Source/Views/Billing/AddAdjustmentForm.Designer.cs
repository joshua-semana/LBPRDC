namespace LBPRDC.Source.Views.Billing
{
    partial class AddAdjustmentForm
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
            btnAdd = new Button();
            btnCancel = new Button();
            pnlBody = new Panel();
            chkSIL = new CheckBox();
            grpDetails = new GroupBox();
            lblDatePreview = new Label();
            btnPrevMonth = new Button();
            btnNextMonth = new Button();
            lblMonthYear = new Label();
            pnlCalendar = new Panel();
            label7 = new Label();
            txtRemarks = new TextBox();
            btnReset = new Button();
            label4 = new Label();
            txtInputValueUnits = new TextBox();
            label5 = new Label();
            txtInputValue = new TextBox();
            label3 = new Label();
            txtInitialValueUnits = new TextBox();
            cmbOperation = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            txtInitialValue = new TextBox();
            cmbCategory = new ComboBox();
            label29 = new Label();
            pnlLine2 = new Panel();
            lblTitle = new Label();
            pnlFooter.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            pnlBody.SuspendLayout();
            grpDetails.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLine1
            // 
            pnlLine1.BorderStyle = BorderStyle.FixedSingle;
            pnlLine1.Dock = DockStyle.Top;
            pnlLine1.Location = new Point(0, 0);
            pnlLine1.Name = "pnlLine1";
            pnlLine1.Size = new Size(521, 1);
            pnlLine1.TabIndex = 0;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = SystemColors.Control;
            pnlFooter.Controls.Add(flowLayoutPanel1);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 741);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(521, 46);
            pnlFooter.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnAdd);
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Dock = DockStyle.Right;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(328, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(16, 9, 0, 0);
            flowLayoutPanel1.Size = new Size(193, 46);
            flowLayoutPanel1.TabIndex = 7;
            // 
            // btnAdd
            // 
            btnAdd.AutoSize = true;
            btnAdd.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnAdd.Location = new Point(102, 9);
            btnAdd.Margin = new Padding(8, 0, 0, 0);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 28);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.Location = new Point(19, 9);
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
            pnlBody.Controls.Add(chkSIL);
            pnlBody.Controls.Add(grpDetails);
            pnlBody.Controls.Add(cmbCategory);
            pnlBody.Controls.Add(label29);
            pnlBody.Controls.Add(pnlLine2);
            pnlBody.Controls.Add(lblTitle);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 1);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(16);
            pnlBody.Size = new Size(521, 740);
            pnlBody.TabIndex = 2;
            // 
            // chkSIL
            // 
            chkSIL.AutoSize = true;
            chkSIL.Enabled = false;
            chkSIL.Location = new Point(16, 705);
            chkSIL.Name = "chkSIL";
            chkSIL.Size = new Size(291, 20);
            chkSIL.TabIndex = 28;
            chkSIL.Text = "Check this box if this will be marked as SIL";
            chkSIL.UseVisualStyleBackColor = true;
            // 
            // grpDetails
            // 
            grpDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpDetails.Controls.Add(lblDatePreview);
            grpDetails.Controls.Add(btnPrevMonth);
            grpDetails.Controls.Add(btnNextMonth);
            grpDetails.Controls.Add(lblMonthYear);
            grpDetails.Controls.Add(pnlCalendar);
            grpDetails.Controls.Add(label7);
            grpDetails.Controls.Add(txtRemarks);
            grpDetails.Controls.Add(btnReset);
            grpDetails.Controls.Add(label4);
            grpDetails.Controls.Add(txtInputValueUnits);
            grpDetails.Controls.Add(label5);
            grpDetails.Controls.Add(txtInputValue);
            grpDetails.Controls.Add(label3);
            grpDetails.Controls.Add(txtInitialValueUnits);
            grpDetails.Controls.Add(cmbOperation);
            grpDetails.Controls.Add(label2);
            grpDetails.Controls.Add(label1);
            grpDetails.Controls.Add(txtInitialValue);
            grpDetails.Enabled = false;
            grpDetails.Location = new Point(16, 119);
            grpDetails.Margin = new Padding(0, 0, 0, 8);
            grpDetails.Name = "grpDetails";
            grpDetails.Padding = new Padding(16);
            grpDetails.Size = new Size(489, 575);
            grpDetails.TabIndex = 27;
            grpDetails.TabStop = false;
            grpDetails.Text = "Details";
            grpDetails.EnabledChanged += grpDetails_EnabledChanged;
            // 
            // lblDatePreview
            // 
            lblDatePreview.AutoSize = true;
            lblDatePreview.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblDatePreview.Location = new Point(16, 438);
            lblDatePreview.Margin = new Padding(0, 0, 0, 12);
            lblDatePreview.Name = "lblDatePreview";
            lblDatePreview.Size = new Size(211, 16);
            lblDatePreview.TabIndex = 44;
            lblDatePreview.Text = "Please select date(s) to preview.";
            lblDatePreview.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnPrevMonth
            // 
            btnPrevMonth.AutoSize = true;
            btnPrevMonth.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnPrevMonth.Location = new Point(405, 194);
            btnPrevMonth.Margin = new Padding(8, 0, 0, 0);
            btnPrevMonth.Name = "btnPrevMonth";
            btnPrevMonth.Size = new Size(30, 28);
            btnPrevMonth.TabIndex = 43;
            btnPrevMonth.Text = "<";
            btnPrevMonth.UseVisualStyleBackColor = true;
            btnPrevMonth.Click += btnPrevMonth_Click;
            // 
            // btnNextMonth
            // 
            btnNextMonth.AutoSize = true;
            btnNextMonth.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnNextMonth.Location = new Point(443, 194);
            btnNextMonth.Margin = new Padding(8, 0, 0, 8);
            btnNextMonth.Name = "btnNextMonth";
            btnNextMonth.Size = new Size(30, 28);
            btnNextMonth.TabIndex = 42;
            btnNextMonth.Text = ">";
            btnNextMonth.UseVisualStyleBackColor = true;
            btnNextMonth.Click += btnNextMonth_Click;
            // 
            // lblMonthYear
            // 
            lblMonthYear.AutoSize = true;
            lblMonthYear.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblMonthYear.Location = new Point(16, 200);
            lblMonthYear.Margin = new Padding(0, 0, 0, 4);
            lblMonthYear.Name = "lblMonthYear";
            lblMonthYear.Size = new Size(37, 16);
            lblMonthYear.TabIndex = 41;
            lblMonthYear.Text = "Date";
            lblMonthYear.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlCalendar
            // 
            pnlCalendar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlCalendar.AutoSize = true;
            pnlCalendar.Location = new Point(16, 230);
            pnlCalendar.Margin = new Padding(0, 0, 0, 8);
            pnlCalendar.Name = "pnlCalendar";
            pnlCalendar.Size = new Size(457, 200);
            pnlCalendar.TabIndex = 40;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(16, 466);
            label7.Margin = new Padding(0, 0, 0, 4);
            label7.Name = "label7";
            label7.Size = new Size(63, 16);
            label7.TabIndex = 38;
            label7.Text = "Remarks";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtRemarks
            // 
            txtRemarks.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRemarks.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtRemarks.Location = new Point(16, 486);
            txtRemarks.Margin = new Padding(0, 0, 0, 16);
            txtRemarks.MaxLength = 100;
            txtRemarks.Name = "txtRemarks";
            txtRemarks.Size = new Size(457, 26);
            txtRemarks.TabIndex = 39;
            // 
            // btnReset
            // 
            btnReset.AutoSize = true;
            btnReset.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnReset.Location = new Point(398, 528);
            btnReset.Margin = new Padding(8, 0, 0, 0);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(75, 28);
            btnReset.TabIndex = 37;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(339, 140);
            label4.Margin = new Padding(0, 0, 0, 4);
            label4.Name = "label4";
            label4.Size = new Size(38, 16);
            label4.TabIndex = 34;
            label4.Text = "Units";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtInputValueUnits
            // 
            txtInputValueUnits.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtInputValueUnits.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtInputValueUnits.Location = new Point(339, 160);
            txtInputValueUnits.Margin = new Padding(0, 0, 0, 8);
            txtInputValueUnits.Name = "txtInputValueUnits";
            txtInputValueUnits.ReadOnly = true;
            txtInputValueUnits.Size = new Size(134, 26);
            txtInputValueUnits.TabIndex = 33;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(16, 140);
            label5.Margin = new Padding(0, 0, 0, 4);
            label5.Name = "label5";
            label5.Size = new Size(77, 16);
            label5.TabIndex = 31;
            label5.Text = "Input Value";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtInputValue
            // 
            txtInputValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtInputValue.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtInputValue.Location = new Point(16, 160);
            txtInputValue.Margin = new Padding(0, 0, 8, 8);
            txtInputValue.MaxLength = 5;
            txtInputValue.Name = "txtInputValue";
            txtInputValue.Size = new Size(315, 26);
            txtInputValue.TabIndex = 32;
            txtInputValue.TextChanged += txtInputValue_TextChanged;
            txtInputValue.KeyPress += txtInputValue_KeyPress;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(339, 32);
            label3.Margin = new Padding(0, 0, 0, 4);
            label3.Name = "label3";
            label3.Size = new Size(38, 16);
            label3.TabIndex = 30;
            label3.Text = "Units";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtInitialValueUnits
            // 
            txtInitialValueUnits.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtInitialValueUnits.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtInitialValueUnits.Location = new Point(339, 52);
            txtInitialValueUnits.Margin = new Padding(0, 0, 0, 8);
            txtInitialValueUnits.Name = "txtInitialValueUnits";
            txtInitialValueUnits.ReadOnly = true;
            txtInitialValueUnits.Size = new Size(134, 26);
            txtInitialValueUnits.TabIndex = 29;
            // 
            // cmbOperation
            // 
            cmbOperation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbOperation.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOperation.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbOperation.FormattingEnabled = true;
            cmbOperation.Items.AddRange(new object[] { "Add", "Subtract" });
            cmbOperation.Location = new Point(16, 106);
            cmbOperation.Margin = new Padding(0, 0, 0, 8);
            cmbOperation.Name = "cmbOperation";
            cmbOperation.Size = new Size(457, 26);
            cmbOperation.TabIndex = 28;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(16, 86);
            label2.Margin = new Padding(0, 0, 0, 4);
            label2.Name = "label2";
            label2.Size = new Size(70, 16);
            label2.TabIndex = 27;
            label2.Text = "Operation";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(16, 32);
            label1.Margin = new Padding(0, 0, 0, 4);
            label1.Name = "label1";
            label1.Size = new Size(78, 16);
            label1.TabIndex = 22;
            label1.Text = "Initial Value";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtInitialValue
            // 
            txtInitialValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtInitialValue.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtInitialValue.Location = new Point(16, 52);
            txtInitialValue.Margin = new Padding(0, 0, 8, 8);
            txtInitialValue.Name = "txtInitialValue";
            txtInitialValue.ReadOnly = true;
            txtInitialValue.Size = new Size(315, 26);
            txtInitialValue.TabIndex = 23;
            // 
            // cmbCategory
            // 
            cmbCategory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Items.AddRange(new object[] { "Regular Days", "Undertime", "Legal Holiday 100%", "Regular Overtime 125%", "Rest Day/Special Holiday 130%", "Rest Day Special Holiday 150%", "Rest Day/Special Holiday Excess 169%", "Special Holiday Excess Overtime 195%", "Legal Holiday Overtime 200%", "Legal Holiday Overtime 260%", "Regular Holiday 160%", "Night Differential 10%", "Night Differential 20%", "Night Differential 50%", "Night Differential 125%", "Night Differential 130%", "Night Differential 150%" });
            cmbCategory.Location = new Point(16, 77);
            cmbCategory.Margin = new Padding(0, 0, 0, 16);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(489, 26);
            cmbCategory.TabIndex = 26;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label29.Location = new Point(16, 57);
            label29.Margin = new Padding(0, 0, 0, 4);
            label29.Name = "label29";
            label29.Size = new Size(65, 16);
            label29.TabIndex = 25;
            label29.Text = "Category";
            // 
            // pnlLine2
            // 
            pnlLine2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLine2.BorderStyle = BorderStyle.FixedSingle;
            pnlLine2.Location = new Point(16, 40);
            pnlLine2.Margin = new Padding(0, 0, 0, 16);
            pnlLine2.Name = "pnlLine2";
            pnlLine2.Size = new Size(489, 1);
            pnlLine2.TabIndex = 4;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(16, 16);
            lblTitle.Margin = new Padding(0, 0, 0, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(86, 16);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Adjustment";
            // 
            // AddAdjustmentForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(521, 787);
            ControlBox = false;
            Controls.Add(pnlBody);
            Controls.Add(pnlFooter);
            Controls.Add(pnlLine1);
            Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "AddAdjustmentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Load += AddAdjustmentForm_Load;
            pnlFooter.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            grpDetails.ResumeLayout(false);
            grpDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLine1;
        private Panel pnlFooter;
        private Panel pnlBody;
        private Label lblTitle;
        private Panel pnlLine2;
        private TextBox txtRegularInDays;
        private Label label1;
        private ComboBox cmbDepartment;
        private Label label29;
        private GroupBox grpDetails;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Label label2;
        private Label label4;
        private TextBox textBox2;
        private Label label5;
        private TextBox textBox3;
        private Label label3;
        private Label label6;
        private DateTimePicker dtpDate;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnAdd;
        private Button btnCancel;
        private TextBox txtInitialValue;
        private ComboBox cmbCategory;
        private TextBox txtInputValueUnits;
        private TextBox txtInputValue;
        private TextBox txtInitialValueUnits;
        private ComboBox cmbOperation;
        private Button btnReset;
        private Label label7;
        private TextBox txtRemarks;
        private MonthCalendar calDate;
        private Panel pnlCalendar;
        private Label label8;
        private Label lblMonthYear;
        private Button btnPrevMonth;
        private Button btnNextMonth;
        private Label lblDatePreview;
        private CheckBox chkSIL;
    }
}