using Microsoft.EntityFrameworkCore;
using SecureAPI.Models;

namespace SecureAPI.Contexts
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}