using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RayTracer
{

    class Scene
    {
        
        private Camera camera;
        private FileManipulator fileManipulator;
        private RenderManager RenderManager;

        private const double AmbientLight = 0.60;
        private const double Reflectivity = 0.30;

        public Scene(string input_file)
        {
            
            fileManipulator = new FileManipulator();

            fileManipulator.loadSceneFromTXT(input_file);

            Console.WriteLine(SceneInfoContainer.toString());

            for(int i = 0; i < SceneInfoContainer.shapeCount; i++)
            {
                Console.WriteLine(SceneInfoContainer.shapes[i].ToString());
            }

            
            double aspect = (double)(SceneInfoContainer.screenWidth / SceneInfoContainer.screenHeight);
            camera = Camera.LookAt(new Vector(6.0, 3.0, 12.0), new Vector(), aspect, 60.0);

            RenderManager = new RenderManager(this, camera, fileManipulator);

            RenderManager.RenderingPicture();

            fileManipulator.FileWriter.Close();
        }

        public Scene()
        {
            fileManipulator = new FileManipulator();

            Random random = new Random();

            SceneInfoContainer.shapes = new Shape[SceneInfoContainer.shapeCount];
            double width, height, depth;
            for (int i = 0; i < SceneInfoContainer.shapeCount; ++i)
            {
                if (random.Next(2) == 0)
                {
                    SceneInfoContainer.shapes[i] = new Sphere(new Material(Vector.RandomColor),
                        Vector.RandomPointInSphere(SceneInfoContainer.radius), 0.5 + random.NextDouble());
                }
                else
                {

                    width = 0.5 + random.NextDouble();
                    height = 0.5 + random.NextDouble();
                    depth = 0.5 + random.NextDouble();

                    SceneInfoContainer.shapes[i] = new Cuboid(new Material(Vector.RandomColor),
                        Vector.RandomPointInCuboid(width,height,depth), width,
                        height, depth);
                }
            }

            SceneInfoContainer.lights = new Light[SceneInfoContainer.lightCount];

            for (int i = 0; i < SceneInfoContainer.lightCount ; ++i)
            {                    Sphere sphere = new Sphere(new Material(Vector.RandomColor),
                        new Vector(0.0, 1.0, 0.0) + Vector.RandomPointInSphere(SceneInfoContainer.radius),
                        0.5 + random.NextDouble());
                    SceneInfoContainer.lights[i] = new Light(sphere);
            }

            fileManipulator.SaveSceneToTXT();

        }

        public Vector RayTrace(Ray ray)
        {
            Intersection nearestShape = NearestShape(ray);
            Intersection nearestLight = NearestLight(ray);

            if (nearestShape.T < nearestLight.T)
            {
                return this.PhongAt(nearestShape, ray);
            }
            else if (nearestLight.T < Intersection.MaxT)
            {
                return nearestLight.Material.Color;
            }
            else
            {
                return this.BackgroundColor(ray.Direction);
            }
        }


        private Vector BackgroundColor(Vector direction)
        {
            Vector horizonColor = new Vector (0.60, 0.80, 1.0);
            Vector  zenithColor = horizonColor * 0.70;
            double elevation = direction.Y;
            double percent = (elevation < 0.0) ? 0.0 : elevation;
            return horizonColor + ((zenithColor - horizonColor) * percent);
        }

        private double AmbientPercent(Vector point, Vector normal)
        {
            int unoccludedRays = 0;
            for (int n = 0; n < SceneInfoContainer.lightSamples; ++n)
            {
                Vector hemisphereDir = Vector.RandomHemisphereDirection(normal);
                Ray hemisphereRay = new Ray(point, hemisphereDir, Ray.InitialDepth);
                Intersection currentTry = this.NearestShape(hemisphereRay);
                if (currentTry.T == Intersection.MaxT)
                {
                    ++unoccludedRays;
                }
            }

            return ((double)unoccludedRays / SceneInfoContainer.lightSamples) * AmbientLight;
        }

        private Vector PhongAt(Intersection intersection, Ray ray)
        {
            Vector viewVector = -ray.Direction;
            Vector localNormal = (viewVector.Dot(intersection.Normal) > 0.0) ?
                intersection.Normal : -intersection.Normal;
            Vector localNormalEps = localNormal * Vector.EPSILON;
            Vector localNormalEpsPoint = intersection.Point + localNormalEps;

            Vector materialColor = intersection.Material.Color;
            Vector ambientColor = (materialColor * this.BackgroundColor(ray.Direction)) *
                this.AmbientPercent(localNormalEpsPoint, localNormal);

            Vector totalColor = ambientColor;

            foreach (Light light in SceneInfoContainer.lights)
            {
                Vector diffuseColorSum = new Vector();

                for (int n = 0; n < SceneInfoContainer.lightSamples; ++n)
                {
                    Vector lightDir = (light.Shape.RandomPoint - intersection.Point).Normalized;
                    Ray lightRay = new Ray(localNormalEpsPoint, lightDir, Ray.InitialDepth);
                    Intersection lightTry = light.Shape.Intersect(lightRay);
                    Intersection shadowTry = this.NearestShape(lightRay);

                    if (lightTry.T < shadowTry.T)
                    {
                        double lnDot = lightDir.Dot(localNormal);
                        Vector lightColor = light.Shape.Material.Color;
                        Vector diffuseColor = (materialColor * lightColor) * lnDot;
                        diffuseColorSum = diffuseColorSum + diffuseColor;
                    }
                }

                totalColor = totalColor + (diffuseColorSum * (1.0 / SceneInfoContainer.lightSamples));
            }

            if (ray.Depth < SceneInfoContainer.maxDepth)
            {
                Vector reflectDir = viewVector.Reflected(localNormal).Normalized;
                Ray reflectRay = new Ray(localNormalEpsPoint, reflectDir, ray.Depth + 1);
                Vector reflectColor = this.RayTrace(reflectRay) * Reflectivity;
                totalColor = totalColor + reflectColor;
            }

            return totalColor;
        }


        private Intersection NearestShape(Ray ray)
        {
            Intersection nearestHit = new Intersection();

            foreach (Shape shape in SceneInfoContainer.shapes)
            {
                Intersection currentTry = shape.Intersect(ray);

                if (currentTry.T < nearestHit.T)
                {
                    nearestHit = currentTry;
                }
            }

            return nearestHit;
        }

        private Intersection NearestLight(Ray ray)
        {
            Intersection nearestHit = new Intersection();

            foreach (Light light in SceneInfoContainer.lights)
            {
                Intersection currentTry = light.Shape.Intersect(ray);

                if (currentTry.T < nearestHit.T)
                {
                    nearestHit = currentTry;
                }
            }
            return nearestHit;
        }

    }
}
