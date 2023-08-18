using MediatR;

namespace ShoppingCart.SharedKernel
{
    public abstract class BaseDomainEvent : INotification
    {
        public DateTime DateOccurred { get; protected set; }
    }
}
