using OnlineStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Business.Abstract
{
    public interface ICartService
    {
        Cart GetCartByUserId(Guid userId);
        Cart AddToCart(Guid userId, int productId, int quantity);
        void RemoveCart(Guid cartId);
        void UpdateCart(Guid userId, int productId, int quantity);


    }

}