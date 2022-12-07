using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoList.Api.Data;
using TodoList.Models;
using TodoList.Models.Dtos;

namespace TodoList.Api.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TodoListDbContext _context;
        private readonly IMapper _mapper;

        public TaskRepository(TodoListDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TaskDetailsDto> CreateTask(TaskCreateDto taskDto)
        {
            var task = _mapper.Map<Entities.Task>(taskDto);
            task.CreatedDate = DateTime.Now;
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            var taskDetailsDto = _mapper.Map<TaskDetailsDto>(task);
            return taskDetailsDto;
        }

        public async Task<TaskDetailsDto> DeleteTask(Guid id)
        {
            var taskInDb = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(taskInDb);
            await _context.SaveChangesAsync();
            var taskDetailsDto = _mapper.Map<TaskDetailsDto>(taskInDb);
            return taskDetailsDto;
        }

        public async Task<TaskDetailsDto> GetTaskById(Guid id)
        {
            var taskInDb = await _context.Tasks.Include(a => a.Assignee).FirstOrDefaultAsync(x => x.Id == id);
            var taskDetailsDto = _mapper.Map<TaskDetailsDto>(taskInDb);
            return taskDetailsDto;
        }

        public async Task<IEnumerable<TaskDto>> GetTasks(TaskListSearch taskListSearch)
        {
            var query = _context.Tasks.Include(a => a.Assignee).AsQueryable();
            if (!string.IsNullOrEmpty(taskListSearch.Name))
            {
                query = query.Where(x => x.Name.Contains(taskListSearch.Name));
            }

            if (taskListSearch.AssigneeId.HasValue)
            {
                query = query.Where(x => x.AssigneeId.Value == taskListSearch.AssigneeId.Value);
            }

            if (taskListSearch.Priority.HasValue)
            {
                query = query.Where(x => x.Priority == taskListSearch.Priority.Value);
            }


            return _mapper.Map<IEnumerable<TaskDto>>(await query.OrderByDescending(x => x.CreatedDate).ToListAsync());
        }

        public async Task<TaskDetailsDto> UpdateTask(TaskUpdateDto taskDto)
        {
            var taskInDb = await _context.Tasks.FindAsync(taskDto.Id);
            taskInDb = _mapper.Map<TaskUpdateDto, Entities.Task>(taskDto, taskInDb);
            _context.Tasks.Update(taskInDb);
            await _context.SaveChangesAsync();
            var taskDetailsDto = _mapper.Map<TaskDetailsDto>(taskInDb);
            return taskDetailsDto;
        }
    }
}
