using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionObjectPattern.AgileBookSamples
{
    public class CsvPiecePartExtension : ICsvPartExtension
    {
        private PiecePart piecePart;
        public CsvPiecePartExtension(PiecePart part)
        {
            piecePart = part;
        }
        public string CsvText
        {
            get
            {
                StringBuilder b = new StringBuilder("PiecePart,");
                b.Append(piecePart.PartNumber);
                b.Append(",");
                b.Append(piecePart.Description);
                b.Append(",");
                b.Append(piecePart.Cost);
                return b.ToString();
            }
        }
    }
}
