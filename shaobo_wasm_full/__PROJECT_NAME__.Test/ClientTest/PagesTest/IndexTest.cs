using AntDesign.Tests;
using Bunit;
using Xunit;

using Microsoft.Extensions.DependencyInjection;

using __PROJECT_NAME__.Client.Pages;
using __PROJECT_NAME__.Client.Services;
using __PROJECT_NAME__.Test.ClientTest.MockServices;

namespace __PROJECT_NAME__.Test.ClientTest.PagesTest;

public class IndexTest : AntDesignTestBase
{
    [Fact]
    public void Render_default()
    {
        Context.Services.AddScoped<ILocalStorageService, MockLocalStorageService>();
        var index = Context.RenderComponent<Index>();

        index.Find("h1").MarkupMatches("<h1>__PROJECT_NAME__ : Index</h1>");
        index.Find("p").MarkupMatches("<p>currentCount == 0</p>");
    }

    [Fact]
    public void Render_localStorage_throw_exception_when_get()
    {

        Context.Services.AddScoped<ILocalStorageService>(sp =>
        {
            var ls = new MockLocalStorageService();
            ls.ShouldThrowExceptionOnGet = true;
            return ls;
        });
        var index = Context.RenderComponent<Index>();

        index.Find("h1").MarkupMatches("<h1>__PROJECT_NAME__ : Index</h1>");
        index.Find("p").MarkupMatches("<p>currentCount == 0</p>");
    }

    [Fact]
    public void Render_click_button()
    {
        Context.Services.AddScoped<ILocalStorageService, MockLocalStorageService>();
        var index = Context.RenderComponent<Index>();

        for(int i = 0; i < 100; ++i)
        {
            index.Find(cssSelector:".ant-btn").Click();
            index.Find("p").MarkupMatches($"<p>currentCount == {i + 1}</p>");
        }
    }

    [Fact]
    public void Render_with_value_in_localStorage()
    {
        Context.Services.AddScoped<ILocalStorageService>(sp => {
            var mockLSService = new MockLocalStorageService();
            mockLSService.SetAsync<int>("CurrentCount", 9527).Wait();
            return mockLSService;

        });
        var index = Context.RenderComponent<Index>();


        index.Find("h1").MarkupMatches("<h1>__PROJECT_NAME__ : Index</h1>");
        index.Find("p").MarkupMatches($"<p>currentCount == {9527}</p>");
    }

    [Fact]
    public void Render_with_localStorageChange()
    {
        Context.Services.AddScoped<ILocalStorageService>(sp => {
            var mockLSService = new MockLocalStorageService();
            mockLSService.SetAsync<int>("CurrentCount", 9527).Wait();
            return mockLSService;

        });
        var index = Context.RenderComponent<Index>();

        index.Find("h1").MarkupMatches("<h1>__PROJECT_NAME__ : Index</h1>");
        index.Find("p").MarkupMatches($"<p>currentCount == {9527}</p>");

        var lsService = Context.Services.GetService<ILocalStorageService>();
        lsService!.SetAsync("CurrentCount", 8837).Wait();

        index.Find("p").MarkupMatches($"<p>currentCount == {8837}</p>");
    }
}
