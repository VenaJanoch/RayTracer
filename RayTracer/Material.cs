using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RayTracer
{
    /*
     * Trida predstavujici povrh daneho objektu 
     */
    public class Material
    {
        /* Barva ulozena pomoci Tridy Vector */
        public Vector Color { get; }
        
        public Material(Vector color)
        {
            Color = color;
        }

        public override string ToString()
        {
            return  Color.ToString() ;
        }

        /*
         *Metoda pro vypis inforamci o materialu objektu, ktery ho predstavuje do XML 
         */
        internal XmlElement GetInXML(XmlDocument doc)
        {
            XmlElement materialElm = doc.CreateElement("material");
            XmlElement color = Color.GetInXML(doc); 

            materialElm.AppendChild(color);
           
            return materialElm;
        }
    }


}
