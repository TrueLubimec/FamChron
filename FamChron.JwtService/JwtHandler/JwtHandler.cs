using FamChron.JwtService.Entities;
using FamChron.JwtService.JwtHandler.Contracts;
using FamChron.JwtService.Repositories.Contracts;
using FamChron.Gateway.Protos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace FamChron.JwtService.JwtHandler
{
    public class JwtHandler : IJwtHandler
    {
        private readonly IConfiguration configuration;
        private readonly IAuthRepository authRepository;

        public JwtHandler(IConfiguration configuration, IAuthRepository authRepository) 
        {
            this.configuration = configuration;
            this.authRepository = authRepository;
        }
        public async Task<AuthResponse> CreateToken(AuthRequest authRequest)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, authRequest.UserName),
                new Claim(ClaimTypes.Role, authRequest.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                                       configuration.GetSection("Jwt:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var expiration =  BitConverter.ToInt16(Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:Expiration").Value!));
           

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(expiration),
                    signingCredentials: creds
                    );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            var response = new AuthResponse
            {
                UserName = authRequest.UserName,
                Token = jwt,
                Expiration = expiration
            };

            //TODO: error catch
            await authRepository.AddToken(response);

            return response; 


        }
    }
}
