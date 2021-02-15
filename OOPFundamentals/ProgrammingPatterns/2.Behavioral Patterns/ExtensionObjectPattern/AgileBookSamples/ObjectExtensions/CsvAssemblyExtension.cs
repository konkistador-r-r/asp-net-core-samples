using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionObjectPattern.AgileBookSamples
{
    public class CsvAssemblyExtension : ICsvPartExtension
    {
        private Assembly assembly;
        public CsvAssemblyExtension(Assembly assy)
        {
            assembly = assy;
        }
        public string CsvText
        {
            get
            {
                StringBuilder b =
                new StringBuilder("Assembly,");
                b.Append(assembly.PartNumber);
                b.Append(",");
                b.Append(assembly.Description);
                foreach (Part part in assembly.Parts)
                {
                    ICsvPartExtension cpe = part.GetExtension("CSV") as ICsvPartExtension;
                    b.Append(",{");
                    b.Append(cpe.CsvText);
                    b.Append("}");
                }
                return b.ToString();
            }
        }
    }
}
