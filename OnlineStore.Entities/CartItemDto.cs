using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CartItemDto.cs
namespace OnlineStore.Entities
{
    public class CartItemDto
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public float ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }
    }
}
