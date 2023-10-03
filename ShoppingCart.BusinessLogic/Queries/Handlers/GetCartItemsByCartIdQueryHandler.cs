using MediatR;
using ShoppingCart.BusinessLogic.Specifications;
using ShoppingCart.Core.CartAggregate;
using ShoppingCart.Infrastracture.Persistence;
using ShoppingCart.SharedKernel.Interfaces;

namespace ShoppingCart.BusinessLogic.Queries.Handlers
{
    public class GetCartItemsByCartIdQueryHandler : IRequestHandler<GetCartItemsByCartIdQuery, IEnumerable<CartItem>>
    {
        private readonly IGenericRepository<CartItem, Guid, ShoppingCartDbContext> _repository;

        public GetCartItemsByCartIdQueryHandler(IGenericRepository<CartItem, Guid, ShoppingCartDbContext> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CartItem>> Handle(GetCartItemsByCartIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new CartItemsByCartIdSpecification(request.CartId);
            var cartItems = await _repository.GetListAsync(specification);

            return cartItems;
        }
    }
}
