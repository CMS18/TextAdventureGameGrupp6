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
        public Dictionary<string, Room> roomCollection;
        public Dictionary<string, Item> itemCollection;

        public WorldBuilder()
        {

        }

        public void CreateRooms()
        {
            List<string> items = new List<string>();
            items.Add("CANDYBAR");
            items.Add("GAMEGUIDE");
            CreateRoom( "START", "You are standing in a hallway. Surrounded by doorways all leading to different rooms.", items );

            /*Room westRoom = new Room();
            startRoom.roomDescription = "";
            startRoom.roomInventory.Add("", itemCollection[""]);
            startRoom.roomInventory.Add("", itemCollection[""]);
            roomCollection.Add("WEST", westRoom);

            Room eastRoom = new Room();
            startRoom.roomDescription = "";
            startRoom.roomInventory.Add("", itemCollection[""]);
            startRoom.roomInventory.Add("", itemCollection[""]);
            roomCollection.Add("EAST", eastRoom);

            Room southRoom = new Room();
            startRoom.roomDescription = "";
            startRoom.roomInventory.Add("", itemCollection[""]);
            startRoom.roomInventory.Add("", itemCollection[""]);
            roomCollection.Add("SOUTH", southRoom);*/


        }

        public void CreateRoom(string name, string roomDesc, List<string> items)
        {
            Room room = new Room();
            room.roomDescription = "";
            roomCollection.Add(name, room);
        }

        public void CreateItems()
        {
            Item item = new Item();
            item.name = "";
            item.playerInventoryDesc.Add(item.name, "");
            item.roomInvectoryDesc.Add(item.name, "");
            itemCollection.Add(item.name, item);

            item = new Item();
            item.name = "";
            item.playerInventoryDesc.Add(item.name, "");
            item.roomInvectoryDesc.Add(item.name, "");
            itemCollection.Add(item.name, item);

            item = new Item();
            item.name = "";
            item.playerInventoryDesc.Add(item.name, "");
            item.roomInvectoryDesc.Add(item.name, "");
            itemCollection.Add(item.name, item);

            item = new Item();
            item.name = "";
            item.playerInventoryDesc.Add(item.name, "");
            item.roomInvectoryDesc.Add(item.name, "");
            itemCollection.Add(item.name, item);

            item = new Item();
            item.name = "";
            item.playerInventoryDesc.Add(item.name, "");
            item.roomInvectoryDesc.Add(item.name, "");
            itemCollection.Add(item.name, item);

        }

        public void CreateItem()
        {

        }

    }
}
