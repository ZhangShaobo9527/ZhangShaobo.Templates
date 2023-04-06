using System.Collections.Generic;

using __PROJECT_NAME__.Shared.Models;

namespace __PROJECT_NAME__.Test.MockData;

public static class MockBooks
{
    public static readonly List<Book> Books = new List<Book>()
    { 
        new Book{Id = 1, Name = "MockBook1", Author = "MockAuthor1", Price = 1.11M },
        new Book{Id = 2, Name = "MockBook2", Author = "MockAuthor2", Price = 2.22M },
        new Book{Id = 3, Name = "MockBook3", Author = "MockAuthor3", Price = 3.33M },
        new Book{Id = 4, Name = "MockBook4", Author = "MockAuthor4", Price = 4.44M },
    };
}
