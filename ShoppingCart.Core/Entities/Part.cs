using ShoppingCart.Core.ValueObjects;
using ShoppingCart.SharedKernel;

namespace ShoppingCart.Core.Entities
{
    public class Part : BaseEntity<int>
    {
        public Part(int id, string name, Manufacturer manufacturer, Price price)
        {
            Id = id;
            Name = name;
            Manufacturer = manufacturer;
            Price = price;
        }

        public Part() { }

        public string Name { get; private set; }
        public Manufacturer Manufacturer { get; private set; }
        public Price Price { get; private set; }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
