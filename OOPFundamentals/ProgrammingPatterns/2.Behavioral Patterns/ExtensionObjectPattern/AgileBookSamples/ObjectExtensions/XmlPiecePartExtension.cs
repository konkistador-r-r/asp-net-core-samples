using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ExtensionObjectPattern.AgileBookSamples
{
    public class XmlPiecePartExtension : XmlPartExtension
    {
        private PiecePart piecePart;
        public XmlPiecePartExtension(PiecePart part)
        {
            piecePart = part;
        }
        public override XmlElement XmlElement
        {
            get
            {
                XmlElement e = NewElement("PiecePart");
                e.AppendChild(NewTextElement("PartNumber", piecePart.PartNumber));
                e.AppendChild(NewTextElement("Description", piecePart.Description));
                e.AppendChild(NewTextElement("Cost", piecePart.Cost.ToString()));
                return e;
            }
        }
    }
}
