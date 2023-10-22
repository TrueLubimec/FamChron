using FamChron.Models.Dtos;
using FamChron.Web.Authentication;
using FamChron.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace FamChron.Web.Pages
{
    public class RegistraionBASE : ComponentBase
    {
        [Inject]
        ILoginService loginService { get; set; }

        public RegistrationUserDto registrationUser {get; set;}


        protected override async Task OnInitializedAsync()
        {
            registrationUser = new RegistrationUserDto();
        }

        public async Task Registration()
        {
            var result = loginService.Register(registrationUser);
        }
    }
}
