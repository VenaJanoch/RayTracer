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
        public ImageControler ImageControler { get; set; }

        private Boolean scene2D;

        private Shape moveShape;

        public Cuboid Camera { get; set; } 

        public Shape ChooseShape { get; set; }

        private Point mouseOffset;

        public const int SCALE = 50;

        public Canvas2D()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
            
        }


        public void Set2DScene()
        {
            scene2D = true;
            Invalidate();
        }

        public void Set3DScene()
        {
            scene2D = false;
            Invalidate();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (moveShape == null)
            {
                return;
            }

            if (moveShape.Type.Contains("Cuboid"))
            {
                Cuboid c = (Cuboid)moveShape;

                int width = (int)(Math.Abs(c.Width) * SCALE);
                int height = (int)(Math.Abs(c.Height) * SCALE);

                double x = (double)(e.X - Width / 2) / SCALE;
                double y = -(double)(e.Y - Height / 2) / SCALE;

                c.Point.X = x;
                c.Point.Y = y;

            }
            else if (moveShape.Type.Contains("Sphere"))
            {
                Sphere s = (Sphere)moveShape;
                int radius = (int)(Math.Abs(s.Radius) * SCALE);

                double x = (double)(e.X - mouseOffset.X - Width / 2) / SCALE;
                double y = -((double)(e.Y - mouseOffset.Y - Height / 2) / SCALE);

                s.Point.X = x;
                s.Point.Y = y;
            }

            Invalidate();

        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            moveShape = null;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            foreach (Shape shape in ImageControler.Scene.shapes)
            {
                if (ShapeMouseDownControl(e, shape))
                {
                    return;
                }
            }

            foreach (Light light in ImageControler.Scene.lights)
            {
                if (ShapeMouseDownControl(e, light.Shape))
              {
                  return;
              }
            }

              if (ShapeMouseDownControl(e, Camera))
              {
                  return;
              }

            moveShape = null;
            Invalidate();

        }

        public bool ShapeMouseDownControl(MouseEventArgs e, Shape shape)
        {
            if (shape.Type.Contains("Cuboid"))
            {
                Cuboid c = (Cuboid)shape;

                int width = (int)(Math.Abs(c.Width) * SCALE);
                int height = (int)(Math.Abs(c.Height) * SCALE);

                int x = (int)(c.Point.X * SCALE - width / 2) + Width / 2;
                int y = (int)(-c.Point.Y * SCALE - height / 2) + Height / 2;

                Rectangle r = new Rectangle(x, y, width, height);

                if (r.Contains(e.Location))
                {
                    moveShape = shape;
                    ChooseShape = shape;
                    Invalidate();
                    return true;
                }
            }
            else if (shape.Type.Contains("Sphere"))
            {
                Sphere s = (Sphere)shape;
                int radius = (int)(Math.Abs(s.Radius) * SCALE);

                int x = (int)(s.Point.X * SCALE) + Width / 2;
                int y = (int)(-s.Point.Y * SCALE) + Height / 2;


                if (Math.Abs(x - e.X) <= radius / 2 && Math.Abs(y - e.Y) <= radius / 2)
                {
                    moveShape = shape;
                    ChooseShape = shape;
                    mouseOffset = new Point(e.X - x, e.Y - y);
                    Invalidate();
                    return true;
                }

            }
            return false;

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (ImageControler == null) return;

            if (scene2D)
            {

                foreach (Shape shape in ImageControler.Scene.shapes)
                {
                    AddShapes(shape, false, e);

                }

                foreach (Light light in ImageControler.Scene.lights)
                {
                    AddShapes(light.Shape, true, e);

                }

                if(Camera != null)
                {
                AddShapes(Camera, false, e);

                }

            }
            else
            {
                if (ImageControler.Scene?.Image == null) return;
                e.Graphics.DrawImage(ImageControler.Scene.Image, new Point(0, 0));
            }


        }

        public void SetCame()
        {
            Camera = new Cuboid(new Material(new Vector(0.5, 0.5, 0.5)), new Vector(ImageControler.Scene.Camera.eye.X, ImageControler.Scene.Camera.eye.Y, 0), 1, 0.5, 0);
        }

        public void AddShapes(Shape shape, bool light, PaintEventArgs e)
        {
            Color colorARGB = Color.FromArgb(shape.Material.Color.toARGB());

            using (Brush brush = new SolidBrush(colorARGB))
            {

                if (shape.Type.Contains("Cuboid"))
                {
                    Cuboid c = (Cuboid)shape;

                    int width = (int)(Math.Abs(c.Width) * SCALE);
                    int height = (int)(Math.Abs(c.Height) * SCALE);

                    int x = (int)(c.Point.X * SCALE - width / 2) + Width / 2;
                    int y = (int)(-c.Point.Y * SCALE - height / 2) + Height / 2;


                    e.Graphics.FillRectangle(brush, new Rectangle(x, y, width, height));

                    e.Graphics.DrawRectangle(Pens.Bisque, new Rectangle(x, y, width, height));


                    if (ChooseShape == shape)
                    {
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(x, y, width, height));
                    }
                }
                else if (shape.Type.Contains("Sphere"))
                {
                    Sphere s = (Sphere)shape;
                    int radius = (int)(Math.Abs(s.Radius) * SCALE);

                    int x = (int)(s.Point.X * SCALE - radius / 2) + Width / 2;
                    int y = (int)(-s.Point.Y * SCALE - radius / 2) + Height / 2;

                    e.Graphics.FillEllipse(brush, new Rectangle(x, y, radius, radius));

                    if (light)
                    {
                        using (Pen myPen = new Pen(Color.DarkCyan))
                        {
                            e.Graphics.DrawEllipse(Pens.DarkCyan, new Rectangle(x, y, radius, radius));
                        }
                    }

                    if (ChooseShape == shape)
                    {
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(x, y, radius, radius));
                    }
                }
            }
        }
    }


}