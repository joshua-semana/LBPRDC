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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucEmployees));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            flowControls = new FlowLayoutPanel();
            btnAddBatch = new Button();
            btnAddEmployee = new Button();
            pnlContainerHeader = new Panel();
            panel2 = new Panel();
            lblRowCounter = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnSettings = new Button();
            pnlContainerSearch = new Panel();
            label1 = new Label();
            txtSearch = new TextBox();
            pnlContainerFilter = new Panel();
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
            cntxtEmployeeActions = new ContextMenuStrip(components);
            cntxtMenuView = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            cntxtMenuEdit = new ToolStripMenuItem();
            cntxtMenuUpdate = new ToolStripMenuItem();
            menuUpdatePosition = new ToolStripMenuItem();
            menuUpdateCivilStatus = new ToolStripMenuItem();
            menuUpdateEmploymentStatus = new ToolStripMenuItem();
            menuUpdateDepartmentLocation = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            cntxtMenuHistory = new ToolStripMenuItem();
            menuHistoryPosition = new ToolStripMenuItem();
            menuHistoryCivilStatus = new ToolStripMenuItem();
            menuHistoryEmploymentStatus = new ToolStripMenuItem();
            menuHistoryDepartmentLocation = new ToolStripMenuItem();
            flowControls.SuspendLayout();
            pnlContainerHeader.SuspendLayout();
            panel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            pnlContainerSearch.SuspendLayout();
            pnlContainerFilter.SuspendLayout();
            pnlFilterContent.SuspendLayout();
            flowFilters.SuspendLayout();
            flowFilterControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            cntxtEmployeeActions.SuspendLayout();
            SuspendLayout();
            // 
            // flowControls
            // 
            flowControls.BackColor = SystemColors.Menu;
            flowControls.Controls.Add(btnAddBatch);
            flowControls.Controls.Add(btnAddEmployee);
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
            btnAddBatch.Visible = false;
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
            // pnlContainerHeader
            // 
            pnlContainerHeader.Controls.Add(panel2);
            pnlContainerHeader.Controls.Add(pnlContainerSearch);
            pnlContainerHeader.Controls.Add(pnlContainerFilter);
            pnlContainerHeader.Controls.Add(dgvEmployees);
            pnlContainerHeader.Dock = DockStyle.Fill;
            pnlContainerHeader.Location = new Point(0, 0);
            pnlContainerHeader.Name = "pnlContainerHeader";
            pnlContainerHeader.Padding = new Padding(16);
            pnlContainerHeader.Size = new Size(1213, 569);
            pnlContainerHeader.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(lblRowCounter);
            panel2.Controls.Add(flowLayoutPanel1);
            panel2.Location = new Point(247, 16);
            panel2.Margin = new Padding(0, 0, 0, 16);
            panel2.Name = "panel2";
            panel2.Size = new Size(950, 35);
            panel2.TabIndex = 7;
            // 
            // lblRowCounter
            // 
            lblRowCounter.AutoSize = true;
            lblRowCounter.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblRowCounter.ForeColor = SystemColors.ControlDarkDark;
            lblRowCounter.Location = new Point(4, 8);
            lblRowCounter.Margin = new Padding(0);
            lblRowCounter.Name = "lblRowCounter";
            lblRowCounter.Size = new Size(108, 16);
            lblRowCounter.TabIndex = 1;
            lblRowCounter.Text = "Employee count";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnSettings);
            flowLayoutPanel1.Dock = DockStyle.Right;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(685, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(263, 33);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // btnSettings
            // 
            btnSettings.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSettings.Cursor = Cursors.Hand;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Image = (Image)resources.GetObject("btnSettings.Image");
            btnSettings.Location = new Point(230, 0);
            btnSettings.Margin = new Padding(0);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(33, 33);
            btnSettings.TabIndex = 9;
            btnSettings.Tag = "Home";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // pnlContainerSearch
            // 
            pnlContainerSearch.BorderStyle = BorderStyle.FixedSingle;
            pnlContainerSearch.Controls.Add(label1);
            pnlContainerSearch.Controls.Add(txtSearch);
            pnlContainerSearch.Location = new Point(16, 16);
            pnlContainerSearch.Margin = new Padding(0, 0, 0, 16);
            pnlContainerSearch.Name = "pnlContainerSearch";
            pnlContainerSearch.Padding = new Padding(8);
            pnlContainerSearch.Size = new Size(215, 68);
            pnlContainerSearch.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.WindowText;
            label1.Location = new Point(5, 8);
            label1.Margin = new Padding(0, 0, 0, 6);
            label1.Name = "label1";
            label1.Size = new Size(116, 16);
            label1.TabIndex = 7;
            label1.Text = "Search and Filter";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(8, 30);
            txtSearch.Margin = new Padding(0, 0, 0, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(197, 26);
            txtSearch.TabIndex = 1;
            txtSearch.KeyUp += txtSearch_KeyUp;
            // 
            // pnlContainerFilter
            // 
            pnlContainerFilter.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlContainerFilter.BorderStyle = BorderStyle.FixedSingle;
            pnlContainerFilter.Controls.Add(pnlFilterContent);
            pnlContainerFilter.Controls.Add(pnlLine1);
            pnlContainerFilter.Controls.Add(flowFilterControls);
            pnlContainerFilter.Location = new Point(16, 100);
            pnlContainerFilter.Margin = new Padding(0, 0, 16, 0);
            pnlContainerFilter.Name = "pnlContainerFilter";
            pnlContainerFilter.Size = new Size(215, 453);
            pnlContainerFilter.TabIndex = 5;
            // 
            // pnlFilterContent
            // 
            pnlFilterContent.AutoScroll = true;
            pnlFilterContent.Controls.Add(flowFilters);
            pnlFilterContent.Dock = DockStyle.Fill;
            pnlFilterContent.Location = new Point(0, 0);
            pnlFilterContent.Margin = new Padding(0);
            pnlFilterContent.Name = "pnlFilterContent";
            pnlFilterContent.Size = new Size(213, 410);
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
            flowFilters.Padding = new Padding(4, 0, 0, 0);
            flowFilters.Size = new Size(196, 306);
            flowFilters.TabIndex = 6;
            // 
            // lblFilterDepartments
            // 
            lblFilterDepartments.AutoSize = true;
            lblFilterDepartments.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblFilterDepartments.ForeColor = SystemColors.ControlDarkDark;
            lblFilterDepartments.Location = new Point(5, 8);
            lblFilterDepartments.Margin = new Padding(1, 8, 0, 6);
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
            dchkListFilterDepartments.Location = new Point(16, 30);
            dchkListFilterDepartments.Margin = new Padding(12, 0, 0, 2);
            dchkListFilterDepartments.Name = "dchkListFilterDepartments";
            dchkListFilterDepartments.Size = new Size(180, 0);
            dchkListFilterDepartments.TabIndex = 6;
            // 
            // lblFilterLocations
            // 
            lblFilterLocations.AutoSize = true;
            lblFilterLocations.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblFilterLocations.ForeColor = SystemColors.ControlDarkDark;
            lblFilterLocations.Location = new Point(5, 40);
            lblFilterLocations.Margin = new Padding(1, 8, 0, 6);
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
            dchkListFilterLocations.Location = new Point(16, 62);
            dchkListFilterLocations.Margin = new Padding(12, 0, 0, 2);
            dchkListFilterLocations.Name = "dchkListFilterLocations";
            dchkListFilterLocations.Size = new Size(180, 0);
            dchkListFilterLocations.TabIndex = 8;
            dchkListFilterLocations.Visible = false;
            // 
            // lblFilterPositions
            // 
            lblFilterPositions.AutoSize = true;
            lblFilterPositions.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblFilterPositions.ForeColor = SystemColors.ControlDarkDark;
            lblFilterPositions.Location = new Point(5, 72);
            lblFilterPositions.Margin = new Padding(1, 8, 0, 6);
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
            dchkListFilterPositions.Location = new Point(16, 94);
            dchkListFilterPositions.Margin = new Padding(12, 0, 0, 2);
            dchkListFilterPositions.Name = "dchkListFilterPositions";
            dchkListFilterPositions.Size = new Size(180, 0);
            dchkListFilterPositions.TabIndex = 10;
            // 
            // lblFilterCivilStatus
            // 
            lblFilterCivilStatus.AutoSize = true;
            lblFilterCivilStatus.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblFilterCivilStatus.ForeColor = SystemColors.ControlDarkDark;
            lblFilterCivilStatus.Location = new Point(5, 104);
            lblFilterCivilStatus.Margin = new Padding(1, 8, 0, 6);
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
            dchkListFilterCivilStatus.Location = new Point(16, 126);
            dchkListFilterCivilStatus.Margin = new Padding(12, 0, 0, 2);
            dchkListFilterCivilStatus.Name = "dchkListFilterCivilStatus";
            dchkListFilterCivilStatus.Size = new Size(180, 0);
            dchkListFilterCivilStatus.TabIndex = 12;
            dchkListFilterCivilStatus.Visible = false;
            // 
            // lblFilterGender
            // 
            lblFilterGender.AutoSize = true;
            lblFilterGender.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblFilterGender.ForeColor = SystemColors.ControlDarkDark;
            lblFilterGender.Location = new Point(5, 136);
            lblFilterGender.Margin = new Padding(1, 8, 0, 6);
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
            dchkListFilterGender.Location = new Point(16, 158);
            dchkListFilterGender.Margin = new Padding(12, 0, 0, 2);
            dchkListFilterGender.Name = "dchkListFilterGender";
            dchkListFilterGender.Size = new Size(180, 0);
            dchkListFilterGender.TabIndex = 14;
            dchkListFilterGender.Visible = false;
            // 
            // lblFilterEmploymentStatus
            // 
            lblFilterEmploymentStatus.AutoSize = true;
            lblFilterEmploymentStatus.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblFilterEmploymentStatus.ForeColor = SystemColors.ControlDarkDark;
            lblFilterEmploymentStatus.Location = new Point(5, 168);
            lblFilterEmploymentStatus.Margin = new Padding(1, 8, 0, 6);
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
            dchkListFilterEmploymentStatus.Location = new Point(16, 190);
            dchkListFilterEmploymentStatus.Margin = new Padding(12, 0, 0, 8);
            dchkListFilterEmploymentStatus.Name = "dchkListFilterEmploymentStatus";
            dchkListFilterEmploymentStatus.Size = new Size(180, 0);
            dchkListFilterEmploymentStatus.TabIndex = 16;
            // 
            // pnlLine1
            // 
            pnlLine1.BorderStyle = BorderStyle.FixedSingle;
            pnlLine1.Dock = DockStyle.Bottom;
            pnlLine1.Location = new Point(0, 410);
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
            flowFilterControls.Location = new Point(0, 411);
            flowFilterControls.Name = "flowFilterControls";
            flowFilterControls.Padding = new Padding(8, 6, 0, 0);
            flowFilterControls.Size = new Size(213, 40);
            flowFilterControls.TabIndex = 6;
            // 
            // btnFilter
            // 
            btnFilter.AutoSize = true;
            btnFilter.Location = new Point(135, 6);
            btnFilter.Margin = new Padding(4, 0, 0, 0);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(70, 28);
            btnFilter.TabIndex = 6;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // btnReset
            // 
            btnReset.AutoSize = true;
            btnReset.Location = new Point(61, 6);
            btnReset.Margin = new Padding(0);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(70, 28);
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
            dataGridViewCellStyle1.SelectionBackColor = Color.SeaGreen;
            dgvEmployees.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvEmployees.BackgroundColor = SystemColors.Window;
            dgvEmployees.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
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
            dgvEmployees.GridColor = SystemColors.Control;
            dgvEmployees.Location = new Point(247, 67);
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
            dgvEmployees.RowTemplate.DefaultCellStyle.Padding = new Padding(4, 8, 4, 8);
            dgvEmployees.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgvEmployees.RowTemplate.Height = 41;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.Size = new Size(950, 486);
            dgvEmployees.TabIndex = 3;
            dgvEmployees.VirtualMode = true;
            dgvEmployees.CellMouseClick += dgvEmployees_CellMouseClick;
            // 
            // cntxtEmployeeActions
            // 
            cntxtEmployeeActions.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            cntxtEmployeeActions.Items.AddRange(new ToolStripItem[] { cntxtMenuView, toolStripSeparator1, cntxtMenuEdit, cntxtMenuUpdate, toolStripSeparator2, cntxtMenuHistory });
            cntxtEmployeeActions.Name = "cntxtEmployeeActions";
            cntxtEmployeeActions.Size = new Size(143, 104);
            // 
            // cntxtMenuView
            // 
            cntxtMenuView.DisplayStyle = ToolStripItemDisplayStyle.Text;
            cntxtMenuView.Name = "cntxtMenuView";
            cntxtMenuView.Size = new Size(142, 22);
            cntxtMenuView.Text = "View Details";
            cntxtMenuView.Click += cntxtMenuView_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(139, 6);
            // 
            // cntxtMenuEdit
            // 
            cntxtMenuEdit.Name = "cntxtMenuEdit";
            cntxtMenuEdit.Size = new Size(142, 22);
            cntxtMenuEdit.Text = "Edit";
            cntxtMenuEdit.Click += cntxtMenuEdit_Click;
            // 
            // cntxtMenuUpdate
            // 
            cntxtMenuUpdate.DropDownItems.AddRange(new ToolStripItem[] { menuUpdatePosition, menuUpdateCivilStatus, menuUpdateEmploymentStatus, menuUpdateDepartmentLocation });
            cntxtMenuUpdate.Name = "cntxtMenuUpdate";
            cntxtMenuUpdate.Size = new Size(142, 22);
            cntxtMenuUpdate.Text = "Update";
            // 
            // menuUpdatePosition
            // 
            menuUpdatePosition.Name = "menuUpdatePosition";
            menuUpdatePosition.Size = new Size(213, 22);
            menuUpdatePosition.Text = "Position";
            menuUpdatePosition.Click += menuUpdatePosition_Click;
            // 
            // menuUpdateCivilStatus
            // 
            menuUpdateCivilStatus.Name = "menuUpdateCivilStatus";
            menuUpdateCivilStatus.Size = new Size(213, 22);
            menuUpdateCivilStatus.Text = "Civil Status";
            menuUpdateCivilStatus.Click += menuUpdateCivilStatus_Click;
            // 
            // menuUpdateEmploymentStatus
            // 
            menuUpdateEmploymentStatus.Name = "menuUpdateEmploymentStatus";
            menuUpdateEmploymentStatus.Size = new Size(213, 22);
            menuUpdateEmploymentStatus.Text = "Employment Status";
            menuUpdateEmploymentStatus.Click += menuUpdateEmploymentStatus_Click;
            // 
            // menuUpdateDepartmentLocation
            // 
            menuUpdateDepartmentLocation.Name = "menuUpdateDepartmentLocation";
            menuUpdateDepartmentLocation.Size = new Size(213, 22);
            menuUpdateDepartmentLocation.Text = "Department and Location";
            menuUpdateDepartmentLocation.Click += menuUpdateDepartmentLocation_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(139, 6);
            // 
            // cntxtMenuHistory
            // 
            cntxtMenuHistory.DropDownItems.AddRange(new ToolStripItem[] { menuHistoryPosition, menuHistoryCivilStatus, menuHistoryEmploymentStatus, menuHistoryDepartmentLocation });
            cntxtMenuHistory.Name = "cntxtMenuHistory";
            cntxtMenuHistory.Size = new Size(142, 22);
            cntxtMenuHistory.Text = "History";
            // 
            // menuHistoryPosition
            // 
            menuHistoryPosition.Name = "menuHistoryPosition";
            menuHistoryPosition.Size = new Size(213, 22);
            menuHistoryPosition.Text = "Position";
            menuHistoryPosition.Click += menuHistoryPosition_Click;
            // 
            // menuHistoryCivilStatus
            // 
            menuHistoryCivilStatus.Name = "menuHistoryCivilStatus";
            menuHistoryCivilStatus.Size = new Size(213, 22);
            menuHistoryCivilStatus.Text = "Civil Status";
            menuHistoryCivilStatus.Click += menuHistoryCivilStatus_Click;
            // 
            // menuHistoryEmploymentStatus
            // 
            menuHistoryEmploymentStatus.Name = "menuHistoryEmploymentStatus";
            menuHistoryEmploymentStatus.Size = new Size(213, 22);
            menuHistoryEmploymentStatus.Text = "Employment Status";
            menuHistoryEmploymentStatus.Click += menuHistoryEmploymentStatus_Click;
            // 
            // menuHistoryDepartmentLocation
            // 
            menuHistoryDepartmentLocation.Name = "menuHistoryDepartmentLocation";
            menuHistoryDepartmentLocation.Size = new Size(213, 22);
            menuHistoryDepartmentLocation.Text = "Department and Location";
            menuHistoryDepartmentLocation.Click += menuHistoryDepartmentLocation_Click;
            // 
            // ucEmployees
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Window;
            Controls.Add(pnlContainerHeader);
            Controls.Add(flowControls);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "ucEmployees";
            Size = new Size(1213, 629);
            VisibleChanged += ucEmployees_VisibleChanged;
            flowControls.ResumeLayout(false);
            flowControls.PerformLayout();
            pnlContainerHeader.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            pnlContainerSearch.ResumeLayout(false);
            pnlContainerSearch.PerformLayout();
            pnlContainerFilter.ResumeLayout(false);
            pnlFilterContent.ResumeLayout(false);
            pnlFilterContent.PerformLayout();
            flowFilters.ResumeLayout(false);
            flowFilters.PerformLayout();
            flowFilterControls.ResumeLayout(false);
            flowFilterControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            cntxtEmployeeActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel flowControls;
        private Panel pnlContainerHeader;
        private DataGridView dgvEmployees;
        private Button btnAddBatch;
        private Button btnAddEmployee;
        private Panel pnlContainerSearch;
        private TextBox txtSearch;
        private Label label1;
        private Panel panel2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnSettings;
        private Label lblRowCounter;
        private ContextMenuStrip cntxtEmployeeActions;
        private ToolStripMenuItem cntxtMenuEdit;
        private ToolStripMenuItem cntxtMenuUpdate;
        private ToolStripMenuItem menuUpdatePosition;
        private ToolStripMenuItem menuUpdateDepartmentLocation;
        private ToolStripMenuItem menuUpdateCivilStatus;
        private ToolStripMenuItem menuUpdateEmploymentStatus;
        private ToolStripMenuItem cntxtMenuHistory;
        private ToolStripMenuItem menuHistoryPosition;
        private ToolStripMenuItem menuHistoryCivilStatus;
        private ToolStripMenuItem menuHistoryEmploymentStatus;
        private ToolStripMenuItem menuHistoryDepartmentLocation;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem cntxtMenuView;
        private ToolStripSeparator toolStripSeparator2;
        private Panel pnlContainerFilter;
        private Panel pnlFilterContent;
        private FlowLayoutPanel flowFilters;
        private Label lblFilterDepartments;
        private Shared.DynamicCheckedListBoxControl dchkListFilterDepartments;
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
        private Panel pnlLine1;
        private FlowLayoutPanel flowFilterControls;
        private Button btnFilter;
        private Button btnReset;
    }
}
