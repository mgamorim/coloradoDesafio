using ColoradoDesafio.Web.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace ColoradoDesafio.Web.Services
{
    public class ClienteService : IClienteService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public ClienteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<IEnumerable<ClienteViewModel>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("api/clientes");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<ClienteViewModel>>(_jsonOptions);
        }

        public async Task<ClienteViewModel> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/clientes/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ClienteViewModel>(_jsonOptions);
            }
            return null;
        }

        public async Task<ClienteViewModel> CreateAsync(ClienteViewModel cliente)
        {
            var response = await _httpClient.PostAsJsonAsync("api/clientes", cliente);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ClienteViewModel>(_jsonOptions);
        }

        public async Task<ClienteViewModel> UpdateAsync(int id, ClienteViewModel cliente)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/clientes/{id}", cliente);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ClienteViewModel>(_jsonOptions);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/clientes/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
