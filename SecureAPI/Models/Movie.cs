using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecureAPI.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Title { get; set; }
        [Required]
        public int ReleasedIn { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Director { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Languages { get; set; }
        [Required]
        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
    }
}