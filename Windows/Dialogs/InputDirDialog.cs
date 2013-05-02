using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EasyCore.Windows.Forms;
//using EasyCore.Windows.Forms;

namespace EasyCore.Forms
{

    public partial class InputDirDialog : Form
    {
        public string Address="$";

        private Nodos[] dirNodos = new Nodos[40];

        //--11-08-2006
        private int[,] PilaDef = new int[40, 2];
        private int[] PilaTmp = new int[10];
        private int tDef;
        private int tTmp;
        private int sizeTmp;
        private string letra;
        private string lApto;
        //**

        public InputDirDialog()
        {
            UtilsForms.ShowCursor(true);
            InitializeComponent();            
        }        

        private void Fill_Nodos()
        {

            //NODO INICIO
            dirNodos[0] = new Nodos(0);
            dirNodos[0].AddNext(1);
            dirNodos[0].AddNext(24);
            //dirNodos[0].AddNext(26);

            dirNodos[1] = new Nodos(1);
            dirNodos[1].AddNext(2);

            dirNodos[2] = new Nodos(4);
            dirNodos[2].AddNext(3);
            dirNodos[2].AddNext(4);
            dirNodos[2].AddNext(8);

            dirNodos[3] = new Nodos(61);
            dirNodos[3].AddNext(4);
            dirNodos[3].AddNext(5);
            dirNodos[3].AddNext(8);

            dirNodos[4] = new Nodos(63);
            dirNodos[4].AddNext(8);

            dirNodos[5] = new Nodos(62);
            dirNodos[5].AddNext(6);
            dirNodos[5].AddNext(7);
            dirNodos[5].AddNext(8);

            dirNodos[6] = new Nodos(63);
            dirNodos[6].AddNext(8);

            dirNodos[7] = new Nodos(61);
            dirNodos[7].AddNext(6);
            dirNodos[7].AddNext(8);

            dirNodos[8] = new Nodos(7);
            dirNodos[8].AddNext(9);

            dirNodos[9] = new Nodos(4);
            dirNodos[9].AddNext(10);
            dirNodos[9].AddNext(11);
            dirNodos[9].AddNext(15);

            dirNodos[10] = new Nodos(61);
            dirNodos[10].AddNext(11);
            dirNodos[10].AddNext(12);
            dirNodos[10].AddNext(15);

            dirNodos[11] = new Nodos(63);
            dirNodos[11].AddNext(15);

            dirNodos[12] = new Nodos(62);
            dirNodos[12].AddNext(13);
            dirNodos[12].AddNext(14);
            dirNodos[12].AddNext(15);

            dirNodos[13] = new Nodos(63);
            dirNodos[13].AddNext(15);

            dirNodos[14] = new Nodos(61);
            dirNodos[14].AddNext(13);
            dirNodos[14].AddNext(15);

            dirNodos[15] = new Nodos(8);
            dirNodos[15].AddNext(16);

            dirNodos[16] = new Nodos(4);
            dirNodos[16].AddNext(17);
            dirNodos[16].AddNext(19);
            dirNodos[16].AddNext(20);
            dirNodos[16].AddNext(21);
            dirNodos[16].AddNext(22);
            dirNodos[16].AddNext(31);

            dirNodos[17] = new Nodos(96);
            dirNodos[17].AddNext(32);


            dirNodos[18] = new Nodos(97);
            dirNodos[18].AddNext(33);

            dirNodos[19] = new Nodos(91);
            dirNodos[19].AddNext(34);


            dirNodos[20] = new Nodos(92);
            dirNodos[20].AddNext(35);

            dirNodos[21] = new Nodos(93);
            dirNodos[21].AddNext(37);

            dirNodos[22] = new Nodos(94);
            dirNodos[22].AddNext(36);


            dirNodos[23] = new Nodos(95);
            dirNodos[23].AddNext(38);

            dirNodos[24] = new Nodos(2);
            dirNodos[24].AddNext(25);

            dirNodos[25] = new Nodos(5);
            dirNodos[25].AddNext(8);

            dirNodos[26] = new Nodos(3);
            dirNodos[26].AddNext(27);

            dirNodos[27] = new Nodos(5);
            dirNodos[27].AddNext(28);
            dirNodos[27].AddNext(30);

            dirNodos[28] = new Nodos(8);
            dirNodos[28].AddNext(29);

            dirNodos[29] = new Nodos(5);
            dirNodos[29].AddNext(30);

            dirNodos[30] = new Nodos(10);
            dirNodos[30].AddNext(16);

            //--Ultimos nodos...complemento de Modificadores 2

            dirNodos[32] = new Nodos(61);
            dirNodos[32].AddNext(18);
            dirNodos[32].AddNext(19);

            dirNodos[33] = new Nodos(61);
            dirNodos[33].AddNext(31);

            dirNodos[34] = new Nodos(61);
            dirNodos[34].AddNext(20);
            dirNodos[34].AddNext(21);

            dirNodos[35] = new Nodos(61);
            dirNodos[35].AddNext(21);

            dirNodos[36] = new Nodos(61);
            dirNodos[36].AddNext(23);
            dirNodos[36].AddNext(31);

            dirNodos[37] = new Nodos(61);
            dirNodos[37].AddNext(31);

            dirNodos[38] = new Nodos(61);
            dirNodos[38].AddNext(31);

            //**

            //NODO FIN
            dirNodos[31] = new Nodos(31);
            //--SE LLENO EL GRAFO DE DIRECCIONES
        }

        

