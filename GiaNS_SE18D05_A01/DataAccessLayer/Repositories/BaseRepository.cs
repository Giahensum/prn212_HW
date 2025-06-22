using System.Linq.Expressions;
using DataAccessLayer.Data;

namespace DataAccessLayer.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly HotelDbContext _context;
        protected readonly List<T> _dbSet;

        protected BaseRepository()
        {
            _context = HotelDbContext.Instance;
            _dbSet = GetDbSet();
        }

        protected abstract List<T> GetDbSet();
        protected abstract int GetEntityId(T entity);
        protected abstract void SetEntityId(T entity, int id);

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual T GetById(int id)
        {
            return _dbSet.FirstOrDefault(entity => GetEntityId(entity) == id);
        }

        public virtual T Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AsQueryable().FirstOrDefault(predicate);
        }

        public virtual IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AsQueryable().Where(predicate).ToList();
        }

        public virtual void Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            // Auto-generate ID if it's 0
            if (GetEntityId(entity) == 0)
            {
                int nextId = _dbSet.Count > 0 ? _dbSet.Max(e => GetEntityId(e)) + 1 : 1;
                SetEntityId(entity, nextId);
            }

            _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var existingEntity = GetById(GetEntityId(entity));
            if (existingEntity == null)
                throw new InvalidOperationException("Entity not found");

            var index = _dbSet.IndexOf(existingEntity);
            _dbSet[index] = entity;
        }

        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                Delete(entity);
            }
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _dbSet.Remove(entity);
        }

        public virtual IEnumerable<T> GetPaged(int page, int pageSize)
        {
            return _dbSet.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public virtual int Count()
        {
            return _dbSet.Count;
        }

        public virtual int Count(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AsQueryable().Count(predicate);
        }

        public virtual bool Exists(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AsQueryable().Any(predicate);
        }
    }
}
