using System.Collections.Generic;
using SecureAPI.Models;

namespace SecureAPI.Repo
{
    public interface IGenericCrudRepo<T>
    {
        public IEnumerable<T> GetAll();
        public T GetById(int id);
        public T Create(T model);
        public void Update(int id);
        public void Delete(T model);
        public bool SaveChanges();
        public IEnumerable<Movie> GetAllMoviesByGenreId(int genreId);
        public Movie GetMovieByGenreIdAndMovieId(int genreId, int movieId);
    }
}