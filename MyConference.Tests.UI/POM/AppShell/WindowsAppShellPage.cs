using MyConference.Tests.UI.POM.AppShell.Interfaces;
using TestWare.Engines.Appium.WinAppDriver.Pages;

namespace MyConference.Tests.UI.POM.AppShell;

internal class WindowsAppShellPage : WinAppDriverPage, IWindowsAppShellPage
{
    private AppShellPage _commonLogic;

    [FindsBy(How = How.Name, Using = "Schedule")]
    public IWebElement ScheduleTab { get; set; }
    [FindsBy(How = How.Name, Using = "Day 1")]
    public IWebElement ScheduleDay1Tab { get; set; }
    [FindsBy(How = How.Name, Using = "Day 2")]
    public IWebElement ScheduleDay2Tab { get; set; }

    [FindsBy(How = How.Name, Using = "My Agenda")]
    public IWebElement MyAgendaTab { get; set; }
    [FindsBy(How = How.Name, Using = "Day 1")]
    public IWebElement MyAgendaDay1Tab { get; set; }
    [FindsBy(How = How.Name, Using = "Day 2")]
    public IWebElement MyAgendaDay2Tab { get; set; }

    [FindsBy(How = How.Name, Using = "Sponsors")]
    public IWebElement SponsorsTab { get; set; }

    public WindowsAppShellPage(IWindowsDriver driver) : base(driver)
    {
        _commonLogic = new AppShellPage(this);

    }

    public void ClickSchedulerTab(int day)
    {
        _commonLogic.ClickSchedulerTab(day);
    }

    public void ClickMyAgendaTab(int day)
    {
        _commonLogic.ClickMyAgendaTab(day);
    }

    public void ClickSponsorTab()
    {
        _commonLogic.ClickSponsorTab();
    }
}