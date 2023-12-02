using System;

namespace OnlineStore.API.Models
{
    public class AddItemToCartDto
    {
        public Guid UserId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}
