using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.pizzaOrder.pattern.payment
{
    class FiveHundredBillHandler : AbstractHandler
    {
        public FiveHundredBillHandler(int amountOfBillsInHandler, String handlerName)
            : base(amountOfBillsInHandler,handlerName)
        {
            this.billValue = 500;
        }

        public override void payOff()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write(this.billValue + " ");

            this.amountOfBillsInHandler--;

            Console.ResetColor();
        }
    }
}
