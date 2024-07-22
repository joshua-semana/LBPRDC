namespace LBPRDC.Source.Views.Accounts
{
    partial class AccountsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlFooter = new Panel();
            flowControls = new FlowLayoutPanel();
            btnAdd = new Button();
            btnEdit = new Button();
            btnReset = new Button();
            panel1 = new Panel();
            lblRowCounter = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            panel2 = new Panel();
            dgvUsers = new DataGridView();
            btnPermissions = new Button();
            pnlFooter.SuspendLayout();
            flowControls.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = SystemColors.Menu;
            pnlFooter.Controls.Add(flowControls);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 569);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1213, 60);
            pnlFooter.TabIndex = 2;
            // 
            // flowControls
            // 
            flowControls.BackColor = SystemColors.Menu;
            flowControls.Controls.Add(btnAdd);
            flowControls.Controls.Add(btnEdit);
            flowControls.Controls.Add(btnPermissions);
            flowControls.Controls.Add(btnReset);
            flowControls.Dock = DockStyle.Right;
            flowControls.FlowDirection = FlowDirection.RightToLeft;
            flowControls.Location = new Point(691, 0);
            flowControls.Name = "flowControls";
            flowControls.Padding = new Padding(23, 16, 0, 16);
            flowControls.Size = new Size(522, 60);
            flowControls.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.AutoSize = true;
            btnAdd.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnAdd.Location = new Point(424, 16);
            btnAdd.Margin = new Padding(8, 0, 0, 0);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 28);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.AutoSize = true;
            btnEdit.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnEdit.Location = new Point(341, 16);
            btnEdit.Margin = new Padding(8, 0, 0, 0);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 28);
            btnEdit.TabIndex = 7;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnReset
            // 
            btnReset.AutoSize = true;
            btnReset.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnReset.Location = new Point(113, 16);
            btnReset.Margin = new Padding(0);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(119, 28);
            btnReset.TabIndex = 8;
            btnReset.Text = "Reset Password";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblRowCounter);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(dgvUsers);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(24, 24, 24, 10);
            panel1.Size = new Size(1213, 569);
            panel1.TabIndex = 3;
            // 
            // lblRowCounter
            // 
            lblRowCounter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblRowCounter.AutoSize = true;
            lblRowCounter.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblRowCounter.ForeColor = SystemColors.GrayText;
            lblRowCounter.Location = new Point(20, 543);
            lblRowCounter.Margin = new Padding(0, 8, 0, 0);
            lblRowCounter.Name = "lblRowCounter";
            lblRowCounter.Size = new Size(45, 16);
            lblRowCounter.TabIndex = 1;
            lblRowCounter.Text = "Count";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(24, 24);
            txtSearch.Margin = new Padding(0, 0, 4, 16);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(215, 26);
            txtSearch.TabIndex = 1;
            txtSearch.KeyUp += txtSearch_KeyUp;
            // 
            // btnSearch
            // 
            btnSearch.AutoSize = true;
            btnSearch.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearch.Location = new Point(247, 23);
            btnSearch.Margin = new Padding(4, 0, 8, 0);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 28);
            btnSearch.TabIndex = 12;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Location = new Point(24, 66);
            panel2.Margin = new Padding(0, 0, 0, 16);
            panel2.Name = "panel2";
            panel2.Size = new Size(1165, 1);
            panel2.TabIndex = 9;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AllowUserToOrderColumns = true;
            dgvUsers.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.SelectionBackColor = Color.SeaGreen;
            dgvUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvUsers.BackgroundColor = SystemColors.Window;
            dgvUsers.BorderStyle = BorderStyle.Fixed3D;
            dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new Padding(0, 2, 0, 2);
            dataGridViewCellStyle2.SelectionBackColor = Color.MediumSeaGreen;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.EditMode = DataGridViewEditMode.EditOnF2;
            dgvUsers.GridColor = SystemColors.Control;
            dgvUsers.Location = new Point(24, 83);
            dgvUsers.Margin = new Padding(0);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new Padding(4);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowTemplate.DefaultCellStyle.Padding = new Padding(4, 8, 4, 8);
            dgvUsers.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgvUsers.RowTemplate.Height = 41;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(1165, 452);
            dgvUsers.TabIndex = 5;
            dgvUsers.VirtualMode = true;
            // 
            // btnPermissions
            // 
            btnPermissions.AutoSize = true;
            btnPermissions.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnPermissions.Location = new Point(240, 16);
            btnPermissions.Margin = new Padding(8, 0, 0, 0);
            btnPermissions.Name = "btnPermissions";
            btnPermissions.Size = new Size(93, 28);
            btnPermissions.TabIndex = 9;
            btnPermissions.Text = "Permissions";
            btnPermissions.UseVisualStyleBackColor = true;
            btnPermissions.Click += btnPermissions_Click;
            // 
            // AccountsControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            Controls.Add(panel1);
            Controls.Add(pnlFooter);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "AccountsControl";
            Size = new Size(1213, 629);
            VisibleChanged += AccountsControl_VisibleChanged;
            pnlFooter.ResumeLayout(false);
            flowControls.ResumeLayout(false);
            flowControls.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlFooter;
        private Panel panel1;
        private DataGridView dgvUsers;
        private Panel panel2;
        private Label lblRowCounter;
        private TextBox txtSearch;
        private FlowLayoutPanel flowControls;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnReset;
        private Button btnSearch;
        private Button btnPermissions;
    }
}
