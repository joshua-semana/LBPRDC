﻿namespace LBPRDC.Source.Views
{
    partial class ucLoading
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
            progressBar1 = new ProgressBar();
            label1 = new Label();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.None;
            progressBar1.Location = new Point(8, 34);
            progressBar1.Margin = new Padding(0);
            progressBar1.MarqueeAnimationSpeed = 50;
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(240, 23);
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.TabIndex = 3;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.Location = new Point(8, 8);
            label1.Margin = new Padding(0, 0, 0, 8);
            label1.Name = "label1";
            label1.Size = new Size(240, 18);
            label1.TabIndex = 2;
            label1.Text = "Processing, please wait...";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ucLoading
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Window;
            Controls.Add(progressBar1);
            Controls.Add(label1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "ucLoading";
            Padding = new Padding(8);
            Size = new Size(256, 66);
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar progressBar1;
        private Label label1;
    }
}
