using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorPattern.AgileBookSamples.ReportGenerationVisitors
{
    public class ExplodedCostVisitor : PartVisitor
    {
        private double cost = 0;
        public double Cost
        {
            get { return cost; }
        }
        public void Visit(PiecePart p)
        {
            cost += p.Cost;
        }
        public void Visit(Assembly a)
        { }
    }
}
