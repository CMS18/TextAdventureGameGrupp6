using System;
using System.Collections.Generic;

namespace TextAdventure
{
    public class Room
    {
        public string name;
        public string roomDescription;
        public Dictionary<string, Item> roomInventory;

        public Room()
        {
            roomInventory = new Dictionary<string, Item>();
        }

        public Room(string name, string roomDescription, Dictionary<string, Item> roomInventory)
        {
            this.name = name;
            this.roomDescription = roomDescription;
            this.roomInventory = roomInventory;
        }

        public void Look()
        {
            Console.WriteLine(roomDescription);
            var keys = new List<string>(roomInventory.Keys);


            for (var i = 0; i < roomInventory.Count; i++)
            {
                var tempItem = roomInventory[keys[i]];
                Console.Write(tempItem.roomInventoryDesc);
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public void InspectItem(string itemToInsp)
        {
            var tempItem = roomInventory[itemToInsp];
            Console.WriteLine(tempItem.roomInventoryDesc);
            Console.WriteLine();
        }
    }
}