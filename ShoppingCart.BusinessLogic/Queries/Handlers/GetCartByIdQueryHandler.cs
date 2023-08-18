﻿using MediatR;
using ShoppingCart.Core.CartAggregate;
using ShoppingCart.SharedKernel.Interfaces;

namespace ShoppingCart.BusinessLogic.Queries.Handlers
{
    public class GetCartByIdQueryHandler : IRequestHandler<GetCartByIdQuery, Cart>
    {
        private readonly IGenericRepository<Cart, Guid> _repository;

        public GetCartByIdQueryHandler(IGenericRepository<Cart, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<Cart> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
        {
            var cart = await _repository.GetByIdAsync(request.Id);

            return cart;
        }
    }
}
