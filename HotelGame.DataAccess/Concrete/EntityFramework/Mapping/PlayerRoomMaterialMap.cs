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
    public class PlayerRoomMaterialMap : IEntityTypeConfiguration<PlayerRoomMaterial>
    {
        public void Configure(EntityTypeBuilder<PlayerRoomMaterial> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.PlayerRoomId);
            builder.Property(x => x.RoomMaterialId);

            builder.ToTable("PlayerRoomMaterials");
        }
    }
}
