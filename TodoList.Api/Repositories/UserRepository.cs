using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoList.Api.Data;
using TodoList.Models.Dtos;

namespace TodoList.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TodoListDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(TodoListDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AssigneeDto>> GetAssignees()
        {
            return _mapper.Map<List<AssigneeDto>>(await _context.Users.ToListAsync());
        }
    }
}
