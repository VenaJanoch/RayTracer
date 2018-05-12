using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer
{

    /// <summary>
    /// Trida predstavujici paprsek vychazejici z kamery
    /// </summary>
    public class Ray
    {
        public Vector Point { get; }
        public Vector Direction { get; }
        public int Depth { get; }

        public const int InitialDepth = 0;

        public Ray(Vector point, Vector direction, int depth)
        {
            Point = point;
            Direction = direction;
            Depth = depth;
        }

       
        public Vector PointAt(double distance)
        {
            return Point + (Direction * distance);
        }
    }
}
