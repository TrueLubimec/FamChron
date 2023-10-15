using FamChron.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace FamChron.Web.Pages
{
    public class HomePageBASE : ComponentBase
    {
        [Parameter]
        public int id { get; set; }
        
        [Inject]
        public ILoginService loginService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                loginService.
            }
        }
    }
}
