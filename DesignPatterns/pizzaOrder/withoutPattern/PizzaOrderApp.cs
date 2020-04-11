using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.pizzaOrder.withoutPattern.orders;

namespace DesignPatterns.pizzaOrder.withoutPattern
{
    class PizzaOrderApp
    {
        private OnlinePizzaOrder onlinePizzaOrder;
        private InPlacePizzaOrder inPlacePizzaOrder;
        
        public PizzaOrderApp()
        {
            this.onlinePizzaOrder = new OnlinePizzaOrder();
            this.inPlacePizzaOrder = new InPlacePizzaOrder();
        }

        public void showBillsInHandlers()
        {
            Console.Write(this.inPlacePizzaOrder.BillHandler.ToString());
        }

        private void displayMenu()
        {
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("Options:                                                             ");
            Console.WriteLine("1. Start ordering process at In-Place pizza store                    ");
            Console.WriteLine("2. Start ordering process at Online pizza store                      ");
            Console.WriteLine("3. Refill In-Place pizza store with cash                             ");
            Console.WriteLine("4. Show bills in handlers                                            ");
            Console.WriteLine("0. Exit                                                              ");
            Console.WriteLine("---------------------------------------------------------------------");
        }


        private int callAction()
        {
            int option = 0;
            Console.Write("Command: ");
            while (!Int32.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("Invalid input, please enter a valid option (from 0 to 4)!");
                Console.WriteLine("---------------------------------------------------------------------");
                Console.Write("Command: ");
            }

            switch (option)
            {
                case 1:
                    this.inPlacePizzaOrder.startOrderingProcess();
                    break;
                case 2:
                    this.onlinePizzaOrder.startOrderingProcess();
                    break;
                case 3:
                    this.inPlacePizzaOrder.BillHandler.refill();
                    break;
                case 4:
                    this.showBillsInHandlers();
                    break;
                case 0:
                    Console.WriteLine("Exiting from pizza order app...");
                    break;
                default:
                    Console.WriteLine("---------------------------------------------------------------------");
                    Console.WriteLine("Invalid input, please enter a valid option (from 0 to 4)!");
                    break;
            }
            Console.WriteLine("---------------------------------------------------------------------");
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
