using System.ComponentModel.DataAnnotations;
using TodoList.Models.Enums;

namespace TodoList.Models.Dtos
{
    public class TaskUpdateDto
    {
        public Guid Id { get; set; }
        [MaxLength(20, ErrorMessage = "You cannot fill task name over than 20 characters")]
        [Required(ErrorMessage = "Please enter your task name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please select assignee")]
        public Guid? AssigneeId { get; set; }
        [Required(ErrorMessage = "Please select task priority")]
        public Priority? Priority { get; set; }
        [Required(ErrorMessage = "Please select task status")]
        public Status? Status { get; set; }
    }
}
