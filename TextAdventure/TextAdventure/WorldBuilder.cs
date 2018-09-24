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
            CreateRoom("START", "You are standing in a room. In each cardinal direction there is a door. " +
                                "By the looks of it, none of the doors are locked..", items);

            items.Clear();
            items.Add("GIRL");
            items.Add("DOOR");
            CreateRoom("NORTH", "You entered the northern room. SHIT, that nasty girl from the Grudge is here. Her " +
                                "black eyes are staring right through your soul.. ", items);

            items.Clear();
            items.Add("SKÅNING");
            items.Add("DEODORANT");
            CreateRoom("SOUTH", "You entered the southern room, There's some Crazy swedish skåning here. Can't " +
                                "understand a word he's saying..",items);

            items.Clear();
            items.Add("CLINT");
            items.Add("TOOTHBRUSH");
            items.Add("POSTER");
            CreateRoom("WEST", "You entered the western room. Clint Eastwood has gone mental and is " +
                               "lying in bed watching Teletubbies. ", items);

            items.Clear();
            items.Add("CHUCK");
            items.Add("CONTAINER");
            items.Add("RAT");
            CreateRoom("EAST", "You entered the eastern room. Is that??!! Oh shit, Chuck Norris is here, " +
                                "trying to build a rocket with a chewing gum and a pencil. Classic Chuck. ", items);

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
            CreateItem("CANDYBAR", "It looks tasty.", "There's a candybar lying all alone on the floor. ", "0002", true);
            CreateItem("GAMEGUIDE", "Valid commands are: \r\nGo <direction>,\r\nUse <item>, Use <item> on <item>,\r\nTake <item>,\r\nDrop <item>," +
                "\r\nInspect <item> \r\nand Look.", 
                "An old and dusty gameguide for some game long forgotten is lying here. ", "08", true);
            CreateItem("GIRL", "", "She is standing completely still in the right corner. You can hear her singing something..\r\n", "930", false);
            CreateItem("DEODORANT", "If you smell shit, use it.", "A deodorant is lying just beneath your feet. ", "930", true);
            CreateItem("SKÅNING", "", "As crazy as they come, this Skåning is batshit crazy. I wonder why?\r\n", "8008", false);
            CreateItem("TOOTHBRUSH", "A used toothbrush, barely any straws are left on it.", "Old and used toothbrush. ", "1001", true);
            CreateItem("CLINT", "", "Clint gives you a quick stare before turning his head back to the TV.\r\n", "1009" , false);
            CreateItem("POSTER", "A movie poster, Clint Eastwood is the star of the movie.", "A poster hanging on the left side of the room. The good, the bad and the uglys movie cover is printed on it. ", "1000", true);
            CreateItem("CONTAINER", "A container with a text Prima Fint Snus.", "A round container with some text written on it. It's lying upside down. ", "8008", true);
            CreateItem("RAT", "", "A disgusting albino rat with human eyes is dashing around the room. ", "05", false);
            CreateItem("CHUCK", "", "You suddenly feel alot better knowing that Chuck is here to save the day. But what is he doing here?\r\n", "1001" , false);
            CreateItem("DOOR", "", "There's a sturdy looking door here, it seems locked. I can hear birds chirping on the other side of it. ", "1230", false);
            return itemCollection;
            
        }

        public void CreateLockedItem(string name, string invDesc, string roomInvDesc, string ID, bool locked, bool small)
        {
            LockedItem item = new LockedItem(name, invDesc, roomInvDesc, ID, locked, small);
            itemCollection.Add(item.name, item);
        }

        public void CreateItem(string name, string invDesc, string roomInvDesc, string ID, bool small)
        {
            Item item = new Item(name, invDesc, roomInvDesc, ID, small);
            itemCollection.Add(item.name, item);
        }
        
        public void CreateItem(string name, string invDesc, string roomInvDesc, bool small)
        {
            Item item = new Item(name, invDesc, roomInvDesc, small);
            itemCollection.Add(item.name, item);
        }

    }
}
