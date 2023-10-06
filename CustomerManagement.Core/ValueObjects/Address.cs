using ShoppingCart.SharedKernel;

namespace CustomerManagement.Core.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string street, string city, string number, string country)
        {
            Street = street;
            City = city;
            Number = number;
            Country = country;
        }

        public string Street { get; private set; }
        public string City { get; private set; }
        public string Number { get; private set; }
        public string Country { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return Number;
            yield return Country;
        }
    }
}
