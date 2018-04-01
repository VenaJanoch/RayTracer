using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer
{
    class Light
    {

        private Shape shape;

        public Light(Shape shape)
        {
            this.shape = shape;
        }

        public Shape Shape { get { return this.shape; } }

        public override string ToString()
        {
            return "l\r\n" + this.shape.ToString() ;
        }

    }
}
