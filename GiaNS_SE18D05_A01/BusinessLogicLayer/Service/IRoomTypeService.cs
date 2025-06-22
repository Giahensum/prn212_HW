using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Services
{
    public interface IRoomTypeService
    {
        // CRUD operations
        IEnumerable<RoomTypeDto> GetAllRoomTypes();
        RoomTypeDto GetRoomTypeById(int id);
        RoomTypeDto GetRoomTypeByName(string name);
        void CreateRoomType(RoomTypeDto roomType);
        void UpdateRoomType(RoomTypeDto roomType);
        void DeleteRoomType(int id);

        // Search and filter
        IEnumerable<RoomTypeDto> SearchRoomTypes(string searchTerm);

        // Validation
        bool IsRoomTypeNameExists(string name, int excludeRoomTypeId = 0);
        bool ValidateRoomType(RoomTypeDto roomType, out List<string> errors);
        bool CanDeleteRoomType(int roomTypeId, out string reason);
    }
}
