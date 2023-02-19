using System.ComponentModel.DataAnnotations;

namespace WAD_CW.Models
{
    public class Categories
    {
        [Key] public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
