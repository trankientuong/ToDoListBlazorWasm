using TodoList.Models.Enums;

namespace TodoList.Models.Dtos
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? AssigneeId { get; set; }
        public string AssigneeName { get; set; }
        public DateTime CreatedDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
    }
}
