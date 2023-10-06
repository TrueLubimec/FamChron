using FamChron.Api.Data;
using FamChron.Api.Entities;
using FamChron.Api.Repositories.Contracts;
using FamChron.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FamChron.Api.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly FamChronDbContext famChronDbContext;

        public AuthRepository(FamChronDbContext famChronDbContext)
        {
            this.famChronDbContext = famChronDbContext;
        }
        public Task<ActionResult<User>> Login(User user)
        {
            var result = famChronDbContext.Users.FindAsync(user.id);
        }

        public Task Regitration(RegistrationUserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
