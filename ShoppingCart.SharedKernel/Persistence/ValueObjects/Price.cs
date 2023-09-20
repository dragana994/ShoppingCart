﻿namespace ShoppingCart.SharedKernel.Persistence.ValueObjects
{
    public class Price
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
