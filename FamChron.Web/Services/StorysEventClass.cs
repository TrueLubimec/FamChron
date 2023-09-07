using FamChron.Web.Pages;
using FamChron.Web.Services.Contracts;
using System.Net.Http.Json;

namespace FamChron.Web.Services
{
    public class StorysEventClass : IStorysEventService
    {
        private readonly HttpClient httpClient;

        public StorysEventClass(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public Task<IEnumerable<Event>> GetAllEvents(int storyId)
        {
            throw new NotImplementedException();
        }

        public async Task<Event> PostEvent(Event @event)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync<Event>("api/StorysEvent", @event);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent) 
                    {
                        return default(Event);
                    }
                    return await response.Content.ReadFromJsonAsync<Event>();
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
