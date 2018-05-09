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
            InputFormControler = new InputFormControler(scene, this);
            Scene = scene;
            InitWindow = new InitWindow(this, InputFormControler);
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
                if(Scene.Image == null)
                {
                    Scene.Image = (Bitmap)Image.FromFile(Scene.imageOutputFilePath);
                    
                }
                return true;
            }
            return false;
        }

        internal void StopRenderingImage()
        {
            if (RenderManager.Rendering)
            {
                RenderManager.StopRenderingImage();
            }
            else
            {
                string message = "Image is not rendering ";
                string caption = "Error Detected in stop rendering";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }
        }

        internal void RepaintCanvas()
        {
            InitWindow.RepaintCanvas();
        }

        internal bool AddCuboidToSceneControl()
        {
            if(Scene.Shapes != null)
            {
               Cuboid c = new Cuboid(new Material(new Vector(0, 0, 0)), new Vector(1.5, -1.5, 0), 1, 1, 1);
                Scene.Shapes.Add(c);
                Scene.shapeCount++;
                return true;
            }
            return false;
        }

        internal bool AddSphereToSceneControl()
        {
            if (Scene.Shapes != null)
            {
                Sphere s = new Sphere(new Material(new Vector(0, 0, 0)), new Vector(new Vector(1.5, -1.5, 0)), 1);
                Scene.Shapes.Add(s);
                Scene.shapeCount++;
                return true;
            }
            return false;
        }

        internal bool AddLightToSceneControl()
        {
            if (Scene.Shapes != null)
            {
                Sphere s = new Sphere(new Material(new Vector(0, 0, 0)), new Vector(new Vector(1.5, -1.5, 0)), 1);
                Light l = new Light(s);
                Scene.Lights.Add(l);
                Scene.lightCount++;
                return true;
            }
            return false;
            

        }

        internal bool SaveSceneControl()
        {
            if (FileManipulator == null || Scene == null) return false;
            
            return FileManipulator.SaveSceneToXML(); 

        }
    }
}
