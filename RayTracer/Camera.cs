﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer

{
   public class Camera
    {
        /** Globalni promenne tridy */

        public Vector eye { get; }
        public Vector forward { get; }
        public Vector right { get; }
        public Vector up { get; }

        public double FovY { get; set; }

        public static readonly Vector GlobalUp = new Vector(0.0, 1.0, 0.0);

        private Camera(Vector eye, Vector forward, Vector right, Vector up, double fovY)
        {
            this.eye = eye;
            this.forward = forward;
            this.right = right;
            this.up = up;
            this.FovY = fovY;
        }
        
        /// <summary>
        /// Metoda LookAt
        /// Umoznuje nastaveni kamery na zadanou polohu a uhel pohledu
        /// </summary>
        /// <param name="eye">Vector umisteni kamery</param>
        /// <param name="focus">Vector s bodem lomu</param>
        /// <param name="aspect">aspect</param>
        /// <param name="fovY">Uhel pohledu</param>
        /// <returns></returns>
        public static Camera LookAt(Vector eye, Vector focus, double aspect, double fovY)
        {
            
            double zoom = 1.0 / Math.Tan((fovY * 0.5) * (Math.PI / 180.0));

            Vector forward = (focus - eye).Normalized * zoom;
            Vector right = forward.Cross(GlobalUp).Normalized * aspect;
            Vector up = right.Cross(forward).Normalized;

            return new Camera(eye, forward, right, up, fovY);
        }

        
        
        /// <summary>
        /// Metoda ImageRay
        /// Tato metoda vraci instanci paprsku Ray vypoctenou z danych bodu
        /// </summary>
        /// <param name="xx">double x souradnice</param>
        /// <param name="yy">double y souradnice</param>
        /// <returns></returns>
        public Ray ImageRay(double xx, double yy)
        {
            Vector rightComp = right * ((2.0 * xx) - 1.0);
            Vector upComp = up * ((2.0 * yy) - 1.0);
            Vector direction = (forward + rightComp - upComp).Normalized;
            return new Ray(eye, direction, Ray.InitialDepth);
        }
    }
}