       /* private void FindButtons(string valTag,string valTag2,int swTag2)
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i] is Button)
                {
                    this.Controls[i].Enabled = false;

                    if (swTag2 == 0)
                    {
                        if (this.Controls[i].Tag.ToString() == valTag)
                        {
                            this.Controls[i].Enabled = true;
                        }
                    }
                    else if (this.Controls[i].Tag.ToString() == valTag || this.Controls[i].Tag.ToString() == valTag2)
                    {
                        this.Controls[i].Enabled = true;
                    }
                }
            }
        }*/


        private void ActiveControls()
        {
            InactiveButtons();
            for (int j = 0; j < tTmp; j++)
            {
                ActiveButtons(dirNodos[PilaTmp[j]].Value);
            }
        }

        private void InactiveButtons()
        {
            btnCIRC.Enabled = false;
            btnTV.Enabled = false;
            btnDG.Enabled = false;
            btnAK.Enabled = false;
            btnAC.Enabled = false;
            btnKR.Enabled = false;
            btnCL.Enabled = false;
            btnAUTO.Enabled = false;
            btnAV.Enabled = false;
            btnVIA.Enabled = false;
            btn0.Enabled = false;
            btn9.Enabled = false;
            btn8.Enabled = false;
            btn7.Enabled = false;
            btn6.Enabled = false;
            btn5.Enabled = false;
            btn4.Enabled = false;
            btn3.Enabled = false;
            btn2.Enabled = false;
            btn1.Enabled = false;
            btnM.Enabled = false;
            btnN.Enabled = false;
            btnB.Enabled = false;
            btnV.Enabled = false;
            btnC.Enabled = false;
            btnX.Enabled = false;
            btnZ.Enabled = false;
            btnEGNE.Enabled = false;
            btnL.Enabled = false;
            btnK.Enabled = false;
            btnJ.Enabled = false;
            btnH.Enabled = false;
            btnG.Enabled = false;
            btnF.Enabled = false;
            btnD.Enabled = false;
            btnS.Enabled = false;
            btnA.Enabled = false;
            btnP.Enabled = false;
            btnO.Enabled = false;
            btnI.Enabled = false;
            btnU.Enabled = false;
            btnY.Enabled = false;
            btnT.Enabled = false;
            btnR.Enabled = false;
            btnE.Enabled = false;
            btnW.Enabled = false;
            btnQ.Enabled = false;
            btnBIS.Enabled = false;
            btnOESTE.Enabled = false;
            btnESTE.Enabled = false;
            btnSUR.Enabled = false;
            btnNORTE.Enabled = false;
            btnNUMERO.Enabled = false;
            btnGUION.Enabled = false;
            btnBQ.Enabled = false;
            btnINT.Enabled = false;
            btnBOD.Enabled = false;
            btnOF.Enabled = false;
            btnLOC.Enabled = false;
            btnSMZ.Enabled = false;
            btnMZ.Enabled = false;
            btnAPTO.Enabled = false;
            btnKM.Enabled = false;
            btnAceptar.Enabled = false;
            btnSPACE.Enabled = false;
            btnDEL.Enabled = false;

            btnCIRC.BackColor = Color.Gainsboro;
            btnTV.BackColor = Color.Gainsboro;
            btnDG.BackColor = Color.Gainsboro;
            btnAK.BackColor = Color.Gainsboro;
            btnAC.BackColor = Color.Gainsboro;
            btnKR.BackColor = Color.Gainsboro;
            btnCL.BackColor = Color.Gainsboro;
            btnAUTO.BackColor = Color.Gainsboro;
            btnAV.BackColor = Color.Gainsboro;
            btnVIA.BackColor = Color.Gainsboro;
            btn0.BackColor = Color.Gainsboro;
            btn9.BackColor = Color.Gainsboro;
            btn8.BackColor = Color.Gainsboro;
            btn7.BackColor = Color.Gainsboro;
            btn6.BackColor = Color.Gainsboro;
            btn5.BackColor = Color.Gainsboro;
            btn4.BackColor = Color.Gainsboro;
            btn3.BackColor = Color.Gainsboro;
            btn2.BackColor = Color.Gainsboro;
            btn1.BackColor = Color.Gainsboro;
            btnM.BackColor = Color.Gainsboro;
            btnN.BackColor = Color.Gainsboro;
            btnB.BackColor = Color.Gainsboro;
            btnV.BackColor = Color.Gainsboro;
            btnC.BackColor = Color.Gainsboro;
            btnX.BackColor = Color.Gainsboro;
            btnZ.BackColor = Color.Gainsboro;
            btnEGNE.BackColor = Color.Gainsboro;
            btnL.BackColor = Color.Gainsboro;
            btnK.BackColor = Color.Gainsboro;
            btnJ.BackColor = Color.Gainsboro;
            btnH.BackColor = Color.Gainsboro;
            btnG.BackColor = Color.Gainsboro;
            btnF.BackColor = Color.Gainsboro;
            btnD.BackColor = Color.Gainsboro;
            btnS.BackColor = Color.Gainsboro;
            btnA.BackColor = Color.Gainsboro;
            btnP.BackColor = Color.Gainsboro;
            btnO.BackColor = Color.Gainsboro;
            btnI.BackColor = Color.Gainsboro;
            btnU.BackColor = Color.Gainsboro;
            btnY.BackColor = Color.Gainsboro;
            btnT.BackColor = Color.Gainsboro;
            btnR.BackColor = Color.Gainsboro;
            btnE.BackColor = Color.Gainsboro;
            btnW.BackColor = Color.Gainsboro;
            btnQ.BackColor = Color.Gainsboro;
            btnBIS.BackColor = Color.Gainsboro;
            btnOESTE.BackColor = Color.Gainsboro;
            btnESTE.BackColor = Color.Gainsboro;
            btnSUR.BackColor = Color.Gainsboro;
            btnNORTE.BackColor = Color.Gainsboro;
            btnNUMERO.BackColor = Color.Gainsboro;
            btnGUION.BackColor = Color.Gainsboro;
            btnBQ.BackColor = Color.Gainsboro;
            btnINT.BackColor = Color.Gainsboro;
            btnBOD.BackColor = Color.Gainsboro;
            btnOF.BackColor = Color.Gainsboro;
            btnLOC.BackColor = Color.Gainsboro;
            btnSMZ.BackColor = Color.Gainsboro;
            btnMZ.BackColor = Color.Gainsboro;
            btnAPTO.BackColor = Color.Gainsboro;
            btnKM.BackColor = Color.Gainsboro;
            btnAceptar.BackColor = Color.Gainsboro;

        }

