namespace FamChron.JwtService.Entities
{
    public class AuthRequest
    {
        public int id { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
    }
}
