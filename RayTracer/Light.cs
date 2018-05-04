using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RayTracer
{
    public class Light
    {

        private Shape shape;

        public Light(Shape shape)
        {
            this.shape = shape;
        }

        public Shape Shape { get { return this.shape; } }

        public override string ToString()
        {
            return "l\r\n" + shape.ToString() ;
        }

        internal XmlNode GetInXML(XmlDocument doc)
        {
            XmlElement lightElem = doc.CreateElement("light");
            XmlElement shapeElem = shape.GetInXML(doc);
           
            lightElem.AppendChild(shapeElem);

            return lightElem;
        }
    }
}
