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
        public string playerInventoryDesc;
        public string roomInventoryDesc;
        public string ID;

        public Item()
        {
            
        }

        public Item(string itemName, string playerInvDesc, string roomInvDesc, string itemID)
        {
            name = itemName;
            playerInventoryDesc = playerInvDesc;
            roomInventoryDesc = roomInvDesc;
            ID = itemID;
        }

        public void Use(string item)
        {
            throw new NotImplementedException();
        }

        public void Use(string itemOne, string itemTwo)
        {
            throw new NotImplementedException();
        }
    }
}
