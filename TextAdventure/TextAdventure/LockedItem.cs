using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class LockedItem : Item
    {
        public bool status;
        public bool pickupAble;

        public LockedItem(string name, string playerInventoryDesc, string roomInventoryDesc, string ID, bool locked, bool small) 
            : base(name, playerInventoryDesc, roomInventoryDesc, ID)
        {
            status = locked;
            pickupAble = small;
        }
    }
}
