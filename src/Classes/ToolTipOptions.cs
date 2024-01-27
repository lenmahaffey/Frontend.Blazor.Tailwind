using Microsoft.AspNetCore.Components;

namespace Frontend.Blazor.Bootstrap.Classes
{
    public class ToolTipOptions
    {
        public string Text { get; set; } = string.Empty;
        public ElementReference Element { get; set; }
    }
}
