using FamChron.Models.Dtos;
using FamChron.Web.Pages;
using FamChron.Web.Services.Contracts;
using System.Net.Http.Json;

namespace FamChron.Web.Services
{
    public class EventService : IEventService
    {
        private readonly HttpClient httpClient;

        public EventService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<EventDto> GetEvent(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Event/{id}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(EventDto);
                    }
                    return await response.Content.ReadFromJsonAsync<EventDto>();
                }
                else
                {
                    var message = response.Content.ReadAsStringAsync();
                    throw new Exception(message.ToString());
                }
            }
            catch (Exception)
            {
                //Log
                throw;
            }
        }

        // WORKING ON IT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public async Task<IEnumerable<EventDto>> GetEvents(int storyId)
        {
            try
            {
                var response = await this.httpClient.GetAsync($"api/Event/story{storyId}");
                
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<EventDto>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<EventDto>>();
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


        public async Task<EventDto> PostEvent(EventDto @event)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync("api/StorysEvent", @event);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(EventDto);
                    }
                    return await response.Content.ReadFromJsonAsync<EventDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status:{response.StatusCode} Message -{message}");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
