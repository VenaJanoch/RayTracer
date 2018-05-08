using RayTracer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayTracerGUI.Controlers    
{
    
    public class ImageControler
    {
        public InitWindow InitWindow { get; set; }

        public InputFormControler InputFormControler { get; set; }

        public FileManipulator FileManipulator { get; set; }

        public RenderManager RenderManager { get; set; }

        public Scene Scene { get; set; }
        

        public ImageControler(Scene scene)
        {
            InputFormControler inputFormControler = new InputFormControler(scene, this);
            Scene = scene;
            InitWindow = new InitWindow(this, inputFormControler);
            FileManipulator = new FileManipulator(scene);
            RenderManager = new RenderManager(scene, FileManipulator);

        }

        public void RenderImage(double x, double y)
        {
            Scene.Camera.eye.X = x;
            Scene.Camera.eye.Y = y;

            var th = new Thread(new ThreadStart(RenderManager.RenderingPicture));

            th.IsBackground = true;

            th.Start();

              
        }


        internal bool IsAvailableImage()
        {
            if (File.Exists(Scene.imageOutputFilePath))
            {
                return true;
            }
            return false;
        }

        internal void StopRenderingImage()
        {
            RenderManager.StopRenderingImage();
        }

        internal void RepaintCanvas()
        {
            InitWindow.RepaintCanvas();
        }
    }
}
