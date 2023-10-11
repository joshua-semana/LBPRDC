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
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            dgvEmployees = new DataGridView();
            groupBox1 = new GroupBox();
            btnSearch = new Button();
            txtSearch = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(16, 16);
            label1.Margin = new Padding(0, 0, 0, 12);
            label1.Name = "label1";
            label1.Size = new Size(139, 29);
            label1.TabIndex = 0;
            label1.Text = "Employees";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = SystemColors.Menu;
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(0, 569);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1213, 60);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvEmployees);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(16);
            panel1.Size = new Size(1213, 569);
            panel1.TabIndex = 2;
            // 
            // dgvEmployees
            // 
            dgvEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvEmployees.BackgroundColor = SystemColors.Window;
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Location = new Point(16, 140);
            dgvEmployees.Margin = new Padding(0);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.RowTemplate.Height = 25;
            dgvEmployees.Size = new Size(1181, 413);
            dgvEmployees.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(txtSearch);
            groupBox1.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(16, 57);
            groupBox1.Margin = new Padding(0, 0, 0, 16);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(8);
            groupBox1.Size = new Size(1181, 67);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tools";
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
            Controls.Add(flowLayoutPanel1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MinimumSize = new Size(733, 509);
            Name = "ucEmployees";
            Size = new Size(1213, 629);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private GroupBox groupBox1;
        private DataGridView dgvEmployees;
        private TextBox txtSearch;
        private Button btnSearch;
    }
}
