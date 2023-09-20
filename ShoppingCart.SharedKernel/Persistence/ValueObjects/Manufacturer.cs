namespace ShoppingCart.SharedKernel.Persistence.ValueObjects
{
    public class Manufacturer
    {
        public Manufacturer(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
