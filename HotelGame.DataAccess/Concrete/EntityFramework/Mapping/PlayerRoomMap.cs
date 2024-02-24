using HotelGame.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.DataAccess.Concrete.EntityFramework.Mapping
{
    public class PlayerRoomMap : IEntityTypeConfiguration<PlayerRoom>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PlayerRoom> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.PlayerHotelId);
            builder.Property(x => x.RoomTypeId);
            builder.Property(x => x.RoomDailyPrice);
            builder.Property(x => x.Availability);

            builder.ToTable("PlayerRooms");

        }
    }
}
