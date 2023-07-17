using Microsoft.AspNetCore.Components;

namespace FamChron.Web.Pages
{
    public class StoryCreatorBASE : ComponentBase
    {
        public string storyName { get; set; }
        public DateTime storyDate { get; set; }
        public string description { get; set; }
        public string previewIMG { get; set; }
    }
}
