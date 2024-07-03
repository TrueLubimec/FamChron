using FamChron.Models.BaseModels;

namespace FamChron.Api.Entities
{
    public class User : BaseUser
    {
        public int id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}
