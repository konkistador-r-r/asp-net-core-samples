using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorPattern.AgileBookSamples.ReportGenerationVisitors
{
    public interface PartVisitor
    {
        void Visit(PiecePart pp);
        void Visit(Assembly a);
    }
}
