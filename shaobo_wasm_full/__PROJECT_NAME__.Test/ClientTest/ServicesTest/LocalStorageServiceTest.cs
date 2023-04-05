using Bunit;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using __PROJECT_NAME__.Client.Services;
using Xunit;

namespace __PROJECT_NAME__.Test.ClientTest.ServicesTest;

public class LocalStorageServiceTest
{
    internal class DummyWatcher : ILocalStorageWatcher
    {
        public Task OnLocalStorageChangeAsync()
        {
            return Task.CompletedTask;
        }
    }

    [Fact]
    public async Task GetAsyncTestAsync()
    {
        string existKey = "exist";
        int existValue = 233;
        string nonExistKey = "non-exist";

        using var ctx = new TestContext();

        var localStorageModule = ctx.JSInterop.SetupModule("/modules/localStorage.js");
        localStorageModule.Setup<bool>("contains", nonExistKey).SetResult(false);
        localStorageModule.Setup<bool>("contains", existKey).SetResult(true);
        localStorageModule.Setup<int>("get", existKey).SetResult(existValue);

        ctx.Services.AddScoped<ILocalStorageService, LocalStorageService>();
        var lsService = ctx.Services.GetService<ILocalStorageService>();
        await lsService!.InitAsync();
        await lsService!.InitAsync();

        var nonExistResult = await lsService!.GetAsync<int>(nonExistKey);
        var existResult = await lsService!.GetAsync<int>(existKey);

        Assert.False(nonExistResult.Exist);
        Assert.Equal(actual: nonExistResult.Value, expected: 0);

        Assert.True(existResult.Exist);
        Assert.Equal(actual: existResult.Value, expected: existValue);
    }

    [Fact]
    public async Task SetAsyncTestAsync()
    {
        string key = "key";
        int value = 233;

        using var ctx = new TestContext();

        var localStorageModule = ctx.JSInterop.SetupModule("/modules/localStorage.js");
        localStorageModule.SetupVoid("set", key, value).SetVoidResult();
        localStorageModule.Setup<bool>("contains", key).SetResult(true);
        localStorageModule.Setup<int>("get", key).SetResult(value);

        ctx.Services.AddScoped<ILocalStorageService, LocalStorageService>();
        var lsService = ctx.Services.GetService<ILocalStorageService>();
        await lsService!.InitAsync();
        await lsService!.InitAsync();

        await lsService!.SetAsync(key, value);
        var result = await lsService!.GetAsync<int>(key);

        Assert.True(result.Exist);
        Assert.Equal(actual: result.Value, expected: value);
    }

    [Fact]
    public async Task WatchAsyncTestAsync()
    {
        using var ctx = new TestContext();

        var localStorageModule = ctx.JSInterop.SetupModule("/modules/localStorage.js");
        localStorageModule.SetupVoid("watch", _ => true).SetVoidResult();

        ctx.Services.AddScoped<ILocalStorageService, LocalStorageService>();
        var lsService = ctx.Services.GetService<ILocalStorageService>();
        await lsService!.InitAsync();
        await lsService!.InitAsync();

        await lsService!.WatchAsync<DummyWatcher>(new DummyWatcher());
    }
}
