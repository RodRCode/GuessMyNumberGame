using App;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace GuessMyNumberGame
{
    internal class Bisection
    {
        static int low;
        static int high;
        static int current;
        static int lastCurrent;
        static int userNum;
        static int numGuesses;
        internal static void CompGuess(int min, int max)
        {
            lastCurrent = 0;
            numGuesses = 0;
            current = (max - min) / 2;
            Console.Clear();
            ConsoleMenuPainter.TextColor(15, 1);
            Console.WriteLine($"\nThe computer guesses your number from {min} to {max}\n");
            ConsoleMenuPainter.TextColor();
            Console.WriteLine("Enter your whole number (I am not going to use this to guess, only to lock in your number.");
            Console.Write("I would NEVER think *you* would try to trick or cheat, but some would): ");
            userNum = Elicit.WholeNumber(min, max);
            low = min;
            high = max;
            bool finished = false;
            do
            {
                BisectionSplit(max);
                finished = IsThisYourNumber();
            } while (!finished);
            Console.WriteLine("\n\n");
            ConsoleMenuPainter.TextColor(15, 1);
            Console.Write($"Your number was {current}, it took {numGuesses} times to guess it.");
            ConsoleMenuPainter.TextColor();
            Console.Write("\nHit any key to go to the start menu");
            Console.ReadKey();
        }

        internal static void UserValues()
        {
            Console.Clear();
            ConsoleMenuPainter.TextColor(15, 1);
            Console.WriteLine("The computer guesses your number from values you define");
            ConsoleMenuPainter.TextColor();
            Console.Write("\nEnter the lower: ");
            int min = Elicit.WholeNumber(int.MinValue+2, int.MaxValue-1);
            Console.Write("\nEnter the upper number: ");
            int max = Elicit.WholeNumber(min + 1, int.MaxValue);
            CompGuess(min, max);
        }

        internal static void UserValuesHumanGuess()
        {
            Console.Clear();
            ConsoleMenuPainter.TextColor(15, 1);
            Console.WriteLine("You enter the limit numbers, computer picks and you guess");
            ConsoleMenuPainter.TextColor();
            Console.Write("\nEnter the lower: ");
            int min = Elicit.WholeNumber(int.MinValue + 2, int.MaxValue - 1);
            Console.Write("\nEnter the upper number: ");
            int max = Elicit.WholeNumber(min + 1, int.MaxValue);
            HumanGuesses(min, max);
        }

        internal static void HumanGuesses(int low, int high)
        {
            Random rand = new Random();
            int compNum = rand.Next(low, high + 1);
            bool done = false;
            numGuesses = 0;

            Console.Clear();
            ConsoleMenuPainter.TextColor(15, 1);
            Console.WriteLine($"\nYou guess the computer's number from {low} to {high}");
            ConsoleMenuPainter.TextColor();
            Console.WriteLine($"OK, I have guessed my number from {low} to {high}!");

            do
            {
                Console.Write($"Whole numbers from {low} to {high}, what is your guess: ");
                userNum = Elicit.WholeNumber(low, high);
                numGuesses++;
                Console.WriteLine();
                if (userNum == compNum)
                {
                    ConsoleMenuPainter.TextColor(15, 1);
                    Console.WriteLine($"Good guess! My number was {compNum}.");
                    Console.WriteLine($"You got it in {numGuesses} guesses.");
                    ConsoleMenuPainter.TextColor();
                    Console.WriteLine("Hit any key to continue back to the main menu.");
                    Console.ReadKey();
                    done = true;
                }
                if (userNum > compNum)
                {
                    Console.WriteLine($"Your guess of {userNum} was too high");
                }
                if (userNum < compNum)
                {
                    Console.WriteLine($"Your guess of {userNum} was too low");
                }
            } while (!done);
        }

        private static bool IsThisYourNumber()
        {
            Console.Write($"Is {current} your number? (Y/N): ");
            do
            {
                var keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.N:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("N");
                        ConsoleMenuPainter.TextColor();
                        if (userNum == current)
                        {
                            numGuesses++;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\nYes it is! You said {userNum} originally!");
                            ConsoleMenuPainter.TextColor();
                            Console.Write($"Looks like I guessed it!  Cheater :)");
                            return true;
                        }
                        Console.WriteLine();
                        String highlow = HighOrLow();
                        switch (highlow)
                        {
                            case "High":
                                high = current;
                                numGuesses++;
                                return false;
                            case "Low":
                                low = current;
                                numGuesses++;
                                return false;
                            case "Error":
                                return false;
                            default:
                                break;
                        }
                        break;
                    case ConsoleKey.Y:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Y");
                        ConsoleMenuPainter.TextColor();
                        if (current != userNum)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\nYou changed your number! You said {userNum} originally!");
                            ConsoleMenuPainter.TextColor();
                            Console.WriteLine($"Lets try that again.");
                            Console.WriteLine();
                            return false;
                        }
                        numGuesses++;
                        return true;
                    default:
                        break;
                }
            } while (true);
        }

        private static string HighOrLow()
        {
            Console.Write($"The number {current} was not your number. Was it High or Low? (H/L): ");
            do
            {
                var keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.H:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("H");
                        ConsoleMenuPainter.TextColor();
                        Console.WriteLine();
                        if (userNum > current)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine();
                            Console.WriteLine($"Are you SURE about that?  You said {current} was HIGHER than {userNum}");
                            ConsoleMenuPainter.TextColor();
                            return "Error";
                        }
                        return "High";
                    case ConsoleKey.L:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("L");
                        ConsoleMenuPainter.TextColor();
                        Console.WriteLine();
                        if (userNum < current)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine();
                            Console.WriteLine($"Are you SURE about that?  You said {current} was LOWER than {userNum}");
                            ConsoleMenuPainter.TextColor();
                            return "Error";
                        }
                        return "Low";
                    default:
                        break;
                }
            }
            while (true);
        }

        private static void BisectionSplit(int max)
        {
            lastCurrent = current;

            if (low < 0 && high > 0)
            {
                current = (high + low) / 2;
            }
            else
            {
                current = low + (high - low) / 2;
            }
            if (lastCurrent == current)
            {
                current++;
            }
        }
    }
}