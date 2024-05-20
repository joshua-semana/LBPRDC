namespace LBPRDC.Source.Views.Categories
{
    partial class PositionRatesHistory
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlLine1 = new Panel();
            pnlHeader = new Panel();
            lblTitle = new Label();
            pnlFooter = new Panel();
            flowFooterActions = new FlowLayoutPanel();
            btnClose = new Button();
            pnlBody = new Panel();
            dgvHistory = new DataGridView();
            grpPersonalData = new GroupBox();
            label10 = new Label();
            txtID = new TextBox();
            txtName = new TextBox();
            label1 = new Label();
            pnlHeader.SuspendLayout();
            pnlFooter.SuspendLayout();
            flowFooterActions.SuspendLayout();
            pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            grpPersonalData.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLine1
            // 
            pnlLine1.BorderStyle = BorderStyle.FixedSingle;
            pnlLine1.Dock = DockStyle.Top;
            pnlLine1.Location = new Point(0, 0);
            pnlLine1.Name = "pnlLine1";
            pnlLine1.Size = new Size(870, 1);
            pnlLine1.TabIndex = 0;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = SystemColors.Control;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 1);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(870, 40);
            pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(16, 11);
            lblTitle.Margin = new Padding(0, 0, 0, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(838, 19);
            lblTitle.TabIndex = 28;
            lblTitle.Text = "RATES HISTORY";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = SystemColors.Control;
            pnlFooter.Controls.Add(flowFooterActions);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 398);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(870, 60);
            pnlFooter.TabIndex = 2;
            // 
            // flowFooterActions
            // 
            flowFooterActions.Controls.Add(btnClose);
            flowFooterActions.Dock = DockStyle.Right;
            flowFooterActions.FlowDirection = FlowDirection.RightToLeft;
            flowFooterActions.Location = new Point(759, 0);
            flowFooterActions.Name = "flowFooterActions";
            flowFooterActions.Padding = new Padding(15, 16, 0, 16);
            flowFooterActions.Size = new Size(111, 60);
            flowFooterActions.TabIndex = 4;
            // 
            // btnClose
            // 
            btnClose.AutoSize = true;
            btnClose.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.Location = new Point(21, 16);
            btnClose.Margin = new Padding(8, 0, 0, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 28);
            btnClose.TabIndex = 8;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(dgvHistory);
            pnlBody.Controls.Add(grpPersonalData);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 41);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(16, 10, 16, 16);
            pnlBody.Size = new Size(870, 357);
            pnlBody.TabIndex = 3;
            // 
            // dgvHistory
            // 
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AllowUserToDeleteRows = false;
            dgvHistory.AllowUserToOrderColumns = true;
            dgvHistory.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.SelectionBackColor = Color.SeaGreen;
            dgvHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvHistory.BackgroundColor = SystemColors.Window;
            dgvHistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHistory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new Padding(0, 2, 0, 2);
            dataGridViewCellStyle2.SelectionBackColor = Color.MediumSeaGreen;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistory.EditMode = DataGridViewEditMode.EditOnF2;
            dgvHistory.GridColor = SystemColors.Control;
            dgvHistory.Location = new Point(16, 118);
            dgvHistory.Margin = new Padding(0);
            dgvHistory.MultiSelect = false;
            dgvHistory.Name = "dgvHistory";
            dgvHistory.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new Padding(4);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.RowTemplate.DefaultCellStyle.Padding = new Padding(4, 8, 4, 8);
            dgvHistory.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgvHistory.RowTemplate.Height = 41;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.Size = new Size(838, 223);
            dgvHistory.TabIndex = 6;
            dgvHistory.VirtualMode = true;
            // 
            // grpPersonalData
            // 
            grpPersonalData.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpPersonalData.Controls.Add(label10);
            grpPersonalData.Controls.Add(txtID);
            grpPersonalData.Controls.Add(txtName);
            grpPersonalData.Controls.Add(label1);
            grpPersonalData.Location = new Point(16, 10);
            grpPersonalData.Margin = new Padding(0, 0, 0, 16);
            grpPersonalData.Name = "grpPersonalData";
            grpPersonalData.Padding = new Padding(4);
            grpPersonalData.Size = new Size(838, 92);
            grpPersonalData.TabIndex = 5;
            grpPersonalData.TabStop = false;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(124, 24);
            label10.Margin = new Padding(4);
            label10.Name = "label10";
            label10.Size = new Size(43, 16);
            label10.TabIndex = 9;
            label10.Text = "Name";
            // 
            // txtID
            // 
            txtID.AccessibleName = "Employee ID";
            txtID.Location = new Point(12, 48);
            txtID.Margin = new Padding(8, 4, 8, 8);
            txtID.MaxLength = 50;
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(100, 23);
            txtID.TabIndex = 1;
            // 
            // txtName
            // 
            txtName.AccessibleName = "Full Name";
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtName.Location = new Point(128, 48);
            txtName.Margin = new Padding(8, 4, 8, 8);
            txtName.MaxLength = 50;
            txtName.Name = "txtName";
            txtName.ReadOnly = true;
            txtName.Size = new Size(698, 23);
            txtName.TabIndex = 10;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(9, 24);
            label1.Margin = new Padding(4);
            label1.Name = "label1";
            label1.Size = new Size(20, 16);
            label1.TabIndex = 0;
            label1.Text = "ID";
            // 
            // PositionRatesHistory
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(870, 458);
            Controls.Add(pnlBody);
            Controls.Add(pnlFooter);
            Controls.Add(pnlHeader);
            Controls.Add(pnlLine1);
            Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PositionRatesHistory";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Load += PositionRatesHistory_Load;
            pnlHeader.ResumeLayout(false);
            pnlFooter.ResumeLayout(false);
            flowFooterActions.ResumeLayout(false);
            flowFooterActions.PerformLayout();
            pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            grpPersonalData.ResumeLayout(false);
            grpPersonalData.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLine1;
        private Panel pnlHeader;
        private Panel pnlFooter;
        private Panel pnlBody;
        private Label lblTitle;
        private TextBox txtName;
        private GroupBox grpPersonalData;
        private Label label10;
        private TextBox txtID;
        private Label label1;
        private DataGridView dgvHistory;
        private FlowLayoutPanel flowFooterActions;
        private Button btnClose;
    }
}