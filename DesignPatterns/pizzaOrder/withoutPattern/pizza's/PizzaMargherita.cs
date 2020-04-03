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

        public override int cost()
        {
            int cost = 900;
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
