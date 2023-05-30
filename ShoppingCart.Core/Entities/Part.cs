using ShoppingCart.Core.ValueObjects;
using ShoppingCart.SharedKernel;

namespace ShoppingCart.Core.Entities
{
    public class Part : BaseEntity<int>
    {
        public Part(int id, string name, int storeId, Manufacturer manufacturer, Price price)
        {
            Id = id;
            Name = name;
            StoreId = storeId;
            Manufacturer = manufacturer;
            Price = price;
        }

        public string Name { get; private set; }
        public int StoreId { get; private set; }
        public Manufacturer Manufacturer { get; private set; }
        public Price Price { get; private set; }


        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
