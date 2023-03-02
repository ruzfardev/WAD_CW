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
    public class RecipesController : ControllerBase
    {
        private readonly IRepository<Recipes> _recipesRepository;
        private readonly IFileService _fileService;
        public RecipesController(IRepository<Recipes> recipesRepository, IFileService fileService)
        {
            _recipesRepository = recipesRepository;
            _fileService = fileService;
        }
        // GET: api/Recipes
        [HttpGet]
        public IActionResult Get()
        {
            var recipes = _recipesRepository.GetAll();
            return new OkObjectResult(recipes);
        }
        // GET: api/Recipes/5
        [HttpGet, Route("{id}", Name = "GetR")]
        public IActionResult Get(int id)
        {
            var recipe = _recipesRepository.GetById(id);
            return new OkObjectResult(recipe);
        }
        // POST: api/Recipes
        [HttpPost]
        public IActionResult Post([FromForm] Recipes recipe)
        {
            using (var scope = new TransactionScope())
            {
                if (recipe.ImageFile != null)
                {
                    var fileResult = _fileService.SaveImage(recipe.ImageFile);
                    if (fileResult.Item1 == 1)
                    {
                        recipe.Image = fileResult.Item2; // getting name of image
                    }
                    _recipesRepository.Add(recipe);
                    scope.Complete();
                }
                
                return CreatedAtAction(nameof(Get), new { id = recipe.Id }, recipe);
            }
        }
        // PUT: api/Recipes/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Recipes recipe)
        {
            if (recipe != null)
            {
                using (var scope = new TransactionScope())
                {
                    _recipesRepository.Update(recipe);
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
            _recipesRepository.Delete(id);
            return new OkResult();
        }
    }
}
