using MyConference.Tests.UI.POM.AppShell.Interfaces;
using OpenQA.Selenium;
using TestWare.Engines.Appium.WinAppDriver.Factory;
using TestWare.Engines.Appium.WinAppDriver.Pages;

namespace MyConference.Tests.UI.POM.AppShell;

internal class WindowsAppShellPage : WinAppDriverPage, IWindowsAppShellPage
{
    [FindsBy(How = How.Name, Using = "Schedule")]
    private IWebElement ScheduleTab { get; set; }
    [FindsBy(How = How.Name, Using = "Day 1")]
    private IWebElement ScheduleDay1Tab { get; set; }
    [FindsBy(How = How.Name, Using = "Day 2")]
    private IWebElement ScheduleDay2Tab { get; set; }

    [FindsBy(How = How.Name, Using = "My Agenda")]
    private IWebElement MyAgendaTab { get; set; }
    [FindsBy(How = How.Name, Using = "Day 1")]
    private IWebElement MyAgendaDay1Tab { get; set; }
    [FindsBy(How = How.Name, Using = "Day 2")]
    private IWebElement MyAgendaDay2Tab { get; set; }

    [FindsBy(How = How.Name, Using = "Sponsors")]
    private IWebElement SponsorsTab { get; set; }   
    
    public WindowsAppShellPage(IWindowsDriver driver) : base(driver)
    {
    }

    public void ClickSchedulerTab(int day)
    {
        ClickElement(ScheduleTab);
        if (day == 1)
        {
            ClickElement(ScheduleDay1Tab);
        }
        else
        {
            ClickElement(ScheduleDay2Tab);
        }
    }

    public void ClickMyAgendaTab(int day)
    {
        ClickElement(MyAgendaTab);
        if (day == 1)
        {
            ClickElement(MyAgendaDay1Tab);
        }
        else
        {
            ClickElement(MyAgendaDay2Tab);
        }
    }

    public void ClickSponsorTab()
    {
        ClickElement(SponsorsTab);
    }
}