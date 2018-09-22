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
        public bool pickUpAble;

        public Item()
        {
        }

        public Item(string itemName, string playerInvDesc, string roomInvDesc, bool smallItem)
        {
            name = itemName;
            playerInventoryDesc = playerInvDesc;
            roomInventoryDesc = roomInvDesc;
            pickUpAble = smallItem;
        }

        public Item(string itemName, string playerInvDesc, string roomInvDesc, string itemID, bool smallItem)
        {
            name = itemName;
            playerInventoryDesc = playerInvDesc;
            roomInventoryDesc = roomInvDesc;
            ID = itemID;
            pickUpAble = smallItem;
        }
    }
}
