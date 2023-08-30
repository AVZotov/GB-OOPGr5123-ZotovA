using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VenidngMachine.Domain
{
    public class Place
    {
        private Product product;
        private int productAmount;
        private int row;
        private int column;

        public Place(Product product, int productAmount, int row, int column)
        {
            this.product = product;
            this.productAmount = productAmount;
            this.row = row;
            this.column = column;
        }

        public void SetAmmount(int productAmount)
        {
            if (productAmount <= this.productAmount)
            {
                this.productAmount -= productAmount;
            }
            else
            {
                System.Console.WriteLine("No enough product in Vending Machine");
            }
        }

        public Product GetProduct()
        {
            return this.product;
        }
    
        public int GetProductAmount()
        {
            return this.productAmount;
        }
    }
}