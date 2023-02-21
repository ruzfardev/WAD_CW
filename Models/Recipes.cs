using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WAD_CW.Models
{
    public class Recipes
    {
        [Key] public int Id { get; set; }
        public string RecipeName { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public int CookingTime { get; set; }
        public int ServingSize { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public string Image { get; set; }
    }
}

