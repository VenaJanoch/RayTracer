using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer
{
    public class Material
    {
        public Vector color { get; }
        
        public Material(Vector color)
        {
            this.color = color;
        }

        public override string ToString()
        {
            return  color.ToString() ;
        }
    }


}
