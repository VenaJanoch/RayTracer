using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RayTracer
{
   public abstract class Shape
    {
        protected Material material;

        protected Vector point;

        protected string type;

        public abstract Vector RandomPoint { get; }


        public  Shape(Material material, Vector point, string type)
        {
            this.material = material;
            this.point = point;
            this.type = type;
        }

        public Material Material { get { return material; } }

        public Vector Point { get { return point; } }
        
        public string Type
        {
            get { return type; }
            set
            {
                if (value.Contains("Camera"))
                {
                    type = value;
                }
            }
        }

      
         /// <summary>
         /// Metoda pro vypocet kolize objektu s paprsekem
         /// Vraci objekt Inteseciton s potrebnymi informacemi pro vykresleni barvy
         /// Pokud neni objek v kolizi vraci prazdnou instanci
         /// </summary>
         /// <param name="ray">Paprsek Ray</param>
         /// <returns>Inresction Objekt</returns>
        public abstract Intersection Intersect(Ray ray);

        /// <summary>
        /// Metoda pro vypis inforamci o objektu do XML 
        /// </summary>
        /// <param name="doc">Xml dokument</param>
        /// <returns>XmlElement s infomace o objektu</returns>
        public abstract XmlElement GetInXML(XmlDocument doc);


        public override string ToString()
        {
            return material.ToString() + "\r\n" + point.ToString();
        }

    }
}
