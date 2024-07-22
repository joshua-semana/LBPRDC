namespace LBPRDC.Source.Views.Categories
{
    partial class PermissionsForm
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
            pnlFooter = new Panel();
            flowFooterActions = new FlowLayoutPanel();
            btnSave = new Button();
            btnCancel = new Button();
            flowPermissions = new FlowLayoutPanel();
            label1 = new Label();
            pnlLine2 = new Panel();
            label3 = new Label();
            panel1 = new Panel();
            label2 = new Label();
            cmbUserRoles = new ComboBox();
            pnlFooter.SuspendLayout();
            flowFooterActions.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = SystemColors.Control;
            pnlFooter.Controls.Add(flowFooterActions);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 398);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(363, 60);
            pnlFooter.TabIndex = 6;
            // 
            // flowFooterActions
            // 
            flowFooterActions.Controls.Add(btnSave);
            flowFooterActions.Controls.Add(btnCancel);
            flowFooterActions.Dock = DockStyle.Right;
            flowFooterActions.FlowDirection = FlowDirection.RightToLeft;
            flowFooterActions.Location = new Point(120, 0);
            flowFooterActions.Name = "flowFooterActions";
            flowFooterActions.Padding = new Padding(15, 16, 0, 16);
            flowFooterActions.Size = new Size(243, 60);
            flowFooterActions.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Location = new Point(153, 16);
            btnSave.Margin = new Padding(8, 0, 0, 0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 28);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.Location = new Point(70, 16);
            btnCancel.Margin = new Padding(8, 0, 0, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 28);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // flowPermissions
            // 
            flowPermissions.AutoScroll = true;
            flowPermissions.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowPermissions.FlowDirection = FlowDirection.TopDown;
            flowPermissions.Location = new Point(16, 114);
            flowPermissions.Name = "flowPermissions";
            flowPermissions.Size = new Size(347, 265);
            flowPermissions.TabIndex = 2;
            flowPermissions.WrapContents = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 79);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 8, 4, 8);
            label1.Size = new Size(133, 32);
            label1.TabIndex = 1;
            label1.Text = "List of Permissions:";
            // 
            // pnlLine2
            // 
            pnlLine2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLine2.BorderStyle = BorderStyle.FixedSingle;
            pnlLine2.Location = new Point(16, 40);
            pnlLine2.Margin = new Padding(0, 0, 0, 8);
            pnlLine2.Name = "pnlLine2";
            pnlLine2.Size = new Size(331, 1);
            pnlLine2.TabIndex = 32;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(16, 16);
            label3.Margin = new Padding(0, 0, 0, 8);
            label3.Name = "label3";
            label3.Size = new Size(179, 16);
            label3.TabIndex = 31;
            label3.Text = "Edit of User Permissions";
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cmbUserRoles);
            panel1.Controls.Add(pnlLine2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(flowPermissions);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(16);
            panel1.Size = new Size(363, 398);
            panel1.TabIndex = 33;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 56);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(69, 16);
            label2.TabIndex = 2;
            label2.Text = "User Role";
            // 
            // cmbUserRoles
            // 
            cmbUserRoles.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUserRoles.FormattingEnabled = true;
            cmbUserRoles.Location = new Point(92, 52);
            cmbUserRoles.Name = "cmbUserRoles";
            cmbUserRoles.Size = new Size(255, 24);
            cmbUserRoles.TabIndex = 33;
            cmbUserRoles.SelectedIndexChanged += cmbUserRoles_SelectedIndexChanged;
            // 
            // PermissionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(363, 458);
            Controls.Add(panel1);
            Controls.Add(pnlFooter);
            Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            MaximizeBox = false;
            Name = "PermissionsForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "User Permissions";
            Load += PermissionsForm_Load;
            pnlFooter.ResumeLayout(false);
            flowFooterActions.ResumeLayout(false);
            flowFooterActions.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlFooter;
        private FlowLayoutPanel flowFooterActions;
        private Button btnSave;
        private Button btnCancel;
        private FlowLayoutPanel flowPermissions;
        private Label label1;
        private Panel pnlLine2;
        private Label label3;
        private Panel panel1;
        private ComboBox cmbUserRoles;
        private Label label2;
    }
}