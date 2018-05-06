using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer

{
   public class Camera
    {
        public Vector eye { get; }
        public Vector forward { get; }
        public Vector right { get; }
        public Vector up { get; }

        public static readonly Vector GlobalUp = new Vector(0.0, 1.0, 0.0);

        private Camera(Vector eye, Vector forward, Vector right, Vector up)
        {
            this.eye = eye;
            this.forward = forward;
            this.right = right;
            this.up = up;
        }

        public static Camera LookAt(Vector eye, Vector focus, double aspect, double fovY)
        {
            double zoom = 1.0 / Math.Tan((fovY * 0.5) * (Math.PI / 180.0));

            Vector forward = (focus - eye).Normalized * zoom;
            Vector right = forward.Cross(GlobalUp).Normalized * aspect;
            Vector up = right.Cross(forward).Normalized;

            return new Camera(eye, forward, right, up);
        }

        
        public Ray ImageRay(double xx, double yy)
        {
            Vector rightComp = right * ((2.0 * xx) - 1.0);
            Vector upComp = up * ((2.0 * yy) - 1.0);
            Vector direction = (forward + rightComp - upComp).Normalized;
            return new Ray(eye, direction, Ray.InitialDepth);
        }
    }
}

