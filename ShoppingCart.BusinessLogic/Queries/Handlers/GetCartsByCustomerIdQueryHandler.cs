using MediatR;
using ShoppingCart.BusinessLogic.Specifications;
using ShoppingCart.Core.CartAggregate;
using ShoppingCart.Infrastracture.Persistence;
using ShoppingCart.SharedKernel.Interfaces;

namespace ShoppingCart.BusinessLogic.Queries.Handlers
{
    public class GetCartsByCustomerIdQueryHandler : IRequestHandler<GetCartsByCustomerIdQuery, IEnumerable<Cart>>
    {
        private readonly IGenericRepository<Cart, Guid, ShoppingCartDbContext> _repository;

        public GetCartsByCustomerIdQueryHandler(IGenericRepository<Cart, Guid, ShoppingCartDbContext> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Cart>> Handle(GetCartsByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new CartsByCustomerIdSpecification(request.CustomerId);
            var carts = await _repository.GetListAsync(specification);

            return carts;
        }
    }
}
