using HotelGame.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.DataAccess.Concrete.EntityFramework.Mapping
{
    public class RoomTypeMap : IEntityTypeConfiguration<RoomType>
    {
        public void Configure(EntityTypeBuilder<RoomType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ImageUrl);
            builder.Property(x => x.PeopleCount);

            builder.ToTable("RoomTypes");

            builder.HasData(
                new RoomType
                {
                    Id = 1,
                    Name = "Standart Double Oda",
                    IsActive = true,
                    PeopleCount = 2,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new RoomType
                {
                    Id = 2,
                    Name = "Standart Twin Oda",
                    IsActive = true,
                    PeopleCount = 2,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new RoomType
                {
                    Id = 3,
                    Name = "Superiour Double Oda",
                    IsActive = true,
                    PeopleCount = 2,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new RoomType
                {
                    Id = 4,
                    Name = "Aile Odası",
                    IsActive = true,
                    PeopleCount = 4,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new RoomType
                {
                    Id = 5,
                    Name = "King Size Oda",
                    IsActive = true,
                    PeopleCount = 2,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                }
                );
        }
    }
}
