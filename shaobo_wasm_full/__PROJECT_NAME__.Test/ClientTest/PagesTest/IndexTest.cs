using AntDesign.Tests;
using Bunit;
using Fluxor;
using Moq;
using Xunit;

using Microsoft.Extensions.DependencyInjection;

using __PROJECT_NAME__.Client.Pages;
using __PROJECT_NAME__.Shared.ClientServices;
using __PROJECT_NAME__.Shared.StateManagement.Stores.Index;
using __PROJECT_NAME__.Test.ClientTest.MockServices;
using __PROJECT_NAME__.Test.MockData;

namespace __PROJECT_NAME__.Test.ClientTest.PagesTest;

public class IndexTest : AntDesignTestBase
{
    private MockLocalStorageService mockLocalStorageService = default!;
    private Mock<IBookService> MockBookService = default!;

    public IndexTest()
    {
        Context.Services.AddFluxor(options => options.ScanAssemblies(typeof(IndexStore).Assembly));
        Context.Services.AddScoped<ILocalStorageService, MockLocalStorageService>();

        this.MockBookService = new Mock<IBookService>();
        this.MockBookService.Setup(s => s.GetBooksAsync()).ReturnsAsync(MockBooks.Books.ToArray());


        Context.Services.AddScoped<IBookService>(sp => this.MockBookService.Object);
        // necessary for Fluxor
        Context.RenderComponent<Fluxor.Blazor.Web.StoreInitializer>();

        this.mockLocalStorageService = (MockLocalStorageService)Context.Services.GetService<ILocalStorageService>()!;
    }
    [Fact]
    public void Render_ShouldRenderLoadingIfBookServiceHang()
    {
        this.MockBookService.Setup(s => s.GetBooksAsync()).ReturnsAsync(MockBooks.Books.ToArray(), System.TimeSpan.MaxValue);
        var index = Context.RenderComponent<Index>();

        index.Find("em").MarkupMatches("<em>Loading books...</em>");
    }

    [Fact]
    public void Render_RenderBooksCorrectly()
    {
        var index = Context.RenderComponent<Index>();

        index.Find("table").MarkupMatches(@"
            <table border = ""1"">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Author</th>
                        <th>Price</th>
                    </tr>
                </thead>
                <tbody>
                        <tr>
                            <td>1</td>
                            <td>MockBook1</td>
                            <td>MockAuthor1</td>
                            <td>1.11</td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td>MockBook2</td>
                            <td>MockAuthor2</td>
                            <td>2.22</td>
                        </tr>
                        <tr>
                            <td>3</td>
                            <td>MockBook3</td>
                            <td>MockAuthor3</td>
                            <td>3.33</td>
                        </tr>
                        <tr>
                            <td>4</td>
                            <td>MockBook4</td>
                            <td>MockAuthor4</td>
                            <td>4.44</td>
                        </tr>
                </tbody>
            </table>
        ");
    }

    [Fact]
    public void Render_DefaultCurrentCountShouldBeZero()
    {
        var index = Context.RenderComponent<Index>();

        index.Find("h1").MarkupMatches("<h1>__PROJECT_NAME__ : Index</h1>");
        index.Find("p").MarkupMatches("<p>currentCount == 0</p>");
    }

    [Fact]
    public void Render_CurrentCountShouldBeZeroWhenLocalStorageCorrupted()
    {
        this.mockLocalStorageService.ShouldThrowExceptionOnGet = true;

        var index = Context.RenderComponent<Index>();

        index.Find("h1").MarkupMatches("<h1>__PROJECT_NAME__ : Index</h1>");
        index.Find("p").MarkupMatches("<p>currentCount == 0</p>");
    }

    [Fact]
    public void Render_CurrentCountShouldIncrWhenButtonClicked()
    {
        var index = Context.RenderComponent<Index>();

        for(int i = 0; i < 100; ++i)
        {
            index.Find(cssSelector:".ant-btn").Click();
            index.Find("p").MarkupMatches($"<p>currentCount == {i + 1}</p>");
        }
    }

    [Fact]
    public void Render_CurrentCountShouldBeValueInLocalStorage()
    {
        this.mockLocalStorageService.SetAsync<int>("CurrentCount", 9527).Wait();

        var index = Context.RenderComponent<Index>();

        index.Find("h1").MarkupMatches("<h1>__PROJECT_NAME__ : Index</h1>");
        index.Find("p").MarkupMatches($"<p>currentCount == {9527}</p>");
    }

    [Fact]
    public void Render_CurrentCountShouldSyncWithLocalStorageChange()
    {
        this.mockLocalStorageService.SetAsync<int>("CurrentCount", 9527).Wait();

        var index = Context.RenderComponent<Index>();

        index.Find("h1").MarkupMatches("<h1>__PROJECT_NAME__ : Index</h1>");
        index.Find("p").MarkupMatches($"<p>currentCount == {9527}</p>");

        this.mockLocalStorageService.SetAsync("CurrentCount", 8837).Wait();

        index.Find("p").MarkupMatches($"<p>currentCount == {8837}</p>");

        index.Find(cssSelector:".ant-btn").Click();
        index.Find("p").MarkupMatches($"<p>currentCount == {8838}</p>");
    }
}
