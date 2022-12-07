using System.Net.Http.Json;
using TodoList.Models;
using TodoList.Models.Dtos;

namespace ToDoListBlazorWasm.Services
{
    public class TaskApiClient : ITaskApiClient
    {
        private readonly HttpClient _httpClient;

        public TaskApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AssignTask(Guid id,TaskAssignModel taskAssign)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/tasks/Assign/{id}", taskAssign);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> CreateTask(TaskCreateDto taskCreateDto)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/tasks",taskCreateDto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteTask(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"/api/tasks/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<TaskDetailsDto> GetTaskDetails(string id)
        {
            var response = await _httpClient.GetFromJsonAsync<TaskDetailsDto>($"/api/tasks/{id}");
            return response;
        }

        public async Task<List<TaskDto>> GetTasks(TaskListSearch taskListSearch)
        {
            string url = $"/api/tasks?name={taskListSearch.Name}&assigneeId={taskListSearch.AssigneeId}&priority={taskListSearch.Priority}";
            var response = await _httpClient.GetFromJsonAsync<List<TaskDto>>(url);
            return response;
        }

        public async Task<bool> UpdateTask(TaskUpdateDto taskUpdateDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/tasks/{taskUpdateDto.Id}", taskUpdateDto);
            return response.IsSuccessStatusCode;
        }
    }
}
