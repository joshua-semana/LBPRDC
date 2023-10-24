namespace LBPRDC.Source.Views.Shared
{
    partial class DynamicCheckedListBoxControl
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
            chkListItems = new CheckedListBox();
            lblAction = new Label();
            flowContainer = new FlowLayoutPanel();
            flowContainer.SuspendLayout();
            SuspendLayout();
            // 
            // chkListItems
            // 
            chkListItems.BorderStyle = BorderStyle.None;
            chkListItems.CheckOnClick = true;
            chkListItems.Cursor = Cursors.Hand;
            chkListItems.FormattingEnabled = true;
            chkListItems.Location = new Point(0, 0);
            chkListItems.Margin = new Padding(0);
            chkListItems.Name = "chkListItems";
            chkListItems.Size = new Size(180, 18);
            chkListItems.TabIndex = 0;
            chkListItems.SelectedIndexChanged += chkListItems_SelectedIndexChanged;
            // 
            // lblAction
            // 
            lblAction.AutoSize = true;
            lblAction.Cursor = Cursors.Hand;
            lblAction.Font = new Font("Arial", 10F, FontStyle.Underline, GraphicsUnit.Point);
            lblAction.Location = new Point(15, 18);
            lblAction.Margin = new Padding(15, 0, 0, 0);
            lblAction.Name = "lblAction";
            lblAction.Size = new Size(77, 16);
            lblAction.TabIndex = 1;
            lblAction.Tag = "Show";
            lblAction.Text = "Show more";
            lblAction.Visible = false;
            lblAction.Click += lblAction_Click;
            // 
            // flowContainer
            // 
            flowContainer.AutoSize = true;
            flowContainer.Controls.Add(chkListItems);
            flowContainer.Controls.Add(lblAction);
            flowContainer.Dock = DockStyle.Fill;
            flowContainer.FlowDirection = FlowDirection.TopDown;
            flowContainer.Location = new Point(0, 0);
            flowContainer.Margin = new Padding(0);
            flowContainer.Name = "flowContainer";
            flowContainer.Size = new Size(180, 34);
            flowContainer.TabIndex = 2;
            // 
            // DynamicCheckedListBoxControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSize = true;
            BackColor = Color.White;
            Controls.Add(flowContainer);
            Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(0);
            Name = "DynamicCheckedListBoxControl";
            Size = new Size(180, 34);
            Load += DynamicCheckedListBoxControl_Load;
            flowContainer.ResumeLayout(false);
            flowContainer.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox chkListItems;
        private Label lblAction;
        private FlowLayoutPanel flowContainer;
    }
}
