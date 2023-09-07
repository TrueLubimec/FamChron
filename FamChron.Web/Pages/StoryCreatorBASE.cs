using Microsoft.AspNetCore.Components;
using FamChron.Web.Services.Contracts;

namespace FamChron.Web.Pages
{
    public class StoryCreatorBASE : ComponentBase
    {
        public string storyName { get; set; }
        public string description { get; set; }
        public string previewIMG { get; set; }

    }
}
