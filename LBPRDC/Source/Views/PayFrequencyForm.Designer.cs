namespace LBPRDC.Source.Views
{
    partial class PayFrequencyForm
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
            lblHeader = new Label();
            pnlBody = new Panel();
            flowPayFrequencies = new FlowLayoutPanel();
            label12 = new Label();
            flowControls = new FlowLayoutPanel();
            btnConfirm = new Button();
            btnCancel = new Button();
            pnlBody.SuspendLayout();
            flowControls.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLine1
            // 
            pnlLine1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLine1.BorderStyle = BorderStyle.FixedSingle;
            pnlLine1.Location = new Point(16, 43);
            pnlLine1.Margin = new Padding(0, 0, 0, 16);
            pnlLine1.Name = "pnlLine1";
            pnlLine1.Size = new Size(436, 1);
            pnlLine1.TabIndex = 26;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeader.Location = new Point(16, 16);
            lblHeader.Margin = new Padding(0, 0, 0, 8);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(175, 19);
            lblHeader.TabIndex = 25;
            lblHeader.Text = "Select Pay Frequency";
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(flowPayFrequencies);
            pnlBody.Controls.Add(label12);
            pnlBody.Controls.Add(lblHeader);
            pnlBody.Controls.Add(pnlLine1);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 0);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(16);
            pnlBody.Size = new Size(468, 333);
            pnlBody.TabIndex = 27;
            // 
            // flowPayFrequencies
            // 
            flowPayFrequencies.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowPayFrequencies.AutoScroll = true;
            flowPayFrequencies.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowPayFrequencies.FlowDirection = FlowDirection.TopDown;
            flowPayFrequencies.Location = new Point(0, 119);
            flowPayFrequencies.Margin = new Padding(3, 3, 3, 0);
            flowPayFrequencies.Name = "flowPayFrequencies";
            flowPayFrequencies.Padding = new Padding(16, 0, 0, 16);
            flowPayFrequencies.Size = new Size(468, 139);
            flowPayFrequencies.TabIndex = 34;
            flowPayFrequencies.WrapContents = false;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label12.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(16, 50);
            label12.Margin = new Padding(0, 0, 0, 16);
            label12.Name = "label12";
            label12.Size = new Size(436, 55);
            label12.TabIndex = 29;
            label12.Text = "Please choose the pay frequency below to filter the clients that will be shown within the system. Changing the pay frequency is only available after a user logs to his/her account.";
            // 
            // flowControls
            // 
            flowControls.BackColor = SystemColors.Menu;
            flowControls.Controls.Add(btnConfirm);
            flowControls.Controls.Add(btnCancel);
            flowControls.Dock = DockStyle.Bottom;
            flowControls.FlowDirection = FlowDirection.RightToLeft;
            flowControls.Location = new Point(0, 273);
            flowControls.Margin = new Padding(3, 0, 3, 3);
            flowControls.Name = "flowControls";
            flowControls.Padding = new Padding(16, 16, 0, 16);
            flowControls.Size = new Size(468, 60);
            flowControls.TabIndex = 28;
            // 
            // btnConfirm
            // 
            btnConfirm.AutoSize = true;
            btnConfirm.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnConfirm.Location = new Point(377, 16);
            btnConfirm.Margin = new Padding(8, 0, 0, 0);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(75, 28);
            btnConfirm.TabIndex = 24;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.Location = new Point(294, 16);
            btnCancel.Margin = new Padding(0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 28);
            btnCancel.TabIndex = 25;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // PayFrequencyForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Window;
            ClientSize = new Size(468, 333);
            Controls.Add(flowControls);
            Controls.Add(pnlBody);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "PayFrequencyForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Load += PayFrequencyForm_Load;
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            flowControls.ResumeLayout(false);
            flowControls.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLine1;
        private Label lblHeader;
        private Panel pnlBody;
        private FlowLayoutPanel flowControls;
        private Button btnConfirm;
        private Button btnCancel;
        private Label label12;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label label2;
        private Label label1;
        private Label lblPayFrequency2Clients;
        private Label lblPayFrequency1Clients;
        private FlowLayoutPanel flowPayFrequencies;
    }
}