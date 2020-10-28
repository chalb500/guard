using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using guard.Core.Services;
using guard.Core.Models;
using AutoMapper;
using guard.Api.Resources;
using System.Security.Cryptography;
using System.Text;
using server.guard.Api.DTOs;

namespace guard.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]

  public class EmployeeController : ControllerBase
  {
    private readonly IEmployeeService _employeeService;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;
    public EmployeeController(IEmployeeService employeeService, IMapper mapper, ITokenService tokenService)
    {
      _tokenService = tokenService;
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

    [HttpPost("/api/employee/register")]
    public async Task<ActionResult<EmployeeDto>> Register(RegisterDto registerDto)
    {
      using var hmac = new HMACSHA512();
      var newEmployee = new Employee
      {
        FirstName = registerDto.FirstName,
        LastName = registerDto.LastName,
        Email = registerDto.Email,
        PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
        PasswordSalt = hmac.Key
      };
      var employee = await _employeeService.CreateEmployee(newEmployee);
      return Ok(new EmployeeDto
      {
        Email = newEmployee.Email,
        Token = _tokenService.CreateToken(newEmployee)
      });
    }

    [HttpPost("/api/employee/login")]
    public async Task<ActionResult<EmployeeDto>> Login(LoginDto loginDto)
    {
      var employee = await _employeeService.GetEmployeeByEmail(loginDto.Email);
      if (employee == null) return Unauthorized("Employee not found");
      using var hmac = new HMACSHA512(employee.PasswordSalt);

      var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

      for (int i = 0; i < computedHash.Length; i++)
      {
        if (computedHash[i] != employee.PasswordHash[i]) return Unauthorized("Invalid password");
      }

      return Ok(new EmployeeDto
      {
        Email = employee.Email,
        Token = _tokenService.CreateToken(employee)
      });
    }
  }
}
