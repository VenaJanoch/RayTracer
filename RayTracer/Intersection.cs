using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer
{

    /// <summary>
    /// Trida uchovavajici inforamce o kolizi paprsku s objektem
    /// </summary>
    public class Intersection
    {
        public double T { get; }
        public Vector Point { get; }
        public Vector Normal { get; }
        public Material Material { get; }

        public const double MaxT = 1.0e30;

        public Intersection()
        {
            T = MaxT;
            Point = null;
            Normal = null;
            Material = null;
        }

        /// <summary>
        /// Metoda urcena pro nastaveni dat o kolizi do tridy
        /// </summary>
        /// <param name="t"></param>
        /// <param name="point"></param>
        /// <param name="normal"></param>
        /// <param name="material"></param>
        public Intersection(double t, Vector point, Vector normal, Material material)
        {
            T = t;
            Point = point;
            Normal = normal;
            Material = material;
        }

    }
}
