using System.Collections.Generic;

namespace eHealthApp.Services.Data
{
    public interface IDataService<T> where T : class
    {
        void Save(T entity);
        void Update(T entity);
        void Delete(T entity);
        T? GetById(int id);
        List<T> GetAll();
    }
}