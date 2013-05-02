namespace PrOMCore.Windows.Dialogs
{
    partial class PrOMAlert
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
            this.imagenPictureBox = new System.Windows.Forms.PictureBox();
            this.mensajeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // imagenPictureBox
            // 
            this.imagenPictureBox.Location = new System.Drawing.Point(5, 12);
            this.imagenPictureBox.Name = "imagenPictureBox";
            this.imagenPictureBox.Size = new System.Drawing.Size(40, 40);
            // 
            // mensajeLabel
            // 
            this.mensajeLabel.Location = new System.Drawing.Point(47, 3);
            this.mensajeLabel.Name = "mensajeLabel";
            this.mensajeLabel.Size = new System.Drawing.Size(138, 60);
            this.mensajeLabel.Text = "Mensaje ";
            this.mensajeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PrOMAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(200, 65);
            this.Controls.Add(this.mensajeLabel);
            this.Controls.Add(this.imagenPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "PrOMAlert";
            this.Text = "PrOMAlert";
            this.Load += new System.EventHandler(this.PrOMAlert_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox imagenPictureBox;
        public System.Windows.Forms.Label mensajeLabel;

    }
}