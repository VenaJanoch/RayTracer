using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RayTracer
{
    public class Plane : Shape
    {
        public double Distance { get; set; }
        
        public override Vector RandomPoint => throw new NotImplementedException();

        public Plane(Material material, Vector point, double distance)
            : base(material, point)
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

    }

}

