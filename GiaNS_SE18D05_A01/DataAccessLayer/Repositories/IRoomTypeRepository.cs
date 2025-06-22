using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public interface IRoomTypeRepository : IRepository<RoomType>
    {
        RoomType GetByName(string name);
        IEnumerable<RoomType> SearchByName(string name);
    }
}

