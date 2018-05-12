using System;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using RayTracerGUI.Controlers;

namespace RayTracer

    /*
     * Trida slouzi k renderovani namodelovaneho obrazku 
     */ 
{
    public class RenderManager
    {

        private Scene scene;
        private FileManipulator fileManipulator;
        ImageControler imageControler;
        public bool Rendering { get; set; }


        public RenderManager(Scene scene, FileManipulator fileManipulator, ImageControler imageControler)
        {
            this.scene = scene;
            this.fileManipulator = fileManipulator;
            this.imageControler = imageControler;
        }

        /*
         * Metoda urcena pro spusteni vlakna s vypoctem jednotlivych pixelu
         * Jednotlive radky pixelu jsou rozdeleny do vlaken pomoci Parallel a 
         * nasledne spuctena jejich hodnota
         */
        public void RenderingPicture()
        {
            Rendering = true;

            int screenWidth = scene.screenWidth;
            int screenHeight = scene.screenWidth;
            int superSamples = scene.superSamples;

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
                            Ray ray = scene.Camera.ImageRay(xx, yy);
                            color = color + scene.RayTrace(ray).Clamped();
                        }

                        if (!Rendering) { break; }
                    }


                    color = color * superSamplesSquaredRecip;

                    Color colorARGB = Color.FromArgb(color.toARGB());
                    lock (obj)
                    {
                        image.SetPixel(x, y, colorARGB); 
                       // fileManipulator.SaveImgToTXT(y, color.Brightness(colorARGB) );
                        
                    }
                    if (!Rendering) { break; }
                }



            });

            image.Save(scene.imageOutputFilePath, ImageFormat.Png);
            scene.Image = image;
            imageControler.InitWindow.SetCanvasAfterRendering();
            Rendering = false;

            Console.WriteLine("Done!");           
        }
        
        public void StopRenderingImage()
        {
            Rendering = false;
        }
    }
}
