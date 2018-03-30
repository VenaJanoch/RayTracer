using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer
{
    public class FileManipulator
    {

      public void saveSceneToTXT()
      {
            string outputText = SceneInfoContainer.toString();

            if(SceneInfoContainer.shapes != null)
            {

                for(int i = 0; i < SceneInfoContainer.shapeCount; i++ )
                {
                    outputText += SceneInfoContainer.shapes[i].ToString() + "\r\n";

                }
            }

            System.IO.File.WriteAllText(SceneInfoContainer.sceneOutputFilePath, outputText);


        }

    }
}
