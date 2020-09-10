using SecureAPI.Contexts;
using SecureAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace SecureAPI.Repo
{
    public class MovieCrudRepo : IGenericCrudRepo<Movie>
    {
        private readonly MovieContext context;

        public MovieCrudRepo(MovieContext context)
        {
            this.context = context;
        }
        public Movie Create(Movie model)
        {
            this.context.Movies.Add(model);
            if (this.SaveChanges())
            {
                return model;
            }
            else
            {
                return null;
            }
        }

        public void Delete(Movie model)
        {
            this.context.Movies.Remove(model);
        }

        public IEnumerable<Movie> GetAll()
        {
            return this.context.Movies.ToList();
        }

        public Movie GetById(int id)
        {
            return this.context.Movies.ToList().Where(movie => movie.Id == id).FirstOrDefault();
        }

        public IEnumerable<Movie> GetAllMoviesByGenreId(int genreId)
        {
            return this.context.Movies.ToList().Where(movie => movie.GenreId == genreId);
        }

        public Movie GetMovieByGenreIdAndMovieId(int genreId, int movieId)
        {
            return this.context.Movies.ToList().Where(movie => movie.GenreId == genreId && movie.Id == movieId).FirstOrDefault();
        }

        public bool SaveChanges()
        {
            return this.context.SaveChanges() >= 0;
        }

        public void Update(int id)
        {

        }
    }
}