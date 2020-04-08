using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DesignPatterns.pizzaOrder.pattern
{
    class PizzaMargherita : AbstractPizza
    {

        public PizzaMargherita()
        {
            this.name = "Margherita";
            this.Size = 40;
        }

        public override int cost()
        {
            return 900;
        }

        public override void simulateBaking()
        {
            double radius = 4;
            double thickness = 0.4;
            Console.ForegroundColor = ConsoleColor.Yellow;
            char symbol = '.';

            Console.WriteLine();
            double rIn = radius - thickness;
            double rOut = radius + thickness;

            List<ConsoleColor> colors = new List<ConsoleColor>();
            colors.Add(ConsoleColor.White);
            colors.Add(ConsoleColor.Yellow);
            Console.SetCursorPosition(0, Console.CursorTop + 10);
            for (int i = 0; i < 2; i++)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 10);
                if (i != 0)
                    Thread.Sleep(4000);


                for (double y = -radius; y <= radius; ++y)
                {
                    for (double x = -radius; x < rOut; x += 0.5)
                    {
                        double value = x * x + y * y;
                        if (value >= rIn * rIn && value <= rOut * rOut)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(symbol);
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else if (value < rIn * rIn)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.BackgroundColor = colors[i];
                            Console.Write('o');
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


        }
    }
}
