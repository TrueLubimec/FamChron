using FamChron.Models.Dtos;
using FamChron.Models.UIModels;
using FamChron.Web.Authentication;
using FamChron.Web.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace FamChron.Web.Services
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient httpClient;
        private ILocalStorageService localStorageService;
        private UserAuthStateProvider userAuthStateProvider;
        public LoginService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        //LATER !!!!!!!!
        public async Task<ActionResult<FormUser>> Login(UserDto user)
        {
            try
            {
                var response = await this.httpClient.PostAsJsonAsync<UserDto>($"api/auth/login", user);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        // Чёт не то !!!!!!!!!!!!!!!!!!!!!
                        return null;
                    }
                    var token = await response.Content.ReadAsStringAsync();
                    await localStorageService.SetItemAsync("token", token);
                    await userAuthStateProvider.GetAuthenticationStateAsync();
                    return await response.Content.ReadFromJsonAsync<FormUser>();

                }
                else
                {
                    var message = response.Content.ReadAsStringAsync();
                    throw new Exception(message.ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<ActionResult<FormUser>> Register(RegistrationUserDto user)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync($"api/Auth", user);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        // Чёт не то !!!!!!!!!!!!!!!!!!!!!
                        return null;
                    }
                    // Тут ЗАПУТАЛСЯ немного...
                    return await response.Content.ReadFromJsonAsync<FormUser>();
                }
                else
                {
                    var message = response.Content.ReadAsStringAsync();
                    throw new Exception(message.ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
