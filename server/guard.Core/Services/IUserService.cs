using System.Collections.Generic;
using System.Threading.Tasks;
using guard.Core.Models;

namespace guard.Core.Services
{
  public interface IUserService
  {
    Task<IEnumerable<User>> GetAllUsers();
    Task<User> GetUserById(int id);
    Task<User> CreateUser(User newUser);
    Task<User> GetUserByEmail(string email);
  }
}
