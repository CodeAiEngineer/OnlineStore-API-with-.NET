using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.DataAccess.Abstract;
using OnlineStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OnlineStore.DataAccess.Concrete
{
    public class CartRepository : ICartRepository
    {
        private StoreDbContext _context;
        public CartRepository(StoreDbContext context)
        {
            _context = context;
        }

        public List<Cart> GetAllCarts()
        {
            return _context.Carts.ToList();
        }

        public Cart GetCartByUserId(Guid userId)
        {
            return _context.Carts.FirstOrDefault(c => c.UserId == userId);
        }

        public Cart CreateCart(Cart cart)
        {
            _context.Carts.Add(cart);
            _context.SaveChanges();
            return cart;
        }

        public Cart UpdateCart(Cart cart)
        {
            _context.Carts.Update(cart);
            _context.SaveChanges();
            return cart;
        }

        public void DeleteCart(Guid cartId)
        {
            var cart = GetCartById(cartId);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
                _context.SaveChanges();
            }
        }



        public Cart GetCartById(Guid cartId)
        {
            return _context.Carts.FirstOrDefault(c => c.Id == cartId);
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }




}

