using FamChron.Models.UIModels;
using FamChron.Web.Authentication;
using FamChron.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

namespace FamChron.Web.Pages
{
    public class HomePageBASE : ComponentBase
    {
        public int id { get; set; }
        
        [Inject]
        public ILocalStorageService localStorageService { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> authenticationState { get; set; }

        //[Inject]
        UserManager<FormUser> userManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var user = (await authenticationState).User;
                if (user.Identity.IsAuthenticated)
                {
                    var authUser = await userManager.GetUserAsync(user);
                    id = authUser.UserId;
                }
                //var authstate = await userAuthStateProvider.GetAuthenticationStateAsync();
                //var user = authstate.User;
                //var name = user.Identity.Name;
                
            }
            catch
            {

            }
        }
    }
}
