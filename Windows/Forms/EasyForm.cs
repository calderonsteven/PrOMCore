using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PrOMCore.Windows.Forms
{
    public partial class PrOMForm : Form
    {
        public PrOMForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Muestra el Formulario para que solo se vea Este en la iTask
        /// </summary>
        public void ShowForm() {
            /*if(this.Parent != null)
                UtilsForms.ShowForm(this.Parent, this);*/
        }
    }
}