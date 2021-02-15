using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class PostalServicePackaging
    {
        /// <summary>
        /// Basic packing materials, which are used within packaging strategies.
        /// </summary>
        internal enum PackingMaterials
        {
            Box,
            BubbleWrap,
            DryIce,
            Envelope,
            Foam,
            LargeBox,
            Tape
        }

        /// <summary>
        /// Defines a basic package to be shipped.
        /// 
        /// Contains package content and packing materials used.
        /// </summary>
        internal class Package
        {
            internal string Content { get; set; }
            internal List<PackingMaterials> Packaging { get; set; } = new List<PackingMaterials>();

            internal Package(string content)
            {
                Content = content;
            }

            /// <summary>
            /// Outputs package Content and comma-delimited list of packing materials.
            /// </summary>
            /// <returns>Formatted string.</returns>
            public override string ToString()
            {
                return $"{Content} was packaged using {string.Join(", ", Packaging.ToArray())}.";
            }
        }

        /// <summary>
        /// Strategy interface used to pack all packages.
        /// </summary>
        internal interface IPackagingStrategy
        {
            void Pack(Package package);
        }

        /// <summary>
        /// Default packaging strategy.
        /// 
        /// Abstract class forces this class to be inherited.
        /// </summary>
        internal abstract class PackagingStrategy : IPackagingStrategy
        {
            public virtual void Pack(Package package)
            {
                package.Packaging.Add(PackingMaterials.Box);
                package.Packaging.Add(PackingMaterials.BubbleWrap);
                package.Packaging.Add(PackingMaterials.Tape);
            }
        }

        #region Conreate strategies
        /// <summary>
        /// Default packaging strategy.
        /// 
        /// Uses box, bubble wrap, and tape.
        /// </summary>
        internal class DefaultStrategy : PackagingStrategy { }

        /// <summary>
        /// Strategy for flat objects, such as letters.
        /// 
        /// Uses envelope.
        /// </summary>
        internal class FlatStrategy : PackagingStrategy
        {
            public override void Pack(Package package)
            {
                package.Packaging.Add(PackingMaterials.Envelope);
            }
        }

        /// <summary>
        /// Strategy for fragile objects, such as glassware.
        /// 
        /// Uses box, bubble wrap, foam, and tape.
        /// </summary>
        internal class FragileStrategy : PackagingStrategy
        {
            public override void Pack(Package package)
            {
                package.Packaging.Add(PackingMaterials.Box);
                package.Packaging.Add(PackingMaterials.BubbleWrap);
                package.Packaging.Add(PackingMaterials.Foam);
                package.Packaging.Add(PackingMaterials.Tape);
            }
        }

        /// <summary>
        /// Strategy for perishables, such as food.
        /// 
        /// Uses box, dry ice, foam, and tape.
        /// </summary>
        internal class PerishableStrategy : PackagingStrategy
        {
            public override void Pack(Package package)
            {
                package.Packaging.Add(PackingMaterials.Box);
                package.Packaging.Add(PackingMaterials.DryIce);
                package.Packaging.Add(PackingMaterials.Foam);
                package.Packaging.Add(PackingMaterials.Tape);
            }
        }

        /// <summary>
        /// Strategy for pliable objects, such as clothing.
        /// 
        /// Uses envelope and tape.
        /// </summary>
        internal class PliableStrategy : PackagingStrategy
        {
            public override void Pack(Package package)
            {
                package.Packaging.Add(PackingMaterials.Envelope);
                package.Packaging.Add(PackingMaterials.Tape);
            }
        }

        /// <summary>
        /// Strategy for oversized objects, such as furniture.
        /// 
        /// Uses large box, foam, and tape.
        /// </summary>
        internal class OversizedStrategy : PackagingStrategy
        {
            public override void Pack(Package package)
            {
                package.Packaging.Add(PackingMaterials.LargeBox);
                package.Packaging.Add(PackingMaterials.Foam);
                package.Packaging.Add(PackingMaterials.Tape);
            }
        }
        #endregion

        /// <summary>
        /// Client that routes all packages to the passed packaging strategy.
        /// </summary>
        internal class Packager
        {
            protected IPackagingStrategy Strategy;

            public Packager(IPackagingStrategy strategy)
            {
                Strategy = strategy;
            }

            /// <summary>
            /// Packs the passed Package, using the existing strategy.
            /// </summary>
            /// <param name="package"></param>
            public void Pack(Package package)
            {
                // Output the current strategy to the log.
                Console.WriteLine(Strategy.GetType().Name);

                // Pack the package using current strategy.
                Strategy.Pack(package);
            }

            /// <summary>
            /// Packs the passed Package, using the passed strategy.
            /// </summary>
            /// <param name="package">Package to pack.</param>
            /// <param name="strategy">Strategy to use.</param>
            public void Pack(Package package, IPackagingStrategy strategy)
            {
                // Assign to local strategy.
                Strategy = strategy;

                // Pass to default Pack method.
                Pack(package);
            }
        }

        public static void Test() {
            // The characteristics of a given object will determine what packing materials are necessary to safely ship it. 
            // the packaging required to send a letter will differ dramatically 
            // from the packaging necessary to send a watermelon or a saxophone.
            // These different forms of packaging up objects can be thought of as unique packaging strategies. 
            var bear = new Package("A teddy bear");
            var defaultPackager = new Packager(new DefaultStrategy());
            defaultPackager.Pack(bear);
            Console.WriteLine(bear.ToString());

            var monitor = new Package("A computer monitor");
            var packager = new Packager(new FragileStrategy());
            packager.Pack(monitor);
            Console.WriteLine(monitor.ToString());

            var fish = new Package("Some salmon filets");
            packager.Pack(fish, new PerishableStrategy());
            Console.WriteLine(fish.ToString());

            var massiveBear = new Package("A MASSIVE teddy bear");
            packager.Pack(massiveBear, new OversizedStrategy());
            Console.WriteLine(massiveBear.ToString());
        }
    }
}
