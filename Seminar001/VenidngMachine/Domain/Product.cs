using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VenidngMachine.Domain
{
    public class Product
    {
        private string name;
        private float price;

        public Product(string name, float price)
        {
            this.name = name;
            SetPrice(price);
        }
        override public string ToString()
        {
            return $"Product: {name}\tCost: {price}";
        }

        private void SetPrice(float price)
        {
            if (price > 10)
            {
                this.price = price;
            }
            else
            {
                this.price = 10;
            }
        }

        public float GetPrice()
        {
            return this.price;
        }
    }
}