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
    public partial class SphereEditWindow : Form
    {
        private InputFormControler inputFormControler;
        private ImageControler imageControler;
        private Sphere sphere;
        private int light;

        public SphereEditWindow(Sphere sphere, int light, ImageControler imageControler, InputFormControler inputFormControler)
        {
            this.inputFormControler = inputFormControler;
            this.imageControler = imageControler;
            this.sphere = sphere;
            this.light = light;

            InitializeComponent();
            SetDataToComponents();

        }

        public void SetDataToComponents()
        {
            if (light == 1)
            {
                SphereEditLB.Text = "Light Sphere Editation";
            }

            CoordXTB.Text = sphere.Point.X.ToString();
            CoordYTB.Text = sphere.Point.Y.ToString();
            CoordZTB.Text = sphere.Point.Z.ToString();

            RadiusTB.Text = sphere.Radius.ToString();
            
            Color mColor = Color.FromArgb(sphere.Material.Color.toARGB());
            colorDialog1.Color = mColor;
            MaterialBT.BackColor = mColor;

        }

        
        private void MaterialBT_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                MaterialBT.BackColor = colorDialog1.Color;
            }
        }

        private void SaveBTEdit_Click(object sender, EventArgs e)
        {
            if(inputFormControler.UpdateSphere(sphere, CoordXTB.Text, CoordYTB.Text, CoordYTB.Text, RadiusTB.Text, colorDialog1.Color))
            {
            Close();
            }
        }

      
    }
}
