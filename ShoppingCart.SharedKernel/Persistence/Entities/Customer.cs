namespace ShoppingCart.SharedKernel.Persistence.Entities
{
    public class Customer : BaseEntity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
