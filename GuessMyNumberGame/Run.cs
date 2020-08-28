﻿using GuessMyNumberGame;
using System;

namespace App
{
    internal class Run
    {
        public Run()
        {
            EventLoop();
        }

        private bool EventLoop()
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
                        Console.Clear();
                        Console.WriteLine("\n");
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("\n");
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("\n");
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