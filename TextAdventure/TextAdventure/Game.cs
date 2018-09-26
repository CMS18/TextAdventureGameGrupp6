using System;
using System.Collections.Generic;

namespace TextAdventure
{
    public class Game
    {
        public Dictionary<string, Item> itemCollection;
        public string[,] map = new string[3, 3];
        public Player player;
        public Dictionary<string, Room> roomCollection;
        public string[] userInput;
        public bool victory = false;
        public int xCoord = 1;
        public int yCoord = 1;

        public Game()
        {
            roomCollection = new Dictionary<string, Room>();
            player = new Player();
        }

        public void NewGame()
        {
            var wb = new WorldBuilder();
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
            Console.WriteLine(
                @"    ____     _____    _           _  _______    _         _   ___________   _      _   _____    _______ ");
            Console.WriteLine(
                @"  /      \  |  __  \  \\         // |  _____|  | |\\     | | |____   ____| | |    | | |   _ \\ |  _____|");
            Console.WriteLine(
                @" |   /\   | | |  \  \  \\       //  | |____    | | \\    | |      | |      | |    | | |  | ||| | |____  ");
            Console.WriteLine(
                @" |  |__|  | | |   | |   \\     //   |  ____|   | |  \\   | |      | |      | |    | | |   __// |  ____| ");
            Console.WriteLine(
                @" |        | | |   | |    \\   //    | |        | |   \\  | |      | |      | |    | | |  |\\   | |      ");
            Console.WriteLine(
                @" |        | | |__/ /      \\ //     | |______  | |    \\ | |      | |       \\    //  |  | \\  | |______");
            Console.WriteLine(
                @" |___||___| |_____/        \\/      |________| |_|     \\|_|      |_|        \\__//   |__|  \\ |________|");
            Console.WriteLine();
            Console.WriteLine(
                "                  WELCOME TO PORK. A SIMPLE TEXT ADVENTURE GAME MADE FOR SIMPLE PEOPLE.                   ");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("What is your epic gamertag?  ");
            player.playerName = Console.ReadLine();
            Console.WriteLine();
            player.currentLocation.Look();
            var stillPlaying = true;
            while (stillPlaying)
                CheckText();

            //break;
        }

        public void Win()
        {
            if (victory)
            {
                Console.WriteLine("Do you want to play again?");
                Console.Write("(YES/NO):");
                var input = Console.ReadLine().ToUpper();

                if (!input.Equals("YES"))
                {
                    if (input.Equals("NO"))
                        Environment.Exit(0);
                    else
                        Console.WriteLine("Please control your writing.");
                }

                NewGame();
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
                if (xCoord == 0 || xCoord == 2)
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
                if (yCoord == 0 || yCoord == 2)
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
                if (yCoord == 0 || yCoord == 2)
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
                if (xCoord == 0 || xCoord == 2)
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
            Console.WriteLine();

            if (userInput[0].Equals("GO") || userInput[0].Equals("G"))
            {
                if (userInput.Length > 1)
                {
                    if (userInput[1].Equals("NORTH") || userInput[1].Equals("WEST") || userInput[1].Equals("EAST") ||
                        userInput[1].Equals("SOUTH"))
                    {
                        Move(userInput[1]);
                    }
                    else
                    {
                        Console.WriteLine("You can't go there...");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Deciding where to go makes things much easier.");
                    Console.WriteLine();
                }
            }
            else if (userInput[0].Equals("USE") || userInput[0].Equals("U"))
            {
                if (userInput.Length > 1)
                {
                    if (player.playerInventory.ContainsKey(userInput[1]))
                    {
                        if (userInput.Length == 2)
                        {
                            player.Use(userInput[1]);
                        }
                        else if (userInput.Length == 3)
                        {
                            Console.WriteLine("Please be a little more precise... USE <ITEM> ON <ITEM>..");
                            Console.WriteLine();
                        }
                        else if (player.currentLocation.roomInventory.ContainsKey(userInput[3]) &&
                                 userInput[2].Equals("ON"))
                        {
                            player.UseOnRoomItem(userInput[1], userInput[3]);
                        }
                        else if (player.playerInventory.ContainsKey(userInput[3]) && userInput[2].Equals("ON"))
                        {
                            player.UseOnInvItem(userInput[1], userInput[3]);
                        }
                        else
                        {
                            Console.WriteLine("Do you speak the english language? USE <ITEM> ON <ITEM>!");
                            Console.WriteLine();
                        }
                    }

                    if (player.currentLocation.roomInventory.ContainsKey(userInput[1]))
                        player.UseSomethingInRoom(userInput[1]);
                }
                else
                {
                    Console.WriteLine("Using nothing seems kinda useless");
                    Console.WriteLine();
                }
            }
            else if (userInput[0].Equals("TAKE") || userInput[0].Equals("T"))
            {
                if (userInput.Length > 1)
                {
                    if (player.currentLocation.roomInventory.ContainsKey(userInput[1]))
                    {
                        player.PickItem(userInput[1]);
                    }
                    else
                    {
                        Console.WriteLine("What are you on about? " + userInput[1] + " doesn't even exist!");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("What do you want to pick up stupid???");
                    Console.WriteLine();
                }
            }
            else if (userInput[0].Equals("DROP") || userInput[0].Equals("D"))
            {
                if (userInput.Length > 1)
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
                else
                {
                    Console.WriteLine("Good on you " + player.playerName + " for not littering.");
                    Console.WriteLine();
                }
            }
            else if (userInput[0].Equals("INSPECT") || userInput[0].Equals("I"))
            {
                if (userInput.Length > 1)
                {
                    if (player.currentLocation.roomInventory.ContainsKey(userInput[1]))
                        player.currentLocation.InspectItem(userInput[1]);
                    else if (player.playerInventory.ContainsKey(userInput[1])) player.InspectItem(userInput[1]);
                }
                else
                {
                    Console.WriteLine("Inspect what? " + player.playerName + ", INSPECT WHAT?!");
                    Console.WriteLine();
                }
            }
            else if (userInput[0].Equals("LOOK") || userInput[0].Equals("L"))
            {
                player.currentLocation.Look();
            }
            else if (userInput[0].Equals("INVENTORY") || userInput[0].Equals("INV"))
            {
                player.ShowInventory();
            }
            else if (userInput[0].Equals("EXIT") || userInput[0].Equals("QUIT"))
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Stop speaking in words that I do not understand!");
                Console.WriteLine();
            }
        }
    }
}