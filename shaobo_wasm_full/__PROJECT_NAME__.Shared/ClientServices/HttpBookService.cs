using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using __PROJECT_NAME__.Shared.Models;

namespace __PROJECT_NAME__.Shared.ClientServices;

public class HttpBookService : IBookService
{
    private readonly HttpClient http;

    public HttpBookService(HttpClient http)
    {
        this.http = http;
    }

    public async Task<Book[]?> GetBooksAsync()
    {
        return await http.GetFromJsonAsync<Book[]>("api/book");
    }
}
