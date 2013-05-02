using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace PrOMCore.Windows.Forms
{
    delegate void UpdateComponent();

    public class PrOMBanner : System.Windows.Forms.Control
    {
        private int m_Speed;
        private int m_TextPosition;
        private Thread m_ThreadBanner;
        private bool m_Continue;
        private SizeF textSize;
        private bool firstPaint;
        private Bitmap m_bmpOffscreen;
        private int xxx = 2;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public PrOMBanner()
        {
            InitializeComponent();
            this.m_Speed = 50;
            this.m_Continue = false;
            this.firstPaint = true;
            this.m_TextPosition = 0;
            this.m_ThreadBanner = new Thread(new ThreadStart(this.threadBanner_Event));

        }

        public int Speed
        {
            get { return m_Speed; }
            set { m_Speed = value; }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                //Find out the size of the text
                textSize = new SizeF();
                Graphics g = this.CreateGraphics();
                textSize = g.MeasureString(this.Text, this.Font);
                g.Dispose();
            }
        }

        

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics gxOff;	   //Offscreen graphics
            Rectangle r = this.ClientRectangle;
            r.Width -= 1;
            r.Height -= 1;
            if (this.firstPaint)
            {
                this.m_TextPosition = r.Width;
                this.firstPaint = false;
            }

            if (m_bmpOffscreen == null) //Bitmap for doublebuffering
            {
                m_bmpOffscreen = new Bitmap(ClientSize.Width, ClientSize.Height);
            }

            gxOff = Graphics.FromImage(m_bmpOffscreen);

            gxOff.Clear(this.BackColor);

            this.DrawRec(gxOff);
            this.DrawText(gxOff);

            //Draw from the memory bitmap
            pe.Graphics.DrawImage(this.m_bmpOffscreen, 0, 0);

            // Calling the base class OnPaint
            base.OnPaint(pe);

            if (!this.m_Continue)
            {
                this.m_Continue = true;
                this.m_ThreadBanner.Start();
            }
        }

        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
        {
            //Do nothing
        }

        private void DrawRec(Graphics graphics)
        {
            Rectangle r = this.ClientRectangle;
            SolidBrush solidBrush = new SolidBrush(this.BackColor);
            graphics.FillRectangle(solidBrush, r);
        }

        private void DrawText(Graphics graphics)
        {
            Pen pen = new Pen(Color.Black, 3);

            SolidBrush drawBrush = new SolidBrush(this.BackColor);

            Rectangle r = this.ClientRectangle;

            if (this.m_TextPosition + textSize.Width <= xxx)
                this.m_TextPosition = this.Width - xxx;

            //Work out how to position the text centrally
            float x = 0, y = 0;
            if (textSize.Height < Height)
                y = (int)(this.Height - textSize.Height) / 2;

            x = this.m_TextPosition;

            //Draw the text in the vertical center of the PrOMBanner using
            // the default font
            drawBrush = new SolidBrush(this.ForeColor);
            graphics.DrawString(this.Text, this.Font, drawBrush, x, y);

            r.Width -= 1;
            r.Height -= 1;

            graphics.DrawRectangle(pen, r);


            this.m_TextPosition -= xxx;
       }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            this.m_ThreadBanner.Abort();
            this.m_Continue = false;
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // PrOMBanner
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ResumeLayout(false);

        }

        #endregion

        private void UpdateComponentEvent()
        {
            this.Invalidate();
            /*Graphics g = this.CreateGraphics();
            PaintEventArgs pe = new PaintEventArgs(g, this.Bounds);
            this.DrawRec(pe);
            this.DrawText(pe);
             * */

        }
        private void threadBanner_Event()
        {
            while (this.m_Continue)
            {
                this.Invoke(new UpdateComponent(this.UpdateComponentEvent));
                Thread.Sleep(this.m_Speed);
            }
        }
    }
}
