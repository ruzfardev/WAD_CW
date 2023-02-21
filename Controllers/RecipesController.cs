using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WAD_CW.DAL;
using WAD_CW.Models;
using WAD_CW.Repository;

namespace WAD_CW.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRepository _recipesService;

        public RecipesController(IRepository service)
        {
            _recipesService = service;
        }
        // GET: Recipes
        public ActionResult Index()
        {
            var allRecipes = _recipesService.GetAll();
            return View(allRecipes);
        }

        // GET: Recipes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Recipes/Create
        public ActionResult Create()
        {
            // var categories = _recipesService.Categories.GetAll().Select(x=>x.Id);//all categories
            // ViewBag.Categories = categories;
            return View();//new List<Category>
        }

        // POST: Recipes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RecipeView recipe)
        {
            if (!ModelState.IsValid)
            {
                return View(recipe);
            }

            var imgURL = await FileHelper.SaveImage(recipe.Image);
            var newRecipe = new Recipes
            {
                RecipeName = recipe.RecipeName,
                Description = recipe.Description,
                Ingredients = recipe.Ingredients,
                CookingTime = recipe.CookingTime,
                ServingSize = recipe.ServingSize,
                UserId = 1,
                CategoryId = 1,
                Image = imgURL
            };
            _recipesService.Add(newRecipe);
            return RedirectToAction(nameof(Index));

        }

        // GET: Recipes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Recipes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Recipes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Recipes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
