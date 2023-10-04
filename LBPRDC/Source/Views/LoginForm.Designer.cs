namespace LBPRDC.Source.Views
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            splitHorizontal = new SplitContainer();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)splitHorizontal).BeginInit();
            splitHorizontal.Panel1.SuspendLayout();
            splitHorizontal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // splitHorizontal
            // 
            splitHorizontal.Dock = DockStyle.Fill;
            splitHorizontal.Location = new Point(0, 0);
            splitHorizontal.Name = "splitHorizontal";
            // 
            // splitHorizontal.Panel1
            // 
            splitHorizontal.Panel1.Controls.Add(pictureBox1);
            splitHorizontal.Size = new Size(1264, 681);
            splitHorizontal.SplitterDistance = 720;
            splitHorizontal.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(310, 306);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 50);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1264, 681);
            Controls.Add(splitHorizontal);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login ";
            splitHorizontal.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitHorizontal).EndInit();
            splitHorizontal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitHorizontal;
        private PictureBox pictureBox1;
    }
}