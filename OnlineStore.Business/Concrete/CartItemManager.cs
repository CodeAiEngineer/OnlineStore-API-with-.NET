using OnlineStore.Business.Abstract;
using OnlineStore.DataAccess.Abstract;
using OnlineStore.Entities;
using System;
using System.Collections.Generic;

namespace OnlineStore.Business.Concrete
{
    public class CartItemManager : ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly ICartRepository _cartRepository;



        public CartItemManager(ICartItemRepository cartItemRepository, ICartRepository cartRepository)
        {
            _cartItemRepository = cartItemRepository;
            _cartRepository = cartRepository;
            
        }

        public void RemoveCartItem(Guid cartId, int productId)
        {
            var cartItem = _cartItemRepository.GetCartItemByCartIdAndProductId(cartId, productId);
            if (cartItem == null)
            {
                throw new Exception("CartItem not found.");
            }

            _cartItemRepository.DeleteCartItem(cartItem);
        }


        public IEnumerable<CartItemDto> GetCartItemsByCartId(Guid cartId)
        {
            return _cartItemRepository.GetCartItemsByCartId(cartId);
        }
    }
}


