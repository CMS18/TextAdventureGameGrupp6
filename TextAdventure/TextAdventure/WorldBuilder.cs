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

        public void CreateRooms()
        {
            Room startRoom = new Room();
            startRoom.roomDescription = "";
            //startRoom.roomInventory.Add(Item);


        }

        public void CreateItems()
        {
            throw new NotImplementedException();
        }

    }
}
