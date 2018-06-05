﻿using System.Collections.Generic;

namespace XMLTest
{
    public class Element
    {

        public string Identifier_ { get; set; }

        public string Type_ { get; set; }

        public string Name_ { get; set; }

        public string Documentation_ { get; set; }

        public List<Property> Properties_ { get; set; }


        public Element()
        {
        }

        public Element(string identifier_, string type_, string name_, string documentation_, List<Property> properties_)
        {
            this.Identifier_ = identifier_;
            this.Type_ = type_;
            this.Name_ = name_;
            this.Documentation_ = documentation_;
            this.Properties_ = properties_;
        }

        public override string ToString()
        {
            string s;
            s = "identifier: " + this.Identifier_ + "\r\nname: " + this.Name_ + "\r\ntype: " + this.Type_ + "\r\ndocumentation: " + this.Documentation_ + "\r\nproperties: ";
            if (this.Properties_ != null)
            {
                int i = 0;
                foreach(Property p in this.Properties_)
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
        public string value;
    }
}
