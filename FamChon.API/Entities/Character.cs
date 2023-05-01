namespace FamChron.API.Entities
{
    public class Character
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StoryID { get; set; }
        public int EventID { get; set; }
    }
}
