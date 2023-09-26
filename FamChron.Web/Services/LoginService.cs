﻿using FamChron.Models.Dtos;
using FamChron.Models.UIModels;
using FamChron.Web.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace FamChron.Web.Services
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient httpClient;

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
                    var token = response.Content.ReadAsStringAsync();
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

        public async Task<ActionResult<FormUser>> Register(UserDto user)
        {
            try
            {
                var response = await this.httpClient.PostAsJsonAsync<UserDto>($"api/auth/register", user);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        // Чёт не то !!!!!!!!!!!!!!!!!!!!!
                        return null;
                    }
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
