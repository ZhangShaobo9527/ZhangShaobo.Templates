using System.Threading.Tasks;

using Microsoft.JSInterop;

namespace __PROJECT_NAME__.Shared.ClientServices;

public interface ILocalStorageWatcher
{
    [JSInvokable]
    Task OnLocalStorageChangeAsync();
}