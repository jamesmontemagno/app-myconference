using MyConference.Tests.UI.StepDefinitions.MyAgendaPage.Interfaces;
using TestWare.Engines.Appium.WinAppDriver.Pages;

namespace MyConference.Tests.UI.POM.MyAgendaPage;

internal class WindowsMyAgendaPage : WinAppDriverPage, IWindowsMyAgendaPage
{
    [FindsBy(How = How.AccessibilityId, Using = "MyAgendaList")]
    private IWebElement MyAgendaList { get; set; }

    public WindowsMyAgendaPage(IWindowsDriver driver) : base(driver)
    {
    }

    public string GetScheduleItems()
    {
        return MyAgendaList?.Text;
    }
}
