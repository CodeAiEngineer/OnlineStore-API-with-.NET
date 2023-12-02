using OnlineStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OnlineStore.DataAccess.Abstract
{
    public interface ICartItemRepository
    {
        List<CartItem> GetAllCartItems();

        CartItem CreateCartItem(CartItem cartItem);

        CartItem UpdateCartItem(CartItem cartItem);

        IEnumerable<CartItem> GetItemsByCartId(Guid cartId);

        CartItem GetCartItemByCartIdAndProductId(Guid cartId, int productId);

        void DeleteCartItem(CartItem cartItem);
        void SaveChanges();

        IEnumerable<CartItemDto> GetCartItemsByCartId(Guid cartId);

    }

}