using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorPattern.AgileBookSamples.ReportGenerationVisitors
{
    public interface Part
    {
        string PartNumber { get; }
        string Description { get; }
        void Accept(PartVisitor v);
    }
}