        private void ActiveButtons(int NumTag)
        {
            #region botones segun nodos()
            /*
                      //1
                      btnCIRC;
                      btnTV;
                      btnDG;
                      btnAK;
                      btnAC;
                      btnKR;
                      btnCL;
                     //2
                      btnAUTO;
                      btnAV;
                     //3
                       btnVIA; 
                     //4
                      btn0;
                      btn9;
                      btn8;
                      btn7;
                      btn6;
                      btn5;
                      btn4;
                      btn3;
                      btn2;
                      btn1;
                     //5
                      btnM;
                      btnN;
                      btnB;
                      btnV;
                      btnC;
                      btnX;
                      btnZ;
                      btnEGNE;
                      btnL;
                      btnK;
                      btnJ;
                      btnH;
                      btnG;
                      btnF;
                      btnD;
                      btnS;
                      btnA;
                      btnP;
                      btnO;
                      btnI;
                      btnU;
                      btnY;
                      btnT;
                      btnR;
                      btnE;
                      btnW;
                      btnQ;
                     //6
                     //61 (5 + 4)
         
                     //62
                      btnBIS;
                     //63
                      btnOESTE;
                      btnESTE;
                      btnSUR;
                      btnNORTE;
                     //7
                      btnNUMERO;
                     //8
                      btnGUION;
                     //9
                     //91
                      btnBQ;
                     //92
                      btnINT;
                     //93 (97 + 95)
          
                     //94
                      btnBOD;
                     //95
                      btnOF;
                      btnLOC;
                     //96
                      btnSMZ;
                      btnMZ;
                     //97 
                      btnAPTO;
         
                     //10
                      btnKM;  
                    //31
                      btnAceptar;
         
                     */
            #endregion

            switch (NumTag)
            {
                case 1:
                    btnCIRC.Enabled = true;
                    btnTV.Enabled = true;
                    btnDG.Enabled = true;
                    btnAK.Enabled = true;
                    btnAC.Enabled = true;
                    btnKR.Enabled = true;
                    btnCL.Enabled = true;

                    btnCIRC.BackColor = Color.GhostWhite;
                    btnTV.BackColor = Color.GhostWhite;
                    btnDG.BackColor = Color.GhostWhite;
                    btnAK.BackColor = Color.GhostWhite;
                    btnAC.BackColor = Color.GhostWhite;
                    btnKR.BackColor = Color.GhostWhite;
                    btnCL.BackColor = Color.GhostWhite;


                    break;
                case 2:
                    btnAUTO.Enabled = true;
                    btnAV.Enabled = true;

                    btnAUTO.BackColor = Color.GhostWhite;
                    btnAV.BackColor = Color.GhostWhite;
                    break;
                case 3:
                    btnVIA.Enabled = true;

                    btnVIA.BackColor = Color.GhostWhite;
                    break;
                case 4:
                    letra = "4";
                    picVariables.Visible = true;
                    //picBtnBase.Visible = true;
                    txtVariable.Text = "";
                    btnDEL.Enabled = false;

                    btn0.Enabled = true;
                    btn9.Enabled = true;
                    btn8.Enabled = true;
                    btn7.Enabled = true;
                    btn6.Enabled = true;
                    btn5.Enabled = true;
                    btn4.Enabled = true;
                    btn3.Enabled = true;
                    btn2.Enabled = true;
                    btn1.Enabled = true;
                    btnSPACE.Enabled = true;
                    btnDEL.Enabled = true;

                    btn0.BackColor = Color.GhostWhite;
                    btn9.BackColor = Color.GhostWhite;
                    btn8.BackColor = Color.GhostWhite;
                    btn7.BackColor = Color.GhostWhite;
                    btn6.BackColor = Color.GhostWhite;
                    btn5.BackColor = Color.GhostWhite;
                    btn4.BackColor = Color.GhostWhite;
                    btn3.BackColor = Color.GhostWhite;
                    btn2.BackColor = Color.GhostWhite;
                    btn1.BackColor = Color.GhostWhite;
                    break;
                case 5:  //(5 + 4)
                case 61:  //(5 + 4)
                    if (NumTag == 5)
                    {
                        letra = "5";
                    }
                    else
                    {
                        letra = "61";
                    }
                    picVariables.Visible = true;
                    //picBtnBase.Visible = true;
                    txtVariable.Text = "";
                    btnDEL.Enabled = false;

                    btnM.Enabled = true;
                    btnN.Enabled = true;
                    btnB.Enabled = true;
                    btnV.Enabled = true;
                    btnC.Enabled = true;
                    btnX.Enabled = true;
                    btnZ.Enabled = true;
                    btnEGNE.Enabled = true;
                    btnL.Enabled = true;
                    btnK.Enabled = true;
                    btnJ.Enabled = true;
                    btnH.Enabled = true;
                    btnG.Enabled = true;
                    btnF.Enabled = true;
                    btnD.Enabled = true;
                    btnS.Enabled = true;
                    btnA.Enabled = true;
                    btnP.Enabled = true;
                    btnO.Enabled = true;
                    btnI.Enabled = true;
                    btnU.Enabled = true;
                    btnY.Enabled = true;
                    btnT.Enabled = true;
                    btnR.Enabled = true;
                    btnE.Enabled = true;
                    btnW.Enabled = true;
                    btnQ.Enabled = true;

                    btn0.Enabled = true;
                    btn9.Enabled = true;
                    btn8.Enabled = true;
                    btn7.Enabled = true;
                    btn6.Enabled = true;
                    btn5.Enabled = true;
                    btn4.Enabled = true;
                    btn3.Enabled = true;
                    btn2.Enabled = true;
                    btn1.Enabled = true;
                    btnSPACE.Enabled = true;
                    btnDEL.Enabled = true;

                    btnM.BackColor = Color.GhostWhite;
                    btnN.BackColor = Color.GhostWhite;
                    btnB.BackColor = Color.GhostWhite;
                    btnV.BackColor = Color.GhostWhite;
                    btnC.BackColor = Color.GhostWhite;
                    btnX.BackColor = Color.GhostWhite;
                    btnZ.BackColor = Color.GhostWhite;
                    btnEGNE.BackColor = Color.GhostWhite;
                    btnL.BackColor = Color.GhostWhite;
                    btnK.BackColor = Color.GhostWhite;
                    btnJ.BackColor = Color.GhostWhite;
                    btnH.BackColor = Color.GhostWhite;
                    btnG.BackColor = Color.GhostWhite;
                    btnF.BackColor = Color.GhostWhite;
                    btnD.BackColor = Color.GhostWhite;
                    btnS.BackColor = Color.GhostWhite;
                    btnA.BackColor = Color.GhostWhite;
                    btnP.BackColor = Color.GhostWhite;
                    btnO.BackColor = Color.GhostWhite;
                    btnI.BackColor = Color.GhostWhite;
                    btnU.BackColor = Color.GhostWhite;
                    btnY.BackColor = Color.GhostWhite;
                    btnT.BackColor = Color.GhostWhite;
                    btnR.BackColor = Color.GhostWhite;
                    btnE.BackColor = Color.GhostWhite;
                    btnW.BackColor = Color.GhostWhite;
                    btnQ.BackColor = Color.GhostWhite;

                    btn0.BackColor = Color.GhostWhite;
                    btn9.BackColor = Color.GhostWhite;
                    btn8.BackColor = Color.GhostWhite;
                    btn7.BackColor = Color.GhostWhite;
                    btn6.BackColor = Color.GhostWhite;
                    btn5.BackColor = Color.GhostWhite;
                    btn4.BackColor = Color.GhostWhite;
                    btn3.BackColor = Color.GhostWhite;
                    btn2.BackColor = Color.GhostWhite;
                    btn1.BackColor = Color.GhostWhite;
                    break;

                case 62:
                    btnBIS.Enabled = true;

                    btnBIS.BackColor = Color.GhostWhite;
                    break;

                case 63:
                    btnOESTE.Enabled = true;
                    btnESTE.Enabled = true;
                    btnSUR.Enabled = true;
                    btnNORTE.Enabled = true;

                    btnOESTE.BackColor = Color.GhostWhite;
                    btnESTE.BackColor = Color.GhostWhite;
                    btnSUR.BackColor = Color.GhostWhite;
                    btnNORTE.BackColor = Color.GhostWhite;
                    break;

                case 7:
                    btnNUMERO.Enabled = true;

                    btnNUMERO.BackColor = Color.GhostWhite;
                    break;

                case 8:
                    btnGUION.Enabled = true;

                    btnGUION.BackColor = Color.GhostWhite;
                    break;

                case 91:
                    btnBQ.Enabled = true;

                    btnBQ.BackColor = Color.GhostWhite;
                    break;

                case 92:
                    btnINT.Enabled = true;

                    btnINT.BackColor = Color.GhostWhite;
                    break;

                case 93:// (97 + 95)
                    lApto = "93";
                    btnAPTO.Enabled = true;
                    btnOF.Enabled = true;
                    btnLOC.Enabled = true;

                    btnAPTO.BackColor = Color.GhostWhite;
                    btnOF.BackColor = Color.GhostWhite;
                    btnLOC.BackColor = Color.GhostWhite;
                    break;

                case 94:
                    btnBOD.Enabled = true;

                    btnBOD.BackColor = Color.GhostWhite;
                    break;

                case 95:
                    lApto = "95";
                    btnOF.Enabled = true;
                    btnLOC.Enabled = true;

                    btnOF.BackColor = Color.GhostWhite;
                    btnLOC.BackColor = Color.GhostWhite;
                    break;

                case 96:
                    btnSMZ.Enabled = true;
                    btnMZ.Enabled = true;

                    btnSMZ.BackColor = Color.GhostWhite;
                    btnMZ.BackColor = Color.GhostWhite;
                    break;

                case 97:
                    lApto = "97";
                    btnAPTO.Enabled = true;

                    btnAPTO.BackColor = Color.GhostWhite;
                    break;

                case 10:
                    btnKM.Enabled = true;

                    btnKM.BackColor = Color.GhostWhite;
                    break;

                case 31:
                    btnAceptar.Enabled = true;

                    btnAceptar.BackColor = Color.GhostWhite;
                    break;
            }
        }


