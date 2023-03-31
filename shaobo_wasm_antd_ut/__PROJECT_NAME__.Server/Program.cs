using System.Diagnostics.CodeAnalysis;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace __PROJECT_NAME__.Server;

[ExcludeFromCodeCoverage]
public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder webApplicationBuilder = WebApplication.CreateBuilder(args);

        webApplicationBuilder.Services.AddControllersWithViews();
        webApplicationBuilder.Services.AddRazorPages();

        WebApplication webApplication = webApplicationBuilder.Build();

        if (webApplication.Environment.IsDevelopment())
        {
            webApplication.UseWebAssemblyDebugging();
        }
        else
        {
            webApplication.UseExceptionHandler("/Error");
            webApplication.UseHsts();
        }

        webApplication.UseHttpsRedirection();

        webApplication.UseBlazorFrameworkFiles();
        webApplication.UseStaticFiles();

        webApplication.UseRouting();

        webApplication.MapRazorPages();
        webApplication.MapControllers();
        webApplication.MapFallbackToFile("index.html");

        webApplication.Run();
    }
}