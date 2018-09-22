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
            roomCollection = new Dictionary<string, Room>();
            itemCollection = new Dictionary<string, Item>();
        }

        public Dictionary<string, Room> CreateRooms()
        {
            List<string> items = new List<string>();
            items.Add("CANDYBAR");
            items.Add("GAMEGUIDE");
            CreateRoom("START", "You are standing in a hallway. Surrounded by doorways all leading to different rooms.", items);

            items.Clear();
            items.Add("KEY");
            items.Add("SWORD");
            CreateRoom("NORTH", "To the north of the house, around the room you see a table and a door.", items);

            return roomCollection;

        }

        public void CreateRoom(string name, string roomDesc, List<string> items)
        {
            Room room = new Room();
            room.roomDescription = roomDesc;
            for (int i = 0; i < items.Count; i++)
            {
                room.roomInventory.Add(items[i], itemCollection[items[i]]);
            }
            roomCollection.Add(name, room);
        }

        public Dictionary<string, Item> CreateItems()
        {
            CreateItem("CANDYBAR", "It looks tasty.", "There's a candybar lying all alone on the floor.");
            CreateItem("GAMEGUIDE", "Valid commands are Go, Use, Take, Drop, Inspect and Look.", "An old and dusty guide for some game long forgotten is lying here.");
            CreateItem("KEY", "A golden key", "A small golden object is radiating in the dark.");
            CreateItem("SWORD", "Sharp sword.", "A sword is stuck on the ground.");

            return itemCollection;
            
        }

        public void CreateLockedItem(string name, string invDesc, string roomInvDesc, string ID, bool locked, bool small)
        {
            LockedItem item = new LockedItem(name, invDesc, roomInvDesc, ID, locked, small);
            itemCollection.Add(item.name, item);
        }

        public void CreateItem(string name, string invDesc, string roomInvDesc)
        {
            Item item = new Item();
            item.name = name;
            item.playerInventoryDesc = invDesc;
            item.roomInventoryDesc = roomInvDesc;
            itemCollection.Add(item.name, item);
        }

    }
}
