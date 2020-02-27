using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DesignPatterns.pizzaOrder.pattern.topings;

namespace DesignPatterns.pizzaOrder.pattern
{
    abstract class AbstractPizzaOrder
    {
        protected AbstractPizza chosenPizza;
        private PizzaFactory pizzaFactory;

        public AbstractPizzaOrder(PizzaFactory pizzaFactory) 
        {
            this.pizzaFactory = pizzaFactory;
        }

        void choosePizza()
        {
            Console.WriteLine("----------------------------------------");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            
            Console.WriteLine("Type of pizza to order: ");
            Console.WriteLine("1. Capricossa");
            Console.WriteLine("2. Vegetariana");
            Console.WriteLine("3. Margherita");

            Console.ResetColor();
            
            Console.Write("Choose type: ");

            int option = Convert.ToInt32(Console.ReadLine());
            String pizzaType;

            switch (option)
            {
                case 1:
                    {
                        pizzaType = "Capricossa";
                        break;
                    }
                case 2:
                    {
                        pizzaType = "Vegetariana";
                        break;
                    }
                default:
                    {
                        pizzaType = "Margherita";
                        break;
                    }
            }

            this.chosenPizza = pizzaFactory.createPizza(pizzaType);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Chosen pizza: " + this.chosenPizza.getName());

        }

        void addToppings()
        {
            Console.WriteLine("Toppings: ");
            Console.WriteLine("1. Ketchup");
            Console.WriteLine("2. Mayonaise");
            Console.ResetColor();
            Console.Write("Choose toppings (1,4,2 for example, or press 0 if you dont want any): ");
            
            String toppings = Console.ReadLine();

            String[] toppingArray = toppings.Split(',');
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine();

            if (toppingArray.Contains("1"))
            {
                this.chosenPizza = new KetchupTopping(this.chosenPizza);
                Console.WriteLine("Adding ketchup...");
                Thread.Sleep(1000);
            }
            if (toppingArray.Contains("2"))
            {
                this.chosenPizza = new MayonaiseTopping(this.chosenPizza);
                Console.WriteLine("Adding mayonaise...");
                Thread.Sleep(1000);
            }
            if (toppings != "0")
            {
                Console.WriteLine("Toppings added!");
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        void bakePizza()
        {
            Console.WriteLine();
            Console.WriteLine("Baking pizza...");
            Thread.Sleep(3000);
            Console.WriteLine("Pizza baked!");
            Console.WriteLine();
        }
        
        public abstract void servePizza();
        public abstract void chargeBill();

        public void startOrderingProcess()
        {
            choosePizza();
            bakePizza();
            addToppings();
            servePizza();
            chargeBill();
        }

    }
}

