using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.pizzaOrder.pattern.oven_s
{
    interface IOven
    {
        void bake(AbstractPizza pizza);
    }
}
