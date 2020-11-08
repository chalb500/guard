using System.Collections.Generic;
using System.Threading.Tasks;
using guard.Core.Repositories;
using guard.Core.Models;
using guard.Core.Services;

namespace guard.Services
{
  public class UserService : IUserService
  {
    private readonly IUnitOfWork _unitOfWork;
    public UserService(IUnitOfWork unitOfWork)
    {
      this._unitOfWork = unitOfWork;
    }

    public async Task<User> CreateUser(User newUser)
    {
      await _unitOfWork.Users.AddAsync(newUser);
      await _unitOfWork.CommitAsync();
      return newUser;
    }

    public async Task DeleteUser(User user)
    {
      _unitOfWork.Users.Remove(user);
      await _unitOfWork.CommitAsync();
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
      return await _unitOfWork.Users
          .GetAllAsync();
    }

    public async Task<User> GetUserById(int id)
    {
      return await _unitOfWork.Users
          .GetUserWithIdAsync(id);
    }

    public async Task<User> GetUserByEmail(string email)
    {
      return await _unitOfWork.Users
          .GetUserByEmailAsync(email);

    }

    public async Task UpdateUser(User userToUpdate, User user)
    {
      userToUpdate.RoleId = user.RoleId;
      await _unitOfWork.CommitAsync();
    }
  }
}