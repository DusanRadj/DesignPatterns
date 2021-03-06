﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DesignPatterns.pizzaOrder.pattern.topings;
using DesignPatterns.pizzaOrder.pattern.pizza_s.factories;
using DesignPatterns.pizzaOrder.pattern.oven_s;

namespace DesignPatterns.pizzaOrder.pattern
{
    abstract class AbstractPizzaStore
    {
        protected AbstractPizza chosenPizza;
        private IPizzaFactory domesticPizzaFactory;
        private IPizzaFactory regularPizzaFactory;
        private IOven pizzaOven;
        private IOven regularOven;

        public AbstractPizzaStore() 
        {
            this.domesticPizzaFactory = new DomesticPizzaFactory();
            this.regularPizzaFactory = new RegularPizzaFactory();
            this.pizzaOven = new PizzaOven();
            this.regularOven = new RegularOven();
        }

        void choosePizza()
        {
            Console.WriteLine("----------------------------------------");

            //code for choosing factory, and based on factory, createing pizza
            Console.Write("Choose pizza style (1.Regular / 2.Domestic): ");
            String option = Console.ReadLine();
            Console.WriteLine();

            if (option == "1")
            {
                this.chosenPizza = this.regularPizzaFactory.createPizza();
            }
            else 
            {
                this.chosenPizza = this.domesticPizzaFactory.createPizza();
            }
 
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Chosen pizza: " + this.chosenPizza.ToString());
            Console.ResetColor();
            Console.WriteLine("----------------------------------------");

        }

        void addToppings()
        {
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
            if (toppingArray.Contains("3"))
            {
                this.chosenPizza = new OlivesTopping(this.chosenPizza);
                Console.WriteLine("Adding olives...");
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
            Console.Write("Choose oven (1.Regular / 2.Pizza): ");
            String option = Console.ReadLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            Console.WriteLine("Chosen oven: " + option);
            Console.WriteLine();

            if (option == "1")
            {    
                this.regularOven.bake(this.chosenPizza);
            }
            else
            {
                this.pizzaOven.bake(this.chosenPizza);
            }

            Console.WriteLine();
            Console.ResetColor();    
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

