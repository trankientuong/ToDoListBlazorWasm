using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Models.Dtos
{
    public class AssigneeDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
    }
}
