using Microsoft.EntityFrameworkCore;
using SecureAPI.Models;

namespace SecureAPI.Contexts
{
    public class GenreContext : DbContext
    {
        public GenreContext(DbContextOptions<GenreContext> options) : base(options)
        {

        }

        public DbSet<Genre> Genres { get; set; }
    }
}