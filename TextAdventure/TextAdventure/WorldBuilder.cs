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
            items.Add("KEY");
            items.Add("SWORD");
            CreateRoom("NORTH", "You entered the northern room. SHIT, that nasty girl from the Grudge is here. Her" +
                                "black eyes are staring right through your soul.. ", items);

            items.Clear();
            items.Add("DAGGER");
            items.Add("DEODORANT");
            CreateRoom("SOUTH", "You entered the southern room, There's some Crazy swedish skåning here. Can't" +
                                "understand a word he's saying..",items);

            items.Clear();
            items.Add("TOOTHBRUSH");
            items.Add("ORANGEJUICE");
            CreateRoom("WEST", "You entered the western room. Clint Eastwood has gone mental and is " +
                               "lying in bed watching Teletubbies. ", items);

            items.Clear();
            items.Add("CONTAINER");
            items.Add("RAT");
            CreateRoom("EAST", "You entered the eastern room. Is that??!! Oh shit, Chuck Norris is here, " +
                                "trying to build a rocket with a chewing gum and a pencil. Classic Chuck. ", items);

            items.Clear();
            items.Add("");
            items.Add("");
            CreateRoom("EXIT", "Room DESC", items);

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
            CreateItem("GAMEGUIDE", "Valid commands are Go, Use, Take, Drop, Inspect and Look.", 
                "An old and dusty guide for some game long forgotten is lying here.");
            CreateItem("KEY", "A golden key", "A small golden object is radiating in the dark.");
            CreateItem("SWORD", "Sharp sword.", "A sword is stuck on the ground.");
            CreateItem("DAGGER", "A rusty old dagger", "There's a rusty old dagger lying here");
            CreateItem("DEODORANT", "If you smell shit, use it", "A deodorant is lying just beneath your feet");
            CreateItem("TOOTHBRUSH", "A used toothbrush, barely any straws are left on it.", "Old and used toothbrush.");
            CreateItem("GLASS", "Some kind of bewerage with orange color.", "Glass containing some kind of bewerage.");
            CreateItem("LÖSSNUSS", "A container with a text Prima Fint", "A round box of some sort");
            CreateItem("RAT", "Oh shit, it was dead", "A disgusting albino rat with human eyes");
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
