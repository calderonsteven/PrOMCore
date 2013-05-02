using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using PrOMCore.Windows.Forms;
using PrOMCore.Windows.Interop;
using PrOMCore.Core;


namespace PrOMCore.Windows.Forms
{
    public class UtilsForms
    {
        public static void ShowCursor(bool Visible)
        {
            if (Visible == true)
            {
                Cursor.Current = Cursors.WaitCursor;
                Cursor.Show();
            }
            else
            {
                Cursor.Current = Cursors.Default;
                Cursor.Hide();
            }
        }

        public static Image TuneImage(Image image, Color backColor)
        {
            Bitmap bmp = new Bitmap(image);
            Color colorTransparencia = bmp.GetPixel(0, 0);

            for (int h = 0; h < bmp.Height; h++)
                for (int w = 0; w < bmp.Width; w++)
                    if (bmp.GetPixel(w, h) == colorTransparencia)
                        bmp.SetPixel(w, h, backColor);

            return bmp;

        }

        public static void PrepararImageList(ImageList imagenesDelMenu)
        {
            List<Image> ImagenesEnBarra = new List<Image>();
            foreach (Image img in imagenesDelMenu.Images)
                ImagenesEnBarra.Add(img);

            imagenesDelMenu.Images.Clear();
            foreach (Image img in ImagenesEnBarra)
            {
                Bitmap bmp = new Bitmap(img);
                Color colorTransparencia = bmp.GetPixel(0, 0);

                for (int h = 0; h < bmp.Height; h++)
                    for (int w = 0; w < bmp.Width; w++)
                        if (bmp.GetPixel(w, h) == colorTransparencia)
                            bmp.SetPixel(w, h, SystemColors.Control);

                imagenesDelMenu.Images.Add(bmp);
            }
        }

        /// <summary>
        /// Oculta O Elimina el Boton del Sip(Soft Input Panel)
        /// </summary>
        /// <param name="Visible">Representa es eltado visible del sip.</param>
        /// <param name="RamboMode">Destruye la ventana del Sistema, No es necesaria para Ipaq</param>
        public static void ShowSipButton(bool Visible, bool RamboMode)
        {
            IntPtr windowH = Native.FindWindow("MS_SIPBUTTON", "MS_SIPBUTTON");

            if (windowH == IntPtr.Zero) return;

            if (Visible)
                Native.MoveWindow(windowH, 204, 295, 36, 24, false);
            else if (RamboMode)
                Native.DestroyWindow(windowH);//Puede Presentar errores en el manejador de ventanas de windows
            else
                Native.MoveWindow(windowH, 0, 0, 0, 0, false);
        }

        public static void CreatePrOMFlowToolbarMenu(PrOMFlowToolbar PrOMFlowToolbar)
        {
            PrOMFlowToolbarButton button;
            PrepararImageList(PrOMFlowToolbar.ImageList);

            for (int i = 0; i < PrOMFlowToolbar.ImageList.Images.Count; i++)
            {
                button = new PrOMFlowToolbarButton();
                button.ImageIndex = i;
                PrOMFlowToolbar.AddButton(button);
            }
        }


        public static void CreateToolbarMenu(ToolBar toolBar)
        {
            ToolBarButton toolBarButton;
            PrepararImageList(toolBar.ImageList);

            for (int i = 0; i < toolBar.ImageList.Images.Count; i++)
            {
                toolBarButton = new ToolBarButton();
                toolBarButton.ImageIndex = i;
                toolBar.Buttons.Add(toolBarButton);
            }
        }

        public static void CenterForm(Form formToCenter)
        {
            formToCenter.FormBorderStyle = FormBorderStyle.None;
            //Get the size of the screen for centering the form.
            Rectangle rectS = Screen.PrimaryScreen.Bounds;
            formToCenter.Location = new Point(Convert.ToInt32((rectS.Width - formToCenter.Width) / 2), Convert.ToInt32((rectS.Height - formToCenter.Height) / 2));
        }

