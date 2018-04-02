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
        private StreamWriter FileWriter;
        
        public void SaveSceneToTXT()
        {
            string outputText = SceneInfoContainer.toString();

            if (SceneInfoContainer.shapes != null)
            {

                for (int i = 0; i < SceneInfoContainer.shapeCount; i++)
                {
                    outputText += SceneInfoContainer.shapes[i].ToString();

                }
            }

            if (SceneInfoContainer.lights != null)
            {

                for (int i = 0; i < SceneInfoContainer.lightCount; i++)
                {
                    outputText += SceneInfoContainer.lights[i].ToString();

                }
            }

            System.IO.File.WriteAllText(SceneInfoContainer.sceneOutputFilePath, outputText);


        }

        public void loadSceneFromTXT(string inputFile)
        {
            SceneInfoContainer.clearContainer();

            SceneInfoContainer.sceneInputFilePath = inputFile;
         
            System.IO.StreamReader file = new System.IO.StreamReader(inputFile);

            SceneInfoContainer.sceneOutputFilePath = textReadLine(file);

            SceneInfoContainer.imageOutputFilePath = textReadLine(file);
                        
            SceneInfoContainer.screenWidth = (int)TextReadNumber(file);

            SceneInfoContainer.screenHeight = (int)TextReadNumber(file);

            SceneInfoContainer.superSamples = (int)TextReadNumber(file);

            SceneInfoContainer.shapeCount = (int)TextReadNumber(file);

            SceneInfoContainer.lightCount = (int)TextReadNumber(file);

            SceneInfoContainer.lightSamples = (int)TextReadNumber(file);

            SceneInfoContainer.indirectLightSamples = (int)TextReadNumber(file);

            SceneInfoContainer.maxDepth = (int)TextReadNumber(file);

            ReadShepes(file);

            ReadLights(file);

            file.Close();

            FileWriter = new StreamWriter(SceneInfoContainer.imageOutputFilePath);
        }

        private void ReadLights(StreamReader file)
        {
            SceneInfoContainer.lights = new Light[SceneInfoContainer.lightCount];

            int i = 0;

            while(i <= (SceneInfoContainer.lightCount - 1))
            {
                if (textReadLine(file).Contains("l"))
                {
                    if (textReadLine(file).Contains("s"))
                    {
                        Shape tmpShape = ProcessShapeBodyTXT(file);
                        if(tmpShape != null)
                        {
                        SceneInfoContainer.lights[i] = new Light(tmpShape);
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
            SceneInfoContainer.shapes = new Shape[SceneInfoContainer.shapeCount];

            while (i <= (SceneInfoContainer.shapeCount-1)) 
            {
                string tmp = textReadLine(file);
              
                if (tmp.Contains("s"))
                {
                    SceneInfoContainer.shapes[i] = ProcessShapeBodyTXT(file);
                }
                else
                {
                    break;
                }
                              
                i++;

            }
        }

        public Shape ProcessShapeBodyTXT(StreamReader file)
        {

            double x, y,z,r,g,b;

            r = TextReadNumber(file);
            g = TextReadNumber(file);
            b = TextReadNumber(file);

            x = TextReadNumber(file);
            y = TextReadNumber(file);
            z = TextReadNumber(file);

            textReadLine(file);

            Sphere tmpSphere = new Sphere(new Material(new Vector(r, g, b)), new Vector(x, y, z), SceneInfoContainer.radius);
            return tmpSphere;
        }
      
        private double TextReadNumber(System.IO.StreamReader file)
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

        public void SaveImgToTXT(int y, Color color)
        {

            if(y != SceneInfoContainer.screenWidth)
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
