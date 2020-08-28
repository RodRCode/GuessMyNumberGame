using System;
using System.Collections.Generic;
using System.Text;

namespace GuessMyNumberGame
{
    internal class Elicit
    {
        internal static int WholeNumber()
        {
            int userChoice = 0;
            string numString = "";

            bool done = false;
            do
            {
                numString = Console.ReadLine();

                try
                {
                    userChoice = int.Parse(numString);
                    if (userChoice > int.MaxValue || userChoice < 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("That is not what we were looking for.  Please enter a number 1 to 2,147,483,647: ");
                        Console.ResetColor();
                    }
                    else
                    {
                        done = true;
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is not what we were looking for.  Please enter a number 1 to 2,147,483,647:");
                    Console.ResetColor();
                }
            } while (!done);

            return userChoice;
        }

        // Generates the choices for the "What Now" menu and then activates it
        internal static int WhatNowMenu(int x = 0, int y = 0)
        {
            string[] whatNowChoices = new string[]
            {
            "1) ",
            "2) ",
            "3) ",
            "4) "
            };
            Console.WriteLine("What would you like to do? (Make your selection with the \n" +
                "arrow key or number key then hit enter)");
            int userChoice = Menu.Selection(whatNowChoices, x, y);
            return userChoice;
        }
    }
}
