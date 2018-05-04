using RayTracer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayTracerGUI
{
    public partial class RandomSceneWindow : Form
    {

        private InitWindow initWindow;
        public RandomSceneWindow(InitWindow initWindow)
        {
            this.initWindow = initWindow;
            InitializeComponent();
        }

        private void SceneWindow_Load(object sender, EventArgs e)
        {

        }

        private void saveBt_Click(object sender, EventArgs e)
        {

            string sceneOutputFilePath = sceneOutput.Text;
            string imageOutputFilePath = imageOutput.Text;

            int screenWidth = Int32.Parse(sceneWidth.Text);
            int screenHeight = Int32.Parse(sceneHeight.Text);
            int superSamples = Int32.Parse(this.superSamples.Text);
            int shapeCount = Int32.Parse(this.shapeCount.Text);
            int lightCount = Int32.Parse(this.lightCount.Text);
            int lightSamples = Int32.Parse(this.lightSamples.Text);
            int indirectLightSamples = Int32.Parse(this.indirectLightSamples.Text);
            int maxDepth = Int32.Parse(recursionDepth.Text);

           Scene scene = new Scene(sceneOutputFilePath, imageOutputFilePath,
            screenWidth, screenHeight, superSamples, shapeCount, lightCount, lightSamples,
            indirectLightSamples, maxDepth);

            initWindow.SetImageToImageView(scene.imageOutputFilePath);

            this.Close();
            
        }

        private void sceneOutputBT_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Scene Files|(*.txt)";
            openFileDialog.Title = "Select a scene File";

                       //Update - remove parenthesis
            if (openFileDialog.ShowDialog() == DialogResult.OK )
            {
                sceneOutput.Text = openFileDialog.FileName;
                

            }
        }

        private void imgOutputBT_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Scene Files|*.txt";
            openFileDialog.Title = "Select a scene File";

            //Update - remove parenthesis
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imageOutput.Text = openFileDialog.FileName;


            }
        }
    }
}
