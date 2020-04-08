using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.pizzaOrder.pattern.payment
{
    abstract class AbstractHandler
    {

        protected int amountOfBillsInHandler;   
        protected AbstractHandler nextHandler;
        protected int billValue;                
        protected String handlerName;


        public AbstractHandler(int amountOfBillsInHandler, String handlerName)
        {
            this.amountOfBillsInHandler = amountOfBillsInHandler;
            this.handlerName = handlerName;
        }

        public void setNextHandler(AbstractHandler handler)
        {
            this.nextHandler = handler;
        }

        public void processRequest(int amountToPayOff)
        {
            int amountOfBillsToGive = amountToPayOff / billValue;

            while (amountOfBillsToGive > 0 && this.amountOfBillsInHandler != 0) // dok god trebas i imas da vracas ti vrati
            {
                this.payOff();
                amountOfBillsToGive--;
                amountToPayOff -= billValue;
            }

            if (amountOfBillsInHandler == 0)
                Console.WriteLine("[ " + this.handlerName + " IS EMPTY! ]");


            if (amountToPayOff > 0 && this.nextHandler != null)
            {
                this.nextHandler.processRequest(amountToPayOff);
            }
            else if (amountToPayOff > 0 && this.nextHandler == null)
            {
                Console.WriteLine("Waiter owe you " + amountToPayOff);
            }

        }

        public void refill(int amount, String handlerName)
        {
            if (this.handlerName == handlerName)
            {
                this.amountOfBillsInHandler += amount;
                Console.WriteLine("Amount of bills in " + this.handlerName + " is: " + this.amountOfBillsInHandler);
            }
            else if (this.nextHandler != null)
            {
                this.nextHandler.refill(amount, handlerName);
            }
            else
            {
                Console.WriteLine("Refill failed");
            }

        }

        public override string ToString()
        {
            string retVal = this.handlerName + ", amount of " + this.billValue + " bills in handler is: " + this.amountOfBillsInHandler;
            retVal += System.Environment.NewLine;

            if (this.nextHandler != null)
            {
                retVal += nextHandler.ToString();
            }

            return retVal;
        }


        public abstract void payOff();

    }
}
