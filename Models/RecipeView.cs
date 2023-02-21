using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace WAD_CW.Models
{
    public class RecipeView
    {
        public string RecipeName { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public int CookingTime { get; set; }
        public int ServingSize { get; set; }
        public int CategoryId { get; set; }
        public IFormFile Image { get; set; }
    }
}
