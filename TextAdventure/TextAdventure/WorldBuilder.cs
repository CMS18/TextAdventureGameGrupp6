using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    public class WorldBuilder
    {
        //North, west, east, south, middle.
        public Dictionary<string, Room> roomList;

        public WorldBuilder()
        {

        }

        public void CreateRooms()
        {
            Room startRoom = new Room();
            startRoom.roomDescription = "";
            //startRoom.roomInventory.Add(Item);

           
        }

        public void CreateItems()
        {
            Item item = new Item();
            item.name = "";
            item.playerInventoryDesc.Add(item.name, "");
            item.roomInvectoryDesc.Add(item.name, "");
        }

    }
}
