using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorPattern.AgileBookSamples.ReportGenerationVisitors
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
        }
        public void Accept(PartVisitor v)
        {
            v.Visit(this);
        }
        public string PartNumber
        {
            get { return partNumber; }
        }
        public string Description
        {
            get { return description; }
        }
        public double Cost
        {
            get { return cost; }
        }
    }
}
