using System;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        private List<string> _identifiers;

        public IdentifiableObject(string[] idents)
        {
            _identifiers = new List<string>(idents);
            
        }


        public bool AreYou(string id)
        {
            return _identifiers.Contains(id.ToLower());
        }


        public string FirstId
        {
            get
            {
                if (_identifiers.Count() > 0)
                {
                    return _identifiers.First();
                }

                return "";
            }
        }


        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }
    }
}
