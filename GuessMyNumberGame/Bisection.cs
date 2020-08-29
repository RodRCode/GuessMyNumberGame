using App;
using System;
using System.Threading;

namespace GuessMyNumberGame
{
    internal class Bisection
    {
        static int low;
        static int high;
        static int current;
        static int userNum;
        internal static void CompGuess(int min, int max)
        {
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
            int count = 0;
            do
            {
                BisectionSplit();
                finished = IsThisYourNumber();
                /*
                if (finished)
                {
                    if (current != userNum)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"You changed your number! You said {userNum} originally!");
                        ConsoleMenuPainter.TextColor();
                        Console.Write($"Lets start over.  Hit any key to return to the main menu: ");
                        Console.ReadKey();
                        Run.EventLoop();
                    }
                }
                */
                count++;
            } while (!finished);
            Console.WriteLine($"\nYour number was {current}, it took {count} times to guess it.");
            Console.Write("Hit any key to go to the start menu");
            Console.ReadKey();
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
                        Console.Write("N");
                        if (userNum == current)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\nYes it is! You said {userNum} originally!");
                            ConsoleMenuPainter.TextColor();
                            Console.Write($"Lets start over, hit any key to return to the main menu: ");
                            Console.ReadKey();
                            Run.EventLoop();
                        }
                        Console.WriteLine();
                        String highlow = HighOrLow();
                        switch (highlow)
                        {
                            case "High":
                                high = current;
                                return false;
                            case "Low":
                                low = current;
                                return false;
                            case "Error":
                                return false;
                            default:
                                break;
                        }
                        break;
                    case ConsoleKey.Y:
                        Console.Write("Y");
                        if (current != userNum)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\nYou changed your number! You said {userNum} originally!");
                            ConsoleMenuPainter.TextColor();
                            Console.WriteLine($"Lets try that again.");
                            Console.WriteLine();
                            return false;
                        }
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
                        Console.Write("H");
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
                        Console.Write("L");
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

        private static void BisectionSplit()
        {
            current = low + (high - low) / 2;
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