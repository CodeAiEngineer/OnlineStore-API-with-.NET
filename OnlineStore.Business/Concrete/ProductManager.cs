using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Business.Abstract;
using OnlineStore.DataAccess.Abstract;
using OnlineStore.Entities;


namespace OnlineStore.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product CreateProduct(Product product)
        {
            // Ürün adının benzersiz olup olmadığını kontrol et
            if (IsDuplicateProductName(product.Name))
            {
                throw new Exception("Aynı isimde bir ürün zaten mevcut.");
            }

            return _productRepository.CreateProduct(product);
        }

        public Product UpdateProduct(Product product)
        {
            return _productRepository.UpdateProduct(product);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        private bool IsDuplicateProductName(string productName, int? productId = null)
        {
            // Ürün adını kullanarak mevcut ürünleri veritabanında kontrol et
            var existingProduct = _productRepository.GetProductByName(productName);

            // Ürün adı benzersiz olmalı, aynı isimde bir ürün varsa ve farklı bir ürünse true döndür
            return existingProduct != null && (productId == null || existingProduct.Id != productId);
        }


    }
}
