using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DesignPatterns.pizzaOrder.pattern
{
    class OnlinePizzaOrder : AbstractPizzaOrder
    {

        public OnlinePizzaOrder(PizzaFactory pizzaFactory) : base(pizzaFactory) { }

        public override void servePizza()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Getting pizza to pizza guy who will deliver pizza to you...");
            Thread.Sleep(500);
            Console.WriteLine("Pizza guy is on the way...");
            Thread.Sleep(5000);
            Console.WriteLine("Pizza guy is here!");
            Console.WriteLine();
        }

        public override void chargeBill()
        {
            Console.WriteLine(this.chosenPizza.getName() + " is charged online from your credit card with total sum of + " + this.chosenPizza.cost() + "$");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
