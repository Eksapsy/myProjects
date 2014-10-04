using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMDesign;

namespace MenuNavigator
{
    class Navigator
    {
        private static int minimumPointer { get; set; }
        private static int start = 0;
        internal static int count = 0;
        private static bool menuStart = true;
        bool stop = false;

        public void menuNavigator(string[] options, int startPoint, int minPointer, string menuCursor = ">")
        {
            start = startPoint;          //it stores the variable to the memory
            Console.CursorVisible = false;
            minimumPointer = minPointer; //it stores the variable to the memory
            int totalOptions = options.Length;

            StringBuilder lineReadyForCursor = new StringBuilder();
            StringBuilder resetMenu = new StringBuilder();

            //The first time the menu is showed it uses this algo so it's prepared for the next input
            if (menuStart == true)
            {
                Console.SetCursorPosition(0, start);
                count = 0;
                resetMenu.Append(options[count]);
                lineReadyForCursor.Append(options[0]);
                lineReadyForCursor.Insert(0, menuCursor);
                Console.Write(lineReadyForCursor);
                menuStart = false;

            }

            if ((start + count < minPointer) || (start + count == (minimumPointer + totalOptions)))
            {
                throw new IndexOutOfRangeException("Cursor is below the minPointer !");
            }
            while (stop != true)
            {
                ConsoleKeyInfo k = Console.ReadKey();


                if (k.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(0, minimumPointer + count);
                    lineReadyForCursor.Remove(0, menuCursor.Length);
                    Console.Write(lineReadyForCursor);
                    Console.SetCursorPosition(lineReadyForCursor.Length, start + count);

                    Console.Write(CMDesign.ConsoleDesign.gaps(80 - lineReadyForCursor.Length));
                    lineReadyForCursor.Clear();
                    resetMenu.Clear();
                    count++;
                    if (count == totalOptions)
                        count = 0;
                    resetMenu.Append(options[0 + count]);
                    Console.SetCursorPosition(0, minimumPointer + count);
                    lineReadyForCursor.Insert(0, menuCursor + options[count]);
                    Console.Write(lineReadyForCursor);

                }

                else if (k.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(0, minimumPointer + count);
                    lineReadyForCursor.Remove(0, menuCursor.Length);
                    Console.Write(lineReadyForCursor);
                    Console.SetCursorPosition(lineReadyForCursor.Length, start + count);
                    Console.Write(CMDesign.ConsoleDesign.gaps(80 - lineReadyForCursor.Length));
                    lineReadyForCursor.Clear();
                    resetMenu.Clear();
                    count--;
                    int count2 = count;
                    if (count < 0)
                        count = totalOptions - 1;
                    count2 = count;
                    resetMenu.Append(options[0 + count]);
                    Console.SetCursorPosition(0, minimumPointer + count);
                    lineReadyForCursor.Insert(0, menuCursor + options[count]);
                    Console.Write(lineReadyForCursor);
                }

                if (k.Key == ConsoleKey.Enter) { menuStart = true; return; }

            }
        }
    }
}
