using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Http;
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
        private readonly IRepository<Users> _usersRepository;
        private readonly IRepository<Categories> _categoriesRepository;
        private readonly IFileService _fileService;
        public RecipesController(IRepository<Recipes> recipesRepository, 
            IRepository<Users> usersRepository, 
            IRepository<Categories> categoriesRepository, 
            IFileService fileService)
        {
            _recipesRepository = recipesRepository;
            _usersRepository = usersRepository;
            _categoriesRepository = categoriesRepository;
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
        public IActionResult Post([FromForm] Recipes recipe, IFormFile image)
        {
            var newRecipe = new Recipes();
            using (var scope = new TransactionScope())
            {
                if (image != null)
                {
                   var fileResult = _fileService.SaveImage(image);
                    if (fileResult.Item1 == 1)
                    {
                        newRecipe = new Recipes()
                        {
                            Image = fileResult.Item2,
                            CookingTime = recipe.CookingTime,
                            Description = recipe.Description,
                            Ingredients = recipe.Ingredients,
                            RecipeName = recipe.RecipeName,
                            ServingSize = recipe.ServingSize,
                            UserId = recipe.UserId,
                            CategoryId = recipe.CategoryId
                        };
                        _recipesRepository.Add(newRecipe);

                    }
                    scope.Complete();
                }
                
            }
            return CreatedAtAction(nameof(Get), new { id = recipe.UserId }, newRecipe);
        }
        // PUT: api/Recipes/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Recipes recipe)
        {
            if (recipe != null)
            {
                using var scope = new TransactionScope();
                _recipesRepository.Update(recipe);
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
