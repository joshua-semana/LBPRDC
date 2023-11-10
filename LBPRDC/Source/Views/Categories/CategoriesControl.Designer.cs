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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            pnlBody = new Panel();
            dgvUsers = new DataGridView();
            pnlContainerSearch = new Panel();
            label1 = new Label();
            cmbCategories = new ComboBox();
            pnlRight = new Panel();
            pnlRightBody = new Panel();
            flowRightContent = new FlowLayoutPanel();
            pnlRightFooter = new Panel();
            pnlRightHeader = new Panel();
            pnlFooter = new Panel();
            pnlVLine1 = new Panel();
            label10 = new Label();
            txtID = new TextBox();
            label2 = new Label();
            txtCode = new TextBox();
            label3 = new Label();
            txtName = new TextBox();
            label4 = new Label();
            txtSalaryRate = new TextBox();
            label5 = new Label();
            txtBillingRate = new TextBox();
            label6 = new Label();
            txtDescription = new TextBox();
            label7 = new Label();
            cmbStatus = new ComboBox();
            label8 = new Label();
            cmbDepartment = new ComboBox();
            pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            pnlContainerSearch.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlRightBody.SuspendLayout();
            flowRightContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(dgvUsers);
            pnlBody.Controls.Add(pnlContainerSearch);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 0);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(16);
            pnlBody.Size = new Size(853, 628);
            pnlBody.TabIndex = 0;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AllowUserToOrderColumns = true;
            dgvUsers.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.SelectionBackColor = Color.SeaGreen;
            dgvUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvUsers.BackgroundColor = SystemColors.Window;
            dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.Padding = new Padding(0, 2, 0, 2);
            dataGridViewCellStyle5.SelectionBackColor = Color.MediumSeaGreen;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.EditMode = DataGridViewEditMode.EditOnF2;
            dgvUsers.GridColor = SystemColors.Control;
            dgvUsers.Location = new Point(16, 77);
            dgvUsers.Margin = new Padding(0);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.Padding = new Padding(4);
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowTemplate.DefaultCellStyle.Padding = new Padding(4, 8, 4, 8);
            dgvUsers.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgvUsers.RowTemplate.Height = 41;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(821, 535);
            dgvUsers.TabIndex = 13;
            dgvUsers.VirtualMode = true;
            // 
            // pnlContainerSearch
            // 
            pnlContainerSearch.BorderStyle = BorderStyle.FixedSingle;
            pnlContainerSearch.Controls.Add(label1);
            pnlContainerSearch.Controls.Add(cmbCategories);
            pnlContainerSearch.Location = new Point(16, 16);
            pnlContainerSearch.Margin = new Padding(0, 0, 16, 16);
            pnlContainerSearch.Name = "pnlContainerSearch";
            pnlContainerSearch.Padding = new Padding(8);
            pnlContainerSearch.Size = new Size(285, 45);
            pnlContainerSearch.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.WindowText;
            label1.Location = new Point(8, 13);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(65, 16);
            label1.TabIndex = 9;
            label1.Text = "Category";
            // 
            // cmbCategories
            // 
            cmbCategories.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategories.FormattingEnabled = true;
            cmbCategories.Items.AddRange(new object[] { "Position", "Civil Status", "Department", "Location", "Employment Status" });
            cmbCategories.Location = new Point(76, 9);
            cmbCategories.Name = "cmbCategories";
            cmbCategories.Size = new Size(197, 24);
            cmbCategories.TabIndex = 0;
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
            flowRightContent.Controls.Add(label10);
            flowRightContent.Controls.Add(txtID);
            flowRightContent.Controls.Add(label2);
            flowRightContent.Controls.Add(txtCode);
            flowRightContent.Controls.Add(label3);
            flowRightContent.Controls.Add(txtName);
            flowRightContent.Controls.Add(label8);
            flowRightContent.Controls.Add(cmbDepartment);
            flowRightContent.Controls.Add(label4);
            flowRightContent.Controls.Add(txtSalaryRate);
            flowRightContent.Controls.Add(label5);
            flowRightContent.Controls.Add(txtBillingRate);
            flowRightContent.Controls.Add(label6);
            flowRightContent.Controls.Add(txtDescription);
            flowRightContent.Controls.Add(label7);
            flowRightContent.Controls.Add(cmbStatus);
            flowRightContent.Dock = DockStyle.Fill;
            flowRightContent.FlowDirection = FlowDirection.TopDown;
            flowRightContent.Location = new Point(0, 0);
            flowRightContent.Name = "flowRightContent";
            flowRightContent.Padding = new Padding(16);
            flowRightContent.Size = new Size(360, 528);
            flowRightContent.TabIndex = 0;
            // 
            // pnlRightFooter
            // 
            pnlRightFooter.BackColor = SystemColors.Control;
            pnlRightFooter.Dock = DockStyle.Bottom;
            pnlRightFooter.Location = new Point(0, 568);
            pnlRightFooter.Name = "pnlRightFooter";
            pnlRightFooter.Size = new Size(360, 60);
            pnlRightFooter.TabIndex = 2;
            // 
            // pnlRightHeader
            // 
            pnlRightHeader.BackColor = SystemColors.Control;
            pnlRightHeader.Dock = DockStyle.Top;
            pnlRightHeader.Location = new Point(0, 0);
            pnlRightHeader.Name = "pnlRightHeader";
            pnlRightHeader.Size = new Size(360, 40);
            pnlRightHeader.TabIndex = 0;
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
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(19, 16);
            label10.Margin = new Padding(3, 0, 3, 4);
            label10.Name = "label10";
            label10.Size = new Size(322, 16);
            label10.TabIndex = 1;
            label10.Text = "ID";
            // 
            // txtID
            // 
            txtID.AccessibleName = "ID";
            txtID.Location = new Point(22, 39);
            txtID.Margin = new Padding(6, 3, 3, 8);
            txtID.MaxLength = 100;
            txtID.Name = "txtID";
            txtID.Size = new Size(319, 23);
            txtID.TabIndex = 9;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(19, 70);
            label2.Margin = new Padding(3, 0, 3, 4);
            label2.Name = "label2";
            label2.Size = new Size(322, 16);
            label2.TabIndex = 10;
            label2.Text = "Code";
            // 
            // txtCode
            // 
            txtCode.AccessibleName = "Code";
            txtCode.Location = new Point(22, 93);
            txtCode.Margin = new Padding(6, 3, 3, 8);
            txtCode.MaxLength = 100;
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(319, 23);
            txtCode.TabIndex = 11;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(19, 124);
            label3.Margin = new Padding(3, 0, 3, 4);
            label3.Name = "label3";
            label3.Size = new Size(322, 16);
            label3.TabIndex = 12;
            label3.Text = "Name";
            // 
            // txtName
            // 
            txtName.AccessibleName = "Name";
            txtName.Location = new Point(22, 147);
            txtName.Margin = new Padding(6, 3, 3, 8);
            txtName.MaxLength = 100;
            txtName.Name = "txtName";
            txtName.Size = new Size(319, 23);
            txtName.TabIndex = 13;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(19, 233);
            label4.Margin = new Padding(3, 0, 3, 4);
            label4.Name = "label4";
            label4.Size = new Size(322, 16);
            label4.TabIndex = 14;
            label4.Text = "Salary Rate";
            // 
            // txtSalaryRate
            // 
            txtSalaryRate.AccessibleName = "Salary Rate";
            txtSalaryRate.Location = new Point(22, 256);
            txtSalaryRate.Margin = new Padding(6, 3, 3, 8);
            txtSalaryRate.MaxLength = 100;
            txtSalaryRate.Name = "txtSalaryRate";
            txtSalaryRate.Size = new Size(319, 23);
            txtSalaryRate.TabIndex = 15;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(19, 287);
            label5.Margin = new Padding(3, 0, 3, 4);
            label5.Name = "label5";
            label5.Size = new Size(322, 16);
            label5.TabIndex = 16;
            label5.Text = "Billing Rate";
            // 
            // txtBillingRate
            // 
            txtBillingRate.AccessibleName = "Billing Rate";
            txtBillingRate.Location = new Point(22, 310);
            txtBillingRate.Margin = new Padding(6, 3, 3, 8);
            txtBillingRate.MaxLength = 100;
            txtBillingRate.Name = "txtBillingRate";
            txtBillingRate.Size = new Size(319, 23);
            txtBillingRate.TabIndex = 17;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(19, 341);
            label6.Margin = new Padding(3, 0, 3, 4);
            label6.Name = "label6";
            label6.Size = new Size(322, 16);
            label6.TabIndex = 18;
            label6.Text = "Description";
            // 
            // txtDescription
            // 
            txtDescription.AccessibleName = "Description";
            txtDescription.Location = new Point(22, 364);
            txtDescription.Margin = new Padding(6, 3, 3, 8);
            txtDescription.MaxLength = 100;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(319, 23);
            txtDescription.TabIndex = 19;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(19, 395);
            label7.Margin = new Padding(3, 0, 3, 4);
            label7.Name = "label7";
            label7.Size = new Size(322, 16);
            label7.TabIndex = 20;
            label7.Text = "Status";
            // 
            // cmbStatus
            // 
            cmbStatus.AccessibleName = "Status";
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Position", "Civil Status", "Department", "Location", "Employment Status" });
            cmbStatus.Location = new Point(22, 418);
            cmbStatus.Margin = new Padding(6, 3, 3, 8);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(319, 24);
            cmbStatus.TabIndex = 21;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(19, 178);
            label8.Margin = new Padding(3, 0, 3, 4);
            label8.Name = "label8";
            label8.Size = new Size(322, 16);
            label8.TabIndex = 22;
            label8.Text = "Department";
            // 
            // cmbDepartment
            // 
            cmbDepartment.AccessibleName = "Department";
            cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.Items.AddRange(new object[] { "Position", "Civil Status", "Department", "Location", "Employment Status" });
            cmbDepartment.Location = new Point(22, 201);
            cmbDepartment.Margin = new Padding(6, 3, 3, 8);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(319, 24);
            cmbDepartment.TabIndex = 23;
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
            pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            pnlContainerSearch.ResumeLayout(false);
            pnlContainerSearch.PerformLayout();
            pnlRight.ResumeLayout(false);
            pnlRightBody.ResumeLayout(false);
            flowRightContent.ResumeLayout(false);
            flowRightContent.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlBody;
        private Panel pnlRight;
        private Panel pnlFooter;
        private Panel pnlContainerSearch;
        private ComboBox cmbCategories;
        private Label label1;
        private DataGridView dgvUsers;
        private Panel panel1;
        private Panel pnlVLine1;
        private Panel pnlRightFooter;
        private Panel pnlRightBody;
        private Panel pnlRightHeader;
        private FlowLayoutPanel flowRightContent;
        private Label label10;
        private TextBox txtID;
        private Label label2;
        private TextBox txtCode;
        private Label label3;
        private TextBox txtName;
        private Label label4;
        private TextBox txtSalaryRate;
        private Label label5;
        private TextBox txtBillingRate;
        private Label label6;
        private TextBox txtDescription;
        private Label label7;
        private ComboBox cmbStatus;
        private Label label8;
        private ComboBox cmbDepartment;
    }
}
