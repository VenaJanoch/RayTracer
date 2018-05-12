using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RayTracer
{
    /*
     * Trida predsavujici svetelny prvek
     * Svetlo je tvoreno pomoci objektu Shape konkretne Sphere
     */ 
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

        /*
         *Metoda pro vypis inforamci o svetlu a objektu, ktery ho predstavuje do XML 
         */
        internal XmlNode GetInXML(XmlDocument doc)
        {
            XmlElement lightElem = doc.CreateElement("light");
            XmlElement shapeElem = shape.GetInXML(doc);
           
            lightElem.AppendChild(shapeElem);

            return lightElem;
        }
    }
}
