using Microsoft.AspNetCore.Components;

namespace Blazor.Frontend.Components
{
    public partial class SpinnerDialog
    {
        [Parameter] public string Id { get; set; } = "spinner"; 
        [Parameter] public string Message { get; set; } = "Message goes here";
        [Parameter] public bool IsStatic { get; set;} = true;
        private Dictionary<string, object> atributes = new Dictionary<string, object> { { "data-bs-backdrop", "static" }, { "data-bs-keyboard", "false"} };
        protected override void OnInitialized()
        {
            if (!IsStatic)
            {
                atributes.Clear();
            }
            base.OnInitialized();
        }
    }
}
