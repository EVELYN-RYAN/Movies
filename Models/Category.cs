using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
    public class Category
    {
        [Key]
        [Required(ErrorMessage = "Category is required")]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
