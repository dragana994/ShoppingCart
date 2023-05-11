namespace ShoppingCart.SharedKernel
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; }
    }
}
