using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq.Expressions;

namespace DataAccessLayer.Repositories
{
    public interface IRepository<T> where T : class
    {
        // Basic CRUD operations
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Find(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void Delete(T entity);

        // Advanced operations
        IEnumerable<T> GetPaged(int page, int pageSize);
        int Count();
        int Count(Expression<Func<T, bool>> predicate);
        bool Exists(Expression<Func<T, bool>> predicate);
    }
}

