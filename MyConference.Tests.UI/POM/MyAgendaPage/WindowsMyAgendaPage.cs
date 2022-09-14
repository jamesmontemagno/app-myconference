using MyConference.Tests.UI.StepDefinitions.MyAgendaPage.Interfaces;
using TestWare.Engines.Appium.WinAppDriver.Pages;

namespace MyConference.Tests.UI.POM.MyAgendaPage;

internal class WindowsMyAgendaPage : WinAppDriverPage, IWindowsMyAgendaPage
{
    private MyAgendaPage _commonLogic;

    [FindsBy(How = How.AccessibilityId, Using = "MyAgendaList")]
    public IWebElement MyAgendaList { get; set; }

    public WindowsMyAgendaPage(IWindowsDriver driver): base(driver)
    {
        _commonLogic = new(this);
    }

    public string GetScheduleItems()
    {
        return _commonLogic.GetScheduleItems();   
    }
}
