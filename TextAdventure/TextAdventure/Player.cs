using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    public class Player
    {
        public string playerName { get { return playerName; } set { playerName = value; } }
        public Dictionary<string, Item> playerInventory;
        public Room currentLocation;

        public Player()
        {

        }

        public void DropItem()
        {
            
            throw new NotImplementedException();
        }

        public void PickItem()
        {
            throw new NotImplementedException();
        }

        public void ShowInventory()
        {
            throw new NotImplementedException();
        }

        public void InspectItem()
        {
            throw new NotImplementedException();
        }
    }
}
