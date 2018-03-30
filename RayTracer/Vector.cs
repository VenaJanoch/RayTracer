using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RayTracer
{
    public class Vector
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

        private static ThreadLocal<Random> random =
            new ThreadLocal<Random>(() => new Random());

        public const double EPSILON = 1.0e-6;

        public Vector()
        {
            this.x = 0.0;
            this.y = 0.0;
            this.z = 0.0;
        }

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector(Vector v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }


        public static Vector RandomColor
        {
            get
            {
                return new Vector(
                    random.Value.NextDouble(),
                    random.Value.NextDouble(),
                    random.Value.NextDouble());
            }
        }

        public static Vector RandomPointInSphere(double radius)
        {
            return new Vector(
                (2.0 * random.Value.NextDouble()) - 1.0,
                (2.0 * random.Value.NextDouble()) - 1.0,
                (2.0 * random.Value.NextDouble()) - 1.0).Normalized *
                (random.Value.NextDouble() * radius);
        }

        public Vector Normalized
        {
            get
            {
                double lenRecip = 1.0 / this.Length;
                return new Vector(this.x * lenRecip, this.y * lenRecip, this.z * lenRecip);
            }
        }

        public double LengthSquared
        {
            get
            {
                return (this.x * this.x) + (this.y * this.y) + (this.z * this.z);
            }
        }


        public double Length
        {
            get
            {
                return Math.Sqrt(this.LengthSquared);
            }
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vector operator -(Vector v)
        {
            return new Vector(-v.x, -v.y, -v.z);
        }

        public static Vector operator *(Vector v1, double m)
        {
            return new Vector(v1.x * m, v1.y * m, v1.z * m);
        }

        public static Vector operator *(Vector v1, Vector v2)
        {
            return new Vector(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
        }

        public override string ToString()
        {
            return x + "\r\n" + y + "\r\n" + z; 
        }


    }
}
