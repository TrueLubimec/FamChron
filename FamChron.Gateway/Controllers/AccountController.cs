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
        private ILoggerFactory loggerFactory;

        public AccountController(ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
        }

        //TODO: убрать хардкод(appsettings) и сделать connection удобнее
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
                var channel = GrpcChannel.ForAddress("https://localhost:7290",
                                                                new GrpcChannelOptions { LoggerFactory = loggerFactory});
                var client = new AuthenticationGrpcService.AuthenticationGrpcServiceClient(channel);
                var response = client.Authenticate(request);
                if (response == null) //check return!!
                {
                    return Unauthorized();
                }
                return Ok(response);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
