using System.Collections.Generic;
using System.Threading.Tasks;
using guard.Core.Models;

namespace guard.Core.Repositories
{
  public interface IUserRepository : IRepository<User>
  {
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> GetUserWithIdAsync(int id);
    Task<User> GetUserByEmailAsync(string email);
  }
}
