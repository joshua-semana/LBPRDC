namespace LBPRDC.Source.Views.EmployeeFlow
{
    partial class ViewBillingsForm
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
            pnlFooter = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnClose = new Button();
            pnlBody = new Panel();
            label1 = new Label();
            cmbTimeType = new ComboBox();
            dgvBillings = new DataGridView();
            pnlLine2 = new Panel();
            lblTitle1 = new Label();
            pnlFooter.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBillings).BeginInit();
            SuspendLayout();
            // 
            // pnlLine1
            // 
            pnlLine1.BorderStyle = BorderStyle.FixedSingle;
            pnlLine1.Dock = DockStyle.Top;
            pnlLine1.Location = new Point(0, 0);
            pnlLine1.Name = "pnlLine1";
            pnlLine1.Size = new Size(800, 1);
            pnlLine1.TabIndex = 0;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = SystemColors.Control;
            pnlFooter.Controls.Add(flowLayoutPanel1);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 404);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(800, 46);
            pnlFooter.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnClose);
            flowLayoutPanel1.Dock = DockStyle.Right;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(692, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(16, 9, 0, 0);
            flowLayoutPanel1.Size = new Size(108, 46);
            flowLayoutPanel1.TabIndex = 7;
            // 
            // btnClose
            // 
            btnClose.AutoSize = true;
            btnClose.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.Location = new Point(17, 9);
            btnClose.Margin = new Padding(8, 0, 0, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 28);
            btnClose.TabIndex = 9;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(label1);
            pnlBody.Controls.Add(cmbTimeType);
            pnlBody.Controls.Add(dgvBillings);
            pnlBody.Controls.Add(pnlLine2);
            pnlBody.Controls.Add(lblTitle1);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 1);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(16);
            pnlBody.Size = new Size(800, 403);
            pnlBody.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 59);
            label1.Name = "label1";
            label1.Size = new Size(42, 16);
            label1.TabIndex = 8;
            label1.Text = "Type:";
            // 
            // cmbTimeType
            // 
            cmbTimeType.AutoCompleteCustomSource.AddRange(new string[] { "Regular", "Overtime" });
            cmbTimeType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTimeType.FormattingEnabled = true;
            cmbTimeType.Items.AddRange(new object[] { "Regular", "Overtime" });
            cmbTimeType.Location = new Point(64, 56);
            cmbTimeType.Margin = new Padding(0, 0, 0, 12);
            cmbTimeType.Name = "cmbTimeType";
            cmbTimeType.Size = new Size(147, 24);
            cmbTimeType.TabIndex = 7;
            cmbTimeType.SelectedIndexChanged += cmbTimeType_SelectedIndexChanged;
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
            dgvBillings.Location = new Point(16, 92);
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
            dgvBillings.Size = new Size(768, 295);
            dgvBillings.TabIndex = 6;
            dgvBillings.VirtualMode = true;
            // 
            // pnlLine2
            // 
            pnlLine2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLine2.BorderStyle = BorderStyle.FixedSingle;
            pnlLine2.Location = new Point(16, 43);
            pnlLine2.Margin = new Padding(0, 0, 0, 12);
            pnlLine2.Name = "pnlLine2";
            pnlLine2.Size = new Size(768, 1);
            pnlLine2.TabIndex = 5;
            // 
            // lblTitle1
            // 
            lblTitle1.AutoSize = true;
            lblTitle1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle1.Location = new Point(16, 16);
            lblTitle1.Margin = new Padding(0, 0, 0, 8);
            lblTitle1.Name = "lblTitle1";
            lblTitle1.Size = new Size(89, 19);
            lblTitle1.TabIndex = 4;
            lblTitle1.Text = "All Billings";
            // 
            // ViewBillingsForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlBody);
            Controls.Add(pnlFooter);
            Controls.Add(pnlLine1);
            Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "ViewBillingsForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "All Billings";
            Load += ViewBillingsForm_Load;
            pnlFooter.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBillings).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLine1;
        private Panel pnlFooter;
        private Panel pnlBody;
        private Label lblTitle1;
        private Panel pnlLine2;
        private DataGridView dgvBillings;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnClose;
        private Label label1;
        private ComboBox cmbTimeType;
    }
}