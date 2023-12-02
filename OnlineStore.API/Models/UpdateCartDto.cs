using System;

namespace OnlineStore.API.Models
{
    public class UpdateCartDto
    {
        public Guid UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

}
