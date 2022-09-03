using System.Net.Http;
using Microsoft.AspNetCore.Http;

namespace WhoAmIGame.Services.ApiService
{
    public class ApiService
    {
        public HttpClient _httpClient;

        public ApiService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<IResult> CreateGuestAsync(object value = default)
        {
            var response = await _httpClient.PostAsJsonAsync("api/entry", value);

            try
            {
                return await response.Content.ReadAsAsync<IResult>();
            }
            catch (UnsupportedMediaTypeException ex)
            {
                var content = await response.Content.ReadAsStringAsync();
                throw new ApiException($"Произошла ошибка при разборе ответа от сервера: {ex.Message}", content, ex);
            }
        }

    }
}
