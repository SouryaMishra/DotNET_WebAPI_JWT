using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecureAPI.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(300)")]
        public string NotableDirectors { get; set; }
        public List<Movie> Movies { get; set; }
    }
}