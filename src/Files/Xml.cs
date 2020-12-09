using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Reflection;

namespace JBAddons
{
    public class JBXml
    {
        private static string Path;
        private string EXE = Assembly.GetExecutingAssembly().GetName().Name;
        private XmlDocument doc = new XmlDocument();
        private XmlNode xml;

        public JBXml(string xmlPath)
        {
            Path = new FileInfo(xmlPath).FullName;
            doc.Load(Path);
            xml = doc.DocumentElement;
        }

        public string ReadNode(string node)
        {            
            foreach(XmlNode child in xml.ChildNodes)
            {             
                if(child.Name==node)
                {
                    return child.InnerText;
                }
            }          
            return "";
        }

        public string ReadAttrubiteByNode(string node, string attrubite, int index)
        {
            foreach(XmlNode child in xml.ChildNodes)
            {
                if (child.Name == node)
                {
                    string nodeAtt = child.Attributes[index].Name;
                    if (nodeAtt==attrubite)
                    {
                        return child.Attributes[index].InnerText;
                    }
                }
            }
            return "";
        }

        public int ReadNodeInt(string node)
        {
            return int.Parse(ReadNode(node));
        }
    }
}
