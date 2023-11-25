using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.Frontend.Shared
{
    public partial class MainLayout
    {
        [Inject]
        public IJSRuntime? Js { get; set; }
        private IJSObjectReference? _js;
        public int Height { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //_js = await Js!.InvokeAsync<IJSObjectReference>("import", "./Shared/MainLayout.razor.js");
            //await GetPageDeminsions();
            await base.OnInitializedAsync();
        }

        public async Task<int> GetPageDeminsions()
        {
            var result = await _js!.InvokeAsync<int>("calulatePageHeight");
            Height = result;
            return result;
        }
    }
}
