using System.Collections.Generic;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using WADAPI.Models;
using WADAPI.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WADAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        // GET: api/Category
        [HttpGet]
        public IActionResult Get()
        {
            var category = _categoryRepository.GetAllCategories();
            return new OkObjectResult(category);
        }
        // GET: api/Category/5
        [HttpGet("{id}", Name = "GetC")]
        public IActionResult Get(int id)
        {
            var category = _categoryRepository.GetById(id);
            return new OkObjectResult(category);
        }
        // POST: api/Category
        [HttpPost]
        public IActionResult Post([FromBody] Categories category)
        {
            using (var scope = new TransactionScope())
            {
                _categoryRepository.Add(category);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = category.CategoryId }, category);
            }
        }
        // PUT: api/Category/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Categories category)
        {
            if (category != null)
            {
                using (var scope = new TransactionScope())
                {
                    _categoryRepository.Update(category);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryRepository.Delete(id);
            return new OkResult();
        }
    }
}
