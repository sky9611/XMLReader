using System;
using System.Collections.Generic;
using System.Text;

namespace XMLTest
{
    public class Element
    {
        string identifier_;
        string type_;
        string name_;
        string documentation_;
        Property[] properties_;

        public Element()
        {
        }

        public Element(string identifier_, string type_, string name_, string documentation_, Property[] properties_)
        {
            this.identifier_ = identifier_;
            this.type_ = type_;
            this.name_ = name_;
            this.documentation_ = documentation_;
            this.properties_ = properties_;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    public struct Property
    {
        string name;
        int value;
    }
}
