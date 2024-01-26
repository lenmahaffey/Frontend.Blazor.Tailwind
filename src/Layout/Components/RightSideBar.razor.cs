namespace Blazor.Frontend.Bootstrap.Layout.Components
{
    public partial class RightSideBar
    {
        bool isActive { get; set; } = false;

        void ToggleVisibility()
        {
            isActive = !isActive;
        }
    }
}
