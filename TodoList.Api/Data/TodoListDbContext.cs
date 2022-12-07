using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoList.Api.Entities;


namespace TodoList.Api.Data
{
    public class TodoListDbContext : IdentityDbContext<User,Role,Guid>
    {
        public DbSet<Entities.Task> Tasks { get; set; }


        public TodoListDbContext(DbContextOptions<TodoListDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);                                                     
        }
    }
}
