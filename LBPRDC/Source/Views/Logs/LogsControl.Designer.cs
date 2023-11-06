namespace LBPRDC.Source.Views.Logs
{
    partial class LogsControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogsControl));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlFooter = new Panel();
            flowControls = new FlowLayoutPanel();
            panel1 = new Panel();
            pnlContainerSearch = new Panel();
            label1 = new Label();
            txtSearch = new TextBox();
            pnlContainerFilter = new Panel();
            pnlFilterContent = new Panel();
            flowFilters = new FlowLayoutPanel();
            lblFilterType = new Label();
            dchkListFilterType = new Shared.DynamicCheckedListBoxControl();
            flowFilterControls = new FlowLayoutPanel();
            btnFilter = new Button();
            btnReset = new Button();
            panel2 = new Panel();
            lblRowCounter = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnSettings = new Button();
            dgvLogs = new DataGridView();
            pnlFooter.SuspendLayout();
            panel1.SuspendLayout();
            pnlContainerSearch.SuspendLayout();
            pnlContainerFilter.SuspendLayout();
            pnlFilterContent.SuspendLayout();
            flowFilters.SuspendLayout();
            flowFilterControls.SuspendLayout();
            panel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLogs).BeginInit();
            SuspendLayout();
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = SystemColors.Menu;
            pnlFooter.Controls.Add(flowControls);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 569);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1213, 60);
            pnlFooter.TabIndex = 1;
            pnlFooter.Visible = false;
            // 
            // flowControls
            // 
            flowControls.Dock = DockStyle.Right;
            flowControls.Location = new Point(562, 0);
            flowControls.Name = "flowControls";
            flowControls.Size = new Size(651, 60);
            flowControls.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(pnlContainerSearch);
            panel1.Controls.Add(pnlContainerFilter);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(dgvLogs);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(16);
            panel1.Size = new Size(1213, 569);
            panel1.TabIndex = 2;
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
            pnlContainerSearch.TabIndex = 10;
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
            pnlContainerFilter.Controls.Add(flowFilterControls);
            pnlContainerFilter.Location = new Point(16, 100);
            pnlContainerFilter.Margin = new Padding(0, 0, 16, 0);
            pnlContainerFilter.Name = "pnlContainerFilter";
            pnlContainerFilter.Size = new Size(215, 453);
            pnlContainerFilter.TabIndex = 9;
            // 
            // pnlFilterContent
            // 
            pnlFilterContent.AutoScroll = true;
            pnlFilterContent.Controls.Add(flowFilters);
            pnlFilterContent.Dock = DockStyle.Fill;
            pnlFilterContent.Location = new Point(0, 0);
            pnlFilterContent.Margin = new Padding(0);
            pnlFilterContent.Name = "pnlFilterContent";
            pnlFilterContent.Size = new Size(213, 411);
            pnlFilterContent.TabIndex = 6;
            // 
            // flowFilters
            // 
            flowFilters.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowFilters.AutoSize = true;
            flowFilters.Controls.Add(lblFilterType);
            flowFilters.Controls.Add(dchkListFilterType);
            flowFilters.FlowDirection = FlowDirection.TopDown;
            flowFilters.Location = new Point(0, 0);
            flowFilters.Name = "flowFilters";
            flowFilters.Padding = new Padding(4, 0, 0, 0);
            flowFilters.Size = new Size(196, 306);
            flowFilters.TabIndex = 6;
            // 
            // lblFilterType
            // 
            lblFilterType.AutoSize = true;
            lblFilterType.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblFilterType.ForeColor = SystemColors.ControlDarkDark;
            lblFilterType.Location = new Point(5, 8);
            lblFilterType.Margin = new Padding(1, 8, 0, 6);
            lblFilterType.Name = "lblFilterType";
            lblFilterType.Size = new Size(45, 16);
            lblFilterType.TabIndex = 6;
            lblFilterType.Text = "Types";
            // 
            // dchkListFilterType
            // 
            dchkListFilterType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dchkListFilterType.AutoSize = true;
            dchkListFilterType.BackColor = Color.White;
            dchkListFilterType.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dchkListFilterType.Location = new Point(16, 30);
            dchkListFilterType.Margin = new Padding(12, 0, 0, 2);
            dchkListFilterType.Name = "dchkListFilterType";
            dchkListFilterType.Size = new Size(180, 0);
            dchkListFilterType.TabIndex = 6;
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
            panel2.TabIndex = 8;
            // 
            // lblRowCounter
            // 
            lblRowCounter.AutoSize = true;
            lblRowCounter.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblRowCounter.ForeColor = SystemColors.ControlDarkDark;
            lblRowCounter.Location = new Point(4, 8);
            lblRowCounter.Margin = new Padding(0);
            lblRowCounter.Name = "lblRowCounter";
            lblRowCounter.Size = new Size(77, 16);
            lblRowCounter.TabIndex = 1;
            lblRowCounter.Text = "Logs count";
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
            btnSettings.Visible = false;
            // 
            // dgvLogs
            // 
            dgvLogs.AllowUserToAddRows = false;
            dgvLogs.AllowUserToDeleteRows = false;
            dgvLogs.AllowUserToOrderColumns = true;
            dgvLogs.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.SelectionBackColor = Color.SeaGreen;
            dgvLogs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvLogs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvLogs.BackgroundColor = SystemColors.Window;
            dgvLogs.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLogs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new Padding(0, 2, 0, 2);
            dataGridViewCellStyle2.SelectionBackColor = Color.MediumSeaGreen;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvLogs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLogs.EditMode = DataGridViewEditMode.EditOnF2;
            dgvLogs.GridColor = SystemColors.Control;
            dgvLogs.Location = new Point(247, 67);
            dgvLogs.Margin = new Padding(0);
            dgvLogs.MultiSelect = false;
            dgvLogs.Name = "dgvLogs";
            dgvLogs.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new Padding(4);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvLogs.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvLogs.RowHeadersVisible = false;
            dgvLogs.RowTemplate.DefaultCellStyle.Padding = new Padding(4, 8, 4, 8);
            dgvLogs.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgvLogs.RowTemplate.Height = 41;
            dgvLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLogs.Size = new Size(950, 486);
            dgvLogs.TabIndex = 4;
            dgvLogs.VirtualMode = true;
            // 
            // LogsControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            Controls.Add(panel1);
            Controls.Add(pnlFooter);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "LogsControl";
            Size = new Size(1213, 629);
            VisibleChanged += LogsControl_VisibleChanged;
            pnlFooter.ResumeLayout(false);
            panel1.ResumeLayout(false);
            pnlContainerSearch.ResumeLayout(false);
            pnlContainerSearch.PerformLayout();
            pnlContainerFilter.ResumeLayout(false);
            pnlFilterContent.ResumeLayout(false);
            pnlFilterContent.PerformLayout();
            flowFilters.ResumeLayout(false);
            flowFilters.PerformLayout();
            flowFilterControls.ResumeLayout(false);
            flowFilterControls.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLogs).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLine1;
        private Panel pllFooter;
        private FlowLayoutPanel flowControls;
        private Panel panel1;
        private DataGridView dgvLogs;
        private Panel panel2;
        private Label lblRowCounter;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnSettings;
        private Panel pnlContainerFilter;
        private Panel pnlFilterContent;
        private FlowLayoutPanel flowFilters;
        private Label lblFilterType;
        private Shared.DynamicCheckedListBoxControl dchkListFilterType;
        private FlowLayoutPanel flowFilterControls;
        private Button btnFilter;
        private Button btnReset;
        private Panel pnlContainerSearch;
        private Label label1;
        private TextBox txtSearch;
        private Panel pnlFooter;
    }
}
