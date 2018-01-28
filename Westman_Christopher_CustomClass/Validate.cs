using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Westman_Christopher_CustomClass
{
    class Validate
    {
        public static string Input(string input)
        {
            double numbers;
            // Check for empty value
            while (string.IsNullOrWhiteSpace(input) || double.TryParse(input, out numbers))
            {
                // If incorrect user input is entered, correct user
                Console.WriteLine("Please type in a valide entry.");
                // Store input once again from user
                input = Console.ReadLine();
                continue;
            }
            // Return value to variable in main method
            return input;
        }

        // Craete method for validating user input
        public static decimal Input(string input, string type = "money")
        {
            // Declare generic variable since this method will be used for multiple questions
            decimal output = 0;
            // Create while loop that allows for 2 validation loops to run
            while (true)
            {
                // Validate for number < 0
                while (decimal.TryParse(input, out output) && output < 0)
                {
                    Console.WriteLine("\r\nYou can not type in a value of less than 0. Please try again.");
                    input = Console.ReadLine();

                }

                // Validate for letters and blank
                while (string.IsNullOrWhiteSpace(input) || !decimal.TryParse(input, out output))
                {
                    // If incorrect user input is entered, correct user
                    Console.WriteLine("Pleae type in a valid entry.");
                    // Store input once again from user
                    input = Console.ReadLine();
                    continue;
                }
                // Break out of while loop if user input is valid
                if (output >= 0)
                {
                    break;
                }

            }

            // Return output to user to be stored for later purposes
            return output;
        }
    }
}
