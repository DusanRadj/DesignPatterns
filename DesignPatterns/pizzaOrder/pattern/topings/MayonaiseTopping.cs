using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.pizzaOrder.pattern.topings
{
    class MayonaiseTopping : AbstractToppingDecorator
    {
        private AbstractPizza pizza;

        public MayonaiseTopping(AbstractPizza pizza)
        {
            this.pizza = pizza;
            this.name = pizza.getName() + " + Mayonaise";
            this.Size = pizza.Size;
        }

        public override int cost()
        {
            return 70 + pizza.cost();
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
