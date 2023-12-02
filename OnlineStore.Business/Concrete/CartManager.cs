using OnlineStore.Business.Abstract;
using OnlineStore.DataAccess.Abstract;
using OnlineStore.Entities;
using System;
using System.Linq;

namespace OnlineStore.Business.Concrete
{
    public class CartManager : ICartService
    {
        private ICartRepository _cartRepository;
        private ICartItemRepository _cartItemRepository;
        private IProductRepository _productRepository;

        public CartManager(ICartRepository cartRepository, ICartItemRepository cartItemRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
        }

        public Cart GetCartByUserId(Guid userId)
        {
            return _cartRepository.GetCartByUserId(userId);
        }

        public Cart AddToCart(Guid userId, int productId, int quantity)
        {
            var cart = GetCartByUserId(userId);
            var product = _productRepository.GetProductById(productId);
            if (product == null)
                throw new Exception("Product not found.");

            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                _cartRepository.CreateCart(cart);
            }

            var cartItems = _cartItemRepository.GetItemsByCartId(cart.Id); // Tüm cart itemları al
            var cartItem = cartItems.FirstOrDefault(i => i.ProductId == productId); // İlgili ürün ID'sine sahip olanı bul

            if (cartItem == null)
            {
                cartItem = new CartItem { CartId = cart.Id, ProductId = productId, Quantity = quantity };
                _cartItemRepository.CreateCartItem(cartItem);
            }
            else
            {
                cartItem.Quantity += quantity;
                _cartItemRepository.UpdateCartItem(cartItem);
            }

            return cart;
        }


        public void RemoveCart(Guid cartId)
        {
            var cart = _cartRepository.GetCartById(cartId);
            if (cart == null)
            {
                throw new Exception("Cart not found.");
            }

            var cartItems = _cartItemRepository.GetItemsByCartId(cartId);
            foreach (var cartItem in cartItems)
            {
                _cartItemRepository.DeleteCartItem(cartItem);
            }

            // Save changes after deleting cart items
            _cartItemRepository.SaveChanges();

            _cartRepository.DeleteCart(cartId);

            _cartRepository.SaveChanges();
        }


        public void UpdateCart(Guid userId, int productId, int quantity)
        {
            var cart = _cartRepository.GetCartByUserId(userId);
            if (cart == null)
            {
                throw new Exception("Cart not found.");
            }

            var cartItems = _cartItemRepository.GetItemsByCartId(cart.Id);
            var cartItem = cartItems.FirstOrDefault(i => i.ProductId == productId);
            if (cartItem == null)
            {
                throw new Exception("Product not found in the cart.");
            }

            cartItem.Quantity = quantity;
            _cartItemRepository.UpdateCartItem(cartItem);
        }


    }
}
