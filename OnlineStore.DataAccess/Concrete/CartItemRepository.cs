using OnlineStore.DataAccess.Abstract;
using OnlineStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.DataAccess.Concrete
{
    public class CartItemRepository : ICartItemRepository
    {
        private StoreDbContext _context;
        public CartItemRepository(StoreDbContext context)
        {
            _context = context;
        }

        public List<CartItem> GetAllCartItems()
        {
            return _context.CartItems.ToList();
        }



        public CartItem CreateCartItem(CartItem cartItem)
        {
            _context.CartItems.Add(cartItem);
            _context.SaveChanges();
            return cartItem;
        }

        public CartItem UpdateCartItem(CartItem cartItem)
        {
            _context.CartItems.Update(cartItem);
            _context.SaveChanges();
            return cartItem;
        }

        public IEnumerable<CartItem> GetItemsByCartId(Guid cartId)
        {
            return _context.CartItems.Where(ci => ci.CartId == cartId).ToList();
        }

        public CartItem GetCartItemByCartIdAndProductId(Guid cartId, int productId)
        {
            return _context.CartItems.FirstOrDefault(ci => ci.CartId == cartId && ci.ProductId == productId);
        }

        public void DeleteCartItem(CartItem cartItem)
        {
            _context.CartItems.Remove(cartItem);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<CartItemDto> GetCartItemsByCartId(Guid cartId)
        {
            return _context.CartItems
                           .Include(c => c.Product) // Product ile birlikte yükler
                           .Where(ci => ci.CartId == cartId)
                           .Select(ci => new CartItemDto // yeni DTO'ya çevirir
                           {
                               Id = ci.Id,
                               CartId = ci.CartId,
                               ProductId = ci.ProductId,
                               Quantity = ci.Quantity,
                               ProductPrice = ci.Product.Price,
                               ProductImageUrl = ci.Product.ImageUrl,
                           }).ToList();
        }


    }
    }
