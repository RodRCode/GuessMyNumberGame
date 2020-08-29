using GuessMyNumberGame;
using System;

namespace App
{
    internal class Run
    {
        public Run()
        {
            Output.Intro();
            EventLoop();
            Output.ClosingMessage();
        }

        static public bool EventLoop()
        {
            bool finished = false;
            do
            {
                string[] menuItems = new string[] {
                "1) The computer guesses your number from 1 to 10",
                "2) You guess the computer's number from 1 to 1000",
                "3) Human picks number from 1 to 100, computer guesses",
                "4) Quit" };
                Console.Clear();
                Output.Intro();
                int userChoice = Menu.Selection(menuItems, 0, Console.CursorTop + 1); // the two digits are to place the menu on the x and y axis

                switch (userChoice)
                {
                    case 0:
                        Bisection.CompGuess(1,10);                        
                        break;
                    case 1:
                        Bisection.HumnGuess1to1000();
                        break;
                    case 2:
                        Bisection.CompGuess(1, 100);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Quit");
                        finished = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Default case");
                        break;
                }
            } while (!finished);

            return finished;
        }
    }
}