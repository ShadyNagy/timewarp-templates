namespace TimeWarp.Blazor.Features.Applications.Components
{
  using Microsoft.AspNetCore.Components;
  using TimeWarp.Blazor.Features.Bases.Client;

  public partial class NavMenu : BaseComponent
  {
    protected bool CollapseNavMenu { get; set; }

    protected string NavMenuCssClass => CollapseNavMenu ? "collapse" : null;

    protected void ToggleNavMenu() => CollapseNavMenu = !CollapseNavMenu;
  }
}
