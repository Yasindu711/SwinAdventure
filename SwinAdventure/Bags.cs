using System;
using System.Text;



namespace SwinAdventure
{
    public class Bag : Item, IHaveInventory
    {
        private Inventory _inventory;

        public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
        }

        public override string FullDesc
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"In the {Name} you can see:");
                sb.Append(_inventory.ItemList);

                return sb.ToString().TrimEnd();
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }

            return _inventory.Fetch(id);
        }
    }
}

