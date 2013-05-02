using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PrOMCore.Windows.Forms
{
    public class PrOMTextBox:TextBox
    {
        public PrOMTextBox()
            : base()
        {
            InitializeComponent();
        }

        private bool m_OnlyNumbers;

        public bool OnlyNumbers
        {
            get { return m_OnlyNumbers; }
            set { m_OnlyNumbers = value; }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // PrOMTextBox
            // 
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PrOMTextBox_KeyPress);
            this.ResumeLayout(false);

        }

        private void PrOMTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!this.m_OnlyNumbers)
                return;

            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)8 || e.KeyChar == '-')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

    }
}
