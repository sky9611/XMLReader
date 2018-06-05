using System;
using System.Collections.Generic;
using System.Text;

namespace XMLTest
{
    public class Element
    {
        private	string identifier_;
        private string type_;
        private string name_;
        private string documentation_;
        private List<Property> properties_;
		
		public string Identifier_
		{
			get { return identifier_; }
			set { identifier_ = value; }
		}
		
		public string Type_
		{
			get { return type_; }
			set { type_ = value; }
		}
		
		public string Name_
		{
			get { return name_; }
			set { name_ = value; }
		}

		public string Documentation_
		{
			get { return documentation_; }
			set { documentation_ = value; }
		}

		public List<Property> Properties_
		{
			get { return properties_; }
			set { properties_ = value; }
		}


        public Element()
        {
        }

        public Element(string identifier_, string type_, string name_, string documentation_, List<Property> properties_)
        {
            this.identifier_ = identifier_;
            this.type_ = type_;
            this.name_ = name_;
            this.documentation_ = documentation_;
            this.properties_ = properties_;
        }

        public override string ToString()
        {
            string s;
            s = "identifier: " + this.identifier_ + "\r\nname: " + this.name_ + "\r\ntype: " + this.type_ + "\r\ndocumentation: " + this.documentation_ + "\r\nproperties: ";
            if (this.properties_ != null)
            {
                int i = 0;
                foreach(Property p in this.properties_)
                {
                    if (i != 0)
                        s += "            ";
                    s += p.name + " - " + p.value+"\r\n";
                    i++;
                }
            }
            return s;
        }
    }

    public struct Property
    {
        public string name;
        public int value;
    }
}
