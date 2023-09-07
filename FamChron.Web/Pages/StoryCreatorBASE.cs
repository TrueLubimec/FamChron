using Microsoft.AspNetCore.Components;
using FamChron.Web.Services.Contracts;
using FamChron.Models.Dtos;


namespace FamChron.Web.Pages
{
    public class StoryCreatorBASE : ComponentBase
    {
        private StoryDto story = new StoryDto();

        protected override async Task OnInitializedAsync()
        {
            story = await 
        }


    }
}
