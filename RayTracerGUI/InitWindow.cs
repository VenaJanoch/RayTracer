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
            BackColor = Color.Brown;
        }

        private void ShowRandomSceneWindow(object sender, EventArgs e)
        {
            if (ImageControler.IsLoadScene())
            {
                var randScene = new RandomSceneWindow(this, InputControler, ImageControler);
                randScene.Show();
            }
            else
            {
                string message = "You have load scene, do you want save and create new?";
                string caption = "Exist scene";
                MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
                DialogResult result = MessageBox.Show(message, caption, buttons);

                if (result == DialogResult.Yes)
                {
                    ImageControler.SaveSceneControl();
                    var randScene = new RandomSceneWindow(this, InputControler, ImageControler);
                    randScene.Show();
                }
                else if (result == DialogResult.No)
                {
                    var randScene = new RandomSceneWindow(this, InputControler, ImageControler);
                    randScene.Show();
                }

            }   

        }

        internal void SetRenderingStatus()
        {
            canvas2D1.SetRenderingStatus();
          //  DisableScene();

        }

        private void DisableScene()
        {
            cuboidBT.Enabled = false;
            sphareBT.Enabled = false;
            lightBT.Enabled = false;
            CreateOwnSceneBT.Enabled = false;
            CreateRandomSceneBT.Enabled = false;
            EditSceneBT.Enabled = false; 
            LoadSceneBT.Enabled = false;
            d2ViewBT.Enabled = false;
            d3ViewBT.Enabled = false;
            startRanderBT.Enabled = false;
            SaveSceneBT.Enabled = false;
        }

        private void EnableScene()
        {
            cuboidBT.Enabled = true;
            sphareBT.Enabled = true;
            lightBT.Enabled = true;
            CreateOwnSceneBT.Enabled = true;
            CreateRandomSceneBT.Enabled = true;
            EditSceneBT.Enabled = true;
            LoadSceneBT.Enabled = true;
            d2ViewBT.Enabled = true;
            d3ViewBT.Enabled = true;
            startRanderBT.Enabled = true;
            SaveSceneBT.Enabled = true;
        }


        private void LoadSceneButton_Click(object sender, EventArgs e)
        {

            if (ImageControler.IsLoadScene())
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Scene Files|*.xml";
                openFileDialog.Title = "Select a scene File";

                
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;
                    ImageControler.LoadSceneFromFile(fileName);
                    Show2DSceneClick(sender, e);
                }
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

        private void AddSphareBT_Click(object sender, EventArgs e)
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

        private void AddLightBT_Click(object sender, EventArgs e)
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

            if(ImageControler.IsLoadScene()){
                var ownScene = new OwnSceneWindow(this, InputControler, ImageControler);
                ownScene.Show();
            }
            else
            {
                string message = "You have load scene, do you want save and create new?";
                string caption = "Exist scene";
                MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
                DialogResult result = MessageBox.Show(message, caption, buttons);

                if (result == DialogResult.Yes)
                {
                    ImageControler.SaveSceneControl();
                    var ownScene = new OwnSceneWindow(this, InputControler, ImageControler);
                    ownScene.Show();
                }
                else if(result == DialogResult.No)
                {
                    var ownScene = new OwnSceneWindow(this, InputControler, ImageControler);
                    ownScene.Show();
                }



            }


        }

        private void EditScene_Click(object sender, EventArgs e)
        {
            if (!ImageControler.IsLoadScene())
            {
                var editScene = new SceneEditWindow(this, InputControler, ImageControler);
                editScene.Show();
            }
            else
            {
                ShowErrorMessage("You do not load scene for edit", "Edit Scene problem");
            }
        }

        private void CreateRandomSceneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowRandomSceneWindow(sender, e);
        }

        private void CreateOwnSceneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateOwnSceneBT_Click(sender, e);
        }

        private void EditSceneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditScene_Click(sender, e);
        }

        private void LoadSceneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadSceneButton_Click(sender, e);
        }

        private void SaveSceneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveSceneBT_Click(sender, e);
        }
    }
}
