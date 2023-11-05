using FamChron.Api.Data;
using FamChron.Api.Entities;
using FamChron.Api.Repositories.Contracts;
using FamChron.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FamChron.Api.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly FamChronDbContext famChronDbContext;

        public AuthRepository(FamChronDbContext famChronDbContext)
        {
            this.famChronDbContext = famChronDbContext;
        }
        public async Task<User> Login(User user)
        {
            var result = await famChronDbContext.Users.FirstOrDefaultAsync(name => name.UserName == user.UserName);
            return result;
        }

        public async Task<User> Regitration(RegistrationUserDto @user)
        {
            string passwordHash
                 = BCrypt.Net.BCrypt.HashPassword(@user.Password);
            var newUser = new User
            {
                id = @user.Id,
                UserName = @user.Name,
                PasswordHash = passwordHash
            };

            if (@user != null)
            {
                var result = await this.famChronDbContext.Users.AddAsync(newUser);
                await this.famChronDbContext.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }
    }
}
