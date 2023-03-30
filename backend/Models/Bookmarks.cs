using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WADAPI.Models
{
    public class Bookmarks
    {
        [Key] public int Id { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        [ForeignKey("RecipeId")]
        public int RecipeId { get; set; }
    }
}
