using HotelGame.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelGame.DataAccess.Concrete.EntitiyFramework.Mapping
{
    public class UserClaimMap : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            // Primary key
            builder.HasKey(uc => uc.Id);

            // Maps to the AspNetUserClaims table
            builder.ToTable("AspNetUserClaims");
        }
    }


}