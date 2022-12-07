using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Json;
using TodoList.Models;
using TodoList.Models.Dtos;
using TodoList.Models.SeedWork;

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

        public async Task<PagedList<TaskDto>> GetTasks(TaskListSearch taskListSearch)
        {
            //string url = $"/api/tasks?name={taskListSearch.Name} " +
            //    $"&assigneeId={taskListSearch.AssigneeId} " +
            //    $"&priority={taskListSearch.Priority}";

            var queryStringParams = new Dictionary<string, string>
            {
                ["pageNumber"] = taskListSearch.PageNumber.ToString(),
            };

            if (!string.IsNullOrEmpty(taskListSearch.Name))
                queryStringParams.Add("name", taskListSearch.Name);
            if (taskListSearch.AssigneeId.HasValue)
                queryStringParams.Add("assigneeId", taskListSearch.AssigneeId.ToString());
            if (taskListSearch.Priority.HasValue)
                queryStringParams.Add("priority", taskListSearch.Priority.ToString());

            string url = QueryHelpers.AddQueryString("/api/tasks",queryStringParams);
            var response = await _httpClient.GetFromJsonAsync<PagedList<TaskDto>>(url);
            return response;
        }

        public async Task<bool> UpdateTask(TaskUpdateDto taskUpdateDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/tasks/{taskUpdateDto.Id}", taskUpdateDto);
            return response.IsSuccessStatusCode;
        }
    }
}
