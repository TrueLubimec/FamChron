using FamChron.JwtService.Entities;
using FamChron.Models.Dtos;
using FamChron.Models.UIModels;
using Microsoft.AspNetCore.Mvc;

namespace FamChron.JwtService.Repositories.Contracts
{
    public interface IAuthRepository
    {
        public Task AddToken(AuthResponse token);

        // Task<UserAccount> Regitration(RegistrationUserDto user);
    }
}
