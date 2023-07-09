namespace ShoppingCart.SharedKernel.Persistence.Entities
{
    public class Employee : BaseEntity<int>
    {
        public string Name { get; set; }
        public int StoreId { get; set; }

        public virtual Store Store { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