        public static void MakeFlotableForm(Form formToFlotable)
        {
            ///HACK: suma el tamaño para pda de pidion (comparedos)
            formToFlotable.Height += 30;

            /****If you want display OK button on caption you can look at method: 
             * Win32Window.SetWindowLong(hWnd, GWL.EXSTYLE, style); 
             * For example: 
             * int style = (int)(WS.BORDER | WS.CAPTION | WS.DLGFRAME); 
             * Win32Window.SetWindowLong(hWnd, GWL.STYLE, style); 
             * style = (int)(WS_EX.DLGMODALFRAME | WS_EX.CAPTIONOKBUTTON); 
             * Win32Window.SetWindowLong(hWnd, GWL.EXSTYLE, style); 
             * ************/
            formToFlotable.FormBorderStyle = FormBorderStyle.None;
            IntPtr hWnd = formToFlotable.Handle;
            int style = (int)(WS.BORDER | WS.CAPTION | WS.DLGFRAME);
            int lastStyle = Native.SetWindowLong(hWnd, (int)GWL.STYLE, style);
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            int heightToolBar = 26;//26
            bool successWindowPos = Native.SetWindowPos(hWnd, 0, ((screen.Width - formToFlotable.Width) / 2), ((screen.Height - (formToFlotable.Height + heightToolBar)) / 2), formToFlotable.Width, formToFlotable.Height + heightToolBar, (int)SWP.NOACTIVATE);
        }

        public static void EAlert(string alert)
        {
            MessageBox.Show(alert, "PrOMNet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Muestra un formulario con el patron de unica vista de aplicación
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="formToShow"></param>
        public static void ShowForm(Form parent, Form formToShow)
        {
            ShowForm(parent, formToShow, true);
        }

        public static void ShowForm(Form parent, Form formToShow, bool modal)
        {
            string lastTitle = parent.Text;
            try
            {
                //this allow that the form parent not display in task bar
                parent.Text = "";
                if (modal)
                {
                    formToShow.Activated += new EventHandler(formToShow_Activated);
                    formToShow.ShowDialog();
                }
                else
                {
                    Manager.Session["CURRENTFORM"] = formToShow;
                    formToShow.Show();
                }
            }
            catch (Exception exception)
            {
                UtilsForms.ShowCursor(false);
                throw exception;
            }
            finally
            {
                parent.Text = lastTitle;
                parent.Visible = true;
            }
        }

        static void formToShow_Activated(object sender, EventArgs e)
        {
            Manager.Session["CURRENTFORM"] = sender;
        }



        public static Bitmap ConvertToGrayscale(Image source)
        {
            return ConvertToGrayscale(new Bitmap(source));
        }

        public static Bitmap ConvertToGrayscale(Bitmap source)
        {

            Bitmap bm = new Bitmap(source.Width, source.Height);

            for (int y = 0; y < bm.Height; y++)
            {

                for (int x = 0; x < bm.Width; x++)
                {
                    Color c = source.GetPixel(x, y);

                    int luma = (int)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);

                    bm.SetPixel(x, y, Color.FromArgb(luma, luma, luma));
                }

            }

            return bm;

        }

        public static Bitmap InactivateImage(Bitmap source, Color backColor)
        {
            Bitmap bm = new Bitmap(source.Width, source.Height);
            Color colorTransparencia = source.GetPixel(0, 0);

            for (int y = 0; y < bm.Height; y++)
            {
                for (int x = 0; x < bm.Width; x++)
                {
                    Color c = source.GetPixel(x, y);
                    if (c == Color.White)
                    {
                        c = backColor;
                    }
                    else if (c != colorTransparencia)
                    {
                        c = Color.DimGray;
                    }

                    bm.SetPixel(x, y, c);
                }

            }

            return bm;

        }

        public static Bitmap InactivateImage(Image source,Color backColor)
        {
            return InactivateImage(new Bitmap(source), backColor);
        }
    }
}
