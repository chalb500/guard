using System.Collections.Generic;
using System.Threading.Tasks;
using guard.Core.Models;

namespace guard.Core.Repositories
{
    public interface IEmployeeRepository : IRepository <Employee>
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetEmployeeWithIdAsync(int id);
        
    }
}