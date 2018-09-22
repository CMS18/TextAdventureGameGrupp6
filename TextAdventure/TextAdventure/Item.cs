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
            //If the item is usable, use it.
            throw new NotImplementedException();
        }

        public void Use(string itemOne, string itemTwo)
        {
            //Check if the second item is in the player inventory or if it's in the room/find where the items are located.
            //If the two items can be used together, use them.
            throw new NotImplementedException();
        }
    }
}
