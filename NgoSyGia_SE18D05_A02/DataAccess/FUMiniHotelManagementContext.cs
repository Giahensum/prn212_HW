using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class FUMiniHotelManagementContext : DbContext
    {
        public FUMiniHotelManagementContext() { }

        public FUMiniHotelManagementContext(DbContextOptions<FUMiniHotelManagementContext> options)
            : base(options) { }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<RoomInformation> RoomInformations { get; set; }
        public virtual DbSet<BookingReservation> BookingReservations { get; set; }
        public virtual DbSet<BookingDetail> BookingDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                try
                {
                    var config = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .Build();

                    var connectionString = config.GetConnectionString("DefaultConnection");

                    if (string.IsNullOrEmpty(connectionString))
                    {
                        connectionString = "Server=.;Database=FUMiniHotelManagement;User Id=sa;Password=1357910;TrustServerCertificate=true";
                    }

                    optionsBuilder.UseSqlServer(connectionString);
                }
                catch (Exception)
                {
                    var fallbackConnectionString = "Server=.;Database=FUMiniHotelManagement;User Id=sa;Password=1357910;TrustServerCertificate=true";
                    optionsBuilder.UseSqlServer(fallbackConnectionString);
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // FIX: Override table names to match database schema
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<RoomType>().ToTable("RoomType");
            modelBuilder.Entity<RoomInformation>().ToTable("RoomInformation");
            modelBuilder.Entity<BookingReservation>().ToTable("BookingReservation");
            modelBuilder.Entity<BookingDetail>().ToTable("BookingDetail");

            // Configure Customer
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerID);
                entity.Property(e => e.CustomerID).UseIdentityColumn(3, 1);
                entity.Property(e => e.EmailAddress).IsRequired().HasMaxLength(50);
                entity.HasIndex(e => e.EmailAddress).IsUnique();
                entity.Property(e => e.CustomerFullName).HasMaxLength(50);
                entity.Property(e => e.Telephone).HasMaxLength(12);
                entity.Property(e => e.Password).HasMaxLength(50);
                entity.Property(e => e.CustomerBirthday).HasColumnType("date");
                entity.Property(e => e.CustomerStatus).HasColumnType("tinyint");
            });

            // Configure RoomType
            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.HasKey(e => e.RoomTypeID);
                entity.Property(e => e.RoomTypeID).UseIdentityColumn(1, 1);
                entity.Property(e => e.RoomTypeName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.TypeDescription).HasMaxLength(250);
                entity.Property(e => e.TypeNote).HasMaxLength(250);
            });

            // Configure RoomInformation
            modelBuilder.Entity<RoomInformation>(entity =>
            {
                entity.HasKey(e => e.RoomID);
                entity.Property(e => e.RoomID).UseIdentityColumn(1, 1);
                entity.Property(e => e.RoomNumber).IsRequired().HasMaxLength(50);
                entity.Property(e => e.RoomDetailDescription).HasMaxLength(220);
                entity.Property(e => e.RoomStatus).HasColumnType("tinyint");
                entity.Property(e => e.RoomPricePerDay).HasColumnType("money");

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.RoomInformations)
                    .HasForeignKey(d => d.RoomTypeID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure BookingReservation
            modelBuilder.Entity<BookingReservation>(entity =>
            {
                entity.HasKey(e => e.BookingReservationID);
                entity.Property(e => e.BookingReservationID).ValueGeneratedNever();
                entity.Property(e => e.BookingDate).HasColumnType("date");
                entity.Property(e => e.TotalPrice).HasColumnType("money");
                entity.Property(e => e.BookingStatus).HasColumnType("tinyint");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.BookingReservations)
                    .HasForeignKey(d => d.CustomerID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure BookingDetail
            modelBuilder.Entity<BookingDetail>(entity =>
            {
                entity.HasKey(e => new { e.BookingReservationID, e.RoomID });
                entity.Property(e => e.StartDate).HasColumnType("date").IsRequired();
                entity.Property(e => e.EndDate).HasColumnType("date").IsRequired();
                entity.Property(e => e.ActualPrice).HasColumnType("money");

                entity.HasOne(d => d.BookingReservation)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.BookingReservationID)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.RoomInformation)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.RoomID)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
