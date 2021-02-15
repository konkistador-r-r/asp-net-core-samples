using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace VisitorPattern.AgileBookSamples.ReportGenerationVisitors
{
    public class PartCountVisitor : PartVisitor
    {
        private int pieceCount = 0;
        private Hashtable pieceMap = new Hashtable();
        public void Visit(PiecePart p)
        {
            pieceCount++;
            string partNumber = p.PartNumber;

            int partNumberCount = 0;
            if (pieceMap.ContainsKey(partNumber))
                partNumberCount = (int)pieceMap[partNumber];

            partNumberCount++;
            pieceMap[partNumber] = partNumberCount;
        }
        public void Visit(Assembly a)
        {
        }
        public int PieceCount
        {
            get { return pieceCount; }
        }
        public int PartNumberCount
        {
            get { return pieceMap.Count; }
        }
        public int GetCountForPart(string partNumber)
        {
            int partNumberCount = 0;
            if (pieceMap.ContainsKey(partNumber))
                partNumberCount = (int)pieceMap[partNumber];
            return partNumberCount;
        }
    }
}
