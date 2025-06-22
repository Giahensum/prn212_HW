using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Extensions
{
    public static class MappingExtensions
    {
        // Customer mappings
        public static CustomerDto? ToDto(this Customer? customer)
        {
            if (customer == null) return null;

            return new CustomerDto
            {
                CustomerID = customer.CustomerID,
                CustomerFullName = customer.CustomerFullName,
                Telephone = customer.Telephone,
                EmailAddress = customer.EmailAddress,
                CustomerBirthday = customer.CustomerBirthday,
                CustomerStatus = customer.CustomerStatus,
                Password = customer.Password
            };
        }

        public static Customer? ToEntity(this CustomerDto? dto)
        {
            if (dto == null) return null;

            return new Customer
            {
                CustomerID = dto.CustomerID,
                CustomerFullName = dto.CustomerFullName,
                Telephone = dto.Telephone,
                EmailAddress = dto.EmailAddress,
                CustomerBirthday = dto.CustomerBirthday,
                CustomerStatus = dto.CustomerStatus,
                Password = dto.Password
            };
        }

        // Room mappings
        public static RoomDto? ToDto(this RoomInformation? room, string? roomTypeName = null)
        {
            if (room == null) return null;

            return new RoomDto
            {
                RoomID = room.RoomID,
                RoomNumber = room.RoomNumber,
                RoomDescription = room.RoomDescription,
                RoomMaxCapacity = room.RoomMaxCapacity,
                RoomStatus = room.RoomStatus,
                RoomPricePerDate = room.RoomPricePerDate,
                RoomTypeID = room.RoomTypeID,
                RoomTypeName = roomTypeName ?? string.Empty
            };
        }

        public static RoomInformation? ToEntity(this RoomDto? dto)
        {
            if (dto == null) return null;

            return new RoomInformation
            {
                RoomID = dto.RoomID,
                RoomNumber = dto.RoomNumber,
                RoomDescription = dto.RoomDescription,
                RoomMaxCapacity = dto.RoomMaxCapacity,
                RoomStatus = dto.RoomStatus,
                RoomPricePerDate = dto.RoomPricePerDate,
                RoomTypeID = dto.RoomTypeID
            };
        }

        // RoomType mappings
        public static RoomTypeDto? ToDto(this RoomType? roomType, int roomCount = 0)
        {
            if (roomType == null) return null;

            return new RoomTypeDto
            {
                RoomTypeID = roomType.RoomTypeID,
                RoomTypeName = roomType.RoomTypeName,
                TypeDescription = roomType.TypeDescription,
                TypeNote = roomType.TypeNote,
                RoomCount = roomCount
            };
        }

        public static RoomType? ToEntity(this RoomTypeDto? dto)
        {
            if (dto == null) return null;

            return new RoomType
            {
                RoomTypeID = dto.RoomTypeID,
                RoomTypeName = dto.RoomTypeName,
                TypeDescription = dto.TypeDescription,
                TypeNote = dto.TypeNote
            };
        }
    }
}
