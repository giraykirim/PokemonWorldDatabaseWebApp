using webc.Client.Pages;
using webc.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using webc.Data;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Radzen;





var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextFactory<webcContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("webcContext") ?? throw new InvalidOperationException("Connection string 'webcContext' not found.")));

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();



builder.Services.AddScoped<ProtectedLocalStorage>();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<DialogService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(webc.Client._Imports).Assembly);


app.Run();
