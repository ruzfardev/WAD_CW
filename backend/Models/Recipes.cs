using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        [ForeignKey("UserId")] public int UserId { get; set; }
        [ForeignKey("CategoryId")] public int CategoryId { get; set; }
        public string Image { get; set; }
    }
}

