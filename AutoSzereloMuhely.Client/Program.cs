using AutoSzereloMuhely.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace AutoSzereloMuhely.Client;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5000")
        });

        builder.Services.AddScoped<IUgyfelService,UgyfelService>();
        builder.Services.AddScoped<IMunkaService,MunkaService>();

        await builder.Build().RunAsync();
    }
}