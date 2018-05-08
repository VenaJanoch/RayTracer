using RayTracer;
using RayTracerGUI.Controlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayTracerGUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Scene scene = new Scene();
            ImageControler imageControler = new ImageControler(scene);
            
            Application.Run(imageControler.InitWindow);
        }
    }
}
