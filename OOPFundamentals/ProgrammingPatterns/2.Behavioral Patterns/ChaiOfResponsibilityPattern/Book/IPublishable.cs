using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaiOfResponsibilityPattern
{
    public interface IPublishable
    {
        string Author { get; set; }
        CoverType CoverType { get; }
        decimal PublicationCost { get; set; }
        void Publish();
        string Title { get; set; }
    }
}
