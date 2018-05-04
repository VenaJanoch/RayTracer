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

        public ImageControler imageControler { get; set; }

        public InitWindow(ImageControler imageControler)
        {
            this.imageControler = imageControler;
            InitializeComponent();

        }


        public void SetImageToImageView(string imagePath)
        {
            imageView.Image = Image.FromFile("Output.png"); // TODO: opravit na imagePath
        }

        private void ShowRandomSceneWindow(object sender, EventArgs e)
        {
            var randScene = new RandomSceneWindow(this);
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

                XElement sceneFile = XElement.Load(fileName);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void sphareToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
