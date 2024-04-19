namespace LBPRDC.Source.Views.Billing
{
    partial class BillingInformationForm
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
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnConfirm = new Button();
            btnCancel = new Button();
            pnlBody = new Panel();
            pnlEquipmentsGroup = new Panel();
            chkIncludeEquipments = new CheckBox();
            txtEquipmentsBilledValue = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label4 = new Label();
            txtOfficerPosition = new TextBox();
            label3 = new Label();
            txtOfficerName = new TextBox();
            label2 = new Label();
            txtDescription = new TextBox();
            pnlLine2 = new Panel();
            panel1 = new Panel();
            label1 = new Label();
            pnlFooter.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            pnlBody.SuspendLayout();
            pnlEquipmentsGroup.SuspendLayout();
            pnlLine2.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLine1
            // 
            pnlLine1.BorderStyle = BorderStyle.FixedSingle;
            pnlLine1.Dock = DockStyle.Top;
            pnlLine1.Location = new Point(0, 0);
            pnlLine1.Name = "pnlLine1";
            pnlLine1.Size = new Size(322, 1);
            pnlLine1.TabIndex = 0;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = SystemColors.Control;
            pnlFooter.Controls.Add(flowLayoutPanel2);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 307);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(322, 46);
            pnlFooter.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(btnConfirm);
            flowLayoutPanel2.Controls.Add(btnCancel);
            flowLayoutPanel2.Dock = DockStyle.Right;
            flowLayoutPanel2.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel2.Location = new Point(131, 0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Padding = new Padding(16, 9, 0, 0);
            flowLayoutPanel2.Size = new Size(191, 46);
            flowLayoutPanel2.TabIndex = 9;
            // 
            // btnConfirm
            // 
            btnConfirm.AutoSize = true;
            btnConfirm.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnConfirm.Location = new Point(100, 9);
            btnConfirm.Margin = new Padding(8, 0, 0, 0);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(75, 28);
            btnConfirm.TabIndex = 10;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.Location = new Point(17, 9);
            btnCancel.Margin = new Padding(8, 0, 0, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 28);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(pnlEquipmentsGroup);
            pnlBody.Controls.Add(label7);
            pnlBody.Controls.Add(label6);
            pnlBody.Controls.Add(label4);
            pnlBody.Controls.Add(txtOfficerPosition);
            pnlBody.Controls.Add(label3);
            pnlBody.Controls.Add(txtOfficerName);
            pnlBody.Controls.Add(label2);
            pnlBody.Controls.Add(txtDescription);
            pnlBody.Controls.Add(pnlLine2);
            pnlBody.Controls.Add(label1);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 1);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(16);
            pnlBody.Size = new Size(322, 306);
            pnlBody.TabIndex = 2;
            // 
            // pnlEquipmentsGroup
            // 
            pnlEquipmentsGroup.AutoSize = true;
            pnlEquipmentsGroup.Controls.Add(chkIncludeEquipments);
            pnlEquipmentsGroup.Controls.Add(txtEquipmentsBilledValue);
            pnlEquipmentsGroup.Location = new Point(16, 246);
            pnlEquipmentsGroup.Margin = new Padding(0);
            pnlEquipmentsGroup.Name = "pnlEquipmentsGroup";
            pnlEquipmentsGroup.Size = new Size(294, 46);
            pnlEquipmentsGroup.TabIndex = 25;
            // 
            // chkIncludeEquipments
            // 
            chkIncludeEquipments.AutoSize = true;
            chkIncludeEquipments.Location = new Point(3, 0);
            chkIncludeEquipments.Name = "chkIncludeEquipments";
            chkIncludeEquipments.Size = new Size(240, 20);
            chkIncludeEquipments.TabIndex = 9;
            chkIncludeEquipments.Text = "Include supplies and equipments?";
            chkIncludeEquipments.UseVisualStyleBackColor = true;
            chkIncludeEquipments.CheckedChanged += chkIncludeEquipments_CheckedChanged;
            // 
            // txtEquipmentsBilledValue
            // 
            txtEquipmentsBilledValue.AccessibleName = "Supplies and Equipments Value";
            txtEquipmentsBilledValue.Enabled = false;
            txtEquipmentsBilledValue.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtEquipmentsBilledValue.Location = new Point(0, 20);
            txtEquipmentsBilledValue.Margin = new Padding(0);
            txtEquipmentsBilledValue.MaxLength = 100;
            txtEquipmentsBilledValue.Name = "txtEquipmentsBilledValue";
            txtEquipmentsBilledValue.PlaceholderText = "Enter Amount";
            txtEquipmentsBilledValue.Size = new Size(294, 26);
            txtEquipmentsBilledValue.TabIndex = 8;
            txtEquipmentsBilledValue.KeyPress += ValidateInputIfNumber_KeyPress;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.Red;
            label7.Location = new Point(125, 184);
            label7.Margin = new Padding(0);
            label7.Name = "label7";
            label7.Size = new Size(12, 16);
            label7.TabIndex = 24;
            label7.Text = "*";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.Red;
            label6.Location = new Point(169, 122);
            label6.Margin = new Padding(0);
            label6.Name = "label6";
            label6.Size = new Size(12, 16);
            label6.TabIndex = 23;
            label6.Text = "*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(16, 184);
            label4.Margin = new Padding(0, 0, 0, 4);
            label4.Name = "label4";
            label4.Size = new Size(113, 16);
            label4.TabIndex = 11;
            label4.Text = "Officer's Position";
            // 
            // txtOfficerPosition
            // 
            txtOfficerPosition.AccessibleName = "Officer's Position";
            txtOfficerPosition.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtOfficerPosition.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtOfficerPosition.Location = new Point(16, 204);
            txtOfficerPosition.Margin = new Padding(0, 0, 0, 16);
            txtOfficerPosition.Name = "txtOfficerPosition";
            txtOfficerPosition.Size = new Size(290, 26);
            txtOfficerPosition.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(16, 122);
            label3.Margin = new Padding(0, 0, 0, 4);
            label3.Name = "label3";
            label3.Size = new Size(157, 16);
            label3.TabIndex = 9;
            label3.Text = "Officer-in-Charge Name";
            // 
            // txtOfficerName
            // 
            txtOfficerName.AccessibleName = "Officer-in-Charge Name";
            txtOfficerName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtOfficerName.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtOfficerName.Location = new Point(16, 142);
            txtOfficerName.Margin = new Padding(0, 0, 0, 16);
            txtOfficerName.Name = "txtOfficerName";
            txtOfficerName.Size = new Size(290, 26);
            txtOfficerName.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(16, 60);
            label2.Margin = new Padding(0, 0, 0, 4);
            label2.Name = "label2";
            label2.Size = new Size(78, 16);
            label2.TabIndex = 7;
            label2.Text = "Description";
            // 
            // txtDescription
            // 
            txtDescription.AccessibleName = "Description";
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDescription.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtDescription.Location = new Point(16, 80);
            txtDescription.Margin = new Padding(0, 0, 0, 16);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(290, 26);
            txtDescription.TabIndex = 6;
            // 
            // pnlLine2
            // 
            pnlLine2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLine2.BorderStyle = BorderStyle.FixedSingle;
            pnlLine2.Controls.Add(panel1);
            pnlLine2.Location = new Point(16, 43);
            pnlLine2.Margin = new Padding(0, 0, 0, 16);
            pnlLine2.Name = "pnlLine2";
            pnlLine2.Size = new Size(290, 1);
            pnlLine2.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(-1, 0);
            panel1.Margin = new Padding(0, 0, 0, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(512, 1);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(16, 16);
            label1.Margin = new Padding(0, 0, 0, 8);
            label1.Name = "label1";
            label1.Size = new Size(148, 19);
            label1.TabIndex = 4;
            label1.Text = "Billing Information";
            // 
            // BillingInformationForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(322, 353);
            ControlBox = false;
            Controls.Add(pnlBody);
            Controls.Add(pnlFooter);
            Controls.Add(pnlLine1);
            Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "BillingInformationForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Billing Information";
            Load += BillingInformationForm_Load;
            pnlFooter.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            pnlEquipmentsGroup.ResumeLayout(false);
            pnlEquipmentsGroup.PerformLayout();
            pnlLine2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLine1;
        private Panel pnlFooter;
        private Panel pnlBody;
        private Label label2;
        private TextBox txtDescription;
        private Panel pnlLine2;
        private Panel panel1;
        private Label label1;
        private Label label3;
        private TextBox txtOfficerName;
        private Label label4;
        private TextBox txtOfficerPosition;
        private Label label5;
        private Label label7;
        private Label label6;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button btnConfirm;
        private Button btnCancel;
        private Panel panel3;
        private CheckBox chkIncludeEquipments;
        private TextBox txtEquipmentsBilledValue;
        private Panel pnlEquipmentsGroup;
    }
}