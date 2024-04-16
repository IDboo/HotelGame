using HotelGame.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.DataAccess.Concrete.EntityFramework.Mapping
{
    public class RMTelevisionMap : IEntityTypeConfiguration<RMTelevision>
    {
        public void Configure(EntityTypeBuilder<RMTelevision> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ImageUrl);
            builder.Property(x => x.Level);
            builder.Property(x => x.Price);
            builder.Property(x => x.QualityPoint);

            builder.ToTable("RMTelevisions");

            builder.HasData(
                new RMTelevision
                {
                    Id = 1,
                    Name = "1 Seviye",
                    Price = 20,
                    QualityPoint = 20,
                    IsActive = true,
                    Level = 1,
                },
                new RMTelevision
                {
                    Id = 2,
                    Name = "2 Seviye",
                    Price = 20,
                    QualityPoint = 20,
                    IsActive = true,
                    Level = 2,
                },
                new RMTelevision
                {
                    Id = 3,
                    Name = "3 Seviye",
                    Price = 20,
                    QualityPoint = 20,
                    IsActive = true,
                    Level = 3,
                },
                new RMTelevision
                {
                    Id = 4,
                    Name = "4 Seviye",
                    Price = 20,
                    QualityPoint = 20,
                    IsActive = true,
                    Level = 4,
                },
                new RMTelevision
                {
                    Id = 5,
                    Name = "5 Seviye",
                    Price = 20,
                    QualityPoint = 20,
                    IsActive = true,
                    Level = 5,
                },
                new RMTelevision
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
