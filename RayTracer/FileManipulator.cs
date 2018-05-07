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


    public class FileManipulator
    {
        public StreamWriter FileWriter { get; set; }
        private Scene scene { get; set; }

        public FileManipulator(Scene scene)
        {
            this.scene = scene;
        }

        public void SaveSceneToTXT()
        {
            string outputText = scene.GetInfo();

            if (scene.shapes != null)
            {

                for (int i = 0; i < scene.shapeCount; i++)
                {
                    outputText += scene.shapes[i].ToString();

                }
            }

            if (scene.lights != null)
            {

                for (int i = 0; i < scene.lightCount; i++)
                {
                    outputText += scene.lights[i].ToString();

                }
            }

            File.WriteAllText(scene.sceneOutputFilePath, outputText);

           
        }

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


            scene.shapes = new List<Shape>();
            for (int i = 0; i <= shapeNodeList.Count - 1; i++)
            {
               scene.shapes.Add(ProcessShapeXML(shapeNodeList[i], doc));
            }

            scene.lights = new List<Light>();
            for (int i = 0; i <= lightNodeList.Count - 1; i++)
            {
                scene.lights.Add(ProcessLightXML(lightNodeList[i], doc));
            }

        }

        private Light ProcessLightXML(XmlNode xmlNode, XmlDocument doc)
        {
            return new Light(ProcessSphereFromXML(xmlNode.SelectSingleNode("shape/sphere"), doc));
        }

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

        private Shape ProcessPlaneFromXML(XmlNode xmlNode, XmlDocument doc)
        {
            double distance;
            Vector v = ProcessVectorFromXML(xmlNode.SelectSingleNode("vector"), doc);

            Material m = ProcessMaterialFromXML(xmlNode.SelectSingleNode("material"), doc);

            distance = Double.Parse(xmlNode.SelectSingleNode("distance").InnerText.Trim());


            return new Plane(m, v, distance);
        }

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

        private Shape ProcessSphereFromXML(XmlNode xmlNode, XmlDocument doc)
        {
            double radius;
            XmlNode node = xmlNode.SelectSingleNode("vector");
            Vector v = ProcessVectorFromXML(node, doc);

            Material m = ProcessMaterialFromXML(xmlNode.SelectSingleNode("material"), doc);

            radius = Double.Parse(xmlNode.SelectSingleNode("radius").InnerText.Trim());


            return new Sphere(m, v, radius);
        }

        private Material ProcessMaterialFromXML(XmlNode xmlNode, XmlDocument doc)
        {
            Vector v = ProcessVectorFromXML(xmlNode.SelectSingleNode("vector"), doc);

            return new Material(v);
        }

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

        private void ReadLights(StreamReader file)
        {
            scene.lights = new List<Light>();

            int i = 0;

            while(i <= (scene.lightCount - 1))
            {
                if (textReadLine(file).Contains("l"))
                {
                    if (textReadLine(file).Contains("s"))
                    {
                        Shape tmpShape = ProcessSphereBodyTXT(file);
                        if(tmpShape != null)
                        {
                        scene.lights.Add(new Light(tmpShape));
                        }
                    }
                    else
                    {
                        break;
                    }

                }
                else
                {
                    break;
                }
                i++;
            }
        }

        public void SaveSceneToXML()
        {
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

            if (scene.shapes != null)
            {

                for (int i = 0; i < scene.shapeCount; i++)
                {
                    doc.DocumentElement.AppendChild(scene.shapes[i].GetInXML(doc));
                     
                }
            }

            if (scene.lights != null)
            {

                for (int i = 0; i < scene.lightCount; i++)
                {
                    doc.DocumentElement.AppendChild(scene.lights[i].GetInXML(doc));

                }
            }
      
            doc.Save(scene.sceneOutputFilePath);

            
        }


        private XmlElement CreateXMLElem(String elmName, String text, XmlDocument doc)
        {
            XmlElement elem = doc.CreateElement(elmName);
            XmlText eText = doc.CreateTextNode(text);
            elem.AppendChild(eText);

            return elem;
        }

        private void ReadShepes(StreamReader file)
        {
            

            int i = 0;
            scene.shapes = new List<Shape>();

            while (i <= (scene.shapeCount-1)) 
            {
                string tmp = textReadLine(file);
              
                if (tmp.Contains("s"))
                {
                    scene.shapes.Add(ProcessSphereBodyTXT(file));
                }
                else if (tmp.Contains("c"))
                {
                    scene.shapes.Add(ProcessCuboidBodyTXT(file));
                }
                else if (tmp.Contains("p"))
                {
                     scene.shapes.Add(ProcessPlaneBodyTXT(file));
                }
                else
                {
                    break;
                }
                              
                i++;

            }
        }


        public Shape ProcessPlaneBodyTXT(StreamReader file)
        {

            double x, y, z, r, g, b, dept;

            r = TextReadNumber(file);
            g = TextReadNumber(file);
            b = TextReadNumber(file);

            x = TextReadNumber(file);
            y = TextReadNumber(file);
            z = TextReadNumber(file);

            dept = TextReadNumber(file);
           

            Plane tmpPlane = new Plane(new Material(new Vector(r, g, b)), new Vector(x, y, z), dept);
            return tmpPlane;
        }

        public Shape ProcessCuboidBodyTXT(StreamReader file)
        {

            double x, y, z, r, g, b, width, height, dept;

            r = TextReadNumber(file);
            g = TextReadNumber(file);
            b = TextReadNumber(file);

            x = TextReadNumber(file);
            y = TextReadNumber(file);
            z = TextReadNumber(file);

            width = TextReadNumber(file);
            height = TextReadNumber(file);
            dept = TextReadNumber(file);

            Cuboid tmpCuboid = new Cuboid(new Material(new Vector(r, g, b)), new Vector(x, y, z), width, height, dept);
            return tmpCuboid;
        }

        public Shape ProcessSphereBodyTXT(StreamReader file)
        {

            double x, y,z,r,g,b, radius;

            r = TextReadNumber(file);
            g = TextReadNumber(file);
            b = TextReadNumber(file);

            x = TextReadNumber(file);
            y = TextReadNumber(file);
            z = TextReadNumber(file);

            radius = TextReadNumber(file);

            Sphere tmpSphere = new Sphere(new Material(new Vector(r, g, b)), new Vector(x, y, z), radius);
            return tmpSphere;
        }

        private double TextReadNumber(StreamReader file)
        {
            string output_string = "";
            double output = 0;

            output_string = textReadLine(file);
           
            if (output_string != null)
            {
                output = double.Parse(output_string);
            }

            return output;
        }
    
        private string textReadLine(System.IO.StreamReader file)
        {
            string output = "";

            if ((output = file.ReadLine()) != null)
            {

                return output;
            }

            return null;
        }

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
