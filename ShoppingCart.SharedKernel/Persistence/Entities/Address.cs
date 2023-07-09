namespace ShoppingCart.SharedKernel.Persistence.Entities
{
    public class Address : BaseEntity<int>
    {
        public int CustomerId { get; set; }
        public bool IsPrimary { get; set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string Number { get; private set; }
        public string Country { get; private set; }

        public virtual Customer Customer { get; set; }
    }
}
