using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

using RichardSzalay.MockHttp;
using Xunit;

using __PROJECT_NAME__.Shared.ClientServices;
using __PROJECT_NAME__.Test.MockData;

namespace __PROJECT_NAME__.Test.ClientTest.ServicesTest;

public class HttpBookServiceTest
{
    private readonly HttpBookService httpBookService;
    private readonly string baseAddress = "https://__PROJECT_NAME__.Test.ClientTest";

    public HttpBookServiceTest()
    {
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When($"{baseAddress}/api/book")
            .Respond("application/json", JsonSerializer.Serialize(MockBooks.Books));
        var client = mockHttp.ToHttpClient();
        client.BaseAddress = new Uri(baseAddress);
        this.httpBookService = new HttpBookService(client);
    }

    [Fact]
    public async Task GetBooksAsync()
    {
        var books = await this.httpBookService.GetBooksAsync();

        Assert.NotNull(books);
        Assert.Equal(expected: MockBooks.Books.Count, actual: books.Count());
    }
}
