using LBPRDC.Source.Config;

namespace LBPRDC.Source.Views.Billing
{
    partial class SummaryView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SummaryView));
            pnlLine1 = new Panel();
            pnlFooter = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnContinue = new Button();
            btnClose = new Button();
            pnlBody = new Panel();
            groupBox1 = new GroupBox();
            label3 = new Label();
            dgvEmployees = new DataGridView();
            cmbCompositeCategory = new ComboBox();
            grpSummaryCount = new GroupBox();
            lblSILCount = new Label();
            lblBookmarkCount = new Label();
            lblUnverifiedCount = new Label();
            lblDescription = new Label();
            pnlLine2 = new Panel();
            panel1 = new Panel();
            lblTitle = new Label();
            pnlFooter.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            pnlBody.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            grpSummaryCount.SuspendLayout();
            pnlLine2.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLine1
            // 
            pnlLine1.BorderStyle = BorderStyle.FixedSingle;
            pnlLine1.Dock = DockStyle.Top;
            pnlLine1.Location = new Point(0, 0);
            pnlLine1.Name = "pnlLine1";
            pnlLine1.Size = new Size(565, 1);
            pnlLine1.TabIndex = 0;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = SystemColors.Control;
            pnlFooter.Controls.Add(flowLayoutPanel1);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 662);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(565, 46);
            pnlFooter.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnContinue);
            flowLayoutPanel1.Controls.Add(btnClose);
            flowLayoutPanel1.Dock = DockStyle.Right;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(372, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(16, 9, 0, 0);
            flowLayoutPanel1.Size = new Size(193, 46);
            flowLayoutPanel1.TabIndex = 7;
            // 
            // btnContinue
            // 
            btnContinue.AutoSize = true;
            btnContinue.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnContinue.Location = new Point(102, 9);
            btnContinue.Margin = new Padding(8, 0, 0, 0);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(75, 28);
            btnContinue.TabIndex = 9;
            btnContinue.Text = "Continue";
            btnContinue.UseVisualStyleBackColor = true;
            btnContinue.Click += btnContinue_Click;
            // 
            // btnClose
            // 
            btnClose.AutoSize = true;
            btnClose.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.Location = new Point(19, 9);
            btnClose.Margin = new Padding(8, 0, 0, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 28);
            btnClose.TabIndex = 8;
            btnClose.Text = "Cancel";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnCancel_Click;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(groupBox1);
            pnlBody.Controls.Add(grpSummaryCount);
            pnlBody.Controls.Add(lblDescription);
            pnlBody.Controls.Add(pnlLine2);
            pnlBody.Controls.Add(lblTitle);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 1);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(16);
            pnlBody.Size = new Size(565, 661);
            pnlBody.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(dgvEmployees);
            groupBox1.Controls.Add(cmbCompositeCategory);
            groupBox1.Location = new Point(16, 135);
            groupBox1.Margin = new Padding(0, 0, 0, 8);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(16, 9, 16, 18);
            groupBox1.Size = new Size(533, 402);
            groupBox1.TabIndex = 25;
            groupBox1.TabStop = false;
            groupBox1.Text = "List";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.WindowText;
            label3.Location = new Point(16, 28);
            label3.Margin = new Padding(0, 0, 8, 8);
            label3.Name = "label3";
            label3.Size = new Size(69, 16);
            label3.TabIndex = 25;
            label3.Text = "Category:";
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
            dgvEmployees.EditMode = DataGridViewEditMode.EditOnF2;
            dgvEmployees.GridColor = SystemColors.Control;
            dgvEmployees.Location = new Point(16, 65);
            dgvEmployees.Margin = new Padding(0);
            dgvEmployees.MultiSelect = false;
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
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
            dgvEmployees.Size = new Size(501, 319);
            dgvEmployees.TabIndex = 21;
            dgvEmployees.VirtualMode = true;
            // 
            // cmbCompositeCategory
            // 
            cmbCompositeCategory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbCompositeCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCompositeCategory.FormattingEnabled = true;
            cmbCompositeCategory.Items.AddRange(new object[] { "Unverified", "Bookmarked", "On Service Incentive Leave" });
            cmbCompositeCategory.Location = new Point(93, 25);
            cmbCompositeCategory.Margin = new Padding(0, 0, 0, 16);
            cmbCompositeCategory.Name = "cmbCompositeCategory";
            cmbCompositeCategory.Size = new Size(424, 24);
            cmbCompositeCategory.TabIndex = 24;
            cmbCompositeCategory.SelectedIndexChanged += cmbCompositeCategory_SelectedIndexChanged;
            // 
            // grpSummaryCount
            // 
            grpSummaryCount.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpSummaryCount.Controls.Add(lblSILCount);
            grpSummaryCount.Controls.Add(lblBookmarkCount);
            grpSummaryCount.Controls.Add(lblUnverifiedCount);
            grpSummaryCount.Location = new Point(16, 545);
            grpSummaryCount.Margin = new Padding(0);
            grpSummaryCount.Name = "grpSummaryCount";
            grpSummaryCount.Padding = new Padding(7, 8, 8, 8);
            grpSummaryCount.Size = new Size(533, 100);
            grpSummaryCount.TabIndex = 23;
            grpSummaryCount.TabStop = false;
            grpSummaryCount.Text = "Summary Count";
            // 
            // lblSILCount
            // 
            lblSILCount.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSILCount.AutoSize = true;
            lblSILCount.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblSILCount.ForeColor = SystemColors.GrayText;
            lblSILCount.Location = new Point(7, 72);
            lblSILCount.Margin = new Padding(0, 0, 0, 8);
            lblSILCount.Name = "lblSILCount";
            lblSILCount.Size = new Size(298, 16);
            lblSILCount.TabIndex = 24;
            lblSILCount.Text = "Employee(s) on Service Incentive Leave (SIL):";
            // 
            // lblBookmarkCount
            // 
            lblBookmarkCount.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblBookmarkCount.AutoSize = true;
            lblBookmarkCount.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblBookmarkCount.ForeColor = SystemColors.GrayText;
            lblBookmarkCount.Location = new Point(7, 48);
            lblBookmarkCount.Margin = new Padding(0, 0, 0, 8);
            lblBookmarkCount.Name = "lblBookmarkCount";
            lblBookmarkCount.Size = new Size(173, 16);
            lblBookmarkCount.TabIndex = 23;
            lblBookmarkCount.Text = "Bookmarked Employee(s):";
            // 
            // lblUnverifiedCount
            // 
            lblUnverifiedCount.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblUnverifiedCount.AutoSize = true;
            lblUnverifiedCount.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblUnverifiedCount.ForeColor = SystemColors.GrayText;
            lblUnverifiedCount.Location = new Point(7, 24);
            lblUnverifiedCount.Margin = new Padding(0, 0, 0, 8);
            lblUnverifiedCount.Name = "lblUnverifiedCount";
            lblUnverifiedCount.Size = new Size(157, 16);
            lblUnverifiedCount.TabIndex = 22;
            lblUnverifiedCount.Text = "Unverified Employee(s):";
            // 
            // lblDescription
            // 
            lblDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDescription.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblDescription.ForeColor = SystemColors.WindowText;
            lblDescription.Location = new Point(16, 60);
            lblDescription.Margin = new Padding(0, 0, 0, 8);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(533, 67);
            lblDescription.TabIndex = 20;
            lblDescription.Text = resources.GetString("lblDescription.Text");
            // 
            // pnlLine2
            // 
            pnlLine2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLine2.BorderStyle = BorderStyle.FixedSingle;
            pnlLine2.Controls.Add(panel1);
            pnlLine2.Location = new Point(16, 43);
            pnlLine2.Margin = new Padding(0, 0, 0, 16);
            pnlLine2.Name = "pnlLine2";
            pnlLine2.Size = new Size(533, 1);
            pnlLine2.TabIndex = 19;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(-1, 0);
            panel1.Margin = new Padding(0, 0, 0, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(1031, 1);
            panel1.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(16, 16);
            lblTitle.Margin = new Padding(0, 0, 0, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(218, 19);
            lblTitle.TabIndex = 18;
            lblTitle.Text = "Employee Summary Details";
            // 
            // SummaryView
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(565, 708);
            ControlBox = false;
            Controls.Add(pnlBody);
            Controls.Add(pnlFooter);
            Controls.Add(pnlLine1);
            Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(581, 747);
            Name = "SummaryView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Summary View";
            Load += SummaryViewForm_Load;
            pnlFooter.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            grpSummaryCount.ResumeLayout(false);
            grpSummaryCount.PerformLayout();
            pnlLine2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLine1;
        private Panel pnlFooter;
        private Panel pnlBody;
        private DataGridView dgvEmployees;
        private Label lblDescription;
        private Panel pnlLine2;
        private Panel panel1;
        private Label lblTitle;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnClose;
        private Button btnContinue;
        private Label lblUnverifiedCount;
        private GroupBox grpSummaryCount;
        private Label lblSILCount;
        private Label lblBookmarkCount;
        private ComboBox cmbCompositeCategory;
        private GroupBox groupBox1;
        private Label label3;
    }
}