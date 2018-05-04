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


        public void RenderingPicture(int screenWidth, int screenHeight, int superSamples )
        {
            double widthRecip = 1.0 / screenWidth;
            double heightRecip = 1.0 / screenHeight;
            double superSamplesRecip = 1.0 / superSamples;
            double superSamplesHalfRecip = superSamplesRecip * 0.5;
            double superSamplesSquaredRecip = 1.0 / (superSamples * superSamples);

            Bitmap image = new Bitmap(screenWidth, screenHeight);


            object obj = new object();
            Parallel.For(0, screenHeight, y =>
            {
                for (int x = 0; x < screenWidth; ++x)
                {
                    Vector color = new Vector();
                    for (int j = 0; j < superSamples; ++j)
                    {
                        double jj = j * superSamplesRecip;
                        double yy = (y + superSamplesHalfRecip + jj) * heightRecip;
                        for (int i = 0; i < superSamples; ++i)
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
                       // fileManipulator.SaveImgToTXT(y, color.Brightness(colorARGB) );
                        
                    }
                }



            });

            scene.Image = image;
            image.Save("Output.png", ImageFormat.Png);
            image.Dispose();

           Console.WriteLine("Done!");
           Console.Read();


        }


    }
}
