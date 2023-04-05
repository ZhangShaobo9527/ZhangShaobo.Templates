using System;
using System.Threading.Tasks;

using Microsoft.JSInterop;

using __PROJECT_NAME__.Client.Services;

namespace __PROJECT_NAME__.Client.Pages;

public partial class Index :ILocalStorageWatcher
{
    public int CurrentCount{ get; set; }

    private async Task OnButtonClickAsync()
    {
        this.CurrentCount++;
        await localStorage.SetAsync<int>(nameof(this.CurrentCount), this.CurrentCount);
    }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            await this.localStorage.InitAsync();
            await this.localStorage.WatchAsync(this);

            var lsResult = await this.localStorage.GetAsync<int>(nameof(this.CurrentCount));
            if (lsResult.Exist)
            {
                this.CurrentCount = lsResult.Value;
            }
        }
        catch
        {
            // localStorage corrupted, ignore
        }
    }

    [JSInvokable]
    public async Task OnLocalStorageChangeAsync()
    {
        var lsResult = await this.localStorage.GetAsync<int>(nameof(this.CurrentCount));

        if(lsResult.Value == this.CurrentCount)
        {
            return;
        }

        this.CurrentCount = lsResult.Value;
        await this.InvokeAsync(this.StateHasChanged);
    }
}
