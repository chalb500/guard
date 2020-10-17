using System;
using System.Threading.Tasks;
using guard.Core.Repositories;

namespace guard.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
         IEmployeeRepository Employees { get; }
         Task<int> CommitAsync();
    }
}