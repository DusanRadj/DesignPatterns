using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.pizzaOrder.pattern.topings
{
    class OlivesTopping : AbstractToppingDecorator
    {
        private AbstractPizza pizza;

        public OlivesTopping(AbstractPizza pizza)
        {
            this.pizza = pizza;
            this.name = pizza.getName() + " + Olives";
        }

        public override double cost()
        {
            return 0.35 + pizza.cost();
        }

        public override String getName()
        {
            return this.getName();
        }
    }
}
