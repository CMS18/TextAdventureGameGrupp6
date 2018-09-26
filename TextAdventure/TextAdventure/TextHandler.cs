using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    public class TextHandler
    {
        // Kontrollera och hantera indata

        string[] userInput;

        public TextHandler()
        {
            
        }

        /*
        public void CheckText()
        {
            userInput = Console.ReadLine().ToUpper().Split(' ');

            if (userInput[0].Equals("GO") || userInput[0].Equals("G"))
            {
                if(userInput[1].Equals("NORTH") || userInput[1].Equals("WEST") || userInput[1].Equals("EAST") || userInput[1].Equals("SOUTH"))
                {
                    Move(userInput[1]);
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
                    base.player.PickItem(userInput[1]);
                }
                    
            }
            else if (userInput[0].Equals("DROP") || userInput[0].Equals("D"))
            {
                base.player.DropItem(userInput[1]);
            }
            else if (userInput[0].Equals("INSPECT") || userInput[0].Equals("I"))
            {
                if (base.player.currentLocation.roomInventory.ContainsKey(userInput[1]))
                {
                    base.player.currentLocation.InspectItem(userInput[1]);
                } 
                else if (base.player.playerInventory.ContainsKey(userInput[1]))
                {
                    base.player.InspectItem(userInput[1]);
                }
            }
            else if (userInput[0].Equals("LOOK") || userInput[0].Equals("L"))
            {
                base.player.currentLocation.Look();
            }
        }
        */
    }
}
