using guard.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace guard.Data.Configurations
{
  public class UserConfiguration : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder
          .HasKey(m => m.Id);

      builder
          .Property(m => m.Id)
          .UseIdentityColumn();

      builder
          .Property(m => m.PasswordHash)
          .IsRequired();

      builder
          .Property(m => m.PasswordSalt)
          .IsRequired();
      builder
          .HasOne(m => m.UserProfile);
      builder
          .ToTable("Users");
    }
  }
}
