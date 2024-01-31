using Microsoft.AspNetCore.Components;

namespace Frontend.Blazor.Tailwind.Classes
{
    public class ToolTipOptions
    {
        public string Text { get; set; } = string.Empty;
        public ElementReference Element { get; set; }
    }
}
