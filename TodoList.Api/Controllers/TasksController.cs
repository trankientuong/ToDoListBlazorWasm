using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models.Dtos;
using TodoList.Api.Repositories;
using TodoList.Models;
using AutoMapper;

namespace TodoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TasksController(ITaskRepository taskRepository,IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        // /api/tasks?name=
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] TaskListSearch taskListSearch)
        {
            return Ok(await _taskRepository.GetTasks(taskListSearch));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var task = await _taskRepository.GetTaskById(id);
            if(task == null) return NotFound($"{id} is not found");
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskCreateDto task)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var taskCreated = await _taskRepository.CreateTask(task);
            return CreatedAtAction(nameof(GetById),new {id = taskCreated.Id},taskCreated);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id,[FromBody] TaskUpdateDto task)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var taskInDb = await _taskRepository.GetTaskById(id);
            if (taskInDb == null) return NotFound($"{id} is not found");

            var taskUpdated = await _taskRepository.UpdateTask(task);
            return Ok(taskUpdated);
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Assign(Guid id, [FromBody] TaskAssignModel taskAssign)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var taskInDb = await _taskRepository.GetTaskById(id);
            if (taskInDb == null) return NotFound($"{id} is not found");
            var taskUpdateDto = _mapper.Map<TaskDetailsDto, TaskUpdateDto>(taskInDb);
            taskUpdateDto.AssigneeId = taskAssign.UserId;

            var taskUpdated = await _taskRepository.UpdateTask(taskUpdateDto);
            return Ok(taskUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var taskInDb = await _taskRepository.GetTaskById(id);
            if (taskInDb == null) return NotFound($"{id} is not found");

            var taskDeleted = await _taskRepository.DeleteTask(id);
            return Ok(taskDeleted);
        }
    }
}
