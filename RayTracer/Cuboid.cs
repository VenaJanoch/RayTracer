using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer
{
   public class Cuboid : Shape
    {

        public double width { get; set; }
        public double height { get; set; }
        public double depth { get; set; }

        public Cuboid(Material material, Vector point, double width, double height, double depth)
            : base(material, point)
        {
            this.width = width;
            this.height = height;
            this.depth = depth;
        }

        public override Vector RandomPoint
        {
            get
            {
                return this.point +
                    Vector.RandomPointInCuboid(width, height, depth);
            }
        }

        public override Intersection Intersect(Ray ray)
        {
            double nMinX, nMinY, nMinZ, nMaxX, nMaxY, nMaxZ;
            double tMin, tMax;
            double tX1 = (-this.width + this.point.X - ray.Point.X) / ray.Direction.X;
            double tX2 = (this.width + this.point.X - ray.Point.X) / ray.Direction.X;

            if (tX1 < tX2)
            {
                tMin = tX1;
                tMax = tX2;
                nMinX = -this.width;
                nMinY = 0.0;
                nMinZ = 0.0;
                nMaxX = this.width;
                nMaxY = 0.0;
                nMaxZ = 0.0;
            }
            else
            {
                tMin = tX2;
                tMax = tX1;
                nMinX = this.width;
                nMinY = 0.0;
                nMinZ = 0.0;
                nMaxX = -this.width;
                nMaxY = 0.0;
                nMaxZ = 0.0;
            }

            if (tMin > tMax)
            {
                return new Intersection();
            }

            double tY1 = (-this.height + this.point.Y - ray.Point.Y) / ray.Direction.Y;
            double tY2 = (this.height + this.point.Y - ray.Point.Y) / ray.Direction.Y;

            if (tY1 < tY2)
            {
                if (tY1 > tMin)
                {
                    tMin = tY1;
                    nMinX = 0.0;
                    nMinY = -this.height;
                    nMinZ = 0.0;
                }
                if (tY2 < tMax)
                {
                    tMax = tY2;
                    nMaxX = 0.0;
                    nMaxY = this.height;
                    nMaxZ = 0.0;
                }
            }
            else
            {
                if (tY2 > tMin)
                {
                    tMin = tY2;
                    nMinX = 0.0;
                    nMinY = this.height;
                    nMinZ = 0.0;
                }
                if (tY1 < tMax)
                {
                    tMax = tY1;
                    nMaxX = 0.0;
                    nMaxY = -this.height;
                    nMaxZ = 0.0;
                }
            }

            if (tMin > tMax)
            {
                return new Intersection();
            }

            double tZ1 = (-this.depth + this.point.Z - ray.Point.Z) / ray.Direction.Z;
            double tZ2 = (this.depth + this.point.Z - ray.Point.Z) / ray.Direction.Z;

            if (tZ1 < tZ2)
            {
                if (tZ1 > tMin)
                {
                    tMin = tZ1;
                    nMinX = 0.0;
                    nMinY = 0.0;
                    nMinZ = -this.depth;
                }
                if (tZ2 < tMax)
                {
                    tMax = tZ2;
                    nMaxX = 0.0;
                    nMaxY = 0.0;
                    nMaxZ = this.depth;
                }
            }
            else
            {
                if (tZ2 > tMin)
                {
                    tMin = tZ2;
                    nMinX = 0.0;
                    nMinY = 0.0;
                    nMinZ = this.depth;
                }
                if (tZ1 < tMax)
                {
                    tMax = tZ1;
                    nMaxX = 0.0;
                    nMaxY = 0.0;
                    nMaxZ = -this.depth;
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

    }
}
