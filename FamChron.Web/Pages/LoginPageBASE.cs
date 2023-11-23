using FamChron.Models.Dtos;
using FamChron.Models.UIModels;
using FamChron.Web.Authentication;
using FamChron.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamChron.Web.Pages
{
    public class LoginPageBASE : ComponentBase
    {
        [Inject]
        ILoginService loginService { get; set; }

        public FormUser formUser {get; set;}

        [Inject]
        public NavigationManager navigationManager { get; set; }

        
        private UserAuthStateProvider userAuthStateProvider { get; set; }


        protected override async Task OnInitializedAsync()
        {
            formUser = new FormUser();
        }
        
        public async Task Login()
        {
            var userDto = new UserDto()
            {
                // UserId = formUser.UserId,
                Name = formUser.Name,
                Password = formUser.Password
            };

            var result = await loginService.Login(userDto);
            var authState = await userAuthStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            if (user.Identity is not null && user.Identity.IsAuthenticated)
            {
                navigationManager.NavigateTo($"/storycreator");
            }

        }

    }
}
