using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Extensions;
using DataAccessLayer.Repositories;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IRoomTypeRepository _roomTypeRepository;

        public RoomService(IRoomRepository roomRepository, IRoomTypeRepository roomTypeRepository)
        {
            _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
            _roomTypeRepository = roomTypeRepository ?? throw new ArgumentNullException(nameof(roomTypeRepository));
        }

        public IEnumerable<RoomDto> GetAllRooms()
        {
            var rooms = _roomRepository.GetAll();
            var roomTypes = _roomTypeRepository.GetAll().ToDictionary(rt => rt.RoomTypeID, rt => rt.RoomTypeName);

            return rooms.Select(r => r.ToDto(roomTypes.GetValueOrDefault(r.RoomTypeID, "Unknown")));
        }

        public RoomDto GetRoomById(int id)
        {
            if (id <= 0) return null;

            var room = _roomRepository.GetById(id);
            if (room == null) return null;

            var roomType = _roomTypeRepository.GetById(room.RoomTypeID);
            return room.ToDto(roomType?.RoomTypeName);
        }

        public RoomDto GetRoomByNumber(string roomNumber)
        {
            if (string.IsNullOrWhiteSpace(roomNumber)) return null;

            var room = _roomRepository.GetByRoomNumber(roomNumber);
            if (room == null) return null;

            var roomType = _roomTypeRepository.GetById(room.RoomTypeID);
            return room.ToDto(roomType?.RoomTypeName);
        }

        public void CreateRoom(RoomDto roomDto)
        {
            if (roomDto == null)
                throw new ArgumentNullException(nameof(roomDto));

            if (!ValidateRoom(roomDto, out List<string> errors))
                throw new ValidationException(string.Join("; ", errors));

            if (IsRoomNumberExists(roomDto.RoomNumber))
                throw new InvalidOperationException("Room number already exists");

            roomDto.RoomID = 0; // Will be auto-generated
            roomDto.RoomStatus = 1; // Active

            var room = roomDto.ToEntity();
            _roomRepository.Add(room);
        }

        public void UpdateRoom(RoomDto roomDto)
        {
            if (roomDto == null)
                throw new ArgumentNullException(nameof(roomDto));

            if (!ValidateRoom(roomDto, out List<string> errors))
                throw new ValidationException(string.Join("; ", errors));

            if (IsRoomNumberExists(roomDto.RoomNumber, roomDto.RoomID))
                throw new InvalidOperationException("Room number already exists");

            var room = roomDto.ToEntity();
            _roomRepository.Update(room);
        }

        public void DeleteRoom(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid room ID");

            _roomRepository.Delete(id);
        }

        public IEnumerable<RoomDto> SearchRooms(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return GetActiveRooms();

            var rooms = _roomRepository.SearchByNumber(searchTerm);
            var roomTypes = _roomTypeRepository.GetAll().ToDictionary(rt => rt.RoomTypeID, rt => rt.RoomTypeName);

            return rooms.Select(r => r.ToDto(roomTypes.GetValueOrDefault(r.RoomTypeID, "Unknown")));
        }

        public IEnumerable<RoomDto> GetActiveRooms()
        {
            var rooms = _roomRepository.GetActiveRooms().OrderByDescending(r => r.RoomID);
            var roomTypes = _roomTypeRepository.GetAll().ToDictionary(rt => rt.RoomTypeID, rt => rt.RoomTypeName);

            return rooms.Select(r => r.ToDto(roomTypes.GetValueOrDefault(r.RoomTypeID, "Unknown")));
        }

        public IEnumerable<RoomDto> GetRoomsByType(int roomTypeId)
        {
            var rooms = _roomRepository.GetByRoomType(roomTypeId);
            var roomType = _roomTypeRepository.GetById(roomTypeId);

            return rooms.Select(r => r.ToDto(roomType?.RoomTypeName));
        }

        public IEnumerable<RoomDto> GetAvailableRooms()
        {
            var rooms = _roomRepository.GetAvailableRooms();
            var roomTypes = _roomTypeRepository.GetAll().ToDictionary(rt => rt.RoomTypeID, rt => rt.RoomTypeName);

            return rooms.Select(r => r.ToDto(roomTypes.GetValueOrDefault(r.RoomTypeID, "Unknown")));
        }

        public bool IsRoomNumberExists(string roomNumber, int excludeRoomId = 0)
        {
            if (string.IsNullOrWhiteSpace(roomNumber)) return false;

            var existingRoom = _roomRepository.GetByRoomNumber(roomNumber);
            return existingRoom != null && existingRoom.RoomID != excludeRoomId;
        }

        public bool ValidateRoom(RoomDto room, out List<string> errors)
        {
            errors = new List<string>();

            if (room == null)
            {
                errors.Add("Room data is required");
                return false;
            }

            // Validate using Data Annotations
            var validationContext = new ValidationContext(room);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(room, validationContext, validationResults, true))
            {
                errors.AddRange(validationResults.Select(vr => vr.ErrorMessage));
            }

            // Additional business rules
            var roomType = _roomTypeRepository.GetById(room.RoomTypeID);
            if (roomType == null)
            {
                errors.Add("Invalid room type selected");
            }

            return errors.Count == 0;
        }

        public Dictionary<string, int> GetRoomStatistics()
        {
            var rooms = _roomRepository.GetAll();
            var roomTypes = _roomTypeRepository.GetAll().ToDictionary(rt => rt.RoomTypeID, rt => rt.RoomTypeName);

            var stats = new Dictionary<string, int>
            {
                ["Total Rooms"] = rooms.Count(),
                ["Active Rooms"] = rooms.Count(r => r.RoomStatus == 1),
                ["Deleted Rooms"] = rooms.Count(r => r.RoomStatus == 2)
            };

            // Room type statistics
            foreach (var roomType in roomTypes)
            {
                var count = rooms.Count(r => r.RoomTypeID == roomType.Key && r.RoomStatus == 1);
                stats[roomType.Value] = count;
            }

            return stats;
        }
    }
}

