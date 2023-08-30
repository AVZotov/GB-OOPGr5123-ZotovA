using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using VenidngMachine.Domain;

namespace VenidngMachine.Services
{
    public class Display
    {
        private readonly VendingMachine vendingMachine;
        public Display(VendingMachine vendingMachine)
        {
            this.vendingMachine = vendingMachine;
        }

        public void PrintWelcome()
        {
            System.Console.WriteLine(vendingMachine.GetInfo());
            System.Console.WriteLine("Please select product to continue:");
        }
        public void PrintMenu()
        {
            Holder holder = vendingMachine.GetHolder();
            int counter = 1;
            int columns = vendingMachine.GetColumns();
            int rows = vendingMachine.GetRows();

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    Place place = holder.GetPlace(j, i);
                    Console.WriteLine($"{counter, 10}. {holder.GetProduct(place), 10} | Quantity: {place.GetProductAmount(), 10}");
                    counter++;
                }
            }
        }
    }
}