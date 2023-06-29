namespace ShoppingCart.SharedKernel
{
    [Serializable]
    public abstract class ValueObject : IComparable, IComparable<ValueObject>
    {
        public int CompareTo(object? obj)
        {
            //TODO Add logic
            throw new NotImplementedException();
        }

        public int CompareTo(ValueObject? other)
        {
            //TODO Add logic
            throw new NotImplementedException();
        }
    }
}
