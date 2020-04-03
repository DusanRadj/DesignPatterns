using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.pizzaOrder.pattern.payment
{
    class HundredBillHandler : AbstractHandler
    {
        public HundredBillHandler(int amountOfBillsInHandler, String handlerName)
            : base(amountOfBillsInHandler, handlerName)
        {
            this.billValue = 100;
        }

        public override void payOff()
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Write(this.billValue + " ");

            this.amountOfBillsInHandler--;

            Console.ResetColor();
        }
    }
}
