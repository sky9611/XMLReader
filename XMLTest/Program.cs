using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace XMLTest
{
    class Program
    {
        XElement doc;
        XNamespace NP;
        XNamespace xmlns_xsi = "http://www.w3.org/2001/XMLSchema-instance";

        List<Element> list_element = new List<Element>();
        Dictionary<string, string> property_definition_map = new Dictionary<string, string>();

        public void ReadXml(string path)
        {
            doc = XElement.Load(path);
            NP = doc.GetDefaultNamespace();
            Console.WriteLine("XML loaded \r\n");
        }


        public void GetPropertyDefinition()
        {
            if (doc == null)
            {
                Console.WriteLine("XML not loaded yet");
            }
            else
            {

                IEnumerable<XElement> prop_defs = from element in doc.Descendants(NP + "propertyDefinition")
                                                  select element;
                foreach (XElement ele in prop_defs)
                {
                    property_definition_map.Add(ele.Attribute("identifier").Value, (ele.Element(NP + "name").Value != null) ? ele.Element(NP + "name").Value : "");
                }
            }
        }

        public void DataIn()
        {
            if (doc == null)
            {
                Console.WriteLine("XML not loaded yet");
            }
            else
            {
                list_element = doc.Descendants(NP + "element").Select(x =>
                       new Element(
                              ((XElement)x).Attribute("identifier").Value,
                              ((XElement)x).Attribute(xmlns_xsi + "type").Value,
                              (((XElement)x).Element(NP + "name") != null) ? ((XElement)x).Element(NP + "name").Value : "",
                              (((XElement)x).Element(NP + "documentation") != null) ? ((XElement)x).Element(NP + "documentation").Value : "",
                              (((XElement)x).Descendants(NP + "properties") != null) ? ((XElement)x).Descendants(NP + "property").Select(y =>
                                   new Property
                                   {
                                       name = property_definition_map[((XElement)y).Attribute("propertyDefinitionRef").Value],
                                       //value = Int32.Parse(((XElement)y).Element(NP + "value").Value)
                                       value = ((XElement)y).Element(NP + "value").Value
                                   }
                              ).ToList() : null
                           )).ToList();
            }
        }

        public void PrintElements()
        {
            foreach (Element element in list_element)
            {
                Console.WriteLine(element);
                Console.WriteLine("\r\n");
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            var path = @"D:\documents\INSA\maidis\vs\test\XMLTest\XMLTest\Test\Read\PLATEFORME_VNEXT.xml";
            //var path = @"Test\Read\element_test.xml";
            program.ReadXml(path);
            program.GetPropertyDefinition();
            program.DataIn();
            program.PrintElements();
            //Console.WriteLine("Hello World!");
        }
    }
}
