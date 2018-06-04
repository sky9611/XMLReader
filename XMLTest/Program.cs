using System;
using System.Collections.Generic;
using System.Xml;

namespace XMLTest
{
    class Program
    {
        XmlDocument doc = new XmlDocument();
        List<Element> elements = new List<Element>(); 
        public void ReadXml(string path)
        {
            doc.Load(path);
        }

        public void DataIn()
        {
            if (doc == null)
            {
                Console.WriteLine("XML not loaded yet");
            }
            else
            {
                XmlNode xml_node = doc.SelectSingleNode("elements");
                XmlNodeList xml_node_list = xml_node.ChildNodes;
                foreach (XmlNode xn in xml_node_list)
                {
                    Element eleemnt = new Element();
                }
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.ReadXml("TOB");
            Console.WriteLine("Hello World!");
        }
    }
}
