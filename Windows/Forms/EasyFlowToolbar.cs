using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PrOMCore.Windows.Forms
{
    public class PrOMFlowToolbar : Panel
    {
        List<PrOMButton> listadoBotones;
        private PrOMToolTip PrOMToolTipFlowToolbar;
        public event PrOMFlowToolbarEventHandler PrOMFlowToolbarClick;
        private ImageList m_ImageList;

        public ImageList ImageList
        {
            get { return m_ImageList; }
            set { m_ImageList = value; }
        }

        public PrOMFlowToolbar()
        {
            InitializeComponent();
            listadoBotones = new List<PrOMButton>();
        }

        public List<PrOMButton> Buttons
        {
            get { return this.listadoBotones; }
            set { this.listadoBotones = value; }
        }

        public void AddButton(PrOMFlowToolbarButton newButton)
        {
            newButton.Size = new System.Drawing.Size(20, 20);
            newButton.Location = new System.Drawing.Point((this.Controls.Count * newButton.Size.Width), 0);
            this.Size = new System.Drawing.Size(newButton.Location.X + newButton.Width, newButton.Size.Height);
            newButton.Click += new EventHandler(newButton_Click);
            newButton.Imagen = this.ImageList.Images[newButton.ImageIndex];
            this.listadoBotones.Add(newButton);
            this.Controls.Add(newButton);
            //this.PrOMToolTipFlowToolbar.SetTooltipText(newButton, newButton.ToolTipText);
        }

        void newButton_Click(object sender, EventArgs e)
        {
            OnPrOMFlowToolbarClick(sender);
        }

        protected void OnPrOMFlowToolbarClick(object sender)
        {
            if (this.PrOMFlowToolbarClick != null)
            {
                PrOMToolBarButtonClickEventArgs PrOMToolBarButtonClickEventArgs = new PrOMToolBarButtonClickEventArgs((PrOMFlowToolbarButton)sender);
                this.PrOMFlowToolbarClick(this, PrOMToolBarButtonClickEventArgs);
            }
        }

        private void InitializeComponent()
        {
            this.PrOMToolTipFlowToolbar = new PrOMCore.Windows.Forms.PrOMToolTip();
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }

    public class PrOMFlowToolbarButton : PrOMButton
    {
        private int m_ImageIndex;

        public int ImageIndex
        {
            get { return m_ImageIndex; }
            set { m_ImageIndex = value; }
        }
    }

    public class PrOMToolBarButtonClickEventArgs : EventArgs
    {
        PrOMFlowToolbarButton m_PrOMFlowToolbarButton;

        public PrOMFlowToolbarButton Button
        {
            get { return m_PrOMFlowToolbarButton; }
        }

        public PrOMToolBarButtonClickEventArgs(PrOMFlowToolbarButton PrOMFlowToolbarButton)
        {
            this.m_PrOMFlowToolbarButton = PrOMFlowToolbarButton;
        }
    }

    public delegate void PrOMFlowToolbarEventHandler(object sender, PrOMToolBarButtonClickEventArgs PrOMToolBarButtonClickEventArgs);
}
