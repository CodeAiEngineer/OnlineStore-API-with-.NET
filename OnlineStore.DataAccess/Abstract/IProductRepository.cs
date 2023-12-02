using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Entities;


namespace OnlineStore.DataAccess.Abstract
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();

        Product GetProductById(int id);

        Product GetProductByName(string name);

        Product CreateProduct(Product product);

        Product UpdateProduct(Product product);

        void DeleteProduct(int id);
    }
}