using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using WADAPI.Models;
using WADAPI.Repository;


namespace WADAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRepository<Recipes> _recipesRepository;
        private readonly IFileService _fileService;
        public RecipesController(IRepository<Recipes> recipesRepository, 
            IFileService fileService)
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
        public IActionResult Post([FromBody] Recipes recipe)
        {
            var newRecipe = new Recipes();
            using (var scope = new TransactionScope())
            {
                        newRecipe = new Recipes()
                        {
                            CookingTime = recipe.CookingTime,
                            Description = recipe.Description,
                            Ingredients = recipe.Ingredients,
                            RecipeName = recipe.RecipeName,
                            ServingSize = recipe.ServingSize,
                            UserId = recipe.UserId,
                            CategoryId = recipe.CategoryId
                        };
                        _recipesRepository.Add(newRecipe);
                        
                    scope.Complete();
            }
            return CreatedAtAction(nameof(Get), new { id = recipe.UserId }, newRecipe);
        }
        // PUT: api/Recipes/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Recipes recipe, int id)
        {
            if (recipe != null)
            {
                using var scope = new TransactionScope();
                _recipesRepository.Update(recipe, id);
                scope.Complete();
                return new OkResult();
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
