namespace Blazor.Frontend.Bootstrap.Shared
{
    public partial class LeftSideBar
    {
        public Dictionary<string, string> Links { get; set; }

        public LeftSideBar()
        {
            Links = new Dictionary<string, string>
            {
                { "List Users", "/users" },
            };
        }
    }
}
