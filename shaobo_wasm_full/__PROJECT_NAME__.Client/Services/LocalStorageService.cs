using System.Threading.Tasks;

using Microsoft.JSInterop;

namespace __PROJECT_NAME__.Client.Services;

public class LocalStorageService : ILocalStorageService
{
    private readonly IJSRuntime js = default!;
    private IJSObjectReference? module;

    public LocalStorageService(IJSRuntime js)
    {
        this.js = js;
    }

    public async Task InitAsync()
    {
        if(this.module is not null)
        {
            return;
        }

        this.module = await this.js.InvokeAsync<IJSObjectReference>("import", "/modules/localStorage.js");
    }

    public async Task<LocalStorageGetResult<T>> GetAsync<T>(string key)
    {

        bool exists = await this.module!.InvokeAsync<bool>("contains", key);
        if(!exists)
        {
            return new(false, default(T)!);
        }

        T value = await this.module!.InvokeAsync<T>("get", key);
        return new(true, value);
    }

    public async Task SetAsync<T>(string key, T value)
    {
        await this.module!.InvokeVoidAsync("set", key, value);
        return;
    }

    public async Task WatchAsync<T>(T watcher) where T : class, ILocalStorageWatcher
    {
        await this.module!.InvokeVoidAsync("watch", DotNetObjectReference.Create(watcher));
        return;
    }
}
