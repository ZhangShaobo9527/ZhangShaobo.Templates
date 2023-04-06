using System.Linq;
using System.Threading.Tasks;

using Moq;
using Xunit;

using __PROJECT_NAME__.Server.Controllers;
using __PROJECT_NAME__.Shared.Models;
using __PROJECT_NAME__.Shared.ServerServices;
using __PROJECT_NAME__.Test.MockData;

namespace __PROJECT_NAME__.Test.ServerTest.ControllersTest;

public class BookControllerTest
{
    private readonly BookController bookController;

    public BookControllerTest()
    {
        var mockBookService = new Mock<IBookService>();
        mockBookService
            .Setup(s => s.GetBooksAsync())
            .ReturnsAsync(MockBooks.Books);
        mockBookService
            .Setup(s => s.GetBookByIdAsync(It.IsAny<int>()))
            .ReturnsAsync((Book?)null);
        foreach(Book book in MockBooks.Books)
        {
            mockBookService
                .Setup(s => s.GetBookByIdAsync(book.Id))
                .ReturnsAsync(book);

        }
        this.bookController = new BookController(mockBookService.Object);
    }

    [Fact]
    public async Task GetBooks()
    {
        var res = await this.bookController.GetAllBooksAsync();
        Assert.NotNull(res);
        Assert.Equal(expected: MockBooks.Books.Count(), actual: res.Count());
    }

    [Fact]
    public async Task GetBookById_BookExists()
    {
        foreach(Book book in MockBooks.Books)
        {
            var res = await this.bookController.GetBookByIdAsync(book.Id);
            Assert.NotNull(res);
            Assert.Equal(expected: book.Id, actual: res.Id);
        }
    }

    [Fact]
    public async Task GetBookById_BookDoesNotExists()
    {
        var nonExistIds = Enumerable.Range(1, 100).Where(id => !MockBooks.Books.Select(b => b.Id).Contains(id));
        Assert.NotEmpty(nonExistIds);
        foreach(int id in nonExistIds)
        {
            var res = await this.bookController.GetBookByIdAsync(id);
            Assert.Null(res);
        }
    }
}
