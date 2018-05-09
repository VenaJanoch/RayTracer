using RayTracer;
using RayTracerGUI.Controlers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RayTracerGUI
{
    public partial class InitWindow : Form
    {

        public ImageControler ImageControler { get; set; }
        public InputFormControler InputControler { get; set; }

        public InitWindow(ImageControler imageControler, InputFormControler inputControler)
        {
            ImageControler = imageControler;
            InputControler = inputControler;
            InitializeComponent();
            canvas2D1.ImageControler = imageControler;
            canvas2D1.InputFormControler = inputControler;
        }

        private void ShowRandomSceneWindow(object sender, EventArgs e)
        {
            var randScene = new RandomSceneWindow(this, InputControler, ImageControler);
            randScene.Show();

        }


        private void SelectSceneButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Scene Files|*.xml";
            openFileDialog.Title = "Select a scene File";

            Stream fileStream = null;
           
            if (openFileDialog.ShowDialog() == DialogResult.OK && (fileStream = openFileDialog.OpenFile()) != null)
            {
                string fileName = openFileDialog.FileName;
                ImageControler.FileManipulator.LoadSceneFromXML(fileName);
                Show2DSceneClick(sender, e); 
            }
        }

        private void Show2DSceneClick(object sender, EventArgs e)
        {
            if(ImageControler.Scene?.Camera != null)
            {
                canvas2D1.SetCame();
                canvas2D1.Set2DScene();
            }
            else
            {
                string message = "You must load or create scene ";
                string caption = "Error Detected in scene";
                ShowErrorMessage(message, caption);
            }
            
        }

        private void StartRenderingBT_Click(object sender, EventArgs e)
        {
            if(ImageControler.Scene?.Camera != null)
            {
                ImageControler.RenderImage(canvas2D1.Camera.Point.X, canvas2D1.Camera.Point.Y);
            }
            else
            {
                string message = "You must load or create scene ";
                string caption = "Error Detected in Rendering";
                ShowErrorMessage(message, caption);
            }
            
        }

        private void StopRenderingBT_Click(object sender, EventArgs e)
        {

            ImageControler.StopRenderingImage();
        }

        private void sphareToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SaveSceneBT_Click(object sender, EventArgs e)
        {
            if (!ImageControler.SaveSceneControl())
            {
                string message = "You must load or create scene ";
                string caption = "Error Detected in Rendering";
                ShowErrorMessage(message, caption);
            } 
        }

        private void D3ViewBT_Click(object sender, EventArgs e)
        {
            if (ImageControler.Scene?.Image != null || ImageControler.IsAvailableImage())
            {

            canvas2D1.Set3DScene();

            }
            else
            {
                ShowErrorMessage("You must render image for 3D view ", "Error Detected in Rendering");
            }
        }

        public void ShowErrorMessage(string message, string caption)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons);
        }

        private void AddCuboidBT_Click(object sender, EventArgs e)
        {
            if(!ImageControler.AddCuboidToSceneControl())
            {
                ShowErrorMessage("You must choose or create sceen for add", "Error Detected in Add to Scene");
            }
            else
            {
            RepaintCanvas();        

            }


        }

        internal void RepaintCanvas()
        {
            canvas2D1.Invalidate();
        }

        private void SphareBT_Click(object sender, EventArgs e)
        {
            if (!ImageControler.AddSphereToSceneControl())
            {
                ShowErrorMessage("You must choose or create sceen for add", "Error Detected in Add to Scene");
            }
            else
            {
                RepaintCanvas();

            }
        }

        private void LightBT_Click(object sender, EventArgs e)
        {
            if (!ImageControler.AddLightToSceneControl())
            {
                ShowErrorMessage("You must choose or create sceen for add", "Error Detected in Add to Scene");
            }
            else
            {
                RepaintCanvas();

            }
      
        }

        private void CreateOwnSceneBT_Click(object sender, EventArgs e)
        {
            var ownScene = new OwnSceneWindow(this, InputControler, ImageControler);
            ownScene.Show();
        }
    }
}
