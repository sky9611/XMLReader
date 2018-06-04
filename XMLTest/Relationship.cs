using System;
using System.Collections.Generic;
using System.Text;

namespace XMLTest
{
    enum AccesType {Write, Read, ReadWrite};
    class Relationship
    {
        private string identifier_;
        private string source_;
        private string target_;
        private string type_;
        private string name_;
        private AccesType accesType_;
        private Property[] properties_;


        public Relationship()
        {
        }

        public Relationship(string identifier_, string source_, string target_, string type_, string name_, AccesType accesType_, Property[] properties_)
        {
            this.identifier_ = identifier_;
            this.source_ = source_;
            this.target_ = target_;
            this.type_ = type_;
            this.name_ = name_;
            this.accesType_ = accesType_;
            this.properties_ = properties_;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
