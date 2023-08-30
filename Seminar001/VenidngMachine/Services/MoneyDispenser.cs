using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VenidngMachine.Services
{
    public class MoneyDispenser
    {
        float money;

        public MoneyDispenser(float money)
        {
            this.money = money;
        }

        public void SetMoney(float money)
        {
            this.money += money;
        }
    }
}