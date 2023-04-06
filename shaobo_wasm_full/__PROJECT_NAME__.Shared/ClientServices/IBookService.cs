using System.Threading.Tasks;

using __PROJECT_NAME__.Shared.Models;

namespace __PROJECT_NAME__.Shared.ClientServices;

public interface IBookService
{
    Task<Book[]?> GetBooksAsync();
}
