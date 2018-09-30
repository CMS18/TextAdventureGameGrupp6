using System;
using System.Collections.Generic;
using System.Speech.Synthesis;

namespace TextAdventure
{
    public class Player
    {
        public Room currentLocation;
        public Dictionary<string, Item> playerInventory;
        public string playerName;

        public Player()
        {
            playerInventory = new Dictionary<string, Item>();
            currentLocation = new Room();
        }

        public void DropItem(string item)
        {
            currentLocation.roomInventory.Add(item, playerInventory[item]);
            playerInventory.Remove(item);
        }

        public void PickItem(string item)
        {
            if (currentLocation.roomInventory[item].pickUpAble)
            {
                if (item.Equals("POSTER") && currentLocation.roomInventory[item].ID.Equals("1000"))
                {
                    Console.WriteLine("Behind the poster is a secret stash. A small lockbox is lying here.");
                    Console.WriteLine();
                    var poster = new Item("POSTER", "A movie poster, Clint Eastwood is the star of the movie.",
                        "A poster hanging on the left side of the room. The good, the bad and the uglys movie cover is printed on it. ",
                        "1009", true);
                    currentLocation.roomInventory.Remove(item);
                    playerInventory.Add(poster.name, poster);
                    currentLocation.roomInventory.Remove(item);
                    var lockbox = new Item("LOCKBOX", "A small locked lockbox",
                        "With the poster gone there's now a small lockbox standing in the hidden area the poster was covering.",
                        "1200", true);
                    currentLocation.roomInventory.Add(lockbox.name, lockbox);
                }
                else
                {
                    playerInventory.Add(item, currentLocation.roomInventory[item]);
                    currentLocation.roomInventory.Remove(item);
                }
            }
            else
            {
                Console.WriteLine("Are you really trying to pick up a frickin " + item + "?");
                Console.WriteLine();
            }
        }

        public void ShowInventory()
        {
            var itemNr = 1;
            foreach (var item in playerInventory.Keys)
            {
                Console.WriteLine(itemNr + ". " + item);
                itemNr++;
            }

            Console.WriteLine();
        }

        public void InspectItem(string item)
        {
            var tempItem = playerInventory[item];
            Console.WriteLine(tempItem.playerInventoryDesc);
            Console.WriteLine();
        }

        public void UseSomethingInRoom(string item)
        {
            var useItem = currentLocation.roomInventory[item];
            if (useItem.name.Equals("DOOR") && "1337".Equals(useItem.ID))
            {
                Console.WriteLine(@"      ___________                                   ");
                Console.WriteLine(@"     | ___ |     |                                  ");
                Console.WriteLine(@"     ||___||  0 /|                                  ");
                Console.WriteLine(@"     | ___*|--|/ |                                  ");
                Console.WriteLine(@"     ||___||  |  |                                  ");
                Console.WriteLine(@"     |_____|_/_\_|                                  ");
                SpeechSynthesizer voice = new SpeechSynthesizer();
                voice.SetOutputToDefaultAudioDevice();
                voice.Speak("As you open the door and step outside you realize that you actually made it through that nightmarish house.");
                voice.Speak("VICTORY IS YOURS!");

                Console.WriteLine(@"                  Made by: Gabriel, Max and Robert.T");
                Console.WriteLine("                                                     ");
                Console.WriteLine("      ******You made it! VICTORY IS YOURS!******     ");
                Console.WriteLine();
                Console.ReadKey();
                Environment.Exit(0);
            }

            else
            {
                Console.WriteLine("You crazy? What exactly are you going for here?");
                Console.WriteLine();
            }
        }

        public void Use(string item)
        {
            var useItem = playerInventory[item];
            if ("0002".Equals(useItem.ID))
            {
                if (useItem.name.Equals("CANDYBAR"))
                {
                    Console.WriteLine("You feel a lot better instantly. You're not you when you're hungry...");
                    Console.WriteLine(
                        "As you take your third bite you strike something hard within the candybar.. WTF! WHO PUT A KEY IN THE CANDYBAR" +
                        " **KEY ADDED TO INVENTORY**");
                    Console.WriteLine();
                    playerInventory.Remove(useItem.name);
                    var key = new Item("KEY", "A key, wonder where it leads to?", "A small key lying on the floor ",
                        "1200", true);
                    playerInventory.Add(key.name, key);
                }
            }
            else
            {
                Console.WriteLine("You crazy? What exactly are you going for here?");
                Console.WriteLine();
            }
        }

