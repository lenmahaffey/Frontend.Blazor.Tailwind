namespace Frontend.Blazor.Tailwind.Layout.Components
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
