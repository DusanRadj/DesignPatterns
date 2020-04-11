using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.pizzaOrder.pattern.pizza_s.factories
{
    class DomesticPizzaFactory : IPizzaFactory
    {
        private void showMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Type of pizza to order: ");
            Console.WriteLine("1. Domestic Capricossa");
            Console.WriteLine("2. Domestic Vegetariana");
            Console.WriteLine("3. Domestic Margherita");
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

        private int getDesiredSize()
        {
            Console.Write("Choose size: ");

            int size= Convert.ToInt32(Console.ReadLine());

            return size;
        }

        public AbstractPizza createPizza()
        {
            showMenu();
            String pizzaType = getTypeOfPizza();
            int size = getDesiredSize();

            if (pizzaType == "Capricossa")
            {
                return new DomesticWayPizzaCapricossa(size);
            }
            else if (pizzaType == "Vegetariana")
            {
                return new DomesticWayPizzaVegetariana(size);
            }
            else if (pizzaType == "Margherita")
            {
                return new DomesticWayPizzaMargherita(size);
            }
            else
            {
                return null;
            }
        }
    }
}
