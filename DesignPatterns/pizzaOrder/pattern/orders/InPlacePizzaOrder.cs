using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DesignPatterns.pizzaOrder.pattern
{
    class InPlacePizzaOrder : AbstractPizzaOrder
    {
        public InPlacePizzaOrder(PizzaFactory pizzaFactory) : base(pizzaFactory) { }

        public override void servePizza()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Serving pizza to the table...");
            Thread.Sleep(2000);
            Console.WriteLine("Pizza is served!");
            Console.WriteLine();
        }

        public override void chargeBill()
        {
            Console.WriteLine("Waiter is charging " + this.chosenPizza.getName() + " with total sum of " + this.chosenPizza.cost() + "$...");
            Thread.Sleep(1500);
            Console.WriteLine("Pizza is charged!");
            Console.ResetColor();
        }
    
    }
}
