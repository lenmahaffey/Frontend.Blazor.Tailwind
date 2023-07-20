using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace Blazor.Frontend.Components
{
    public partial class ConfirmationDialog
    {
        [Parameter] public string Id { get; set; } = "confirm"; 
        [Parameter] public string Title { get; set; } = "Modal Title goes here";
        [Parameter] public string Message { get; set; } = "Message to user goes here";
        [Parameter] public string OkButtonText { get; set; } = "Ok";
        [Parameter] public string CancelButtonText { get; set; } = "Cancel";
        [Parameter] public bool DisableEscape { get; set; } = false;    
        [Parameter] public EventCallback<bool> UserResponse { get; set; }
        [Inject] public IJSRuntime? Js { get; set; }
        private IJSObjectReference? _js;
        private Dictionary<string, object> attributes = new Dictionary<string, object> { { "data-bs-backdrop", "static" }, { "data-bs-keyboard", "false" } };

        protected override async Task OnInitializedAsync()
        {
            if (!DisableEscape)
            {
                attributes.Clear();
            }
            _js = await Js!.InvokeAsync<IJSObjectReference>("import", "./Components/ConfirmationDialog.razor.js");
            await base.OnInitializedAsync();
        }

        public void ToggleModal()
        {
            _js!.InvokeVoidAsync("ToggleModal", Id);
        }
        private Task Cancel(MouseEventArgs e)
        {
            return UserResponse.InvokeAsync(false);
        }
        private Task Ok(MouseEventArgs e)
        {
            ToggleModal();
            return UserResponse.InvokeAsync(true);
        }
    }
}
