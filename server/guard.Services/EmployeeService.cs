using System.Collections.Generic;
using System.Threading.Tasks;
using guard.Core.Repositories;
using guard.Core.Models;
using guard.Core.Services;

namespace guard.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Employee> CreateEmployee(Employee newEmployee)
        {
            await _unitOfWork.Employees.AddAsync(newEmployee);
            await _unitOfWork.CommitAsync();
            return newEmployee;
        }

        public async Task DeleteEmployee(Employee employee)
        {
            _unitOfWork.Employees.Remove(employee);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _unitOfWork.Employees
                .GetAllAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _unitOfWork.Employees
                .GetEmployeeWithIdAsync(id);
        }

        public async Task UpdateEmployee(Employee employeeToUpdate, Employee employee)
        {
            employeeToUpdate.FirstName = employee.FirstName;
            employeeToUpdate.LastName = employee.LastName;
            employeeToUpdate.RoleId = employee.RoleId;
            await _unitOfWork.CommitAsync();
        }
    }
}