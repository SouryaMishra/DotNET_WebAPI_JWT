using System.ComponentModel.DataAnnotations;

namespace SecureAPI.Dtos.GenreDtos
{
    public class GenreUpdateDto
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        [Required]
        [MaxLength(200)]
        public string NotableDirectors { get; set; }
        //public List<Movie> Movies { get; set; }
    }
}