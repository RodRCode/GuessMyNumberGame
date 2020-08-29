using System;
using System.Collections.Generic;
using System.Text;

namespace GuessMyNumberGame
{
    internal class Elicit
    {
        // Checkes to make sure the whole number input is in a valid range
        internal static int WholeNumber(int min = 1, int max = 10)
        {
            int userChoice = 0;
            string numString = "";

            bool done = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                numString = Console.ReadLine();
                ConsoleMenuPainter.TextColor();
                try
                {
                    userChoice = int.Parse(numString);
                    if (userChoice >= min && userChoice <= max)
                    {
                        done = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"That is not what we were looking for.  Please enter a number {min} to {max}: ");
                        ConsoleMenuPainter.TextColor();
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"That is not what we were looking for.  Please enter a number {min} to {max}: ");
                    ConsoleMenuPainter.TextColor();
                }
            } while (!done);

            return userChoice;
        }
    }
}
