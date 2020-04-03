using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DesignPatterns.pizzaOrder.withoutPattern.pizza_s;


namespace DesignPatterns.pizzaOrder.withoutPattern.orders
{
    class InPlacePizzaOrder
    {
        private AbstractPizza chosenPizza;
        private int numOfThousandBills = 10;
        private int numOfFiveHundredBills = 10;
        private int numOfHundredBills = 10;
        private int numOfFiftyBills = 10;
        private int numOfTenBills = 10;

        public InPlacePizzaOrder() { }

        public void startOrderingProcess()
        {
            Console.WriteLine("----------------------------------------");

            //choose Pizza
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Type of pizza to order: ");
            Console.WriteLine("1. Capricossa");
            Console.WriteLine("2. Vegetariana");
            Console.WriteLine("3. Margherita");
            Console.ResetColor();
            Console.Write("Choose type: ");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    {
                        this.chosenPizza = new PizzaCapricossa();
                        break;
                    }
                case 2:
                    {
                        this.chosenPizza = new PizzaVegetariana();
                        break;
                    }
                default:
                    {
                        this.chosenPizza = new PizzaMargherita();
                        break;
                    }
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Chosen pizza: " + this.chosenPizza.getName());

            //bake pizza
            Console.WriteLine();
            Console.WriteLine("Baking pizza...");
            Thread.Sleep(3000);
            Console.WriteLine("Pizza baked!");
            Console.WriteLine();

            //add toppings
            Console.WriteLine("Toppings: ");
            Console.WriteLine("1. Ketchup");
            Console.WriteLine("2. Mayonaise");
            Console.WriteLine("3. Olives");
            Console.ResetColor();
            Console.Write("Choose toppings (1,3 for example, or press 0 if you dont want any): ");

            String toppings = Console.ReadLine();

            String[] toppingArray = toppings.Split(',');
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine();

            if (toppingArray.Contains("1"))
            {
                Console.WriteLine("Adding ketchup...");
                Thread.Sleep(1000);
                this.chosenPizza.addKetchup();
            }
            if (toppingArray.Contains("2"))
            {
                Console.WriteLine("Adding mayonaise...");
                Thread.Sleep(1000);
                this.chosenPizza.addMayonaise();
            }
            if (toppingArray.Contains("3"))
            {
                Console.WriteLine("Adding olives...");
                Thread.Sleep(1000);
                this.chosenPizza.addOlives();
            }
            if (toppings != "0")
            {
                Console.WriteLine("Toppings added!");
            }
            Console.WriteLine();
            

            //serve pizza
            Console.WriteLine("Serving pizza to the table...");
            Thread.Sleep(2000);
            Console.WriteLine("Pizza is served!");
            Console.WriteLine();
        
            //charge bill
            Console.WriteLine("Waiter is charging " + this.chosenPizza.getName() + " with total sum of " + this.chosenPizza.cost() + "RSD...");

            Console.ResetColor();
            Console.Write("Amount of money you give: ");

            int waiterRecieved = Convert.ToInt32(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Your change in bills: ");

            int change = waiterRecieved - this.chosenPizza.cost();
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

            Thread.Sleep(1500);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine();
            Console.WriteLine("Pizza is charged!");
            Console.ResetColor();
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
