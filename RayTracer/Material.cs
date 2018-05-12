using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RayTracer
{
    
    /// <summary>
    /// Trida predstavujici povrh daneho objektu
    /// </summary>
    public class Material
    {

        /// <summary>
        /// Barva ulozena pomoci Tridy Vector
        /// </summary>
        public Vector Color { get; }
        
        public Material(Vector color)
        {
            Color = color;
        }

        public override string ToString()
        {
            return  Color.ToString() ;
        }

        
        /// <summary>
        /// Metoda pro vypis inforamci o materialu objektu, ktery ho predstavuje do XML
        /// </summary>
        /// <param name="doc">XmlDocument doc</param>
        /// <returns>XmlElement s informacemi o materialu</returns>
        internal XmlElement GetInXML(XmlDocument doc)
        {
            XmlElement materialElm = doc.CreateElement("material");
            XmlElement color = Color.GetInXML(doc); 

            materialElm.AppendChild(color);
           
            return materialElm;
        }
    }


}
