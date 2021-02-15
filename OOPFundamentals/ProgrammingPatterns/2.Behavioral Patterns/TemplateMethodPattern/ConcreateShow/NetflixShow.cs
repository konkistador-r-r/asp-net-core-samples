using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern
{
    internal class NetflixShow : Show
    {
        public override void AssignBroadcastSlot()
        {
            // Assign a default BroadcastSlot, 
            // which ensures the show is always available.
            BroadcastSlot = new BroadcastSlot();
            Console.WriteLine($"{Name} is a {BroadcastSlot.Type} broadcast.");
        }

        public override void FindNetwork()
        {
            Network = "Netflix";
            Console.WriteLine($"Network ({Network}) found for {Name}.");
        }

        /// <summary>
        /// Create new Netflix show.
        /// </summary>
        /// <param name="name">Name of show.</param>
        public NetflixShow(string name) : base(name)
        {
        }
    }
}
