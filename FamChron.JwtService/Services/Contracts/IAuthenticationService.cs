using FamChron.Gateway.Protos;
using FamChron.JwtService.Entities;
using Grpc.Core;

namespace FamChron.JwtService.Services.Contracts
{
    public interface IAuthenticationService
    {
        public Task<AuthenticationResponse> Authenticate(AuthenticationRequest authRequest, ServerCallContext context);
    }
}
