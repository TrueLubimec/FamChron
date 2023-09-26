using FamChron.Models.Dtos;
using FamChron.Models.UIModels;
using Microsoft.AspNetCore.Mvc;

namespace FamChron.Web.Services.Contracts
{
    public interface ILoginService
    {
        Task<ActionResult<FormUser>> Register(UserDto user);
        Task<ActionResult<FormUser>> Login(UserDto user);
    }
}
