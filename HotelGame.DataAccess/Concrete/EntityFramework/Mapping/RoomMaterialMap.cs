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
    public class RoomMaterialMap : IEntityTypeConfiguration<RoomMaterial>
    {
        public void Configure(EntityTypeBuilder<RoomMaterial> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ImageUrl);
            builder.Property(x => x.Level);
            builder.Property(x => x.Price);
            builder.Property(x => x.QualityPoint);

            builder.ToTable("RoomMaterial");

            builder.HasData(
                new RoomMaterial
                {
                    Id = 1,
                    Name = "Televizyon",
                    Level = 1,
                    Price = 1,
                    QualityPoint = 1,
                    IsActive = true,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow, 
                },
                new RoomMaterial
                {
                    Id = 2,
                    Name = "Yatak",
                    Level = 1,
                    Price = 1,
                    QualityPoint = 1,
                    IsActive = true,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new RoomMaterial
                {
                    Id = 3,
                    Name = "Klima",
                    Level = 1,
                    Price = 1,
                    QualityPoint = 1,
                    IsActive = true,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new RoomMaterial
                {
                    Id = 4,
                    Name = "Süs Eşyaları",
                    Level = 1,
                    Price = 1,
                    QualityPoint = 1,
                    IsActive = true,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new RoomMaterial
                {
                    Id = 5,
                    Name = "Banyo",
                    Level = 1,
                    Price = 1,
                    QualityPoint = 1,
                    IsActive = true,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new RoomMaterial
                {
                    Id = 6,
                    Name = "Tuvalet",
                    Level = 1,
                    Price = 1,
                    QualityPoint = 1,
                    IsActive = true,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                }
                );
        }
    }
}
