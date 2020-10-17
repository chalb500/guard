using System.Threading.Tasks;
using guard.Core;
using guard.Core.Repositories;
using guard.Data.Repositories;

namespace guard.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GuardDBContext _context;
        private EmployeeRepository _employeeRepository;

        public UnitOfWork(GuardDBContext context)
        {
            this._context = context;
        }

        public IEmployeeRepository Employees => _employeeRepository ?? new EmployeeRepository(_context);

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