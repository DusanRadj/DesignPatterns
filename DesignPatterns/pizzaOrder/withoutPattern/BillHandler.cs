using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.pizzaOrder.withoutPattern.pizza_s;

namespace DesignPatterns.pizzaOrder.withoutPattern
{
    class BillHandler
    {
        private int numOfThousandBills;
        private int numOfFiveHundredBills;
        private int numOfHundredBills;
        private int numOfFiftyBills;
        private int numOfTenBills;

        public BillHandler(int num1000, int num500, int num100, int num50, int num10)
        {
            this.numOfThousandBills = num1000;
            this.numOfFiveHundredBills = num500;
            this.numOfHundredBills = num100;
            this.numOfFiftyBills = num50;
            this.numOfTenBills = num10;
        }

        public void chargeBill(AbstractPizza chosenPizza)
        {
            Console.WriteLine("Waiter is charging " + chosenPizza.getName() + " with total sum of " + chosenPizza.cost() + "RSD...");

            Console.ResetColor();
            Console.Write("Amount of money you give: ");

            int waiterRecieved = Convert.ToInt32(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Your change in bills: ");

            int change = waiterRecieved - chosenPizza.cost();
            while (change / 1000 >= 1 && this.numOfThousandBills > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("1000 ");
                change -= 1000;
            }
            while (change / 500 >= 1 && this.numOfFiveHundredBills > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("500 ");
                change -= 500;
            }
            while (change / 100 >= 1 && this.numOfHundredBills > 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("100 ");
                change -= 100;
            }
            while (change / 50 >= 1 && this.numOfFiftyBills > 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("50 ");
                change -= 50;
            }
            while (change / 10 >= 1 && this.numOfTenBills > 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("10 ");
                change -= 10;
            }

        }

        public void refill()
        {
            Console.WriteLine("Enter bill handler to refill: ");
            String billHandler = Console.ReadLine();

            Console.WriteLine("Enter amount of bills to insert in handler: ");
            int amount = Convert.ToInt32(Console.ReadLine());

            switch (billHandler)
            {
                case "1000":
                    {
                        this.numOfThousandBills += amount;
                        break;
                    }
                case "500":
                    {
                        this.numOfThousandBills += amount;
                        break;
                    }
                case "100":
                    {
                        this.numOfThousandBills += amount;
                        break;
                    }
                case "50":
                    {
                        this.numOfThousandBills += amount;
                        break;
                    }
                case "10":
                    {
                        this.numOfThousandBills += amount;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Refill failed!");
                        break;
                    }
            }
        }
    }
}
