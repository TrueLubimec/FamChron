using FamChron.Api.Entities;
using FamChron.Models.Dtos;
using FamChron.Models.UIModels;
using Microsoft.AspNetCore.Mvc;

namespace FamChron.JwtService.Repositories.Contracts
{
    public interface IAuthRepository
    {
        Task<User> Login(User user);

        Task<User> Regitration(RegistrationUserDto user);
    }
}
