using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using guard.Core.Models;
using guard.Core.Repositories;

namespace guard.Data.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(GuardDBContext context) : base(context)
        {}

        public async Task<IEnumerable<Employee>> GetEmployeesAsync() => await GuardDBContext.Employees
                .ToListAsync();
        public async Task<Employee> GetEmployeeWithIdAsync(int id)
        {
            return await GuardDBContext.Employees.FirstOrDefaultAsync(m => m.Id == id);
        }

        private GuardDBContext GuardDBContext
        {
            get { return Context as GuardDBContext; }
        }
    }
}