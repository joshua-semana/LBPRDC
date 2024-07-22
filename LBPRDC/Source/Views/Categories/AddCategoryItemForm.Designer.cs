using LBPRDC.Source.Config;

namespace LBPRDC.Source.Views.Categories
{
    partial class AddCategoryItemForm
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
            pnlHeader = new Panel();
            lblTitle = new Label();
            flowBody = new FlowLayoutPanel();
            lblPayFrequency = new Label();
            cmbPayFrequency = new ComboBox();
            lblCode = new Label();
            txtCode = new TextBox();
            lblName = new Label();
            txtName = new TextBox();
            lblClient = new Label();
            cmbClient = new ComboBox();
            lblDepartment = new Label();
            cmbDepartment = new ComboBox();
            lblDailySalaryRate = new Label();
            txtDailySalaryRate = new TextBox();
            lblDailyBillingRate = new Label();
            txtDailyBillingRate = new TextBox();
            lblMonthlySalaryRate = new Label();
            txtMonthlySalaryRate = new TextBox();
            lblMonthlyBillingRate = new Label();
            txtMonthlyBillingRate = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            pnlFooter = new Panel();
            flowFooterActions = new FlowLayoutPanel();
            btnAdd = new Button();
            btnCancel = new Button();
            pnlHeader.SuspendLayout();
            flowBody.SuspendLayout();
            pnlFooter.SuspendLayout();
            flowFooterActions.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = SystemColors.Control;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(363, 40);
            pnlHeader.TabIndex = 3;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(9, 11);
            lblTitle.Margin = new Padding(0, 0, 0, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(345, 19);
            lblTitle.TabIndex = 27;
            lblTitle.Text = "NEW ITEM";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowBody
            // 
            flowBody.Controls.Add(lblPayFrequency);
            flowBody.Controls.Add(cmbPayFrequency);
            flowBody.Controls.Add(lblCode);
            flowBody.Controls.Add(txtCode);
            flowBody.Controls.Add(lblName);
            flowBody.Controls.Add(txtName);
            flowBody.Controls.Add(lblClient);
            flowBody.Controls.Add(cmbClient);
            flowBody.Controls.Add(lblDepartment);
            flowBody.Controls.Add(cmbDepartment);
            flowBody.Controls.Add(lblDailySalaryRate);
            flowBody.Controls.Add(txtDailySalaryRate);
            flowBody.Controls.Add(lblDailyBillingRate);
            flowBody.Controls.Add(txtDailyBillingRate);
            flowBody.Controls.Add(lblMonthlySalaryRate);
            flowBody.Controls.Add(txtMonthlySalaryRate);
            flowBody.Controls.Add(lblMonthlyBillingRate);
            flowBody.Controls.Add(txtMonthlyBillingRate);
            flowBody.Controls.Add(lblDescription);
            flowBody.Controls.Add(txtDescription);
            flowBody.Controls.Add(lblStatus);
            flowBody.Controls.Add(cmbStatus);
            flowBody.Dock = DockStyle.Fill;
            flowBody.FlowDirection = FlowDirection.TopDown;
            flowBody.Location = new Point(0, 40);
            flowBody.Name = "flowBody";
            flowBody.Padding = new Padding(16);
            flowBody.Size = new Size(363, 652);
            flowBody.TabIndex = 4;
            // 
            // lblPayFrequency
            // 
            lblPayFrequency.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPayFrequency.AutoSize = true;
            lblPayFrequency.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblPayFrequency.ForeColor = SystemColors.GrayText;
            lblPayFrequency.Location = new Point(19, 16);
            lblPayFrequency.Margin = new Padding(3, 0, 3, 2);
            lblPayFrequency.Name = "lblPayFrequency";
            lblPayFrequency.Size = new Size(322, 16);
            lblPayFrequency.TabIndex = 30;
            lblPayFrequency.Text = "Pay Frequency";
            lblPayFrequency.Visible = false;
            // 
            // cmbPayFrequency
            // 
            cmbPayFrequency.AccessibleName = "Pay Frequency";
            cmbPayFrequency.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPayFrequency.Enabled = false;
            cmbPayFrequency.FormattingEnabled = true;
            cmbPayFrequency.Location = new Point(22, 37);
            cmbPayFrequency.Margin = new Padding(6, 3, 3, 12);
            cmbPayFrequency.Name = "cmbPayFrequency";
            cmbPayFrequency.Size = new Size(319, 24);
            cmbPayFrequency.TabIndex = 29;
            cmbPayFrequency.Visible = false;
            // 
            // lblCode
            // 
            lblCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblCode.AutoSize = true;
            lblCode.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblCode.ForeColor = SystemColors.GrayText;
            lblCode.Location = new Point(19, 73);
            lblCode.Margin = new Padding(3, 0, 3, 2);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(322, 16);
            lblCode.TabIndex = 10;
            lblCode.Text = "Code";
            lblCode.Visible = false;
            // 
            // txtCode
            // 
            txtCode.AccessibleName = "Code";
            txtCode.Location = new Point(22, 94);
            txtCode.Margin = new Padding(6, 3, 3, 12);
            txtCode.MaxLength = 100;
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(319, 23);
            txtCode.TabIndex = 1;
            txtCode.Visible = false;
            txtCode.KeyPress += ToUpperCase_KeyPress;
            // 
            // lblName
            // 
            lblName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblName.AutoSize = true;
            lblName.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblName.ForeColor = SystemColors.GrayText;
            lblName.Location = new Point(19, 129);
            lblName.Margin = new Padding(3, 0, 3, 2);
            lblName.Name = "lblName";
            lblName.Size = new Size(322, 16);
            lblName.TabIndex = 12;
            lblName.Text = "Name";
            lblName.Visible = false;
            // 
            // txtName
            // 
            txtName.AccessibleName = "Name";
            txtName.Location = new Point(22, 150);
            txtName.Margin = new Padding(6, 3, 3, 12);
            txtName.MaxLength = 100;
            txtName.Name = "txtName";
            txtName.Size = new Size(319, 23);
            txtName.TabIndex = 2;
            txtName.Visible = false;
            // 
            // lblClient
            // 
            lblClient.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblClient.AutoSize = true;
            lblClient.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblClient.ForeColor = SystemColors.GrayText;
            lblClient.Location = new Point(19, 185);
            lblClient.Margin = new Padding(3, 0, 3, 2);
            lblClient.Name = "lblClient";
            lblClient.Size = new Size(322, 16);
            lblClient.TabIndex = 24;
            lblClient.Text = "Client";
            lblClient.Visible = false;
            // 
            // cmbClient
            // 
            cmbClient.AccessibleName = "Client";
            cmbClient.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClient.FormattingEnabled = true;
            cmbClient.Location = new Point(22, 206);
            cmbClient.Margin = new Padding(6, 3, 3, 12);
            cmbClient.Name = "cmbClient";
            cmbClient.Size = new Size(319, 24);
            cmbClient.TabIndex = 3;
            cmbClient.Visible = false;
            // 
            // lblDepartment
            // 
            lblDepartment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDepartment.AutoSize = true;
            lblDepartment.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblDepartment.ForeColor = SystemColors.GrayText;
            lblDepartment.Location = new Point(19, 242);
            lblDepartment.Margin = new Padding(3, 0, 3, 2);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(322, 16);
            lblDepartment.TabIndex = 22;
            lblDepartment.Text = "Department";
            lblDepartment.Visible = false;
            // 
            // cmbDepartment
            // 
            cmbDepartment.AccessibleName = "Department";
            cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.Location = new Point(22, 263);
            cmbDepartment.Margin = new Padding(6, 3, 3, 12);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(319, 24);
            cmbDepartment.TabIndex = 4;
            cmbDepartment.Visible = false;
            // 
            // lblDailySalaryRate
            // 
            lblDailySalaryRate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDailySalaryRate.AutoSize = true;
            lblDailySalaryRate.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblDailySalaryRate.ForeColor = SystemColors.GrayText;
            lblDailySalaryRate.Location = new Point(19, 299);
            lblDailySalaryRate.Margin = new Padding(3, 0, 3, 2);
            lblDailySalaryRate.Name = "lblDailySalaryRate";
            lblDailySalaryRate.Size = new Size(322, 16);
            lblDailySalaryRate.TabIndex = 14;
            lblDailySalaryRate.Text = "Salary Rate (Daily)";
            lblDailySalaryRate.Visible = false;
            // 
            // txtDailySalaryRate
            // 
            txtDailySalaryRate.AccessibleName = "Salary Rate (Daily)";
            txtDailySalaryRate.Location = new Point(22, 320);
            txtDailySalaryRate.Margin = new Padding(6, 3, 3, 12);
            txtDailySalaryRate.MaxLength = 100;
            txtDailySalaryRate.Name = "txtDailySalaryRate";
            txtDailySalaryRate.Size = new Size(319, 23);
            txtDailySalaryRate.TabIndex = 5;
            txtDailySalaryRate.Visible = false;
            txtDailySalaryRate.KeyPress += ValidateInputIfNumber_KeyPress;
            // 
            // lblDailyBillingRate
            // 
            lblDailyBillingRate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDailyBillingRate.AutoSize = true;
            lblDailyBillingRate.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblDailyBillingRate.ForeColor = SystemColors.GrayText;
            lblDailyBillingRate.Location = new Point(19, 355);
            lblDailyBillingRate.Margin = new Padding(3, 0, 3, 2);
            lblDailyBillingRate.Name = "lblDailyBillingRate";
            lblDailyBillingRate.Size = new Size(322, 16);
            lblDailyBillingRate.TabIndex = 16;
            lblDailyBillingRate.Text = "Billing Rate (Daily)";
            lblDailyBillingRate.Visible = false;
            // 
            // txtDailyBillingRate
            // 
            txtDailyBillingRate.AccessibleName = "Billing Rate (Daily)";
            txtDailyBillingRate.Location = new Point(22, 376);
            txtDailyBillingRate.Margin = new Padding(6, 3, 3, 12);
            txtDailyBillingRate.MaxLength = 100;
            txtDailyBillingRate.Name = "txtDailyBillingRate";
            txtDailyBillingRate.Size = new Size(319, 23);
            txtDailyBillingRate.TabIndex = 6;
            txtDailyBillingRate.Visible = false;
            txtDailyBillingRate.KeyPress += ValidateInputIfNumber_KeyPress;
            // 
            // lblMonthlySalaryRate
            // 
            lblMonthlySalaryRate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblMonthlySalaryRate.AutoSize = true;
            lblMonthlySalaryRate.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblMonthlySalaryRate.ForeColor = SystemColors.GrayText;
            lblMonthlySalaryRate.Location = new Point(19, 411);
            lblMonthlySalaryRate.Margin = new Padding(3, 0, 3, 2);
            lblMonthlySalaryRate.Name = "lblMonthlySalaryRate";
            lblMonthlySalaryRate.Size = new Size(322, 16);
            lblMonthlySalaryRate.TabIndex = 27;
            lblMonthlySalaryRate.Text = "Salary Rate (Monthly)";
            lblMonthlySalaryRate.Visible = false;
            // 
            // txtMonthlySalaryRate
            // 
            txtMonthlySalaryRate.AccessibleName = "Salary Rate (Monthly)";
            txtMonthlySalaryRate.Location = new Point(22, 432);
            txtMonthlySalaryRate.Margin = new Padding(6, 3, 3, 12);
            txtMonthlySalaryRate.MaxLength = 100;
            txtMonthlySalaryRate.Name = "txtMonthlySalaryRate";
            txtMonthlySalaryRate.Size = new Size(319, 23);
            txtMonthlySalaryRate.TabIndex = 25;
            txtMonthlySalaryRate.Visible = false;
            txtMonthlySalaryRate.KeyPress += ValidateInputIfNumber_KeyPress;
            // 
            // lblMonthlyBillingRate
            // 
            lblMonthlyBillingRate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblMonthlyBillingRate.AutoSize = true;
            lblMonthlyBillingRate.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblMonthlyBillingRate.ForeColor = SystemColors.GrayText;
            lblMonthlyBillingRate.Location = new Point(19, 467);
            lblMonthlyBillingRate.Margin = new Padding(3, 0, 3, 2);
            lblMonthlyBillingRate.Name = "lblMonthlyBillingRate";
            lblMonthlyBillingRate.Size = new Size(322, 16);
            lblMonthlyBillingRate.TabIndex = 28;
            lblMonthlyBillingRate.Text = "Billing Rate (Monthly)";
            lblMonthlyBillingRate.Visible = false;
            // 
            // txtMonthlyBillingRate
            // 
            txtMonthlyBillingRate.AccessibleName = "Billing Rate (Monthly)";
            txtMonthlyBillingRate.Location = new Point(22, 488);
            txtMonthlyBillingRate.Margin = new Padding(6, 3, 3, 12);
            txtMonthlyBillingRate.MaxLength = 100;
            txtMonthlyBillingRate.Name = "txtMonthlyBillingRate";
            txtMonthlyBillingRate.Size = new Size(319, 23);
            txtMonthlyBillingRate.TabIndex = 26;
            txtMonthlyBillingRate.Visible = false;
            txtMonthlyBillingRate.KeyPress += ValidateInputIfNumber_KeyPress;
            // 
            // lblDescription
            // 
            lblDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblDescription.ForeColor = SystemColors.GrayText;
            lblDescription.Location = new Point(19, 523);
            lblDescription.Margin = new Padding(3, 0, 3, 2);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(322, 16);
            lblDescription.TabIndex = 18;
            lblDescription.Text = "Description";
            lblDescription.Visible = false;
            // 
            // txtDescription
            // 
            txtDescription.AccessibleName = "Description";
            txtDescription.Location = new Point(22, 544);
            txtDescription.Margin = new Padding(6, 3, 3, 12);
            txtDescription.MaxLength = 100;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(319, 23);
            txtDescription.TabIndex = 7;
            txtDescription.Visible = false;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblStatus.ForeColor = SystemColors.GrayText;
            lblStatus.Location = new Point(19, 579);
            lblStatus.Margin = new Padding(3, 0, 3, 2);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(322, 16);
            lblStatus.TabIndex = 20;
            lblStatus.Text = "Status";
            lblStatus.Visible = false;
            // 
            // cmbStatus
            // 
            cmbStatus.AccessibleName = "Status";
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "(Choose Status)", "Active", "Inactive" });
            cmbStatus.Location = new Point(22, 600);
            cmbStatus.Margin = new Padding(6, 3, 3, 12);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(319, 24);
            cmbStatus.TabIndex = 8;
            cmbStatus.Visible = false;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = SystemColors.Control;
            pnlFooter.Controls.Add(flowFooterActions);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 692);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(363, 60);
            pnlFooter.TabIndex = 5;
            // 
            // flowFooterActions
            // 
            flowFooterActions.Controls.Add(btnAdd);
            flowFooterActions.Controls.Add(btnCancel);
            flowFooterActions.Dock = DockStyle.Right;
            flowFooterActions.FlowDirection = FlowDirection.RightToLeft;
            flowFooterActions.Location = new Point(120, 0);
            flowFooterActions.Name = "flowFooterActions";
            flowFooterActions.Padding = new Padding(15, 16, 0, 16);
            flowFooterActions.Size = new Size(243, 60);
            flowFooterActions.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.AutoSize = true;
            btnAdd.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnAdd.Location = new Point(153, 16);
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
            btnCancel.Location = new Point(70, 16);
            btnCancel.Margin = new Padding(8, 0, 0, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 28);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // AddCategoryItemForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(363, 752);
            Controls.Add(flowBody);
            Controls.Add(pnlHeader);
            Controls.Add(pnlFooter);
            Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddCategoryItemForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add";
            Load += AddCategoryItemForm_Load;
            pnlHeader.ResumeLayout(false);
            flowBody.ResumeLayout(false);
            flowBody.PerformLayout();
            pnlFooter.ResumeLayout(false);
            flowFooterActions.ResumeLayout(false);
            flowFooterActions.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private FlowLayoutPanel flowBody;
        private Label lblID;
        private TextBox txtID;
        private Label lblCode;
        private TextBox txtCode;
        private Label lblName;
        private TextBox txtName;
        private Label lblDepartment;
        private ComboBox cmbDepartment;
        private Label lblDailySalaryRate;
        private TextBox txtDailySalaryRate;
        private Label lblDailyBillingRate;
        private TextBox txtDailyBillingRate;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Panel pnlFooter;
        private FlowLayoutPanel flowFooterActions;
        private Button btnAdd;
        private Button btnCancel;
        private Label lblClient;
        private ComboBox cmbClient;
        private Label lblMonthlySalaryRate;
        private TextBox txtMonthlySalaryRate;
        private Label lblMonthlyBillingRate;
        private TextBox txtMonthlyBillingRate;
        private Label lblPayFrequency;
        private ComboBox cmbPayFrequency;
    }
}