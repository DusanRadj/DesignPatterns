using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DesignPatterns.pizzaOrder.withoutPattern.pizza_s
{
    class DomesticPizzaMargherita : AbstractPizza
    {
        public DomesticPizzaMargherita(int size)
        {
            this.name = "Domestic Margherita";
            this.size = size;
        }
        
        public override int cost()
        {
            int cost = 1100;
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

            List<ConsoleColor> ovenColors = new List<ConsoleColor>();
            ovenColors.Add(ConsoleColor.DarkGray);
            ovenColors.Add(ConsoleColor.Gray);
            ovenColors.Add(ConsoleColor.Yellow);
            ovenColors.Add(ConsoleColor.DarkYellow);
            ovenColors.Add(ConsoleColor.Red);
            ovenColors.Add(ConsoleColor.DarkRed);

            for (int i = 0; i < 6; i++)
            {
                Console.ForegroundColor = ovenColors[i];
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

            //simulate pizza start
            double radius = 4;
            double thickness = 0.4;
            Console.ForegroundColor = ConsoleColor.Yellow;
            char symbol = 'O';

            Console.WriteLine();
            double rIn = radius - thickness;
            double rOut = radius + thickness;

            List<ConsoleColor> colors = new List<ConsoleColor>();
            colors.Add(ConsoleColor.White);
            colors.Add(ConsoleColor.Yellow);
            colors.Add(ConsoleColor.DarkYellow);
            Console.SetCursorPosition(0, Console.CursorTop + 10);
            for (int i = 0; i < 3; i++)
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
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.Write(symbol);
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else if (value < rIn * rIn)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.BackgroundColor = colors[i];
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
            //simulate pizza end

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

            //simulate pizza start
            double radius = 4;
            double thickness = 0.4;
            Console.ForegroundColor = ConsoleColor.Yellow;
            char symbol = 'O';

            Console.WriteLine();
            double rIn = radius - thickness;
            double rOut = radius + thickness;

            List<ConsoleColor> colors = new List<ConsoleColor>();
            colors.Add(ConsoleColor.White);
            colors.Add(ConsoleColor.Yellow);
            colors.Add(ConsoleColor.DarkYellow);
            Console.SetCursorPosition(0, Console.CursorTop + 10);
            for (int i = 0; i < 3; i++)
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
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.Write(symbol);
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else if (value < rIn * rIn)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.BackgroundColor = colors[i];
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
            //simulate pizza end

            Console.SetCursorPosition(0, Console.CursorTop + 4);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Pizza baked!");
        }
    }
}
