using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.pizzaOrder.withoutPattern.pizza_s
{
    abstract class AbstractPizza
    {

        protected String name = "No name";
        protected int size = 0;
        protected bool hasKetchup = false;
        protected bool hasMayonaise = false;
        protected bool hasOlives = false;

        public abstract int cost();

        public abstract void simulateBakingInPizzaOven();
        public abstract void simulateBakingInRegularOven();

        public String getName()
        {
            return this.name;
        }

        public void addKetchup()
        {
            this.hasKetchup = true;
        }

        public void addMayonaise()
        {
            this.hasMayonaise = true;
        }

        public void addOlives()
        {
            this.hasOlives = true;
        }


    }
}
