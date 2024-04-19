using LBPRDC.Source.Config;

namespace LBPRDC.Source.Views.Billing
{
    partial class ViewAccountBillings
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
            btnUpdate = new Button();
            btnClose = new Button();
            pnlBody = new Panel();
            lblTotalNetValue = new Label();
            lblTotalGrossValue = new Label();
            dgvBillings = new DataGridView();
            pnlLine2 = new Panel();
            lblAccountNumber = new Label();
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
            pnlLine1.Size = new Size(1111, 1);
            pnlLine1.TabIndex = 0;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = SystemColors.Control;
            pnlFooter.Controls.Add(flowLayoutPanel1);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 599);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1111, 46);
            pnlFooter.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnUpdate);
            flowLayoutPanel1.Controls.Add(btnClose);
            flowLayoutPanel1.Dock = DockStyle.Right;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(730, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(16, 9, 0, 0);
            flowLayoutPanel1.Size = new Size(381, 46);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // btnUpdate
            // 
            btnUpdate.AutoSize = true;
            btnUpdate.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpdate.Location = new Point(290, 9);
            btnUpdate.Margin = new Padding(8, 0, 0, 0);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 28);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnClose
            // 
            btnClose.AutoSize = true;
            btnClose.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.Location = new Point(207, 9);
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
            pnlBody.Controls.Add(lblTotalNetValue);
            pnlBody.Controls.Add(lblTotalGrossValue);
            pnlBody.Controls.Add(dgvBillings);
            pnlBody.Controls.Add(pnlLine2);
            pnlBody.Controls.Add(lblAccountNumber);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 1);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(16);
            pnlBody.Size = new Size(1111, 598);
            pnlBody.TabIndex = 2;
            // 
            // lblTotalNetValue
            // 
            lblTotalNetValue.AutoSize = true;
            lblTotalNetValue.Location = new Point(16, 84);
            lblTotalNetValue.Margin = new Padding(3, 0, 3, 16);
            lblTotalNetValue.Name = "lblTotalNetValue";
            lblTotalNetValue.Size = new Size(105, 16);
            lblTotalNetValue.TabIndex = 7;
            lblTotalNetValue.Text = "Total Net Value:";
            // 
            // lblTotalGrossValue
            // 
            lblTotalGrossValue.AutoSize = true;
            lblTotalGrossValue.Location = new Point(16, 60);
            lblTotalGrossValue.Margin = new Padding(3, 0, 3, 8);
            lblTotalGrossValue.Name = "lblTotalGrossValue";
            lblTotalGrossValue.Size = new Size(122, 16);
            lblTotalGrossValue.TabIndex = 6;
            lblTotalGrossValue.Text = "Total Gross Value:";
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
            dgvBillings.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvBillings.GridColor = SystemColors.Control;
            dgvBillings.Location = new Point(16, 116);
            dgvBillings.Margin = new Padding(0);
            dgvBillings.MultiSelect = false;
            dgvBillings.Name = "dgvBillings";
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
            dgvBillings.Size = new Size(1079, 466);
            dgvBillings.TabIndex = 5;
            dgvBillings.VirtualMode = true;
            dgvBillings.DataError += dgvBillings_DataError;
            // 
            // pnlLine2
            // 
            pnlLine2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLine2.BorderStyle = BorderStyle.FixedSingle;
            pnlLine2.Location = new Point(16, 43);
            pnlLine2.Margin = new Padding(0, 0, 0, 16);
            pnlLine2.Name = "pnlLine2";
            pnlLine2.Size = new Size(1079, 1);
            pnlLine2.TabIndex = 4;
            // 
            // lblAccountNumber
            // 
            lblAccountNumber.AutoSize = true;
            lblAccountNumber.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblAccountNumber.Location = new Point(16, 16);
            lblAccountNumber.Margin = new Padding(0, 0, 0, 8);
            lblAccountNumber.Name = "lblAccountNumber";
            lblAccountNumber.Size = new Size(82, 19);
            lblAccountNumber.TabIndex = 3;
            lblAccountNumber.Text = "SOA No.: ";
            // 
            // ViewAccountBillings
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(1111, 645);
            Controls.Add(pnlBody);
            Controls.Add(pnlFooter);
            Controls.Add(pnlLine1);
            Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "ViewAccountBillings";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Statement of Account Billings";
            FormClosed += ViewAccountBillings_FormClosed;
            Load += ViewAccountBillings_Load;
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
        private Panel pnlLine2;
        private Label lblAccountNumber;
        private DataGridView dgvBillings;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnClose;
        private Label lblTotalGrossValue;
        private Label lblTotalNetValue;
        private Button btnUpdate;
    }
}