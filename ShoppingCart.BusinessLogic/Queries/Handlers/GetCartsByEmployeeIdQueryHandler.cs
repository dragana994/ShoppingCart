using MediatR;
using ShoppingCart.BusinessLogic.Specifications;
using ShoppingCart.Core.CartAggregate;
using ShoppingCart.Infrastracture.Persistence;
using ShoppingCart.SharedKernel.Interfaces;

namespace ShoppingCart.BusinessLogic.Queries.Handlers
{
    public class GetCartsByEmployeeIdQueryHandler : IRequestHandler<GetCartsByEmployeeIdQuery, IEnumerable<Cart>>
    {
        private readonly IGenericRepository<Cart, Guid, ShoppingCartDbContext> _repository;

        public GetCartsByEmployeeIdQueryHandler(IGenericRepository<Cart, Guid, ShoppingCartDbContext> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Cart>> Handle(GetCartsByEmployeeIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new CartsByEmployeeIdSpecification(request.EmployeeId);
            var carts = await _repository.GetListAsync(specification);

            return carts;
        }
    }
}
