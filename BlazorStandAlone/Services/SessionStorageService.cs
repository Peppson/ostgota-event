using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorStandAlone.Services
{
    public class SessionStorageService
    {
        private readonly IJSRuntime _jsRuntime;

        public SessionStorageService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task SetItemAsync<T>(string key, T value) =>
            await _jsRuntime.InvokeVoidAsync("sessionStorageHelper.setItem", key, value);

        public async Task<T> GetItemAsync<T>(string key) =>
            await _jsRuntime.InvokeAsync<T>("sessionStorageHelper.getItem", key);

        public async Task RemoveItemAsync(string key) =>
            await _jsRuntime.InvokeVoidAsync("sessionStorageHelper.removeItem", key);

        public async Task ClearAsync() =>
            await _jsRuntime.InvokeVoidAsync("sessionStorageHelper.clear");
    }
}
