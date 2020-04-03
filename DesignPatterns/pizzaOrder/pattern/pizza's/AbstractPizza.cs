using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.pizzaOrder.pattern
{
    abstract class AbstractPizza
    {

        protected String name = "No name";

        public abstract int cost();
        
        public String getName()
        {
            return this.name;
        }
    }
}
