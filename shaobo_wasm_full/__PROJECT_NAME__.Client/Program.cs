using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

using Fluxor;

using __PROJECT_NAME__.Shared.StateManagement.Stores.Index;
using __PROJECT_NAME__.Shared.ClientServices;

namespace __PROJECT_NAME__.Client;

[ExcludeFromCodeCoverage]
public class Program
{
    public static async Task Main(string[] args)
    {
        WebAssemblyHostBuilder hostBuilder = WebAssemblyHostBuilder.CreateDefault(args);
        hostBuilder.RootComponents.Add<App>("#app");
        hostBuilder.RootComponents.Add<HeadOutlet>("head::after");

        hostBuilder.Services.AddAntDesign();
        hostBuilder.Services.AddScoped(serviceProvider => new HttpClient { BaseAddress = new Uri(hostBuilder.HostEnvironment.BaseAddress) });
        hostBuilder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
        hostBuilder.Services.AddScoped<IBookService, HttpBookService>();
        hostBuilder.Services.AddFluxor(options => options.ScanAssemblies(typeof(IndexStore).Assembly));

        await hostBuilder.Build().RunAsync();
    }
}