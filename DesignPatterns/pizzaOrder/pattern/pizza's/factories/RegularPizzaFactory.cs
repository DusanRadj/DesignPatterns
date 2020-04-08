using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.pizzaOrder.pattern.pizza_s.factories
{
    class RegularPizzaFactory : PizzaFactory
    {
        private void showMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Type of pizza to order: ");
            Console.WriteLine("1. Capricossa");
            Console.WriteLine("2. Vegetariana");
            Console.WriteLine("3. Margherita");
            Console.WriteLine();
            Console.ResetColor();

        }

        private String getTypeOfPizza()
        {
            Console.Write("Choose type: ");

            int option = Convert.ToInt32(Console.ReadLine());
            String pizzaType;

            switch (option)
            {
                case 1:
                    {
                        pizzaType = "Capricossa";
                        break;
                    }
                case 2:
                    {
                        pizzaType = "Vegetariana";
                        break;
                    }
                default:
                    {
                        pizzaType = "Margherita";
                        break;
                    }
            }

            return pizzaType;
        }

        public AbstractPizza createPizza()
        {
            showMenu();
            String pizzaType = getTypeOfPizza();

            if (pizzaType == "Capricossa")
            {
                return new PizzaCapricossa();
            }
            else if (pizzaType == "Vegetariana")
            {
                return new PizzaVegetariana();
            }
            else if (pizzaType == "Margherita")
            {
                return new PizzaMargherita();
            }
            else
            {
                return null;
            }
        }
    }
}
