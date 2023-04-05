using System.Threading.Tasks;

using Microsoft.JSInterop;

namespace __PROJECT_NAME__.Client.Services;

public interface ILocalStorageWatcher
{
    [JSInvokable]
    Task OnLocalStorageChangeAsync();
}