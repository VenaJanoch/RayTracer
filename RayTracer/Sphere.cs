using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RayTracer
{
    public class Sphere : Shape
    {

        private double radius;
        private double radiusRecip;
        private double radiusSquared;

        public Sphere(Material material, Vector point, double radius)
            : base(material, point, "Sphere")
        {
            this.radius = radius;
            radiusRecip = 1.0 / radius;
            radiusSquared = radius * radius;
        }

        public override Vector RandomPoint
        {
            get
            {
                return point + Vector.RandomPointInSphere(radius);
            }
        }

        public override Intersection Intersect(Ray ray)
        {
            Vector diff = this.point - ray.Point;
            double b = diff.Dot(ray.Direction);
            double determinant = (b * b) - diff.Dot(diff) + radiusSquared;
            if (determinant < 0.0)
            {
                return new Intersection();
            }
            else
            {
                double detSqrt = Math.Sqrt(determinant);
                double b1 = b - detSqrt;
                double b2 = b + detSqrt;
                double t = (b1 > Vector.EPSILON) ? b1 :
                    ((b2 > Vector.EPSILON) ? b2 : Intersection.MaxT);
                Vector point = ray.PointAt(t);
                Vector normal = (point - this.point) * radiusRecip;
                return new Intersection(t, point, normal, material);
            }
        }

        public override string ToString()
        {           
            return "s\r\n" +  base.ToString()+ "\r\n" + radius + "\r\n";
        }

        public override XmlElement GetInXML(XmlDocument doc)
        {
            XmlElement shapeElm = doc.CreateElement("shape");
            XmlElement elem = doc.CreateElement("sphere");
            XmlElement pointElem = point.GetInXML(doc);
            XmlElement matElem = material.GetInXML(doc);
            XmlElement radElem = doc.CreateElement("radius");


            XmlText eText = doc.CreateTextNode(radius.ToString());

            radElem.AppendChild(eText);
            elem.AppendChild(radElem);
            elem.AppendChild(matElem);
            elem.AppendChild(pointElem);
            shapeElm.AppendChild(elem);

            return shapeElm;

        }

    }
}
