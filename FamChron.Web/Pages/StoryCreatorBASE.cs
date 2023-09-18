﻿using Microsoft.AspNetCore.Components;
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
        public int storyId { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            newStory = new FormStory();
        }
        public async void Submit()
        {
            var storyDto = new StoryDto()
            {
                id = newStory.Id,
                Name = newStory.Name
            };
            await storyService.PostStory(storyDto);            

            newStory = new FormStory();
        }
    }
}
