using System.Threading.Tasks;

using Fluxor;

using __PROJECT_NAME__.Shared.ClientServices;
using __PROJECT_NAME__.Shared.Models;
using __PROJECT_NAME__.Shared.StateManagement.Actions.Index;

namespace __PROJECT_NAME__.Shared.StateManagement.Effects.Index;

public class FetchBooksActionEffect : Effect<FetchBooksAction>
{
    private readonly IBookService bookService;

    public FetchBooksActionEffect(IBookService bookService)
    {
        this.bookService = bookService;
    }

    public override async Task HandleAsync(FetchBooksAction action, IDispatcher dispatcher)
    {
        Book[]? books = await this.bookService.GetBooksAsync();
        dispatcher.Dispatch(new FetchBooksResultAction(books));
    }
}
