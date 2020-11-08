using System;

namespace guard.Core.Models
{
  public class User
  {
    public int Id { get; set; }
    public int RoleId { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public UserProfile UserProfile {get; set;}

  }
}
