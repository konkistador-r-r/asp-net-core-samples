using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionObjectPattern.AgileBookSamples
{
    public class PiecePart : Part
    {
        private string partNumber;
        private string description;
        private double cost;
        public PiecePart(string partNumber, string description, double cost)
        {
            this.partNumber = partNumber;
            this.description = description;
            this.cost = cost;

            AddExtension("CSV", new CsvPiecePartExtension(this));
            AddExtension("XML", new XmlPiecePartExtension(this));
        }

        public override string PartNumber
        {
            get { return partNumber; }
        }
        public override string Description
        {
            get { return description; }
        }
        public double Cost
        {
            get { return cost; }
        }
    }
}
