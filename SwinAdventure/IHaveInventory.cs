using System;

namespace SwinAdventure
{
    public interface IHaveInventory
    {
        GameObject Locate(string id);

        public string Name { get; }
    }
}

