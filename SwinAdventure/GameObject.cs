using System;
using System.Xml.Linq;

namespace SwinAdventure
{
	public abstract class GameObject : IdentifiableObject
	{
		private string _itemDesciption;
		private string _itemName;

		public GameObject(string[] ids, string name, string description) : base(ids)
		{
			_itemName = name;
			_itemDesciption = description;
        }

		public string Name
		{
			get
			{
				return _itemName;
			}
		}

        public string ShortDesc
        {
            get { return $"{_itemName} ({FirstId})"; }
        }

		public virtual string FullDesc
		{
			get {
					return _itemDesciption;
				}
		}
    }
}

