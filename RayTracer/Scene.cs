using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RayTracer
{

    class Scene
    {

        public string input_file_text;
        public int input_text_position;

        private Camera camera;
        private FileManipulator fileManipulator;
        
        public Scene(string input_file)
        {
            SceneInfoContainer.sceneInputFilePath = input_file;
        }

        public Scene()
        {
            camera = new Camera();
            fileManipulator = new FileManipulator();

            Random random = new Random();

            SceneInfoContainer.shapes = new Shape[SceneInfoContainer.shapeCount];

            for (int i = 0; i < SceneInfoContainer.shapeCount; ++i)
            {
              //  if (random.Next(2) == 0)
               // {
                    SceneInfoContainer.shapes[i] = new Sphere(new Material(Vector.RandomColor),
                        Vector.RandomPointInSphere(SceneInfoContainer.radius), 0.5 + random.NextDouble());
                //}
               /* else
                {
                    this.shapes[i] = new Cuboid(new Material(Vector3.RandomColor),
                        Vector3.RandomPointInSphere(radius), 0.5 + random.NextDouble(),
                        0.5 + random.NextDouble(), 0.5 + random.NextDouble());
                }*/
            }

            SceneInfoContainer.lights = new Light[SceneInfoContainer.lightCount];

            for (int i = 0; i < SceneInfoContainer.lightCount ; ++i)
            {
                if (random.Next(2) == 0)
                {
                    Sphere sphere = new Sphere(new Material(Vector.RandomColor),
                        new Vector(0.0, 1.0, 0.0) + Vector.RandomPointInSphere(SceneInfoContainer.radius),
                        0.5 + random.NextDouble());
                    SceneInfoContainer.lights[i] = new Light(sphere);
                }
               /* else
                {
                    Cuboid cuboid = new Cuboid(new Material(Vector3.RandomColor),
                        new Vector3(0.0, 1.0, 0.0) + Vector3.RandomPointInSphere(radius),
                        0.5 + random.NextDouble(), 0.5 + random.NextDouble(),
                        0.5 + random.NextDouble());
                    this.lights[i] = new Light(cuboid);
                }*/
            }


            fileManipulator.saveSceneToTXT();

        }


    }
}
