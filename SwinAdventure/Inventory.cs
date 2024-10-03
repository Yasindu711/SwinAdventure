using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }


        public string ItemList
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                foreach(Item it in _items)
                {
                    sb.AppendLine($"\t{it.ShortDesc}");
                }

                return sb.ToString();
            }
        }

        public bool HasItem(string id)
        {
            return _items.Exists(i => i.AreYou(id));
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item Take(string id)
        {
            Item item = _items.Find(i => i.AreYou(id));
            _items.Remove(item);
            return item;

        }

        public Item Fetch(string id)
        {
            return _items.Find(i => i.AreYou(id));
        }
    }
}


