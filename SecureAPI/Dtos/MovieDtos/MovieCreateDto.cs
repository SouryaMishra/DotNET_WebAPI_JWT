using System.ComponentModel.DataAnnotations;

namespace SecureAPI.Dtos.MovieDtos
{
    public class MovieCreateDto
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        public int ReleasedIn { get; set; }
        [Required]
        [MaxLength(200)]
        public string Director { get; set; }
        [Required]
        [MaxLength(200)]
        public string Languages { get; set; }
        [Required]
        public int GenreId { get; set; }
        // public Genre Genre { get; set; }

    }
}