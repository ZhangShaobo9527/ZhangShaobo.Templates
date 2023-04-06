using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using __PROJECT_NAME__.Shared.Models;

namespace __PROJECT_NAME__.Shared.ServerServices;

public class StaticBookService : IBookService
{
    private Book[] books = new[]
    {
        new Book
        {
            Id = 1,
            Name = "A Tale of Two Cities",
            Author = "Charles Dickens",
            Price = 19.99M
        },
        new Book
        {
            Id = 2,
            Name = "The Little Prince",
            Author = "Antoine de Saint Exupery",
            Price = 9.99M
        },
        new Book
        {
            Id = 3,
            Name = "Harry Potter and the Philosopher's Stone",
            Author = "J.K. Rowling",
            Price = 14.99M
        },
    };

    public Task<Book?> GetBookByIdAsync(int id)
    {
        return Task.FromResult(this.books.FirstOrDefault(b => b.Id == id));
    }

    public Task<IEnumerable<Book>?> GetBooksAsync()
    {
        return Task.FromResult<IEnumerable<Book>?>(this.books);
    }
}
