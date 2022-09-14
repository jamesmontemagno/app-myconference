using MyConference.Tests.UI.POM.AppShell.Interfaces;
using MyConference.Tests.UI.StepDefinitions.MyAgendaPage.Interfaces;
using System.Reflection;
using TestWare.Engines.Selenium.Pages;

namespace MyConference.Tests.UI.POM.AppShell;

internal class AppShellPage: PageBase
{
    private IAppShellPage _appShellPage;

    internal AppShellPage(PageBase shellPage)
    {
        _appShellPage = (IAppShellPage)shellPage;
        Driver = shellPage.Driver;
    }

    public void ClickSchedulerTab(int day)
    {

        ClickElement(_appShellPage.ScheduleTab);
        if (day == 1)
        {
            ClickElement(_appShellPage.ScheduleDay1Tab);
        }
        else
        {
            ClickElement(_appShellPage.ScheduleDay2Tab);
        }
   }

    public void ClickMyAgendaTab(int day)
    {
        ClickElement(_appShellPage.MyAgendaTab);
        if (day == 1)
        {
            ClickElement(_appShellPage.MyAgendaDay1Tab);
        }
        else
        {
            ClickElement(_appShellPage.MyAgendaDay2Tab);
        }
    }

    public void ClickSponsorTab()
    {
        ClickElement(_appShellPage.SponsorsTab);
    }
}
