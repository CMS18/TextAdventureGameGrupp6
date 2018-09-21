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

        public TextHandler(string[] userInput)
        {
            this.userInput = userInput;
        }

        public void CheckText()
        {
            userInput = Console.ReadLine().ToUpper().Split(' ');

            if (userInput[0].Equals("GO") || userInput[0].Equals("G"))
            {

            }
            else if (userInput[0].Equals("USE") || userInput[0].Equals("U"))
            {

            }
            else if (userInput[0].Equals("TAKE") || userInput[0].Equals("T"))
            {

            }
            else if (userInput[0].Equals("DROP") || userInput[0].Equals("D"))
            {

            }
            else if (userInput[0].Equals("INSPECT") || userInput[0].Equals("I"))
            {

            }
            else if (userInput[0].Equals("LOOK") || userInput[0].Equals("L"))
            {

            }
        }
    }
}
