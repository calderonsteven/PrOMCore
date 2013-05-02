using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PrOMCore.Windows.Forms;
//using PrOMCore.Windows.Forms;

namespace PrOMCore.Windows.Dialogs
{
    public partial class PrOMTeclado : Form
    {
        public PrOMTeclado()
        {
            UtilsForms.ShowCursor(true);
            InitializeComponent();
            PrOMTeclado1.OKbutton.Click += new EventHandler(OKbutton_Click);
        }


        public static new string Show(){
            UtilsForms.ShowCursor(true);
            PrOMTeclado tec = new PrOMTeclado();
            tec.ShowDialog();
            UtilsForms.ShowCursor(false);
            return tec.Texto;
        }

        public static string Show(string Texto) {
            UtilsForms.ShowCursor(true);
            PrOMTeclado tec = new PrOMTeclado();
            tec.Texto = Texto;
            tec.ShowDialog();
            UtilsForms.ShowCursor(false);
            return tec.Texto;
        }

        private void OKbutton_Click(object sender, EventArgs e) {
            this.Close();                     
        }

        public string Texto {
            get { return PrOMTeclado1.Text.Trim(); }
            set { PrOMTeclado1.Text = value; }
        }
        /// <summary>
        /// TextoxBox del control
        /// </summary>
        public TextBox TextoTextBox {
            get {
                return PrOMTeclado1.TextoTextBox;
            } 
            set {
                PrOMTeclado1.TextoTextBox = value;
            }
        }

        private void TecladoForm_Load(object sender, EventArgs e){
            UtilsForms.CenterForm(this);
            UtilsForms.MakeFlotableForm(this);            
            UtilsForms.ShowCursor(false);            
        }
    }
}