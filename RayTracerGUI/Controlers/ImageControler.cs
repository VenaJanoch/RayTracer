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
    /*
     * Trida slouzici jako controler funkcnosti ohledne renderovani obrazku 
     * a vytvareni 2D nahledu
     */
    
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
            RenderManager = new RenderManager(scene, FileManipulator, this);

        }

        /*
         * Metoda urcena pro nastaveni hodnot pred zacatkem renderovani.
         * A spusteni vlakna pro samotne renderovani
         */ 
        public void RenderImage(double x, double y)
        {
            Scene.Camera.eye.X = x;
            Scene.Camera.eye.Y = y;
            InitWindow.SetRenderingStatus();
            var th = new Thread(new ThreadStart(RenderManager.RenderingPicture));

            th.IsBackground = true;

            th.Start();

              
        }

        /*
         * Kontrolni metoda pro zjisteni zda uz existuje vyrenderovany obrazek,
         * pro ukazku na platen.
         * 
         * return true pokud obrazek existuje
         */ 
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

        /*
         * Metoda pro zavolani metody ze tridi FileManipulator pro nacteni sceny z XML
         * a nastavi scenu jako nactenou.
         */ 
        internal void LoadSceneFromFile(string fileName)
        {
            
            FileManipulator.LoadSceneFromXML(fileName);
            Scene.IsLoad= true;
        }

        /*
         * Metoda kontroluje zda je prave renderovany obrazek.
         * Pokud ano zavola metodu pro ukonceni renderovani ze tridy RenderManager
         */ 
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

        /*
         * Metoda pro prekresleni platna v uvodnim okne
         */
        internal void RepaintCanvas()
        {
            InitWindow.RepaintCanvas();
        }


        /*
         * Kontrolni metoda pro pridani Kvadru na kreslici platno
         */ 
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

        /*
         * Kontrolni metoda pro pridani Kuzelu na kreslici platno
         */
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

        /*
         * Kontrolni metoda pro pridani svetla na kreslici platno
         */
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

        /*
         * Kontrolni metoda pro ulozeni sceny do XML
         */
        internal bool SaveSceneControl()
        {
            if (FileManipulator == null || Scene == null) return false;
            
            return FileManipulator.SaveSceneToXML(); 

        }

        /*
         * Kontrolni metoda pro zjisteni zda je jiz scena nactena 
         */
        internal bool IsLoadScene()
        {
            if (!Scene.IsLoad)
            {
                return true;
            }

            return false;
        }
    }
}
