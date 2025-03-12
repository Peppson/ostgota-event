using Blazor.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Blazor;

class Program
{
    static void Main()
    {        
        var builder = WebApplication.CreateBuilder();

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        builder.Services.AddScoped<ProtectedSessionStorage>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts(); 
        }

        app.UseHttpsRedirection();


        app.UseAntiforgery();

        app.MapStaticAssets(); 
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}
 