        //--11-08-2006

        /// <summary>
        /// Este procedimiento adiciona los elementos validados en la dirección escrita
        /// y va guardando la secuencia en la pilaDef
        /// </summary>
        /// <param name="NumNodo">Numero del Nodo que se adiciona</param>
        /// <param name="size">Posición del primer caracter del nodo en la dirección</param>
        /// 
        private void Add_PilaDef(int NumNodo, int size)
        {
            //adiciona el valor de NumNext a la pila Definitiva
            PilaDef[tDef, 0] = NumNodo;
            PilaDef[tDef, 1] = size;
            tDef++;
            //lstNodos.Items.Add(NumNodo.ToString());
            //lstTam.Items.Add(size.ToString());

            //borra pilaTmp y le adiciona los siguientes del Nodo
            tTmp = 0;

            for (int i = 0; i < dirNodos[NumNodo].Index; i++)
            {
                PilaTmp[tTmp] = dirNodos[NumNodo].Next[i];
                tTmp++;
            }
            ActiveControls();
        }

        private void Del_PilaDef()
        {
            //adiciona el valor de NumNext a la pila Definitiva
            tDef--;
            //borra pilaTmp y le adiciona los siguientes del Nodo
            tTmp = 0;

            for (int i = 0; i < dirNodos[PilaDef[tDef - 1, 0]].Index; i++)
            {
                PilaTmp[tTmp] = dirNodos[PilaDef[tDef - 1, 0]].Next[i];
                tTmp++;
            }
            ActiveControls();
        }



