using BlazorStandAlone.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorStandAlone;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");
        
        // Configure HttpClient with the correct API base address
        builder.Services.AddScoped(sp => new HttpClient { 
            BaseAddress = new Uri("https://localhost:7189/") // Update this to match your API URL
        });

        // Add other services
        builder.Services.AddScoped<SessionStorageService>();

        await builder.Build().RunAsync();
    }
}
