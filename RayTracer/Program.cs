﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RayTracer
{
    class Program
    {
        private static Scene scene;

        static void Main(string[] args)
        {
            Console.WriteLine("Ray Tracer create scene file");

            Console.WriteLine("Choose aplication mod, \n" +
                "1 for creating and save scene to file\n" +
                "2 for load scene from file and pixel save");
            int choose = Int32.Parse(Console.ReadLine());


            if(choose == 1)
            {
                get_scene_info_from_console();
            }
            else
            {
                process_scene_file();
            }

        }

        private static void process_scene_file()
        {
            Console.WriteLine("Give scene input file path");
            string path = Console.ReadLine();

            scene = new Scene(path);

        }

        private static void get_scene_info_from_console()
        {
            
            Console.WriteLine("Scene output file name/path");

            SceneInfoContainer.sceneOutputFilePath = Console.ReadLine();

            Console.WriteLine(SceneInfoContainer.sceneOutputFilePath);

            Console.WriteLine("Image output file name/path");

            SceneInfoContainer.imageOutputFilePath = Console.ReadLine();

            Console.Write("Scene width (i.e., 1-3840): ");
            SceneInfoContainer.screenWidth = Int32.Parse(Console.ReadLine());
         
            Console.Write("Scene height (i.e., 1-3840): ");
            SceneInfoContainer.screenHeight = Int32.Parse(Console.ReadLine());

            Console.Write("Super samples (i.e., 1-8): ");
            SceneInfoContainer.superSamples = Int32.Parse(Console.ReadLine());

            Console.Write("Shape count (i.e., 1-200): ");
            SceneInfoContainer.shapeCount = Int32.Parse(Console.ReadLine());

            Console.Write("Light count (i.e., 1-5): ");
            SceneInfoContainer.lightCount = Int32.Parse(Console.ReadLine());

            Console.Write("Light samples (i.e., 1-128): ");
            SceneInfoContainer.lightSamples = Int32.Parse(Console.ReadLine());

            Console.Write("Indirect light samples (i.e., 1-128): ");
            SceneInfoContainer.indirectLightSamples = Int32.Parse(Console.ReadLine());

            Console.Write("Max recursion depth (i.e., 0-10): ");
            SceneInfoContainer.maxDepth = Int32.Parse(Console.ReadLine());


            scene = new Scene();


        }

    }
}
