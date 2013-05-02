using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PrOMCore.Windows.Forms;
using PrOMCore.Properties;

namespace PrOMCore.Windows.Dialogs
{
    public partial class PrOMAlert : Form
    {
        public PrOMAlert()
        {
            InitializeComponent();
        }

        public enum PrOMAlertImages { PlusAlert, WriteAlert}

        public static void Show(string mensaje) {
            Show(mensaje, "PrOMNet", PrOMAlertImages.WriteAlert);
        }

        public static void Show(string mensaje, string caption, PrOMAlertImages alertImage)
        {
            UtilsForms.ShowCursor(true);
            PrOMAlert alert = new PrOMAlert();
            alert.mensajeLabel.Text = mensaje;            
            alert.Text = caption;

            switch (alertImage) { 
                case PrOMAlertImages.PlusAlert:
                    alert.imagenPictureBox.Image = Resources.PlusAlert;
                    break;
                case PrOMAlertImages.WriteAlert:
                    alert.imagenPictureBox.Image = Resources.WriteAlert;
                    break;
            }

            alert.ShowDialog();
        }

        public static void Show(string mensaje, Image imagen)
        {
            Show(mensaje, "PrOMNet", imagen);
        }

        public static void Show(string mensaje, string caption, Image imagen)
        {
            UtilsForms.ShowCursor(true);
            PrOMAlert alert = new PrOMAlert();
            alert.mensajeLabel.Text = mensaje;
            alert.imagenPictureBox.Image = imagen;
            alert.Text = caption;
            alert.ShowDialog();
        }


        private void PrOMAlert_Load(object sender, EventArgs e)
        {
            UtilsForms.MakeFlotableForm(this);
            UtilsForms.ShowCursor(false);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}