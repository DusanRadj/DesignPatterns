using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DesignPatterns.pizzaOrder.pattern.oven_s
{
    class PizzaOven : IOven
    {
        public PizzaOven() { }



        public void bake(AbstractPizza pizza)
        {
            Console.WriteLine("Turning on the pizza oven...");
            Console.WriteLine();

            List<ConsoleColor> colors = new List<ConsoleColor>();
            colors.Add(ConsoleColor.DarkGray);
            colors.Add(ConsoleColor.Gray);
            colors.Add(ConsoleColor.Yellow);
            colors.Add(ConsoleColor.DarkYellow);
            colors.Add(ConsoleColor.Red);
            colors.Add(ConsoleColor.DarkRed);

            for (int i = 0; i < 6; i++)
            {
                Console.ForegroundColor = colors[i];
                Console.WriteLine("###############################");
                Console.SetCursorPosition(0, Console.CursorTop + 12);
                Console.WriteLine("###############################");
                Console.SetCursorPosition(0, Console.CursorTop - 14);
                Thread.Sleep(1500);
            }

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