        /// <summary>
        /// Busca en la pila tmp el nodo cuyo valor es el Tag del botón Presionado
        /// </summary>
        /// <param name="btnTag">Tag del Botón presionado</param>
        /// <returns></returns>
        private int Buscar_Nodo(int btnTag)
        {
            for (int j = 0; j < tTmp; j++)
            {
                if (dirNodos[PilaTmp[j]].Value == btnTag)
                {
                    return (PilaTmp[j]);
                }
            }
            return (-1);
        }

        private void CheckButton(string btn_tag, int size)
        {
            int index = Buscar_Nodo(int.Parse(btn_tag));
            if (index != -1)
            {
                Add_PilaDef(index, size);
            }
        }

        //**


        private void frmInputDir_Load(object sender, EventArgs e)
        {
            Fill_Nodos();
            //--
            tTmp = 0;
            tDef = 0;
            Add_PilaDef(0, 0);
            //**
            UtilsForms.MakeFlotableForm(this);
            UtilsForms.ShowCursor(false);
        }

#region Botones_y_Comportamiento
        private void btnCL_Click(object sender, EventArgs e)
        {
            sizeTmp = txtDIR.Text.Length;
            txtDIR.Text += btnCL.Text + " ";
            CheckButton(btnCL.Tag.ToString(), sizeTmp);

        }

