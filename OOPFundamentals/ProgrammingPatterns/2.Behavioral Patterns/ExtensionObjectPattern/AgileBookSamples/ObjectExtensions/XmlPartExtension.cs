using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ExtensionObjectPattern.AgileBookSamples
{
    public abstract class XmlPartExtension : IPartExtension
    {
        private static XmlDocument document = new XmlDocument();
        public abstract XmlElement XmlElement { get; }
        protected XmlElement NewElement(string name)
        {
            return document.CreateElement(name);
        }
        protected XmlElement NewTextElement(string name, string text)
        {
            XmlElement element = document.CreateElement(name);
            XmlText xmlText = document.CreateTextNode(text);
            element.AppendChild(xmlText);
            return element;
        }
    }
}
