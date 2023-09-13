using Microsoft.AspNetCore.Components;
using FamChron.Web.Services.Contracts;
using FamChron.Models.Dtos;
using FamChron.Models.UIModels;
using FamChron.Web.Services;

namespace FamChron.Web.Pages
{
    public class StoryCreatorBASE : ComponentBase
    {
        [Inject]
        IStoryService storyService { get; set; } 
        public FormStory newStory { get; set; }

        protected override async Task OnInitializedAsync()
        {
            newStory =
                  new FormStory();
        }
        public async void Submit()
        {
            storyService.PostStory()
            
        }

    }
}
