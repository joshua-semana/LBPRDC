namespace LBPRDC.Source.Views.Billing
{
    partial class ExportEmployeeSelectionForm
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
            pnlFooter = new Panel();
            flowActions = new FlowLayoutPanel();
            btnContinue = new Button();
            btnCancel = new Button();
            pnlBody = new Panel();
            panel3 = new Panel();
            pnlLeftContainer = new Panel();
            flowLeftList = new FlowLayoutPanel();
            cmbDepartment = new ComboBox();
            label29 = new Label();
            lblDescription = new Label();
            pnlLine2 = new Panel();
            panel1 = new Panel();
            lblTitle = new Label();
            btnSelectAll = new Button();
            pnlFooter.SuspendLayout();
            flowActions.SuspendLayout();
            pnlBody.SuspendLayout();
            pnlLeftContainer.SuspendLayout();
            pnlLine2.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLine1
            // 
            pnlLine1.BorderStyle = BorderStyle.FixedSingle;
            pnlLine1.Dock = DockStyle.Top;
            pnlLine1.Location = new Point(0, 0);
            pnlLine1.Name = "pnlLine1";
            pnlLine1.Size = new Size(695, 1);
            pnlLine1.TabIndex = 0;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = SystemColors.Control;
            pnlFooter.Controls.Add(flowActions);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 656);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(695, 46);
            pnlFooter.TabIndex = 1;
            // 
            // flowActions
            // 
            flowActions.Controls.Add(btnContinue);
            flowActions.Controls.Add(btnCancel);
            flowActions.Dock = DockStyle.Right;
            flowActions.FlowDirection = FlowDirection.RightToLeft;
            flowActions.Location = new Point(502, 0);
            flowActions.Name = "flowActions";
            flowActions.Padding = new Padding(16, 9, 0, 0);
            flowActions.Size = new Size(193, 46);
            flowActions.TabIndex = 8;
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
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.Location = new Point(19, 9);
            btnCancel.Margin = new Padding(8, 0, 0, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 28);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(btnSelectAll);
            pnlBody.Controls.Add(panel3);
            pnlBody.Controls.Add(pnlLeftContainer);
            pnlBody.Controls.Add(cmbDepartment);
            pnlBody.Controls.Add(label29);
            pnlBody.Controls.Add(lblDescription);
            pnlBody.Controls.Add(pnlLine2);
            pnlBody.Controls.Add(lblTitle);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 1);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(16);
            pnlBody.Size = new Size(695, 655);
            pnlBody.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel3.BackColor = SystemColors.Control;
            panel3.Location = new Point(375, 144);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(302, 495);
            panel3.TabIndex = 27;
            // 
            // pnlLeftContainer
            // 
            pnlLeftContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlLeftContainer.AutoScroll = true;
            pnlLeftContainer.BackColor = SystemColors.Control;
            pnlLeftContainer.Controls.Add(flowLeftList);
            pnlLeftContainer.Location = new Point(16, 144);
            pnlLeftContainer.Margin = new Padding(0);
            pnlLeftContainer.Name = "pnlLeftContainer";
            pnlLeftContainer.Size = new Size(302, 495);
            pnlLeftContainer.TabIndex = 26;
            // 
            // flowLeftList
            // 
            flowLeftList.AutoSize = true;
            flowLeftList.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLeftList.FlowDirection = FlowDirection.TopDown;
            flowLeftList.Location = new Point(0, 0);
            flowLeftList.Margin = new Padding(0);
            flowLeftList.Name = "flowLeftList";
            flowLeftList.Padding = new Padding(8, 8, 0, 0);
            flowLeftList.Size = new Size(8, 8);
            flowLeftList.TabIndex = 0;
            // 
            // cmbDepartment
            // 
            cmbDepartment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartment.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.Location = new Point(16, 104);
            cmbDepartment.Margin = new Padding(0, 0, 4, 16);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(215, 26);
            cmbDepartment.TabIndex = 25;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label29.Location = new Point(16, 84);
            label29.Margin = new Padding(0, 0, 0, 4);
            label29.Name = "label29";
            label29.Size = new Size(88, 16);
            label29.TabIndex = 24;
            label29.Text = "Departments";
            // 
            // lblDescription
            // 
            lblDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblDescription.ForeColor = SystemColors.GrayText;
            lblDescription.Location = new Point(16, 60);
            lblDescription.Margin = new Padding(0, 0, 0, 8);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(318, 16);
            lblDescription.TabIndex = 23;
            lblDescription.Text = "You can select the employees you want to export.";
            // 
            // pnlLine2
            // 
            pnlLine2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLine2.BorderStyle = BorderStyle.FixedSingle;
            pnlLine2.Controls.Add(panel1);
            pnlLine2.Location = new Point(16, 43);
            pnlLine2.Margin = new Padding(0, 0, 0, 16);
            pnlLine2.Name = "pnlLine2";
            pnlLine2.Size = new Size(663, 1);
            pnlLine2.TabIndex = 22;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(-1, 0);
            panel1.Margin = new Padding(0, 0, 0, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(1391, 1);
            panel1.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(16, 16);
            lblTitle.Margin = new Padding(0, 0, 0, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(160, 19);
            lblTitle.TabIndex = 21;
            lblTitle.Text = "Employee Selection";
            // 
            // btnSelectAll
            // 
            btnSelectAll.AutoSize = true;
            btnSelectAll.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSelectAll.Location = new Point(243, 103);
            btnSelectAll.Margin = new Padding(8, 0, 0, 0);
            btnSelectAll.Name = "btnSelectAll";
            btnSelectAll.Size = new Size(75, 28);
            btnSelectAll.TabIndex = 28;
            btnSelectAll.Text = "Select All";
            btnSelectAll.UseVisualStyleBackColor = true;
            btnSelectAll.Click += btnSelectAll_Click;
            // 
            // ExportEmployeeSelectionForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(695, 702);
            ControlBox = false;
            Controls.Add(pnlBody);
            Controls.Add(pnlFooter);
            Controls.Add(pnlLine1);
            Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "ExportEmployeeSelectionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Export";
            Load += ExportEmployeeSelectionForm_Load;
            pnlFooter.ResumeLayout(false);
            flowActions.ResumeLayout(false);
            flowActions.PerformLayout();
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            pnlLeftContainer.ResumeLayout(false);
            pnlLeftContainer.PerformLayout();
            pnlLine2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLine1;
        private Panel pnlFooter;
        private Panel pnlBody;
        private Label lblDescription;
        private Panel pnlLine2;
        private Panel panel1;
        private Label lblTitle;
        private ComboBox cmbDepartment;
        private Label label29;
        private Panel pnlLeftContainer;
        private Panel panel3;
        private FlowLayoutPanel flowLeftList;
        private FlowLayoutPanel flowActions;
        private Button btnContinue;
        private Button btnCancel;
        private Button btnSelectAll;
    }
}