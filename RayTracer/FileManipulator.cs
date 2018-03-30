using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer
{
    public class FileManipulator
    {
        private string inputText;
        private int inputTextPosition;

        public void saveSceneToTXT()
        {
            string outputText = SceneInfoContainer.toString();

            if (SceneInfoContainer.shapes != null)
            {

                for (int i = 0; i < SceneInfoContainer.shapeCount; i++)
                {
                    outputText += SceneInfoContainer.shapes[i].ToString();

                }
            }

            System.IO.File.WriteAllText(SceneInfoContainer.sceneOutputFilePath, outputText);


        }

        public void loadSceneFromTXT(string inputFile)
        {
            SceneInfoContainer.clearContainer();

            SceneInfoContainer.sceneInputFilePath = inputFile;

            inputTextPosition = 0;
            
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

            SceneInfoContainer.lights = null;

            file.Close();
        }

        private void ReadShepes(System.IO.StreamReader file)
        {
            double x;
            double y;
            double z;

            double r;
            double g;
            double b;

            int i = 0;
            SceneInfoContainer.shapes = new Shape[SceneInfoContainer.shapeCount];

            while (!file.EndOfStream) 
            {
                string tmp = textReadLine(file);
              
                if (tmp.Contains("s"))
                {
                    

                    r = TextReadNumber(file);
                    g = TextReadNumber(file);
                    b = TextReadNumber(file);

                    x = TextReadNumber(file);
                    y = TextReadNumber(file);
                    z = TextReadNumber(file);

                    textReadLine(file);

                    Sphere tmpSphere = new Sphere(new Material(new Vector(r,g,b)), new Vector(x,y,z), SceneInfoContainer.radius);
                    SceneInfoContainer.shapes[i] = tmpSphere;
                }
                else
                {
                    break;
                }
               
                i++;

            }
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
    }
}
