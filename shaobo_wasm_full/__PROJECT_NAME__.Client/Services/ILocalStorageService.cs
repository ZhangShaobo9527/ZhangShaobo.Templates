using System.Threading.Tasks;

namespace __PROJECT_NAME__.Client.Services;

public interface ILocalStorageService
{
    Task InitAsync();

    Task<LocalStorageGetResult<T>> GetAsync<T>(string key);

    Task SetAsync<T>(string key, T value);

    Task WatchAsync<T>(T watcher) where T : class, ILocalStorageWatcher;
}