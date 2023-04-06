using System.Threading.Tasks;

using Xunit;

using __PROJECT_NAME__.Shared.ServerServices;

namespace __PROJECT_NAME__.Test.ServerTest.ServicesTest;

public class StaticBookServiceTest
{
    private readonly StaticBookService staticBookService;

    public StaticBookServiceTest()
    {
        this.staticBookService = new StaticBookService();
    }

    [Fact]
    public async Task GetBooksAsync()
    {
        var books = await this.staticBookService.GetBooksAsync();

        Assert.NotNull(books);
    }

    [Fact]
    public async Task GetBookByIdAsync()
    {
        var book = await this.staticBookService.GetBookByIdAsync(1);

        Assert.NotNull(book);
    }
}
