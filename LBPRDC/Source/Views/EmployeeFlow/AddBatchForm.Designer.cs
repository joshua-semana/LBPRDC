namespace LBPRDC.Source.Views
{
    partial class frmAddBatchEmployees
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
            pnlLine1 = new Panel();
            pnlMain = new Panel();
            groupBox1 = new GroupBox();
            lblRowCount = new Label();
            lblFilePath = new Label();
            dgvRawData = new DataGridView();
            flowControls = new FlowLayoutPanel();
            btnConfirm = new Button();
            btnCancel = new Button();
            pnlMain.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRawData).BeginInit();
            flowControls.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLine1
            // 
            pnlLine1.BorderStyle = BorderStyle.FixedSingle;
            pnlLine1.Dock = DockStyle.Top;
            pnlLine1.Location = new Point(0, 0);
            pnlLine1.Name = "pnlLine1";
            pnlLine1.Size = new Size(784, 1);
            pnlLine1.TabIndex = 0;
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(groupBox1);
            pnlMain.Controls.Add(dgvRawData);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 1);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(16);
            pnlMain.Size = new Size(784, 500);
            pnlMain.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(lblRowCount);
            groupBox1.Controls.Add(lblFilePath);
            groupBox1.Location = new Point(16, 16);
            groupBox1.Margin = new Padding(0, 0, 0, 16);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(752, 70);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "File Details";
            // 
            // lblRowCount
            // 
            lblRowCount.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblRowCount.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblRowCount.Location = new Point(6, 42);
            lblRowCount.Name = "lblRowCount";
            lblRowCount.Size = new Size(740, 16);
            lblRowCount.TabIndex = 1;
            lblRowCount.Text = "Total row count:";
            // 
            // lblFilePath
            // 
            lblFilePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblFilePath.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblFilePath.Location = new Point(6, 22);
            lblFilePath.Margin = new Padding(3, 0, 3, 4);
            lblFilePath.Name = "lblFilePath";
            lblFilePath.Size = new Size(740, 15);
            lblFilePath.TabIndex = 0;
            lblFilePath.Text = "File path:";
            // 
            // dgvRawData
            // 
            dgvRawData.AllowUserToAddRows = false;
            dgvRawData.AllowUserToDeleteRows = false;
            dgvRawData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRawData.BackgroundColor = SystemColors.Window;
            dgvRawData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRawData.Location = new Point(16, 102);
            dgvRawData.Margin = new Padding(0);
            dgvRawData.Name = "dgvRawData";
            dgvRawData.RowTemplate.Height = 25;
            dgvRawData.Size = new Size(752, 382);
            dgvRawData.TabIndex = 0;
            // 
            // flowControls
            // 
            flowControls.BackColor = SystemColors.Menu;
            flowControls.Controls.Add(btnConfirm);
            flowControls.Controls.Add(btnCancel);
            flowControls.Dock = DockStyle.Bottom;
            flowControls.FlowDirection = FlowDirection.RightToLeft;
            flowControls.Location = new Point(0, 501);
            flowControls.Name = "flowControls";
            flowControls.Padding = new Padding(16, 16, 0, 16);
            flowControls.Size = new Size(784, 60);
            flowControls.TabIndex = 2;
            // 
            // btnConfirm
            // 
            btnConfirm.AutoSize = true;
            btnConfirm.Location = new Point(693, 16);
            btnConfirm.Margin = new Padding(8, 0, 0, 0);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(75, 28);
            btnConfirm.TabIndex = 0;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.Location = new Point(610, 16);
            btnCancel.Margin = new Padding(0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 28);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmAddBatchEmployees
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Window;
            ClientSize = new Size(784, 561);
            Controls.Add(pnlMain);
            Controls.Add(flowControls);
            Controls.Add(pnlLine1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            MinimumSize = new Size(800, 600);
            Name = "frmAddBatchEmployees";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Data from Excel file";
            pnlMain.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRawData).EndInit();
            flowControls.ResumeLayout(false);
            flowControls.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLine1;
        private Panel pnlMain;
        private FlowLayoutPanel flowControls;
        private DataGridView dgvRawData;
        private Button btnConfirm;
        private Button btnCancel;
        private GroupBox groupBox1;
        private Label lblRowCount;
        private Label lblFilePath;
    }
}