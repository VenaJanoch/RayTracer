using RayTracer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayTracerGUI.Controlers
{
    

   public class InputFormControler
    {
        public Scene Scene { get; set; }      

        public InputFormControler(Scene scene)
        {
            Scene = scene;
        }

        public void ControlRandomForm(String outputFile, String imgFile, String width, String height,
           String superSamples, String shapeCount, String lightCount, String lightSamples, String indirectLightSamples, String maxDepth)
        {
      //      if(outputFile == null || imgFile == null ||)
        }

        internal void InitScene(string sceneOutputFilePath, string imageOutputFilePath, int screenWidth, int screenHeight, int superSamples, int shapeCount, int lightCount, int lightSamples, int indirectLightSamples, int maxDepth)
        {
            Scene.FillScene(sceneOutputFilePath, imageOutputFilePath,
                            screenWidth, screenHeight, superSamples, shapeCount, lightCount, lightSamples,
                            indirectLightSamples, maxDepth);

            double aspect = (Scene.screenWidth / Scene.screenHeight);
            Scene.Camera = Camera.LookAt(new Vector(6.0, 3.0, 12.0), new Vector(), aspect, 60.0);



        }

        internal void UpdateCuboid(Cuboid cuboid, string coordX, string coordY,
            string coordZ, string width, string height, string depth, Color color)
        {
            cuboid.Point.X = Double.Parse(coordX);
            cuboid.Point.Y = Double.Parse(coordY);
            cuboid.Point.Z = Double.Parse(coordZ);

            cuboid.Width = Double.Parse(width);
            cuboid.Height = Double.Parse(height);
            cuboid.Depth = Double.Parse(depth);

            double r = (int)color.R / 255;
            double g = (int)color.G / 255;
            double b = (int)color.B / 255;


            cuboid.Material.Color.X = r;
            cuboid.Material.Color.Y = g;
            cuboid.Material.Color.Z = b;
        }

        internal void UpdateSphere(Sphere sphere, string coordX, string coordY,
            string coordZ, string radius, Color color)
        {
            sphere.Point.X = Double.Parse(coordX);
            sphere.Point.Y = Double.Parse(coordY);
            sphere.Point.Z = Double.Parse(coordZ);

            sphere.Radius = Double.Parse(radius);
            
            double r = (int)color.R / 255;
            double g = (int)color.G / 255;
            double b = (int)color.B / 255;


            sphere.Material.Color.X = r;
            sphere.Material.Color.Y = g;
            sphere.Material.Color.Z = b;
        }
    }
       

}   
