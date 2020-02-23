using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            this.inPlacePizzaOrder = new InPlacePizzaOrder(this.pizzaFactory);
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


        private void displayMenu()
        {
            Console.WriteLine("---------------------------------------                              ");
            Console.WriteLine("Options:                                                             ");
            Console.WriteLine("1. Change pizza store                                                ");
            Console.WriteLine("2. Start ordering process                                            ");
            /*Console.WriteLine("3. Pause                                                             ");
            Console.WriteLine("4. Stop                                                              ");
            Console.WriteLine("5. Next                                                              ");
            Console.WriteLine("6. Previous                                                          ");
            Console.WriteLine("7. Lock/Unlock                                                       ");
            Console.WriteLine("8. Turn off                                                          ");*/
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

            //Console.WriteLine("----------------------------");
            switch (option)
            {
                case 1:
                    this.changePizzaStore();
                    break;
                case 2:
                    this.selectedPizzaStore.startOrderingProcess();
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
