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

        public override int cost()
        {
            return 900;
        }
    }
}
