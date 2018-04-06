using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer
{
    class SceneInfoContainer
    {
        public const double radius = 3.0;

        public static Shape[] shapes;
        public static Light[] lights;

        public static string sceneOutputFilePath { get; set; }

        public static string sceneInputFilePath { get; set; }

        public static string imageOutputFilePath { get; set; }

        public static int screenWidth { get; set; }

        public static int screenHeight { get; set; }

        public static int superSamples { get; set; }

        public static int shapeCount { get; set; }

        public static int lightCount { get; set; }

        public static int lightSamples { get; set; }

        public static int indirectLightSamples { get; set; }

        public static int maxDepth { get; set; }


        public static string toString()
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

        public static void clearContainer()
        {
                       
            shapes = null;

            lights = null;

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
