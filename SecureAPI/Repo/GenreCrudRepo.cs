using System.Collections.Generic;
using SecureAPI.Contexts;
using SecureAPI.Models;
using System.Linq;

namespace SecureAPI.Repo
{
    public class GenreCrudRepo : IGenericCrudRepo<Genre>
    {
        private readonly MovieContext context;

        public GenreCrudRepo(MovieContext context)
        {
            this.context = context;
        }
        public void Create(Genre model)
        {
            this.context.Genres.Add(model);
        }

        public void Delete(Genre model)
        {
            this.context.Genres.Remove(model);
        }

        public IEnumerable<Genre> GetAll()
        {
            return this.context.Genres.ToList();
        }

        public Genre GetById(int id)
        {
            return this.context.Genres.ToList().Where(genre => genre.Id == id).FirstOrDefault();
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