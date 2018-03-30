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
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "s " +  base.ToString()+ " " + radius;
        }
    }
}
