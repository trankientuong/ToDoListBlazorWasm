using TodoList.Models;
using TodoList.Models.Dtos;
using TodoList.Models.SeedWork;

namespace TodoList.Api.Repositories
{
    public interface ITaskRepository
    {
        Task<PagedList<TaskDto>> GetTasks(TaskListSearch taskListSearch);
        Task<TaskDetailsDto> CreateTask(TaskCreateDto task);
        Task<TaskDetailsDto> UpdateTask(TaskUpdateDto task);
        Task<TaskDetailsDto> DeleteTask(Guid id);
        Task<TaskDetailsDto> GetTaskById(Guid id);
    }
}
