namespace LBPRDC.Source.Views.EmployeeFlow
{
    partial class UpdatePositionForm
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
            label5 = new Label();
            grpNewPositionData = new GroupBox();
            label27 = new Label();
            txtRemarks = new TextBox();
            label11 = new Label();
            dtpEffectiveDate = new DateTimePicker();
            label15 = new Label();
            txtPositionTitle = new TextBox();
            label14 = new Label();
            cmbPosition = new ComboBox();
            label3 = new Label();
            grpPersonalData = new GroupBox();
            txtCurrentPositionTitle = new TextBox();
            label4 = new Label();
            txtCurrentPosition = new TextBox();
            label2 = new Label();
            txtFullName = new TextBox();
            label10 = new Label();
            txtEmployeeID = new TextBox();
            label1 = new Label();
            flowControls.SuspendLayout();
            panel1.SuspendLayout();
            grpNewPositionData.SuspendLayout();
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
            flowControls.Location = new Point(0, 411);
            flowControls.Name = "flowControls";
            flowControls.Padding = new Padding(15, 16, 0, 16);
            flowControls.Size = new Size(655, 60);
            flowControls.TabIndex = 3;
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
            panel1.Controls.Add(label5);
            panel1.Controls.Add(grpNewPositionData);
            panel1.Controls.Add(grpPersonalData);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 1);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(16);
            panel1.Size = new Size(655, 410);
            panel1.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(285, 16);
            label5.Margin = new Padding(0, 0, 0, 16);
            label5.Name = "label5";
            label5.Size = new Size(85, 19);
            label5.TabIndex = 23;
            label5.Text = "POSITION";
            // 
            // grpNewPositionData
            // 
            grpNewPositionData.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            grpNewPositionData.Controls.Add(label27);
            grpNewPositionData.Controls.Add(txtRemarks);
            grpNewPositionData.Controls.Add(label11);
            grpNewPositionData.Controls.Add(dtpEffectiveDate);
            grpNewPositionData.Controls.Add(label15);
            grpNewPositionData.Controls.Add(txtPositionTitle);
            grpNewPositionData.Controls.Add(label14);
            grpNewPositionData.Controls.Add(cmbPosition);
            grpNewPositionData.Controls.Add(label3);
            grpNewPositionData.Location = new Point(16, 220);
            grpNewPositionData.Margin = new Padding(0, 0, 0, 16);
            grpNewPositionData.Name = "grpNewPositionData";
            grpNewPositionData.Padding = new Padding(3, 8, 3, 3);
            grpNewPositionData.Size = new Size(623, 166);
            grpNewPositionData.TabIndex = 11;
            grpNewPositionData.TabStop = false;
            grpNewPositionData.Text = "New Position Information";
            // 
            // label27
            // 
            label27.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label27.AutoSize = true;
            label27.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label27.ForeColor = Color.Red;
            label27.Location = new Point(59, 25);
            label27.Margin = new Padding(0, 0, 0, 4);
            label27.Name = "label27";
            label27.Size = new Size(14, 18);
            label27.TabIndex = 28;
            label27.Text = "*";
            // 
            // txtRemarks
            // 
            txtRemarks.AccessibleName = "Remarks";
            txtRemarks.Location = new Point(10, 115);
            txtRemarks.Margin = new Padding(6, 3, 3, 16);
            txtRemarks.MaxLength = 100;
            txtRemarks.Name = "txtRemarks";
            txtRemarks.Size = new Size(400, 26);
            txtRemarks.TabIndex = 3;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(412, 92);
            label11.Margin = new Padding(3, 0, 3, 4);
            label11.Name = "label11";
            label11.Size = new Size(95, 16);
            label11.TabIndex = 25;
            label11.Text = "Effective Date";
            // 
            // dtpEffectiveDate
            // 
            dtpEffectiveDate.AccessibleName = "Effective Date";
            dtpEffectiveDate.CustomFormat = "MM-dd-yyy";
            dtpEffectiveDate.Format = DateTimePickerFormat.Custom;
            dtpEffectiveDate.Location = new Point(416, 115);
            dtpEffectiveDate.Margin = new Padding(3, 3, 3, 16);
            dtpEffectiveDate.Name = "dtpEffectiveDate";
            dtpEffectiveDate.Size = new Size(197, 26);
            dtpEffectiveDate.TabIndex = 4;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(6, 92);
            label15.Margin = new Padding(3, 0, 3, 4);
            label15.Name = "label15";
            label15.Size = new Size(63, 16);
            label15.TabIndex = 27;
            label15.Text = "Remarks";
            // 
            // txtPositionTitle
            // 
            txtPositionTitle.AccessibleName = "Position Title";
            txtPositionTitle.Location = new Point(416, 50);
            txtPositionTitle.Margin = new Padding(3, 3, 3, 16);
            txtPositionTitle.MaxLength = 50;
            txtPositionTitle.Name = "txtPositionTitle";
            txtPositionTitle.Size = new Size(197, 26);
            txtPositionTitle.TabIndex = 2;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(412, 27);
            label14.Margin = new Padding(3, 0, 3, 4);
            label14.Name = "label14";
            label14.Size = new Size(87, 16);
            label14.TabIndex = 23;
            label14.Text = "Position Title";
            // 
            // cmbPosition
            // 
            cmbPosition.AccessibleName = "Position";
            cmbPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPosition.FormattingEnabled = true;
            cmbPosition.Location = new Point(10, 50);
            cmbPosition.Margin = new Padding(3, 3, 3, 16);
            cmbPosition.Name = "cmbPosition";
            cmbPosition.Size = new Size(400, 26);
            cmbPosition.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(6, 27);
            label3.Margin = new Padding(3, 0, 0, 4);
            label3.Name = "label3";
            label3.Size = new Size(57, 16);
            label3.TabIndex = 0;
            label3.Text = "Position";
            // 
            // grpPersonalData
            // 
            grpPersonalData.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            grpPersonalData.Controls.Add(txtCurrentPositionTitle);
            grpPersonalData.Controls.Add(label4);
            grpPersonalData.Controls.Add(txtCurrentPosition);
            grpPersonalData.Controls.Add(label2);
            grpPersonalData.Controls.Add(txtFullName);
            grpPersonalData.Controls.Add(label10);
            grpPersonalData.Controls.Add(txtEmployeeID);
            grpPersonalData.Controls.Add(label1);
            grpPersonalData.Location = new Point(16, 42);
            grpPersonalData.Margin = new Padding(0, 0, 0, 16);
            grpPersonalData.Name = "grpPersonalData";
            grpPersonalData.Padding = new Padding(3, 8, 3, 3);
            grpPersonalData.Size = new Size(623, 162);
            grpPersonalData.TabIndex = 2;
            grpPersonalData.TabStop = false;
            grpPersonalData.Text = "Employee Information";
            // 
            // txtCurrentPositionTitle
            // 
            txtCurrentPositionTitle.AccessibleName = "Current Position Title";
            txtCurrentPositionTitle.Location = new Point(416, 115);
            txtCurrentPositionTitle.Margin = new Padding(7, 3, 3, 16);
            txtCurrentPositionTitle.MaxLength = 50;
            txtCurrentPositionTitle.Name = "txtCurrentPositionTitle";
            txtCurrentPositionTitle.ReadOnly = true;
            txtCurrentPositionTitle.Size = new Size(197, 26);
            txtCurrentPositionTitle.TabIndex = 14;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(412, 92);
            label4.Margin = new Padding(3, 0, 3, 4);
            label4.Name = "label4";
            label4.Size = new Size(87, 16);
            label4.TabIndex = 13;
            label4.Text = "Position Title";
            // 
            // txtCurrentPosition
            // 
            txtCurrentPosition.AccessibleName = "Current Position";
            txtCurrentPosition.Location = new Point(10, 115);
            txtCurrentPosition.Margin = new Padding(3, 3, 3, 16);
            txtCurrentPosition.MaxLength = 50;
            txtCurrentPosition.Name = "txtCurrentPosition";
            txtCurrentPosition.ReadOnly = true;
            txtCurrentPosition.Size = new Size(400, 26);
            txtCurrentPosition.TabIndex = 12;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(6, 92);
            label2.Margin = new Padding(3, 0, 3, 4);
            label2.Name = "label2";
            label2.Size = new Size(109, 16);
            label2.TabIndex = 11;
            label2.Text = "Current Position";
            // 
            // txtFullName
            // 
            txtFullName.AccessibleName = "Full Name";
            txtFullName.Location = new Point(213, 50);
            txtFullName.Margin = new Padding(3, 3, 3, 16);
            txtFullName.MaxLength = 50;
            txtFullName.Name = "txtFullName";
            txtFullName.ReadOnly = true;
            txtFullName.Size = new Size(400, 26);
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
            // UpdatePositionForm
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(655, 471);
            Controls.Add(panel1);
            Controls.Add(flowControls);
            Controls.Add(pnlLine1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UpdatePositionForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Update";
            Load += UpdatePositionForm_Load;
            flowControls.ResumeLayout(false);
            flowControls.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            grpNewPositionData.ResumeLayout(false);
            grpNewPositionData.PerformLayout();
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
        private Label label1;
        private TextBox txtEmployeeID;
        private TextBox txtFullName;
        private Label label10;
        private GroupBox grpNewPositionData;
        private Label label3;
        private ComboBox cmbPosition;
        private TextBox txtPositionTitle;
        private Label label14;
        private Label label11;
        private DateTimePicker dtpEffectiveDate;
        private TextBox txtRemarks;
        private Label label15;
        private TextBox txtCurrentPositionTitle;
        private Label label4;
        private TextBox txtCurrentPosition;
        private Label label2;
        private Label label27;
        private Label label5;
    }
}