using FamChron.JwtService.Entities;
using FamChron.JwtService.JwtHandler.Contracts;
using FamChron.Gateway.Protos;
using FamChron.JwtService.Services.Contracts;
using Grpc.Core;

namespace FamChron.JwtService.Services
{
    public class AuthenticationService : AuthenticationGrpcService.AuthenticationGrpcServiceBase, IAuthenticationService
    {
        private readonly IJwtHandler jwtHandler;

        public AuthenticationService(IJwtHandler jwtHandler)
        {
            this.jwtHandler = jwtHandler;
        }

        public override async Task<AuthenticationResponse> Authenticate(AuthenticationRequest authRequest, ServerCallContext contextn)
        {
                var request = new AuthRequest
            {
                id = authRequest.Id,
                UserName = authRequest.Username,
                Password = authRequest.Password,
                Role = authRequest.Role
            };
            try
            {
                var authResponse = await jwtHandler.CreateToken(request);
                if (authRequest == null) return null; // СДЕЛАТЬ ОБРАБОТКУ ОШИБОК
                var response = new AuthenticationResponse
                {
                    Id = authResponse.id,
                    Username = authResponse.UserName,
                    Token = authResponse.Token,
                    Expiration = authResponse.Expiration
                };
                return response;
            }
            //TODO: сделать отлов под разные ошибки
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
