using System;

namespace App
{
    internal class Bisection
    {
        internal static void CompGuess1to10()
        {
            Console.Clear();
            Console.WriteLine("\nThe computer guesses your number from 1 to 10");
            Console.ReadLine();
        }

        internal static void CompGuess1to100()
        {
            Console.Clear();
            Console.WriteLine("\nHuman picks number from 1 to 100, computer guesses");
            Console.ReadLine();
        }

        internal static void HumnGuess1to1000()
        {
            Console.Clear();
            Console.WriteLine("\nYou guess the computer's number from 1 to 1000");
            Console.ReadLine();
        }
    }
}