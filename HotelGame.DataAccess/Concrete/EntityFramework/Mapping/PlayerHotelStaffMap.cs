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
    public class PlayerHotelStaffMap : IEntityTypeConfiguration<PlayerHotelStaff>
    {
        public void Configure(EntityTypeBuilder<PlayerHotelStaff> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.PlayerHotelPositionId);
            builder.Property(x => x.StaffId);
            
            builder.ToTable("PlayerHotelStaff");
        }
    }
}
