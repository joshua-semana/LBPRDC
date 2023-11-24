namespace LBPRDC.Source.Views.Billing
{
    partial class BillingControl
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
            pnlRight = new Panel();
            pnlRightFooter = new Panel();
            flowFooterActions = new FlowLayoutPanel();
            btnView = new Button();
            pnlVLine1 = new Panel();
            pnlLeft = new Panel();
            pnlLeftBody = new Panel();
            btnSearch = new Button();
            pnlLine1 = new Panel();
            lblRowCounter = new Label();
            txtSearch = new TextBox();
            dgvBillings = new DataGridView();
            pnlLeftFooter = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnNew = new Button();
            btnUpload = new Button();
            pnlRight.SuspendLayout();
            pnlRightFooter.SuspendLayout();
            flowFooterActions.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlLeftBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBillings).BeginInit();
            pnlLeftFooter.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRight
            // 
            pnlRight.Controls.Add(pnlRightFooter);
            pnlRight.Dock = DockStyle.Right;
            pnlRight.Location = new Point(853, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(360, 629);
            pnlRight.TabIndex = 0;
            // 
            // pnlRightFooter
            // 
            pnlRightFooter.BackColor = SystemColors.Control;
            pnlRightFooter.Controls.Add(flowFooterActions);
            pnlRightFooter.Dock = DockStyle.Bottom;
            pnlRightFooter.Location = new Point(0, 569);
            pnlRightFooter.Name = "pnlRightFooter";
            pnlRightFooter.Size = new Size(360, 60);
            pnlRightFooter.TabIndex = 0;
            // 
            // flowFooterActions
            // 
            flowFooterActions.Controls.Add(btnView);
            flowFooterActions.Dock = DockStyle.Right;
            flowFooterActions.FlowDirection = FlowDirection.RightToLeft;
            flowFooterActions.Location = new Point(251, 0);
            flowFooterActions.Name = "flowFooterActions";
            flowFooterActions.Padding = new Padding(15, 16, 0, 16);
            flowFooterActions.Size = new Size(109, 60);
            flowFooterActions.TabIndex = 4;
            // 
            // btnView
            // 
            btnView.AutoSize = true;
            btnView.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnView.Location = new Point(19, 16);
            btnView.Margin = new Padding(8, 0, 0, 0);
            btnView.Name = "btnView";
            btnView.Size = new Size(75, 28);
            btnView.TabIndex = 8;
            btnView.Text = "View";
            btnView.UseVisualStyleBackColor = true;
            // 
            // pnlVLine1
            // 
            pnlVLine1.BorderStyle = BorderStyle.FixedSingle;
            pnlVLine1.Dock = DockStyle.Right;
            pnlVLine1.Location = new Point(852, 0);
            pnlVLine1.Name = "pnlVLine1";
            pnlVLine1.Size = new Size(1, 629);
            pnlVLine1.TabIndex = 1;
            // 
            // pnlLeft
            // 
            pnlLeft.Controls.Add(pnlLeftBody);
            pnlLeft.Controls.Add(pnlLeftFooter);
            pnlLeft.Dock = DockStyle.Fill;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(852, 629);
            pnlLeft.TabIndex = 2;
            // 
            // pnlLeftBody
            // 
            pnlLeftBody.Controls.Add(btnSearch);
            pnlLeftBody.Controls.Add(pnlLine1);
            pnlLeftBody.Controls.Add(lblRowCounter);
            pnlLeftBody.Controls.Add(txtSearch);
            pnlLeftBody.Controls.Add(dgvBillings);
            pnlLeftBody.Dock = DockStyle.Fill;
            pnlLeftBody.Location = new Point(0, 0);
            pnlLeftBody.Name = "pnlLeftBody";
            pnlLeftBody.Padding = new Padding(24, 24, 24, 10);
            pnlLeftBody.Size = new Size(852, 569);
            pnlLeftBody.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.AutoSize = true;
            btnSearch.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearch.Location = new Point(247, 23);
            btnSearch.Margin = new Padding(4, 0, 8, 0);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 28);
            btnSearch.TabIndex = 10;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // pnlLine1
            // 
            pnlLine1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLine1.BorderStyle = BorderStyle.FixedSingle;
            pnlLine1.Location = new Point(24, 66);
            pnlLine1.Margin = new Padding(0, 0, 0, 16);
            pnlLine1.Name = "pnlLine1";
            pnlLine1.Size = new Size(804, 1);
            pnlLine1.TabIndex = 9;
            // 
            // lblRowCounter
            // 
            lblRowCounter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblRowCounter.AutoSize = true;
            lblRowCounter.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblRowCounter.ForeColor = SystemColors.GrayText;
            lblRowCounter.Location = new Point(20, 543);
            lblRowCounter.Margin = new Padding(0, 8, 0, 0);
            lblRowCounter.Name = "lblRowCounter";
            lblRowCounter.Size = new Size(45, 16);
            lblRowCounter.TabIndex = 1;
            lblRowCounter.Text = "Count";
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
            // dgvBillings
            // 
            dgvBillings.AllowUserToAddRows = false;
            dgvBillings.AllowUserToDeleteRows = false;
            dgvBillings.AllowUserToOrderColumns = true;
            dgvBillings.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.SelectionBackColor = Color.SeaGreen;
            dgvBillings.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvBillings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBillings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvBillings.BackgroundColor = SystemColors.Window;
            dgvBillings.BorderStyle = BorderStyle.Fixed3D;
            dgvBillings.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvBillings.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new Padding(0, 2, 0, 2);
            dataGridViewCellStyle2.SelectionBackColor = Color.MediumSeaGreen;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvBillings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvBillings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBillings.EditMode = DataGridViewEditMode.EditOnF2;
            dgvBillings.GridColor = SystemColors.Control;
            dgvBillings.Location = new Point(24, 83);
            dgvBillings.Margin = new Padding(0);
            dgvBillings.MultiSelect = false;
            dgvBillings.Name = "dgvBillings";
            dgvBillings.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new Padding(4);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvBillings.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvBillings.RowHeadersVisible = false;
            dgvBillings.RowTemplate.DefaultCellStyle.Padding = new Padding(4, 8, 4, 8);
            dgvBillings.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgvBillings.RowTemplate.Height = 41;
            dgvBillings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBillings.Size = new Size(804, 452);
            dgvBillings.TabIndex = 4;
            dgvBillings.VirtualMode = true;
            // 
            // pnlLeftFooter
            // 
            pnlLeftFooter.BackColor = SystemColors.Control;
            pnlLeftFooter.Controls.Add(flowLayoutPanel1);
            pnlLeftFooter.Dock = DockStyle.Bottom;
            pnlLeftFooter.Location = new Point(0, 569);
            pnlLeftFooter.Name = "pnlLeftFooter";
            pnlLeftFooter.Size = new Size(852, 60);
            pnlLeftFooter.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnNew);
            flowLayoutPanel1.Controls.Add(btnUpload);
            flowLayoutPanel1.Dock = DockStyle.Right;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(649, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(23, 16, 0, 16);
            flowLayoutPanel1.Size = new Size(203, 60);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // btnNew
            // 
            btnNew.AutoSize = true;
            btnNew.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnNew.Location = new Point(105, 16);
            btnNew.Margin = new Padding(8, 0, 0, 0);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(75, 28);
            btnNew.TabIndex = 8;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // btnUpload
            // 
            btnUpload.AutoSize = true;
            btnUpload.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpload.Location = new Point(22, 16);
            btnUpload.Margin = new Padding(8, 0, 0, 0);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(75, 28);
            btnUpload.TabIndex = 9;
            btnUpload.Text = "Upload";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // BillingControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            Controls.Add(pnlLeft);
            Controls.Add(pnlVLine1);
            Controls.Add(pnlRight);
            Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "BillingControl";
            Size = new Size(1213, 629);
            VisibleChanged += BillingControl_VisibleChanged;
            pnlRight.ResumeLayout(false);
            pnlRightFooter.ResumeLayout(false);
            flowFooterActions.ResumeLayout(false);
            flowFooterActions.PerformLayout();
            pnlLeft.ResumeLayout(false);
            pnlLeftBody.ResumeLayout(false);
            pnlLeftBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBillings).EndInit();
            pnlLeftFooter.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRight;
        private Panel pnlVLine1;
        private Panel pnlLeft;
        private Panel pnlRightFooter;
        private Panel pnlLeftFooter;
        private FlowLayoutPanel flowFooterActions;
        private Button btnView;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnNew;
        private DataGridView dgvBillings;
        private Panel pnlLeftBody;
        private TextBox txtSearch;
        private Label lblRowCounter;
        private Panel pnlLine1;
        private Button btnSearch;
        private Button btnUpload;
    }
}
