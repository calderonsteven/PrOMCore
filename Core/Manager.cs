using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using PrOMCore.Windows.Forms;
using PrOMCore.Utils;

namespace PrOMCore.Core
{
    public class Manager
    {
        /// <summary>
        /// Contiene Datos de Sesion, 
        /// </summary>
        public static Dictionary<string, object> Session = new Dictionary<string, object>();


        private static Manager m_Manager;
        private XmlTextReader textReader;

        private Manager()
        {
            Session["CONNECTIONSTRING"] = "Data Source = " + PrOMTools.ApplicationDirectory + @"\DB\SFACatana.sdf;";
        }

        /// <summary>
        /// Obtiene una instancia de un objeto en memoria
        /// </summary>
        /// <returns>Instancia del objeto</returns>
        public static Manager GetInstance()
        {
            if (m_Manager == null)
            {
                m_Manager = new Manager();
            }

            return m_Manager;
        }

        public Form GetForm(string formName)
        {
            return new Form();
        }

        public void CreateToolbarFromConfig(ToolBar toolBar, string idToolBar)
        {
            System.Windows.Forms.ImageList imageList = new ImageList();
            toolBar.ImageList = imageList;
            ToolBarButton toolBarButton;
            List<ToolBarButton> toolBarButtonList = new List<ToolBarButton>();
            try
            {
                this.textReader = new XmlTextReader(PrOMTools.ApplicationDirectory + "\\PrOMAppConfig.xml");

                while (textReader.Read())
                {
                    XmlNodeType nType = textReader.NodeType;
                    int i = 0;
                    if ((nType == XmlNodeType.Element) && (textReader.Name.ToUpper() == toolBar.GetType().Name.ToUpper()))
                    {
                        System.Collections.Hashtable hashtable = new System.Collections.Hashtable();
                        hashtable = this.ReadAttributes();
                        //si se leyeron atributos se asume que el primero es el ID
                        if (hashtable.Count > 0 && ((string)hashtable[0]) == idToolBar)
                        {
                            while (textReader.Read())
                            {
                                nType = textReader.NodeType;
                                if ((nType == XmlNodeType.Element) && textReader.Name != "button")
                                {
                                    return;
                                }
                                if ((nType == XmlNodeType.Element) && textReader.Name == "button")
                                {
                                    hashtable = this.ReadAttributes();
                                    toolBarButton = new ToolBarButton();
                                    if ((string)hashtable[0] != string.Empty)
                                    {
                                        imageList.Images.Add(new System.Drawing.Bitmap(PrOMTools.ApplicationDirectory + "\\img\\" + hashtable[0]));
                                    }
                                    toolBarButton.ToolTipText = (string)hashtable[1];
                                    toolBarButton.ImageIndex = i++;
                                    toolBarButtonList.Add(toolBarButton); 

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Exceptions.LoggerException.PublishException(exception, true);
            }
            finally
            {
                if (this.textReader != null)
                {
                    this.textReader.Close();
                }
                this.textReader = null;
                
                PrOMCore.Windows.Forms.UtilsForms.PrepararImageList(toolBar.ImageList);
                foreach (ToolBarButton toolBarButtonNew in toolBarButtonList)
                {
                    toolBar.Buttons.Add(toolBarButtonNew);
                }

            }
        }

        public void CreatePrOMFlowToolbarMenuFromConfig(PrOMFlowToolbar PrOMFlowToolbar, string idPrOMFlowToolbar)
        {
            System.Windows.Forms.ImageList imageList = new ImageList();
            PrOMFlowToolbar.ImageList = imageList;
            PrOMFlowToolbarButton PrOMFlowToolbarButton;
            List<PrOMButton> PrOMButtonList = new List<PrOMButton>(); 
            try
            {
                this.textReader = new XmlTextReader(PrOMTools.ApplicationDirectory + "\\PrOMAppConfig.xml");

                while (textReader.Read())
                {
                    XmlNodeType nType = textReader.NodeType;
                    int i = 0;
                    if ((nType == XmlNodeType.Element) && (textReader.Name.ToUpper() == PrOMFlowToolbar.GetType().Name.ToUpper()))
                    {
                        System.Collections.Hashtable hashtable = new System.Collections.Hashtable();
                        hashtable = this.ReadAttributes();
                        //si se leyeron atributos se asume que el primero es el ID
                        if (hashtable.Count > 0 && ((string)hashtable[0]) == idPrOMFlowToolbar)
                        {
                            while (textReader.Read())
                            {
                                nType = textReader.NodeType;
                                if ((nType == XmlNodeType.Element) && textReader.Name != "button")
                                {
                                    return;
                                }
                                if ((nType == XmlNodeType.Element) && textReader.Name == "button")
                                {
                                    hashtable = this.ReadAttributes();
                                    PrOMFlowToolbarButton = new PrOMFlowToolbarButton();
                                    if ((string)hashtable[0] != string.Empty)
                                    {
                                        imageList.Images.Add(new System.Drawing.Bitmap(PrOMTools.ApplicationDirectory + "\\img\\" + hashtable[0]));
                                    }
                                    PrOMFlowToolbarButton.Text = (string)hashtable[1];
                                    PrOMFlowToolbarButton.ToolTipText = (string)hashtable[2];
                                    if (hashtable.Count == 4)
                                    {
                                        PrOMFlowToolbarButton.Enabled = bool.Parse((string)hashtable[3]);
                                    }
                                    PrOMFlowToolbarButton.ImageIndex = i++;
                                    PrOMButtonList.Add(PrOMFlowToolbarButton); 

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Exceptions.LoggerException.PublishException(exception, true);
            }
            finally
            {
                if (this.textReader != null)
                {
                    this.textReader.Close();
                }
                this.textReader = null;
                
                PrOMCore.Windows.Forms.UtilsForms.PrepararImageList(PrOMFlowToolbar.ImageList);
                foreach (PrOMFlowToolbarButton PrOMButton in PrOMButtonList)
                {
                    PrOMFlowToolbar.AddButton(PrOMButton);
                }

            }
        }
        private System.Collections.Hashtable ReadAttributes()
        {
            System.Collections.Hashtable hashtable = new System.Collections.Hashtable();
            for (int i = 0; textReader.HasAttributes && i < textReader.AttributeCount; i++)
            {
                hashtable.Add(i, textReader.GetAttribute(i));
            }
            return hashtable;
        }
    }
}
