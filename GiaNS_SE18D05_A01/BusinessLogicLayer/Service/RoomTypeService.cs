using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Extensions;
// Xóa dòng: using BusinessLogicLayer.Service;
using DataAccessLayer.Repositories;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.Services
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IRoomRepository _roomRepository;

        public RoomTypeService(IRoomTypeRepository roomTypeRepository, IRoomRepository roomRepository)
        {
            _roomTypeRepository = roomTypeRepository ?? throw new ArgumentNullException(nameof(roomTypeRepository));
            _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
        }

        public IEnumerable<RoomTypeDto> GetAllRoomTypes()
        {
            var roomTypes = _roomTypeRepository.GetAll();
            return roomTypes.Select(rt =>
            {
                var roomCount = _roomRepository.GetByRoomType(rt.RoomTypeID).Count();
                return rt.ToDto(roomCount);
            });
        }

        public RoomTypeDto? GetRoomTypeById(int id)
        {
            if (id <= 0) return null;

            var roomType = _roomTypeRepository.GetById(id);
            if (roomType == null) return null;

            var roomCount = _roomRepository.GetByRoomType(id).Count();
            return roomType.ToDto(roomCount);
        }

        public RoomTypeDto? GetRoomTypeByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;

            var roomType = _roomTypeRepository.GetByName(name);
            if (roomType == null) return null;

            var roomCount = _roomRepository.GetByRoomType(roomType.RoomTypeID).Count();
            return roomType.ToDto(roomCount);
        }

        public void CreateRoomType(RoomTypeDto roomTypeDto)
        {
            if (roomTypeDto == null)
                throw new ArgumentNullException(nameof(roomTypeDto));

            if (!ValidateRoomType(roomTypeDto, out List<string> errors))
                throw new ValidationException(string.Join("; ", errors));

            if (IsRoomTypeNameExists(roomTypeDto.RoomTypeName))
                throw new InvalidOperationException("Room type name already exists");

            roomTypeDto.RoomTypeID = 0; // Will be auto-generated

            var roomType = roomTypeDto.ToEntity();
            if (roomType != null)
                _roomTypeRepository.Add(roomType);
        }

        public void UpdateRoomType(RoomTypeDto roomTypeDto)
        {
            if (roomTypeDto == null)
                throw new ArgumentNullException(nameof(roomTypeDto));

            if (!ValidateRoomType(roomTypeDto, out List<string> errors))
                throw new ValidationException(string.Join("; ", errors));

            if (IsRoomTypeNameExists(roomTypeDto.RoomTypeName, roomTypeDto.RoomTypeID))
                throw new InvalidOperationException("Room type name already exists");

            var roomType = roomTypeDto.ToEntity();
            if (roomType != null)
                _roomTypeRepository.Update(roomType);
        }

        public void DeleteRoomType(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid room type ID");

            if (!CanDeleteRoomType(id, out string reason))
                throw new InvalidOperationException(reason);

            _roomTypeRepository.Delete(id);
        }

        public IEnumerable<RoomTypeDto> SearchRoomTypes(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return GetAllRoomTypes();

            var roomTypes = _roomTypeRepository.SearchByName(searchTerm);
            return roomTypes.Select(rt =>
            {
                var roomCount = _roomRepository.GetByRoomType(rt.RoomTypeID).Count();
                return rt.ToDto(roomCount);
            });
        }

        public bool IsRoomTypeNameExists(string name, int excludeRoomTypeId = 0)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;

            var existingRoomType = _roomTypeRepository.GetByName(name);
            return existingRoomType != null && existingRoomType.RoomTypeID != excludeRoomTypeId;
        }

        public bool ValidateRoomType(RoomTypeDto roomType, out List<string> errors)
        {
            errors = new List<string>();

            if (roomType == null)
            {
                errors.Add("Room type data is required");
                return false;
            }

            // Validate using Data Annotations
            var validationContext = new ValidationContext(roomType);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(roomType, validationContext, validationResults, true))
            {
                errors.AddRange(validationResults.Where(vr => vr.ErrorMessage != null).Select(vr => vr.ErrorMessage!));
            }

            return errors.Count == 0;
        }

        public bool CanDeleteRoomType(int roomTypeId, out string reason)
        {
            reason = string.Empty;

            var roomsUsingType = _roomRepository.GetByRoomType(roomTypeId);
            if (roomsUsingType.Any())
            {
                reason = $"Cannot delete room type. There are {roomsUsingType.Count()} rooms using this type.";
                return false;
            }

            return true;
        }
    }
}
