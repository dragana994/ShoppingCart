namespace ShoppingCart.SharedKernel
{
    [Serializable]
    public abstract class ValueObject : IComparable, IComparable<ValueObject>
    {
        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(ValueObject? other)
        {
            throw new NotImplementedException();
        }
    }
}
