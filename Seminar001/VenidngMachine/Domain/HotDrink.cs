namespace VenidngMachine.Domain
{
    public class HotDrink : ColdDrink
    {
        private float temp;
        public HotDrink(string name, float price, float volume, float temp) : base(name, price, volume)
        {
            this.temp = temp;
        }
    }
}