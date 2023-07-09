using ShoppingCart.SharedKernel;

namespace ShoppingCart.SharedKernel.Persistence.ValueObjects
{
    public class Manufacturer : ValueObject
    {
        public Manufacturer(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
