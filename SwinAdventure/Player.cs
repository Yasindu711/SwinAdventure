using System;
using System.Text;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        public Inventory _Inventory;
        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
        {
            _Inventory = new Inventory();
        }

        public override string FullDesc
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"You are {Name}, {base.FullDesc}.");
                sb.AppendLine($"You are carrying:");
                sb.Append(_Inventory.ItemList);

                return sb.ToString();
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _Inventory;
            }
        }


        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }

            return Inventory.Fetch(id);
        }
    }
}




