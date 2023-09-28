namespace ShoppingCart.SharedKernel.Persistence.ValueObjects
{
    public class Price
    {
        public Price(string currency, int cost)
        {
            Currency = currency;
            Cost = cost;
        }

        public string Currency { get; private set; }
        public int Cost { get; private set; }
    }
}
