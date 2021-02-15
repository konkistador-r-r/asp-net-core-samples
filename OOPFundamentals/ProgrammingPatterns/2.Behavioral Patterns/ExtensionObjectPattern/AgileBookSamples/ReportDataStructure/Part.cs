using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ExtensionObjectPattern.AgileBookSamples
{
    public abstract class Part
    {
        Hashtable extensions = new Hashtable();
        public abstract string PartNumber { get; }
        public abstract string Description { get; }
        public void AddExtension(string extensionType, IPartExtension extension)
        {
            extensions[extensionType] = extension;
        }
        public IPartExtension GetExtension(string extensionType)
        {
            IPartExtension pe = extensions[extensionType] as IPartExtension;
            if (pe == null)
                pe = new BadPartExtension();
            return pe;
        }
    }
}
