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
            this.Size = pizza.Size;
        }

        public override int cost()
        {
            return 90 + pizza.cost();
        }

        public override String getName()
        {
            return this.getName();
        }

        public override void simulateBaking()
        {
            pizza.simulateBaking();
        }
    }
}
