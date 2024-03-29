﻿using ShoppingCart.SharedKernel;

namespace ShoppingCart.Api.Requests
{
    public class ChangeCartItemQuantityRequest : BaseRequest
    {
        public Guid CartId { get; set; }
        public Guid CartItemId { get; set; }
        public int Quantity { get; set; }
    }
}
