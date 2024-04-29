using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using ClientApp.Services;

namespace ClientApp;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddSingleton(sp => new HttpClient {
            BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
        });

        builder.Services.AddBlazoredLocalStorage();

        
        builder.Services.AddSingleton<IBikeService, BikeService>();
        // Note: the HttpClient object for the BikeService constructor
        // is provided as a singleton - see line 16 

        await builder.Build().RunAsync();
    }
}

