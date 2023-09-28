namespace ShoppingCart.SharedKernel.Persistence.Entities
{
    public class StorePart : BaseEntity<int>
    {
        public int StoreId { get; set; }
        public int PartId { get; set; }
        public int Quantity { get; set; }

        public virtual Store Store { get; set; }
        public virtual Part Part { get; set; }
    }
}
