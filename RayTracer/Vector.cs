using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RayTracer
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        private static ThreadLocal<Random> random =
            new ThreadLocal<Random>(() => new Random());

        public const double EPSILON = 1.0e-6;

        public Vector()
        {
            this.X = 0.0;
            this.Y = 0.0;
            this.Z = 0.0;
        }

        public Vector(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Vector(Vector v)
        {
            this.X = v.X;
            this.Y = v.Y;
            this.Z = v.Z;
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

        public int Brightness(Color c)
        {
            return (int)Math.Sqrt(
               c.R * c.R * .241 +
               c.G * c.G * .691 +
               c.B * c.B * .068);
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
                return new Vector(this.X * lenRecip, this.Y * lenRecip, this.Z * lenRecip);
            }
        }

        public double LengthSquared
        {
            get
            {
                return (this.X * this.X) + (this.Y * this.Y) + (this.Z * this.Z);
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
            return new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        public static Vector operator -(Vector v)
        {
            return new Vector(-v.X, -v.Y, -v.Z);
        }

        public static Vector operator *(Vector v1, double m)
        {
            return new Vector(v1.X * m, v1.Y * m, v1.Z * m);
        }

        public static Vector operator *(Vector v1, Vector v2)
        {
            return new Vector(v1.X * v2.X, v1.Y * v2.Y, v1.Z * v2.Z);
        }

        public double Dot(Vector v)
        {
            return (this.X * v.X) + (this.Y * v.Y) + (this.Z * v.Z);
        }

        public Vector Cross(Vector v)
        {
            return new Vector(
                (this.Y * v.Z) - (v.Y * this.Z),
                (v.X * this.Z) - (this.X * v.Z),
                (this.X * v.Y) - (v.X * this.Y));
        }

        public Vector Add(Vector v)
        {
            return new Vector(X + v.X, Y + v.Y, Z + v.Z);
        }
        public static Vector RandomPointInCuboid(double width, double height, double depth)
        {
            return new Vector(
                width * ((2.0 * random.Value.NextDouble()) - 1.0),
                height * ((2.0 * random.Value.NextDouble()) - 1.0),
                depth * ((2.0 * random.Value.NextDouble()) - 1.0));
        }

        public static Vector RandomHemisphereDirection(Vector normal)
        {
            Vector direction = new Vector(
                (2.0 * random.Value.NextDouble()) - 1.0,
                (2.0 * random.Value.NextDouble()) - 1.0,
                (2.0 * random.Value.NextDouble()) - 1.0).Normalized;
            return (direction.Dot(normal) > 0.0) ? direction : -direction;
        }

        internal static Vector RandomPointInPlane(double depth)
        {
            return new Vector(
                depth * ((2.0 * random.Value.NextDouble()) - 1.0),
                depth * ((2.0 * random.Value.NextDouble()) - 1.0),
                depth * ((2.0 * random.Value.NextDouble()) - 1.0)).Normalized;

        }

        public Vector Clamped(double low, double high)
        {
            return new Vector(
                (X > high) ? high : ((X < low) ? low : X),
                (Y > high) ? high : ((Y < low) ? low : Y),
                (Z > high) ? high : ((Z < low) ? low : Z));
        }

        public int toARGB()
        {
            byte a = 255;
            byte r = (byte)(this.X * 255.0);
            byte g = (byte)(this.Y * 255.0);
            byte b = (byte)(this.Z * 255.0);
            return (a << 24) | (r << 16) | (g << 8) | b;
        }
        public Vector Reflected(Vector normal)
        {
            return (normal * (2.0 * this.Dot(normal))) - this;
        }


        public Vector Clamped()
        {
            return this.Clamped(0.0, 1.0);
        }

        public Vector Lerp(Vector v, double percent)
        {
            return this + ((v - this) * percent);
        }

        public Vector Mult(double scalar)
        {
            return new Vector(X * scalar, Y * scalar, Z * scalar);
        }

        public override string ToString()
        {
            return X + "\r\n" + Y + "\r\n" + Z; 
        }


    }
}
