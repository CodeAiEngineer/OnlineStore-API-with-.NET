using OnlineStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OnlineStore.DataAccess.Abstract
{
    public interface ICartRepository
    {
        List<Cart> GetAllCarts();
        Cart GetCartByUserId(Guid userId);
        Cart CreateCart(Cart cart);
        Cart UpdateCart(Cart cart);
        Cart GetCartById(Guid cartId);
        void DeleteCart(Guid userId);
        void SaveChanges();
    }

}