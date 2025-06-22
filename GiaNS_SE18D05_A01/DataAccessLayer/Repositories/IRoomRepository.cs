using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public interface IRoomRepository : IRepository<RoomInformation>
    {
        RoomInformation GetByRoomNumber(string roomNumber);
        IEnumerable<RoomInformation> GetByRoomType(int roomTypeId);
        IEnumerable<RoomInformation> GetAvailableRooms();
        IEnumerable<RoomInformation> SearchByNumber(string roomNumber);
        IEnumerable<RoomInformation> GetActiveRooms();
    }
}

