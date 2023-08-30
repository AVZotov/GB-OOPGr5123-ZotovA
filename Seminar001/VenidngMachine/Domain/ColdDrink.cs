namespace VenidngMachine.Domain
{
    public class ColdDrink : Product
    {
        private readonly float volume;
        public ColdDrink(string name, float price, float volume) : base(name, price)
        {
            this.volume = volume;
        }

        public override string ToString()
        {
            return $"{base.ToString()}: Category:{this.GetType().Name}";
        }
    }
}