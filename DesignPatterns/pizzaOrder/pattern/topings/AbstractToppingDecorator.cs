using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.pizzaOrder.pattern.topings
{
    abstract class AbstractToppingDecorator : AbstractPizza
    {
        public abstract String getName();

    }
}
