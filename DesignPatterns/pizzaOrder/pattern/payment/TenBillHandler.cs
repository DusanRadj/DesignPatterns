using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.pizzaOrder.pattern.payment
{
    class TenBillHandler : AbstractHandler
    {
        public TenBillHandler(int amountOfBillsInHandler, String handlerName)
            : base(amountOfBillsInHandler,handlerName)
        {
            this.billValue = 10;
        }

        public override void payOff()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write(this.billValue + " ");

            this.amountOfBillsInHandler--;

            Console.ResetColor();
        }
    }
}
