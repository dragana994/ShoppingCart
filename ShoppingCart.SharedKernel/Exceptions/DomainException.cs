﻿namespace ShoppingCart.SharedKernel.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }
    }
}
