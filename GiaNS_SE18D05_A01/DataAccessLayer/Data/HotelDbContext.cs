using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer.Models;

namespace DataAccessLayer.Data
{
    public class HotelDbContext
    {
        private static HotelDbContext? _instance;
        private static readonly object _lock = new object();

        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<RoomInformation> Rooms { get; set; } = new List<RoomInformation>();
        public List<RoomType> RoomTypes { get; set; } = new List<RoomType>();
        public Admin AdminAccount { get; set; } = new Admin();

        private HotelDbContext()
        {
            InitializeData();
        }

        public static HotelDbContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        _instance ??= new HotelDbContext();
                    }
                }
                return _instance;
            }
        }

        private void InitializeData()
        {
            // Initialize Admin Account
            AdminAccount = new Admin
            {
                EmailAddress = "admin@FUMiniHotelSystem.com",
                Password = "@@abc123@@"
            };

            // Initialize Room Types
            RoomTypes = new List<RoomType>
            {
                new RoomType { RoomTypeID = 1, RoomTypeName = "Standard", TypeDescription = "Basic room with essential amenities", TypeNote = "Most affordable option" },
                new RoomType { RoomTypeID = 2, RoomTypeName = "Deluxe", TypeDescription = "Spacious room with premium amenities", TypeNote = "Popular choice" },
                new RoomType { RoomTypeID = 3, RoomTypeName = "Suite", TypeDescription = "Luxury suite with separate living area", TypeNote = "Premium experience" },
                new RoomType { RoomTypeID = 4, RoomTypeName = "Presidential", TypeDescription = "Ultimate luxury with personal butler", TypeNote = "VIP treatment" }
            };

            // Initialize Rooms
            Rooms = new List<RoomInformation>
            {
                new RoomInformation { RoomID = 1, RoomNumber = "101", RoomDescription = "Standard room on first floor", RoomMaxCapacity = 2, RoomStatus = 1, RoomPricePerDate = 500000, RoomTypeID = 1 },
                new RoomInformation { RoomID = 2, RoomNumber = "102", RoomDescription = "Standard room with garden view", RoomMaxCapacity = 2, RoomStatus = 1, RoomPricePerDate = 550000, RoomTypeID = 1 },
                new RoomInformation { RoomID = 3, RoomNumber = "201", RoomDescription = "Deluxe room with city view", RoomMaxCapacity = 3, RoomStatus = 1, RoomPricePerDate = 800000, RoomTypeID = 2 },
                new RoomInformation { RoomID = 4, RoomNumber = "202", RoomDescription = "Deluxe room with balcony", RoomMaxCapacity = 4, RoomStatus = 1, RoomPricePerDate = 900000, RoomTypeID = 2 },
                new RoomInformation { RoomID = 5, RoomNumber = "301", RoomDescription = "Suite with living room", RoomMaxCapacity = 4, RoomStatus = 1, RoomPricePerDate = 1500000, RoomTypeID = 3 },
                new RoomInformation { RoomID = 6, RoomNumber = "401", RoomDescription = "Presidential suite", RoomMaxCapacity = 6, RoomStatus = 1, RoomPricePerDate = 3000000, RoomTypeID = 4 }
            };

            // Initialize Customers
            Customers = new List<Customer>
            {
                new Customer { CustomerID = 1, CustomerFullName = "Nguyen Van A", Telephone = "0123456789", EmailAddress = "nguyenvana@gmail.com", CustomerBirthday = new DateTime(1990, 1, 15), CustomerStatus = 1, Password = "123456" },
                new Customer { CustomerID = 2, CustomerFullName = "Tran Thi B", Telephone = "0987654321", EmailAddress = "tranthib@gmail.com", CustomerBirthday = new DateTime(1985, 5, 20), CustomerStatus = 1, Password = "password" },
                new Customer { CustomerID = 3, CustomerFullName = "Le Van C", Telephone = "0369852147", EmailAddress = "levanc@gmail.com", CustomerBirthday = new DateTime(1992, 8, 10), CustomerStatus = 1, Password = "abc123" }
            };
        }

        public int GetNextCustomerId()
        {
            return Customers.Count > 0 ? Customers.Max(c => c.CustomerID) + 1 : 1;
        }

        public int GetNextRoomId()
        {
            return Rooms.Count > 0 ? Rooms.Max(r => r.RoomID) + 1 : 1;
        }

        public int GetNextRoomTypeId()
        {
            return RoomTypes.Count > 0 ? RoomTypes.Max(rt => rt.RoomTypeID) + 1 : 1;
        }
    }
}
