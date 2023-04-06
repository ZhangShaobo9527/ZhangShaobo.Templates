using System.Collections.Generic;
using System.Threading.Tasks;

using __PROJECT_NAME__.Shared.Models;

namespace __PROJECT_NAME__.Shared.ServerServices;

public interface IBookService
{
    Task<IEnumerable<Book>?> GetBooksAsync();
    Task<Book?> GetBookByIdAsync(int id);
}
