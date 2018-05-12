using RayTracer;
using RayTracerGUI.Controlers;
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
    public partial class SceneEditWindow : Form
    {

        private InitWindow initWindow;
        private InputFormControler InputControler { get; set; }

        private ImageControler ImageControler { get; set; }

        public SceneEditWindow(InitWindow initWindow, InputFormControler inputControler, ImageControler imageControler)
        {
            InputControler = inputControler;
            ImageControler = imageControler;
            this.initWindow = initWindow;

            InitializeComponent();
            SetDataToComponets();
        }

        /*
        * Metoda nastavi data do formulare
        */
        private void SetDataToComponets()
        {
            sceneOutput.Text = ImageControler.Scene.sceneOutputFilePath;
            imageOutput.Text = ImageControler.Scene.imageOutputFilePath;
            sceneWidth.Text = ImageControler.Scene.screenWidth.ToString();
            sceneHeight.Text = ImageControler.Scene.screenHeight.ToString();
            superSamples.Text = ImageControler.Scene.superSamples.ToString();
            lightSamples.Text = ImageControler.Scene.lightSamples.ToString();
            indirectLightSamples.Text  = ImageControler.Scene.indirectLightSamples.ToString();
            recursionDepth.Text = ImageControler.Scene.maxDepth.ToString();

        }


        private void SceneWindow_Load(object sender, EventArgs e)
        {

        }

        private void EditSceneBT_Click(object sender, EventArgs e)
        {

           if(InputControler.ControlOwnForm(sceneOutput.Text, imageOutput.Text,
                   sceneWidth.Text, sceneHeight.Text, superSamples.Text, lightSamples.Text,
                    indirectLightSamples.Text, recursionDepth.Text, true))
            {  
                Close();
            }
                        
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
