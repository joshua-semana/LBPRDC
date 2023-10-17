namespace LBPRDC.Source.Views
{
    partial class ucEmployees
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
            flowControls = new FlowLayoutPanel();
            btnAddBatch = new Button();
            btnAddEmployee = new Button();
            btnEditEmployee = new Button();
            panel1 = new Panel();
            dgvEmployees = new DataGridView();
            groupBox1 = new GroupBox();
            btnSettings = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            flowControls.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // flowControls
            // 
            flowControls.BackColor = SystemColors.Menu;
            flowControls.Controls.Add(btnAddBatch);
            flowControls.Controls.Add(btnAddEmployee);
            flowControls.Controls.Add(btnEditEmployee);
            flowControls.Dock = DockStyle.Bottom;
            flowControls.FlowDirection = FlowDirection.RightToLeft;
            flowControls.Location = new Point(0, 569);
            flowControls.Name = "flowControls";
            flowControls.Padding = new Padding(16, 16, 0, 16);
            flowControls.Size = new Size(1213, 60);
            flowControls.TabIndex = 1;
            // 
            // btnAddBatch
            // 
            btnAddBatch.AutoSize = true;
            btnAddBatch.Location = new Point(1097, 16);
            btnAddBatch.Margin = new Padding(0);
            btnAddBatch.Name = "btnAddBatch";
            btnAddBatch.Size = new Size(100, 28);
            btnAddBatch.TabIndex = 5;
            btnAddBatch.Text = "Add Batch";
            btnAddBatch.UseVisualStyleBackColor = true;
            btnAddBatch.Click += btnAddBatch_Click;
            // 
            // btnAddEmployee
            // 
            btnAddEmployee.AutoSize = true;
            btnAddEmployee.Location = new Point(997, 16);
            btnAddEmployee.Margin = new Padding(0);
            btnAddEmployee.Name = "btnAddEmployee";
            btnAddEmployee.Size = new Size(100, 28);
            btnAddEmployee.TabIndex = 6;
            btnAddEmployee.Text = "Add";
            btnAddEmployee.UseVisualStyleBackColor = true;
            btnAddEmployee.Click += btnAddEmployee_Click;
            // 
            // btnEditEmployee
            // 
            btnEditEmployee.AutoSize = true;
            btnEditEmployee.Location = new Point(897, 16);
            btnEditEmployee.Margin = new Padding(0);
            btnEditEmployee.Name = "btnEditEmployee";
            btnEditEmployee.Size = new Size(100, 28);
            btnEditEmployee.TabIndex = 7;
            btnEditEmployee.Text = "Edit";
            btnEditEmployee.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvEmployees);
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(16, 10, 16, 16);
            panel1.Size = new Size(1213, 569);
            panel1.TabIndex = 2;
            // 
            // dgvEmployees
            // 
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.AllowUserToDeleteRows = false;
            dgvEmployees.AllowUserToOrderColumns = true;
            dgvEmployees.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.Honeydew;
            dataGridViewCellStyle1.SelectionBackColor = Color.SeaGreen;
            dgvEmployees.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvEmployees.BackgroundColor = SystemColors.Window;
            dgvEmployees.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new Padding(0, 2, 0, 2);
            dataGridViewCellStyle2.SelectionBackColor = Color.MediumSeaGreen;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvEmployees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.EditMode = DataGridViewEditMode.EditOnF2;
            dgvEmployees.GridColor = SystemColors.Window;
            dgvEmployees.Location = new Point(16, 93);
            dgvEmployees.Margin = new Padding(0);
            dgvEmployees.MultiSelect = false;
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new Padding(4);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvEmployees.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvEmployees.RowHeadersVisible = false;
            dgvEmployees.RowTemplate.DefaultCellStyle.Padding = new Padding(4);
            dgvEmployees.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgvEmployees.RowTemplate.Height = 37;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.Size = new Size(1181, 460);
            dgvEmployees.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(btnSettings);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(txtSearch);
            groupBox1.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(16, 10);
            groupBox1.Margin = new Padding(0, 0, 0, 16);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(8);
            groupBox1.Size = new Size(1181, 67);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tools";
            // 
            // btnSettings
            // 
            btnSettings.Anchor = AnchorStyles.Right;
            btnSettings.AutoSize = true;
            btnSettings.Location = new Point(1098, 24);
            btnSettings.Margin = new Padding(0);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(75, 26);
            btnSettings.TabIndex = 5;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnSearch
            // 
            btnSearch.AutoSize = true;
            btnSearch.Location = new Point(212, 24);
            btnSearch.Margin = new Padding(0);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 26);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(8, 24);
            txtSearch.Margin = new Padding(0, 0, 4, 0);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 26);
            txtSearch.TabIndex = 0;
            // 
            // ucEmployees
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Window;
            Controls.Add(panel1);
            Controls.Add(flowControls);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MinimumSize = new Size(733, 509);
            Name = "ucEmployees";
            Size = new Size(1213, 629);
            VisibleChanged += ucEmployees_VisibleChanged;
            flowControls.ResumeLayout(false);
            flowControls.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel flowControls;
        private Panel panel1;
        private GroupBox groupBox1;
        private DataGridView dgvEmployees;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnAddBatch;
        private Button btnAddEmployee;
        private Button btnSettings;
        private Button btnEditEmployee;
    }
}
