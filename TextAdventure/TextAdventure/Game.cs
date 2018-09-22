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
        public Dictionary<string, Item> itemCollection;
        //public TextHandler th = new TextHandler();
        public string[,] map = new string[3, 3];
        public string[] userInput;
        public int xCoord = 1;
        public int yCoord = 1;

        public Game()
        {
            roomCollection = new Dictionary<string, Room>();
            player = new Player();
        }

        public void NewGame()
        {
            WorldBuilder wb = new WorldBuilder();
            itemCollection = wb.CreateItems();
            roomCollection = wb.CreateRooms();
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
            Console.WriteLine();
            Console.WriteLine("Welcome to Pork. A simple text adventure game made for simple people.");
            Console.WriteLine();
            player.currentLocation.Look();
            bool stillPlaying = true;
            while (stillPlaying)
            {

                
                CheckText();

                //break;
            }
        }

        public void Move(string direction)
        {
            
            if (map[yCoord, xCoord].Equals(direction))
            {
                Console.WriteLine("You can't go in the " + direction + " direction.");
                Console.WriteLine();
            }       
            else if (direction.Equals("NORTH"))
            {
                if(xCoord == 0 || xCoord == 2)
                {
                    Console.WriteLine("You can't go in the " + direction + " direction.");
                    Console.WriteLine();
                }
                else
                {
                    yCoord--;
                    player.currentLocation = roomCollection[map[yCoord, xCoord]];
                    player.currentLocation.Look();
                }
               
            }
            else if (direction.Equals("WEST"))
            {
                if(yCoord == 0 || yCoord == 2)
                {
                    Console.WriteLine("You can't go in the " + direction + " direction.");
                    Console.WriteLine();
                }
                else
                {
                    xCoord--;
                    player.currentLocation = roomCollection[map[yCoord, xCoord]];
                    player.currentLocation.Look();
                }
            }
            else if (direction.Equals("EAST"))
            {
                if(yCoord == 0 || yCoord == 2)
                {
                    Console.WriteLine("You can't go in the " + direction + " direction.");
                    Console.WriteLine();
                }
                else
                {
                    xCoord++;
                    player.currentLocation = roomCollection[map[yCoord, xCoord]];
                    player.currentLocation.Look();
                }
            }
            else
            {
                if(xCoord == 0 || xCoord == 2)
                {
                    Console.WriteLine("You can't go in the " + direction + " direction.");
                    Console.WriteLine();
                }
                else
                {
                    yCoord++;
                    player.currentLocation = roomCollection[map[yCoord, xCoord]];
                    player.currentLocation.Look();
                }
            }
                
                
                
        }

        public void CheckText()
        {
            userInput = Console.ReadLine().ToUpper().Split(' ');

            if (userInput[0].Equals("GO") || userInput[0].Equals("G"))
            {
                if (userInput[1].Equals("NORTH") || userInput[1].Equals("WEST") || userInput[1].Equals("EAST") || userInput[1].Equals("SOUTH"))
                {
                    Move(userInput[1]);
                }
                else
                {
                    Console.WriteLine("You can't go there...");
                    Console.WriteLine();
                }

            }
            else if (userInput[0].Equals("USE") || userInput[0].Equals("U"))
            {
                //Use(userInput[1], userInput[3]);
            }
            else if (userInput[0].Equals("TAKE") || userInput[0].Equals("T"))
            {
                if (player.currentLocation.roomInventory.ContainsKey(userInput[1]))
                {
                    player.PickItem(userInput[1]);
                }
                else
                {
                    Console.WriteLine("What are you on about?" + userInput[1] + " doesn't even exist!");
                    Console.WriteLine();
                }

            }
            else if (userInput[0].Equals("DROP") || userInput[0].Equals("D"))
            {
                if (player.playerInventory.ContainsKey(userInput[1]))
                {
                    player.DropItem(userInput[1]);
                }
                else
                {
                    Console.WriteLine("Are you high? " + userInput[1] + " doesn't exist in your inventory!?");
                    Console.WriteLine();
                }
                
            }
            else if (userInput[0].Equals("INSPECT") || userInput[0].Equals("I"))
            {
                if (player.currentLocation.roomInventory.ContainsKey(userInput[1]))
                {
                    player.currentLocation.InspectItem(userInput[1]);
                }
                else if (player.playerInventory.ContainsKey(userInput[1]))
                {
                    player.InspectItem(userInput[1]);
                }
            }
            else if (userInput[0].Equals("LOOK") || userInput[0].Equals("L"))
            {
                player.currentLocation.Look();
            }
            else if(userInput[0].Equals("INVENTORY") || userInput[0].Equals("INV"))
            {
                player.ShowInventory();
            }
            else
            {
                Console.WriteLine("Stop speaking in words that I do not understand!");
                Console.WriteLine();
            }
        }
    }
}
