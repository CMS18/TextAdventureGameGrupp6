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
        public string playerName;
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
            if (currentLocation.roomInventory[item].pickUpAble)
            {
                playerInventory.Add(item, currentLocation.roomInventory[item]);
                currentLocation.roomInventory.Remove(item);
            }
            else
            {
                Console.WriteLine("Are you really trying to pick up a frickin " + item + "?");
                Console.WriteLine();
            }
            
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
            Console.WriteLine();
        }

        public void UseSomethingInRoom(string item)
        {
            Item useItem = currentLocation.roomInventory[item];
            if (useItem.name.Equals("DOOR") && "1337".Equals(useItem.ID))
            {
                Console.WriteLine("You made it! VICTORY IS YOURS!");
                Console.WriteLine();
                Console.ReadKey();
                Environment.Exit(0);

            }
        }

        public void Use(string item)
        {
            //If the item is usable, use it.
            Item useItem = playerInventory[item];
            if ("0002".Equals(useItem.ID))
            {
                if (useItem.name.Equals("CANDYBAR"))
                {
                    Console.WriteLine("You feel a lot better instantly. You're not you when you're hungry.");
                    Console.WriteLine();
                    playerInventory.Remove(useItem.name);
                }
                
            }
            else
            {
                Console.WriteLine("You crazy? What exactly are you going for here?");
                Console.WriteLine();
            }
            //throw new NotImplementedException();
        }

        public void UseOnInvItem(string itemOne, string itemTwo)
        {
            //Check if the second item is in the player inventory or if it's in the room/find where the items are located.
            Item firstItem = playerInventory[itemOne];
            Item secondItem = playerInventory[itemTwo];
            if (firstItem.ID.Equals(secondItem.ID))
            {
                //Add more items.
            }
            else
            {
                Console.WriteLine("You're not a wizard Harry, try using the item with something else.");
                Console.WriteLine();
            }
            //If the two items can be used together, use them.
            //throw new NotImplementedException();
        }

        public void UseOnRoomItem(string itemOne, string itemTwo)
        {
            //Check if the second item is in the player inventory or if it's in the room/find where the items are located.
            Item firstItem = playerInventory[itemOne];
            Item secondItem = currentLocation.roomInventory[itemTwo];
            if (firstItem.ID.Equals(secondItem.ID))
            {
                if (secondItem.name.Equals("DOOR"))
                {
                    Console.WriteLine("The door is now open.");
                    Console.WriteLine();
                    currentLocation.roomInventory.Remove(secondItem.name);
                    Item newDoor = new Item("DOOR", "", "The closed door is now open. Should I make a run for it?", "1337", false);
                    currentLocation.roomInventory.Add(newDoor.name, newDoor);
                    
                }
            }
            else
            {
                Console.WriteLine("You're not a wizard Harry, try using the item with something else.");
                Console.WriteLine();
            }
            //If the two items can be used together, use them.
            //throw new NotImplementedException();
        }
    }
}
