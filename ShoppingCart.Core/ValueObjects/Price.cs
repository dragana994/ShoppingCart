using ShoppingCart.SharedKernel;

namespace ShoppingCart.Core.ValueObjects
{
    public class Price : ValueObject
    {
        public Price(string currency, decimal cost)
        {
            Currency = currency;
            Cost = cost;
        }

        public string Currency { get; private set; }
        public decimal Cost { get; private set; }
    }
}
