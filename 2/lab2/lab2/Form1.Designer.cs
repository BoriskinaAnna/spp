namespace lab2
{
    partial class Playground
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
            this.APoint = new System.Windows.Forms.PictureBox();
            this.BPoint = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.APoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BPoint)).BeginInit();
            this.SuspendLayout();
            // 
            // APoint
            // 
            this.APoint.BackColor = System.Drawing.SystemColors.Highlight;
            this.APoint.Location = new System.Drawing.Point(301, 31);
            this.APoint.Name = "APoint";
            this.APoint.Size = new System.Drawing.Size(25, 25);
            this.APoint.TabIndex = 0;
            this.APoint.TabStop = false;
            // 
            // BPoint
            // 
            this.BPoint.BackColor = System.Drawing.Color.DarkRed;
            this.BPoint.Location = new System.Drawing.Point(301, 210);
            this.BPoint.Name = "BPoint";
            this.BPoint.Size = new System.Drawing.Size(25, 25);
            this.BPoint.TabIndex = 1;
            this.BPoint.TabStop = false;
            // 
            // Playground
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BPoint);
            this.Controls.Add(this.APoint);
            this.Name = "Playground";
            this.Text = "Lab2";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.APoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BPoint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox APoint;
        private System.Windows.Forms.PictureBox BPoint;
    }
}

