using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RayTracer
{

    /// <summary>
    /// Trida urcena pro praci s XML a TXT soubory.
    /// </summary>

    public class FileManipulator
    {
        public StreamWriter FileWriter { get; set; }
        private Scene scene { get; set; }

        public FileManipulator(Scene scene)
        {
            this.scene = scene;
        }



        /// <summary>
        /// Metoda urcena pro ulozeni sceny do klasickeho TXT
        /// Je vyuzivano prepsanych ToString u jednotlivych objektu a statickych dat o scene
        /// </summary>
        public void SaveSceneToTXT()
        {
            string outputText = scene.GetInfo();

            if (scene.Shapes != null)
            {

                for (int i = 0; i < scene.shapeCount; i++)
                {
                    outputText += scene.Shapes[i].ToString();

                }
            }

            if (scene.Lights != null)
            {

                for (int i = 0; i < scene.lightCount; i++)
                {
                    outputText += scene.Lights[i].ToString();

                }
            }

            File.WriteAllText(scene.sceneOutputFilePath, outputText);

           
        }

        
        /// <summary>
        /// Metoda urcena pro nacteni sceny z klasickeho TXT
        /// </summary>
        /// <param name="inputFile">jmeno vstupniho souboru</param>
        public void loadSceneFromTXT(string inputFile)
        {
            scene.ClearScene();

            scene.sceneInputFilePath = inputFile;
         
            StreamReader file = new StreamReader(inputFile);

            scene.sceneOutputFilePath = textReadLine(file);

            scene.imageOutputFilePath = textReadLine(file);
                        
            scene.screenWidth = (int)TextReadNumber(file);

            scene.screenHeight = (int)TextReadNumber(file);

            scene.superSamples = (int)TextReadNumber(file);

            scene.shapeCount = (int)TextReadNumber(file);

            scene.lightCount = (int)TextReadNumber(file);

            scene.lightSamples = (int)TextReadNumber(file);

            scene.indirectLightSamples = (int)TextReadNumber(file);

            scene.maxDepth = (int)TextReadNumber(file);

            ReadShepes(file);

            ReadLights(file);

            file.Close();

            FileWriter = new StreamWriter(scene.imageOutputFilePath);
        }

        /// <summary>
        /// Metoda urcena pro nacteny sceny z XML souboru
        /// Je vyuzivano tridy XmlDocument pro nacteni obsahu
        /// </summary>
        /// <param name="inputFile"></param>
        public void LoadSceneFromXML(string inputFile)
        {
           
            XmlDocument doc = new XmlDocument();
            doc.Load(inputFile);

            XmlNode outputFileNode = doc.SelectSingleNode("/scene/sceneOutputFile");
            scene.sceneOutputFilePath = outputFileNode.InnerText.Trim();

            XmlNode imageFileNode = doc.SelectSingleNode("/scene/imageOutputFile");
            scene.imageOutputFilePath = imageFileNode.InnerText.Trim();

            XmlNode widthNode = doc.SelectSingleNode("/scene/screenWidth");
            scene.screenWidth = Int32.Parse(widthNode.InnerText.Trim());

            XmlNode heightNode = doc.SelectSingleNode("/scene/screenHeight");
            scene.screenHeight = Int32.Parse(heightNode.InnerText.Trim());

            XmlNode superSamplesNode = doc.SelectSingleNode("/scene/superSamples");
            scene.superSamples = Int32.Parse(superSamplesNode.InnerText.Trim());

            XmlNode shapeCountNode = doc.SelectSingleNode("/scene/shapeCount");
            scene.shapeCount = Int32.Parse(shapeCountNode.InnerText.Trim());

            XmlNode lightCountNode = doc.SelectSingleNode("/scene/lightCount");
            scene.lightCount = Int32.Parse(lightCountNode.InnerText.Trim());

            XmlNode lightSamplesNode = doc.SelectSingleNode("/scene/lightSamples");
            scene.lightSamples = Int32.Parse(lightSamplesNode.InnerText.Trim());

            XmlNode indiretLightSamplesNode = doc.SelectSingleNode("/scene/indiretLightSamples");
            scene.indirectLightSamples = Int32.Parse(indiretLightSamplesNode.InnerText.Trim());

            XmlNode maxDepthNode = doc.SelectSingleNode("/scene/maxDepth");
            scene.maxDepth = Int32.Parse(maxDepthNode.InnerText.Trim());

            XmlNode cameraNode = doc.SelectSingleNode("/scene/camera");
            Vector eye = ProcessVectorFromXML(cameraNode.SelectSingleNode("vector"), doc);

            string sangle = cameraNode.SelectSingleNode("angle").InnerText.Trim();

            double angle = Double.Parse(sangle);
            double aspect = (scene.screenWidth / scene.screenHeight);

            scene.Camera = Camera.LookAt(eye, new Vector(), aspect, angle);


            XmlNode sceneNode =
                doc.SelectSingleNode("/scene");

            XmlNodeList shapeNodeList =
                sceneNode.SelectNodes("shape");

           
            XmlNodeList lightNodeList =
                sceneNode.SelectNodes("light");


            scene.Shapes = new List<Shape>();
            for (int i = 0; i <= shapeNodeList.Count - 1; i++)
            {
               scene.Shapes.Add(ProcessShapeXML(shapeNodeList[i], doc));
            }

            scene.Lights = new List<Light>();
            for (int i = 0; i <= lightNodeList.Count - 1; i++)
            {
                scene.Lights.Add(ProcessLightXML(lightNodeList[i], doc));
            }
            
        }

        /// <summary>
        /// Metoda pro zpracovani elementu Light
        /// </summary>
        /// <param name="xmlNode">xmlNode</param>
        /// <param name="doc">Xmldocument</param>
        /// <returns></returns>
        private Light ProcessLightXML(XmlNode xmlNode, XmlDocument doc)
        {
            return new Light(ProcessSphereFromXML(xmlNode.SelectSingleNode("shape/sphere"), doc));
        }


        /// <summary>
        /// Metoda pro zpracovani elementu Shape z XML
        /// </summary>
        /// <param name="xmlNode">xmlNode</param>
        /// <param name="doc">Document</param>
        /// <returns>Shape nacteny z XML</returns>
        private Shape ProcessShapeXML(XmlNode xmlNode, XmlDocument doc)
        {
            
            XmlNode pom = xmlNode.FirstChild;
            switch (pom.Name)
            {
                case "sphere":
                 return   ProcessSphereFromXML(pom, doc);
                    
                case "cuboid":
                 return   ProcessCuboidFromXML(pom, doc);
                    
                case "plane":
                  return  ProcessPlaneFromXML(pom, doc);
                   
                default:
                    return null;
            }

           
            
        }


        /// <summary>
        /// Metoda pro zpracovani elementu Cuboid z XML
        /// </summary>
        /// <param name="xmlNode">xmlNode</param>
        /// <param name="doc">Document</param>
        /// <returns>Cuboid nacteny z XML</returns>
        private Shape ProcessCuboidFromXML(XmlNode xmlNode, XmlDocument doc)
        {
            double width, height, depth;
            Vector v = ProcessVectorFromXML(xmlNode.SelectSingleNode("vector"), doc);

            Material m = ProcessMaterialFromXML(xmlNode.SelectSingleNode("material"), doc);

            width = Double.Parse(xmlNode.SelectSingleNode("width").InnerText.Trim());
            height = Double.Parse(xmlNode.SelectSingleNode("height").InnerText.Trim());
            depth = Double.Parse(xmlNode.SelectSingleNode("depth").InnerText.Trim());


            return new Cuboid(m, v, width, height,depth);
        }

        /// <summary>
        /// Metoda pro zpracovani elementu Sphere z XML
        /// </summary>
        /// <param name="xmlNode">xmlNode</param>
        /// <param name="doc">Document</param>
        /// <returns>Sphere nacteny z XML</returns>
        private Shape ProcessSphereFromXML(XmlNode xmlNode, XmlDocument doc)
        {
            double radius;
            XmlNode node = xmlNode.SelectSingleNode("vector");
            Vector v = ProcessVectorFromXML(node, doc);

            Material m = ProcessMaterialFromXML(xmlNode.SelectSingleNode("material"), doc);

            radius = Double.Parse(xmlNode.SelectSingleNode("radius").InnerText.Trim());


            return new Sphere(m, v, radius);
        }

        /// <summary>
        /// Metoda pro zpracovani elementu Material z XML
        /// </summary>
        /// <param name="xmlNode">xmlNode</param>
        /// <param name="doc">Document</param>
        /// <returns>Material nacteny z XML</returns>
        private Material ProcessMaterialFromXML(XmlNode xmlNode, XmlDocument doc)
        {
            Vector v = ProcessVectorFromXML(xmlNode.SelectSingleNode("vector"), doc);

            return new Material(v);
        }

        /// <summary>
        /// Metoda pro zpracovani elementu Vector z XML
        /// </summary>
        /// <param name="xmlNode">xmlNode</param>
        /// <param name="doc">Document</param>
        /// <returns>Vector nacteny z XML</returns>
        private Vector ProcessVectorFromXML(XmlNode xmlNode, XmlDocument doc)
        {
            XmlNode xNode = xmlNode.SelectSingleNode("x");
            XmlNode yNode = xmlNode.SelectSingleNode("y");
            XmlNode zNode = xmlNode.SelectSingleNode("z");

            double x = Double.Parse(xNode.InnerText.Trim());
            double y = Double.Parse(yNode.InnerText.Trim());
            double z = Double.Parse(zNode.InnerText.Trim());

            return new Vector(x, y, z);
        }

        
        public bool SaveSceneToXML()
        {
            if (scene?.Camera == null) return false;


            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<?xml version='1.0'?>" +
                        "<scene>" +
                        "</scene>");
            
            doc.DocumentElement.AppendChild(CreateXMLElem("sceneOutputFile", scene.sceneOutputFilePath, doc));
            doc.DocumentElement.AppendChild(CreateXMLElem("imageOutputFile", scene.imageOutputFilePath, doc));
            doc.DocumentElement.AppendChild(CreateXMLElem("screenWidth", scene.screenWidth.ToString(), doc));
            doc.DocumentElement.AppendChild(CreateXMLElem("screenHeight", scene.screenHeight.ToString(), doc));
            doc.DocumentElement.AppendChild(CreateXMLElem("superSamples", scene.superSamples.ToString(), doc));
            doc.DocumentElement.AppendChild(CreateXMLElem("shapeCount", scene.shapeCount.ToString(), doc));
            doc.DocumentElement.AppendChild(CreateXMLElem("lightCount", scene.lightCount.ToString(), doc));
            doc.DocumentElement.AppendChild(CreateXMLElem("lightSamples", scene.lightSamples.ToString(), doc));
            doc.DocumentElement.AppendChild(CreateXMLElem("indiretLightSamples", scene.indirectLightSamples.ToString(), doc));
            doc.DocumentElement.AppendChild(CreateXMLElem("maxDepth", scene.maxDepth.ToString(), doc));

            XmlElement cameElm = doc.CreateElement("camera");
            cameElm.AppendChild(scene.Camera.eye.GetInXML(doc));
            XmlElement angleElm = doc.CreateElement("angle");
            
            XmlText eText = doc.CreateTextNode(scene.Camera.FovY.ToString());

            angleElm.AppendChild(eText);

            cameElm.AppendChild(angleElm);

            doc.DocumentElement.AppendChild(cameElm);

            if (scene.Shapes != null)
            {

                for (int i = 0; i < scene.shapeCount; i++)
                {
                    doc.DocumentElement.AppendChild(scene.Shapes[i].GetInXML(doc));
                     
                }
            }

            if (scene.Lights != null)
            {

                for (int i = 0; i < scene.lightCount; i++)
                {
                    doc.DocumentElement.AppendChild(scene.Lights[i].GetInXML(doc));

                }
            }
      
            doc.Save(scene.sceneOutputFilePath);
            return true;
            
        }

        /// <summary>
        /// Metoda slouzici pro ulozeni staticke inforamce sceny do XML
        /// </summary>
        /// <param name="elmName">XmlElement nazev</param>
        /// <param name="text">Text pro ulozeni</param>
        /// <param name="doc">XmlDocumtn</param>
        /// <returns>true </returns>
        private XmlElement CreateXMLElem(String elmName, String text, XmlDocument doc)
        {
            XmlElement elem = doc.CreateElement(elmName);
            XmlText eText = doc.CreateTextNode(text);
            elem.AppendChild(eText);

            return elem;
        }

       /// <summary>
       /// Metoda pro vygenerovani souboru s informacemi o jasu 
       /// </summary>
       /// <param name="y"></param>
       /// <param name="color"></param>
        public void SaveImgToTXT(int y, int color)
        {

            if(y != scene.screenWidth)
            {
                FileWriter.Write(color.ToString() + " ");
            }
            else
            {

                FileWriter.Write(color.ToString() + "\r\n");
            }

            

        }

    }
}
