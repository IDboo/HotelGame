﻿using HotelGame.Entities.Concrete;
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

        }
    }
}