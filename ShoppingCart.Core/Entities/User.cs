using ShoppingCart.SharedKernel;

namespace ShoppingCart.Core.Entities
{
    public class User : BaseEntity<int>
    {
        //zaposleni
        // + customer
        public User(int id, string name, int storeId)
        {
            Id = id;
            Name = name;
            StoreId = storeId;
        }

        public string Name { get; private set; }
        public int StoreId { get; private set; }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
