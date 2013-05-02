using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace PrOMCore.Utils
{
    public class PrOMXMLReader
    {
        private XmlTextReader textReader; 
        public PrOMXMLReader(string path)
        {
            this.textReader = new XmlTextReader(path);
        }

        public object GetObject(Type typeObject, string idObject)
        { 
            object objectReturn = null;
            try
            {
                objectReturn = typeObject.Assembly.CreateInstance(typeObject.FullName);
                FillFields(objectReturn, idObject);
                /*typeObject.GetFields
                System.Reflection.Assembly.GetExecutingAssembly().
                 * */
            }
            catch (Exception exception)
            {
                Exceptions.LoggerException.PublishException(exception, true);
            }
            return objectReturn;
        }

        private void FillFields(object o, string idObject)
        {

            textReader.Read();
            System.Reflection.FieldInfo[] fieldInfo;
            fieldInfo = o.GetType().GetFields();

            while (textReader.Read())
            {
                XmlNodeType nType = textReader.NodeType;
                Console.WriteLine("Leyendo {0}", textReader.Name);
                if ((nType == XmlNodeType.Element) && (textReader.Name.ToUpper() == o.GetType().Name.ToUpper()))
                {
                    System.Collections.Hashtable hashtable = new System.Collections.Hashtable();
                    hashtable = this.ReadAttributes();
                    //si se leyeron atributos se asume que el primerro es el ID
                    if (hashtable.Count > 0 && ((string)hashtable[0]) == idObject)
                    {
                        while (textReader.Read())
                        {
                            nType = textReader.NodeType;
                            if ((nType == XmlNodeType.Element) && textReader.Name != string.Empty )
                            {
                                for (int j = 0; j < fieldInfo.Length; j++)
                                {
                                    if (fieldInfo[j].Name.ToUpper() == textReader.Name.ToUpper())
                                    {
                                        textReader.Read();
                                        textReader.Read();
                                        fieldInfo[j].SetValue(o, textReader.Name);
                                        textReader.Read();
                                        textReader.Read();
                                    }
                                }
                            }
                        }
                    }
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
            /*while (textReader.Read())
            {
                String juega = "";
                if ((_reader.GetAttribute("juega") == _donde) && (_reader.Name == "equipo"))
                {
                    _reader.Read();
                    juega = _reader.Value;
                }
            }
            _reader.Read();
             * */
            return hashtable;
        }

    }
}
