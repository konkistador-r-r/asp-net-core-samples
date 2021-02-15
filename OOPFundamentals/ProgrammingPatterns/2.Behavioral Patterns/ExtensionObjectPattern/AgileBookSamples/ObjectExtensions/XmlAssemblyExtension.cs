using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ExtensionObjectPattern.AgileBookSamples
{
    public class XmlAssemblyExtension : XmlPartExtension
    {
        private Assembly assembly;
        public XmlAssemblyExtension(Assembly assembly)
        {
            this.assembly = assembly;
        }
        public override XmlElement XmlElement
        {
            get
            {
                XmlElement e = NewElement("Assembly");
                e.AppendChild(NewTextElement("PartNumber", assembly.PartNumber));
                e.AppendChild(NewTextElement("Description", assembly.Description));
                XmlElement parts = NewElement("Parts");

                foreach (Part part in assembly.Parts)
                {
                    XmlPartExtension xpe = part.GetExtension("XML") as XmlPartExtension;
                    parts.AppendChild(xpe.XmlElement);
                }
                e.AppendChild(parts);
                return e;
            }
        }
    }
}
