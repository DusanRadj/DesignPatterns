using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.pizzaOrder.withoutPattern.pizza_s
{
    class PizzaVegetariana : AbstractPizza
    {

        public PizzaVegetariana()
        {
            this.name = "Vegetariana";
        }

        public override int cost()
        {
            int cost = 600;
            if (this.hasKetchup)
            {
                cost += 30;
            }

            if (this.hasMayonaise)
            {
                cost += 70;
            }

            if (this.hasOlives)
            {
                cost += 90;
            }

            return cost;
        }
    }
}
