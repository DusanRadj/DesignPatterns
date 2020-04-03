using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.pizzaOrder.withoutPattern.pizza_s
{
    class PizzaCapricossa : AbstractPizza
    {
        public PizzaCapricossa()
        {
            this.name = "Capricossa";
        }

        public override int cost()
        {
            int cost = 750;
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
