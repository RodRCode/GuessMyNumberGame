﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuessMyNumberGame
{

    public class Menu  //basic menu logic gotten from https://codereview.stackexchange.com/questions/198153/navigation-with-arrow-keys and then modified for my task
    //  logic for selecting specific option
    {
        public Menu(IEnumerable<string> items) => Items = items.ToArray();
        public IReadOnlyList<string> Items { get; }
        public int SelectedIndex { get; private set; } = 0; // first item selected by default
        public string SelectedOption => SelectedIndex != -1 ? Items[SelectedIndex] : null;

        public void MoveUp() => SelectedIndex = Math.Max(SelectedIndex - 1, 0);

        public void MoveDown() => SelectedIndex = Math.Min(SelectedIndex + 1, Items.Count - 1);

        // Recieves a string array and x and y coordinates to create the interactive menu at the x and y coordinates
        public static int Selection(string[] menuItems, int x, int y)
        {
            var menu = new Menu(menuItems);

            var countOfMenuItems = menuItems.Count();

            var menuPainter = new ConsoleMenuPainter(menu);

            bool done = false;

            do
            {
                menuPainter.Paint(x, y);

                var keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1: ClearAndPrint(menu); return (0);
                    case ConsoleKey.D2: ClearAndPrint(menu); return (1);
                    case ConsoleKey.D3: ClearAndPrint(menu); return (2);
                    case ConsoleKey.D4: ClearAndPrint(menu); return (3);
                    case ConsoleKey.D5: ClearAndPrint(menu); return (4);
                    case ConsoleKey.D6: ClearAndPrint(menu); return (5);
                    case ConsoleKey.D7: ClearAndPrint(menu); return (6);
                    case ConsoleKey.D8: ClearAndPrint(menu); return (7);
                    case ConsoleKey.D9: ClearAndPrint(menu); return (8);
                    case ConsoleKey.D0: ClearAndPrint(menu); return (9);
                    case ConsoleKey.UpArrow: menu.MoveUp(); break;
                    case ConsoleKey.DownArrow: menu.MoveDown(); break;
                    case ConsoleKey.Enter:
                        done = true;
                        return (menu.SelectedIndex);
                    default:
                        break;
                }
                
                ClearAndPrint(menu);
                
            }
            while (!done);

            return (menu.SelectedIndex);
        }

        private static void ClearAndPrint(Menu menu)
        {
            ClearCurrentConsoleLine();
            PrintSelection(menu);
        }

        private static void PrintSelection(Menu menu)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nSelected option: " + (menu.SelectedOption ?? "(nothing)"));
        }
        private static void ClearCurrentConsoleLine() //handy to clear just a line, not the entire screen
        {
            ConsoleMenuPainter.TextColor();
            int currentYPos = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop+1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentYPos);
        }
    }

    // logic for drawing menu list
    public class ConsoleMenuPainter
    {
        readonly Menu menu;
        public ConsoleMenuPainter(Menu menu)
        {
            this.menu = menu;
        }

        public void Paint(int x, int y)
        {
            for (int i = 0; i < menu.Items.Count; i++)
            {
                Console.SetCursorPosition(x, y + i);

                if (menu.SelectedIndex == i)
                {
                    TextColor(11, 1);
                }
                else
                {
                    TextColor();
                }

                Console.WriteLine(menu.Items[i]);
            }
        }
        static public void TextColor(int fore = 15, int back = 0) //main way I change text color, set for overloading
        {
            Console.ForegroundColor = (ConsoleColor)(fore);
            Console.BackgroundColor = (ConsoleColor)(back);
        }
    }
}
