using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.pizzaOrder.pattern.payment;

namespace DesignPatterns.pizzaOrder.pattern
{
    class PizzaOrderApp
    {
        private OnlinePizzaOrder onlinePizzaOrder;
        private InPlacePizzaOrder inPlacePizzaOrder;
        private AbstractPizzaOrder selectedPizzaStore;

        private static PizzaOrderApp instance;

        private PizzaOrderApp()
        {
            AbstractHandler h1 = new FiveHundredBillHandler(10, "FiveHunderBillHandler");
            AbstractHandler h2 = new HundredBillHandler(10, "HundredBillHandler");
            AbstractHandler h3 = new FiftyBillHandler(10, "FiftyBillHandler");
            AbstractHandler h4 = new TenBillHandler(10, "TenBillHandler");

            h1.setNextHandler(h2);
            h2.setNextHandler(h3);
            h3.setNextHandler(h4);

            this.inPlacePizzaOrder = new InPlacePizzaOrder(h1);
            this.onlinePizzaOrder = new OnlinePizzaOrder();
            this.selectedPizzaStore = inPlacePizzaOrder;
        }

        public static PizzaOrderApp getInstance()
        {
            if (instance == null)
            {
                instance = new PizzaOrderApp();
            }

            return instance;
        }

        public void changePizzaStore()
        {
            if (this.selectedPizzaStore == this.inPlacePizzaOrder)
            {
                this.selectedPizzaStore = this.onlinePizzaOrder;
                Console.WriteLine("Pizza store changed from 'In place' to 'Online'");
            }
            else
            {
                this.selectedPizzaStore = this.inPlacePizzaOrder;
                Console.WriteLine("Pizza store changed from 'Online' to 'In place'");
            }
        }

        public void refillBillHandler()
        {
            if (this.selectedPizzaStore == this.inPlacePizzaOrder)
            {
                this.inPlacePizzaOrder.refill();
            }
            else
            {
                Console.WriteLine("You must select inPlacePizzaStore in order to refill for now");
            }

        }

        public void addThousandBillHandler()
        {
            AbstractHandler h1 = new ThousandBillHandler(10, "ThousandBillHandler");
            h1.setNextHandler(this.inPlacePizzaOrder.BillHandler);
            this.inPlacePizzaOrder.BillHandler = h1;
        }

        public void showBillsInHandlers()
        {
            Console.Write(this.inPlacePizzaOrder.BillHandler.ToString());
        }


        private void displayMenu()
        {
            Console.WriteLine("---------------------------------------                              ");
            Console.WriteLine("Options:                                                             ");
            Console.WriteLine("1. Change pizza store                                                ");
            Console.WriteLine("2. Start ordering process                                            ");
            Console.WriteLine("3. Refill bill handler                                               ");
            Console.WriteLine("4. Demonstrate adding bill handler in real time                      ");
            Console.WriteLine("5. Show bills in handlers                                            ");
            Console.WriteLine("0. Exit                                                              ");
            Console.WriteLine("----------------------------------------                             ");
        }


        private int callAction()
        {
            int option = 0;
            Console.Write("Command: ");
            while (!Int32.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("Invalid input, please enter a valid option (from 0 to 5)!");
                Console.WriteLine("----------------------------");
                Console.Write("Command: ");
            }

            switch (option)
            {
                case 1:
                    this.changePizzaStore();
                    break;
                case 2:
                    this.selectedPizzaStore.startOrderingProcess();
                    break;
                case 3:
                    this.refillBillHandler();
                    break;
                case 4:
                    this.addThousandBillHandler();
                    break;
                case 5:
                    this.showBillsInHandlers();
                    break;
                case 0:
                    Console.WriteLine("Exiting from pizza order app...");
                    break;
                default:
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Invalid input, please enter a valid option (from 0 to 5)!");
                    break;
            }
            Console.WriteLine("----------------------------");
            return option;
        }

        public void startApp()
        {
            int option;
            this.displayMenu();
            do
            {
                int leftPosition = Console.CursorLeft;
                int topPosition = Console.CursorTop;
                Console.SetCursorPosition(Console.WindowLeft, Console.WindowTop);
                this.displayMenu();
                Console.SetCursorPosition(leftPosition, topPosition);

                option = this.callAction();
            } while (option != 0);
        }
    }
}
