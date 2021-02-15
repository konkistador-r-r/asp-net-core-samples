using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern
{
    internal abstract class Show
    {
        public BroadcastSlot BroadcastSlot { get; set; }
        public string Name { get; set; }
        public string Network { get; set; }

        #region Abstract methods.
        // These methods must be overriden.
        public abstract void AssignBroadcastSlot();
        public abstract void FindNetwork();
        #endregion

        #region Default methods.
        // These methods can be left as their default implementations.
        public virtual void CastActors() => Console.WriteLine($"Casting actors for {Name}.");
        public virtual void ShootPilot() => Console.WriteLine($"Shooting pilot for {Name}.");
        public virtual void WriteScript() => Console.WriteLine($"Writing script for {Name}.");
        #endregion

        protected Show(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Broadcasts show according to assigned properties.
        /// 
        /// Acts as 'Template Method' in Template Method pattern.
        /// </summary>
        public void Broadcast()
        {
            WriteScript();
            FindNetwork();
            CastActors();
            ShootPilot();
            AssignBroadcastSlot();

            // Output broadcasting message.
            Console.WriteLine($"Broadcasting {this}.");
        }

        /// <summary>
        /// Get formatted string representation of Show.
        /// </summary>
        /// <returns>Formatted Show information.</returns>
        public override string ToString()
        {
            return $"'{Name}' on {Network} at {BroadcastSlot}";
        }
    }
}
