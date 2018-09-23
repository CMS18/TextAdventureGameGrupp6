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
                if (item.Equals("POSTER"))
                {
                    Console.WriteLine("Behind the poster is a secret stash. A small lockbox is lying here.");
                    Console.WriteLine();
                    playerInventory.Add(item, currentLocation.roomInventory[item]);
                    currentLocation.roomInventory.Remove(item);
                    Item lockbox = new Item("LOCKBOX", "A small locked lockbox", "With the poster gone there's now a small lockbox standing in the hidden area the poster was covering.", "1200", true);
                    currentLocation.roomInventory.Add(lockbox.name, lockbox);
                }
                else
                {
                    playerInventory.Add(item, currentLocation.roomInventory[item]);
                    currentLocation.roomInventory.Remove(item);
                }
                
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
            
            else
            {
                Console.WriteLine("You crazy? What exactly are you going for here?");
                Console.WriteLine();
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
                    Console.WriteLine("You feel a lot better instantly. You're not you when you're hungry...");
                    Console.WriteLine("As you take your third bite you strike something hard within the candybar, a key has been added to your inventory.");
                    Console.WriteLine();
                    playerInventory.Remove(useItem.name);
                    Item key = new Item("KEY", "A key, wonder where it leads to?", "A small key lying on the floor", "1200", true);
                    playerInventory.Add(key.name, key);
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
                if (itemTwo.Equals("LOCKBOX"))
                {
                    Console.WriteLine("The lockbox is now open. Inside it lies a lockpick. You store it in your inventory.");
                    Console.WriteLine();
                    playerInventory.Remove(itemTwo);
                    Item openLB = new Item("LOCKBOX", "Opened lockbox, it's empty.", "Opened lockbox thrown on the floor.", true);
                    playerInventory.Add(openLB.name, openLB);
                    Item lockpick = new Item("LOCKPICK", "Used for opening locked things.", "A slim looking lockpick lying on the dusty floor.", "1230", true);
                    playerInventory.Add(lockpick.name, lockpick);
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
                else if (secondItem.name.Equals("CLINT"))
                {
                    Console.WriteLine("Did you like it? Clint asks as he slowly turns his head towards the TV again.");
                    Console.WriteLine();
                    playerInventory.Remove(itemOne);
                }
                else if (secondItem.name.Equals("CHUCK"))
                {
                    Console.WriteLine("I KNEW MY TOOTHBRUSH WAS HERE! Chuck shouts out, jumping gladly around the room.");
                    Console.WriteLine();
                    playerInventory.Remove(itemOne);
                }
                if (secondItem.name.Equals("GIRL"))
                {
                    Console.WriteLine("The scary girl accepts your gift..");
                    Console.WriteLine("Although she still looks freaking terrifying she atleast smells good now.");
                    Console.WriteLine();
                    playerInventory.Remove(itemOne);
                }
                if (secondItem.name.Equals("SKÅNING"))
                {
                    Console.WriteLine("Skåningen realizes slowly what's in your hand and strikes faster than a Cheetah, grabbing the container and stuffing everything in it up in his mouth.");
                    Console.WriteLine("SATAN VA SNUS! The skåning shouts as his teeth are completely covered with the dark powder.");
                    Console.WriteLine();
                    playerInventory.Remove(itemOne);
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
