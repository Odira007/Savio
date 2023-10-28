using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavioApi.Dto.User.Requests;
using SavioApi.Models;

namespace SavioApi.Dependencies.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUser(CreateUserDto dto);
        Task<List<User>> GetUsers();
        Task<User> FindUser(Guid Id);
        Task<User> UserLogin(UserLoginDto dto);
        Task<User> GetSingleUserById(Guid Id);
        Task<User> UpdateUser(Guid Id,UpdateUserDto dto);
        Task<bool> DeleteUser(Guid Id);
        Task<bool> FindAny(Guid Id);
    }
}