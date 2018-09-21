using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    public class Item
    {
        public string name;
        public Dictionary<string, string> playerInventoryDesc;
        public Dictionary<string, string> roomInvectoryDesc;

        public Item()
        {

        }

        public void Use()
        {
            throw new NotImplementedException();
        }

        public void Inspect()
        {
            throw new NotImplementedException();
        }

    }
}
