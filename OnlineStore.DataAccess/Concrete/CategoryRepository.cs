using OnlineStore.DataAccess.Abstract;
using OnlineStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDbContext _context;

        public CategoryRepository(StoreDbContext context)
        {
            _context = context;
        }

        public Categories CreateCategory(Categories categories)
        {
            _context.Categories.Add(categories);
            _context.SaveChanges();
            return categories;
        }

        public void DeleteCategory(int id)
        {
            var deletedCategory = GetCategoriesById(id);
            _context.Categories.Remove(deletedCategory);
            _context.SaveChanges();
        }

        public List<Categories> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public Categories GetCategoriesById(int id)
        {
            return _context.Categories.Find(id);
        }

        public Categories UpdateCategory(Categories categories)
        {
            _context.Categories.Update(categories);
            _context.SaveChanges();
            return categories;
        }
    }
}
