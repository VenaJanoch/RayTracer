using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer
{
    public class Material
    {
        public Vector Color { get; }
        
        public Material(Vector color)
        {
            Color = color;
        }

        public override string ToString()
        {
            return  Color.ToString() ;
        }
    }


}
