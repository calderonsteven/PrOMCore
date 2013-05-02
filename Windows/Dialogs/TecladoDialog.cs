using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EasyCore.Windows.Forms;
//using EasyCore.Windows.Forms;

namespace EasyCore.Dialogs
{
    public partial class TecladoDialog : Form
    {
        public TecladoDialog()
        {
            UtilsForms.ShowCursor(true);
            InitializeComponent();
            easyTeclado1.OKbutton.Click += new EventHandler(OKbutton_Click);
        }

        private void OKbutton_Click(object sender, EventArgs e) {
            this.Close();                     
        }

        public string Texto {
            get { return easyTeclado1.Text; }
            set { easyTeclado1.Text = value; }
        }

        private void TecladoForm_Load(object sender, EventArgs e){            
            UtilsForms.MakeFlotableForm(this);            
            UtilsForms.ShowCursor(false);            
        }
    }
}