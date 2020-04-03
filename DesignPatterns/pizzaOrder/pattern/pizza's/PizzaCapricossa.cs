using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.pizzaOrder.pattern
{
    class PizzaCapricossa : AbstractPizza
    {
        public PizzaCapricossa()
        {
            this.name = "Capricossa";
        }

        public override int cost()
        {
            return 750;
        }
    }
}
