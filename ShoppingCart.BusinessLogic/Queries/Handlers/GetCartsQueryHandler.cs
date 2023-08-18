﻿using MediatR;
using ShoppingCart.Core.CartAggregate;
using ShoppingCart.SharedKernel.Interfaces;

namespace ShoppingCart.BusinessLogic.Queries.Handlers
{
    public class GetCartsQueryHandler : IRequestHandler<GetCartsQuery, IEnumerable<Cart>>
    {
        private readonly IGenericRepository<Cart, Guid> _repository;

        public GetCartsQueryHandler(IGenericRepository<Cart, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Cart>> Handle(GetCartsQuery request, CancellationToken cancellationToken)
        {
            var carts = await _repository.GetListAsync();

            return carts;
        }
    }
}
