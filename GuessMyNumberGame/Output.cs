using System;
using System.Collections.Generic;
using System.Text;

namespace GuessMyNumberGame
{

    internal class Output
    {

        //Intro text tells the user what this program does
        internal static void Intro()
        {
            ConsoleMenuPainter.TextColor();                       

            Console.WriteLine("Welcome, this is a number guessing gaaaaame");
            Console.WriteLine("What would you like to do? (Make your selection with the \n" +
                "arrow or number key and then hit enter)");
        }

        // A final goodbye for the user
        internal static void ClosingMessage()
        {
            Console.Clear();
            Console.WriteLine("\n\nThanks! Have a Great day!\n\n\n");
            ConsoleMenuPainter.TextColor();
        }
    }

}
