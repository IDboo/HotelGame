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
    public class PlayerHotelMap : IEntityTypeConfiguration<PlayerHotel>
    {
        public void Configure(EntityTypeBuilder<PlayerHotel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.HotelTypeId);
            builder.Property(x => x.UserId);
            builder.Property(x => x.HotelName).IsRequired().HasMaxLength(20);
            builder.Property(x => x.HotelQuality);
            builder.Property(x => x.HotelLevel);
            builder.Property(x => x.HotelMoney);
            builder.Property(x => x.CustomerCommentPointAvarage);

            builder.ToTable("PlayerHotels");
        }
    }
}
