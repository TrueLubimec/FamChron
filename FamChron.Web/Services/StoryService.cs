using FamChron.Models.Dtos;
using FamChron.Web.Services.Contracts;
using System.Net.Http.Json;

namespace FamChron.Web.Services
{
    public class StoryService : IStoryService
    {
        private readonly HttpClient httpClient;

        public StoryService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        //public async Task<IEnumerable<StoryDto>> GetStories(int userId)
        //{
        //    try
        //    {
        //        var response = await httpClient.GetAsync($"api/Story/{userId}");
        //        if (response.IsSuccessStatusCode)
        //        {
        //            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
        //            {
        //                return default(IEnumerable<StoryDto>);
        //            }
        //            return await response.Content.ReadFromJsonAsync<StoryDto>();
        //        }
        //        else
        //        {
        //            var message = response.Content.ReadAsStringAsync();
        //            throw new Exception(message.ToString());
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        //Log
        //        throw;
        //    }
        //}
        public async Task<StoryDto> GetStory(int storyId)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Story/{storyId}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(StoryDto);
                    }
                    return await response.Content.ReadFromJsonAsync<StoryDto>();
                }
                else
                {
                    var message = response.Content.ReadAsStringAsync();
                    throw new Exception(message.ToString());
                }
            }
            catch(Exception)
            {
                //Log
                throw;
            }
        }

        public async Task<StoryDto> PostStory(StoryDto @story)
        {
            try
            {
                var response = await this.httpClient.PostAsJsonAsync<StoryDto>("api/Story", @story);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return  default(StoryDto);
                    }
                    return await response.Content.ReadFromJsonAsync<StoryDto>();
                }
                else
                {
                    var message = response.Content.ReadAsStringAsync();
                    throw new Exception(message.ToString());
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
