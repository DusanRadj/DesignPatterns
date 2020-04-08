using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DesignPatterns.pizzaOrder.pattern
{
    abstract class AbstractPizza
    {

        protected String name = "No name";
        private int size = 0;
        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        public abstract int cost();
        
        public String getName()
        {
            return this.name;
        }

        public abstract void simulateBaking();

        public override string ToString()
        {
            return this.getName() + " with size " + this.size;
        }
    }
}
