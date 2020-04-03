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
        private PizzaFactory pizzaFactory;

        private static PizzaOrderApp instance;

        private PizzaOrderApp()
        {
            this.pizzaFactory = new PizzaFactory();
            this.onlinePizzaOrder = new OnlinePizzaOrder(this.pizzaFactory);
            this.selectedPizzaStore = inPlacePizzaOrder;

            AbstractHandler h1 = new ThousandBillHandler(10, "ThousandBillHandler");
            AbstractHandler h2 = new FiveHundredBillHandler(10, "FiveHunderBillHandler");
            AbstractHandler h3 = new HundredBillHandler(10, "HundredBillHandler");
            AbstractHandler h4 = new FiftyBillHandler(10, "FiftyBillHandler");
            AbstractHandler h5 = new TenBillHandler(10, "TenBillHandler");

            h1.setNextHandler(h2);
            h2.setNextHandler(h3);
            h3.setNextHandler(h4);
            h4.setNextHandler(h5);

            this.inPlacePizzaOrder = new InPlacePizzaOrder(this.pizzaFactory,h1);
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


        private void displayMenu()
        {
            Console.WriteLine("---------------------------------------                              ");
            Console.WriteLine("Options:                                                             ");
            Console.WriteLine("1. Change pizza store                                                ");
            Console.WriteLine("2. Start ordering process                                            ");
            Console.WriteLine("3. Refill bill handler                                               ");
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
                Console.WriteLine("Invalid input, please enter a valid option (from 0 to 2)!");
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
                case 0:
                    Console.WriteLine("Exiting from pizza order app...");
                    break;
                default:
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Invalid input, please enter a valid option (from 0 to 2)!");
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
