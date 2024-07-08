using FamChron.Gateway.Protos;
using FamChron.Models.Dtos;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        
        
        public AccountController()
        {
            
        }

        //TODO: gRPC implementation to JwtHandler
        [HttpPost]
        public async Task<ActionResult<AuthenticationResponse>> Authenticate([FromBody] UserDto userDto)
        {
            var request = new AuthenticationRequest {
                Id = userDto.UserId,
                Username = userDto.Name,
                Password = userDto.Password,
                Role = userDto.Role
             };
            try
            {
                AppContext.SetSwitch(
    "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
                var channel = GrpcChannel.ForAddress("https://localhost:7290");
                var client = new AuthenticationGrpcService.AuthenticationGrpcServiceClient(channel);
                var response = client.Authenticate(request);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
