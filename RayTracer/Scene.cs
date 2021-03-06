﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RayTracer
{

    /// <summary>
    /// Trida predstavujici scenu, ktera je nasledne vyrenderovana do PNG formatu
    /// </summary>
    public class Scene
    {
        
        public Camera Camera { get; set; }
        
        private const double AmbientLight = 0.60;
        private const double Reflectivity = 0.30;

        public bool IsLoad { get; set; } = false;

        public Bitmap Image { get; set; }

        public const double radius = 10.0;

        public List<Shape> Shapes { get; set; }
        public List<Light> Lights { get; set; } 

        public string sceneOutputFilePath { get; set; }
        public string sceneInputFilePath { get; set; }
        public string imageOutputFilePath { get; set; }
        public int screenWidth { get; set; }
        public int screenHeight { get; set; }
        public int superSamples { get; set; }
        public int shapeCount { get; set; }
        public int lightCount { get; set; }
        public int lightSamples { get; set; }
        public int indirectLightSamples { get; set; }
        public int maxDepth { get; set; }


        /// <summary>
        /// Metoda slouzi k naplneni statickych informaci o scene
        /// Spolu o poctu objektu a svetel pro automaticke vygenerovani objektu a svetel na scenu
        /// </summary>
        /// <param name="outputFile">vystupni soubor</param>
        /// <param name="imgFile">vystupni soubor obrazku</param>
        /// <param name="width">sirka</param>
        /// <param name="height">vyska</param>
        /// <param name="superSamples">vzorky</param>
        /// <param name="shapeCount">pocet objektu</param>
        /// <param name="lightCount">pocet svetel</param>
        /// <param name="lightSamples">pocet vzorku svetel</param>
        /// <param name="indirectLightSamples">pocet neprimych svetel</param>
        /// <param name="maxDepth">hloubka</param>
        public void FillScene(string sceneOutputFilePath, string imageOutputFilePath,
            int screenWidth, int screenHeight, int superSamples, int shapeCount, int lightCount, int lightSamples,
            int indirectLightSamples, int maxDepth)
        {

            FillStaticInfo(sceneOutputFilePath, imageOutputFilePath,
            screenWidth, screenHeight, superSamples, lightSamples,
            indirectLightSamples, maxDepth);

            this.shapeCount = shapeCount;
            this.lightCount = lightCount;

            Random random = new Random();

            CreateShapes(random);
            CreateLights(random);

            IsLoad = true;

        }


        /// <summary>
        /// Metoda slouzi k naplneni statickych informaci o scene
        /// </summary>
        /// <param name="outputFile">vystupni soubor</param>
        /// <param name="imgFile">vystupni soubor obrazku</param>
        /// <param name="width">sirka</param>
        /// <param name="height">vyska</param>
        /// <param name="superSamples">vzorky</param>
        /// <param name="lightSamples">pocet vzorku svetel</param>
        /// <param name="indirectLightSamples">pocet neprimych svetel</param>
        /// <param name="maxDepth">hloubka</param>
        public void  FillStaticInfo(string sceneOutputFilePath, string imageOutputFilePath,
            int screenWidth, int screenHeight, int superSamples, int lightSamples,
            int indirectLightSamples, int maxDepth)
        {
            this.sceneOutputFilePath = sceneOutputFilePath;
            this.imageOutputFilePath = imageOutputFilePath;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.superSamples = superSamples;
            this.lightSamples = lightSamples;
            this.indirectLightSamples = indirectLightSamples;
            this.maxDepth = maxDepth;

        }

        /// <summary>
        /// Metoda slouzi k automatickemu vygenerovani svetel na scenu v pozadovanem poctu
        /// </summary>
        /// <param name="random">Random generator cisel</param>
        private void CreateLights(Random random)
        {
            Lights = new List<Light>();

            for (int i = 0; i < lightCount; ++i)
            {
                Sphere sphere = new Sphere(new Material(Vector.RandomColor),
       new Vector(0.0, 1.0, 0.0) + Vector.RandomPointInSphere(radius),
       0.5 + random.NextDouble());
                Lights.Add(new Light(sphere));
            }
        }


        /// <summary>
        /// Metoda slouzi k automatickemu vygenerovani objektu na scenu v pozadovanem poctu
        /// </summary>
        /// <param name="random">Random generator cisel</param>
        private void CreateShapes(Random random)
        {
            Shapes = new List<Shape>();

            double width, height, depth;
            int randInt = 0;
            for (int i = 0; i < shapeCount; ++i)
            {
                randInt = random.Next(2);

                if ( randInt == 0)
                {
                   Sphere tmpS = new Sphere(new Material(Vector.RandomColor),
                        Vector.RandomPointInSphere(radius), 0.5 + random.NextDouble());
                    Shapes.Add(tmpS);
                }
                else if(randInt == 1)
                {

                    width = 0.5 + random.NextDouble();
                    height = 0.5 + random.NextDouble();
                    depth = 0.5 + random.NextDouble();

                   Cuboid c = new Cuboid(new Material(Vector.RandomColor),
                        Vector.RandomPointInCuboid(width, height, depth), width,
                        height, depth);
                    Shapes.Add(c);
                }
                /*else
                {
                    depth = 0.5 + random.NextDouble();

                    shapes[i] = new Plane(new Material(Vector.RandomColor),
                        Vector.RandomPointInPlane(depth), depth);
                }*/
            }
        }

        /*
         * Metada RayTrace slouci k vyberu nejblizsich objektu v okoli
         * Pokud je nejblizsi objekt svetlo je zavolana metoda PhongAt
         * pro vzorkovani povrchu objektu.
         * Pripadne barva okli
         */
         /// <summary>
         /// Metada RayTrace slouci k vyberu nejblizsich objektu v okoli
         /// Pokud je nejblizsi objekt svetlo je zavolana metoda PhongAt
         /// ro vzorkovani povrchu objektu.
         /// Pripadne barva okli
         /// </summary>
         /// <param name="ray">Paprsek Ray</param>
         /// <returns>Bod umisteni</returns>
        public Vector RayTrace(Ray ray)
        {
            Intersection nearestShape = NearestShape(ray);
            Intersection nearestLight = NearestLight(ray);

            if (nearestShape.T < nearestLight.T)
            {
                return PhongAt(nearestShape, ray);
            }
            else if (nearestLight.T < Intersection.MaxT)
            {
                return nearestLight.Material.Color;
            }
            else
            {
                return BackgroundColor(ray.Direction);
            }
        }

        /// <summary>
        /// Metoda BackgroundColor pro urceni barvy pozadi/ 
        /// </summary>
        /// <param name="direction">Vector se smerem paprsku</param>
        /// <returns>Vector s pozadim</returns>
        private Vector BackgroundColor(Vector direction)
        {
            Vector horizonColor = new Vector (0.60, 0.80, 1.0);
            Vector  zenithColor = horizonColor * 0.70;
            double elevation = direction.Y;
            double percent = (elevation < 0.0) ? 0.0 : elevation;
            return horizonColor + ((zenithColor - horizonColor) * percent);
        }

        /// <summary>
        /// Metoda pro vypocet okolniho procenta
        /// </summary>
        /// <param name="point">Vector umisteni</param>
        /// <param name="normal">Vector normal</param>
        /// <returns></returns>
        private double AmbientPercent(Vector point, Vector normal)
        {
            int unoccludedRays = 0;
            for (int n = 0; n < lightSamples; ++n)
            {
                Vector hemisphereDir = Vector.RandomHemisphereDirection(normal);
                Ray hemisphereRay = new Ray(point, hemisphereDir, Ray.InitialDepth);
                Intersection currentTry = this.NearestShape(hemisphereRay);
                if (currentTry.T == Intersection.MaxT)
                {
                    ++unoccludedRays;
                }
            }

            return ((double)unoccludedRays / lightSamples) * AmbientLight;
        }




        /// <summary>
        ///  Metoda PhongAt slouzi pro vypocet odrazu svetla z povrchu materialu
        ///  Na zaklade predaneho objektu intersection a ray je spocitan odraz
        ///  Objekt je vyvzorkovan dle zadaneho poctu vzorku do vstupniho formulare
        ///  Dale je kontrolovan pocet pozadovanych zanoreni
        /// </summary>
        /// <param name="intersection"></param>
        /// <param name="ray"></param>
        /// <returns>Vector s barvou </returns>
        private Vector PhongAt(Intersection intersection, Ray ray)
        {
            Vector viewVector = -ray.Direction;
            Vector localNormal = (viewVector.Dot(intersection.Normal) > 0.0) ?
                intersection.Normal : -intersection.Normal;
            Vector localNormalEps = localNormal * Vector.EPSILON;
            Vector localNormalEpsPoint = intersection.Point + localNormalEps;

            Vector materialColor = intersection.Material.Color;
            Vector ambientColor = (materialColor * BackgroundColor(ray.Direction)) *
                AmbientPercent(localNormalEpsPoint, localNormal);

            Vector totalColor = ambientColor;

            foreach (Light light in Lights)
            {
                Vector diffuseColorSum = new Vector();

                for (int n = 0; n < lightSamples; ++n)
                {
                    Vector lightDir = (light.Shape.RandomPoint - intersection.Point).Normalized;
                    Ray lightRay = new Ray(localNormalEpsPoint, lightDir, Ray.InitialDepth);
                    Intersection lightTry = light.Shape.Intersect(lightRay);
                    Intersection shadowTry = NearestShape(lightRay);

                    if (lightTry.T < shadowTry.T)
                    {
                        double lnDot = lightDir.Dot(localNormal);
                        Vector lightColor = light.Shape.Material.Color;
                        Vector diffuseColor = (materialColor * lightColor) * lnDot;
                        diffuseColorSum = diffuseColorSum + diffuseColor;
                    }
                }

                totalColor = totalColor + (diffuseColorSum * (1.0 / lightSamples));
            }

            if (ray.Depth < maxDepth)
            {
                Vector reflectDir = viewVector.Reflected(localNormal).Normalized;
                Ray reflectRay = new Ray(localNormalEpsPoint, reflectDir, ray.Depth + 1);
                Vector reflectColor = RayTrace(reflectRay) * Reflectivity;
                totalColor = totalColor + reflectColor;
            }

            return totalColor;
        }


        private Intersection NearestShape(Ray ray)
        {
            Intersection nearestHit = new Intersection();

            foreach (Shape shape in Shapes)
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

            foreach (Light light in Lights)
            {
                Intersection currentTry = light.Shape.Intersect(ray);

                if (currentTry.T < nearestHit.T)
                {
                    nearestHit = currentTry;
                }
            }
            return nearestHit;
        }


        /// <summary>
        /// Metoda pro vypsani statickych informaci o scene
        /// </summary>
        /// <returns></returns>
        public string GetInfo()
        {
            return sceneOutputFilePath + "\r\n" +
                   imageOutputFilePath + "\r\n" +
                   screenWidth + "\r\n" +
                   screenHeight + "\r\n" +
                   superSamples + "\r\n" +
                   shapeCount + "\r\n" +
                   lightCount + "\r\n" +
                   lightSamples + "\r\n" +
                   indirectLightSamples + "\r\n" +
                   maxDepth + "\r\n";
        }

        /// <summary>
        /// Meotda pro smazani dat ze sceny
        /// </summary>
        public void ClearScene()
        {

            Shapes = null;

            Lights = null;

            sceneOutputFilePath = "";

            sceneInputFilePath = "";

            imageOutputFilePath = "";

            screenWidth = 0;

            screenHeight = 0;

            superSamples = 0;

            shapeCount = 0;

            lightCount = 0;

            lightSamples = 0;

            indirectLightSamples = 0;

            maxDepth = 0;


        }
    }
    
}
