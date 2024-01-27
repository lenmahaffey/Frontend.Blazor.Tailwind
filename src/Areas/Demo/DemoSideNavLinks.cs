using Frontend.Blazor.Bootstrap.Classes;

namespace Frontend.Blazor.Bootstrap.Areas.Demo
{
    public static class DemoSideNavLinks
    {
        public static List<NavLinkGroup> Links { get; } =
            new List<NavLinkGroup>()
            {
                {
                    new NavLinkGroup()
                    {
                        Title = "Single",
                        Links = new List<NavLink>()
                        {
                            new NavLink() { Label = "Link 1", Href = "/"}
                        },
                    }
                },
                {
                    new NavLinkGroup()
                    {
                        Title = "Double",
                        Links = new List<NavLink>()
                        {
                            new NavLink(){ Label = "Link 1", Href = "/"},
                            new NavLink(){ Label = "Link 2", Href = "/"},
                        },

                    }
                },
                {
                    new NavLinkGroup()
                    {
                        Title = "Triple",
                        Links = new List<NavLink>()
                        {
                            new NavLink(){ Label = "Link 1", Href = "/"},
                            new NavLink(){ Label = "Link 2", Href = "/"},
                            new NavLink(){ Label = "Link 3", Href = "/"},
                        },
                    }
                },
            };
    }
}
