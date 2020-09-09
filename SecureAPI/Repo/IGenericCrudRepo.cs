using System.Collections.Generic;
using SecureAPI.Models;

namespace SecureAPI.Repo
{
    public interface IGenericCrudRepo<T>
    {
        public IEnumerable<T> GetAll();
        public T GetById(int id);
        public void Create(T model);
        public void Update(int id);
        public void Delete(T model);
        public bool SaveChanges();
    }
}