using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VenidngMachine.Domain;

namespace VenidngMachine.Services
{
    public class Holder
    {
        private int maxRows;
        private int maxColumns;
        private Random random;
        private List<Place>[] places;

        public Holder(int maxRows, int maxColumns)
        {
            random = new Random();
            Create(maxRows, maxColumns);
            Fill();
        }

        public Place GetPlace(int row, int column)
        {
            if (row <= maxRows && column <= maxColumns && row >= 0 && column >= 0)
            {
                return places[column][row];
            }
            return null;
        }

        public Product GetProduct(Place place)
        {
            return place.GetProduct();
        }

        private void Create(int maxRows, int maxColumns)
        {
            if (maxRows < 1 || maxColumns < 2)
            {
                this.maxRows = 1;
                this.maxColumns = 2;
            }
            else
            {
                this.maxRows = maxRows;
                this.maxColumns = maxColumns;
            }
            places = new List<Place>[this.maxColumns];

            for (int i = 0; i < places.Length; i++)
            {
                places[i] = new List<Place>();
            }
        }

        private enum ProductNames
        {
            Sandwich,
            Chips,
            Chocolate
        }

        private enum ColdDrinkNames
        {
            Juice,
            Water,
            Milk,
            EnergyDrink
        }

        private enum HotDrinkNames
        {
            Soup,
            Coffe,
            Tea
        }

        private void Fill()
        {

            int maxRowCapacity = 21;

            for (int i = 0; i < places.Length; i++)
            {
                for (int j = 0; j < maxRows; j++)
                {
                    places[i].Add(new Place(GetRandomProduct(), random.Next(5, maxRowCapacity), i, j));
                }
            }
        }

        private Product GetRandomProduct()
        {
            int maxPrice = 101;
            float volume = 0.5f;
            int maxTemp = 51;

            switch (random.Next(1, 4))
            {
                case 1:
                    int productCount = Enum.GetNames(typeof(ProductNames)).Length;
                    return new Product(((ProductNames)GetRandomInt(productCount)).ToString(),
                            GetRandomFloat(maxPrice));
                case 2:
                    productCount = Enum.GetNames(typeof(ColdDrinkNames)).Length;
                    return new ColdDrink(((ColdDrinkNames)GetRandomInt(productCount)).ToString(),
                            GetRandomFloat(maxPrice), volume);
                case 3:
                    productCount = Enum.GetNames(typeof(HotDrinkNames)).Length;
                    return new HotDrink(((HotDrinkNames)GetRandomInt(productCount)).ToString(),
                            GetRandomFloat(maxPrice), volume, GetRandomFloat(maxTemp));
            }
            return null;
        }

        private int GetRandomInt(int maxValue)
        {
            return random.Next(0, maxValue);
        }

        private int GetRandomInt(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
        }

        private float GetRandomFloat(int maxValue)
        {
            return (float)Math.Round(random.Next(10, maxValue) + random.NextDouble(), 2);
        }
    }
}