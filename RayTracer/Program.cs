using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RayTracer
{
    class Program
    {
     //   private static Scene scene;

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
            //    process_scene_file();
            }

        }

        /*private static void process_scene_file()
        {
            Console.WriteLine("Give scene input file path");
            string path = Console.ReadLine();

            scene = new Scene(path);

        }*/

        private static void get_scene_info_from_console()
        {
            
            Console.WriteLine("Scene output file name/path");
            string sceneOutputFilePath = Console.ReadLine();
                      
            Console.WriteLine("Image output file name/path");
            string imageOutputFilePath = Console.ReadLine();

            Console.Write("Scene width (1-3840): ");
            int screenWidth = Int32.Parse(Console.ReadLine());
         
            Console.Write("Scene height (1-3840): ");
            int screenHeight = Int32.Parse(Console.ReadLine());

            Console.Write("Super samples (1-8): ");
            int superSamples = Int32.Parse(Console.ReadLine());

            Console.Write("Shape count (1-20): ");
            int shapeCount = Int32.Parse(Console.ReadLine());

            Console.Write("Light count (1-5): ");
            int lightCount = Int32.Parse(Console.ReadLine());

            Console.Write("Light samples (1-128): ");
            int lightSamples = Int32.Parse(Console.ReadLine());

            Console.Write("Indirect light samples (1-128): ");
            int indirectLightSamples = Int32.Parse(Console.ReadLine());

            Console.Write("Max recursion depth (0-10): ");
            int maxDepth = Int32.Parse(Console.ReadLine());


            /* scene = new Scene(sceneOutputFilePath, imageOutputFilePath,
            screenWidth, screenHeight, superSamples, shapeCount, lightCount, lightSamples,
            indirectLightSamples, maxDepth);*/ 


        }

    }
}
