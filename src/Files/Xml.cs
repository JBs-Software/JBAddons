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

        public string ReadAttrubite(string attrubite, int index)
        {
            foreach(XmlNode child in xml.ChildNodes)
            {
                string childAtt = child.Attributes[index].Value;
                if(childAtt==attrubite)
                {
                    return childAtt;
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
