using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Services
{
    public interface IRoomService
    {
        // CRUD operations
        IEnumerable<RoomDto> GetAllRooms();
        RoomDto GetRoomById(int id);
        RoomDto GetRoomByNumber(string roomNumber);
        void CreateRoom(RoomDto room);
        void UpdateRoom(RoomDto room);
        void DeleteRoom(int id);

        // Search and filter
        IEnumerable<RoomDto> SearchRooms(string searchTerm);
        IEnumerable<RoomDto> GetActiveRooms();
        IEnumerable<RoomDto> GetRoomsByType(int roomTypeId);
        IEnumerable<RoomDto> GetAvailableRooms();

        // Validation
        bool IsRoomNumberExists(string roomNumber, int excludeRoomId = 0);
        bool ValidateRoom(RoomDto room, out List<string> errors);

        // Statistics
        Dictionary<string, int> GetRoomStatistics();
    }
}

