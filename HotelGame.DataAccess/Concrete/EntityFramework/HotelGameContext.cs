using HotelGame.DataAccess.Concrete.EntitiyFramework.Mapping;
using HotelGame.DataAccess.Concrete.EntityFramework.Mapping;
using HotelGame.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.DataAccess.Concrete.EntitiyFramework
{
    public class HotelGameContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public HotelGameContext()
        {

        }

        public HotelGameContext(DbContextOptions<HotelGameContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Server=DESKTOP-5R6CJJ3\SQLEXPRESS;Database=HotelGameDbUc;Trusted_Connection=true");

            }
            base.OnConfiguring(optionsBuilder);



        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<HotelPosition> HotelPositions { get; set; }
        public DbSet<HotelType> HotelTypes { get; set; }
        public DbSet<PlayerHotel> PlayerHotels { get; set; }
        public DbSet<PlayerHotelPosition> PlayerHotelPositions { get; set; }
        public DbSet<PlayerHotelStaff> PlayerHotelStaff { get; set; }
        public DbSet<PlayerRoom> PlayerRooms { get; set; }
        public DbSet<PlayerRoomMaterial> PlayerRoomMaterials { get; set; }
        public DbSet<RoomMaterial> RoomMaterials { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<RoomMaterial2> RoomMaterial2 { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new RoleMap());
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new UserTokenMap());
            builder.ApplyConfiguration(new UserRoleMap());
            builder.ApplyConfiguration(new UserLoginMap());
            builder.ApplyConfiguration(new RoleClaimMap());
            builder.ApplyConfiguration(new UserClaimMap());

            builder.ApplyConfiguration(new BookingMap());
            builder.ApplyConfiguration(new CustomerMap());
            builder.ApplyConfiguration(new HotelPositionMap());
            builder.ApplyConfiguration(new HotelTypeMap());
            builder.ApplyConfiguration(new PlayerHotelMap());
            builder.ApplyConfiguration(new PlayerHotelPositionMap());
            builder.ApplyConfiguration(new PlayerHotelStaffMap());
            builder.ApplyConfiguration(new PlayerRoomMap());
            builder.ApplyConfiguration(new PlayerRoomMaterialMap());
            builder.ApplyConfiguration(new RoomMaterialMap());
            builder.ApplyConfiguration(new RoomTypeMap());
            builder.ApplyConfiguration(new StaffMap());
            builder.ApplyConfiguration(new RoomMaterial2Map());


        }
    }
}