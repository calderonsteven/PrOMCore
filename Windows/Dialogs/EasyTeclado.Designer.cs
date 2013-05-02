using PrOMCore.Windows.Controls;
namespace PrOMCore.Windows.Dialogs
{
    partial class PrOMTeclado
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
            this.PrOMTeclado1 = new PrOMCore.Windows.Controls.PrOMTecladoControl();
            this.SuspendLayout();
            // 
            // PrOMTeclado1
            // 
            this.PrOMTeclado1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.PrOMTeclado1.Location = new System.Drawing.Point(0, 0);
            this.PrOMTeclado1.Name = "PrOMTeclado1";
            this.PrOMTeclado1.Size = new System.Drawing.Size(236, 163);
            this.PrOMTeclado1.TabIndex = 0;
            // 
            // PrOMTeclado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(236, 163);
            this.Controls.Add(this.PrOMTeclado1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimizeBox = false;
            this.Name = "PrOMTeclado";
            this.Text = "PrOMTeclado";
            this.Load += new System.EventHandler(this.TecladoForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public PrOMTecladoControl PrOMTeclado1;

    }
}