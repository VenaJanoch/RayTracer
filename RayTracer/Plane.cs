using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RayTracer
{
    public class Plane : Shape
    {
        public double Distance { get; set; }

        public override Vector RandomPoint
        {
            get
            {
                return point + Vector.RandomPointInPlane(Distance);
            }
        }

        public Plane(Material material, Vector point, double distance)
            : base(material, point, "Plane")
        { 
           Distance = distance;  
        }

         
        public override Intersection Intersect(Ray ray)
        {
            double a = ray.Direction.Dot(Point);

            if (Math.Abs(a - 0d) < 0.01d)
            {
                
                return new Intersection();
            }

            double t = Point.Dot(ray.Point.Add(-Point.Mult(Distance)));

            Vector point = ray.PointAt(t);

            return new Intersection(t, point, this.point, material);

        }

        public override string ToString()
        {
            return "p\r\n" + base.ToString() + "\r\n" + Distance + "\r\n";
        }

        public override XmlElement GetInXML(XmlDocument doc)
        {
            XmlElement shapeElm = doc.CreateElement("shape");
            XmlElement elem = doc.CreateElement("plane");
            XmlElement pointElem = point.GetInXML(doc);
            XmlElement matElem = material.GetInXML(doc);
            XmlElement distElm = doc.CreateElement("distance");

            XmlText eText = doc.CreateTextNode(Distance.ToString());

            distElm.AppendChild(eText);
            elem.AppendChild(distElm);
            elem.AppendChild(matElem);
            elem.AppendChild(pointElem);
            shapeElm.AppendChild(elem);

            return shapeElm;

        }
        
    }

}

