using TodoList.Models;

namespace ToDoListBlazorWasm.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginModel loginModel);
        Task Logout();
    }
}
