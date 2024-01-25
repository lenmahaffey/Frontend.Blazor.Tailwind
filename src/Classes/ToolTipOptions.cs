using Microsoft.AspNetCore.Components;

namespace Blazor.Frontend.Bootstrap.Classes
{
    public class ToolTipOptions
    {
        public string Text { get; set; } = string.Empty;
        public ElementReference Element { get; set; }
    }
}
