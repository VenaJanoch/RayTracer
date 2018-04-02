using System;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace RayTracer
{
    class RenderManager
    {

        private Scene scene;
        private Camera camera;
        private FileManipulator fileManipulator;


        public RenderManager(Scene scene, Camera camera, FileManipulator fileManipulator)
        {
            this.scene = scene;
            this.camera = camera;
            this.fileManipulator = fileManipulator;
        }


        public void RenderingPicture()
        {
            double widthRecip = 1.0 / SceneInfoContainer.screenWidth;
            double heightRecip = 1.0 / SceneInfoContainer.screenHeight;
            double superSamplesRecip = 1.0 / SceneInfoContainer.superSamples;
            double superSamplesHalfRecip = superSamplesRecip * 0.5;
            double superSamplesSquaredRecip = 1.0 / (SceneInfoContainer.superSamples * SceneInfoContainer.superSamples);

            Bitmap image = new Bitmap(SceneInfoContainer.screenWidth, SceneInfoContainer.screenHeight);


            object obj = new object();
            // Stopwatch stopwatch = Stopwatch.StartNew();
            Parallel.For(0, SceneInfoContainer.screenHeight, y =>
            {
                for (int x = 0; x < SceneInfoContainer.screenWidth; ++x)
                {
                    Vector color = new Vector();
                    for (int j = 0; j < SceneInfoContainer.superSamples; ++j)
                    {
                        double jj = j * superSamplesRecip;
                        double yy = (y + superSamplesHalfRecip + jj) * heightRecip;
                        for (int i = 0; i < SceneInfoContainer.superSamples; ++i)
                        {
                            double ii = i * superSamplesRecip;
                            double xx = (x + superSamplesHalfRecip + ii) * widthRecip;
                            Ray ray = camera.ImageRay(xx, yy);
                            color = color + scene.RayTrace(ray).Clamped();
                        }
                    }

                    color = color * superSamplesSquaredRecip;
                    Color colorARGB = Color.FromArgb(color.toARGB());
                    lock (obj)
                    {
                        image.SetPixel(x, y, colorARGB); 
                        // Console.WriteLine(colorARGB.);
                        fileManipulator.SaveImgToTXT(y, colorARGB);
                        
                    }
                }
            });
            

            image.Save("Output.png", ImageFormat.Png);
            image.Dispose();

           Console.WriteLine("Done!");
            Console.Read();


        }


    }
}
