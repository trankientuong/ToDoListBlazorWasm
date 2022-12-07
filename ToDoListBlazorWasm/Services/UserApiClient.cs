using System.Net.Http.Json;
using TodoList.Models.Dtos;

namespace ToDoListBlazorWasm.Services
{
    public class UserApiClient : IUserApiClient
    {
        private readonly HttpClient _httpClient;

        public UserApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<AssigneeDto>> GetAssignees()
        {
            var response = await _httpClient.GetFromJsonAsync<List<AssigneeDto>>("/api/users");
            return response;
        }
    }
}
