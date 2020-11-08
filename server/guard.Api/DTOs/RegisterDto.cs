using System.ComponentModel.DataAnnotations;

namespace guard.Api.DTOs
{
  public class RegisterDto
  {
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [MinLength(6)]
    public string Password { get; set; }
  }
}
