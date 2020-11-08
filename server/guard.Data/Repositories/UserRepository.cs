using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using guard.Core.Models;
using guard.Core.Repositories;

namespace guard.Data.Repositories
{
  public class UserRepository : Repository<User>, IUserRepository
  {
    public UserRepository(GuardDBContext context) : base(context)
    { }

    public async Task<IEnumerable<User>> GetUsersAsync() => await GuardDBContext.Users
            .ToListAsync();
    public async Task<User> GetUserWithIdAsync(int id)
    {
      return await GuardDBContext.Users.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
      return await GuardDBContext.Users.Include(m => m.UserProfile).SingleOrDefaultAsync(x => x.Email == email);
    }

    private GuardDBContext GuardDBContext
    {
      get { return Context as GuardDBContext; }
    }
  }
}