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

        public Canvas2D Canvas2D { get; set; }



        public ImageControler(InputFormControler inputFormControler, Scene scene)
        {
            InputFormControler = inputFormControler;
            Scene = scene;
            InitWindow = new InitWindow(this, inputFormControler);
            FileManipulator = new FileManipulator(scene);
            RenderManager = new RenderManager(scene, FileManipulator);

        }

        public void RenderImage()
        {
            double aspect = (Scene.screenWidth / Scene.screenHeight);

            Scene.Camera = Camera.LookAt(new Vector(6.0, 3.0, 12.0), new Vector(), aspect, 60.0);
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

        
    }
}
