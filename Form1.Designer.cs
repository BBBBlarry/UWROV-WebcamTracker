namespace WebcamTracker
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.IBOriginal = new Emgu.CV.UI.ImageBox();
            this.IBProccessed = new Emgu.CV.UI.ImageBox();
            this.txtXYRadius = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.IBOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IBProccessed)).BeginInit();
            this.SuspendLayout();
            // 
            // IBOriginal
            // 
            this.IBOriginal.Location = new System.Drawing.Point(0, 2);
            this.IBOriginal.Name = "IBOriginal";
            this.IBOriginal.Size = new System.Drawing.Size(640, 480);
            this.IBOriginal.TabIndex = 2;
            this.IBOriginal.TabStop = false;
            // 
            // IBProccessed
            // 
            this.IBProccessed.Location = new System.Drawing.Point(646, 2);
            this.IBProccessed.Name = "IBProccessed";
            this.IBProccessed.Size = new System.Drawing.Size(640, 480);
            this.IBProccessed.TabIndex = 2;
            this.IBProccessed.TabStop = false;
            // 
            // txtXYRadius
            // 
            this.txtXYRadius.Location = new System.Drawing.Point(646, 525);
            this.txtXYRadius.Name = "txtXYRadius";
            this.txtXYRadius.Size = new System.Drawing.Size(100, 35);
            this.txtXYRadius.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 715);
            this.Controls.Add(this.txtXYRadius);
            this.Controls.Add(this.IBProccessed);
            this.Controls.Add(this.IBOriginal);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IBOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IBProccessed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox IBOriginal;
        private Emgu.CV.UI.ImageBox IBProccessed;
        private System.Windows.Forms.TextBox txtXYRadius;
    }
}

