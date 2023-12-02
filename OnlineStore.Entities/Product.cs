using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AmountInStock { get; set; }
        public float Price { get; set; }
        public bool InStock { get; set; } = true;
        public int CategoriesId { get; set; }
        // public Categories Categories { get; set; }
        public string ImageUrl { get; set; }

        public virtual List<CartItem> CartItems { get; set; } // virtual keyword added
    }

}
