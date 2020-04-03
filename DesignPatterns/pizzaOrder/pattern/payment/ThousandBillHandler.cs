using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.pizzaOrder.pattern.payment
{
    class ThousandBillHandler : AbstractHandler
    {
        public ThousandBillHandler(int amountOfBillsInHandler, String handlerName)
            : base(amountOfBillsInHandler, handlerName)
        {
            this.billValue = 1000;
        }

        public override void payOff()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write(this.billValue + " ");

            this.amountOfBillsInHandler--;

            Console.ResetColor();
        }
    }
}
