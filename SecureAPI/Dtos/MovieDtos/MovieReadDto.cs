using System.ComponentModel.DataAnnotations;

namespace SecureAPI.Dtos.MovieDtos
{
    public class MovieReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int ReleasedIn { get; set; }

        public string Director { get; set; }

        public string Languages { get; set; }

        public int GenreId { get; set; }
        // public Genre Genre { get; set; }

    }
}