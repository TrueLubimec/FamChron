using FamChron.Api.Entities;
using FamChron.Models.Dtos;
using FamChron.Models.UIModels;
using Microsoft.AspNetCore.Mvc;

namespace FamChron.Api.Repositories.Contracts
{
    public interface IAuthRepository
    {
        Task<ActionResult<User>> Login(User user);

        Task<User> Regitration(RegistrationUserDto user);
    }
}
