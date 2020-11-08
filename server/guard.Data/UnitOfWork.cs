using System.Threading.Tasks;
using guard.Core;
using guard.Core.Repositories;
using guard.Data.Repositories;

namespace guard.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GuardDBContext _context;
        private UserRepository _userRepository;

        public UnitOfWork(GuardDBContext context)
        {
            this._context = context;
        }

        public IUserRepository Users => _userRepository ?? new UserRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}