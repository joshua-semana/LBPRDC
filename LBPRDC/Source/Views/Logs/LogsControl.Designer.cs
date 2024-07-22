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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlBody = new Panel();
            pnlFilterContent = new Panel();
            flowFilters = new FlowLayoutPanel();
            lblFilterType = new Label();
            dchkListFilterType = new Shared.DynamicCheckedListBoxControl();
            pnlLine2 = new Panel();
            btnReset = new Button();
            btnFilter = new Button();
            lblFilter = new Label();
            dtpDate = new DateTimePicker();
            txtSearch = new TextBox();
            btnSearch = new Button();
            lblRowCounter = new Label();
            pnlLine1 = new Panel();
            dgvLogs = new DataGridView();
            pnlBody.SuspendLayout();
            pnlFilterContent.SuspendLayout();
            flowFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLogs).BeginInit();
            SuspendLayout();
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(pnlFilterContent);
            pnlBody.Controls.Add(pnlLine2);
            pnlBody.Controls.Add(btnReset);
            pnlBody.Controls.Add(btnFilter);
            pnlBody.Controls.Add(lblFilter);
            pnlBody.Controls.Add(dtpDate);
            pnlBody.Controls.Add(txtSearch);
            pnlBody.Controls.Add(btnSearch);
            pnlBody.Controls.Add(lblRowCounter);
            pnlBody.Controls.Add(pnlLine1);
            pnlBody.Controls.Add(dgvLogs);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 0);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(24, 24, 24, 10);
            pnlBody.Size = new Size(1213, 629);
            pnlBody.TabIndex = 2;
            // 
            // pnlFilterContent
            // 
            pnlFilterContent.AutoScroll = true;
            pnlFilterContent.Controls.Add(flowFilters);
            pnlFilterContent.Location = new Point(24, 113);
            pnlFilterContent.Margin = new Padding(0);
            pnlFilterContent.Name = "pnlFilterContent";
            pnlFilterContent.Size = new Size(215, 482);
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
            flowFilters.Size = new Size(198, 306);
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
            dchkListFilterType.Size = new Size(180, 18);
            dchkListFilterType.TabIndex = 6;
            // 
            // pnlLine2
            // 
            pnlLine2.BorderStyle = BorderStyle.FixedSingle;
            pnlLine2.Location = new Point(24, 112);
            pnlLine2.Margin = new Padding(0);
            pnlLine2.Name = "pnlLine2";
            pnlLine2.Size = new Size(215, 1);
            pnlLine2.TabIndex = 27;
            // 
            // btnReset
            // 
            btnReset.AutoSize = true;
            btnReset.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnReset.Location = new Point(134, 83);
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
            btnFilter.Location = new Point(189, 83);
            btnFilter.Margin = new Padding(4, 0, 0, 4);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(51, 25);
            btnFilter.TabIndex = 6;
            btnFilter.Text = "Apply";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblFilter.ForeColor = SystemColors.ControlText;
            lblFilter.Location = new Point(20, 87);
            lblFilter.Margin = new Padding(0, 0, 0, 8);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(52, 16);
            lblFilter.TabIndex = 26;
            lblFilter.Text = "Filters";
            // 
            // dtpDate
            // 
            dtpDate.AccessibleName = "Date";
            dtpDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpDate.CustomFormat = "MMMM dd, yyy";
            dtpDate.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.Location = new Point(992, 24);
            dtpDate.Margin = new Padding(0);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(197, 26);
            dtpDate.TabIndex = 25;
            dtpDate.ValueChanged += dtpDate_ValueChanged;
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
            // btnSearch
            // 
            btnSearch.AutoSize = true;
            btnSearch.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearch.Location = new Point(247, 23);
            btnSearch.Margin = new Padding(4, 0, 8, 0);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 28);
            btnSearch.TabIndex = 12;
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
            lblRowCounter.Location = new Point(251, 603);
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
            pnlLine1.TabIndex = 8;
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
            dgvLogs.BorderStyle = BorderStyle.Fixed3D;
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
            dgvLogs.Location = new Point(255, 83);
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
            dgvLogs.Size = new Size(934, 512);
            dgvLogs.TabIndex = 4;
            dgvLogs.VirtualMode = true;
            // 
            // LogsControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            Controls.Add(pnlBody);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "LogsControl";
            Size = new Size(1213, 629);
            VisibleChanged += LogsControl_VisibleChanged;
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            pnlFilterContent.ResumeLayout(false);
            pnlFilterContent.PerformLayout();
            flowFilters.ResumeLayout(false);
            flowFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLogs).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLine1;
        private Panel pllFooter;
        private Panel pnlBody;
        private DataGridView dgvLogs;
        private Panel panel2;
        private Label lblRowCounter;
        private Panel pnlFilterContent;
        private FlowLayoutPanel flowFilters;
        private Label lblFilterType;
        private Shared.DynamicCheckedListBoxControl dchkListFilterType;
        private Button btnFilter;
        private Button btnReset;
        private TextBox txtSearch;
        private DateTimePicker dtpDate;
        private Button btnSearch;
        private Label label1;
        private Panel pnlLine2;
        private Label lblFilter;
    }
}
