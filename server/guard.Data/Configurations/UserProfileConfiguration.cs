using guard.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace guard.Data.Configurations
{
  public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
            {
                 builder
                    .HasKey(m => m.ProfileId);

                builder
                    .Property(m => m.ProfileId)
                    .UseIdentityColumn();   

                builder
                    .Property(m => m.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                builder
                    .Property(m => m.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
                
                builder
                    .ToTable("UserProfiles");
                    
            }
    }

}