using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RayTracer
{
    public class Sphere : Shape
    {

        private double radius;
        private double radiusRecip;
        private double radiusSquared;

        public Sphere(Material material, Vector point, double radius)
            : base(material, point)
        {
            this.radius = radius;
            this.radiusRecip = 1.0 / radius;
            this.radiusSquared = radius * radius;
        }

        public override Vector RandomPoint
        {
            get
            {
                return this.point + Vector.RandomPointInSphere(this.radius);
            }
        }

        public override Intersection Intersect(Ray ray)
        {
            Vector diff = this.point - ray.Point;
            double b = diff.Dot(ray.Direction);
            double determinant = (b * b) - diff.Dot(diff) + this.radiusSquared;
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
                Vector normal = (point - this.point) * this.radiusRecip;
                return new Intersection(t, point, normal, material);
            }
        }

        public override string ToString()
        {
            return "s\r\n" +  base.ToString()+ "\r\n" + radius + "\r\n";
        }
    }
}
