namespace LBPRDC.Source.Views.EmployeeFlow
{
    partial class UpdateDepartmentLocationForm
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
            panel2 = new Panel();
            label5 = new Label();
            grpNewPositionData = new GroupBox();
            label27 = new Label();
            cmbLocation = new ComboBox();
            txtRemarks = new TextBox();
            label15 = new Label();
            label14 = new Label();
            cmbDepartment = new ComboBox();
            label3 = new Label();
            grpPersonalData = new GroupBox();
            txtCurrentLocation = new TextBox();
            txtCurrentDepartment = new TextBox();
            label4 = new Label();
            label2 = new Label();
            txtFullName = new TextBox();
            label10 = new Label();
            txtEmployeeID = new TextBox();
            label1 = new Label();
            flowControls.SuspendLayout();
            panel2.SuspendLayout();
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
            flowControls.TabIndex = 4;
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
            // panel2
            // 
            panel2.Controls.Add(label5);
            panel2.Controls.Add(grpNewPositionData);
            panel2.Controls.Add(grpPersonalData);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 1);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(16);
            panel2.Size = new Size(655, 410);
            panel2.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(205, 16);
            label5.Margin = new Padding(0, 0, 0, 16);
            label5.Name = "label5";
            label5.Size = new Size(245, 19);
            label5.TabIndex = 23;
            label5.Text = "DEPARTMENT AND LOCATION";
            // 
            // grpNewPositionData
            // 
            grpNewPositionData.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            grpNewPositionData.Controls.Add(label27);
            grpNewPositionData.Controls.Add(cmbLocation);
            grpNewPositionData.Controls.Add(txtRemarks);
            grpNewPositionData.Controls.Add(label15);
            grpNewPositionData.Controls.Add(label14);
            grpNewPositionData.Controls.Add(cmbDepartment);
            grpNewPositionData.Controls.Add(label3);
            grpNewPositionData.Location = new Point(16, 220);
            grpNewPositionData.Margin = new Padding(0, 0, 0, 16);
            grpNewPositionData.Name = "grpNewPositionData";
            grpNewPositionData.Padding = new Padding(3, 8, 3, 3);
            grpNewPositionData.Size = new Size(623, 166);
            grpNewPositionData.TabIndex = 12;
            grpNewPositionData.TabStop = false;
            grpNewPositionData.Text = "New Information";
            // 
            // label27
            // 
            label27.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label27.AutoSize = true;
            label27.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label27.ForeColor = Color.Red;
            label27.Location = new Point(79, 25);
            label27.Margin = new Padding(0, 0, 0, 4);
            label27.Name = "label27";
            label27.Size = new Size(14, 18);
            label27.TabIndex = 29;
            label27.Text = "*";
            // 
            // cmbLocation
            // 
            cmbLocation.AccessibleName = "Location";
            cmbLocation.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLocation.FormattingEnabled = true;
            cmbLocation.Location = new Point(316, 50);
            cmbLocation.Margin = new Padding(3, 3, 3, 16);
            cmbLocation.Name = "cmbLocation";
            cmbLocation.Size = new Size(297, 26);
            cmbLocation.TabIndex = 28;
            // 
            // txtRemarks
            // 
            txtRemarks.AccessibleName = "Remarks";
            txtRemarks.Location = new Point(10, 115);
            txtRemarks.Margin = new Padding(6, 3, 3, 16);
            txtRemarks.MaxLength = 100;
            txtRemarks.Name = "txtRemarks";
            txtRemarks.Size = new Size(603, 26);
            txtRemarks.TabIndex = 3;
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
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(312, 27);
            label14.Margin = new Padding(3, 0, 3, 4);
            label14.Name = "label14";
            label14.Size = new Size(61, 16);
            label14.TabIndex = 23;
            label14.Text = "Location";
            // 
            // cmbDepartment
            // 
            cmbDepartment.AccessibleName = "Department";
            cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.Location = new Point(10, 50);
            cmbDepartment.Margin = new Padding(3, 3, 3, 16);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(300, 26);
            cmbDepartment.TabIndex = 1;
            cmbDepartment.SelectedIndexChanged += cmbDepartment_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(6, 27);
            label3.Margin = new Padding(3, 0, 0, 4);
            label3.Name = "label3";
            label3.Size = new Size(77, 16);
            label3.TabIndex = 0;
            label3.Text = "Deparment";
            // 
            // grpPersonalData
            // 
            grpPersonalData.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            grpPersonalData.Controls.Add(txtCurrentLocation);
            grpPersonalData.Controls.Add(txtCurrentDepartment);
            grpPersonalData.Controls.Add(label4);
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
            grpPersonalData.TabIndex = 3;
            grpPersonalData.TabStop = false;
            grpPersonalData.Text = "Employee Information";
            // 
            // txtCurrentLocation
            // 
            txtCurrentLocation.AccessibleName = "Current Location";
            txtCurrentLocation.Location = new Point(316, 115);
            txtCurrentLocation.Margin = new Padding(7, 3, 3, 16);
            txtCurrentLocation.MaxLength = 50;
            txtCurrentLocation.Name = "txtCurrentLocation";
            txtCurrentLocation.ReadOnly = true;
            txtCurrentLocation.Size = new Size(297, 26);
            txtCurrentLocation.TabIndex = 14;
            // 
            // txtCurrentDepartment
            // 
            txtCurrentDepartment.AccessibleName = "Current Department";
            txtCurrentDepartment.Location = new Point(10, 115);
            txtCurrentDepartment.Margin = new Padding(3, 3, 3, 16);
            txtCurrentDepartment.MaxLength = 50;
            txtCurrentDepartment.Name = "txtCurrentDepartment";
            txtCurrentDepartment.ReadOnly = true;
            txtCurrentDepartment.Size = new Size(300, 26);
            txtCurrentDepartment.TabIndex = 15;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(312, 92);
            label4.Margin = new Padding(3, 0, 3, 4);
            label4.Name = "label4";
            label4.Size = new Size(113, 16);
            label4.TabIndex = 13;
            label4.Text = "Current Location";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(6, 92);
            label2.Margin = new Padding(3, 0, 3, 4);
            label2.Name = "label2";
            label2.Size = new Size(133, 16);
            label2.TabIndex = 11;
            label2.Text = "Current Department";
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
            // UpdateDepartmentLocationForm
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(655, 471);
            Controls.Add(panel2);
            Controls.Add(flowControls);
            Controls.Add(pnlLine1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UpdateDepartmentLocationForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Update";
            Load += UpdateDepartmentLocationForm_Load;
            flowControls.ResumeLayout(false);
            flowControls.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
        private Panel panel2;
        private GroupBox grpPersonalData;
        private TextBox txtCurrentLocation;
        private Label label4;
        private Label label2;
        private TextBox txtFullName;
        private Label label10;
        private TextBox txtEmployeeID;
        private Label label1;
        private TextBox txtCurrentDepartment;
        private GroupBox grpNewPositionData;
        private ComboBox cmbLocation;
        private TextBox txtRemarks;
        private Label label15;
        private Label label14;
        private ComboBox cmbDepartment;
        private Label label3;
        private Label label27;
        private Label label5;
    }
}