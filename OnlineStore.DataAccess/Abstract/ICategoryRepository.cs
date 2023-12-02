using OnlineStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess.Abstract
{
    public interface ICategoryRepository
    {
        List<Categories> GetAllCategories();

        Categories GetCategoriesById(int id);

        Categories CreateCategory(Categories categories);

        Categories UpdateCategory(Categories categories);

        void DeleteCategory(int id); 



    }
}
