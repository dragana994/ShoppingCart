namespace ShoppingCart.SharedKernel
{
    [Serializable]
    public abstract class ValueObject : IComparable, IComparable<ValueObject>
    {
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (left is null ^ right is null)
            {
                return false;
            }
            return ReferenceEquals(left, right) || left!.Equals(right);
        }

        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !EqualOperator(left, right);
        }

        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;

            return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }

        public int CompareTo(object? obj)
        {
            if (obj is null)
                return 1;

            Type thisType = this.GetType();
            Type otherType = obj.GetType();

            if (thisType != otherType)
                return string.Compare(thisType.ToString(), otherType.ToString(), StringComparison.Ordinal);

            var other = (ValueObject)obj;

            object[] components = GetEqualityComponents().ToArray();
            object[] otherComponents = other.GetEqualityComponents().ToArray();

            for (int i = 0; i < components.Length; i++)
            {
                int comparison = CompareComponents(components[i], otherComponents[i]);
                if (comparison != 0)
                    return comparison;
            }

            return 0;
        }

        public int CompareTo(ValueObject? other)
        {
            return CompareTo(other as object);
        }

        public static bool operator ==(ValueObject one, ValueObject two)
        {
            return EqualOperator(one, two);
        }

        public static bool operator !=(ValueObject one, ValueObject two)
        {
            return NotEqualOperator(one, two);
        }

        private static int CompareComponents(object object1, object object2)
        {
            if (object1 is null && object2 is null)
                return 0;

            if (object1 is null)
                return -1;

            if (object2 is null)
                return 1;

            if (object1 is IComparable comparable1 && object2 is IComparable comparable2)
                return comparable1.CompareTo(comparable2);

            return object1.Equals(object2) ? 0 : -1;
        }
    }
}
