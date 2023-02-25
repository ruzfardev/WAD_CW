using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WADAPI.Models
{
    public class Recipes
    {
        [Key] public int Id { get; set; }
        public string RecipeName { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public int CookingTime { get; set; }
        public int ServingSize { get; set; }
        public Users User { get; set; }
        public Categories Category { get; set; }
        public string Image { get; set; }
    }
}

