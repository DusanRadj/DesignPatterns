using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.pizzaOrder.pattern
{
    class PizzaMargherita : AbstractPizza
    {

        public PizzaMargherita()
        {
            this.name = "Margherita";
        }

        public override double cost()
        {
            return 6.99;
        }
    }
}
