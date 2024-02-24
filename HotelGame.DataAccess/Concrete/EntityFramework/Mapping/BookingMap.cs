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
    public class BookingMap : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.PlayerRoomId).IsRequired();
            builder.Property(x => x.CustomerId).IsRequired();
            builder.Property(x => x.CustomerComment).HasMaxLength(500);
            builder.Property(x => x.CustomerCommentPoint);
            builder.ToTable("Bookings");
        }
    }
}
