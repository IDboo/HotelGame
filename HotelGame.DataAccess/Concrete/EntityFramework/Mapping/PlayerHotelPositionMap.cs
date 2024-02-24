using HotelGame.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.DataAccess.Concrete.EntityFramework.Mapping
{
    public class PlayerHotelPositionMap : IEntityTypeConfiguration<PlayerHotelPosition>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PlayerHotelPosition> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.PlayerHotelId);
            builder.Property(x => x.HotelPositionId);
            builder.Property(x => x.StaffCount);

            builder.ToTable("PlayerHotelPositions");
        }
    }
}
