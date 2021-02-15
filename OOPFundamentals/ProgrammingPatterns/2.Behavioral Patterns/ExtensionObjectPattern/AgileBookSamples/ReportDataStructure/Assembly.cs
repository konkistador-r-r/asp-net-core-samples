using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ExtensionObjectPattern.AgileBookSamples
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

            AddExtension("CSV", new CsvAssemblyExtension(this));
            AddExtension("XML", new XmlAssemblyExtension(this));
        }

        public void Add(Part part)
        {
            parts.Add(part);
        }
        public IList Parts
        {
            get { return parts; }
        }
        public override string PartNumber
        {
            get { return partNumber; }
        }
        public override string Description
        {
            get { return description; }
        }
    }

}
