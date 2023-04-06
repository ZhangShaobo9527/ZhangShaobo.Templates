using __PROJECT_NAME__.Shared.Models;

namespace __PROJECT_NAME__.Shared.StateManagement.Stores.Index;

public record IndexStore(
    int ClickCounter,
    bool IsLoading,
    Book[]? books);
