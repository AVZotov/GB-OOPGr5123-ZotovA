using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VenidngMachine.Domain;

namespace VenidngMachine.Services
{

    public class VendingMachine
    {
        private int iD;
        private string location;
        private const int ROWS = 2;
        private const int COLUMNS = 3;
        private const int MONEY = 100;
        private Holder holder;
        private MoneyDispenser dispenser;
        private Display display;

        public VendingMachine(int iD, string location)
        {
            this.iD = iD;
            this.location = location;
            this.holder = new Holder(ROWS, COLUMNS);
            this.display = new Display(this);
            this.dispenser = new MoneyDispenser(MONEY);
        }

        public void Start()
        {
            display.PrintWelcome();
            display.PrintMenu();
            Console.Write("Select Item you want to by: ");
            int position = GetUserInput(ROWS * COLUMNS);
            System.Console.Write("Enter the ammount to purchase: ");
            int ammount = GetUserInput();
            System.Console.WriteLine(ReleaseProduct(position, ammount));
        }

        public string GetInfo()
        {
            return $"Vending machine ID: {this.iD}\nLocation: {this.location}";
        }

        public Holder GetHolder()
        {
            return holder;
        }

        public int GetRows()
        {
            return ROWS;
        }

        public int GetColumns()
        {
            return COLUMNS;
        }

        private int GetUserInput(int maxValue)
        {
            uint userInput;

            while (!uint.TryParse(Console.ReadLine(), out userInput) || userInput > maxValue || userInput == 0)
            {
                System.Console.Write("Enter correct value!: ");
            }
            return (int)userInput;
        }

        private int GetUserInput()
        {
            int userInput;

            while (!int.TryParse(Console.ReadLine(), out userInput) || userInput < 1)
            {
                System.Console.Write("Enter correct value!: ");
            }
            return userInput;
        }

        private string ReleaseProduct(int position, int ammount)
        {
            Place place = null;
            Product product = null;
            int counter = 0;
            bool flag = false;

            for (int i = 0; i < COLUMNS; i++)
            {
                if (flag)
                {
                    break;
                }

                for (int j = 0; j < ROWS; j++)
                {
                    if (counter == position - 1)
                    {
                        place = holder.GetPlace(j, i);
                        product = place.GetProduct();
                        flag = true;
                        break;
                    }
                    counter++;
                }

            }

            if (flag == false)
            {
                return "No such product found";
            }

            if (CheckAmmount(place, ammount))
            {
                float cost = product.GetPrice() * ammount;
                dispenser.SetMoney(cost);
                return $"Your purchase is: {product}\nAmmount: {ammount}\nYou charged on: {cost}";
            }
            else
            {
                return "No Enought products ins vending machine";
            }
        }

        private bool CheckAmmount(Place place, int ammount)
        {
            if (place.GetProductAmount() >= ammount)
            {
                return true;
            }
            return false;
        }
    }
}