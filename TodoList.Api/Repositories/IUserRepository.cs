using TodoList.Models.Dtos;

namespace TodoList.Api.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<AssigneeDto>> GetAssignees();
    }
}
