using WebApp.ViewModels.Sections;

namespace WebApp.ViewModels.Views;

public class HomeIndexViewModel
{
    public string Title { get; set; } = "";
    public ShowcaseViewModel Showcase { get; set; } = null!;
}
