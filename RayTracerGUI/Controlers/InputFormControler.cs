using RayTracer;
using System;
using System.Collections.Generic;
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
    }
       

}   
