using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.pizzaOrder.pattern
{
    class PizzaVegetariana : AbstractPizza
    {

        public PizzaVegetariana()
        {
            this.name = "Vegetariana";
        }

        public override double cost()
        {
            return 3.99;
        }
    }
}
