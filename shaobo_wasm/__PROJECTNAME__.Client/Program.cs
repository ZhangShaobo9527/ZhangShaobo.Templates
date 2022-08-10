using System;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace __PROJECTNAME__.Client;

public class Program
{
    public static async Task Main(string[] args)
    {
        WebAssemblyHostBuilder hostBuilder = WebAssemblyHostBuilder.CreateDefault(args);
        hostBuilder.RootComponents.Add<App>("#app");
        hostBuilder.RootComponents.Add<HeadOutlet>("head::after");

        hostBuilder.Services.AddScoped(serviceProvider => new HttpClient { BaseAddress = new Uri(hostBuilder.HostEnvironment.BaseAddress) });
        await hostBuilder.Build().RunAsync();
    }
}