        private void btnKR_Click(object sender, EventArgs e)
        {
            sizeTmp = txtDIR.Text.Length;
            txtDIR.Text += btnKR.Text + " ";
            CheckButton(btnKR.Tag.ToString(), sizeTmp);
        }

        private void btnAC_Click(object sender, EventArgs e)
        {
            sizeTmp = txtDIR.Text.Length;
            txtDIR.Text += btnAC.Text + " ";
            CheckButton(btnAC.Tag.ToString(), sizeTmp);
        }

        private void btnAK_Click(object sender, EventArgs e)
        {
            sizeTmp = txtDIR.Text.Length;
            txtDIR.Text += btnAK.Text + " ";
            CheckButton(btnAK.Tag.ToString(), sizeTmp);
        }

        private void btnDG_Click(object sender, EventArgs e)
        {
            sizeTmp = txtDIR.Text.Length;
            txtDIR.Text += btnDG.Text + " ";
            CheckButton(btnDG.Tag.ToString(), sizeTmp);
        }

        private void btnTV_Click(object sender, EventArgs e)
        {
            sizeTmp = txtDIR.Text.Length;
            txtDIR.Text += btnTV.Text + " ";
            CheckButton(btnTV.Tag.ToString(), sizeTmp);
        }

        private void btnCIRC_Click(object sender, EventArgs e)
        {
            sizeTmp = txtDIR.Text.Length;
            txtDIR.Text += btnCIRC.Text + " ";
            CheckButton(btnCIRC.Tag.ToString(), sizeTmp);
        }

