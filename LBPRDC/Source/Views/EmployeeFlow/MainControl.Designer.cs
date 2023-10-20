namespace LBPRDC.Source.Views
{
    partial class ucEmployees
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
            flowControls = new FlowLayoutPanel();
            btnAddBatch = new Button();
            btnAddEmployee = new Button();
            btnEditEmployee = new Button();
            panel1 = new Panel();
            pnlFilterContainer = new Panel();
            pnlFilterContent = new Panel();
            flowFilters = new FlowLayoutPanel();
            lblFilterDepartments = new Label();
            dchkListFilterDepartments = new Shared.DynamicCheckedListBoxControl();
            lblFilterLocations = new Label();
            dchkListFilterLocations = new Shared.DynamicCheckedListBoxControl();
            lblFilterPositions = new Label();
            dchkListFilterPositions = new Shared.DynamicCheckedListBoxControl();
            lblFilterCivilStatus = new Label();
            dchkListFilterCivilStatus = new Shared.DynamicCheckedListBoxControl();
            lblFilterGender = new Label();
            dchkListFilterGender = new Shared.DynamicCheckedListBoxControl();
            lblFilterEmploymentStatus = new Label();
            dchkListFilterEmploymentStatus = new Shared.DynamicCheckedListBoxControl();
            pnlLine1 = new Panel();
            flowFilterControls = new FlowLayoutPanel();
            btnFilter = new Button();
            btnReset = new Button();
            dgvEmployees = new DataGridView();
            grpHeader = new GroupBox();
            btnSettings = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            flowControls.SuspendLayout();
            panel1.SuspendLayout();
            pnlFilterContainer.SuspendLayout();
            pnlFilterContent.SuspendLayout();
            flowFilters.SuspendLayout();
            flowFilterControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            grpHeader.SuspendLayout();
            SuspendLayout();
            // 
            // flowControls
            // 
            flowControls.BackColor = SystemColors.Menu;
            flowControls.Controls.Add(btnAddBatch);
            flowControls.Controls.Add(btnAddEmployee);
            flowControls.Controls.Add(btnEditEmployee);
            flowControls.Dock = DockStyle.Bottom;
            flowControls.FlowDirection = FlowDirection.RightToLeft;
            flowControls.Location = new Point(0, 569);
            flowControls.Name = "flowControls";
            flowControls.Padding = new Padding(16, 16, 0, 16);
            flowControls.Size = new Size(1213, 60);
            flowControls.TabIndex = 1;
            // 
            // btnAddBatch
            // 
            btnAddBatch.AutoSize = true;
            btnAddBatch.Location = new Point(1097, 16);
            btnAddBatch.Margin = new Padding(0);
            btnAddBatch.Name = "btnAddBatch";
            btnAddBatch.Size = new Size(100, 28);
            btnAddBatch.TabIndex = 5;
            btnAddBatch.Text = "Add Batch";
            btnAddBatch.UseVisualStyleBackColor = true;
            btnAddBatch.Click += btnAddBatch_Click;
            // 
            // btnAddEmployee
            // 
            btnAddEmployee.AutoSize = true;
            btnAddEmployee.Location = new Point(997, 16);
            btnAddEmployee.Margin = new Padding(0);
            btnAddEmployee.Name = "btnAddEmployee";
            btnAddEmployee.Size = new Size(100, 28);
            btnAddEmployee.TabIndex = 6;
            btnAddEmployee.Text = "Add";
            btnAddEmployee.UseVisualStyleBackColor = true;
            btnAddEmployee.Click += btnAddEmployee_Click;
            // 
            // btnEditEmployee
            // 
            btnEditEmployee.AutoSize = true;
            btnEditEmployee.Location = new Point(897, 16);
            btnEditEmployee.Margin = new Padding(0);
            btnEditEmployee.Name = "btnEditEmployee";
            btnEditEmployee.Size = new Size(100, 28);
            btnEditEmployee.TabIndex = 7;
            btnEditEmployee.Text = "Edit";
            btnEditEmployee.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(pnlFilterContainer);
            panel1.Controls.Add(dgvEmployees);
            panel1.Controls.Add(grpHeader);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(16, 10, 16, 16);
            panel1.Size = new Size(1213, 569);
            panel1.TabIndex = 2;
            // 
            // pnlFilterContainer
            // 
            pnlFilterContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlFilterContainer.BorderStyle = BorderStyle.FixedSingle;
            pnlFilterContainer.Controls.Add(pnlFilterContent);
            pnlFilterContainer.Controls.Add(pnlLine1);
            pnlFilterContainer.Controls.Add(flowFilterControls);
            pnlFilterContainer.Location = new Point(16, 93);
            pnlFilterContainer.Margin = new Padding(0, 0, 16, 0);
            pnlFilterContainer.Name = "pnlFilterContainer";
            pnlFilterContainer.Size = new Size(215, 460);
            pnlFilterContainer.TabIndex = 5;
            // 
            // pnlFilterContent
            // 
            pnlFilterContent.AutoScroll = true;
            pnlFilterContent.Controls.Add(flowFilters);
            pnlFilterContent.Dock = DockStyle.Fill;
            pnlFilterContent.Location = new Point(0, 0);
            pnlFilterContent.Margin = new Padding(0);
            pnlFilterContent.Name = "pnlFilterContent";
            pnlFilterContent.Size = new Size(213, 417);
            pnlFilterContent.TabIndex = 6;
            // 
            // flowFilters
            // 
            flowFilters.AutoSize = true;
            flowFilters.Controls.Add(lblFilterDepartments);
            flowFilters.Controls.Add(dchkListFilterDepartments);
            flowFilters.Controls.Add(lblFilterLocations);
            flowFilters.Controls.Add(dchkListFilterLocations);
            flowFilters.Controls.Add(lblFilterPositions);
            flowFilters.Controls.Add(dchkListFilterPositions);
            flowFilters.Controls.Add(lblFilterCivilStatus);
            flowFilters.Controls.Add(dchkListFilterCivilStatus);
            flowFilters.Controls.Add(lblFilterGender);
            flowFilters.Controls.Add(dchkListFilterGender);
            flowFilters.Controls.Add(lblFilterEmploymentStatus);
            flowFilters.Controls.Add(dchkListFilterEmploymentStatus);
            flowFilters.FlowDirection = FlowDirection.TopDown;
            flowFilters.Location = new Point(0, 0);
            flowFilters.Name = "flowFilters";
            flowFilters.Padding = new Padding(4, 4, 0, 0);
            flowFilters.Size = new Size(191, 352);
            flowFilters.TabIndex = 6;
            // 
            // lblFilterDepartments
            // 
            lblFilterDepartments.AutoSize = true;
            lblFilterDepartments.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblFilterDepartments.Location = new Point(8, 12);
            lblFilterDepartments.Margin = new Padding(4, 8, 0, 8);
            lblFilterDepartments.Name = "lblFilterDepartments";
            lblFilterDepartments.Size = new Size(88, 16);
            lblFilterDepartments.TabIndex = 6;
            lblFilterDepartments.Text = "Departments";
            // 
            // dchkListFilterDepartments
            // 
            dchkListFilterDepartments.AutoSize = true;
            dchkListFilterDepartments.BackColor = Color.White;
            dchkListFilterDepartments.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dchkListFilterDepartments.Location = new Point(11, 36);
            dchkListFilterDepartments.Margin = new Padding(7, 0, 0, 8);
            dchkListFilterDepartments.Name = "dchkListFilterDepartments";
            dchkListFilterDepartments.Size = new Size(180, 0);
            dchkListFilterDepartments.TabIndex = 6;
            // 
            // lblFilterLocations
            // 
            lblFilterLocations.AutoSize = true;
            lblFilterLocations.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblFilterLocations.Location = new Point(8, 52);
            lblFilterLocations.Margin = new Padding(4, 8, 0, 8);
            lblFilterLocations.Name = "lblFilterLocations";
            lblFilterLocations.Size = new Size(68, 16);
            lblFilterLocations.TabIndex = 7;
            lblFilterLocations.Text = "Locations";
            lblFilterLocations.Visible = false;
            // 
            // dchkListFilterLocations
            // 
            dchkListFilterLocations.AutoSize = true;
            dchkListFilterLocations.BackColor = Color.White;
            dchkListFilterLocations.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dchkListFilterLocations.Location = new Point(11, 76);
            dchkListFilterLocations.Margin = new Padding(7, 0, 0, 8);
            dchkListFilterLocations.Name = "dchkListFilterLocations";
            dchkListFilterLocations.Size = new Size(180, 0);
            dchkListFilterLocations.TabIndex = 8;
            dchkListFilterLocations.Visible = false;
            // 
            // lblFilterPositions
            // 
            lblFilterPositions.AutoSize = true;
            lblFilterPositions.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblFilterPositions.Location = new Point(8, 92);
            lblFilterPositions.Margin = new Padding(4, 8, 0, 8);
            lblFilterPositions.Name = "lblFilterPositions";
            lblFilterPositions.Size = new Size(64, 16);
            lblFilterPositions.TabIndex = 9;
            lblFilterPositions.Text = "Positions";
            // 
            // dchkListFilterPositions
            // 
            dchkListFilterPositions.AutoSize = true;
            dchkListFilterPositions.BackColor = Color.White;
            dchkListFilterPositions.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dchkListFilterPositions.Location = new Point(11, 116);
            dchkListFilterPositions.Margin = new Padding(7, 0, 0, 8);
            dchkListFilterPositions.Name = "dchkListFilterPositions";
            dchkListFilterPositions.Size = new Size(180, 0);
            dchkListFilterPositions.TabIndex = 10;
            // 
            // lblFilterCivilStatus
            // 
            lblFilterCivilStatus.AutoSize = true;
            lblFilterCivilStatus.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblFilterCivilStatus.Location = new Point(8, 132);
            lblFilterCivilStatus.Margin = new Padding(4, 8, 0, 8);
            lblFilterCivilStatus.Name = "lblFilterCivilStatus";
            lblFilterCivilStatus.Size = new Size(77, 16);
            lblFilterCivilStatus.TabIndex = 11;
            lblFilterCivilStatus.Text = "Civil Status";
            lblFilterCivilStatus.Visible = false;
            // 
            // dchkListFilterCivilStatus
            // 
            dchkListFilterCivilStatus.AutoSize = true;
            dchkListFilterCivilStatus.BackColor = Color.White;
            dchkListFilterCivilStatus.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dchkListFilterCivilStatus.Location = new Point(11, 156);
            dchkListFilterCivilStatus.Margin = new Padding(7, 0, 0, 8);
            dchkListFilterCivilStatus.Name = "dchkListFilterCivilStatus";
            dchkListFilterCivilStatus.Size = new Size(180, 0);
            dchkListFilterCivilStatus.TabIndex = 12;
            dchkListFilterCivilStatus.Visible = false;
            // 
            // lblFilterGender
            // 
            lblFilterGender.AutoSize = true;
            lblFilterGender.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblFilterGender.Location = new Point(8, 172);
            lblFilterGender.Margin = new Padding(4, 8, 0, 8);
            lblFilterGender.Name = "lblFilterGender";
            lblFilterGender.Size = new Size(55, 16);
            lblFilterGender.TabIndex = 13;
            lblFilterGender.Text = "Gender";
            lblFilterGender.Visible = false;
            // 
            // dchkListFilterGender
            // 
            dchkListFilterGender.AutoSize = true;
            dchkListFilterGender.BackColor = Color.White;
            dchkListFilterGender.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dchkListFilterGender.Location = new Point(11, 196);
            dchkListFilterGender.Margin = new Padding(7, 0, 0, 8);
            dchkListFilterGender.Name = "dchkListFilterGender";
            dchkListFilterGender.Size = new Size(180, 0);
            dchkListFilterGender.TabIndex = 14;
            dchkListFilterGender.Visible = false;
            // 
            // lblFilterEmploymentStatus
            // 
            lblFilterEmploymentStatus.AutoSize = true;
            lblFilterEmploymentStatus.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblFilterEmploymentStatus.Location = new Point(8, 212);
            lblFilterEmploymentStatus.Margin = new Padding(4, 8, 0, 8);
            lblFilterEmploymentStatus.Name = "lblFilterEmploymentStatus";
            lblFilterEmploymentStatus.Size = new Size(128, 16);
            lblFilterEmploymentStatus.TabIndex = 15;
            lblFilterEmploymentStatus.Text = "Employment Status";
            // 
            // dchkListFilterEmploymentStatus
            // 
            dchkListFilterEmploymentStatus.AutoSize = true;
            dchkListFilterEmploymentStatus.BackColor = Color.White;
            dchkListFilterEmploymentStatus.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dchkListFilterEmploymentStatus.Location = new Point(11, 236);
            dchkListFilterEmploymentStatus.Margin = new Padding(7, 0, 0, 8);
            dchkListFilterEmploymentStatus.Name = "dchkListFilterEmploymentStatus";
            dchkListFilterEmploymentStatus.Size = new Size(180, 0);
            dchkListFilterEmploymentStatus.TabIndex = 16;
            // 
            // pnlLine1
            // 
            pnlLine1.BorderStyle = BorderStyle.FixedSingle;
            pnlLine1.Dock = DockStyle.Bottom;
            pnlLine1.Location = new Point(0, 417);
            pnlLine1.Name = "pnlLine1";
            pnlLine1.Size = new Size(213, 1);
            pnlLine1.TabIndex = 7;
            // 
            // flowFilterControls
            // 
            flowFilterControls.BackColor = Color.White;
            flowFilterControls.Controls.Add(btnFilter);
            flowFilterControls.Controls.Add(btnReset);
            flowFilterControls.Dock = DockStyle.Bottom;
            flowFilterControls.FlowDirection = FlowDirection.RightToLeft;
            flowFilterControls.Location = new Point(0, 418);
            flowFilterControls.Name = "flowFilterControls";
            flowFilterControls.Padding = new Padding(8, 6, 0, 0);
            flowFilterControls.Size = new Size(213, 40);
            flowFilterControls.TabIndex = 6;
            // 
            // btnFilter
            // 
            btnFilter.AutoSize = true;
            btnFilter.Location = new Point(125, 6);
            btnFilter.Margin = new Padding(4, 0, 0, 0);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(80, 28);
            btnFilter.TabIndex = 6;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // btnReset
            // 
            btnReset.AutoSize = true;
            btnReset.Location = new Point(41, 6);
            btnReset.Margin = new Padding(0);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(80, 28);
            btnReset.TabIndex = 7;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // dgvEmployees
            // 
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.AllowUserToDeleteRows = false;
            dgvEmployees.AllowUserToOrderColumns = true;
            dgvEmployees.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.Honeydew;
            dataGridViewCellStyle1.SelectionBackColor = Color.SeaGreen;
            dgvEmployees.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvEmployees.BackgroundColor = SystemColors.Window;
            dgvEmployees.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new Padding(0, 2, 0, 2);
            dataGridViewCellStyle2.SelectionBackColor = Color.MediumSeaGreen;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvEmployees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.EditMode = DataGridViewEditMode.EditOnF2;
            dgvEmployees.GridColor = SystemColors.Window;
            dgvEmployees.Location = new Point(247, 93);
            dgvEmployees.Margin = new Padding(0);
            dgvEmployees.MultiSelect = false;
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new Padding(4);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvEmployees.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvEmployees.RowHeadersVisible = false;
            dgvEmployees.RowTemplate.DefaultCellStyle.Padding = new Padding(4);
            dgvEmployees.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgvEmployees.RowTemplate.Height = 37;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.Size = new Size(950, 460);
            dgvEmployees.TabIndex = 3;
            // 
            // grpHeader
            // 
            grpHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpHeader.Controls.Add(btnSettings);
            grpHeader.Controls.Add(btnSearch);
            grpHeader.Controls.Add(txtSearch);
            grpHeader.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            grpHeader.Location = new Point(16, 10);
            grpHeader.Margin = new Padding(0, 0, 0, 16);
            grpHeader.Name = "grpHeader";
            grpHeader.Padding = new Padding(8);
            grpHeader.Size = new Size(1181, 67);
            grpHeader.TabIndex = 1;
            grpHeader.TabStop = false;
            grpHeader.Text = "Tools";
            // 
            // btnSettings
            // 
            btnSettings.Anchor = AnchorStyles.Right;
            btnSettings.AutoSize = true;
            btnSettings.Location = new Point(1098, 24);
            btnSettings.Margin = new Padding(0);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(75, 26);
            btnSettings.TabIndex = 5;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnSearch
            // 
            btnSearch.AutoSize = true;
            btnSearch.Location = new Point(216, 24);
            btnSearch.Margin = new Padding(0);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 26);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(8, 24);
            txtSearch.Margin = new Padding(0, 0, 4, 0);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(201, 26);
            txtSearch.TabIndex = 0;
            // 
            // ucEmployees
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Window;
            Controls.Add(panel1);
            Controls.Add(flowControls);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MinimumSize = new Size(733, 509);
            Name = "ucEmployees";
            Size = new Size(1213, 629);
            VisibleChanged += ucEmployees_VisibleChanged;
            flowControls.ResumeLayout(false);
            flowControls.PerformLayout();
            panel1.ResumeLayout(false);
            pnlFilterContainer.ResumeLayout(false);
            pnlFilterContent.ResumeLayout(false);
            pnlFilterContent.PerformLayout();
            flowFilters.ResumeLayout(false);
            flowFilters.PerformLayout();
            flowFilterControls.ResumeLayout(false);
            flowFilterControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            grpHeader.ResumeLayout(false);
            grpHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel flowControls;
        private Panel panel1;
        private GroupBox grpHeader;
        private DataGridView dgvEmployees;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnAddBatch;
        private Button btnAddEmployee;
        private Button btnSettings;
        private Button btnEditEmployee;
        private Shared.DynamicCheckedListBoxControl dchkListFilterDepartments;
        private Label lblFilterDepartments;
        private FlowLayoutPanel flowFilters;
        private Label lblFilterLocations;
        private Shared.DynamicCheckedListBoxControl dchkListFilterLocations;
        private Label lblFilterPositions;
        private Shared.DynamicCheckedListBoxControl dchkListFilterPositions;
        private Label lblFilterCivilStatus;
        private Shared.DynamicCheckedListBoxControl dchkListFilterCivilStatus;
        private Label lblFilterGender;
        private Shared.DynamicCheckedListBoxControl dchkListFilterGender;
        private Label lblFilterEmploymentStatus;
        private Shared.DynamicCheckedListBoxControl dchkListFilterEmploymentStatus;
        private Panel pnlFilterContent;
        private FlowLayoutPanel flowFilterControls;
        private Button btnFilter;
        private Button btnReset;
        private Panel pnlFilterContainer;
        private Panel pnlLine1;
    }
}
