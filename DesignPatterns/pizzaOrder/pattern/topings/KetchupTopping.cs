﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.pizzaOrder.pattern.topings
{
    class KetchupTopping : AbstractToppingDecorator
    {
        private AbstractPizza pizza;

        public KetchupTopping(AbstractPizza pizza)
        {
            this.pizza = pizza;
            this.name = pizza.getName() + " + Ketchup";
            this.Size = pizza.Size;
        }

        public override int cost()
        {
            return 30 + pizza.cost();
        }

        public override String getName()
        {
            return this.name;
        }

        public override void simulateBaking()
        {
            pizza.simulateBaking();
        }
    }
}