        private void btnAV_Click(object sender, EventArgs e)
        {
            sizeTmp = txtDIR.Text.Length;
            txtDIR.Text += btnAV.Text + " ";
            CheckButton(btnAV.Tag.ToString(), sizeTmp);
        }

        private void btnAUTO_Click(object sender, EventArgs e)
        {
            sizeTmp = txtDIR.Text.Length;
            txtDIR.Text += btnAUTO.Text + " ";
            CheckButton(btnAUTO.Tag.ToString(), sizeTmp);
        }

        private void btnBIS_Click(object sender, EventArgs e)
        {
            sizeTmp = txtDIR.Text.Length;
            txtDIR.Text += btnBIS.Text + " ";
            CheckButton(btnBIS.Tag.ToString(), sizeTmp);
        }

        private void btnBQ_Click(object sender, EventArgs e)
        {
            sizeTmp = txtDIR.Text.Length;
            txtDIR.Text += btnBQ.Text + " ";
            CheckButton(btnBQ.Tag.ToString(), sizeTmp);
        }

        private void btnINT_Click(object sender, EventArgs e)
        {
            sizeTmp = txtDIR.Text.Length;
            txtDIR.Text += btnINT.Text + " ";
            CheckButton(btnINT.Tag.ToString(), sizeTmp);
        }

        private void btnAPTO_Click(object sender, EventArgs e)
        {
            sizeTmp = txtDIR.Text.Length;
            txtDIR.Text += btnAPTO.Text + " ";
            CheckButton(lApto, sizeTmp);
            //CheckButton(btnAPTO.Tag.ToString(), sizeTmp);
        }

        private void btnOF_Click(object sender, EventArgs e)
        {
            sizeTmp = txtDIR.Text.Length;
            txtDIR.Text += btnOF.Text + " ";
            CheckButton(lApto, sizeTmp);
            //CheckButton(btnOF.Tag.ToString(), sizeTmp);
        }

        private void btnLOC_Click(object sender, EventArgs e)
        {
            sizeTmp = txtDIR.Text.Length;
            txtDIR.Text += btnLOC.Text + " ";
            CheckButton(lApto, sizeTmp);
            //CheckButton(btnLOC.Tag.ToString(), sizeTmp);
        }

        private void btnBOD_Click(object sender, EventArgs e)
        {
            sizeTmp = txtDIR.Text.Length;
            txtDIR.Text += btnBOD.Text + " ";
            CheckButton(btnBOD.Tag.ToString(), sizeTmp);
        }

        private void btnSMZ_Click(object sender, EventArgs e)
        {
            sizeTmp = txtDIR.Text.Length;
            txtDIR.Text += btnSMZ.Text + " ";
            CheckButton(btnSMZ.Tag.ToString(), sizeTmp);
        }

        private void btnMZ_Click(object sender, EventArgs e)
        {
            sizeTmp = txtDIR.Text.Length;
            txtDIR.Text += btnMZ.Text + " ";
            CheckButton(btnMZ.Tag.ToString(), sizeTmp);
        }

        private void btnVIA_Click(object sender, EventArgs e)
        {
            sizeTmp = txtDIR.Text.Length;
            txtDIR.Text += btnVIA.Text + " ";
            CheckButton(btnVIA.Tag.ToString(), sizeTmp);
        }

        private void btnKM_Click(object sender, EventArgs e)
        {
            sizeTmp = txtDIR.Text.Length;
            txtDIR.Text += btnKM.Text + " ";
            CheckButton(btnKM.Tag.ToString(), sizeTmp);
        }

        private void btnGUION_Click(object sender, EventArgs e)
        {
            sizeTmp = txtDIR.Text.Length;
            txtDIR.Text += btnGUION.Text + " ";
            CheckButton(btnGUION.Tag.ToString(), sizeTmp);
        }

        private void btnNUMERO_Click(object sender, EventArgs e)
        {
            sizeTmp = txtDIR.Text.Length;
            txtDIR.Text += btnNUMERO.Text + " ";
            CheckButton(btnNUMERO.Tag.ToString(), sizeTmp);
        }

        private void btnNORTE_Click(object sender, EventArgs e)
        {
            sizeTmp = txtDIR.Text.Length;
            txtDIR.Text += btnNORTE.Text + " ";
            CheckButton(btnNORTE.Tag.ToString(), sizeTmp);
        }

