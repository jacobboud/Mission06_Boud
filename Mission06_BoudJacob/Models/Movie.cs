using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_BoudJacob.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }

        public Category? Category { get; set; }

        [Required(ErrorMessage = "Sorry, you need to enter a movie title.")]
        public string Title { get; set; }

        // Limit year to a realistic range
        [Range(1888, 3000, ErrorMessage = "Sorry, you need to enter a valid year.")]
        public string Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        [Required(ErrorMessage = "Sorry, you need to enter if this has been edited.")]
        public bool Edited { get; set; }
        
        public string? LentTo { get; set; }

        [Required(ErrorMessage = "Sorry, you need to enter if this has been copied to Plex.")]
        public bool CopiedToPlex { get; set; }

        public string? Notes { get; set; }

    }
}
