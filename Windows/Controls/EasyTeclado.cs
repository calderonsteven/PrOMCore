using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace EasyCore.Controls
{
    public partial class EasyTeclado : UserControl
    {
        public EasyTeclado()
        {
            InitializeComponent();
            TextoTextBox.Focus();
            TextoTextBox.SelectionStart = TextoTextBox.TextLength;
        }

        
        private void btnMayus_Click(object sender, EventArgs e)
        {
            if (btnMayus.BackColor == Color .Gainsboro)
            {
                //Gainsboro --> All Mayus
                btnMayus.BackColor = Color.Silver;
                btnQ.Text = btnQ.Text.ToUpper();
                btnW.Text = btnW.Text.ToUpper();
                btnE.Text = btnE.Text.ToUpper();
                btnR.Text = btnR.Text.ToUpper();
                btnT.Text = btnT.Text.ToUpper();
                btnY.Text = btnY.Text.ToUpper();
                btnU.Text = btnU.Text.ToUpper();
                btnI.Text = btnI.Text.ToUpper();
                btnO.Text = btnO.Text.ToUpper();
                btnP.Text = btnP.Text.ToUpper();
                btnA.Text = btnA.Text.ToUpper();
                btnS.Text = btnS.Text.ToUpper();
                btnD.Text = btnD.Text.ToUpper();
                btnF.Text = btnF.Text.ToUpper();
                btnG.Text = btnG.Text.ToUpper();
                btnH.Text = btnH.Text.ToUpper();
                btnJ.Text = btnJ.Text.ToUpper();
                btnK.Text = btnK.Text.ToUpper();
                btnL.Text = btnL.Text.ToUpper();
                btnZ.Text = btnZ.Text.ToUpper();
                btnX.Text = btnX.Text.ToUpper();
                btnC.Text = btnC.Text.ToUpper();
                btnV.Text = btnV.Text.ToUpper();
                btnB.Text = btnB.Text.ToUpper();
                btnN.Text = btnN.Text.ToUpper();
                btnM.Text = btnM.Text.ToUpper();
                btnEGNE.Text = btnEGNE.Text.ToUpper();

            }
            else
            {
                //Silver  -->  All Minus
                btnMayus.BackColor = Color.Gainsboro;
                btnQ.Text = btnQ.Text.ToLower();
                btnW.Text = btnW.Text.ToLower();
                btnE.Text = btnE.Text.ToLower();
                btnR.Text = btnR.Text.ToLower();
                btnT.Text = btnT.Text.ToLower();
                btnY.Text = btnY.Text.ToLower();
                btnU.Text = btnU.Text.ToLower();
                btnI.Text = btnI.Text.ToLower();
                btnO.Text = btnO.Text.ToLower();
                btnP.Text = btnP.Text.ToLower();
                btnA.Text = btnA.Text.ToLower();
                btnS.Text = btnS.Text.ToLower();
                btnD.Text = btnD.Text.ToLower();
                btnF.Text = btnF.Text.ToLower();
                btnG.Text = btnG.Text.ToLower();
                btnH.Text = btnH.Text.ToLower();
                btnJ.Text = btnJ.Text.ToLower();
                btnK.Text = btnK.Text.ToLower();
                btnL.Text = btnL.Text.ToLower();
                btnZ.Text = btnZ.Text.ToLower();
                btnX.Text = btnX.Text.ToLower();
                btnC.Text = btnC.Text.ToLower();
                btnV.Text = btnV.Text.ToLower();
                btnB.Text = btnB.Text.ToLower();
                btnN.Text = btnN.Text.ToLower();
                btnM.Text = btnM.Text.ToLower();
                btnEGNE.Text = btnEGNE.Text.ToLower();
            }
        }

        private void BotonPresionado_Click(object sender, EventArgs e)
        {
            TextoTextBox.Text += ((Button)sender).Text;
            TextoTextBox.Focus();
            TextoTextBox.SelectionStart = TextoTextBox.TextLength;
        }

        private void btnDEL_Click(object sender, EventArgs e)
        {
            if (TextoTextBox.Text.Length >= 1)
                TextoTextBox.Text = TextoTextBox.Text.Remove(TextoTextBox.Text.Length - 1, 1);
            
            TextoTextBox.Focus();
            TextoTextBox.SelectionStart = TextoTextBox.TextLength;
        }

        /// <summary>
        /// Obtiene O establese el texto que se va a mostrar en el control;
        /// </summary>        
        public override string Text {
            get {
                return TextoTextBox.Text.Trim();
            }
            set {
                TextoTextBox.Text = value.Trim();            
            }
        }

        private void EasyTeclado_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextoTextBox.Text += e.KeyChar;
        }       
    }
}
