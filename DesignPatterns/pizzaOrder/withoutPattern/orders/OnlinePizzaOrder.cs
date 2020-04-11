using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DesignPatterns.pizzaOrder.withoutPattern.pizza_s;

namespace DesignPatterns.pizzaOrder.withoutPattern.orders
{
    class OnlinePizzaOrder
    {
        private AbstractPizza chosenPizza;

        public OnlinePizzaOrder() { }

        public void startOrderingProcess()
        {
            Console.WriteLine("----------------------------------------");

            //choose Pizza
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Type of pizza to order: ");
            Console.WriteLine("1. Capricossa");
            Console.WriteLine("2. Vegetariana");
            Console.WriteLine("3. Margherita");
            Console.WriteLine("4. Domestic Capricossa");
            Console.WriteLine("5. Domestic Vegetariana");
            Console.WriteLine("6. Domestic Margherita");
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
                case 3:
                    {
                        this.chosenPizza = new PizzaMargherita();
                        break;
                    }
                case 4:
                    {
                        Console.Write("Choose size: ");
                        int size = Convert.ToInt32(Console.ReadLine());

                        this.chosenPizza = new DomesticPizzaCapricossa(size);
                        break;
                    }
                case 5:
                    {
                        Console.Write("Choose size: ");
                        int size = Convert.ToInt32(Console.ReadLine());

                        this.chosenPizza = new DomesticPizzaVegetariana(size);
                        break;
                    }
                default:
                    {
                        Console.Write("Choose size: ");
                        int size = Convert.ToInt32(Console.ReadLine());

                        this.chosenPizza = new DomesticPizzaMargherita(size);
                        break;
                    }
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Chosen pizza: " + this.chosenPizza.getName());

            //bake pizza
            Console.Write("Choose oven (1.Regular / 2.Pizza): ");
            String oven = Console.ReadLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            Console.WriteLine("Chosen oven: " + option);
            Console.WriteLine();

            if (oven == "1")
            {
                this.chosenPizza.simulateBakingInRegularOven();
            }
            else
            {
                this.chosenPizza.simulateBakingInPizzaOven();
            }

            Console.WriteLine();
            Console.ResetColor();    

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
            Console.WriteLine("Getting pizza to pizza guy who will deliver pizza to you...");
            Thread.Sleep(500);
            Console.WriteLine("Pizza guy is on the way...");
            Thread.Sleep(5000);
            Console.WriteLine("Pizza guy is here!");
            Console.WriteLine();
        
            //charge bill
            Console.WriteLine(this.chosenPizza.getName() + " is charged online from your credit card with total sum of " + this.chosenPizza.cost() + "$");
            Console.ResetColor();
            Console.WriteLine();
        }

    }
}
