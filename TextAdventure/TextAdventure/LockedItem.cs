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

        public LockedItem(string name, string playerInventoryDesc, string roomInventoryDesc, string ID, bool small, bool locked) 
            : base(name, playerInventoryDesc, roomInventoryDesc, ID, small)
        {
            status = locked;
            
        }
    }
}
