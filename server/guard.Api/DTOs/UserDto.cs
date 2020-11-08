namespace guard.Api.DTOs
{
  public class UserDto
  {
    public string Email { get; set; }
    public string Token { get; set; }
    public int RoleId {get; set;}
    public UserProfileDto UserProfile {get; set;}
  }
}
