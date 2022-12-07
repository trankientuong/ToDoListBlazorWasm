using TodoList.Models.Dtos;

namespace ToDoListBlazorWasm.Services
{
    public interface IUserApiClient
    {
        Task<List<AssigneeDto>> GetAssignees();
    }
}
