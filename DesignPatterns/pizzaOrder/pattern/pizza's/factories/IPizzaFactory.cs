using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.pizzaOrder.pattern.pizza_s.factories
{
    interface IPizzaFactory
    {
        AbstractPizza createPizza();
    }
}