        private void btnSUR_Click(object sender, EventArgs e)
        {
            sizeTmp = txtDIR.Text.Length;
            txtDIR.Text += btnSUR.Text + " ";
            CheckButton(btnSUR.Tag.ToString(), sizeTmp);
        }

        private void btnESTE_Click(object sender, EventArgs e)
        {
            sizeTmp = txtDIR.Text.Length;
            txtDIR.Text += btnESTE.Text + " ";
            CheckButton(btnESTE.Tag.ToString(), sizeTmp);
        }

        private void btnOESTE_Click(object sender, EventArgs e)
        {
            sizeTmp = txtDIR.Text.Length;
            txtDIR.Text += btnOESTE.Text + " ";
            CheckButton(btnOESTE.Tag.ToString(), sizeTmp);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btn1.Text;

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btn2.Text;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btn3.Text;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btn4.Text;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btn5.Text;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btn6.Text;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btn7.Text;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btn8.Text;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btn9.Text;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btn0.Text;
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btnA.Text;
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btnB.Text;
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btnC.Text;
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btnD.Text;
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btnE.Text;
        }

        private void btnF_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btnF.Text;
        }

        private void btnG_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btnG.Text;
        }

        private void btnH_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btnH.Text;
        }

        private void btnI_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btnI.Text;
        }

        private void btnJ_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btnJ.Text;
        }

        private void btnK_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btnK.Text;
        }

        private void btnL_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btnL.Text;
        }

        private void btnM_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btnM.Text;
        }

        private void btnN_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btnN.Text;
        }

        private void btnEGNE_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btnEGNE.Text;
        }

        private void btnO_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btnO.Text;
        }

        private void btnP_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btnP.Text;
        }

        private void btnQ_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btnQ.Text;
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btnR.Text;
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btnS.Text;
        }

        private void btnT_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btnT.Text;
        }

        private void btnU_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btnU.Text;
        }

        private void btnV_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btnV.Text;
        }

        private void btnW_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btnW.Text;
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btnX.Text;
        }

        private void btnY_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btnY.Text;
        }

        private void btnZ_Click(object sender, EventArgs e)
        {
            txtVariable.Text += btnZ.Text;
        }

        private void btnSPACE_Click(object sender, EventArgs e)
        {
            if (txtVariable.Text[txtVariable.Text.Length - 1] != ' ')
                txtVariable.Text += " ";
        }

        private void btnDEL_Click(object sender, EventArgs e)
        {
            if (txtVariable.Text != "")
            {
                string atext = txtVariable.Text.Substring(0, txtVariable.Text.Length - 1);
                txtVariable.Text = atext;
            }
        }
#endregion

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            UtilsForms.ShowCursor(true);
            Address = txtDIR.Text;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            UtilsForms.ShowCursor(false);
            this.Close();
        }

        private void btnAceptarVariable_Click(object sender, EventArgs e)
        {
            if (txtVariable.Text != "")
            {
                sizeTmp = txtDIR.Text.Length;
                txtDIR.Text += txtVariable.Text + " ";
                picVariables.Visible = false;
                //picBtnBase.Visible = false;
                btnDEL.Enabled = true;
                CheckButton(letra, sizeTmp);
            }
        }

        private void btnDELDIR_Click(object sender, EventArgs e)
        {
            if (txtDIR.Text != "")
            {
                int tam = PilaDef[tDef - 1, 1];
                string atext = txtDIR.Text.Substring(0, tam);
                txtDIR.Text = atext;
                //picBtnBase.Visible = false;
                Del_PilaDef();
            }
        }

        private void cerrarButton_Click(object sender, EventArgs e)
        {

        }


    }

    /// <summary>
    /// Nodos, Formación de la estructura de Grafos para Direcciones
    /// </summary>
    public class Nodos
    {

        public int Value;
        public int Index;
        public int[] Next = new int[6];

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="val">Valor del Nodo.  Indica el tipo de datos que soporta</param>
        public Nodos(int val)
        {
            Value = val;
            Index = 0;
        }
        /// <summary>
        /// Adiciona nodos siguientes al nodo Actual
        /// </summary>
        /// <param name="valor">Nodo Siguiente en el grafo</param>
        public void AddNext(int valor)
        {
            Next[Index] = valor;
            Index++;
        }
        /// <summary>
        /// Adiciona Nodos, Solo es válido con el parámetro
        /// </summary>
        internal void AddNext()
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }

}