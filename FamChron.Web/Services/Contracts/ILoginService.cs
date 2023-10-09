using FamChron.Models.Dtos;
using FamChron.Models.UIModels;
using Microsoft.AspNetCore.Mvc;

namespace FamChron.Web.Services.Contracts
{
    public interface ILoginService
    {
        Task<ActionResult<FormUser>> Login(UserDto user);
        Task<ActionResult<FormUser>> Register(RegistrationUserDto user);
    }
}
