using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ToDoListBlazorWasm;
using ToDoListBlazorWasm.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<ITaskApiClient, TaskApiClient>();
builder.Services.AddTransient<IUserApiClient, UserApiClient>();
builder.Services.AddBlazoredToast();
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration["BackEndAPIUrl"])
});

await builder.Build().RunAsync();
