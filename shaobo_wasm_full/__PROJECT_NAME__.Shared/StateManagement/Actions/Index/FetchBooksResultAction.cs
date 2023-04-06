using __PROJECT_NAME__.Shared.Models;

namespace __PROJECT_NAME__.Shared.StateManagement.Actions.Index;

public record FetchBooksResultAction(Book[]? books);
