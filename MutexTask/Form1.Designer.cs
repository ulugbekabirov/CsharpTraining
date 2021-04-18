
namespace MutexTask
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.ProgressBar2 = new System.Windows.Forms.ProgressBar();
            this.Start = new System.Windows.Forms.Button();
            this.Switch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Location = new System.Drawing.Point(35, 60);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(708, 29);
            this.ProgressBar1.TabIndex = 0;
            // 
            // ProgressBar2
            // 
            this.ProgressBar2.Location = new System.Drawing.Point(35, 123);
            this.ProgressBar2.Name = "ProgressBar2";
            this.ProgressBar2.Size = new System.Drawing.Size(708, 29);
            this.ProgressBar2.TabIndex = 1;
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(35, 227);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(94, 29);
            this.Start.TabIndex = 2;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Switch
            // 
            this.Switch.Location = new System.Drawing.Point(356, 227);
            this.Switch.Name = "Switch";
            this.Switch.Size = new System.Drawing.Size(94, 29);
            this.Switch.TabIndex = 3;
            this.Switch.Text = "Switch";
            this.Switch.UseVisualStyleBackColor = true;
            this.Switch.Click += new System.EventHandler(this.Switch_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Switch);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.ProgressBar2);
            this.Controls.Add(this.ProgressBar1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar ProgressBar1;
        private System.Windows.Forms.ProgressBar ProgressBar2;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Switch;
    }
}

