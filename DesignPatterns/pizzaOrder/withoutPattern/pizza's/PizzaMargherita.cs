using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.pizzaOrder.withoutPattern.pizza_s
{
    class PizzaMargherita : AbstractPizza
    {

        public PizzaMargherita()
        {
            this.name = "Margherita";
        }

        public override double cost()
        {
            double cost = 6.99;
            if (this.hasKetchup)
            {
                cost += 0.19;
            }

            if (this.hasMayonaise)
            {
                cost += 0.29;
            }

            if (this.hasOlives)
            {
                cost += 0.35;
            }

            return cost;
        }
    }
}
