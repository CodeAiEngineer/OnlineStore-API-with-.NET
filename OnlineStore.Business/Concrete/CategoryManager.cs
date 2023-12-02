using OnlineStore.Business.Abstract;
using OnlineStore.DataAccess.Abstract;
using OnlineStore.DataAccess.Concrete;
using OnlineStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Business.Concrete
{

    
    public class CategoryManager : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
             _categoryRepository = categoryRepository;
        }



        public Categories CreateCategory(Categories categories)
        {
            return _categoryRepository.CreateCategory(categories);
        }  

        public void DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
        }

        public List<Categories> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        public Categories GetCategoriesById(int id)
        {
            if (id>0)
            {
                return _categoryRepository.GetCategoriesById(id);

            }

            throw new Exception("id cannot be less than 1");
            
        }

        public Categories UpdateCategory(Categories categories)
        {
            return _categoryRepository.UpdateCategory(categories);
        }
    }
}
