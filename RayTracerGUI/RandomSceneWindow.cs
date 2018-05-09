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
    public partial class RandomSceneWindow : Form
    {

        private InitWindow initWindow;
        private InputFormControler InputControler { get; set; }

        private ImageControler ImageControler { get; set; }

        public RandomSceneWindow(InitWindow initWindow, InputFormControler inputControler, ImageControler imageControler)
        {
            InputControler = inputControler;
            ImageControler = imageControler;
            this.initWindow = initWindow;

            InitializeComponent();
        }

        private void SceneWindow_Load(object sender, EventArgs e)
        {

        }

        private void saveBt_Click(object sender, EventArgs e)
        {

           if(InputControler.ControlRandomForm(sceneOutput.Text, imageOutput.Text,
                   sceneWidth.Text, sceneHeight.Text, superSamples.Text, shapeCount.Text, lightCount.Text, lightSamples.Text,
                    indirectLightSamples.Text, recursionDepth.Text))
            {
                ImageControler.FileManipulator.SaveSceneToXML();
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
