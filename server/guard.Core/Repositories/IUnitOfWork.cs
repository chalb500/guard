using System;
using System.Threading.Tasks;
using guard.Core.Repositories;

namespace guard.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
         IUserRepository Users { get; }
         Task<int> CommitAsync();
    }
}