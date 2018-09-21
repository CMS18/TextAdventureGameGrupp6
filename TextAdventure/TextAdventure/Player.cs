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
        //public Item description;

        public Player()
        {
            playerInventory = new Dictionary<string, Item>();
            currentLocation = new Room();
            //description = new Item();
        }

        public void DropItem(string item)
        {
            currentLocation.roomInventory.Add(item, playerInventory[item]);
            playerInventory.Remove(item);
        }

        public void PickItem(string item)
        {
            playerInventory.Add(item,currentLocation.roomInventory[item]);
            currentLocation.roomInventory.Remove(item);
        }

        public void ShowInventory()
        {
            int itemNr = 1;
            foreach (var item in playerInventory.Keys)
            {
                Console.WriteLine(itemNr + ". " + item);
                itemNr++;
            }
            Console.WriteLine();
        }

        public void InspectItem(string item)
        {
            Item tempItem = playerInventory[item];
            Console.WriteLine(tempItem.playerInventoryDesc);
        }
    }
}
