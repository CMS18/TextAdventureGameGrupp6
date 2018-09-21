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
            playerInventoryDesc = new Dictionary<string, string>();
            roomInvectoryDesc = new Dictionary<string, string>();
        }

        public void Use(string itemOne, string itemTwo)
        {
            throw new NotImplementedException();
        }
    }
}
