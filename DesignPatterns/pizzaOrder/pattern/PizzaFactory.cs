using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.pizzaOrder.pattern
{
    class PizzaFactory
    {

        public AbstractPizza createPizza(String pizzaType)
        {
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
