using System.Collections.Generic;
using SecureAPI.Models;

namespace SecureAPI.Dtos.GenreDtos
{
    public class GenreReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string NotableDirectors { get; set; }
        // public List<Movie> Movies { get; set; }
    }
}