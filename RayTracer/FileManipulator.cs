using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer
{


    public class FileManipulator
    {
        public StreamWriter FileWriter { get; set; }
        private Scene scene { get; set; }

        public FileManipulator(Scene scene)
        {
            this.scene = scene;
        }

        public void SaveSceneToTXT()
        {
            string outputText = scene.GetInfo();

            if (scene.shapes != null)
            {

                for (int i = 0; i < scene.shapeCount; i++)
                {
                    outputText += scene.shapes[i].ToString();

                }
            }

            if (scene.lights != null)
            {

                for (int i = 0; i < scene.lightCount; i++)
                {
                    outputText += scene.lights[i].ToString();

                }
            }

            File.WriteAllText(scene.sceneOutputFilePath, outputText);



        }

        public void loadSceneFromTXT(string inputFile)
        {
            scene.ClearScene();

            scene.sceneInputFilePath = inputFile;
         
            StreamReader file = new StreamReader(inputFile);

            scene.sceneOutputFilePath = textReadLine(file);

            scene.imageOutputFilePath = textReadLine(file);
                        
            scene.screenWidth = (int)TextReadNumber(file);

            scene.screenHeight = (int)TextReadNumber(file);

            scene.superSamples = (int)TextReadNumber(file);

            scene.shapeCount = (int)TextReadNumber(file);

            scene.lightCount = (int)TextReadNumber(file);

            scene.lightSamples = (int)TextReadNumber(file);

            scene.indirectLightSamples = (int)TextReadNumber(file);

            scene.maxDepth = (int)TextReadNumber(file);

            ReadShepes(file);

            ReadLights(file);

            file.Close();

            FileWriter = new StreamWriter(scene.imageOutputFilePath);
        }

        private void ReadLights(StreamReader file)
        {
            scene.lights = new Light[scene.lightCount];

            int i = 0;

            while(i <= (scene.lightCount - 1))
            {
                if (textReadLine(file).Contains("l"))
                {
                    if (textReadLine(file).Contains("s"))
                    {
                        Shape tmpShape = ProcessSphereBodyTXT(file);
                        if(tmpShape != null)
                        {
                        scene.lights[i] = new Light(tmpShape);
                        }
                    }
                    else
                    {
                        break;
                    }

                }
                else
                {
                    break;
                }
                i++;
            }
        }

        private void ReadShepes(StreamReader file)
        {
            

            int i = 0;
            scene.shapes = new Shape[scene.shapeCount];

            while (i <= (scene.shapeCount-1)) 
            {
                string tmp = textReadLine(file);
              
                if (tmp.Contains("s"))
                {
                    scene.shapes[i] = ProcessSphereBodyTXT(file);
                }
                else if (tmp.Contains("c"))
                {
                    scene.shapes[i] = ProcessCuboidBodyTXT(file);
                }
                else if (tmp.Contains("p"))
                {
                     scene.shapes[i] = ProcessPlaneBodyTXT(file);
                }
                else
                {
                    break;
                }
                              
                i++;

            }
        }


        public Shape ProcessPlaneBodyTXT(StreamReader file)
        {

            double x, y, z, r, g, b, dept;

            r = TextReadNumber(file);
            g = TextReadNumber(file);
            b = TextReadNumber(file);

            x = TextReadNumber(file);
            y = TextReadNumber(file);
            z = TextReadNumber(file);

            dept = TextReadNumber(file);
           

            Plane tmpPlane = new Plane(new Material(new Vector(r, g, b)), new Vector(x, y, z), dept);
            return tmpPlane;
        }

        public Shape ProcessCuboidBodyTXT(StreamReader file)
        {

            double x, y, z, r, g, b, width, height, dept;

            r = TextReadNumber(file);
            g = TextReadNumber(file);
            b = TextReadNumber(file);

            x = TextReadNumber(file);
            y = TextReadNumber(file);
            z = TextReadNumber(file);

            width = TextReadNumber(file);
            height = TextReadNumber(file);
            dept = TextReadNumber(file);

            Cuboid tmpCuboid = new Cuboid(new Material(new Vector(r, g, b)), new Vector(x, y, z), width, height, dept);
            return tmpCuboid;
        }

        public Shape ProcessSphereBodyTXT(StreamReader file)
        {

            double x, y,z,r,g,b, radius;

            r = TextReadNumber(file);
            g = TextReadNumber(file);
            b = TextReadNumber(file);

            x = TextReadNumber(file);
            y = TextReadNumber(file);
            z = TextReadNumber(file);

            radius = TextReadNumber(file);

            Sphere tmpSphere = new Sphere(new Material(new Vector(r, g, b)), new Vector(x, y, z), radius);
            return tmpSphere;
        }
      
        private double TextReadNumber(StreamReader file)
        {
            string output_string = "";
            double output = 0;

            output_string = textReadLine(file);
           
            if (output_string != null)
            {
                output = double.Parse(output_string);
            }

            return output;
        }
    
        private string textReadLine(System.IO.StreamReader file)
        {
            string output = "";

            if ((output = file.ReadLine()) != null)
            {

                return output;
            }

            return null;
        }

        public void SaveImgToTXT(int y, int color)
        {

            if(y != scene.screenWidth)
            {
                FileWriter.Write(color.ToString() + " ");
            }
            else
            {

                FileWriter.Write(color.ToString() + "\r\n");
            }

            

        }

    }
}
