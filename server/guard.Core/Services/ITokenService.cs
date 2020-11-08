using guard.Core.Models;

namespace guard.Core.Services
{
  public interface ITokenService
  {
    string CreateToken(User user);
  }
}
