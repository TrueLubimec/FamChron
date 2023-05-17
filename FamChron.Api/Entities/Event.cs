namespace FamChron.Api.Entities
{
    public class Event
    {
        public int id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string PreviewPhoto { get; set; }
        public string Photos { get; set; }
        public int StoryID { get; set; }
    }
}
