using ShoppingCart.SharedKernel;

namespace ShoppingCart.Core.ValueObjects
{
    public class Manufacturer : ValueObject
    {
        public Manufacturer(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}
