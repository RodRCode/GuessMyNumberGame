using System;
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
                    case ConsoleKey.D1: PrintSelection(menu);
                        return (0);
                    case ConsoleKey.D2: PrintSelection(menu); return (1);
                    case ConsoleKey.D3: PrintSelection(menu); return (2);
                    case ConsoleKey.D4: PrintSelection(menu); return (3);
                    case ConsoleKey.D5: PrintSelection(menu); return (4);
                    case ConsoleKey.D6: PrintSelection(menu); return (5);
                    case ConsoleKey.D7: PrintSelection(menu); return (6);
                    case ConsoleKey.D8: PrintSelection(menu); return (7);
                    case ConsoleKey.D9: PrintSelection(menu); return (8);
                    case ConsoleKey.D0: PrintSelection(menu); return (9);
                    case ConsoleKey.UpArrow: menu.MoveUp(); break;
                    case ConsoleKey.DownArrow: menu.MoveDown(); break;
                    case ConsoleKey.Enter:
                        done = true;
                        Console.ResetColor();
                        return (menu.SelectedIndex);
                    default:
                        break;
                }

                PrintSelection(menu);
            }
            while (!done);

            return (menu.SelectedIndex);
        }

        private static void PrintSelection(Menu menu)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Selected option: " + (menu.SelectedOption ?? "(nothing)"));
        }

        private static (bool, int) switchKey(ConsoleKeyInfo keyInfo, int selectedIndex, int countOfMenuItems)
        {
            bool selectInt = false;
            int selection = selectedIndex;

            switch (keyInfo.Key)
            {

                case ConsoleKey.D1: selectInt = true; selection = 0;break;
                case ConsoleKey.D2: selectInt = true; selection = 1;break;
                case ConsoleKey.D3: selectInt = true; selection = 2;break;
                case ConsoleKey.D4: selectInt = true; selection = 3;break;
                case ConsoleKey.D5: selectInt = true; selection = 4;break;
                case ConsoleKey.D6: selectInt = true; selection = 5;break;
                case ConsoleKey.D7: selectInt = true; selection = 6;break;
                case ConsoleKey.D8: selectInt = true; selection = 7;break;
                case ConsoleKey.D9: selectInt = true; selection = 8;break;
                case ConsoleKey.D0: selectInt = true; selection = 9; break;
                default: return (selectInt, selection);
            }
            return (selectInt, selection);

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
