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
    public partial class CameraEditWindow : Form
    {
        InputFormControler inputFormControler;
        ImageControler imageControler;
        
        public CameraEditWindow(ImageControler imageControler, InputFormControler inputFormControler)
        {
            this.inputFormControler = inputFormControler;
            this.imageControler = imageControler;
            
            InitializeComponent();
            SetDataToComponents();
        }

        public void SetDataToComponents()
        {
            CoordXTB.Text = imageControler.Scene.Camera.eye.X.ToString();
            CoordYTB.Text = imageControler.Scene.Camera.eye.Y.ToString();
            CoordZTB.Text = imageControler.Scene.Camera.eye.Z.ToString();

            AngleTB.Text = imageControler.Scene.Camera.FovY.ToString();
         
        }

        
    
        private void SaveBTEdit_Click(object sender, EventArgs e)
        {
            if(inputFormControler.UpdateCamera(CoordXTB.Text, CoordYTB.Text, CoordZTB.Text, AngleTB.Text))
            {
            Close();
            }
        }
    }
}
