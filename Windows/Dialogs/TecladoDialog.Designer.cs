using EasyCore.Controls;
namespace EasyCore.Dialogs
{
    partial class TecladoDialog
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
            this.easyTeclado1 = new EasyCore.Controls.EasyTeclado();
            this.SuspendLayout();
            // 
            // easyTeclado1
            // 
            this.easyTeclado1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.easyTeclado1.Location = new System.Drawing.Point(0, 0);
            this.easyTeclado1.Name = "easyTeclado1";
            this.easyTeclado1.Size = new System.Drawing.Size(236, 163);
            this.easyTeclado1.TabIndex = 0;
            // 
            // TecladoDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(236, 163);
            this.Controls.Add(this.easyTeclado1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimizeBox = false;
            this.Name = "TecladoDialog";
            this.Text = "EasyTeclado";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.TecladoForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public EasyTeclado easyTeclado1;

    }
}