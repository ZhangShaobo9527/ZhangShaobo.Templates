using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

using __PROJECT_NAME__.Shared.ClientServices;

namespace __PROJECT_NAME__.Test.ClientTest.MockServices
{
    internal class MockLocalStorageService : ILocalStorageService
    {
        private List<ILocalStorageWatcher> watchers = new List<ILocalStorageWatcher>();
        private Dictionary<string, object> dict = new Dictionary<string, object>();

        public bool ShouldThrowExceptionOnGet { get; set; } = false;

        public Task<LocalStorageGetResult<T>> GetAsync<T>(string key)
        {
            if(ShouldThrowExceptionOnGet)
            {
                throw new System.Exception("throw by MockLocalStorageService on purpose");
            }

            if(!dict.ContainsKey(key))
            {
                return Task.FromResult(new LocalStorageGetResult<T>(false, default(T)!));
            }
            else
            {
                return Task.FromResult(new LocalStorageGetResult<T>(true, (T)dict[key]));
            }
        }

        public Task InitAsync()
        {
            return Task.CompletedTask;
        }

        public async Task SetAsync<T>(string key, T value)
        {
            bool needInsertOrUpdate = false;

            if (!dict.ContainsKey(key))
            {
                needInsertOrUpdate = true;
            }
            else
            {

                string jsonStrOfStorageValue = JsonSerializer.Serialize(dict[key]);
                string jsonStrOfValue = JsonSerializer.Serialize(value);
                if (string.Compare(jsonStrOfValue, jsonStrOfStorageValue) != 0)
                {
                    needInsertOrUpdate = true;
                }
            }

            if (needInsertOrUpdate)
            {
                dict[key] = value!;
                foreach(ILocalStorageWatcher watcher in watchers)
                {
                    await watcher.OnLocalStorageChangeAsync();
                }
            }
        }

        public Task WatchAsync<T>(T watcher) where T : class, ILocalStorageWatcher
        {
            watchers.Add(watcher);
            return Task.CompletedTask;
        }

    }
}
