using RayTracer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayTracerGUI.Controlers
{
    

   public class InputFormControler
    {
        public Scene Scene { get; set; }

        public ImageControler imageControler;

        public const int maxSceneSize = 3840;

        public InputFormControler(Scene scene, ImageControler imageControler)
        {
            Scene = scene;
            this.imageControler = imageControler;
        }

        /// <summary>
        /// Metoda urcena pro kontrolu vstupu z fromulare pro random scenu
        /// </summary>
        /// <param name="outputFile">vystupni soubor</param>
        /// <param name="imgFile">vystupni soubor obrazku</param>
        /// <param name="width">sirka</param>
        /// <param name="height">vyska</param>
        /// <param name="superSamples">vzorky</param>
        /// <param name="shapeCount">pocet objektu</param>
        /// <param name="lightCount">pocet svetel</param>
        /// <param name="lightSamples">pocet vzorku svetel</param>
        /// <param name="indirectLightSamples">pocet neprimych svetel</param>
        /// <param name="maxDepth">hloubka</param>
        /// <returns>treu pokud jsou data v poradku</returns>
        public bool ControlRandomForm(String outputFile, String imgFile, String width, String height,
           String superSamples, String shapeCount, String lightCount, String lightSamples, String indirectLightSamples, String maxDepth)
        {
            if (!IsCorectField("Output scene file", outputFile)) return false;
            if (!IsCorectField("Output image file", imgFile)) return false;
            if (!IsCorectField("Scene width", width)) return false;
            if (!IsCorectField("Scene height", height)) return false;
            if (!IsCorectField("superSamples", superSamples)) return false;
            if (!IsCorectField("shapeCount", shapeCount)) return false;
            if (!IsCorectField("lightCount", lightCount)) return false;
            if (!IsCorectField("lightSamples", lightSamples)) return false;
            if (!IsCorectField("indirectLightSamples", indirectLightSamples)) return false;
            if (!IsCorectField("maxDepth", maxDepth)) return false;

            int screenWidth;
            if ((screenWidth = IsCorectIntNumberFormat("Scene width", width))  == -1) return false;
            if (!IsCorectIntNumber("Scene width", screenWidth,1, 3840)) return false;

            int screenHeight;
            if ((screenHeight = IsCorectIntNumberFormat("Scene height", height)) == -1) return false;
            if (!IsCorectIntNumber("Scene height", screenHeight, 1, 3840)) return false;

            int iSuperSamples;
            if ((iSuperSamples = IsCorectIntNumberFormat("Super Samples", superSamples)) == -1) return false;
            if (!IsCorectIntNumber("Super Samples", iSuperSamples, 1, 8)) return false;

            int iShapeCount;
            if ((iShapeCount = IsCorectIntNumberFormat("Shape count", shapeCount)) == -1) return false;
            if (!IsCorectIntNumber("Shape count", iShapeCount, 1, 20)) return false;

            int iLightCount;
            if ((iLightCount = IsCorectIntNumberFormat("Light count", lightCount)) == -1) return false;
            if (!IsCorectIntNumber("Light count", iLightCount, 1, 20)) return false;

            int iLightSamples;
            if ((iLightSamples = IsCorectIntNumberFormat("Light Samples", lightSamples)) == -1) return false;
            if (!IsCorectIntNumber("Light samples", iLightSamples, 1, 128)) return false;

            int iIndirectLightSamples;
            if ((iIndirectLightSamples = IsCorectIntNumberFormat("Indirect light samples", indirectLightSamples)) == -1) return false;
            if (!IsCorectIntNumber("Indirect light samples", iLightSamples, 1, 128)) return false;

            int iMaxDepth;
            if ((iMaxDepth = IsCorectIntNumberFormat("Max recursion depth", maxDepth)) == -1) return false;
            if (!IsCorectIntNumber("Max recursion depth", iMaxDepth, 0, 10)) return false;

            InitScene(outputFile, imgFile, screenWidth, screenHeight, iSuperSamples, iShapeCount,
                iLightCount, iLightSamples, iIndirectLightSamples, iMaxDepth);

            return true;  
        }


        /// <summary>
        /// Metoda urcena pro kontrolu vstupu z fromulare pro vlastni scenu
        /// </summary>
        /// <param name="outputFile">vystupni soubor</param>
        /// <param name="imgFile">vystupni soubor obrazku</param>
        /// <param name="width">sirka</param>
        /// <param name="height">vyska</param>
        /// <param name="superSamples">vzorky</param>
        /// <param name="lightSamples">pocet vzorku svetel</param>
        /// <param name="indirectLightSamples">pocet neprimych svetel</param>
        /// <param name="maxDepth">hloubka</param>
        /// <param name="isEdit"></param>
        /// <returns>true pokud je formular v poradku</returns>
        internal bool ControlOwnForm(String outputFile, String imgFile, String width, String height,
           String superSamples, String lightSamples, String indirectLightSamples, String maxDepth, bool isEdit)
        {
            if (!IsCorectField("Output scene file", outputFile)) return false;
            if (!IsCorectField("Output image file", imgFile)) return false;
            if (!IsCorectField("Scene width", width)) return false;
            if (!IsCorectField("Scene height", height)) return false;
            if (!IsCorectField("superSamples", superSamples)) return false;
            if (!IsCorectField("lightSamples", lightSamples)) return false;
            if (!IsCorectField("indirectLightSamples", indirectLightSamples)) return false;
            if (!IsCorectField("maxDepth", maxDepth)) return false;

            int screenWidth;
            if ((screenWidth = IsCorectIntNumberFormat("Scene width", width)) == -1) return false;
            if (!IsCorectIntNumber("Scene width", screenWidth, 1, 3840)) return false;

            int screenHeight;
            if ((screenHeight = IsCorectIntNumberFormat("Scene height", height)) == -1) return false;
            if (!IsCorectIntNumber("Scene height", screenHeight, 1, 3840)) return false;

            int iSuperSamples;
            if ((iSuperSamples = IsCorectIntNumberFormat("Super Samples", superSamples)) == -1) return false;
            if (!IsCorectIntNumber("Super Samples", iSuperSamples, 1, 8)) return false;

            int iLightSamples;
            if ((iLightSamples = IsCorectIntNumberFormat("Light Samples", lightSamples)) == -1) return false;
            if (!IsCorectIntNumber("Light samples", iLightSamples, 1, 128)) return false;

            int iIndirectLightSamples;
            if ((iIndirectLightSamples = IsCorectIntNumberFormat("Indirect light samples", indirectLightSamples)) == -1) return false;
            if (!IsCorectIntNumber("Indirect light samples", iLightSamples, 1, 128)) return false;

            int iMaxDepth;
            if ((iMaxDepth = IsCorectIntNumberFormat("Max recursion depth", maxDepth)) == -1) return false;
            if (!IsCorectIntNumber("Max recursion depth", iMaxDepth, 0, 10)) return false;

            if (!isEdit)
            {
                InitScene(outputFile, imgFile, screenWidth, screenHeight, iSuperSamples, 0, 0, iLightSamples, iIndirectLightSamples, iMaxDepth);
            }
            else
            {
                EditScene(outputFile, imgFile, screenWidth, screenHeight, iSuperSamples, iLightSamples, iIndirectLightSamples, iMaxDepth);
            }

            return true;
        }


        /// <summary>
        /// Metoda pro kontrolu cisla ve formatu double
        /// </summary>
        /// <param name="fieldName">Jmeno pole</param>
        /// <param name="value">Hodnota v poli</param>
        /// <returns>treu pokud je cislo v poradku</returns>
        public Double IsCorectDoubleNumberFormat(string fieldName, string value)
        {
            try
            {
            return Double.Parse(value);
            }
            catch (FormatException)
            {
                string message = "You do not fill number to " + fieldName;
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                return -1;
            }

        }


        /// <summary>
        /// Metoda pro kontrolu cisla ve formatu int
        /// </summary>
        /// <param name="fieldName">Jmeno pole</param>
        /// <param name="value">Hodnota pole</param>
        /// <returns>true pokud je cislo v poradku</returns>
        public int IsCorectIntNumberFormat(string fieldName, string value)
        {
            try
            {
                return Int32.Parse(value);
            }
            catch (FormatException)
            {
                string message = "You do not fill number to " + fieldName;
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                return -1;
            }

        }


        /// <summary>
        /// Metoda pro kontrolu, zda bylo vyplneno dane policko
        /// </summary>
        /// <param name="fieldName">Jmeno pole</param>
        /// <param name="value">Hodnota pole</param>
        /// <returns>true pokud je cislo v poradku</returns>
        public bool IsCorectField(string fieldName, string field)
        {
            if ((field.Length == 0) || field.Contains(" "))
            {
                string message = "You did not enter a " + fieldName;
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Metoda pro kontrolu, zda je int cislo ve spravnem intervalu
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>true pokud je cislo ve spravnem intervalu</returns>
        public bool IsCorectIntNumber(String fieldName, int value, int min, int max)
        {
            if(value > max || value < min)
            {
                string message = "You did not enter value in " + fieldName;
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Metoda pro kontrolu, zda je double cislo ve spravnem intervalu
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>true pokud je cislo ve spravnem intervalu</returns>

        public bool IsCorectDoubleNumber(String fieldName, double value, double min, double max)
        {
            if (value > max || value < min)
            {
                string message = "You did not enter value in " + fieldName;
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Metoda pro nastaveni dat ziskanych z formulare, do sceny
        /// </summary>
        /// <param name="outputFile">vystupni soubor</param>
        /// <param name="imgFile">vystupni soubor obrazku</param>
        /// <param name="width">sirka</param>
        /// <param name="height">vyska</param>
        /// <param name="superSamples">vzorky</param>
        /// <param name="shapeCount">pocet objektu</param>
        /// <param name="lightCount">pocet svetel</param>
        /// <param name="lightSamples">pocet vzorku svetel</param>
        /// <param name="indirectLightSamples">pocet neprimych svetel</param>
        /// <param name="maxDepth">hloubka</param>
        internal void InitScene(string sceneOutputFilePath, string imageOutputFilePath, int screenWidth,
            int screenHeight, int superSamples, int shapeCount, int lightCount, int lightSamples, int indirectLightSamples, int maxDepth)
        {
            Scene.FillScene(sceneOutputFilePath, imageOutputFilePath,
                            screenWidth, screenHeight, superSamples, shapeCount, lightCount, lightSamples,
                            indirectLightSamples, maxDepth);

            double aspect = (Scene.screenWidth / Scene.screenHeight);
            Scene.Camera = Camera.LookAt(new Vector(6.0, 3.0, 12.0), new Vector(), aspect, 60.0);
        }

      
        /// <summary>
        /// Metoda urcena pro kontrolu vstupu z fromulare editaci sceny
        /// </summary>
        /// <param name="outputFile">vystupni soubor</param>
        /// <param name="imgFile">vystupni soubor obrazku</param>
        /// <param name="width">sirka</param>
        /// <param name="height">vyska</param>
        /// <param name="superSamples">vzorky</param>
        /// <param name="lightSamples">pocet vzorku svetel</param>
        /// <param name="indirectLightSamples">pocet neprimych svetel</param>
        /// <param name="maxDepth">hloubka</param>
        internal void EditScene(string sceneOutputFilePath, string imageOutputFilePath, int screenWidth,
            int screenHeight, int superSamples,  int lightSamples, int indirectLightSamples, int maxDepth)
        {
            Scene.FillStaticInfo(sceneOutputFilePath, imageOutputFilePath,
                            screenWidth, screenHeight, superSamples, lightSamples,
                            indirectLightSamples, maxDepth);
        }


        /// <summary>
        /// Metoda urcena pro aktualizaci dat ve vybranem Kvadru
        /// </summary>
        /// <param name="cuboid">objet kvadru</param>
        /// <param name="coordX">X souradnice</param>
        /// <param name="coordY">Y souradnice</param>
        /// <param name="coordZ">Z souradnice</param>
        /// <param name="width">sirka</param>
        /// <param name="height">vyska</param>
        /// <param name="depth">hloubka</param>
        /// <param name="color">barva</param>
        /// <returns>Upraveny objekt Cuboid </returns>
        internal bool UpdateCuboid(Cuboid cuboid, string coordX, string coordY,
            string coordZ, string width, string height, string depth, Color color)
        {
            if (!IsCorectField("X", coordX)) return false;
            if (!IsCorectField("Y", coordY)) return false;
            if (!IsCorectField("Z", coordZ)) return false;
            if (!IsCorectField("Width", width)) return false;
            if (!IsCorectField("Height", height)) return false;
            if (!IsCorectField("Depth", depth)) return false;

            double x = 0;
            if ((x = IsCorectDoubleNumberFormat("X", coordX)) == -1) return false;
            if (!IsCorectDoubleNumber("X", x, -maxSceneSize, maxSceneSize)) return false;

            double y = 0;
            if ((y = IsCorectDoubleNumberFormat("Y", coordY)) == -1) return false;
            if (!IsCorectDoubleNumber("Y", y, -maxSceneSize, maxSceneSize)) return false;

            double z = 0;
            if ((z = IsCorectDoubleNumberFormat("Z", coordZ)) == -1) return false;
            if (!IsCorectDoubleNumber("Z", z, -maxSceneSize, maxSceneSize)) return false;
            double dwidth;
            if ((dwidth = IsCorectDoubleNumberFormat("Width", width)) == -1) return false;
            if (!IsCorectDoubleNumber("Width", dwidth, -maxSceneSize, maxSceneSize)) return false;

            double dheight;
            if ((dheight = IsCorectDoubleNumberFormat("Height", height)) == -1) return false;
            if (!IsCorectDoubleNumber("Height", dheight, -maxSceneSize, maxSceneSize)) return false;

            double ddepth;
            if ((ddepth = IsCorectDoubleNumberFormat("Depth", depth)) == -1) return false;
            if (!IsCorectDoubleNumber("Depth", ddepth, -maxSceneSize, maxSceneSize)) return false;

            if (color == null) return false;
              

            double r = (double)(color.R / 255.0);
            double g = (double)(color.G / 255.0);
            double b = (double)(color.B / 255.0);

            
            
            cuboid.Material.Color.X = r;
            cuboid.Material.Color.Y = g;
            cuboid.Material.Color.Z = (b);
            cuboid.Depth = ddepth;
            cuboid.Height = dheight;
            cuboid.Width = dwidth;
            cuboid.Point.Z = z;
            cuboid.Point.Y = y;
            cuboid.Point.X = x;

            imageControler.RepaintCanvas();

            return true;
        }


        /// <summary>
        /// Metoda urcena pro aktualizaci dat ve vybranem Kvadru
        /// </summary>
        /// <param name="coordX">X souradnice</param>
        /// <param name="coordY">Y souradnice</param>
        /// <param name="coordZ">Z souradnice</param>
        /// <param name="angle"></param>
        /// <returns></returns>
        internal bool UpdateCamera(string coordX, string coordY, string coordZ, string angle)
        {
            double aspect = (Scene.screenWidth / Scene.screenHeight);

            if (!IsCorectField("X", coordX)) return false;
            if (!IsCorectField("Y", coordY)) return false;
            if (!IsCorectField("Z", coordZ)) return false;
            if (!IsCorectField("angle", angle)) return false;


            double x = 0;
            if ((x = IsCorectDoubleNumberFormat("X", coordX)) == -1) return false;
            if (!IsCorectDoubleNumber("X", x, -maxSceneSize, maxSceneSize)) return false;

            double y = 0;
            if ((y = IsCorectDoubleNumberFormat("Y", coordY)) == -1) return false;
            if (!IsCorectDoubleNumber("Y", y, -maxSceneSize, maxSceneSize)) return false;

            double z = 0;
            if ((z = IsCorectDoubleNumberFormat("Z", coordZ)) == -1) return false;
            if (!IsCorectDoubleNumber("Z", z, -maxSceneSize, maxSceneSize)) return false;

            double sangle = 0;
            if ((sangle = IsCorectDoubleNumberFormat("Angle", angle)) == -1) return false;
            if (!IsCorectDoubleNumber("Angle", sangle, -maxSceneSize, maxSceneSize)) return false;


            Scene.Camera = Camera.LookAt(new Vector(x, y, z), new Vector(), aspect, sangle);

            imageControler.RepaintCanvas();

            return true;
        }

        /// <summary>
        /// Metoda urcena pro aktualizaci dat ve vybranem Koule
        /// </summary>
        /// <param name="cuboid">objet Koule</param>
        /// <param name="coordX">X souradnice</param>
        /// <param name="coordY">Y souradnice</param>
        /// <param name="coordZ">Z souradnice</param>
        /// <param name="width">sirka</param>
        /// <param name="height">vyska</param>
        /// <param name="depth">hloubka</param>
        /// <param name="color">barva</param>
        /// <returns>Upraveny objekt Sphere </returns>
        internal bool UpdateSphere(Sphere sphere, string coordX, string coordY,
            string coordZ, string radius, Color color)
        {

            if (!IsCorectField("X", coordX)) return false;
            if (!IsCorectField("Y", coordY)) return false;
            if (!IsCorectField("Z", coordZ)) return false;
            if (!IsCorectField("Radius", radius)) return false;
            
            double x = 0;
            if ((x = IsCorectDoubleNumberFormat("X", coordX)) == -1) return false;
            if (!IsCorectDoubleNumber("X", x, -maxSceneSize, maxSceneSize)) return false;

            double y = 0;
            if ((y = IsCorectDoubleNumberFormat("Y", coordY)) == -1) return false;
            if (!IsCorectDoubleNumber("Y", y, -maxSceneSize, maxSceneSize)) return false;

            double z = 0;
            if ((z = IsCorectDoubleNumberFormat("Z", coordZ)) == -1) return false;
            if (!IsCorectDoubleNumber("Z", z, -maxSceneSize, maxSceneSize)) return false;

            double dradius;
            if ((dradius = IsCorectDoubleNumberFormat("Radius", radius)) == -1) return false;
            if (!IsCorectDoubleNumber("Width", dradius, -maxSceneSize, maxSceneSize)) return false;
            
            if (color == null) return false;

            double r = (color.R / 255.0);
            double g = (color.G / 255.0);
            double b = (color.B / 255.0);


            sphere.Material.Color.X = r;
            sphere.Material.Color.Y = g;
            sphere.Material.Color.Z = b;

            sphere.Radius = dradius;
            
            sphere.Point.X = x;
            sphere.Point.Y = y;
            sphere.Point.Z = z;
 
            imageControler.RepaintCanvas();
            return true;
        }
    }
       

}   
