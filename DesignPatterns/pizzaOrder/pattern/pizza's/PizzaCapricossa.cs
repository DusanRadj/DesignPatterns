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

        public override double cost()
        {
            return 5.0;
        }
    }
}
