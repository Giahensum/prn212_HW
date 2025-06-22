using DataAccessLayer.Models;
using DataAccessLayer.Data;

namespace DataAccessLayer.Repositories
{
    public class RoomTypeRepository : BaseRepository<RoomType>, IRoomTypeRepository
    {
        protected override List<RoomType> GetDbSet()
        {
            return _context.RoomTypes;
        }

        protected override int GetEntityId(RoomType entity)
        {
            return entity.RoomTypeID;
        }

        protected override void SetEntityId(RoomType entity, int id)
        {
            entity.RoomTypeID = id;
        }

        public RoomType GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return null;

            return _dbSet.FirstOrDefault(rt =>
                rt.RoomTypeName.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<RoomType> SearchByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return GetAll();

            return _dbSet.Where(rt =>
                rt.RoomTypeName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
