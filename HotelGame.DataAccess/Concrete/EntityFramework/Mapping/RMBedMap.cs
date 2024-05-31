using HotelGame.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HotelGame.DataAccess.Concrete.EntityFramework.Mapping
{
    public class RMBedMap : IEntityTypeConfiguration<RMBed>
    {
        public void Configure(EntityTypeBuilder<RMBed> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ImageUrl);
            builder.Property(x => x.Level);
            builder.Property(x => x.Price);
            builder.Property(x => x.QualityPoint);

            builder.ToTable("RMBeds");

            builder.HasData(
                new RMBed
                {
                    Id = 1,
                    Name = "Yatak",
                    Price = 20,
                    QualityPoint = 20,
                    IsActive = true,
                    Level = 1,
                },

                new RMBed
                {
                    Id = 2,
                    Name = "Yatak",
                    Price = 20,
                    QualityPoint = 20,
                    IsActive = true,
                    Level = 2,
                },
                new RMBed
                {
                    Id = 3,
                    Name = "Yatak",
                    Price = 20,
                    QualityPoint = 20,
                    IsActive = true,
                    Level = 3,
                },
                new RMBed
                {
                    Id = 4,
                    Name = "Yatak",
                    Price = 20,
                    QualityPoint = 20,
                    IsActive = true,
                    Level = 4,
                },
                new RMBed
                {
                    Id = 5,
                    Name = "Yatak",
                    Price = 20,
                    QualityPoint = 20,
                    IsActive = true,
                    Level = 5,
                },
                new RMBed
                {
                    Id = 6,
                    Name = "Yatak",
                    Price = 20,
                    QualityPoint = 20,
                    IsActive = true,
                    Level = 6,
                }
                );

        }
    }
}
