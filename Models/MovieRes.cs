using System;
using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
    public class MovieRes
    {
        [Key]
        [Required]
        public int MovieID { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Movie title is required")]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        [Required]
        public bool Edited { get; set; }

        public string LentTo { get; set; }

        [MaxLength(25)] //limits to 25 characters
        public string Notes { get; set; }
        // Building foreign key relationship
        
        public Category Category { get; set; }
    }
}
