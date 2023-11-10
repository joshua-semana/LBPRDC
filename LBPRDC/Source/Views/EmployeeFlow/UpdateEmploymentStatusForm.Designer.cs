namespace LBPRDC.Source.Views.EmployeeFlow
{
    partial class UpdateEmploymentStatusForm
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
            flowControls = new FlowLayoutPanel();
            btnUpdate = new Button();
            btnCancel = new Button();
            panel1 = new Panel();
            label2 = new Label();
            groupBox1 = new GroupBox();
            label27 = new Label();
            txtRemarks = new TextBox();
            cmbEmploymentStatus = new ComboBox();
            label15 = new Label();
            label3 = new Label();
            grpPersonalData = new GroupBox();
            txtCurrentEmploymentStatus = new TextBox();
            label4 = new Label();
            txtFullName = new TextBox();
            label10 = new Label();
            txtEmployeeID = new TextBox();
            label1 = new Label();
            flowControls.SuspendLayout();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            grpPersonalData.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLine1
            // 
            pnlLine1.BorderStyle = BorderStyle.FixedSingle;
            pnlLine1.Dock = DockStyle.Top;
            pnlLine1.Location = new Point(0, 0);
            pnlLine1.Name = "pnlLine1";
            pnlLine1.Size = new Size(655, 1);
            pnlLine1.TabIndex = 0;
            // 
            // flowControls
            // 
            flowControls.BackColor = SystemColors.Menu;
            flowControls.Controls.Add(btnUpdate);
            flowControls.Controls.Add(btnCancel);
            flowControls.Dock = DockStyle.Bottom;
            flowControls.FlowDirection = FlowDirection.RightToLeft;
            flowControls.Location = new Point(0, 277);
            flowControls.Name = "flowControls";
            flowControls.Padding = new Padding(15, 16, 0, 16);
            flowControls.Size = new Size(655, 60);
            flowControls.TabIndex = 5;
            // 
            // btnUpdate
            // 
            btnUpdate.AutoSize = true;
            btnUpdate.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpdate.Location = new Point(565, 16);
            btnUpdate.Margin = new Padding(8, 0, 0, 0);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 28);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Save";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.Location = new Point(482, 16);
            btnCancel.Margin = new Padding(0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 28);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(grpPersonalData);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 1);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(16);
            panel1.Size = new Size(655, 276);
            panel1.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(233, 16);
            label2.Margin = new Padding(0, 0, 0, 16);
            label2.Name = "label2";
            label2.Size = new Size(189, 19);
            label2.TabIndex = 23;
            label2.Text = "EMPLOYMENT STATUS";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox1.Controls.Add(label27);
            groupBox1.Controls.Add(txtRemarks);
            groupBox1.Controls.Add(cmbEmploymentStatus);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(16, 155);
            groupBox1.Margin = new Padding(0, 0, 0, 16);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 8, 3, 3);
            groupBox1.Size = new Size(623, 97);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "New Information";
            // 
            // label27
            // 
            label27.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label27.AutoSize = true;
            label27.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label27.ForeColor = Color.Red;
            label27.Location = new Point(130, 25);
            label27.Margin = new Padding(0, 0, 0, 4);
            label27.Name = "label27";
            label27.Size = new Size(14, 18);
            label27.TabIndex = 32;
            label27.Text = "*";
            // 
            // txtRemarks
            // 
            txtRemarks.AccessibleName = "Remarks";
            txtRemarks.Location = new Point(213, 50);
            txtRemarks.Margin = new Padding(6, 3, 3, 16);
            txtRemarks.MaxLength = 100;
            txtRemarks.Name = "txtRemarks";
            txtRemarks.Size = new Size(400, 26);
            txtRemarks.TabIndex = 30;
            // 
            // cmbEmploymentStatus
            // 
            cmbEmploymentStatus.AccessibleName = "Employment Status";
            cmbEmploymentStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmploymentStatus.FormattingEnabled = true;
            cmbEmploymentStatus.Location = new Point(10, 50);
            cmbEmploymentStatus.Margin = new Padding(3, 3, 3, 16);
            cmbEmploymentStatus.Name = "cmbEmploymentStatus";
            cmbEmploymentStatus.Size = new Size(197, 26);
            cmbEmploymentStatus.TabIndex = 29;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(209, 27);
            label15.Margin = new Padding(3, 0, 3, 4);
            label15.Name = "label15";
            label15.Size = new Size(63, 16);
            label15.TabIndex = 31;
            label15.Text = "Remarks";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(6, 27);
            label3.Margin = new Padding(3, 0, 0, 4);
            label3.Name = "label3";
            label3.Size = new Size(128, 16);
            label3.TabIndex = 28;
            label3.Text = "Employment Status";
            // 
            // grpPersonalData
            // 
            grpPersonalData.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            grpPersonalData.Controls.Add(txtCurrentEmploymentStatus);
            grpPersonalData.Controls.Add(label4);
            grpPersonalData.Controls.Add(txtFullName);
            grpPersonalData.Controls.Add(label10);
            grpPersonalData.Controls.Add(txtEmployeeID);
            grpPersonalData.Controls.Add(label1);
            grpPersonalData.Location = new Point(16, 42);
            grpPersonalData.Margin = new Padding(0, 0, 0, 16);
            grpPersonalData.Name = "grpPersonalData";
            grpPersonalData.Padding = new Padding(3, 8, 3, 3);
            grpPersonalData.Size = new Size(623, 97);
            grpPersonalData.TabIndex = 4;
            grpPersonalData.TabStop = false;
            grpPersonalData.Text = "Employee Information";
            // 
            // txtCurrentEmploymentStatus
            // 
            txtCurrentEmploymentStatus.AccessibleName = "Current Employment Status";
            txtCurrentEmploymentStatus.Location = new Point(416, 50);
            txtCurrentEmploymentStatus.Margin = new Padding(3, 3, 3, 16);
            txtCurrentEmploymentStatus.MaxLength = 50;
            txtCurrentEmploymentStatus.Name = "txtCurrentEmploymentStatus";
            txtCurrentEmploymentStatus.ReadOnly = true;
            txtCurrentEmploymentStatus.Size = new Size(197, 26);
            txtCurrentEmploymentStatus.TabIndex = 14;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(412, 27);
            label4.Margin = new Padding(3, 0, 3, 4);
            label4.Name = "label4";
            label4.Size = new Size(180, 16);
            label4.TabIndex = 13;
            label4.Text = "Current Employment Status";
            // 
            // txtFullName
            // 
            txtFullName.AccessibleName = "Full Name";
            txtFullName.Location = new Point(213, 50);
            txtFullName.Margin = new Padding(3, 3, 3, 16);
            txtFullName.MaxLength = 50;
            txtFullName.Name = "txtFullName";
            txtFullName.ReadOnly = true;
            txtFullName.Size = new Size(197, 26);
            txtFullName.TabIndex = 10;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(209, 27);
            label10.Margin = new Padding(3, 0, 3, 4);
            label10.Name = "label10";
            label10.Size = new Size(70, 16);
            label10.TabIndex = 9;
            label10.Text = "Full Name";
            // 
            // txtEmployeeID
            // 
            txtEmployeeID.AccessibleName = "Employee ID";
            txtEmployeeID.Location = new Point(10, 50);
            txtEmployeeID.Margin = new Padding(7, 3, 3, 16);
            txtEmployeeID.MaxLength = 50;
            txtEmployeeID.Name = "txtEmployeeID";
            txtEmployeeID.ReadOnly = true;
            txtEmployeeID.Size = new Size(197, 26);
            txtEmployeeID.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(6, 27);
            label1.Margin = new Padding(3, 0, 3, 4);
            label1.Name = "label1";
            label1.Size = new Size(20, 16);
            label1.TabIndex = 0;
            label1.Text = "ID";
            // 
            // UpdateEmploymentStatusForm
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(655, 337);
            Controls.Add(panel1);
            Controls.Add(flowControls);
            Controls.Add(pnlLine1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UpdateEmploymentStatusForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Update";
            Load += UpdateEmploymentStatusForm_Load;
            flowControls.ResumeLayout(false);
            flowControls.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            grpPersonalData.ResumeLayout(false);
            grpPersonalData.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLine1;
        private FlowLayoutPanel flowControls;
        private Button btnUpdate;
        private Button btnCancel;
        private Panel panel1;
        private GroupBox grpPersonalData;
        private TextBox txtCurrentEmploymentStatus;
        private Label label4;
        private TextBox txtFullName;
        private Label label10;
        private TextBox txtEmployeeID;
        private Label label1;
        private GroupBox groupBox1;
        private TextBox txtRemarks;
        private ComboBox cmbEmploymentStatus;
        private Label label15;
        private Label label3;
        private Label label27;
        private Label label2;
    }
}