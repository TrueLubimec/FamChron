using FamChron.Models.BaseModels;

namespace FamChron.JwtService.Entities
{
    public class UserAccount : BaseUser
    {
        public string? Password { get; set; }

        public string? Role { get; set; }

    }
}
