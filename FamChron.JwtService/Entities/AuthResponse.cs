﻿namespace FamChron.JwtService.Entities
{
    public class AuthResponse
    {
        public int id { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public int Expiration { get; set; }
    }
}
