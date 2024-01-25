namespace Blazor.Frontend.Bootstrap.Classes
{
    public class NavLink
    {
        public string Href { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
    }

    public class NavLinkGroup
    {
        public string Title { get; set; } = string.Empty;
        public List<NavLink> Links { get; set; } = new List<NavLink>();
    }
}
