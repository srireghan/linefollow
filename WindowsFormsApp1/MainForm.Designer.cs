namespace WindowsFormsApp1
{
    partial class MainForm
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
            this.pictureBoxRaw = new System.Windows.Forms.PictureBox();
            this.pictureBoxThreshold = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxRaw
            // 
            this.pictureBoxRaw.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxRaw.Name = "pictureBoxRaw";
            this.pictureBoxRaw.Size = new System.Drawing.Size(374, 426);
            this.pictureBoxRaw.TabIndex = 0;
            this.pictureBoxRaw.TabStop = false;
            // 
            // pictureBoxThreshold
            // 
            this.pictureBoxThreshold.Location = new System.Drawing.Point(421, 12);
            this.pictureBoxThreshold.Name = "pictureBoxThreshold";
            this.pictureBoxThreshold.Size = new System.Drawing.Size(332, 426);
            this.pictureBoxThreshold.TabIndex = 1;
            this.pictureBoxThreshold.TabStop = false;
            this.pictureBoxThreshold.Click += new System.EventHandler(this.pictureBoxThreshold_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBoxThreshold);
            this.Controls.Add(this.pictureBoxRaw);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxThreshold)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxRaw;
        private System.Windows.Forms.PictureBox pictureBoxThreshold;
    }
}