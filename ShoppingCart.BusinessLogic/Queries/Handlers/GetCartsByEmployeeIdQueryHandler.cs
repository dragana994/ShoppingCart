using MediatR;
using ShoppingCart.BusinessLogic.Specifications;
using ShoppingCart.Core.CartAggregate;
using ShoppingCart.SharedKernel.Interfaces;

namespace ShoppingCart.BusinessLogic.Queries.Handlers
{
    public class GetCartsByEmployeeIdQueryHandler : IRequestHandler<GetCartsByEmployeeIdQuery, IEnumerable<Cart>>
    {
        private readonly IGenericRepository<Cart, Guid> _repository;

        public GetCartsByEmployeeIdQueryHandler(IGenericRepository<Cart, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Cart>> Handle(GetCartsByEmployeeIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new CartByEmployeeIdSpecification(request.EmployeeId);
            var carts = await _repository.GetListAsync(specification);

            return carts;
        }
    }
}