        public void UseOnInvItem(string itemOne, string itemTwo)
        {
            var firstItem = playerInventory[itemOne];
            var secondItem = playerInventory[itemTwo];
            if (firstItem.ID.Equals(secondItem.ID))
            {
                if (itemTwo.Equals("LOCKBOX"))
                {
                    Console.WriteLine(
                        "The lockbox is now open. Inside it lies a lockpick. **LOCKPICK ADDED TO INVENTORY**");
                    Console.WriteLine();
                    playerInventory.Remove(itemTwo);
                    var openLB = new Item("LOCKBOX", "Opened lockbox, it's empty.",
                        "Opened lockbox thrown on the floor. ", "051", true);
                    playerInventory.Add(openLB.name, openLB);
                    var lockpick = new Item("LOCKPICK", "Used for opening locked things.",
                        "A slim looking lockpick lying on the dusty floor. ", "1230", true);
                    playerInventory.Add(lockpick.name, lockpick);
                }
            }
            else
            {
                Console.WriteLine("You're not a wizard Harry, try using the item with something else.");
                Console.WriteLine();
            }
        }

        public void UseOnRoomItem(string itemOne, string itemTwo)
        {
            var firstItem = playerInventory[itemOne];
            var secondItem = currentLocation.roomInventory[itemTwo];
            if (firstItem.ID.Equals(secondItem.ID))
            {
                if (secondItem.name.Equals("DOOR"))
                {
                    Console.WriteLine("The door is now open.");
                    Console.WriteLine();
                    currentLocation.roomInventory.Remove(secondItem.name);
                    var newDoor = new Item("DOOR", "", "The closed door is now open. Should I make a run for it? ",
                        "1337", false);
                    currentLocation.roomInventory.Add(newDoor.name, newDoor);
                }
                else if (itemTwo.Equals("LOCKBOX"))
                {
                    Console.WriteLine(
                        "The lockbox is now open. Inside it lies a lockpick. You store it in your inventory.");
                    Console.WriteLine();
                    playerInventory.Remove(itemTwo);
                    var openLB = new Item("LOCKBOX", "Opened lockbox, it's empty.",
                        "Opened lockbox thrown on the floor. ", "051", true);
                    playerInventory.Add(openLB.name, openLB);
                    var lockpick = new Item("LOCKPICK", "Used for opening locked things.",
                        "A slim looking lockpick lying on the dusty floor. ", "1230", true);
                    playerInventory.Add(lockpick.name, lockpick);
                }
                else if (secondItem.name.Equals("CLINT"))
                {
                    Console.WriteLine("Did you like it? Clint asks as he slowly turns his head towards the TV again.");
                    SpeechSynthesizer voice = new SpeechSynthesizer();
                    voice.SetOutputToDefaultAudioDevice();
                    voice.Speak("Did you like it?");
                    Console.WriteLine();
                    playerInventory.Remove(itemOne);
                }
                else if (secondItem.name.Equals("CHUCK"))
                {
                    Console.WriteLine(
                        "I KNEW MY TOOTHBRUSH WAS HERE! Chuck shouts out, jumping gladly around the room.");
                    SpeechSynthesizer voice = new SpeechSynthesizer();
                    voice.SetOutputToDefaultAudioDevice();
                    voice.Speak("I KNEW MY TOOTHBRUSH WAS HERE!");
                    Console.WriteLine();
                    playerInventory.Remove(itemOne);
                }

                if (secondItem.name.Equals("GIRL"))
                {
                    Console.WriteLine("The scary girl accepts your gift..");
                    Console.WriteLine(
                        "That's better! Didn't want to insult her, but she smelled like old cheese.. Still look scary as hell though.");

                    Console.WriteLine();
                    playerInventory.Remove(itemOne);
                }

                if (secondItem.name.Equals("SKÅNING"))
                {
                    Console.WriteLine(
                        "Skåningen realizes slowly what's in your hand and strikes faster than a Cheetah, grabbing the container and stuffing everything in it up his mouth.");
                    Console.WriteLine(
                        "Bedst at udstå, hvad man ikke kan undgå, ålahue! The skåning shouts as his teeth are completely covered with the dark powder.");
                    SpeechSynthesizer voice = new SpeechSynthesizer();
                    voice.SetOutputToDefaultAudioDevice();
                    voice.Speak("Bedst at udstå, hvad man ikke kan undgå, ålahue!");
                    Console.WriteLine();
                    playerInventory.Remove(itemOne);
                }
            }
            else
            {
                Console.WriteLine("You're not a wizard Harry, try using the item with something else.");
                Console.WriteLine();
            }
        }
    }
}