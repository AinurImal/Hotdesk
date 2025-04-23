using Hotdesk.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Hotdesk.Data;
using Hotdesk.Models;
using Hotdesk.Components.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextFactory<HotdeskContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HotdeskContext") ?? throw new InvalidOperationException("Connection string 'HotdeskContext' not found.")));

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<HotdeskContext>();
    context.Database.Migrate();

    if (!context.Desk.Any())
    {
        context.Desk.AddRange(
            new Desk { Id = 1, Name = "Desk A", Location = "First Floor", IsAvailable = true },
            new Desk { Id = 2, Name = "Desk B", Location = "Second Floor", IsAvailable = true },
            new Desk { Id = 3, Name = "Desk C", Location = "Third Floor", IsAvailable = true }
        );
        context.SaveChanges();
    }
}



app.Run();
