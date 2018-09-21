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

        }

        public Room(string name, string roomDescription, Dictionary<string,Item> roomInventory)
        {
            this.name = name;
            this.roomDescription = roomDescription;
            this.roomInventory = roomInventory;
        }

        public void Look()
        {
            throw new NotImplementedException();
        }

        public void InspectItem()
        {
            throw new NotImplementedException();
        }
        
    }
}
