using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionObjectPattern.AgileBookSamples
{
    public interface ICsvPartExtension : IPartExtension
    {
        string CsvText { get; }
    }
}
