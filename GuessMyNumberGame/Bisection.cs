using System;

namespace GuessMyNumberGame
{
    internal class Bisection
    {
        internal static void CompGuess1to10()
        {
            Console.Clear();
            ConsoleMenuPainter.TextColor(15, 1);
            Console.WriteLine("\nThe computer guesses your number from 1 to 10");
            ConsoleMenuPainter.TextColor();

            Console.ReadLine();
        }

        internal static void CompGuess1to100()
        {
            Console.Clear();
            ConsoleMenuPainter.TextColor(15, 1);
            Console.WriteLine("\nHuman picks number from 1 to 100, computer guesses");
            ConsoleMenuPainter.TextColor();
            Console.ReadLine();
        }

        internal static void HumnGuess1to1000()
        {
            Console.Clear();
            ConsoleMenuPainter.TextColor(15, 1);
            Console.WriteLine("\nYou guess the computer's number from 1 to 1000");
            ConsoleMenuPainter.TextColor();
            Console.ReadLine();
        }
    }
}