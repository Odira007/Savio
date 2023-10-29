using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavioApi.Dto.User.Requests;
using SavioApi.Models;
using SavioApi.Models.Data;

namespace SavioApi.Dependencies.Interfaces
{
    public interface IUserService
    {
        Task<Users> CreateUser(CreateUserDto dto);
        Task<List<Users>> GetUsers();
        Task<Users> FindUser(Guid Id);
        Task<Users> UserLogin(UserLoginDto dto);
        Task<Users> GetSingleUserById(Guid Id);
        Task<Users> UpdateUser(Guid Id,UpdateUserDto dto);
        Task<bool> DeleteUser(Guid Id);
        Task<bool> FindAny(Guid Id);
    }
}