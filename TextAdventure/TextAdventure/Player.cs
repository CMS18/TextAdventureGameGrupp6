using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public void DropItem(string item)
        {
            currentLocation.roomInventory.Add(item, playerInventory[item]);
            playerInventory.Remove(item);
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
