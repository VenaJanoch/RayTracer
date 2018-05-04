using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RayTracer
{
    public class Material
    {
        public Vector Color { get; }
        
        public Material(Vector color)
        {
            Color = color;
        }

        public override string ToString()
        {
            return  Color.ToString() ;
        }

        internal XmlElement GetInXML(XmlDocument doc)
        {
            XmlElement materialElm = doc.CreateElement("material");
            XmlElement color = Color.GetInXML(doc); 

            materialElm.AppendChild(color);
           
            return materialElm;
        }
    }


}
