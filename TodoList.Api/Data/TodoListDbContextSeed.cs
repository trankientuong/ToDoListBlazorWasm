using Microsoft.AspNetCore.Identity;
using TodoList.Api.Entities;
using Enums = TodoList.Models.Enums;

namespace TodoList.Api.Data
{
    public class TodoListDbContextSeed
    {
        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
        //private readonly UserManager<User> _userManager;

        //public TodoListDbContextSeed(UserManager<User> userManager)
        //{
        //    _userManager = userManager;
        //}

        public async System.Threading.Tasks.Task SeedAsync(TodoListDbContext context, ILogger<TodoListDbContextSeed> logger)
        {
            if (!context.Users.Any())
            {
                var user = new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Tuong",
                    LastName = "Tran",
                    Email = "tuongtran1106@gmail.com",
                    NormalizedEmail = "TUONGTRAN1106@GMAIL.COM",
                    PhoneNumber = "0797205689",
                    UserName = "tuongtran1106",
                    NormalizedUserName = "TUONGTRAN1106",
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                user.PasswordHash = _passwordHasher.HashPassword(user, "Tuong1106!");
                context.Users.Add(user);
                await context.SaveChangesAsync();
            }

            if (!context.Tasks.Any())
            {
                context.Tasks.Add(new Entities.Task
                {
                    Id = Guid.NewGuid(),
                    Name = "Same task 1",
                    CreatedDate = DateTime.Now,
                    Priority = Enums.Priority.High,
                    AssigneeId = context.Users.First().Id,
                    Status = Enums.Status.Open
                });
                await context.SaveChangesAsync();
            }

            
        }
    }
}
