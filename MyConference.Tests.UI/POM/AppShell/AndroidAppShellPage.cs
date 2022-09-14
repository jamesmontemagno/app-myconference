using Microsoft.CodeAnalysis.Emit;
using MyConference.Tests.UI.POM.AppShell.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;

namespace MyConference.Tests.UI.POM.AppShell;

internal class AndroidAppShellPage : MobilePage, IAndroidAppShellPage
{
    private AppShellPage _commonLogic;

    [FindsBy(How = How.AccessibilityId, Using = "Schedule")]
    public IWebElement ScheduleTab { get; set; }
    [FindsBy(How = How.AccessibilityId, Using = "ScheduleDay1")]
    public IWebElement ScheduleDay1Tab { get; set; }
    [FindsBy(How = How.AccessibilityId, Using = "ScheduleDay2")]
    public IWebElement ScheduleDay2Tab { get; set; }
    [FindsBy(How = How.AccessibilityId, Using = "My Agenda")]
    public IWebElement MyAgendaTab { get; set; }
    [FindsBy(How = How.AccessibilityId, Using = "MyAgendaDay1")]
    public IWebElement MyAgendaDay1Tab { get; set; }
    [FindsBy(How = How.AccessibilityId, Using = "MyAgendaDay2")]
    public IWebElement MyAgendaDay2Tab { get; set; }

    [FindsBy(How = How.AccessibilityId, Using = "Sponsors")]
    public IWebElement SponsorsTab { get; set; }

    public AndroidAppShellPage(IAppiumDriver driver) : base(driver)
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
