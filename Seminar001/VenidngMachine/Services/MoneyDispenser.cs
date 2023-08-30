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