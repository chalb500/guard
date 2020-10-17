using System.Collections.Generic;
using System.Threading.Tasks;
using guard.Core.Models;

namespace guard.Core.Services
{
        public interface IEmployeeService
        {
            Task<IEnumerable<Employee>> GetAllEmployees();
            Task<Employee> GetEmployeeById(int id);

        }
}