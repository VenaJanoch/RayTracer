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
    public partial class CuboidEditWindow : Form
    {
        InputFormControler inputFormControler;
        ImageControler imageControler;
        Cuboid cuboid;

        public CuboidEditWindow(Cuboid cuboid, ImageControler imageControler, InputFormControler inputFormControler)
        {
            this.inputFormControler = inputFormControler;
            this.imageControler = imageControler;
            this.cuboid = cuboid;

            InitializeComponent();
            SetDataToComponents();
        }

        public void SetDataToComponents()
        {
            CoordX.Text = cuboid.Point.X.ToString();
            CoordY.Text = cuboid.Point.Y.ToString();
            CoordZ.Text = cuboid.Point.Z.ToString();

            WidthTB.Text = cuboid.Width.ToString();
            HeightTB.Text = cuboid.Height.ToString();
            DepthTB.Text = cuboid.Depth.ToString();

            Color mColor = Color.FromArgb(cuboid.Material.Color.toARGB());
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
            inputFormControler.UpdateCuboid(cuboid, CoordXTB.Text, CoordYTB.Text, CoordZTB.Text, WidthTB.Text, HeightTB.Text, DepthTB.Text, colorDialog1.Color);
            Close();
        }
    }
}
