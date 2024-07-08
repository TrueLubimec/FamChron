using FamChron.Gateway.Protos;
using FamChron.JwtService.Entities;

namespace FamChron.JwtService.JwtHandler.Contracts
{
    public interface IJwtHandler
    {
        public Task<AuthResponse> CreateToken(AuthRequest authRequest);
    }
}
