using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DesignPatterns.pizzaOrder.withoutPattern.pizza_s
{
    class PizzaCapricossa : AbstractPizza
    {
        public PizzaCapricossa()
        {
            this.name = "Capricossa";
            this.size = 40;
        }

        public override int cost()
        {
            int cost = 750;
            if (this.hasKetchup)
            {
                cost += 30;
            }
            
            if (this.hasMayonaise)
            {
                cost += 70;
            }
            if (this.hasOlives)
            {
                cost += 90;
            }

            return cost;
        }

        public override void simulateBakingInPizzaOven()
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


            //pizza simulate start
            double radius = 4;
            double thickness = 0.4;
            Console.ForegroundColor = ConsoleColor.Yellow;
            char symbol = '.';

            Console.WriteLine();
            double rIn = radius - thickness;
            double rOut = radius + thickness;

            List<ConsoleColor> pizzaColors = new List<ConsoleColor>();
            pizzaColors.Add(ConsoleColor.White);
            pizzaColors.Add(ConsoleColor.Yellow);
            Console.SetCursorPosition(0, Console.CursorTop + 10);
            for (int i = 0; i < 2; i++)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 10);
                if (i != 0)
                    Thread.Sleep(2000);

                for (double y = -radius; y <= radius; ++y)
                {
                    for (double x = -radius; x < rOut; x += 0.5)
                    {
                        double value = x * x + y * y;
                        if (value >= rIn * rIn && value <= rOut * rOut)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkYellow;

                            Console.Write(symbol);
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else if (value < rIn * rIn)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.BackgroundColor = pizzaColors[i];
                            Console.Write('x');
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.Write(' ');
                        }
                    }
                    Console.WriteLine();

                }

                Console.WriteLine();
            }
            //pizzasimulate end


            Console.SetCursorPosition(0, Console.CursorTop + 4);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Pizza baked!");
        }

        public override void simulateBakingInRegularOven()
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

            //pizza simulate start
            double radius = 4;
            double thickness = 0.4;
            Console.ForegroundColor = ConsoleColor.Yellow;
            char symbol = '.';

            Console.WriteLine();
            double rIn = radius - thickness;
            double rOut = radius + thickness;

            List<ConsoleColor> pizzaColors = new List<ConsoleColor>();
            pizzaColors.Add(ConsoleColor.White);
            pizzaColors.Add(ConsoleColor.Yellow);
            Console.SetCursorPosition(0, Console.CursorTop + 10);
            for (int i = 0; i < 2; i++)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 10);
                if (i != 0)
                    Thread.Sleep(2000);

                for (double y = -radius; y <= radius; ++y)
                {
                    for (double x = -radius; x < rOut; x += 0.5)
                    {
                        double value = x * x + y * y;
                        if (value >= rIn * rIn && value <= rOut * rOut)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkYellow;

                            Console.Write(symbol);
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else if (value < rIn * rIn)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.BackgroundColor = pizzaColors[i];
                            Console.Write('x');
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.Write(' ');
                        }
                    }
                    Console.WriteLine();

                }

                Console.WriteLine();
            }
            //pizzasimulate end

            Console.SetCursorPosition(0, Console.CursorTop + 4);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Pizza baked!");

        }
    }
}
