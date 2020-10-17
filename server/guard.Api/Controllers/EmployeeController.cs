using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using guard.Core.Services;
using guard.Core.Models;
using AutoMapper;
using guard.Api.Resources;

namespace guard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            this._mapper = mapper;
            this._employeeService = employeeService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            var Employees = await _employeeService.GetAllEmployees();
            var employeeResources = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeResource>>(Employees);
            return Ok(Employees);
        }
    }
}