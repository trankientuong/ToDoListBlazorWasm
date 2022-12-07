using TodoList.Models;
using TodoList.Models.Dtos;

namespace ToDoListBlazorWasm.Services
{
    public interface ITaskApiClient
    {
        Task<List<TaskDto>> GetTasks(TaskListSearch taskListSearch);
        Task<TaskDetailsDto> GetTaskDetails(string id);

        Task<bool> CreateTask(TaskCreateDto taskCreateDto);
        Task<bool> UpdateTask(TaskUpdateDto taskUpdateDto);
        Task<bool> AssignTask(Guid id,TaskAssignModel taskAssign);
        Task<bool> DeleteTask(Guid id);
    }
}
