using HotelGame.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HotelGame.DataAccess.Concrete.EntityFramework.Mapping
{
    public class RMBathRoomMap : IEntityTypeConfiguration<RMBathRoom>
    {
        public void Configure(EntityTypeBuilder<RMBathRoom> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ImageUrl);
            builder.Property(x => x.Level);
            builder.Property(x => x.Price);
            builder.Property(x => x.QualityPoint);

            builder.ToTable("RMBathRooms");

            builder.HasData(
                new RMBathRoom
                {
                    Id = 1,
                    Name = "1 Seviye",
                    Price = 20,
                    QualityPoint = 20,
                    IsActive = true,
                    Level = 1,
                },
                new RMBathRoom
                {
                    Id = 2,
                    Name = "2 Seviye",
                    Price = 20,
                    QualityPoint = 20,
                    IsActive = true,
                    Level = 2,
                },
                new RMBathRoom
                {
                    Id = 3,
                    Name = "3 Seviye",
                    Price = 20,
                    QualityPoint = 20,
                    IsActive = true,
                    Level = 3,
                },
                new RMBathRoom
                {
                    Id = 4,
                    Name = "4 Seviye",
                    Price = 20,
                    QualityPoint = 20,
                    IsActive = true,
                    Level = 4,
                },
                new RMBathRoom
                {
                    Id = 5,
                    Name = "5 Seviye",
                    Price = 20,
                    QualityPoint = 20,
                    IsActive = true,
                    Level = 5,
                },
                new RMBathRoom
                {
                    Id = 6,
                    Name = "6 Seviye",
                    Price = 20,
                    QualityPoint = 20,
                    IsActive = true,
                    Level = 6,
                }
                );

        }
    }
}
