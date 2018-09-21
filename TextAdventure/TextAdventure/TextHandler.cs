using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    public class TextHandler : Game
    {
        // Kontrollera och hantera indata
        string[] userInput;

        public TextHandler()
        {

        }

        public TextHandler(string[] userInput)
        {
            this.userInput = userInput;
        }

        public void CheckText()
        {
            userInput = Console.ReadLine().ToUpper().Split(' ');

            if (userInput[0].Equals("GO") || userInput[0].Equals("G"))
            {
                Move();
            }
            else if (userInput[0].Equals("USE") || userInput[0].Equals("U"))
            {
                //Use();
            }
            else if (userInput[0].Equals("TAKE") || userInput[0].Equals("T"))
            {
                //player.PickItem(userInput[0]);
            }
            else if (userInput[0].Equals("DROP") || userInput[0].Equals("D"))
            {
                //player.DropItem(userInput[0]);
            }
            else if (userInput[0].Equals("INSPECT") || userInput[0].Equals("I"))
            {
                if (player.currentLocation.roomInventory.ContainsKey(userInput[0]))
                {
                    player.currentLocation.InspectItem(userInput[0]);
                } 
                else if (player.playerInventory.ContainsKey(userInput[0]))
                {
                    //player.InspectItem(userInput[0]);
                }
            }
            else if (userInput[0].Equals("LOOK") || userInput[0].Equals("L"))
            {
                player.currentLocation.Look();
            }
        }
    }
}
