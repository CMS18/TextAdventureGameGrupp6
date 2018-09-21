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
        public string[,] map = new string[3, 3];
        public int xCoord = 1;
        public int yCoord = 1;

        public Game()
        {

        }

        public void NewGame()
        {
            WorldBuilder wb = new WorldBuilder();
            wb.CreateItems();
            wb.CreateRooms();
            CreateMap();
        }

        public void CreateMap()
        {
            map[0, 1] = "NORTH";
            map[1, 1] = "START";
            map[1, 0] = "WEST";
            map[1, 2] = "EAST";
            map[2, 1] = "SOUTH";
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

        public void Move(string direction)
        {
            
            if (map[yCoord, xCoord].Equals(direction))
            {
                Console.WriteLine("You can't go in the " + direction + " direction.");
            }       
            else if (direction.Equals("NORTH"))
            {
                if(xCoord == 0 || xCoord == 2)
                {
                    Console.WriteLine("You can't go in the " + direction + " direction.");
                }
                else
                {
                    yCoord--;
                }
               
            }
            else if (direction.Equals("WEST"))
            {
                if(yCoord == 0 || yCoord == 2)
                {
                    Console.WriteLine("You can't go in the " + direction + " direction.");
                }
                else
                {
                    xCoord--;
                }
            }
            else if (direction.Equals("EAST"))
            {
                if(yCoord == 0 || yCoord == 2)
                {
                    Console.WriteLine("You can't go in the " + direction + " direction.");
                }
                else
                {
                    xCoord++;
                }
            }
            else
            {
                if(xCoord == 0 || xCoord == 2)
                {
                    Console.WriteLine("You can't go in the " + direction + " direction.");
                }
                else
                {
                    yCoord++;
                }
            }
                
                
                
        }

    }
}
