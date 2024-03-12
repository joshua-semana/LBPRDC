namespace LBPRDC.Source.Views.Categories
{
    partial class CategoriesControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlBody = new Panel();
            btnAdd = new Button();
            dgvCategory = new DataGridView();
            pnlLine1 = new Panel();
            btnSelect = new Button();
            cmbCategories = new ComboBox();
            pnlRight = new Panel();
            pnlRightBody = new Panel();
            flowRightContent = new FlowLayoutPanel();
            lblID = new Label();
            txtID = new TextBox();
            lblClient = new Label();
            cmbClient = new ComboBox();
            lblCode = new Label();
            txtCode = new TextBox();
            lblName = new Label();
            txtName = new TextBox();
            lblDepartment = new Label();
            cmbDepartment = new ComboBox();
            lblSalaryRate = new Label();
            txtSalaryRate = new TextBox();
            lblBillingRate = new Label();
            txtBillingRate = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            pnlRightFooter = new Panel();
            flowFooterActions = new FlowLayoutPanel();
            btnUpdate = new Button();
            btnHistory = new Button();
            pnlRightHeader = new Panel();
            label2 = new Label();
            pnlFooter = new Panel();
            pnlVLine1 = new Panel();
            pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategory).BeginInit();
            pnlRight.SuspendLayout();
            pnlRightBody.SuspendLayout();
            flowRightContent.SuspendLayout();
            pnlRightFooter.SuspendLayout();
            flowFooterActions.SuspendLayout();
            pnlRightHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(btnAdd);
            pnlBody.Controls.Add(dgvCategory);
            pnlBody.Controls.Add(pnlLine1);
            pnlBody.Controls.Add(btnSelect);
            pnlBody.Controls.Add(cmbCategories);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 0);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(24);
            pnlBody.Size = new Size(853, 628);
            pnlBody.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.AutoSize = true;
            btnAdd.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnAdd.Location = new Point(755, 23);
            btnAdd.Margin = new Padding(0);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 28);
            btnAdd.TabIndex = 27;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvCategory
            // 
            dgvCategory.AllowUserToAddRows = false;
            dgvCategory.AllowUserToDeleteRows = false;
            dgvCategory.AllowUserToOrderColumns = true;
            dgvCategory.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.SelectionBackColor = Color.SeaGreen;
            dgvCategory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvCategory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCategory.BackgroundColor = SystemColors.Window;
            dgvCategory.BorderStyle = BorderStyle.Fixed3D;
            dgvCategory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCategory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new Padding(0, 2, 0, 2);
            dataGridViewCellStyle2.SelectionBackColor = Color.MediumSeaGreen;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCategory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCategory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategory.EditMode = DataGridViewEditMode.EditOnF2;
            dgvCategory.GridColor = SystemColors.Control;
            dgvCategory.Location = new Point(24, 83);
            dgvCategory.Margin = new Padding(0);
            dgvCategory.MultiSelect = false;
            dgvCategory.Name = "dgvCategory";
            dgvCategory.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new Padding(4);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvCategory.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvCategory.RowHeadersVisible = false;
            dgvCategory.RowTemplate.DefaultCellStyle.Padding = new Padding(4, 8, 4, 8);
            dgvCategory.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgvCategory.RowTemplate.Height = 41;
            dgvCategory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategory.Size = new Size(805, 521);
            dgvCategory.TabIndex = 13;
            dgvCategory.VirtualMode = true;
            dgvCategory.SelectionChanged += dgvCategory_SelectionChanged;
            // 
            // pnlLine1
            // 
            pnlLine1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLine1.BorderStyle = BorderStyle.FixedSingle;
            pnlLine1.Location = new Point(24, 66);
            pnlLine1.Margin = new Padding(0, 0, 0, 16);
            pnlLine1.Name = "pnlLine1";
            pnlLine1.Size = new Size(805, 1);
            pnlLine1.TabIndex = 12;
            // 
            // btnSelect
            // 
            btnSelect.AutoSize = true;
            btnSelect.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSelect.Location = new Point(247, 23);
            btnSelect.Margin = new Padding(8, 0, 0, 0);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(75, 28);
            btnSelect.TabIndex = 26;
            btnSelect.Text = "Select";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Visible = false;
            btnSelect.Click += btnSelect_Click;
            // 
            // cmbCategories
            // 
            cmbCategories.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategories.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbCategories.FormattingEnabled = true;
            cmbCategories.Location = new Point(24, 24);
            cmbCategories.Margin = new Padding(0, 0, 0, 16);
            cmbCategories.Name = "cmbCategories";
            cmbCategories.Size = new Size(215, 26);
            cmbCategories.TabIndex = 0;
            cmbCategories.SelectedIndexChanged += cmbCategories_SelectedIndexChanged;
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.White;
            pnlRight.Controls.Add(pnlRightBody);
            pnlRight.Controls.Add(pnlRightFooter);
            pnlRight.Controls.Add(pnlRightHeader);
            pnlRight.Dock = DockStyle.Right;
            pnlRight.Location = new Point(853, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(360, 628);
            pnlRight.TabIndex = 1;
            // 
            // pnlRightBody
            // 
            pnlRightBody.Controls.Add(flowRightContent);
            pnlRightBody.Dock = DockStyle.Fill;
            pnlRightBody.Location = new Point(0, 40);
            pnlRightBody.Name = "pnlRightBody";
            pnlRightBody.Size = new Size(360, 528);
            pnlRightBody.TabIndex = 1;
            // 
            // flowRightContent
            // 
            flowRightContent.Controls.Add(lblID);
            flowRightContent.Controls.Add(txtID);
            flowRightContent.Controls.Add(lblClient);
            flowRightContent.Controls.Add(cmbClient);
            flowRightContent.Controls.Add(lblCode);
            flowRightContent.Controls.Add(txtCode);
            flowRightContent.Controls.Add(lblName);
            flowRightContent.Controls.Add(txtName);
            flowRightContent.Controls.Add(lblDepartment);
            flowRightContent.Controls.Add(cmbDepartment);
            flowRightContent.Controls.Add(lblSalaryRate);
            flowRightContent.Controls.Add(txtSalaryRate);
            flowRightContent.Controls.Add(lblBillingRate);
            flowRightContent.Controls.Add(txtBillingRate);
            flowRightContent.Controls.Add(lblDescription);
            flowRightContent.Controls.Add(txtDescription);
            flowRightContent.Controls.Add(lblStatus);
            flowRightContent.Controls.Add(cmbStatus);
            flowRightContent.Dock = DockStyle.Fill;
            flowRightContent.FlowDirection = FlowDirection.TopDown;
            flowRightContent.Location = new Point(0, 0);
            flowRightContent.Name = "flowRightContent";
            flowRightContent.Padding = new Padding(16);
            flowRightContent.Size = new Size(360, 528);
            flowRightContent.TabIndex = 0;
            // 
            // lblID
            // 
            lblID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblID.AutoSize = true;
            lblID.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblID.ForeColor = SystemColors.GrayText;
            lblID.Location = new Point(19, 16);
            lblID.Margin = new Padding(3, 0, 3, 2);
            lblID.Name = "lblID";
            lblID.Size = new Size(322, 16);
            lblID.TabIndex = 1;
            lblID.Text = "ID";
            lblID.Visible = false;
            // 
            // txtID
            // 
            txtID.AccessibleName = "ID";
            txtID.Location = new Point(22, 37);
            txtID.Margin = new Padding(6, 3, 3, 12);
            txtID.MaxLength = 100;
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(319, 23);
            txtID.TabIndex = 9;
            txtID.Visible = false;
            // 
            // lblClient
            // 
            lblClient.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblClient.AutoSize = true;
            lblClient.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblClient.ForeColor = SystemColors.GrayText;
            lblClient.Location = new Point(19, 72);
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
            cmbClient.Location = new Point(22, 93);
            cmbClient.Margin = new Padding(6, 3, 3, 12);
            cmbClient.Name = "cmbClient";
            cmbClient.Size = new Size(319, 24);
            cmbClient.TabIndex = 25;
            cmbClient.Visible = false;
            // 
            // lblCode
            // 
            lblCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblCode.AutoSize = true;
            lblCode.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblCode.ForeColor = SystemColors.GrayText;
            lblCode.Location = new Point(19, 129);
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
            txtCode.Location = new Point(22, 150);
            txtCode.Margin = new Padding(6, 3, 3, 12);
            txtCode.MaxLength = 100;
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(319, 23);
            txtCode.TabIndex = 11;
            txtCode.Visible = false;
            txtCode.KeyPress += ToUpperCase_KeyPress;
            // 
            // lblName
            // 
            lblName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblName.AutoSize = true;
            lblName.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblName.ForeColor = SystemColors.GrayText;
            lblName.Location = new Point(19, 185);
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
            txtName.Location = new Point(22, 206);
            txtName.Margin = new Padding(6, 3, 3, 12);
            txtName.MaxLength = 100;
            txtName.Name = "txtName";
            txtName.Size = new Size(319, 23);
            txtName.TabIndex = 13;
            txtName.Visible = false;
            // 
            // lblDepartment
            // 
            lblDepartment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDepartment.AutoSize = true;
            lblDepartment.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblDepartment.ForeColor = SystemColors.GrayText;
            lblDepartment.Location = new Point(19, 241);
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
            cmbDepartment.Location = new Point(22, 262);
            cmbDepartment.Margin = new Padding(6, 3, 3, 12);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(319, 24);
            cmbDepartment.TabIndex = 23;
            cmbDepartment.Visible = false;
            // 
            // lblSalaryRate
            // 
            lblSalaryRate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSalaryRate.AutoSize = true;
            lblSalaryRate.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblSalaryRate.ForeColor = SystemColors.GrayText;
            lblSalaryRate.Location = new Point(19, 298);
            lblSalaryRate.Margin = new Padding(3, 0, 3, 2);
            lblSalaryRate.Name = "lblSalaryRate";
            lblSalaryRate.Size = new Size(322, 16);
            lblSalaryRate.TabIndex = 14;
            lblSalaryRate.Text = "Salary Rate";
            lblSalaryRate.Visible = false;
            // 
            // txtSalaryRate
            // 
            txtSalaryRate.AccessibleName = "Salary Rate";
            txtSalaryRate.Location = new Point(22, 319);
            txtSalaryRate.Margin = new Padding(6, 3, 3, 12);
            txtSalaryRate.MaxLength = 100;
            txtSalaryRate.Name = "txtSalaryRate";
            txtSalaryRate.Size = new Size(319, 23);
            txtSalaryRate.TabIndex = 15;
            txtSalaryRate.Visible = false;
            txtSalaryRate.KeyPress += ValidateInputIfNumber_KeyPress;
            // 
            // lblBillingRate
            // 
            lblBillingRate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblBillingRate.AutoSize = true;
            lblBillingRate.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblBillingRate.ForeColor = SystemColors.GrayText;
            lblBillingRate.Location = new Point(19, 354);
            lblBillingRate.Margin = new Padding(3, 0, 3, 2);
            lblBillingRate.Name = "lblBillingRate";
            lblBillingRate.Size = new Size(322, 16);
            lblBillingRate.TabIndex = 16;
            lblBillingRate.Text = "Billing Rate";
            lblBillingRate.Visible = false;
            // 
            // txtBillingRate
            // 
            txtBillingRate.AccessibleName = "Billing Rate";
            txtBillingRate.Location = new Point(22, 375);
            txtBillingRate.Margin = new Padding(6, 3, 3, 12);
            txtBillingRate.MaxLength = 100;
            txtBillingRate.Name = "txtBillingRate";
            txtBillingRate.Size = new Size(319, 23);
            txtBillingRate.TabIndex = 17;
            txtBillingRate.Visible = false;
            txtBillingRate.KeyPress += ValidateInputIfNumber_KeyPress;
            // 
            // lblDescription
            // 
            lblDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblDescription.ForeColor = SystemColors.GrayText;
            lblDescription.Location = new Point(19, 410);
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
            txtDescription.Location = new Point(22, 431);
            txtDescription.Margin = new Padding(6, 3, 3, 12);
            txtDescription.MaxLength = 100;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(319, 23);
            txtDescription.TabIndex = 19;
            txtDescription.Visible = false;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblStatus.ForeColor = SystemColors.GrayText;
            lblStatus.Location = new Point(19, 466);
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
            cmbStatus.Location = new Point(22, 487);
            cmbStatus.Margin = new Padding(6, 3, 3, 0);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(319, 24);
            cmbStatus.TabIndex = 21;
            cmbStatus.Visible = false;
            // 
            // pnlRightFooter
            // 
            pnlRightFooter.BackColor = SystemColors.Control;
            pnlRightFooter.Controls.Add(flowFooterActions);
            pnlRightFooter.Dock = DockStyle.Bottom;
            pnlRightFooter.Location = new Point(0, 568);
            pnlRightFooter.Name = "pnlRightFooter";
            pnlRightFooter.Size = new Size(360, 60);
            pnlRightFooter.TabIndex = 2;
            // 
            // flowFooterActions
            // 
            flowFooterActions.Controls.Add(btnUpdate);
            flowFooterActions.Controls.Add(btnHistory);
            flowFooterActions.Dock = DockStyle.Right;
            flowFooterActions.FlowDirection = FlowDirection.RightToLeft;
            flowFooterActions.Location = new Point(157, 0);
            flowFooterActions.Name = "flowFooterActions";
            flowFooterActions.Padding = new Padding(15, 16, 0, 16);
            flowFooterActions.Size = new Size(203, 60);
            flowFooterActions.TabIndex = 3;
            // 
            // btnUpdate
            // 
            btnUpdate.AutoSize = true;
            btnUpdate.Enabled = false;
            btnUpdate.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpdate.Location = new Point(113, 16);
            btnUpdate.Margin = new Padding(8, 0, 0, 0);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 28);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnHistory
            // 
            btnHistory.AutoSize = true;
            btnHistory.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnHistory.Location = new Point(30, 16);
            btnHistory.Margin = new Padding(8, 0, 0, 0);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(75, 28);
            btnHistory.TabIndex = 9;
            btnHistory.Text = "History";
            btnHistory.UseVisualStyleBackColor = true;
            btnHistory.Click += btnHistory_Click;
            // 
            // pnlRightHeader
            // 
            pnlRightHeader.BackColor = SystemColors.Control;
            pnlRightHeader.Controls.Add(label2);
            pnlRightHeader.Dock = DockStyle.Top;
            pnlRightHeader.Location = new Point(0, 0);
            pnlRightHeader.Name = "pnlRightHeader";
            pnlRightHeader.Size = new Size(360, 40);
            pnlRightHeader.TabIndex = 0;
            // 
            // label2
            // 
            label2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(8, 11);
            label2.Margin = new Padding(0, 0, 0, 16);
            label2.Name = "label2";
            label2.Size = new Size(345, 19);
            label2.TabIndex = 27;
            label2.Text = "DETAILS";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = SystemColors.Control;
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 628);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1213, 1);
            pnlFooter.TabIndex = 2;
            pnlFooter.Visible = false;
            // 
            // pnlVLine1
            // 
            pnlVLine1.BorderStyle = BorderStyle.FixedSingle;
            pnlVLine1.Dock = DockStyle.Right;
            pnlVLine1.Location = new Point(852, 0);
            pnlVLine1.Name = "pnlVLine1";
            pnlVLine1.Size = new Size(1, 628);
            pnlVLine1.TabIndex = 3;
            // 
            // CategoriesControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            Controls.Add(pnlVLine1);
            Controls.Add(pnlBody);
            Controls.Add(pnlRight);
            Controls.Add(pnlFooter);
            Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "CategoriesControl";
            Size = new Size(1213, 629);
            VisibleChanged += CategoriesControl_VisibleChanged;
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategory).EndInit();
            pnlRight.ResumeLayout(false);
            pnlRightBody.ResumeLayout(false);
            flowRightContent.ResumeLayout(false);
            flowRightContent.PerformLayout();
            pnlRightFooter.ResumeLayout(false);
            flowFooterActions.ResumeLayout(false);
            flowFooterActions.PerformLayout();
            pnlRightHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlBody;
        private Panel pnlRight;
        private Panel pnlFooter;
        private Panel pnlLine1;
        private ComboBox cmbCategories;
        private DataGridView dgvCategory;
        private Panel panel1;
        private Panel pnlVLine1;
        private Panel pnlRightFooter;
        private Panel pnlRightBody;
        private Panel pnlRightHeader;
        private FlowLayoutPanel flowRightContent;
        private Label lblID;
        private TextBox txtID;
        private Label lblCode;
        private TextBox txtCode;
        private Label lblName;
        private TextBox txtName;
        private Label lblSalaryRate;
        private TextBox txtSalaryRate;
        private Label lblBillingRate;
        private TextBox txtBillingRate;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Label lblDepartment;
        private ComboBox cmbDepartment;
        private Button btnSelect;
        private Label label2;
        private FlowLayoutPanel flowFooterActions;
        private Button btnUpdate;
        private Button btnAdd;
        private Button btnHistory;
        private Label lblClient;
        private ComboBox cmbClient;
    }
}
