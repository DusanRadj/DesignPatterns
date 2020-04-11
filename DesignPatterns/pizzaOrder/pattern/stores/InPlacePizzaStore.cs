using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DesignPatterns.pizzaOrder.pattern.payment;

namespace DesignPatterns.pizzaOrder.pattern
{
    class InPlacePizzaStore : AbstractPizzaStore
    {
        private AbstractHandler billHandler;

        internal AbstractHandler BillHandler
        {
            get { return billHandler; }
            set { billHandler = value; }
        }

        public InPlacePizzaStore(AbstractHandler billHandler)
        {
            this.billHandler = billHandler;
        }

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
            Console.WriteLine("Waiter is charging " + this.chosenPizza.ToString() + " with total sum of " + this.chosenPizza.cost() + "RSD...");
            Console.ResetColor();
            Console.Write("Amount of money you give: ");

            int waiterRecieved = Convert.ToInt32(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.DarkCyan;

            Console.Write("Your change in bills: ");
            this.billHandler.processRequest(waiterRecieved - this.chosenPizza.cost());
            
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
            this.billHandler.refill(amount, billHandler);
            
        }
    
    }
}
