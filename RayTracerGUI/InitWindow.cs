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

        }


        public void SetImageToImageView(string imagePath)
        {
            imageView.Image = Image.FromFile(imagePath);
        }


        public void SetImageToImageView()
        {
            if (ImageControler.IsAvailableImage())
            {
            imageView.Image = Image.FromFile(ImageControler.Scene.imageOutputFilePath);
            }
            else
            {
              //  imageView.Image = Image.FromFile("noFileCreated.png");
            }
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
            //Update - remove parenthesis
            if (openFileDialog.ShowDialog() == DialogResult.OK && (fileStream = openFileDialog.OpenFile()) != null)
            {
                string fileName = openFileDialog.FileName;
                ImageControler.FileManipulator.LoadSceneFromXML(fileName);
             //   SetImageToImageView(ImageControler.Scene.imageOutputFilePath);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void StartRenderingBT_Click(object sender, EventArgs e)
        {
            ImageControler.RenderImage();
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
            ImageControler.FileManipulator.SaveSceneToXML();
        }

        private void D3ViewBT_Click(object sender, EventArgs e)
        {
            SetImageToImageView();
        }
    }
}
