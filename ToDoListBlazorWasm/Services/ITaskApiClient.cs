using TodoList.Models;
using TodoList.Models.Dtos;
using TodoList.Models.SeedWork;

namespace ToDoListBlazorWasm.Services
{
    public interface ITaskApiClient
    {
        Task<PagedList<TaskDto>> GetTasks(TaskListSearch taskListSearch);
        Task<TaskDetailsDto> GetTaskDetails(string id);

        Task<bool> CreateTask(TaskCreateDto taskCreateDto);
        Task<bool> UpdateTask(TaskUpdateDto taskUpdateDto);
        Task<bool> AssignTask(Guid id,TaskAssignModel taskAssign);
        Task<bool> DeleteTask(Guid id);
    }
}
