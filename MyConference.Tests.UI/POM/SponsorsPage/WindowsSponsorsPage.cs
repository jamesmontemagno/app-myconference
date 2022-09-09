using MyConference.Tests.UI.StepDefinitions.SponsorsPage.Interfaces;
using TestWare.Engines.Appium.WinAppDriver.Pages;

namespace MyConference.Tests.UI.POM.SponsorsPage;

internal class WindowsSponsorsPage : WinAppDriverPage, IWindowsSponsorsPage
{

    [FindsBy(How = How.AccessibilityId, Using = "SponsorsList")]
    private IWebElement SponsorsList { get; set; }


    public WindowsSponsorsPage(IWindowsDriver driver) : base(driver)
    {
    }

    public string GetSponsors()
    {
        return SponsorsList?.Text;
    }
}