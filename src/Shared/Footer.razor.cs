namespace Blazor.Frontend.Shared
{
    public partial class Footer
    {
        public string CurrentYear { get => DateTime.Now.Year.ToString(); }
    }
}
