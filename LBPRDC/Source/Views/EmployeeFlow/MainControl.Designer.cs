using LBPRDC.Source.Config;

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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            flowControls = new FlowLayoutPanel();
            btnAddBatch = new Button();
            btnAddEmployee = new Button();
            button1 = new Button();
            pnlContainerHeader = new Panel();
            lblClient = new Label();
            cmbClient = new ComboBox();
            btnReset = new Button();
            btnFilter = new Button();
            pnlFilterContainer = new Panel();
            flowFilters = new FlowLayoutPanel();
            lblFilterDepartments = new Label();
            dchkListFilterDepartments = new Shared.DynamicCheckedListBoxControl();
            lblFilterLocations = new Label();
            dchkListFilterLocations = new Shared.DynamicCheckedListBoxControl();
            lblFilterPositions = new Label();
            dchkListFilterPositions = new Shared.DynamicCheckedListBoxControl();
            lblFilterWageType = new Label();
            dchkListFilterWageType = new Shared.DynamicCheckedListBoxControl();
            lblFilterCivilStatus = new Label();
            dchkListFilterCivilStatus = new Shared.DynamicCheckedListBoxControl();
            lblFilterGender = new Label();
            dchkListFilterGender = new Shared.DynamicCheckedListBoxControl();
            lblFilterEmploymentStatus = new Label();
            dchkListFilterEmploymentStatus = new Shared.DynamicCheckedListBoxControl();
            pnlLine2 = new Panel();
            label1 = new Label();
            btnSearch = new Button();
            lblRowCounter = new Label();
            pnlLine1 = new Panel();
            flowButtonActions = new FlowLayoutPanel();
            btnSettings = new Button();
            txtSearch = new TextBox();
            dgvEmployees = new DataGridView();
            cntxtEmployeeActions = new ContextMenuStrip(components);
            cntxtMenuView = new ToolStripMenuItem();
            cntxtMenuViewBillings = new ToolStripMenuItem();
            cntxtMenuHistory = new ToolStripMenuItem();
            menuHistoryPosition = new ToolStripMenuItem();
            menuHistoryEmploymentStatus = new ToolStripMenuItem();
            menuHistoryDepartmentLocation = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            cntxtMenuEdit = new ToolStripMenuItem();
            cntxtMenuUpdate = new ToolStripMenuItem();
            menuUpdatePosition = new ToolStripMenuItem();
            menuUpdateEmploymentStatus = new ToolStripMenuItem();
            menuUpdateDepartmentLocation = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            cntxtMenuArchive = new ToolStripMenuItem();
            flowControls.SuspendLayout();
            pnlContainerHeader.SuspendLayout();
            pnlFilterContainer.SuspendLayout();
            flowFilters.SuspendLayout();
            flowButtonActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            cntxtEmployeeActions.SuspendLayout();
            SuspendLayout();
            // 
            // flowControls
            // 
            flowControls.BackColor = SystemColors.Menu;
            flowControls.Controls.Add(btnAddBatch);
            flowControls.Controls.Add(btnAddEmployee);
            flowControls.Controls.Add(button1);
            flowControls.Dock = DockStyle.Bottom;
            flowControls.FlowDirection = FlowDirection.RightToLeft;
            flowControls.Location = new Point(0, 569);
            flowControls.Name = "flowControls";
            flowControls.Padding = new Padding(23, 16, 0, 16);
            flowControls.Size = new Size(1213, 60);
            flowControls.TabIndex = 1;
            // 
            // btnAddBatch
            // 
            btnAddBatch.AutoSize = true;
            btnAddBatch.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddBatch.Location = new Point(1090, 16);
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
            btnAddEmployee.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddEmployee.Location = new Point(1015, 16);
            btnAddEmployee.Margin = new Padding(8, 0, 0, 0);
            btnAddEmployee.Name = "btnAddEmployee";
            btnAddEmployee.Size = new Size(75, 28);
            btnAddEmployee.TabIndex = 6;
            btnAddEmployee.Text = "Add";
            btnAddEmployee.UseVisualStyleBackColor = true;
            btnAddEmployee.Click += btnAddEmployee_Click;
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(896, 16);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(111, 28);
            button1.TabIndex = 7;
            button1.Text = "View all billings";
            button1.UseVisualStyleBackColor = true;
            // 
            // pnlContainerHeader
            // 
            pnlContainerHeader.Controls.Add(lblClient);
            pnlContainerHeader.Controls.Add(cmbClient);
            pnlContainerHeader.Controls.Add(btnReset);
            pnlContainerHeader.Controls.Add(btnFilter);
            pnlContainerHeader.Controls.Add(pnlFilterContainer);
            pnlContainerHeader.Controls.Add(pnlLine2);
            pnlContainerHeader.Controls.Add(label1);
            pnlContainerHeader.Controls.Add(btnSearch);
            pnlContainerHeader.Controls.Add(lblRowCounter);
            pnlContainerHeader.Controls.Add(pnlLine1);
            pnlContainerHeader.Controls.Add(flowButtonActions);
            pnlContainerHeader.Controls.Add(txtSearch);
            pnlContainerHeader.Controls.Add(dgvEmployees);
            pnlContainerHeader.Dock = DockStyle.Fill;
            pnlContainerHeader.Location = new Point(0, 0);
            pnlContainerHeader.Name = "pnlContainerHeader";
            pnlContainerHeader.Padding = new Padding(24, 24, 24, 10);
            pnlContainerHeader.Size = new Size(1213, 569);
            pnlContainerHeader.TabIndex = 2;
            // 
            // lblClient
            // 
            lblClient.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblClient.AutoSize = true;
            lblClient.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblClient.ForeColor = Color.Black;
            lblClient.Location = new Point(23, 83);
            lblClient.Margin = new Padding(3, 0, 3, 2);
            lblClient.Name = "lblClient";
            lblClient.Size = new Size(48, 16);
            lblClient.TabIndex = 26;
            lblClient.Text = "Client";
            // 
            // cmbClient
            // 
            cmbClient.AccessibleName = "Client";
            cmbClient.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClient.FormattingEnabled = true;
            cmbClient.Location = new Point(27, 104);
            cmbClient.Margin = new Padding(6, 3, 3, 12);
            cmbClient.Name = "cmbClient";
            cmbClient.Size = new Size(216, 26);
            cmbClient.TabIndex = 25;
            cmbClient.SelectedIndexChanged += cmbClient_SelectedIndexChanged;
            // 
            // btnReset
            // 
            btnReset.AutoSize = true;
            btnReset.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnReset.Location = new Point(137, 142);
            btnReset.Margin = new Padding(0);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(51, 25);
            btnReset.TabIndex = 7;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnFilter
            // 
            btnFilter.AutoSize = true;
            btnFilter.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnFilter.Location = new Point(192, 142);
            btnFilter.Margin = new Padding(4, 0, 0, 4);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(51, 25);
            btnFilter.TabIndex = 6;
            btnFilter.Text = "Apply";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // pnlFilterContainer
            // 
            pnlFilterContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlFilterContainer.AutoScroll = true;
            pnlFilterContainer.Controls.Add(flowFilters);
            pnlFilterContainer.Location = new Point(27, 172);
            pnlFilterContainer.Margin = new Padding(0);
            pnlFilterContainer.Name = "pnlFilterContainer";
            pnlFilterContainer.Size = new Size(215, 363);
            pnlFilterContainer.TabIndex = 6;
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
            flowFilters.Controls.Add(lblFilterWageType);
            flowFilters.Controls.Add(dchkListFilterWageType);
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
            flowFilters.Size = new Size(196, 360);
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
            dchkListFilterDepartments.Size = new Size(180, 18);
            dchkListFilterDepartments.TabIndex = 6;
            // 
            // lblFilterLocations
            // 
            lblFilterLocations.AutoSize = true;
            lblFilterLocations.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblFilterLocations.ForeColor = SystemColors.ControlDarkDark;
            lblFilterLocations.Location = new Point(5, 58);
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
            dchkListFilterLocations.Location = new Point(16, 80);
            dchkListFilterLocations.Margin = new Padding(12, 0, 0, 2);
            dchkListFilterLocations.Name = "dchkListFilterLocations";
            dchkListFilterLocations.Size = new Size(180, 18);
            dchkListFilterLocations.TabIndex = 8;
            dchkListFilterLocations.Visible = false;
            // 
            // lblFilterPositions
            // 
            lblFilterPositions.AutoSize = true;
            lblFilterPositions.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblFilterPositions.ForeColor = SystemColors.ControlDarkDark;
            lblFilterPositions.Location = new Point(5, 108);
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
            dchkListFilterPositions.Location = new Point(16, 130);
            dchkListFilterPositions.Margin = new Padding(12, 0, 0, 2);
            dchkListFilterPositions.Name = "dchkListFilterPositions";
            dchkListFilterPositions.Size = new Size(180, 18);
            dchkListFilterPositions.TabIndex = 10;
            // 
            // lblFilterWageType
            // 
            lblFilterWageType.AutoSize = true;
            lblFilterWageType.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblFilterWageType.ForeColor = SystemColors.ControlDarkDark;
            lblFilterWageType.Location = new Point(5, 158);
            lblFilterWageType.Margin = new Padding(1, 8, 0, 6);
            lblFilterWageType.Name = "lblFilterWageType";
            lblFilterWageType.Size = new Size(78, 16);
            lblFilterWageType.TabIndex = 17;
            lblFilterWageType.Text = "Wage Type";
            // 
            // dchkListFilterWageType
            // 
            dchkListFilterWageType.AutoSize = true;
            dchkListFilterWageType.BackColor = Color.White;
            dchkListFilterWageType.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dchkListFilterWageType.Location = new Point(16, 180);
            dchkListFilterWageType.Margin = new Padding(12, 0, 0, 2);
            dchkListFilterWageType.Name = "dchkListFilterWageType";
            dchkListFilterWageType.Size = new Size(180, 18);
            dchkListFilterWageType.TabIndex = 18;
            // 
            // lblFilterCivilStatus
            // 
            lblFilterCivilStatus.AutoSize = true;
            lblFilterCivilStatus.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblFilterCivilStatus.ForeColor = SystemColors.ControlDarkDark;
            lblFilterCivilStatus.Location = new Point(5, 208);
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
            dchkListFilterCivilStatus.Location = new Point(16, 230);
            dchkListFilterCivilStatus.Margin = new Padding(12, 0, 0, 2);
            dchkListFilterCivilStatus.Name = "dchkListFilterCivilStatus";
            dchkListFilterCivilStatus.Size = new Size(180, 18);
            dchkListFilterCivilStatus.TabIndex = 12;
            dchkListFilterCivilStatus.Visible = false;
            // 
            // lblFilterGender
            // 
            lblFilterGender.AutoSize = true;
            lblFilterGender.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblFilterGender.ForeColor = SystemColors.ControlDarkDark;
            lblFilterGender.Location = new Point(5, 258);
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
            dchkListFilterGender.Location = new Point(16, 280);
            dchkListFilterGender.Margin = new Padding(12, 0, 0, 2);
            dchkListFilterGender.Name = "dchkListFilterGender";
            dchkListFilterGender.Size = new Size(180, 18);
            dchkListFilterGender.TabIndex = 14;
            dchkListFilterGender.Visible = false;
            // 
            // lblFilterEmploymentStatus
            // 
            lblFilterEmploymentStatus.AutoSize = true;
            lblFilterEmploymentStatus.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblFilterEmploymentStatus.ForeColor = SystemColors.ControlDarkDark;
            lblFilterEmploymentStatus.Location = new Point(5, 308);
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
            dchkListFilterEmploymentStatus.Location = new Point(16, 330);
            dchkListFilterEmploymentStatus.Margin = new Padding(12, 0, 0, 8);
            dchkListFilterEmploymentStatus.Name = "dchkListFilterEmploymentStatus";
            dchkListFilterEmploymentStatus.Size = new Size(180, 18);
            dchkListFilterEmploymentStatus.TabIndex = 16;
            // 
            // pnlLine2
            // 
            pnlLine2.BorderStyle = BorderStyle.FixedSingle;
            pnlLine2.Location = new Point(27, 171);
            pnlLine2.Margin = new Padding(0);
            pnlLine2.Name = "pnlLine2";
            pnlLine2.Size = new Size(215, 1);
            pnlLine2.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(23, 146);
            label1.Margin = new Padding(0, 0, 0, 8);
            label1.Name = "label1";
            label1.Size = new Size(52, 16);
            label1.TabIndex = 14;
            label1.Text = "Filters";
            // 
            // btnSearch
            // 
            btnSearch.AutoSize = true;
            btnSearch.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearch.Location = new Point(247, 23);
            btnSearch.Margin = new Padding(4, 0, 8, 0);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 28);
            btnSearch.TabIndex = 13;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // lblRowCounter
            // 
            lblRowCounter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblRowCounter.AutoSize = true;
            lblRowCounter.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblRowCounter.ForeColor = SystemColors.GrayText;
            lblRowCounter.Location = new Point(251, 543);
            lblRowCounter.Margin = new Padding(0, 8, 0, 0);
            lblRowCounter.Name = "lblRowCounter";
            lblRowCounter.Size = new Size(45, 16);
            lblRowCounter.TabIndex = 1;
            lblRowCounter.Text = "Count";
            // 
            // pnlLine1
            // 
            pnlLine1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLine1.BorderStyle = BorderStyle.FixedSingle;
            pnlLine1.Location = new Point(24, 66);
            pnlLine1.Margin = new Padding(0, 0, 0, 16);
            pnlLine1.Name = "pnlLine1";
            pnlLine1.Size = new Size(1165, 1);
            pnlLine1.TabIndex = 7;
            // 
            // flowButtonActions
            // 
            flowButtonActions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flowButtonActions.Controls.Add(btnSettings);
            flowButtonActions.FlowDirection = FlowDirection.RightToLeft;
            flowButtonActions.Location = new Point(1143, 21);
            flowButtonActions.Name = "flowButtonActions";
            flowButtonActions.Size = new Size(46, 33);
            flowButtonActions.TabIndex = 0;
            // 
            // btnSettings
            // 
            btnSettings.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSettings.Cursor = Cursors.Hand;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Image = (Image)resources.GetObject("btnSettings.Image");
            btnSettings.Location = new Point(13, 0);
            btnSettings.Margin = new Padding(0);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(33, 33);
            btnSettings.TabIndex = 9;
            btnSettings.Tag = "Home";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(24, 24);
            txtSearch.Margin = new Padding(0, 0, 4, 16);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(215, 26);
            txtSearch.TabIndex = 1;
            txtSearch.KeyUp += txtSearch_KeyUp;
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
            dgvEmployees.BorderStyle = BorderStyle.Fixed3D;
            dgvEmployees.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvEmployees.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new Padding(0, 2, 0, 2);
            dataGridViewCellStyle2.SelectionBackColor = Color.MediumSeaGreen;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvEmployees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvEmployees.DefaultCellStyle = dataGridViewCellStyle3;
            dgvEmployees.EditMode = DataGridViewEditMode.EditOnF2;
            dgvEmployees.GridColor = SystemColors.Control;
            dgvEmployees.Location = new Point(255, 83);
            dgvEmployees.Margin = new Padding(0);
            dgvEmployees.MultiSelect = false;
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.Padding = new Padding(4);
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvEmployees.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvEmployees.RowHeadersVisible = false;
            dgvEmployees.RowTemplate.DefaultCellStyle.Padding = new Padding(4, 8, 4, 8);
            dgvEmployees.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgvEmployees.RowTemplate.Height = 41;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.Size = new Size(934, 452);
            dgvEmployees.TabIndex = 3;
            dgvEmployees.VirtualMode = true;
            dgvEmployees.CellMouseClick += dgvEmployees_CellMouseClick;
            dgvEmployees.SelectionChanged += dgvEmployees_SelectionChanged;
            // 
            // cntxtEmployeeActions
            // 
            cntxtEmployeeActions.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            cntxtEmployeeActions.Items.AddRange(new ToolStripItem[] { cntxtMenuView, cntxtMenuViewBillings, cntxtMenuHistory, toolStripSeparator1, cntxtMenuEdit, cntxtMenuUpdate, toolStripSeparator2, cntxtMenuArchive });
            cntxtEmployeeActions.Name = "cntxtEmployeeActions";
            cntxtEmployeeActions.Size = new Size(181, 170);
            // 
            // cntxtMenuView
            // 
            cntxtMenuView.DisplayStyle = ToolStripItemDisplayStyle.Text;
            cntxtMenuView.Name = "cntxtMenuView";
            cntxtMenuView.Size = new Size(180, 22);
            cntxtMenuView.Text = "View Details";
            cntxtMenuView.Click += cntxtMenuView_Click;
            // 
            // cntxtMenuViewBillings
            // 
            cntxtMenuViewBillings.Name = "cntxtMenuViewBillings";
            cntxtMenuViewBillings.Size = new Size(180, 22);
            cntxtMenuViewBillings.Text = "View Billings";
            cntxtMenuViewBillings.Click += cntxtMenuViewBillings_Click;
            // 
            // cntxtMenuHistory
            // 
            cntxtMenuHistory.DropDownItems.AddRange(new ToolStripItem[] { menuHistoryPosition, menuHistoryEmploymentStatus, menuHistoryDepartmentLocation });
            cntxtMenuHistory.Name = "cntxtMenuHistory";
            cntxtMenuHistory.Size = new Size(180, 22);
            cntxtMenuHistory.Text = "History";
            // 
            // menuHistoryPosition
            // 
            menuHistoryPosition.Name = "menuHistoryPosition";
            menuHistoryPosition.Size = new Size(213, 22);
            menuHistoryPosition.Text = "Position";
            menuHistoryPosition.Click += menuHistoryPosition_Click;
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
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // cntxtMenuEdit
            // 
            cntxtMenuEdit.Name = "cntxtMenuEdit";
            cntxtMenuEdit.Size = new Size(180, 22);
            cntxtMenuEdit.Text = "Edit";
            cntxtMenuEdit.Click += cntxtMenuEdit_Click;
            // 
            // cntxtMenuUpdate
            // 
            cntxtMenuUpdate.DropDownItems.AddRange(new ToolStripItem[] { menuUpdatePosition, menuUpdateEmploymentStatus, menuUpdateDepartmentLocation });
            cntxtMenuUpdate.Name = "cntxtMenuUpdate";
            cntxtMenuUpdate.Size = new Size(180, 22);
            cntxtMenuUpdate.Text = "Update";
            // 
            // menuUpdatePosition
            // 
            menuUpdatePosition.Name = "menuUpdatePosition";
            menuUpdatePosition.Size = new Size(213, 22);
            menuUpdatePosition.Text = "Position";
            menuUpdatePosition.Click += menuUpdatePosition_Click;
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
            toolStripSeparator2.Size = new Size(177, 6);
            // 
            // cntxtMenuArchive
            // 
            cntxtMenuArchive.Name = "cntxtMenuArchive";
            cntxtMenuArchive.Size = new Size(180, 22);
            cntxtMenuArchive.Text = "Archive";
            cntxtMenuArchive.Click += cntxtMenuArchive_Click;
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
            pnlContainerHeader.PerformLayout();
            pnlFilterContainer.ResumeLayout(false);
            pnlFilterContainer.PerformLayout();
            flowFilters.ResumeLayout(false);
            flowFilters.PerformLayout();
            flowButtonActions.ResumeLayout(false);
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
        private TextBox txtSearch;
        private Panel panel2;
        private FlowLayoutPanel flowButtonActions;
        private Button btnSettings;
        private Label lblRowCounter;
        private ContextMenuStrip cntxtEmployeeActions;
        private ToolStripMenuItem cntxtMenuEdit;
        private ToolStripMenuItem cntxtMenuUpdate;
        private ToolStripMenuItem menuUpdatePosition;
        private ToolStripMenuItem menuUpdateDepartmentLocation;
        private ToolStripMenuItem menuUpdateEmploymentStatus;
        private ToolStripMenuItem cntxtMenuHistory;
        private ToolStripMenuItem menuHistoryPosition;
        private ToolStripMenuItem menuHistoryEmploymentStatus;
        private ToolStripMenuItem menuHistoryDepartmentLocation;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem cntxtMenuView;
        private ToolStripSeparator toolStripSeparator2;
        private Panel pnlContainerFilter;
        private Panel pnlFilterContainer;
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
        private Button btnSearch;
        private Label label1;
        private Panel pnlLine2;
        private Button button1;
        private ToolStripMenuItem cntxtMenuArchive;
        private ToolStripMenuItem cntxtMenuViewBillings;
        private Label lblClient;
        private ComboBox cmbClient;
        private Label lblFilterWageType;
        private Shared.DynamicCheckedListBoxControl dchkListFilterWageType;
    }
}
