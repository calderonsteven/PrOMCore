using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PrOMCore.Windows.Forms;

namespace PrOMCore.Windows.Dialogs
{


    public partial class PrOMDigitPad : Form
    {
        #region Propiedades Del Formulario
        /// <summary>
        /// Devuelve un string, que representa el Numero!
        /// </summary>
        public string NumDig {
            get {
                return txtNumero.Text.Trim();                            
            }
            set {
                txtNumero.Text = value;            
            }        
        }
        
        public bool m_Entero = false;
        /// <summary>
        /// Determina si se puede usar el boton de punto(·)
        /// </summary>
        public bool Entero {
            get {
                return m_Entero;            
            }
            set {
                buttonP.Enabled = !value;
                m_Entero = value;
            }        
        }

        public int m_MaxLength = 12;
        /// <summary>
        /// Cantidad maxima de caracteres permitido por el formulario, por defecto es 12
        /// </summary>
        public int MaxLength {
            get {
                return m_MaxLength;            
            }
            set {
                m_MaxLength = value;            
            }
        }

        public int m_MaxDecimales = 2;
        /// <summary>
        /// Cantidad maxima de decimales permitida por el formulario, por defecto es 2
        /// </summary>
        public int MaxDecimales {
            get {
                return m_MaxDecimales;            
            }
            set {
                m_MaxDecimales = value;                            
            }
        }

        ///Separador por defecto dependiendo de la pda!
        private string lSeparador = System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;

        #endregion

        /// <summary>
        /// Muestra el formulario con el texto del Digito Vacio!
        /// </summary>
        /// <returns>Un string Que representa el digito</returns>
        public static new string Show() {
            UtilsForms.ShowCursor(true);
            PrOMDigitPad dig = new PrOMDigitPad();
            dig.ShowDialog();
            UtilsForms.ShowCursor(false);
            return dig.NumDig.Replace(",", ".");
        }

        /// <summary>
        /// Muestra el formulario con el texto especificado en el parametro!
        /// </summary>
        /// <param name="digStr">string representado el Texto</param>
        /// <returns>Un string Que representa el digito</returns>
        public static string Show(string digStr) {
            UtilsForms.ShowCursor(true);
            PrOMDigitPad dig = new PrOMDigitPad();
            dig.NumDig = digStr;
            dig.ShowDialog();
            UtilsForms.ShowCursor(false);
            return dig.NumDig.Replace(",", ".");        
        }

        public PrOMDigitPad()
        {
            InitializeComponent();
            UtilsForms.PrepararImageList(defaultImageList);
        }

        #region Comportamiento de los Botones

        private string ParteEntera(string pNumero)
        {
            int lPosicion = pNumero.LastIndexOf(lSeparador);
            string lRes = "";
            if (lPosicion == -1) {
                lRes = pNumero;
            } else if(lPosicion > 0) {
                lRes =  pNumero.Substring(0, lPosicion);
            }
            return lRes;
        }

        private string ParteDecimal(string pNumero)
        {
            int lPosicion = pNumero.LastIndexOf(lSeparador);
            string lRes = "";

            if (lPosicion != -1) {
                if (lPosicion + 1 != pNumero.Length) {
                    lRes = pNumero.Substring(lPosicion + 1, pNumero.Length - lPosicion - 1);
                }
            }

            return lRes;
        }

        private void buttonNumero_Click(object sender, EventArgs e)
        {
            string lEntero =ParteEntera(txtNumero.Text);
            string lDecimal = ParteDecimal(txtNumero.Text);

            //Feisimo eso no!
            if ((lEntero.Length < MaxLength && lDecimal.Length < MaxDecimales)){
                if (((Button)sender).Text == "0" && (txtNumero.Text.LastIndexOf(lSeparador) == -1 && lEntero.Length > 0 && int.Parse(lEntero) == 0)) { }
                else{
                    txtNumero.Text += ((Button)sender).Text;
                }
            }
        }

        private void buttonP_Click(object sender, EventArgs e)
        {
            if (txtNumero.Text.LastIndexOf(lSeparador) == -1)
                txtNumero.Text += buttonP.Text;
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (txtNumero.Text.Length != 0){
                if (txtNumero.Text.Length == 1){
                    txtNumero.Text = "";
                } else {
                    string NewText = txtNumero.Text.Substring(0, txtNumero.Text.Length - 1);
                    txtNumero.Text = NewText;
                }
            }
        }
        
        #endregion

        private void frmDigitN_Load(object sender, EventArgs e)
        {            
            buttonP.Text = lSeparador;
            UtilsForms.CenterForm(this);
            UtilsForms.MakeFlotableForm(this);            
            UtilsForms.ShowCursor(false);
        }

        private void defaultToolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button == tbCancelar) {
                NumDig = string.Empty;
            }

            this.Close();
        }     
        
    }
}