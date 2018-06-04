using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace XMLTest
{
    class Program
    {
        XDocument doc = new XmlDocument();
        List<Element> list_element = new List<Element>(); 
		Dictionary<string,string> property_definition_map = new Dictionary<string,string>();
        public void ReadXml(string path)
        {
            doc.Load(path);
        }
		
		public void getPropertyDefinition()
		{
			if (doc == null)
            {
                Console.WriteLine("XML not loaded yet");
            }
            else
            {
				doc.DescendantsAndSelf("propertyDefinition").Select(x=>
					property_definition_map.add(x.Element("propertyDefinition").Attribute("identifier").Value, x.Element("name").Value));
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
                list_element=doc.DescendantsAndSelf("element").Select(x=>
					new Element
					{
						identifier_=x.Element("Element").Attribute("identifier").Value,
						type_=x.Element("Element").Attribute("type").Value,
						name_= (x.Element("name")!=null) ? x.Element("name").Value : "",
						documentation_= (x.Elements("documentation")!=null) ? x.Elements("documentation").Value : "",
						properties_ = (x.Elements("properties")!=null) ? x.DescendantsAndSelf("property").Select(y=>
						string prop_name;
						property_definition_map.TryGetValue(y.Elements("property").Attribute("propertyDefinitionRef").Value,prop_name);
							new Property
							{
								name = prop_name,
								value = y.Element("Value").Value
							}).ToList<Property>() : null()
					).ToList<Element>();
            }
        }
		
		public void printElements()
		{
			foreach (element in list_element)
			{
				Console.WriteLine(element);
			}
		}		

        static void Main(string[] args)
        {
            Program program = new Program();
            program.ReadXml("TOB");
			program.getPropertyDefinition();
			program.DataIn();
			program.printElements();
            //Console.WriteLine("Hello World!");
        }
    }
}
