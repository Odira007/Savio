using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SavioApi.Data;
using SavioApi.Dependencies.Interfaces;
using SavioApi.Dto.User.Requests;
using SavioApi.Models;

namespace SavioApi.Dependencies.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly SavioDbContext _context;
        public UserService(IMapper mapper,SavioDbContext context)
        {
            _context = context;
            _mapper = mapper;
            
        }
        public async Task<User> CreateUser(CreateUserDto dto)
        {
            var check=await _context.Users.FirstOrDefaultAsync(x=>x.Email==dto.Email||x.PhoneNumber==dto.PhoneNumber||x.BVN==dto.BVN);
            if(check!=null){
                return null;
            }
            var user=_mapper.Map<User>(dto);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;

        }

        public async Task<bool> DeleteUser(Guid Id)
        {
            var user=await FindUser(Id);
            if(user==null){
                return false;
            }
             _context.Users.Remove(user);
             await _context.SaveChangesAsync();
             return true;
        }

        public async Task<bool> FindAny(Guid Id)
        {
            return await _context.Users.AnyAsync(x=>x.UserId==Id);
        }

        public async Task<User> FindUser(Guid Id)
        {
           var user=await _context.Users.FindAsync(Id);
           if(user==null){
            return null;
           }
           return user;
        }

        public async Task<User> GetSingleUserById(Guid Id)
        {
            return await FindUser(Id);
        }

       

        public async Task<List<User>> GetUsers()
        {
            var users=await _context.Users.ToListAsync();
            if(users==null){
                return null;
            }
            return users;
        }

        public async Task<User> UpdateUser(Guid Id, UpdateUserDto dto)
        {
            var result = await FindUser(Id);
            if (result == null)
            {
                return null;

            }
            result.FirstName = dto.FirstName;
            result.LastName = dto.LastName;
            result.Email = dto.Email;
            result.PhoneNumber = dto.PhoneNumber;
            result.ProfilePicture = dto.ProfilePicture;
            result.Password=dto.ConfirmPassword;
            _context.Entry(result).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return result;
        }

           public async Task<User> UserLogin(UserLoginDto dto)
        {
            var user=await _context.Users.FirstOrDefaultAsync(x=>(x.PhoneNumber==dto.EmailOrPhoneNumber||x.Email==dto.EmailOrPhoneNumber)&&x.Password==dto.Password);
            if(user==null){
                return null;
            }
            return user;
        }
    }
}