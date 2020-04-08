using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DesignPatterns.pizzaOrder.pattern
{
    class OnlinePizzaOrder : AbstractPizzaOrder
    {
        public OnlinePizzaOrder(){ }

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
            Console.WriteLine(this.chosenPizza.ToString() + " is charged online from your credit card with total sum of " + this.chosenPizza.cost() + "RSD");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
