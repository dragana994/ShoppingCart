using Ardalis.GuardClauses;
using ShoppingCart.Core.Enums;
using ShoppingCart.Core.Exceptions;

namespace ShoppingCart.Core.CartAggregate.Guards
{
    public static class CartGuardExtensions
    {
        public static void DuplicateCartItem(this IGuardClause guardClause, IEnumerable<CartItem> existingCartItems, CartItem newCartItem)
        {
            if (existingCartItems.Any(i => i.Id == newCartItem.Id))
            {
                throw new DomainException($"Item with id {newCartItem.Id} already exists in cart.");
            }
        }

        public static void NotFoundCartItem(this IGuardClause guardClause, IEnumerable<CartItem> existingCartItems, CartItem newCartItem)
        {
            if (!existingCartItems.Any(i => i.Id == newCartItem.Id))
            {
                throw new DomainException($"Item with id {newCartItem.Id} not found in cart.");
            }
        }

        public static void ValidStatusChange(this IGuardClause guardClause, CartStatus oldStatus, CartStatus newStatus)
        {
            if (oldStatus == newStatus)
            {
                throw new DomainException($"Can not change status! Cart is already in status {oldStatus}.");
            }
            else if (CartStatus.Expired == oldStatus)
            {
                throw new DomainException($"Can not change status! Cart is exired.");
            }
        }
    }
}
