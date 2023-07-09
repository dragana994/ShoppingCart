namespace ShoppingCart.SharedKernel.Persistence.ValueObjects
{
    public class Residence : ValueObject
    {
        public Residence(string street, string city, string number, string country)
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
    }
}
