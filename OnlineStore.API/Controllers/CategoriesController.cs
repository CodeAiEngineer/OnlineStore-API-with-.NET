using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Entities;
using System.Collections.Generic;

using OnlineStore.Business.Abstract;
using OnlineStore.Business.Concrete;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace OnlineStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet]
        public List<Categories> Get()
        {
            return _categoryService.GetAllCategories();


        }

        [HttpGet("{id}")]
        public Categories Get(int id)
        {
            return _categoryService.GetCategoriesById(id);


        }
        [Authorize(Roles = nameof(Role.Client))]
        [HttpPost]
        public Categories Post([FromBody]Categories category)
        {

            return _categoryService.CreateCategory(category);
        }

        [HttpPut]
        public Categories Put([FromBody] Categories category)
        {

            return _categoryService.UpdateCategory(category);
        }


        [HttpDelete]
        public void Delete(int id)
        {

             _categoryService.DeleteCategory(id);
        }





    }
}
