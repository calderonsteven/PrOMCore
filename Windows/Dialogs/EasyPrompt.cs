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
    public partial class PrOMPrompt : Form
    {
        private string returnValue;

        public PrOMPrompt()
        {
            InitializeComponent();
        }

        public string CaptionText
        {
            get
            {
                return this.mensajeLabel.Text;
            }
            set
            {
                this.mensajeLabel.Text = value;
            }
        }

        public string Value
        {
            get
            {
                return this.returnValue;
            }
            set
            {
                this.textBoxInput.Text = value;
                this.returnValue = value;
            }
        }

        public static string Show(string initialText)
        {
            return Show(initialText, "");
        }

        public static string Show(string initialText, string caption)
        {
            PrOMPrompt PrOMPrompt = new PrOMPrompt();
            PrOMPrompt.CaptionText = caption;
            PrOMPrompt.Value = initialText;
            PrOMPrompt.ShowDialog();
            return PrOMPrompt.Value;
        }

        private void PrOMAlert_Load(object sender, EventArgs e)
        {
            UtilsForms.MakeFlotableForm(this);
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            this.returnValue = this.textBoxInput.Text;
            this.Close();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.returnValue = null;
            this.Close();
        }

        private void textBoxInput_GotFocus(object sender, EventArgs e)
        {
            this.inputPanelPrompt.Enabled = true;
        }

        private void textBoxInput_LostFocus(object sender, EventArgs e)
        {
            this.inputPanelPrompt.Enabled = false;
        }
    }
}