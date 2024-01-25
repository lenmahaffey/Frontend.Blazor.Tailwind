using Blazor.Frontend.Bootstrap.Classes;

namespace Blazor.Frontend.Bootstrap.Layout
{
    public class TopNavLinks
    {
        public static List<NavLinkGroup> Links { get; } =
            new List<NavLinkGroup>()
            {
                {
                    new NavLinkGroup()
                    {
                        Title = "Area 1",
                        Links = new List<NavLink>()
                        {
                            new NavLink() { Label = "Area 1 Link 1", Href = "/"}
                        },
                    }
                },
                {
                    new NavLinkGroup()
                    {
                        Title = "Area 2",
                        Links = new List<NavLink>()
                        {
                            new NavLink(){ Label = "Area 2 Link 1", Href = "/"},
                            new NavLink(){ Label = "Area 2 Link 2", Href = "/"},
                        },
                    }
                },
                {
                    new NavLinkGroup()
                    {
                        Title = "Area 3",
                        Links = new List<NavLink>()
                        {
                            new NavLink(){ Label = "Area 3 Link 1", Href = "/"},
                            new NavLink(){ Label = "Area 3 Link 2", Href = "/"},
                            new NavLink(){ Label = "Area 3 Link 3", Href = "/"},
                        },
                    }
                },
            };
    }
}
