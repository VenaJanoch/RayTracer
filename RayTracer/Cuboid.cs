using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RayTracer
{
   public class Cuboid : Shape
    {

        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }


        public Cuboid(Material material, Vector point, double width, double height, double depth)
            : base(material, point, "Cuboid")
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public override Vector RandomPoint
        {
            get
            {
                return this.point +
                    Vector.RandomPointInCuboid(Width, Height, Depth);
            }
        }

        public override Intersection Intersect(Ray ray)
        {
            double nMinX, nMinY, nMinZ, nMaxX, nMaxY, nMaxZ;
            double tMin, tMax;
            double tX1 = (-Width + this.point.X - ray.Point.X) / ray.Direction.X;
            double tX2 = (Width + this.point.X - ray.Point.X) / ray.Direction.X;

            if (tX1 < tX2)
            {
                tMin = tX1;
                tMax = tX2;
                nMinX = -Width;
                nMinY = 0.0;
                nMinZ = 0.0;
                nMaxX = Width;
                nMaxY = 0.0;
                nMaxZ = 0.0;
            }
            else
            {
                tMin = tX2;
                tMax = tX1;
                nMinX = Width;
                nMinY = 0.0;
                nMinZ = 0.0;
                nMaxX = -Width;
                nMaxY = 0.0;
                nMaxZ = 0.0;
            }

            if (tMin > tMax)
            {
                return new Intersection();
            }

            double tY1 = (-Height + this.point.Y - ray.Point.Y) / ray.Direction.Y;
            double tY2 = (Height + this.point.Y - ray.Point.Y) / ray.Direction.Y;

            if (tY1 < tY2)
            {
                if (tY1 > tMin)
                {
                    tMin = tY1;
                    nMinX = 0.0;
                    nMinY = -Height;
                    nMinZ = 0.0;
                }
                if (tY2 < tMax)
                {
                    tMax = tY2;
                    nMaxX = 0.0;
                    nMaxY = Height;
                    nMaxZ = 0.0;
                }
            }
            else
            {
                if (tY2 > tMin)
                {
                    tMin = tY2;
                    nMinX = 0.0;
                    nMinY = Height;
                    nMinZ = 0.0;
                }
                if (tY1 < tMax)
                {
                    tMax = tY1;
                    nMaxX = 0.0;
                    nMaxY = -Height;
                    nMaxZ = 0.0;
                }
            }

            if (tMin > tMax)
            {
                return new Intersection();
            }

            double tZ1 = (-Depth + this.point.Z - ray.Point.Z) / ray.Direction.Z;
            double tZ2 = (Depth + this.point.Z - ray.Point.Z) / ray.Direction.Z;

            if (tZ1 < tZ2)
            {
                if (tZ1 > tMin)
                {
                    tMin = tZ1;
                    nMinX = 0.0;
                    nMinY = 0.0;
                    nMinZ = -Depth;
                }
                if (tZ2 < tMax)
                {
                    tMax = tZ2;
                    nMaxX = 0.0;
                    nMaxY = 0.0;
                    nMaxZ = Depth;
                }
            }
            else
            {
                if (tZ2 > tMin)
                {
                    tMin = tZ2;
                    nMinX = 0.0;
                    nMinY = 0.0;
                    nMinZ = Depth;
                }
                if (tZ1 < tMax)
                {
                    tMax = tZ1;
                    nMaxX = 0.0;
                    nMaxY = 0.0;
                    nMaxZ = -Depth;
                }
            }

            if (tMin > tMax)
            {
                return new Intersection();
            }

            if (tMin < 0.0)
            {
                tMin = tMax;
                nMinX = nMaxX;
                nMinY = nMaxY;
                nMinZ = nMaxZ;
            }

            if (tMin >= 0.0)
            {
                double t = tMin;
                Vector point = ray.PointAt(t);
                Vector normal = new Vector(nMinX, nMinY, nMinZ).Normalized;
                return new Intersection(t, point, normal, this.material);
            }
            else
            {
                return new Intersection();
            }
        }

        public override string ToString()
        {
            return "c\r\n" + base.ToString() + "\r\n" + Width + "\r\n" + Height + "\r\n" + Depth + "\r\n";
        }

        public override XmlElement GetInXML(XmlDocument doc)
        {
            XmlElement shapeElm = doc.CreateElement("shape");
            XmlElement elem = doc.CreateElement("cuboid");
            XmlElement pointElem = point.GetInXML(doc);
            XmlElement matElem = material.GetInXML(doc);

            XmlElement widthElm = doc.CreateElement("width");
            XmlElement heightElm = doc.CreateElement("height");
            XmlElement depthElm = doc.CreateElement("depth");

            XmlText widthText = doc.CreateTextNode(Width.ToString());
            XmlText heightText = doc.CreateTextNode(Height.ToString());
            XmlText depthText = doc.CreateTextNode(Depth.ToString());

            widthElm.AppendChild(widthText);
            heightElm.AppendChild(heightText);
            depthElm.AppendChild(depthText);

            elem.AppendChild(widthElm);
            elem.AppendChild(heightElm);
            elem.AppendChild(depthElm);

            elem.AppendChild(matElem);
            elem.AppendChild(pointElem);
            shapeElm.AppendChild(elem);

            return shapeElm;

        }
    }
}
