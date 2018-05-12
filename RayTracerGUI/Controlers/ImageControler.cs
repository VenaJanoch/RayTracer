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

    /// <summary>
    /// Trida slouzici jako controler funkcnosti ohledne renderovani obrazku 
    /// a vytvareni 2D nahledu
    /// </summary>
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

     
        /// <summary>
        /// Metoda urcena pro nastaveni hodnot pred zacatkem renderovani.
        /// A spusteni vlakna pro samotne renderovani
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void RenderImage(double x, double y)
        {
            Scene.Camera.eye.X = x;
            Scene.Camera.eye.Y = y;
            InitWindow.SetRenderingStatus();
            var th = new Thread(new ThreadStart(RenderManager.RenderingPicture));

            th.IsBackground = true;

            th.Start();

              
        }

      
        /// <summary>
        /// Kontrolni metoda pro zjisteni zda uz existuje vyrenderovany obrazek,
        /// pro ukazku na platen.
        /// 
        /// </summary>
        /// <returns>true pokud obrazek existuje</returns>
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

        /// <summary>
        /// Metoda pro zavolani metody ze tridi FileManipulator pro nacteni sceny z XML
        /// a nastavi scenu jako nactenou.
        /// 
        /// </summary>
        /// <param name="fileName">Jmeno xml souboru</param>
        internal void LoadSceneFromFile(string fileName)
        {
            
            FileManipulator.LoadSceneFromXML(fileName);
            Scene.IsLoad= true;
        }


        /// <summary>
        /// Metoda kontroluje zda je prave renderovany obrazek.
        /// Pokud ano zavola metodu pro ukonceni renderovani ze tridy RenderManager
        /// </summary>
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


        /// <summary>
        /// Metoda pro prekresleni platna v uvodnim okne
        /// </summary>
        internal void RepaintCanvas()
        {
            InitWindow.RepaintCanvas();
        }


        /// <summary>
        /// Kontrolni metoda pro pridani Kvadru na kreslici platno
        /// </summary>
        /// <returns>Aktualizovany Kvadr</returns>
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

        /// <summary>
        /// Kontrolni metoda pro pridani Koule na kreslici platno
        /// </summary>
        /// <returns>Koule pro pridani</returns>
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

        /// <summary>
        /// Kontrolni metoda pro pridani svetla na kreslici platno
        /// </summary>
        /// <returns>Nove svetlo</returns>
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

      
        /// <summary>
        /// Kontrolni metoda pro ulozeni sceny do XML
        /// </summary>
        /// <returns>true pokud lze data ulozit</returns>
        internal bool SaveSceneControl()
        {
            if (FileManipulator == null || Scene == null) return false;
            
            return FileManipulator.SaveSceneToXML(); 

        }

        /// <summary>
        /// Kontrolni metoda pro zjisteni zda je jiz scena nactena
        /// </summary>
        /// <returns>true pokud uz je scena nactena</returns>
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
