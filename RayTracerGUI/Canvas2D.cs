using RayTracer;
using RayTracerGUI.Controlers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayTracerGUI
{
    public class Canvas2D : Control
    {
        private ImageControler imageControler;

        public Canvas2D(ImageControler imageControler)
        {
            this.imageControler = imageControler;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // If there is an image and it has a location, 
            // paint it when the Form is repainted.
            base.OnPaint(e);
           
            foreach(Shape shape in imageControler.Scene.shapes)
            {
                Color colorARGB = Color.FromArgb(shape.Material.Color.toARGB());
                Brush brush = new SolidBrush(colorARGB);

                if (shape.Type.Contains("cuboid"))
                {
                    Cuboid c = (Cuboid)shape;
                                  e.Graphics.FillRectangle(brush, new Rectangle((int)c.Point.X, (int)c.Point.Y, (int)c.Width, (int)c.Height));
                }else if (shape.Type.Contains("sphere"))
                {
                    Sphere s = (Sphere)shape;
                    System.Drawing.Pen myPen = new System.Drawing.Pen(colorARGB);
                    e.Graphics.FillEllipse(brush, new Rectangle((int)s.Point.X, (int)s.Point.Y, (int)s.Radius, (int)s.Radius));
                }
                
            }


        }



    }
}
