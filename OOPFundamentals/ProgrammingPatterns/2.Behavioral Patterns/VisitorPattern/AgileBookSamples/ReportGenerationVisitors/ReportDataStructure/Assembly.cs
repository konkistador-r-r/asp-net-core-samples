using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace VisitorPattern.AgileBookSamples.ReportGenerationVisitors
{
    public class Assembly : Part
    {
        private IList parts = new ArrayList();
        private string partNumber;
        private string description;

        public Assembly(string partNumber, string description)
        {
            this.partNumber = partNumber;
            this.description = description;
        }
        public void Accept(PartVisitor v)
        {
            v.Visit(this);
            foreach (Part part in Parts)
                part.Accept(v);
        }
        public void Add(Part part)
        {
            parts.Add(part);
        }
        public IList Parts
        {
            get { return parts; }
        }
        public string PartNumber
        {
            get { return partNumber; }
        }
        public string Description
        {
            get { return description; }
        }
    }

}
