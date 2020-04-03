using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.pizzaOrder.pattern.payment
{
    class FiftyBillHandler : AbstractHandler
    {
        public FiftyBillHandler(int amountOfBillsInHandler, String handlerName)
            : base(amountOfBillsInHandler,handlerName)
        {
            this.billValue = 50;
        }

        public override void payOff()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write(this.billValue + " ");

            this.amountOfBillsInHandler--;

            Console.ResetColor();
        }
    }
}
