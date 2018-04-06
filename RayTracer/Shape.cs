using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RayTracer
{
   public abstract class Shape
    {
        protected Material material;

        protected Vector point;
        
        public abstract Vector RandomPoint { get; }


        public  Shape(Material material, Vector point)
        {
            this.material = material;
            this.point = point;
        }

        public Material Material { get { return material; } }

        public Vector Point { get { return point; } }
        

        public abstract Intersection Intersect(Ray ray);

        public override string ToString()
        {
            return material.ToString() + "\r\n" + point.ToString();
        }

    }
}
