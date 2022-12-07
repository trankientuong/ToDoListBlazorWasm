using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using TodoList.Models;
using TodoList.Models.Dtos;
using TodoList.Models.Enums;
using TodoList.Models.SeedWork;
using ToDoListBlazorWasm.Components;
using ToDoListBlazorWasm.Pages.Components;
using ToDoListBlazorWasm.Services;

namespace ToDoListBlazorWasm.Pages
{
    public partial class TaskList
    {
        [Inject] private ITaskApiClient TaskApiClient { get; set; }
        [Inject] private IToastService toastService { get; set; }

        private List<TaskDto> Tasks;
        public Guid deleteId;

        public Confirmation DeleteConfirmation { get; set; }

        public TaskAssign TaskAssignDialog { get; set; }

        public MetaData MetaData { get; set; } = new MetaData();
        private TaskListSearch TaskListSearch = new TaskListSearch();



        protected override async Task OnInitializedAsync()
        {
            await GetTasks();
        }

        public async Task SearchTask(TaskListSearch taskListSearch)
        {
            this.TaskListSearch = taskListSearch;
            await GetTasks();
            toastService.ShowInfo("Search successfully", "Success");
        }

        public void OnDeleteTask(Guid deleteId)
        {
            this.deleteId = deleteId;
            DeleteConfirmation.Show();
        }

       public async Task OnConfirmDeleteTask(bool isDeleteConfirmed)
        {
            if (isDeleteConfirmed)
            {
                await TaskApiClient.DeleteTask(deleteId);
                await GetTasks();
                toastService.ShowSuccess("Delete successfully", "Success");
            }
        }

        public void OpenAssignPopup(Guid id)
        {
            TaskAssignDialog.Show(id);
        }

        public async Task AssignTaskSucces(bool result)
        {
            if (result)
            {
                await GetTasks();
                toastService.ShowSuccess("Assign task successfully", "Success");
            }
            else
            {
                toastService.ShowError("Assign task failed", "Error");
            }
        }

        private async Task GetTasks()
        {
            var pagingResponse = await TaskApiClient.GetTasks(TaskListSearch);
            Tasks = pagingResponse.Items;
            MetaData = pagingResponse.MetaData;
        }

        private async Task SelectedPage(int page)
        {
            TaskListSearch.PageNumber = page;
            await GetTasks();
        }
    }


}
