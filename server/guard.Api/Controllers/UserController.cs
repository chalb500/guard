using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using guard.Core.Services;
using guard.Core.Models;
using AutoMapper;
using System.Security.Cryptography;
using System.Text;
using guard.Api.DTOs;

namespace guard.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]

  public class UserController : ControllerBase
  {
    private readonly IUserService _UserService;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;
    public UserController(IUserService UserService, IMapper mapper, ITokenService tokenService)
    {
      _tokenService = tokenService;
      this._mapper = mapper;
      this._UserService = UserService;
    }

    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
    {
      var Users = await _UserService.GetAllUsers();
      var UserResources = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(Users);
      return Ok(Users);
    }

    [HttpPost("/api/User/register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
      using var hmac = new HMACSHA512();
      var newUser = new User
      {
        UserProfile = new UserProfile
        {
          FirstName = registerDto.FirstName,
          LastName = registerDto.LastName
        },
        //FirstName = registerDto.FirstName,
        // LastName = registerDto.LastName,
        Email = registerDto.Email,
        PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
        PasswordSalt = hmac.Key
      };
      var User = await _UserService.CreateUser(newUser);
      return Ok(new UserDto
      {
        Email = newUser.Email,
        Token = _tokenService.CreateToken(newUser)
      });
    }

    [HttpPost("/api/User/login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
      var User = await _UserService.GetUserByEmail(loginDto.Email);
      if (User == null) return Unauthorized("User not found");
      using var hmac = new HMACSHA512(User.PasswordSalt);

      var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

      for (int i = 0; i < computedHash.Length; i++)
      {
        if (computedHash[i] != User.PasswordHash[i]) return Unauthorized("Invalid password");
      }

      var userDTO = _mapper.Map<User, UserDto>(User);

      return Ok(new UserDto
      {
        Email = userDTO.Email,
        Token = _tokenService.CreateToken(User),
        UserProfile = userDTO.UserProfile
      });
    }
  }
}