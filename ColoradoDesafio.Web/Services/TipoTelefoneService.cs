using ColoradoDesafio.Web.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace ColoradoDesafio.Web.Services
{
    public class TipoTelefoneService : ITipoTelefoneService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public TipoTelefoneService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<IEnumerable<TipoTelefoneViewModel>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("api/tipostelefone");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<TipoTelefoneViewModel>>(_jsonOptions);
        }
    }
}
