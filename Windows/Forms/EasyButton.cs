using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace PrOMCore.Windows.Forms
{
    /*[ToolboxItem(true)]
    [ToolboxBitmap(typeof(PrOMButton))]
     * */
    public partial class PrOMButton : Control
    {
        private Image m_Image;
        private bool bPushed;
        private string m_TooltipText;
        private Bitmap m_bmpOffscreen;

        //TODO: Steven
        public string ToolTipText
        {
            get { return m_TooltipText; }
            set { m_TooltipText = value; }
        }

        public Image Imagen
        {
            get { return m_Image; }
            set
            {
                this.m_Image = value;
                this.m_Image = PrOMCore.Windows.Forms.UtilsForms.TuneImage(this.m_Image, this.BackColor);
                this.Invalidate();
            }
        }

        public PrOMButton()
        {
            InitializeComponent();
            this.bPushed = false;
            //default BackColor
            this.BackColor = SystemColors.Control;
            //default minimal size
            this.Size = new Size(16, 16); 
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g;
            Point pointDrawImage;
            
            Image imageToPaint;

            if (this.m_bmpOffscreen == null) //Bitmap for doublebuffering
            {
                this.m_bmpOffscreen = new Bitmap(ClientSize.Width, ClientSize.Height);
            }

            g = Graphics.FromImage(m_bmpOffscreen);

            g.Clear(this.BackColor);

            if (this.bPushed)
            {
                g.DrawRectangle(new Pen(Color.Gray), 0, 0, this.Width - 1, this.Height - 1);
                g.DrawLine(new Pen(Color.White), this.Width - 1, 1, this.Width - 1, this.Height);
                g.DrawLine(new Pen(Color.White), 1, this.Height - 1, this.Width, this.Height - 1);
            }
            else
            {
                g.DrawRectangle(new Pen(Color.White), 0, 0, this.Width - 1, this.Height - 1);
                g.DrawLine(new Pen(Color.Gray), this.Width - 1, 1, this.Width - 1, this.Height);
                g.DrawLine(new Pen(Color.Gray), 1, this.Height - 1, this.Width, this.Height - 1);
            }

            if (this.m_Image != null)
            {
                pointDrawImage = new Point((this.Width - this.m_Image.Width) / 2, (this.Height - this.m_Image.Height) / 2);
                imageToPaint = this.m_Image;
                if (!this.Enabled)
                {
                    imageToPaint = PrOMCore.Windows.Forms.UtilsForms.InactivateImage(imageToPaint, this.BackColor);
                }

                if (this.bPushed)
                {
                    g.DrawImage(imageToPaint, pointDrawImage.X + 1, pointDrawImage.Y + 1);
                }
                else
                {
                    g.DrawImage(imageToPaint, pointDrawImage.X, pointDrawImage.Y);
                }
            }

            RectangleF drawRect = new RectangleF(0, 0, this.Width, this.Height);
            SolidBrush drawBrush;
            
            if (this.Enabled)
                drawBrush = new SolidBrush(this.ForeColor);
            else
                drawBrush = new SolidBrush(SystemColors.InactiveBorder);

            //Find out the size of the text
            SizeF textSize = new SizeF();
            textSize = pe.Graphics.MeasureString(this.Text, this.Font);

            //Work out how to position the text centrally
            float x = 0, y = 0;
            if (textSize.Width < Width)
                x = (Width - textSize.Width) / 2;
            if (textSize.Height < Height)
                y = (Height - textSize.Height) / 2;

            //Draw the text in the center of the button using
            // the default font
            g.DrawString(this.Text, this.Font, drawBrush, x, y);

            //Draw from the memory bitmap
            pe.Graphics.DrawImage(m_bmpOffscreen, 0, 0);

            // Calling the base class OnPaint
            base.OnPaint(pe);
        }
        

        /*protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics gxOff;	   //Offscreen graphics
            Rectangle imgRect; //m_Image rectangle
            Brush backBrush;   //brush for filling a backcolor

            if (m_bmpOffscreen == null) //Bitmap for doublebuffering
            {
                m_bmpOffscreen = new Bitmap(ClientSize.Width, ClientSize.Height);
            }

            gxOff = Graphics.FromImage(m_bmpOffscreen);

            gxOff.Clear(this.BackColor);

            if (!bPushed)
                backBrush = new SolidBrush(Parent.BackColor);
            else //change the background when it's pressed
                backBrush = new SolidBrush(Color.LightGray);

            gxOff.FillRectangle(backBrush, this.ClientRectangle);

            if (m_Image != null)
            {
                //Center the m_Image relativelly to the control
                int imageLeft = (this.Width - m_Image.Width) / 2;
                int imageTop = (this.Height - m_Image.Height) / 2;

                if (!bPushed)
                {
                    imgRect = new Rectangle(imageLeft, imageTop, m_Image.Width, m_Image.Height);
                }
                else //The button was pressed
                {
                    //Shift the m_Image by one pixel
                    imgRect = new Rectangle(imageLeft + 1, imageTop + 1, m_Image.Width, m_Image.Height);
                }
                //Set transparent key
                ImageAttributes imageAttr = new ImageAttributes();
                imageAttr.SetColorKey(BackgroundImageColor(m_Image), BackgroundImageColor(m_Image));
                //Draw m_Image
                gxOff.DrawImage(m_Image, imgRect, 0, 0, m_Image.Width, m_Image.Height, GraphicsUnit.Pixel, imageAttr);
            }

            if (bPushed) //The button was pressed
            {
                //Prepare rectangle
                Rectangle rc = this.ClientRectangle;
                rc.Width--;
                rc.Height--;
                //Draw rectangle
                gxOff.DrawRectangle(new Pen(Color.Black), rc);
            }

            //Draw from the memory bitmap
            e.Graphics.DrawImage(m_bmpOffscreen, 0, 0);

            base.OnPaint(e);
        }*/

        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
        {
            //Do nothing
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            this.bPushed = true;
            this.Invalidate();
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            this.bPushed = false;
            this.Invalidate();
        }

        public new bool Enabled
        {
            get
            {
                return base.Enabled;
            }
            set
            {
                base.Enabled = value;
                this.Invalidate();
            }
        }

        private Color BackgroundImageColor(Image image)
        {
            Bitmap bmp = new Bitmap(image);
            return bmp.GetPixel(0, 0);
        }
    }
}
