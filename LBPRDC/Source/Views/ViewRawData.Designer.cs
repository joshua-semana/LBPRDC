namespace LBPRDC.Source.Views
{
    partial class frmViewRawData
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
            dgvRawData = new DataGridView();
            flowControls = new FlowLayoutPanel();
            btnConfirm = new Button();
            btnCancel = new Button();
            pnlMain.SuspendLayout();
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
            pnlLine1.Size = new Size(1264, 1);
            pnlLine1.TabIndex = 0;
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(dgvRawData);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 1);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(16);
            pnlMain.Size = new Size(1264, 620);
            pnlMain.TabIndex = 1;
            // 
            // dgvRawData
            // 
            dgvRawData.AllowUserToAddRows = false;
            dgvRawData.AllowUserToDeleteRows = false;
            dgvRawData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRawData.BackgroundColor = SystemColors.Window;
            dgvRawData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRawData.Location = new Point(16, 16);
            dgvRawData.Margin = new Padding(0);
            dgvRawData.Name = "dgvRawData";
            dgvRawData.RowTemplate.Height = 25;
            dgvRawData.Size = new Size(1232, 588);
            dgvRawData.TabIndex = 0;
            // 
            // flowControls
            // 
            flowControls.BackColor = SystemColors.Menu;
            flowControls.Controls.Add(btnConfirm);
            flowControls.Controls.Add(btnCancel);
            flowControls.Dock = DockStyle.Bottom;
            flowControls.FlowDirection = FlowDirection.RightToLeft;
            flowControls.Location = new Point(0, 621);
            flowControls.Name = "flowControls";
            flowControls.Padding = new Padding(16, 16, 0, 16);
            flowControls.Size = new Size(1264, 60);
            flowControls.TabIndex = 2;
            // 
            // btnConfirm
            // 
            btnConfirm.AutoSize = true;
            btnConfirm.Location = new Point(1173, 16);
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
            btnCancel.Location = new Point(1090, 16);
            btnCancel.Margin = new Padding(0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 28);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmViewRawData
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1264, 681);
            Controls.Add(pnlMain);
            Controls.Add(flowControls);
            Controls.Add(pnlLine1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            MinimumSize = new Size(800, 600);
            Name = "frmViewRawData";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Data from Excel file";
            pnlMain.ResumeLayout(false);
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
    }
}