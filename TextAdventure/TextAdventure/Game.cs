using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    public class Game
    {
        public Player player;
        public Dictionary<string, Room> roomCollection;
        public TextHandler th = new TextHandler();

        public Game()
        {

        }

        public void NewGame()
        {
            WorldBuilder wb = new WorldBuilder();
            wb.CreateItems();
            wb.CreateRooms();
        }

        public void PlayingGame()
        {
            NewGame();
            player.currentLocation = roomCollection["START"];
            Console.WriteLine("Welcome to Pork. A simple text adventure game made for simple people.");
            bool stillPlaying = true;
            while (stillPlaying)
            {
                player.currentLocation.Look();
                th.CheckText();
            
                break;
            }
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

    }
}
