using FamChron.Models.Dtos;
using FamChron.Models.UIModels;
using FamChron.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace FamChron.Web.Pages
{
    public class LoginBase : ComponentBase
    {
        [Inject]
        ILoginService loginService { get; set; }
        public FormUser formUser {get; set;}
        [Inject]
        public NavigationManager navigationManager { get; set; }


        protected override async Task OnInitializedAsync()
        {
            formUser = new FormUser();
        }
        
        public async Task Login()
        {
            var userDto = new UserDto()
            {
                UserId = formUser.UserId,
                Name = formUser.Name,
                Password = formUser.Password
            };

            var result = loginService.Login(userDto);
            navigationManager.NavigateTo($"/storycreator");
        }

    }
}
