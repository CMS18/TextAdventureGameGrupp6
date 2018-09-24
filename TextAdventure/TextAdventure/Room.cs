using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Room(string name, string roomDescription, Dictionary<string,Item> roomInventory)
        {
            this.name = name;
            this.roomDescription = roomDescription;
            this.roomInventory = roomInventory;
        }

        public void Look()
        {
            Console.WriteLine(roomDescription);
            List<string> keys = new List<string>(roomInventory.Keys);
            //int words = 0;
            
            for (int i = 0; i < roomInventory.Count; i++)
            {
                /*
                if(words == 2)
                {
                    Console.Write("\r\n");
                }
                */
                Item tempItem = roomInventory[keys[i]];
                Console.Write(tempItem.roomInventoryDesc);
                //words++;
            }
            
            Console.WriteLine();
            Console.WriteLine();

        }

        public void InspectItem(string itemToInsp)
        {
            Item tempItem = roomInventory[itemToInsp];
            Console.WriteLine(tempItem.roomInventoryDesc);
            Console.WriteLine();
        }
        
    }
}
