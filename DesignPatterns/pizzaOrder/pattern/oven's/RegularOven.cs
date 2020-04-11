using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DesignPatterns.pizzaOrder.pattern.oven_s
{
    class RegularOven : IOven
    {
        public RegularOven(){}

        public void bake(AbstractPizza pizza)
        {
            Console.WriteLine("Turning on the regular oven...");
            Console.WriteLine();

            for (int i = 0; i < 10; i++)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                if (i % 2 == 0)
                {

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("###############################");
                    Console.SetCursorPosition(0, Console.CursorTop + 12);
                    Console.WriteLine("###############################");
                    Console.SetCursorPosition(0, Console.CursorTop - 14);
                    Thread.Sleep(450);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("###############################");
                    Console.SetCursorPosition(0, Console.CursorTop + 12);
                    Console.WriteLine("###############################");
                    Console.SetCursorPosition(0, Console.CursorTop - 14);
                    Thread.Sleep(350);
                }
                
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(0, Console.CursorTop + 15);
            Console.WriteLine("Oven turned on!");
            Console.SetCursorPosition(0, Console.CursorTop - 15);

            pizza.simulateBaking();

            Console.SetCursorPosition(0, Console.CursorTop + 4);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Pizza baked!");

        }


        
    }
}
