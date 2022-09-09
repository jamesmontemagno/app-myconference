using Microsoft.CodeAnalysis.Emit;
using MyConference.Tests.UI.POM.AppShell.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;

namespace MyConference.Tests.UI.POM.AppShell;

internal class AndroidAppShellPage : MobilePage, IAndroidAppShellPage
{
    [FindsBy(How = How.AccessibilityId, Using = "Schedule")]
    private IWebElement ScheduleTab { get; set; }
    [FindsBy(How = How.AccessibilityId, Using = "ScheduleDay1")]
    private IWebElement ScheduleDay1Tab { get; set; }
    [FindsBy(How = How.AccessibilityId, Using = "ScheduleDay2")]
    private IWebElement ScheduleDay2Tab { get; set; }
    [FindsBy(How = How.AccessibilityId, Using = "My Agenda")]
    private IWebElement MyAgendaTab { get; set; }
    [FindsBy(How = How.AccessibilityId, Using = "MyAgendaDay1")]
    private IWebElement MyAgendaDay1Tab { get; set; }
    [FindsBy(How = How.AccessibilityId, Using = "MyAgendaDay2")]
    private IWebElement MyAgendaDay2Tab { get; set; }

    [FindsBy(How = How.AccessibilityId, Using = "Sponsors")]
    private IWebElement SponsorsTab { get; set; }


    public AndroidAppShellPage(IAppiumDriver driver) : base(driver)
    {
    }

    public void ClickSchedulerTab(int day)
    {
        ScheduleTab.Click();
        if (day == 1)
        {
            ScheduleDay1Tab.Click();
        }
        else
        {
            ScheduleDay2Tab.Click();
        }
    }

    public void ClickMyAgendaTab(int day)
    {
        MyAgendaTab.Click();
        if (day == 1)
        {
            MyAgendaDay1Tab.Click();
        }
        else
        {
            MyAgendaDay2Tab.Click();
        }
    }

    public void ClickSponsorTab()
    {
        SponsorsTab.Click();
    }
}
