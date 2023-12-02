using OnlineStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Business.Abstract
{
    public interface ICartItemService
    {
        void RemoveCartItem(Guid cartId, int productId);
        IEnumerable<CartItemDto> GetCartItemsByCartId(Guid cartId);
    }
}